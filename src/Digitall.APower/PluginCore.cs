// Copyright (c) DIGITALL Nature. All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Digitall.APower.Contracts;
using Digitall.APower.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.PluginTelemetry;
using Microsoft.Xrm.Sdk.Query;

namespace Digitall.APower
{
    /// <summary>
    /// </summary>
    public sealed class PluginCore
    {
        private readonly IServiceProvider _serviceProvider;

        private IOrganizationService _contextRef;

        private IOrganizationService _elevatedRef;

        public PluginCore(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider ?? throw new InvalidPluginExecutionException("serviceProvider is null");

#pragma warning disable CA1822
        public ICacheService CacheService => new CacheService();

        public ISerializerService SerializerService => new SerializerService();
#pragma warning restore CA1822

        /// <summary>
        ///     The target entity of the context.
        /// </summary>
        public Entity Entity
        {
            get
            {
                GetInputParameter("Target", out Entity value);
                return value;
            }
        }

        /// <summary>
        ///     The target entity reference of the context.
        /// </summary>
        public EntityReference EntityReference
        {
            get
            {
                GetInputParameter("Target", out EntityReference value);
                return value;
            }
        }

        /// <summary>
        ///     The relationship of the context.
        /// </summary>
        public Relationship Relationship
        {
            get
            {
                GetInputParameter("Relationship", out Relationship value);
                return value;
            }
        }

        /// <summary>
        ///     The related entities of the context.
        /// </summary>
        public EntityReferenceCollection RelatedEntities
        {
            get
            {
                GetInputParameter("RelatedEntities", out EntityReferenceCollection value);
                return value;
            }
        }

        /// <summary>
        ///     Get the execution context depth.
        /// </summary>
        public int Depth => ExecutionContext.Depth;

        /// <summary>
        ///     Get the execution context stage as string representation
        /// </summary>
        public string Stage
        {
            get
            {
                switch (PluginExecutionContext.Stage)
                {
                    case 10:
                        return "PreValidation";
                    case 20:
                        return "PreOperation";
                    case 30:
                        return "MainOperation";
                    case 40:
                        return "PostOperation";
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        ///     Get the execution context mode as string representation
        /// </summary>
        public string Mode
        {
            get
            {
                switch (PluginExecutionContext.Mode)
                {
                    case 0:
                        return "Synchronous";
                    case 1:
                        return "Asynchronous";
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        ///     The "PreImage" pre-entity image; see Plugin Registration
        /// </summary>
        public Entity PreEntityImage => PluginExecutionContext.PreEntityImages.Contains("PreImage") ? PluginExecutionContext.PreEntityImages["PreImage"] : null;

        /// <summary>
        ///     The "PostImage" post-entity image; see Plugin Registration
        /// </summary>
        public Entity PostEntityImage => PluginExecutionContext.PostEntityImages.Contains("PostImage") ? PluginExecutionContext.PostEntityImages["PostImage"] : null;

        /// <summary>
        ///     Get column set from execution context.
        /// </summary>
        public ColumnSet ColumnSet
        {
            get
            {
                GetInputParameter("ColumnSet", out ColumnSet value);
                return value;
            }
        }

        /// <summary>
        ///     Get the business entity from output parameters in execution context.
        /// </summary>
        public Entity RetrieveEntity
        {
            get
            {
                GetOutputParameter("BusinessEntity", out Entity value);
                return value;
            }
        }

        /// <summary>
        ///     Get the business entity collection from output parameters in execution context.
        /// </summary>
        public EntityCollection RetrieveMultipleEntities
        {
            get
            {
                GetOutputParameter("BusinessEntityCollection", out EntityCollection value);
                return value;
            }
        }

        /// <summary>
        ///     Context bounded OrganizationService (secured)
        /// </summary>
        public IOrganizationService SecuredOrganizationService
        {
            get => _contextRef ?? (_contextRef = OrganizationService());
            set => _contextRef = value;
        }

        /// <summary>
        ///     Context bounded OrganizationService (elevated)
        /// </summary>
        public IOrganizationService ElevatedOrganizationService
        {
            get => _elevatedRef ?? (_elevatedRef = OrganizationService(true));
            set => _elevatedRef = value;
        }

        /// <summary>
        ///     Generic getter for input parameters in execution context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dafaultValue"></param>
        /// <returns></returns>
        public bool GetInputParameter<T>(string key, out T value, T dafaultValue = default)
        {
            if (PluginExecutionContext.InputParameters.Contains(key) && PluginExecutionContext.InputParameters[key] is T)
            {
                value = (T)PluginExecutionContext.InputParameters[key];
                return true;
            }

            value = dafaultValue;
            return false;
        }

        /// <summary>
        ///     Generic getter for output parameters in execution context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dafaultValue"></param>
        /// <returns></returns>
        public bool GetOutputParameter<T>(string key, out T value, T dafaultValue = default)
        {
            if (PluginExecutionContext.OutputParameters.Contains(key) && PluginExecutionContext.OutputParameters[key] is T)
            {
                value = (T)PluginExecutionContext.OutputParameters[key];
                return true;
            }

            value = dafaultValue;
            return false;
        }

        /// <summary>
        ///     Generic setter for output parameters in execution context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetOutputParameter<T>(string key, T value) => PluginExecutionContext.OutputParameters[key] = value;

        /// <summary>
        ///     Get query from execution context.
        /// </summary>
        public bool Query(out QueryExpression query, out ColumnSet columnSet)
        {
            columnSet = ColumnSet;
            // ReSharper disable once InvertIf
            if (GetInputParameter("Query", out query))
            {
                if (ColumnSet == default(ColumnSet))
                {
                    columnSet = query.ColumnSet;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        ///     Get query from execution context.
        /// </summary>
        public bool Query(out QueryByAttribute query, out ColumnSet columnSet)
        {
            columnSet = ColumnSet;
            // ReSharper disable once InvertIf
            if (GetInputParameter("Query", out query))
            {
                if (ColumnSet == default(ColumnSet))
                {
                    columnSet = query.ColumnSet;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        ///     Get query from execution context.
        /// </summary>
        public bool Query(out FetchExpression query, out ColumnSet columnSet)
        {
            columnSet = ColumnSet;
            // ReSharper disable once InvertIf
            if (GetInputParameter("Query", out query))
            {
                if (ColumnSet == default(ColumnSet))
                {
                    columnSet = new ColumnSet(XDocument.Load(XmlReader.Create(new StringReader(query.Query)))
                        .Descendants("attribute").Select(d => d.Attribute("name")).ToList()
                        .Select(e => e.Value.ToString()).ToArray());
                }

                return true;
            }

            return false;
        }

        public void Trace(string format, params object[] arg) => TracingService.Trace(format, arg);

        #region IServiceProvider given

        public IPluginExecutionContext PluginExecutionContext => (IPluginExecutionContext)_serviceProvider.GetService(typeof(IPluginExecutionContext));

        /// <summary>
        /// </summary>
        public IExecutionContext ExecutionContext => PluginExecutionContext;

        /// <summary>
        /// </summary>
        public ITracingService TracingService => (ITracingService)_serviceProvider.GetService(typeof(ITracingService));

        /// <summary>
        /// </summary>
        public IOrganizationServiceFactory OrganizationServiceFactory => (IOrganizationServiceFactory)_serviceProvider.GetService(typeof(IOrganizationServiceFactory));

        /// <summary>
        /// </summary>
        public IServiceEndpointNotificationService NotificationService => (IServiceEndpointNotificationService)_serviceProvider.GetService(typeof(IServiceEndpointNotificationService));

        /// <summary>
        ///     Uses Application Insights configured under "Activate Data Export" in Power Platform admin center
        /// </summary>
        public ILogger PluginTelemetry => (ILogger)_serviceProvider.GetService(typeof(ILogger));

        #endregion

        #region base methods

        /// <summary>
        ///     Invokes the OrganizationServiceFactory; prefer to use the SecuredOrganizationService or ElevatedOrganizationService
        /// </summary>
        /// <param name="elevated"></param>
        /// <returns></returns>
        public IOrganizationService OrganizationService(bool elevated = false) =>
            elevated ? OrganizationServiceFactory.CreateOrganizationService(null) : OrganizationServiceFactory.CreateOrganizationService(ExecutionContext.UserId);

        /// <summary>
        ///     Invokes the OrganizationServiceFactory; prefer to use the SecuredOrganizationService
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IOrganizationService OrganizationService(Guid userId) =>
            userId == Guid.Empty ? OrganizationServiceFactory.CreateOrganizationService(null) : OrganizationServiceFactory.CreateOrganizationService(userId);

        #endregion

        #region crm executioncontext

        /// <summary>
        ///     The execution context correlation id.
        /// </summary>
        public Guid CorrelationId => ExecutionContext.CorrelationId;

        /// <summary>
        ///     The execution context initiating user id (OrganizationServiceProxy.CallerId).
        /// </summary>
        public Guid CallerId => ExecutionContext.InitiatingUserId;

        /// <summary>
        ///     The business unit that the user making the request, also known as the calling user.
        /// </summary>
        public Guid BusinessUnitId => ExecutionContext.BusinessUnitId;

        /// <summary>
        ///     String representation of the currenty executed process.
        /// </summary>
        public string ProcessName => $"CRM.{GetType().Name}.{PluginExecutionContext.MessageName}.{Mode}.{Stage}.{Depth}";

        #endregion
    }
}
