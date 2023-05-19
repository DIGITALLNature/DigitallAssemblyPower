using System.Linq;
using Microsoft.Xrm.Sdk.Query;

namespace Digitall.APower.EnvironmentVariables
{
    public static class EnvironmentVariablesExtension
    {
        public static string GetConfig(this Executor executor, string key, string defaultValue = null) => executor.Core.GetConfig(key, defaultValue);

        public static string GetConfig(this PluginCore pluginCore, string key, string defaultValue = null)
        {
            var cacheKey = $"EnvironmentVariables-{key.ToLowerInvariant()}";

            if (pluginCore.CacheService.TryGet(cacheKey, out var value))
            {
                return (string)value;
            }

            var configValue = defaultValue;


            // Instantiate QueryExpression query
            var definitionQuery = new QueryExpression("environmentvariabledefinition")
            {
                NoLock = true
            };
            definitionQuery.ColumnSet.AddColumns("environmentvariabledefinitionid", "schemaname", "defaultvalue");
            definitionQuery.Criteria.AddCondition("schemaname", ConditionOperator.Equal, key);


            var environmentVariableDefinition = pluginCore.ElevatedOrganizationService.RetrieveMultiple(definitionQuery).Entities.SingleOrDefault();

            if (environmentVariableDefinition != null)
            {
                // Instantiate QueryExpression query
                var variableQuery = new QueryExpression("environmentvariablevalue");
                variableQuery.NoLock = true;
                variableQuery.ColumnSet.AddColumn("value");
                variableQuery.Criteria.AddCondition("environmentvariabledefinitionid", ConditionOperator.Equal, environmentVariableDefinition.Id);

                var environmentVariableValue = pluginCore.ElevatedOrganizationService.RetrieveMultiple(variableQuery).Entities.SingleOrDefault();
                if (environmentVariableValue != null)
                {
                    configValue = environmentVariableValue.GetAttributeValue<string>("value");
                }
                else if (environmentVariableDefinition.Attributes.Contains("defaultvalue"))
                {
                    configValue = environmentVariableDefinition.GetAttributeValue<string>("defaultvalue");
                }
            }


            pluginCore.CacheService.SetSliding(cacheKey, configValue ?? string.Empty, 121);
            return configValue;
        }
    }
}
