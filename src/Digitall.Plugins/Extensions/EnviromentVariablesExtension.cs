using System;
using System.Linq;
using Microsoft.Xrm.Sdk.Query;

namespace Digitall.Plugins.Extensions;

public static class EnvironmentVariablesExtension
{
    /// <summary>
    /// Extension method for the Executor class that retrieves a configuration setting from the environment variables.
    /// If the setting is not found, it returns the default value if provided, otherwise it returns null.
    /// </summary>
    /// <param name="executor">The executor instance.</param>
    /// <param name="key">The name of the configuration setting to retrieve.</param>
    /// <param name="defaultValue">The default value to return if the configuration setting is not found. Defaults to null.</param>
    /// <returns>The value of the configuration setting, or the default value if it is not found.</returns>
    public static string GetConfig(this Executor executor, string key, string defaultValue = null)
    {
        if (executor == null) throw new ArgumentNullException(nameof(executor));
        // Call the GetConfig method on the ServiceProvider property of the executor instance
        return executor.ServiceProvider.GetConfig(key, defaultValue);
    }

    /// <summary>
    /// Retrieves the value of a configuration setting from the environment variables.
    /// If the setting is not found, it returns the default value if provided, otherwise it returns null.
    /// </summary>
    /// <param name="serviceProvider">The service provider used to retrieve the organization service.</param>
    /// <param name="key">The name of the configuration setting to retrieve.</param>
    /// <param name="defaultValue">The default value to return if the configuration setting is not found. Defaults to null.</param>
    /// <returns>The value of the configuration setting, or the default value if not found.</returns>
    public static string GetConfig(this IServiceProvider serviceProvider, string key, string defaultValue = null)
    {
        if (serviceProvider == null) throw new ArgumentNullException(nameof(serviceProvider));
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
}
