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

        public PluginCore Core { get; private set; }

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
            var timer = Stopwatch.StartNew();
            //follow the "stateless" recommendation of Microsoft
            var inner = (Executor)MemberwiseClone();
            inner.Core = new PluginCore(serviceProvider);
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
            catch (Exception e)
            {
                inner.Result = ExecutionResult.Failure;
                throw;
            }

            //for unit testing only
            Result = inner.Result;
        }

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
        public IOrganizationService OrganizationService(bool elevated = false) => Core.OrganizationService(elevated);

        /// <summary>
        ///     Invokes the OrganizationServiceFactory; prefer to use the SecuredOrganizationService
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IOrganizationService OrganizationService(Guid userId) => Core.OrganizationService(userId);


        /// <summary>
        ///     The execution context correlation id.
        /// </summary>
        public Guid CorrelationId => Core.CorrelationId;

        /// <summary>
        ///     The execution context initiating user id (OrganizationServiceProxy.CallerId).
        /// </summary>
        public Guid CallerId => Core.CallerId;

        /// <summary>
        ///     The business unit that the user making the request, also known as the calling user.
        /// </summary>
        public Guid BusinessUnitId => Core.BusinessUnitId;

        /// <summary>
        ///     String representation of the currenty executed process.
        /// </summary>
        public string ProcessName => Core.ProcessName;


        /// <summary>
        ///     The target entity of the context.
        /// </summary>
        public Entity Entity => Core.Entity;

        /// <summary>
        ///     The target entity reference of the context.
        /// </summary>
        public EntityReference EntityReference => Core.EntityReference;

        /// <summary>
        ///     The relationship of the context.
        /// </summary>
        public Relationship Relationship => Core.Relationship;

        /// <summary>
        ///     The related entities of the context.
        /// </summary>
        public EntityReferenceCollection RelatedEntities => Core.RelatedEntities;

        /// <summary>
        ///     Get the execution context depth.
        /// </summary>
        public int Depth => Core.Depth;

        /// <summary>
        ///     Get the execution context stage as string representation
        /// </summary>
        public string Stage => Core.Stage;

        /// <summary>
        ///     Get the execution context mode as string representation
        /// </summary>
        public string Mode => Core.Mode;


        /// <summary>
        ///     Context bounded OrganizationService (secured)
        /// </summary>
        public IOrganizationService SecuredOrganizationService => Core.SecuredOrganizationService;

        /// <summary>
        ///     Context bounded OrganizationService (elevated)
        /// </summary>
        public IOrganizationService ElevatedOrganizationService => Core.ElevatedOrganizationService;

        /// <summary>
        ///     Generic getter for input parameters in execution context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dafaultValue"></param>
        /// <returns></returns>
        public bool GetInputParameter<T>(string key, out T value, T dafaultValue = default) =>
            Core.GetInputParameter(key, out value, dafaultValue);

        /// <summary>
        ///     Generic getter for output parameters in execution context.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="dafaultValue"></param>
        /// <returns></returns>
        public bool GetOutputParameter<T>(string key, out T value, T dafaultValue = default) =>
            Core.GetOutputParameter(key, out value, dafaultValue);

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
        public Entity PreEntityImage => Core.PreEntityImage;

        /// <summary>
        ///     The "PostImage" post-entity image; see Plugin Registration
        /// </summary>
        public Entity PostEntityImage => Core.PostEntityImage;

        /// <summary>
        ///     Get column set from execution context.
        /// </summary>
        public ColumnSet ColumnSet => Core.ColumnSet;

        /// <summary>
        ///     Get query from execution context.
        /// </summary>
        public bool Query(out QueryExpression query, out ColumnSet columnSet) =>
            Core.Query(out query, out columnSet);

        /// <summary>
        ///     Get query from execution context.
        /// </summary>
        public bool Query(out QueryByAttribute query, out ColumnSet columnSet) =>
            Core.Query(out query, out columnSet);

        /// <summary>
        ///     Get query from execution context.
        /// </summary>
        public bool Query(out FetchExpression query, out ColumnSet columnSet) =>
            Core.Query(out query, out columnSet);


        /// <summary>
        ///     Get the business entity from output parameters in execution context.
        /// </summary>
        public Entity RetrieveEntity => Core.RetrieveEntity;


        /// <summary>
        ///     Get the business entity collection from output parameters in execution context.
        /// </summary>
        public EntityCollection RetrieveMultipleEntities => Core.RetrieveMultipleEntities;

        public void Trace(string format, params object[] arg) => Core.Trace(format, arg);

        #endregion
    }
}
