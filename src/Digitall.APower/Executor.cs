// Copyright (c) DIGITALL Nature. All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.Diagnostics;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Digitall.APower
{
    public abstract class Executor : IPlugin
    {
        public readonly string SecureConfig;
        public readonly string UnsecureConfig;

        /// <summary>
        /// </summary>
        /// <param name="unsecure"></param>
        /// <param name="secure"></param>
        protected Executor(string unsecure = null, string secure = null)
        {
            UnsecureConfig = unsecure;
            SecureConfig = secure;
        }

        /// <summary>
        ///     Get current execution result
        /// </summary>
        public ExecutionResult Result { get; private set; }

        /// <summary>
        ///     IPlugin execute impl.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public void Execute(IServiceProvider serviceProvider)
        {
            //follow the "stateless" recommendation of Microsoft
            var inner = (Executor)MemberwiseClone();
            inner.ServiceProvider = serviceProvider;
            try
            {
                inner.Result = inner.Execute();
            }
            catch (InvalidPluginExecutionException i)
            {
                //if the InvalidPluginExecutionException is used as message handler,
                //e.g. show validation messages,
                //just an ability to bypass the telemetry/logging as error
                if (OperationStatus.Succeeded == i.Status)
                {
                    inner.Result = ExecutionResult.Ok;
                }
                else
                {
                    inner.Result = ExecutionResult.Failure;
                }

                throw;
            }
            catch (Exception)
            {
                inner.Result = ExecutionResult.Failure;
                throw;
            }

            //for unit testing only
            Result = inner.Result;
        }

        public IServiceProvider ServiceProvider { get; set; }

        public IPluginExecutionContext Core => ServiceProvider.GetExecutionContext();

        /// <summary>
        ///     Abstract implementation for the Plugin. The custom code goes here!
        /// </summary>
        /// <returns>ExecutionResult of the process.</returns>
        protected abstract ExecutionResult Execute();

        #region Delegation of PluginCore

        /// <summary>
        ///     Invokes the OrganizationServiceFactory; prefer to use the SecuredOrganizationService or ElevatedOrganizationService
        /// </summary>
        /// <param name="elevated"></param>
        /// <returns></returns>
        public IOrganizationService OrganizationService(bool elevated = false) => elevated ? ServiceProvider.GetElevatedOrganizationService() : ServiceProvider.GetOrganizationService();

        /// <summary>
        ///     Invokes the OrganizationServiceFactory; prefer to use the SecuredOrganizationService
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IOrganizationService OrganizationService(Guid userId) => ServiceProvider.GetOrganizationService(userId);


        /// <summary>
        ///     The execution context correlation id.
        /// </summary>
        public Guid CorrelationId => Core.CorrelationId;

        /// <summary>
        ///     The execution context initiating user id (OrganizationServiceProxy.CallerId).
        /// </summary>
        public Guid CallerId => Core.InitiatingUserId;

        /// <summary>
        ///     The business unit that the user making the request, also known as the calling user.
        /// </summary>
        public Guid BusinessUnitId => Core.BusinessUnitId;

        /// <summary>
        ///     String representation of the currenty executed process.
        /// </summary>
        public string ProcessName => $"CRM.{GetType().Name}.{Core.MessageName}.{Mode}.{Stage}.{Depth}";


        /// <summary>
        ///     The target entity of the context.
        /// </summary>
        public Entity Entity => Core.GetTarget<Entity>();

        /// <summary>
        ///     The target entity reference of the context.
        /// </summary>
        public EntityReference EntityReference => Core.GetTarget();

        /// <summary>
        ///     The relationship of the context.
        /// </summary>
        public Relationship Relationship => Core.GetRelationship();

        /// <summary>
        ///     The related entities of the context.
        /// </summary>
        public EntityReferenceCollection RelatedEntities => Core.GetRelatedEntities();

        /// <summary>
        ///     Get the execution context depth.
        /// </summary>
        public int Depth => Core.Depth;

        /// <summary>
        ///     Get the execution context stage as string representation
        /// </summary>
        public string Stage => Core.GetFormattedExecutionStage();

        /// <summary>
        ///     Get the execution context mode as string representation
        /// </summary>
        public string Mode => Core.GetFormattedExecutionMode();


        /// <summary>
        ///     Context bounded OrganizationService (secured)
        /// </summary>
        public IOrganizationService SecuredOrganizationService
        {
            get
            {
                // allows reuse of the same IOrganizationService instance when property is accessed multiple times
                field ??= ServiceProvider.GetOrganizationService();

                return field;
            }
        }

        /// <summary>
        ///     Context bounded OrganizationService (elevated)
        /// </summary>
        public IOrganizationService ElevatedOrganizationService
        {
            get
            {
                // allows reuse of the same IOrganizationService instance when property is accessed multiple times
                field ??= ServiceProvider.GetElevatedOrganizationService();

                return field;
            }
        }

        /// <summary>
        ///     Generic getter for input parameters in execution context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GetInputParameter<T>(string key, out T value) => Core.GetInputParameter(key, out value);

        /// <summary>
        ///     Generic getter for output parameters in execution context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool GetOutputParameter<T>(string key, out T value) => Core.GetOutputParameter(key, out value);

        /// <summary>
        ///     Generic setter for output parameters in execution context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetOutputParameter<T>(string key, T value) => Core.SetOutputParameter(key, value);

        /// <summary>
        ///     The "PreImage" pre-entity image; see Plugin Registration
        /// </summary>
        public Entity PreEntityImage => Core.GetPreImage<Entity>();

        /// <summary>
        ///     The "PostImage" post-entity image; see Plugin Registration
        /// </summary>
        public Entity PostEntityImage => Core.GetPostImage<Entity>();

        /// <summary>
        ///     Get column set from execution context.
        /// </summary>
        public ColumnSet ColumnSet => Core.GetColumnSet();

        /// <summary>
        ///     Get query from execution context.
        /// </summary>
        public bool Query(out QueryExpression query, out ColumnSet columnSet) => Core.GetQuery(out query, out columnSet);

        /// <summary>
        ///     Get query from execution context.
        /// </summary>
        public bool Query(out QueryByAttribute query, out ColumnSet columnSet) => Core.GetQuery(out query, out columnSet);

        /// <summary>
        ///     Get query from execution context.
        /// </summary>
        public bool Query(out FetchExpression query, out ColumnSet columnSet) => Core.GetQuery(out query, out columnSet);


        /// <summary>
        ///     Get the business entity from output parameters in execution context.
        /// </summary>
        public Entity RetrieveEntity => Core.GetRetrieveEntity();


        /// <summary>
        ///     Get the business entity collection from output parameters in execution context.
        /// </summary>
        public EntityCollection RetrieveMultipleEntities => Core.GetRetrieveMultipleEntities();

        #endregion
    }
}
