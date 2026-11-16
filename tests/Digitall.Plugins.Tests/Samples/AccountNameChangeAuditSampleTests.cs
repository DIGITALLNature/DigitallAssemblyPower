// Copyright (c) DIGITALL Nature. All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.Threading.Tasks;
using Digitall.Dataverse.Testing;
using Digitall.Dataverse.Testing.Extensions;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using SamplePlugin;

namespace Digitall.Plugins.Tests.Samples;

public class AccountNameChangeAuditSampleTests
{
    [Test]
    public async Task ExecuteInternal_WhenAccountNameChanges_CreatesRelatedAuditNote()
    {
        var id = Guid.NewGuid();
        var target = new Entity("account") { Id = id, ["name"] = "New name" };
        var preImage = new Entity("account") { Id = id, ["name"] = "Previous name" };
        var contextProvider = new PluginExecutionContextBuilder(new FakeOrganizationService())
            .WithTarget(target)
            .WithPreEntityImage(preImage)
            .BuildServiceProvider();
        var service = new RecordingOrganizationService();
        var context = (IPluginExecutionContext7)contextProvider.GetService(typeof(IPluginExecutionContext7));
        var serviceProvider = new TestServiceProvider(context, service);

        new TestableSample().Invoke(serviceProvider);

        await Assert.That(service.CreatedEntity).IsNotNull();
        await Assert.That(service.CreatedEntity.LogicalName).IsEqualTo("annotation");
        await Assert.That(service.CreatedEntity["subject"]).IsEqualTo("Account name changed");
        await Assert.That(service.CreatedEntity["notetext"])
            .IsEqualTo("Account name changed from 'Previous name' to 'New name'.");
        await Assert.That(((EntityReference)service.CreatedEntity["objectid"]).Id).IsEqualTo(id);
    }

    [Test]
    public async Task ExecuteInternal_WhenPreImageIsMissing_ThrowsInvalidPluginExecutionException()
    {
        var target = new Entity("account") { Id = Guid.NewGuid(), ["name"] = "New name" };
        var contextProvider = new PluginExecutionContextBuilder(new FakeOrganizationService())
            .WithTarget(target)
            .BuildServiceProvider();
        var context = (IPluginExecutionContext7)contextProvider.GetService(typeof(IPluginExecutionContext7));
        var serviceProvider = new TestServiceProvider(
            context,
            new RecordingOrganizationService());

        var ex = await Assert.That(() => new TestableSample().Invoke(serviceProvider)).ThrowsException();

        await Assert.That(ex).IsTypeOf<InvalidPluginExecutionException>();
    }

    private sealed class TestableSample : AccountNameChangeAuditSample
    {
        public void Invoke(IServiceProvider serviceProvider) => ExecuteInternal(serviceProvider);
    }

    private sealed class TestServiceProvider(
        IPluginExecutionContext7 context,
        IOrganizationService organizationService) : IServiceProvider
    {
        private readonly IOrganizationServiceFactory _factory = new RecordingOrganizationServiceFactory(organizationService);

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(IPluginExecutionContext7)) return context;
            if (serviceType == typeof(IOrganizationServiceFactory)) return _factory;

            return null;
        }
    }

    private sealed class RecordingOrganizationServiceFactory(IOrganizationService organizationService)
        : IOrganizationServiceFactory
    {
        public IOrganizationService CreateOrganizationService(Guid? userId) => organizationService;
    }

    private sealed class RecordingOrganizationService : IOrganizationService
    {
        public Entity CreatedEntity { get; private set; }

        public Guid Create(Entity entity)
        {
            CreatedEntity = entity;
            return Guid.NewGuid();
        }

        public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet) => throw new NotSupportedException();

        public void Update(Entity entity) => throw new NotSupportedException();

        public void Delete(string entityName, Guid id) => throw new NotSupportedException();

        public OrganizationResponse Execute(OrganizationRequest request) => throw new NotSupportedException();

        public void Associate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities) =>
            throw new NotSupportedException();

        public void Disassociate(string entityName, Guid entityId, Relationship relationship, EntityReferenceCollection relatedEntities) =>
            throw new NotSupportedException();

        public EntityCollection RetrieveMultiple(QueryBase query) => throw new NotSupportedException();
    }
}
