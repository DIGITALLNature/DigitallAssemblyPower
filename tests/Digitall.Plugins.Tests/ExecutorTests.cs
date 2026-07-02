// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.Threading.Tasks;
using Digitall.Dataverse.Testing;
using Digitall.Dataverse.Testing.Extensions;
using Microsoft.Xrm.Sdk;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;

namespace Digitall.Plugins.Tests;

public class ExecutorTests
{
    // RecordingExecutor uses reference-type containers to share state between
    // the original instance and the MemberwiseClone that Execute() creates.
    // This is needed because Executor.Execute(IServiceProvider) clones itself
    // and only copies back Result for the non-exception case.
    private sealed class RecordingExecutor : Executor
    {
        // Shared between original and clone via shallow copy (reference type)
        private sealed class SharedState
        {
            public ExecutionResult ExceptionResult { get; set; }
            public IOrganizationService Secured { get; set; }
            public IOrganizationService Elevated { get; set; }
        }

        private readonly SharedState _shared = new();
        public Func<ExecutionResult> OnExecute { get; set; } = () => ExecutionResult.Ok;

        public ExecutionResult CapturedExceptionResult => _shared.ExceptionResult;
        public IOrganizationService CapturedSecured => _shared.Secured;
        public IOrganizationService CapturedElevated => _shared.Elevated;

        protected override ExecutionResult Execute()
        {
            _shared.Secured = OrganizationService();
            _shared.Elevated = OrganizationService(elevated: true);
            try
            {
                return OnExecute();
            }
            catch (InvalidPluginExecutionException ex) when (ex.Status == OperationStatus.Succeeded)
            {
                _shared.ExceptionResult = ExecutionResult.Ok;
                throw;
            }
            catch
            {
                _shared.ExceptionResult = ExecutionResult.Failure;
                throw;
            }
        }
    }

    private static IServiceProvider BuildServiceProvider(Entity target = null)
    {
        var service = new FakeOrganizationService();
        var builder = new PluginExecutionContextBuilder(service);
        if (target != null) builder.WithTarget(target);
        return builder.BuildServiceProvider();
    }

    // ── Happy path ────────────────────────────────────────────────────────────

    [Test]
    public async Task Execute_WhenSucceeds_ResultIsOk()
    {
        var executor = new RecordingExecutor();
        executor.Execute(BuildServiceProvider(new Entity("account") { Id = Guid.NewGuid() }));

        await Assert.That(executor.Result).IsEqualTo(ExecutionResult.Ok);
    }

    // ── Exception handling ────────────────────────────────────────────────────

    [Test]
    public async Task Execute_WhenInvalidPluginExceptionStatusSucceeded_Rethrows_WithOkResult()
    {
        var executor = new RecordingExecutor();
        executor.OnExecute = () => throw new InvalidPluginExecutionException(OperationStatus.Succeeded, "ok-flow");
        var sp = BuildServiceProvider(new Entity("account") { Id = Guid.NewGuid() });

        var ex = await Assert.That(() => executor.Execute(sp)).ThrowsException();
        await Assert.That(ex).IsTypeOf<InvalidPluginExecutionException>();
        await Assert.That(executor.CapturedExceptionResult).IsEqualTo(ExecutionResult.Ok);
    }

    [Test]
    public async Task Execute_WhenInvalidPluginExceptionStatusFailed_Rethrows_WithFailureResult()
    {
        var executor = new RecordingExecutor();
        executor.OnExecute = () => throw new InvalidPluginExecutionException("failure");
        var sp = BuildServiceProvider(new Entity("account") { Id = Guid.NewGuid() });

        var ex = await Assert.That(() => executor.Execute(sp)).ThrowsException();
        await Assert.That(ex).IsTypeOf<InvalidPluginExecutionException>();
        await Assert.That(executor.CapturedExceptionResult).IsEqualTo(ExecutionResult.Failure);
    }

    [Test]
    public async Task Execute_WhenArbitraryExceptionThrown_Rethrows_WithFailureResult()
    {
        var executor = new RecordingExecutor();
        executor.OnExecute = () => throw new InvalidOperationException("unexpected");
        var sp = BuildServiceProvider(new Entity("account") { Id = Guid.NewGuid() });

        var ex = await Assert.That(() => executor.Execute(sp)).ThrowsException();
        await Assert.That(ex).IsTypeOf<InvalidOperationException>();
        await Assert.That(executor.CapturedExceptionResult).IsEqualTo(ExecutionResult.Failure);
    }

    // ── Stateless (MemberwiseClone) ───────────────────────────────────────────

    [Test]
    public async Task Execute_IsStateless_OriginalServiceProviderRemainsNull()
    {
        var executor = new RecordingExecutor();
        var sp = BuildServiceProvider(new Entity("account") { Id = Guid.NewGuid() });

        await Assert.That(executor.ServiceProvider).IsNull();
        executor.Execute(sp);
        await Assert.That(executor.ServiceProvider).IsNull();
    }

    // ── Context delegation properties ─────────────────────────────────────────

    [Test]
    public async Task OrganizationService_ReturnsNonNullServices()
    {
        var executor = new RecordingExecutor();
        executor.Execute(BuildServiceProvider(new Entity("account") { Id = Guid.NewGuid() }));

        await Assert.That(executor.CapturedSecured).IsNotNull();
        await Assert.That(executor.CapturedElevated).IsNotNull();
    }
}
