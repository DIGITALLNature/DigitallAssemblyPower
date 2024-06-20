using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Digitall.APower
{
    public static class PluginExecutionContextExtensions
    {
        public static bool GetInputParameter<T>(this IPluginExecutionContext context, string name, out T value) =>
            context.InputParameters.TryGetValue(name, out value);

        public static bool GetOutputParameter<T>(this IPluginExecutionContext context, string name, out T value) =>
            context.OutputParameters.TryGetValue(name, out value);

        public static void SetOutputParameter<T>(this IPluginExecutionContext context, string name, T value) =>
            context.OutputParameters[name] = value;

        public static TEntity GetTarget<TEntity>(this IPluginExecutionContext context) where TEntity : Entity
        {
            if (context.GetInputParameter("Target", out Entity target)) return target.ToEntity<TEntity>();

            return null;
        }

        public static EntityReference GetTarget(this IPluginExecutionContext context)
        {
            if (context.GetInputParameter("Target", out EntityReference target)) return target;

            return null;
        }

        public static Relationship GetRelationship(this IPluginExecutionContext context)
        {
            if (context.GetInputParameter("Relationship", out Relationship relationship)) return relationship;

            return null;
        }

        public static EntityReferenceCollection GetRelatedEntities(this IPluginExecutionContext context)
        {
            if (context.GetInputParameter("RelatedEntities", out EntityReferenceCollection collection)) return collection;

            return null;
        }

        public static ColumnSet GetColumnSet(this IPluginExecutionContext context)
        {
            if (context.GetInputParameter("ColumnSet", out ColumnSet columnSet)) return columnSet;

            return null;
        }

        public static Entity GetRetrieveEntity(this IPluginExecutionContext context)
        {
            if (context.GetInputParameter("BusinessEntity", out Entity entity)) return entity;

            return null;
        }

        public static EntityCollection GetRetrieveMultipleEntities(this IPluginExecutionContext context)
        {
            if (context.GetInputParameter("BusinessEntityCollection", out EntityCollection collection)) return collection;

            return null;
        }

        public static bool GetQuery(this IPluginExecutionContext context, out QueryExpression query, out ColumnSet columnSet)
        {
            columnSet = context.GetColumnSet();
            // ReSharper disable once InvertIf
            if (context.GetInputParameter("Query", out query))
            {
                if (columnSet == default(ColumnSet))
                {
                    columnSet = query.ColumnSet;
                }

                return true;
            }

            return false;
        }

        public static bool GetQuery(this IPluginExecutionContext context, out QueryByAttribute query, out ColumnSet columnSet)
        {
            columnSet = context.GetColumnSet();
            // ReSharper disable once InvertIf
            if (context.GetInputParameter("Query", out query))
            {
                if (columnSet == default(ColumnSet))
                {
                    columnSet = query.ColumnSet;
                }

                return true;
            }

            return false;
        }

        public static bool GetQuery(this IPluginExecutionContext context, out FetchExpression query, out ColumnSet columnSet)
        {
            columnSet = context.GetColumnSet();
            // ReSharper disable once InvertIf
            if (context.GetInputParameter("Query", out query))
            {
                if (columnSet == default(ColumnSet))
                {
                    columnSet = new ColumnSet(XDocument.Load(XmlReader.Create(new StringReader(query.Query)))
                        .Descendants("attribute").Select(d => d.Attribute("name")).ToList()
                        .Select(e => e.Value.ToString()).ToArray());
                }

                return true;
            }

            return false;
        }

        public static TEntity GetPreImage<TEntity>(this IPluginExecutionContext context, string name = "PreImage")
            where TEntity : Entity
        {
            if (context.PreEntityImages.TryGetValue(name, out var preImage)) return preImage.ToEntity<TEntity>();

            return null;
        }

        public static TEntity GetPostImage<TEntity>(this IPluginExecutionContext context, string name = "PostImage")
            where TEntity : Entity
        {
            if (context.PostEntityImages.TryGetValue(name, out var postImage)) return postImage.ToEntity<TEntity>();

            return null;
        }

        public static string GetFormattedExecutionStage(this IPluginExecutionContext context)
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

        public static string GetFormattedExecutionMode(this IPluginExecutionContext context)
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
}
