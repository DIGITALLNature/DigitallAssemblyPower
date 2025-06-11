// Copyright (c) DIGITALL Nature. All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Digitall.APower.Contracts;
using Digitall.APower.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Extensions;
using Microsoft.Xrm.Sdk.PluginTelemetry;
using Microsoft.Xrm.Sdk.Query;

namespace Digitall.APower;

/// <summary>
///     EntityAttribute extensions
/// </summary>
public static class Extensions
{
    #region extension: Executor
    extension(Executor executor)
    {
        /// <summary>
        ///     Get value T from entity. Lookup order 1st Entity, 2nd PreEntityImage, 3rd default!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public T GetEntityAttributeValue<T>(string attribute) => executor.Core.GetEntityAttributeValue<T>(attribute);

        /// <summary>
        ///     Evaluates if attribute in Entity is set and is different from PreEntityImage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public bool IsEntityAttributeValueChanged<T>(string attribute) => executor.Core.IsEntityAttributeValueChanged<T>(attribute);

        /// <summary>
        ///     Evaluates if Entity contains attribute and PreEntityImage does not
        /// </summary>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public bool IsEntityAttributeValueNew(string attribute) => executor.Core.IsEntityAttributeValueNew(attribute);

        /// <summary>
        ///     Evaluates if attribute contained in Entity or PreEntityImage and not null.
        /// </summary>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public bool IsEntityAttributeValueNullOrEmpty(string attribute) => executor.Core.IsEntityAttributeValueNullOrEmpty(attribute);

        /// <summary>
        ///     Merge Entity and PreEntityImage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T MergeEntity<T>() where T : Entity => executor.Core.MergeEntity<T>();

        /// <summary>
        /// Extension method for the Executor class that retrieves a configuration setting from the environment variables.
        /// If the setting is not found, it returns the default value if provided, otherwise it returns null.
        /// </summary>
        /// <param name="key">The name of the configuration setting to retrieve.</param>
        /// <param name="defaultValue">The default value to return if the configuration setting is not found. Defaults to null.</param>
        /// <returns>The value of the configuration setting, or the default value if it is not found.</returns>
        public string GetConfig(string key, string? defaultValue = null)
        {
            // Call the GetConfig method on the ServiceProvider property of the executor instance
            return executor.ServiceProvider.GetConfig(key, defaultValue);
        }
    }
    #endregion

    #region extension: IPluginExecutionContext
    extension(IPluginExecutionContext pluginExecutionContext)
    {
        /// <summary>
        ///     Get value T from entity. Lookup order 1st Entity, 2nd PreEntityImage, 3rd default!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public T GetEntityAttributeValue<T>(string attribute)
        {
            Debug.Assert(pluginExecutionContext != null, nameof(pluginExecutionContext) + " != null");
            var entity = pluginExecutionContext.GetTarget<Entity>();
            if (entity != null && entity.Attributes.Contains(attribute))
            {
                return (T)entity.Attributes[attribute];
            }

            var preImage = pluginExecutionContext.GetPreImage<Entity>();
            if (preImage != null && preImage.Attributes.Contains(attribute))
            {
                return (T)preImage.Attributes[attribute];
            }

            return default;
        }

        /// <summary>
        ///     Evaluates if attribute in Entity is set and is different from PreEntityImage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public bool IsEntityAttributeValueChanged<T>(string attribute)
        {
            Debug.Assert(pluginExecutionContext != null, nameof(pluginExecutionContext) + " != null");
            var entity = pluginExecutionContext.GetTarget<Entity>();
            var preImage = pluginExecutionContext.GetPreImage<Entity>();

            Debug.Assert(entity != null, nameof(entity) + " != null");
            //not in target
            if (!entity.Contains(attribute))
            {
                return false;
            }

            //no pre-image
            if (preImage == null)
            {
                return true;
            }

            if (typeof(T) != typeof(string))
            {
                //was empty, stays empty
                if (!preImage.Contains(attribute) && entity[attribute] == null)
                {
                    return false;
                }
            }
            else
            {
                //was empty, stays empty
                if (!preImage.Contains(attribute) && string.IsNullOrEmpty((string)entity[attribute]))
                {
                    return false;
                }

                //treat null == "" as true
                if (preImage.Contains(attribute) && string.IsNullOrEmpty((string)preImage[attribute]) && string.IsNullOrEmpty((string)entity[attribute]))
                {
                    return false;
                }
            }

            var typeEqualizer = EqualityComparer<T>.Default;
            return !(preImage.Contains(attribute) && typeEqualizer.Equals((T)preImage[attribute], (T)entity[attribute]));
        }

        /// <summary>
        ///     Evaluates if Entity contains attribute and PreEntityImage does not
        /// </summary>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public bool IsEntityAttributeValueNew(string attribute)
        {
            Debug.Assert(pluginExecutionContext != null, nameof(pluginExecutionContext) + " != null");
            var entity = pluginExecutionContext.GetTarget<Entity>();
            var preImage = pluginExecutionContext.GetPreImage<Entity>();

            return entity != null && entity.Contains(attribute) &&
                   (preImage == null || !preImage.Contains(attribute));
        }

        /// <summary>
        ///     Evaluates if attribute contained in Entity or PreEntityImage and not null.
        /// </summary>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public bool IsEntityAttributeValueNullOrEmpty(string attribute)
        {
            Debug.Assert(pluginExecutionContext != null, nameof(pluginExecutionContext) + " != null");
            var entity = pluginExecutionContext.GetTarget<Entity>();
            var preImage = pluginExecutionContext.GetPreImage<Entity>();

            return entity != null && (!entity.Contains(attribute) || entity[attribute] == null) &&
                   (preImage == null || !preImage.Contains(attribute) || preImage[attribute] == null);
        }

        /// <summary>
        ///     Merge Entity and PreEntityImage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T MergeEntity<T>() where T : Entity
        {
            Debug.Assert(pluginExecutionContext != null, nameof(pluginExecutionContext) + " != null");
            var entity = pluginExecutionContext.GetTarget<Entity>();
            var preImage = pluginExecutionContext.GetPreImage<Entity>();

            if (preImage == null)
            {
                return entity.ToEntity<T>();
            }

            var mergedEntity = new Entity
            {
                Id = preImage.Id,
                LogicalName = preImage.LogicalName
            };

            // return all AttributeLogicalNameAttribute from the given type
            var attributes = from property in typeof(T).GetProperties()
                from attribute in
                    property.GetCustomAttributes(typeof(AttributeLogicalNameAttribute), false).OfType<AttributeLogicalNameAttribute>()
                select attribute;

            foreach (var attribute in attributes)
            {
                if (entity.Contains(attribute.LogicalName))
                {
                    mergedEntity[attribute.LogicalName] = entity[attribute.LogicalName];
                    if (entity.FormattedValues.ContainsKey(attribute.LogicalName))
                    {
                        mergedEntity.FormattedValues.Add(attribute.LogicalName, entity.FormattedValues[attribute.LogicalName]);
                    }
                }
                else if (preImage.Contains(attribute.LogicalName))
                {
                    mergedEntity[attribute.LogicalName] = preImage[attribute.LogicalName];
                    if (preImage.FormattedValues.ContainsKey(attribute.LogicalName))
                    {
                        mergedEntity.FormattedValues.Add(attribute.LogicalName, preImage.FormattedValues[attribute.LogicalName]);
                    }
                }
            }

            return mergedEntity.ToEntity<T>();
        }
    }
    #endregion

    #region extension: IServiceProvider
    extension(IServiceProvider serviceProvider)
    {
          /// <summary>
        /// Retrieves the value of a configuration setting from the environment variables.
        /// If the setting is not found, it returns the default value if provided, otherwise it returns null.
        /// </summary>
        /// <param name="key">The name of the configuration setting to retrieve.</param>
        /// <param name="defaultValue">The default value to return if the configuration setting is not found. Defaults to null.</param>
        /// <returns>The value of the configuration setting, or the default value if not found.</returns>
        public string GetConfig(string key, string? defaultValue = null)
        {
            // Initialize the config value to the default value, or null if not provided
            var configValue = defaultValue;

            // Create a QueryExpression to retrieve the EnvironmentVariableDefinition entity
            var definitionQuery = new QueryExpression("environmentvariabledefinition")
            {
                NoLock = true
            };
            definitionQuery.ColumnSet.AddColumns("environmentvariabledefinitionid", "schemaname", "defaultvalue");
            definitionQuery.Criteria.AddCondition("schemaname", ConditionOperator.Equal, key);

            // Retrieve the EnvironmentVariableDefinition entity using the organization service
            var environmentVariableDefinition = serviceProvider.GetElevatedOrganizationService().RetrieveMultiple(definitionQuery).Entities.SingleOrDefault();

            // If the EnvironmentVariableDefinition entity is found
            if (environmentVariableDefinition != null)
            {
                // Create a QueryExpression to retrieve the EnvironmentVariableValue entity
                var variableQuery = new QueryExpression("environmentvariablevalue");
                variableQuery.NoLock = true;
                variableQuery.ColumnSet.AddColumn("value");
                variableQuery.Criteria.AddCondition("environmentvariabledefinitionid", ConditionOperator.Equal, environmentVariableDefinition.Id);

                // Retrieve the EnvironmentVariableValue entity using the organization service
                var environmentVariableValue = serviceProvider.GetElevatedOrganizationService().RetrieveMultiple(variableQuery).Entities.SingleOrDefault();

                // If the EnvironmentVariableValue entity is found
                if (environmentVariableValue != null)
                {
                    // Set the config value to the value of the EnvironmentVariableValue entity
                    configValue = environmentVariableValue.GetAttributeValue<string>("value");
                }
                else if (environmentVariableDefinition.Attributes.Contains("defaultvalue"))
                {
                    // If the EnvironmentVariableValue entity is not found, but the EnvironmentVariableDefinition entity has a default value, set the config value to the default value
                    configValue = environmentVariableDefinition.GetAttributeValue<string>("defaultvalue");
                }
            }

            // Return the config value
            return configValue;
        }

            /// <summary>
        ///     Returns the <see cref="IPluginExecutionContext7" /> from the service provider.
        /// </summary>
        /// <returns>The <see cref="IPluginExecutionContext7" />.</returns>
        public IPluginExecutionContext7 GetExecutionContext() =>
            serviceProvider.Get<IPluginExecutionContext7>();

        /// <summary>
        /// Retrieves the <see cref="IOrganizationService"/> for the current execution context's user.
        /// </summary>
        /// <returns>The <see cref="IOrganizationService"/> for the user specified in the execution context.</returns>
        public IOrganizationService GetOrganizationService()
        {
            var executionContext = serviceProvider.GetExecutionContext();
            return serviceProvider.GetOrganizationService(executionContext.UserId);
        }

        /// <summary>
        /// Retrieves the <see cref="IOrganizationService"/> for the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The user id of the user for which to retrieve the organization service.</param>
        /// <returns>The <see cref="IOrganizationService"/> for the user with the specified <paramref name="userId"/>.</returns>
        public IOrganizationService GetOrganizationService(Guid userId)
        {
            var factory = serviceProvider.Get<IOrganizationServiceFactory>();
            return factory.CreateOrganizationService(userId);
        }

        /// <summary>
        /// Retrieves the <see cref="IOrganizationService"/> with the "System" user id (i.e. elevated privileges).
        /// </summary>
        /// <returns>The <see cref="IOrganizationService"/> with elevated privileges.</returns>
        public IOrganizationService GetElevatedOrganizationService()
        {
            var factory = serviceProvider.Get<IOrganizationServiceFactory>();
            return factory.CreateOrganizationService(null);
        }

        /// <summary>
        ///     Retrieves the <see cref="ITracingService"/> from the service provider.
        /// </summary>
        /// <returns>The <see cref="ITracingService"/>.</returns>
        public ITracingService GetTracingService() =>
            serviceProvider.Get<ITracingService>();

        /// <summary>
        /// Retrieves the <see cref="ILogger"/> from the service provider.
        /// </summary>
        /// <returns>The <see cref="ILogger"/>.</returns>
        public ILogger GetLogger() => serviceProvider.Get<ILogger>();

        /// <summary>
        /// Retrieves an instance of the <see cref="ISerializerService"/> from the service provider.
        /// </summary>
        /// <returns>An instance of the <see cref="ISerializerService"/>.</returns>
        public ISerializerService GetSerializerService() => new SerializerService();

        /// <summary>
        /// Retrieves the <see cref="ILoggingFacade" /> from the service provider.
        /// </summary>
        /// <returns>An instance of <see cref="ILoggingFacade" />.</returns>
        public ILoggingFacade GetLoggingFacade()
        {
            var tracingService = serviceProvider.GetTracingService();
            var logger = serviceProvider.GetLogger();
            return new LoggingFacade(tracingService, logger);
        }

        /// <summary>
        /// Registers the proxy types assembly for the <see cref="IOrganizationServiceFactory"/>.
        /// </summary>
        /// <remarks>
        /// This is a workaround for a known issue in Dynamics 365 where the <see cref="IOrganizationServiceFactory"/> doesn't
        /// automatically load the proxy types assembly when the service provider is created.
        ///
        /// The Behavior is undocumented and usage is without any warrenty!
        /// </remarks>
        /// <param name="assembly">The assembly containing the proxy types.</param>
        /// <returns>The service provider.</returns>
        public IServiceProvider RegisterProxyTypesAssembly(Assembly assembly)
        {
            var factory = serviceProvider.Get<IOrganizationServiceFactory>();
            var property = factory.GetType().GetProperty("ProxyTypesAssembly", BindingFlags.Instance | BindingFlags.NonPublic);
            property.SetValue(factory, assembly, null);

            return serviceProvider;
        }
    }
    #endregion

    #region extension: IPluginExecutionContext

    extension(IPluginExecutionContext context)
    {
        /// <summary>
        /// Attempts to retrieve a value of type T from the InputParameters collection of the plugin execution context using the specified parameter name.
        /// </summary>
        /// <typeparam name="T">The type of the expected parameter value.</typeparam>
        /// <param name="name">The name of the parameter to retrieve.</param>
        /// <param name="value">The output variable to store the retrieved value if found.</param>
        /// <returns>True if the parameter exists and its value was successfully retrieved; otherwise, false.</returns>
        public bool GetInputParameter<T>(string name, out T value) =>
            context.InputParameters.TryGetValue(name, out value);

        /// <summary>
        /// Attempts to retrieve a value of type T from the OutputParameters collection of the plugin execution context using the specified parameter name.
        /// </summary>
        /// <typeparam name="T">The type of the expected parameter value.</typeparam>
        /// <param name="name">The name of the parameter to retrieve.</param>
        /// <param name="value">The output variable to store the retrieved value if found.</param>
        /// <returns>True if the parameter exists and its value was successfully retrieved; otherwise, false.</returns>
        public bool GetOutputParameter<T>(string name, out T value) =>
            context.OutputParameters.TryGetValue(name, out value);

        /// <summary>
        /// Sets the specified value of type T in the OutputParameters collection of the plugin execution context using the given parameter name.
        /// </summary>
        /// <typeparam name="T">The type of the parameter value to set.</typeparam>
        /// <param name="name">The name of the parameter to set.</param>
        /// <param name="value">The value to assign to the specified parameter.</param>
        public  void SetOutputParameter<T>(string name, T value) =>
            context.OutputParameters[name] = value;

        /// <summary>
        /// Retrieves the target entity of type TEntity from the plugin execution context's InputParameters, if available.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity to retrieve, constrained to Entity or its derived types.</typeparam>
        /// <returns>A nullable instance of TEntity if the target entity is present; otherwise, null.</returns>
        public TEntity? GetTarget<TEntity>() where TEntity : Entity
        {
            if (context.GetInputParameter("Target", out Entity target)) return target.ToEntity<TEntity>();

            return null;
        }

        /// <summary>
        /// Retrieves the "Target" parameter from the plugin execution context if it exists, converting it into an EntityReference.
        /// </summary>
        /// <returns>An EntityReference representing the "Target" parameter if found; otherwise, null.</returns>
        public EntityReference? GetTarget()
        {
            if (context.GetInputParameter("Target", out EntityReference target)) return target;

            return null;
        }

        /// <summary>
        /// Retrieves the "Relationship" input parameter from the plugin execution context, if available.
        /// </summary>
        /// <returns>The "Relationship" object if it exists; otherwise, null.</returns>
        public Relationship? GetRelationship()
        {
            if (context.GetInputParameter("Relationship", out Relationship relationship)) return relationship;

            return null;
        }

        /// <summary>
        /// Retrieves the related entities from the InputParameters of the plugin execution context.
        /// </summary>
        /// <returns>An EntityReferenceCollection containing the related entities if found; otherwise, null.</returns>
        public EntityReferenceCollection? GetRelatedEntities()
        {
            if (context.GetInputParameter("RelatedEntities", out EntityReferenceCollection collection)) return collection;

            return null;
        }

        /// <summary>
        /// Retrieves the ColumnSet from the InputParameters of the plugin execution context.
        /// </summary>
        /// <returns>The ColumnSet if it exists in the context; otherwise, null.</returns>
        public ColumnSet? GetColumnSet()
        {
            if (context.GetInputParameter("ColumnSet", out ColumnSet columnSet)) return columnSet;

            return null;
        }

        /// <summary>
        /// Retrieves the entity from the InputParameters collection of the plugin execution context
        /// using the "BusinessEntity" key.
        /// </summary>
        /// <returns>The retrieved entity if it exists in the InputParameters; otherwise, null.</returns>
        public Entity? GetRetrieveEntity()
        {
            if (context.GetInputParameter("BusinessEntity", out Entity entity)) return entity;

            return null;
        }

        /// <summary>
        /// Retrieves the EntityCollection from the InputParameters collection of the plugin execution context if available.
        /// </summary>
        /// <returns>Returns the EntityCollection if it exists in the InputParameters collection; otherwise, returns null.</returns>
        public EntityCollection? GetRetrieveMultipleEntities()
        {
            if (context.GetInputParameter("BusinessEntityCollection", out EntityCollection collection)) return collection;

            return null;
        }

        /// <summary>
        /// Retrieves a QueryExpression from the InputParameters of the plugin context along with the associated ColumnSet.
        /// </summary>
        /// <param name="query">The output variable to store the retrieved QueryExpression if found.</param>
        /// <param name="columnSet">The output variable to store the associated ColumnSet if determined.</param>
        /// <returns>True if a QueryExpression is found in the InputParameters and retrieved successfully; otherwise, false.</returns>
        public bool GetQuery(out QueryExpression query, out ColumnSet? columnSet)
        {
            columnSet = context.GetColumnSet();
            // ReSharper disable once InvertIf
            if (context.GetInputParameter("Query", out query))
            {
                columnSet ??= query.ColumnSet;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves a QueryByAttribute query and optional ColumnSet from the plugin execution context's InputParameters collection.
        /// </summary>
        /// <param name="query">The output variable to store the retrieved QueryByAttribute query if found.</param>
        /// <param name="columnSet">The output variable to store the retrieved ColumnSet, if available.</param>
        /// <returns>True if the QueryByAttribute query is successfully retrieved from the InputParameters; otherwise, false.</returns>
        public bool GetQuery(out QueryByAttribute query, out ColumnSet? columnSet)
        {
            columnSet = context.GetColumnSet();
            // ReSharper disable once InvertIf
            if (context.GetInputParameter("Query", out query))
            {
                columnSet ??= query.ColumnSet;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves a FetchExpression query along with its associated ColumnSet from the plugin execution context.
        /// </summary>
        /// <param name="query">The output variable to store the extracted FetchExpression query if available.</param>
        /// <param name="columnSet">The output variable to store the associated ColumnSet, inferred from the FetchExpression query if not explicitly provided.</param>
        /// <returns>True if the query was successfully retrieved; otherwise, false.</returns>
        public bool GetQuery(out FetchExpression query, out ColumnSet? columnSet)
        {
            columnSet = context.GetColumnSet();
            // ReSharper disable once InvertIf
            if (context.GetInputParameter("Query", out query))
            {
                columnSet ??= new ColumnSet(XDocument.Load(XmlReader.Create(new StringReader(query.Query)))
                    .Descendants("attribute").Select(d => d.Attribute("name")).ToList()
                    .Select(e => e.Value.ToString()).ToArray());

                return true;
            }

            return false;
        }

        /// <summary>
        /// Retrieves a pre-image of the specified type from the PreEntityImages collection in the plugin execution context using the provided name.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity to retrieve from the pre-image.</typeparam>
        /// <param name="name">The name of the pre-image to retrieve. Defaults to "PreImage" if no name is specified.</param>
        /// <returns>An instance of TEntity if the pre-image exists and can be cast to the specified type; otherwise, null.</returns>
        public TEntity? GetPreImage<TEntity>(string name = "PreImage") where TEntity : Entity
        {
            if (context.PreEntityImages.TryGetValue(name, out var preImage)) return preImage.ToEntity<TEntity>();

            return null;
        }

        /// <summary>
        /// Retrieves a post-operation image of type TEntity with the specified name from the PostEntityImages collection in the plugin execution context.
        /// </summary>
        /// <typeparam name="TEntity">The type of the expected post-operation entity image.</typeparam>
        /// <param name="name">The name of the post-operation image to retrieve. Defaults to "PostImage".</param>
        /// <returns>The post-operation image of type TEntity if it exists; otherwise, null.</returns>
        public TEntity? GetPostImage<TEntity>(string name = "PostImage") where TEntity : Entity
        {
            if (context.PostEntityImages.TryGetValue(name, out var postImage)) return postImage.ToEntity<TEntity>();

            return null;
        }

        /// <summary>
        /// Retrieves the formatted string representation of the execution stage of the plugin context.
        /// </summary>
        /// <returns>A string representing the execution stage (e.g., "PreValidation", "PreOperation", "MainOperation", or "PostOperation"), or null if the stage is unrecognized.</returns>
        public string? GetFormattedExecutionStage()
        {
            switch (context.Stage)
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

        /// <summary>
        /// Retrieves the execution mode of the plugin as a formatted string.
        /// </summary>
        /// <returns>
        /// A string representing the execution mode of the plugin. Returns "Synchronous" for synchronous execution,
        /// "Asynchronous" for asynchronous execution, or null if the mode is not recognized.
        /// </returns>
        public string? GetFormattedExecutionMode()
        {
            switch (context.Mode)
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

    #endregion
}
