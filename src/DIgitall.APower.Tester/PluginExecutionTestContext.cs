// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using Microsoft.Xrm.Sdk;
using NSubstitute;

namespace Digitall.APower.Tester
{
    /// <summary>
    /// Represents the context for a plugin execution test.
    /// </summary>
    public sealed class PluginExecutionTestContext
    {
        private readonly IPluginExecutionContext5 _plugincontext;

        /// <summary>
        /// Gets or sets the target entity.
        /// </summary>
        public Entity Target { get; } = new Entity("unittest");

        /// <summary>
        /// Gets or sets the target entity reference.
        /// </summary>
        public EntityReference TargetReference { get; } = new EntityReference("unittest", Guid.NewGuid());

        /// <summary>
        /// Gets the input parameters collection.
        /// </summary>
        public ParameterCollection InputParameters { get; } = new ParameterCollection();

        /// <summary>
        /// Gets or sets the pre-image entity.
        /// </summary>
        public Entity PreImage { get; } = new Entity("unittest");

        /// <summary>
        /// Gets or sets the post-image entity.
        /// </summary>
        public Entity Postimage { get; } = new Entity("unittest");

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginExecutionTestContext"/> class.
        /// </summary>
        /// <param name="targetType">The target type (default is Entity).</param>
        public PluginExecutionTestContext(TargetType targetType = TargetType.Entity)
        {
            _plugincontext = Substitute.For<IPluginExecutionContext5>();

            switch (targetType)
            {
                case TargetType.Entity:
                    InputParameters.Add("Target", Target);
                    break;
                case TargetType.Reference:
                    InputParameters.Add("Target", TargetReference);
                    break;
            }

            _plugincontext.InputParameters.Returns(InputParameters);
            _plugincontext.PreEntityImages.Returns(new EntityImageCollection { { "PreImage", PreImage } });
            _plugincontext.PostEntityImages.Returns(new EntityImageCollection { { "PostImage", Postimage } });
        }

        // Current last version
        public IPluginExecutionContext5 Context => _plugincontext;

        public IPluginExecutionContext5 Context5 => _plugincontext;
        public IPluginExecutionContext4 Context4 => _plugincontext;
        public IPluginExecutionContext3 Context3 => _plugincontext;
        public IPluginExecutionContext2 Context2 => _plugincontext;
        public IPluginExecutionContext Context1 => _plugincontext;
    }
}
