using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Digitall.Plugins.Extensions;

public static class PluginExecutionContextExtensions
{
    extension(IPluginExecutionContext context)
    {
        public bool GetInputParameter<T>(string name, out T value) => context.InputParameters.TryGetValue(name, out value);

        public bool GetOutputParameter<T>(string name, out T value) => context.OutputParameters.TryGetValue(name, out value);

        public void SetOutputParameter<T>(string name, T value) => context.OutputParameters[name] = value;

        public TEntity GetTarget<TEntity>() where TEntity : Entity
        {
            if (context.GetInputParameter("Target", out Entity target)) return target.ToEntity<TEntity>();

            return null;
        }

        public EntityReference GetTarget()
        {
            if (context.GetInputParameter("Target", out EntityReference target)) return target;

            return null;
        }

        public Relationship GetRelationship()
        {
            if (context.GetInputParameter("Relationship", out Relationship relationship)) return relationship;

            return null;
        }

        public EntityReferenceCollection GetRelatedEntities()
        {
            if (context.GetInputParameter("RelatedEntities", out EntityReferenceCollection collection)) return collection;

            return null;
        }

        public ColumnSet GetColumnSet()
        {
            if (context.GetInputParameter("ColumnSet", out ColumnSet columnSet)) return columnSet;

            return null;
        }

        public Entity GetRetrieveEntity()
        {
            if (context.GetInputParameter("BusinessEntity", out Entity entity)) return entity;

            return null;
        }

        public EntityCollection GetRetrieveMultipleEntities()
        {
            if (context.GetInputParameter("BusinessEntityCollection", out EntityCollection collection)) return collection;

            return null;
        }

        public bool GetQuery(out QueryExpression query, out ColumnSet columnSet)
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

        public bool GetQuery(out QueryByAttribute query, out ColumnSet columnSet)
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

        public bool GetQuery(out FetchExpression query, out ColumnSet columnSet)
        {
            columnSet = context.GetColumnSet();
            // ReSharper disable once InvertIf
            if (context.GetInputParameter("Query", out query))
            {
                columnSet ??= new ColumnSet(XDocument.Load(XmlReader.Create(new StringReader(query.Query))).Descendants("attribute").Select(d => d.Attribute("name")).ToList()
                    .Select(e => e.Value.ToString()).ToArray());

                return true;
            }

            return false;
        }

        public TEntity GetPreImage<TEntity>(string name = "PreImage") where TEntity : Entity
        {
            if (context.PreEntityImages.TryGetValue(name, out var preImage)) return preImage.ToEntity<TEntity>();

            return null;
        }

        public TEntity GetPostImage<TEntity>(string name = "PostImage") where TEntity : Entity
        {
            if (context.PostEntityImages.TryGetValue(name, out var postImage)) return postImage.ToEntity<TEntity>();

            return null;
        }

        public string GetFormattedExecutionStage() =>
            context.Stage switch
            {
                10 => "PreValidation",
                20 => "PreOperation",
                30 => "MainOperation",
                40 => "PostOperation",
                _ => null
            };

        public string GetFormattedExecutionMode() =>
            context.Mode switch
            {
                0 => "Synchronous",
                1 => "Asynchronous",
                _ => null
            };
    }
}
