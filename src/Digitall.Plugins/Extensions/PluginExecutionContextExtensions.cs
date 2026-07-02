using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Digitall.Plugins.Extensions;

public static class PluginExecutionContextExtensions
{
    private const int StagePreValidation = 10;
    private const int StagePreOperation = 20;
    private const int StageMainOperation = 30;
    private const int StagePostOperation = 40;

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

        /// <summary>
        /// Retrieves the list of target entities from the plugin execution context.
        /// </summary>
        /// <remarks>Only available when registering the plugin on CreateMultiple or UpdateMultiple.</remarks>
        /// <typeparam name="TEntity">The type of the entities to retrieve.</typeparam>
        /// <returns>A list of entities of the specified type, or an empty list if the "Targets" input parameter is not present.</returns>
        public IReadOnlyList<TEntity> GetTargets<TEntity>() where TEntity : Entity
        {
            if (context.GetInputParameter("Targets", out EntityCollection targets))
                return targets.Entities.Select(e => e.ToEntity<TEntity>()).ToList().AsReadOnly();

            return [];
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

            return [];
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
                using var xmlReader = XmlReader.Create(new StringReader(query.Query));
                columnSet ??= new ColumnSet(XDocument.Load(xmlReader)
                    .Descendants("attribute")
                    .Select(d => d.Attribute("name"))
                    .Select(e => e.Value)
                    .ToArray());

                return true;
            }

            return false;
        }

        public TEntity GetPreImage<TEntity>(string name = "PreImage") where TEntity : Entity
        {
            if (context.PreEntityImages.TryGetValue(name, out var preImage)) return preImage.ToEntity<TEntity>();

            return null;
        }

        /// <summary>
        /// Retrieves a list of pre-images from the plugin execution context for the specified image name.
        /// </summary>
        /// <remarks>Only available when registering the plugin on CreateMultiple or UpdateMultiple.</remarks>
        /// <typeparam name="TEntity">The type of the entities contained in the pre-images.</typeparam>
        /// <param name="name">The name of the pre-image collection. Defaults to "PreImage".</param>
        /// <returns>A list of entities of type <typeparamref name="TEntity"/> representing the pre-images, or an empty list if none are found.</returns>
        public IReadOnlyList<TEntity> GetPreImages<TEntity>(string name = "PreImage") where TEntity : Entity
        {
            if (context is not IPluginExecutionContext4 context4) return [];

            return context4.PreEntityImagesCollection.Where(x => x.ContainsKey(name)).Select(x => x[name].ToEntity<TEntity>()).ToList().AsReadOnly();
        }

        public TEntity GetPostImage<TEntity>(string name = "PostImage") where TEntity : Entity
        {
            if (context.PostEntityImages.TryGetValue(name, out var postImage)) return postImage.ToEntity<TEntity>();

            return null;
        }

        /// <summary>
        /// Retrieves a collection of post-images from the plugin execution context.
        /// </summary>
        /// <remarks>Only available when registering the plugin on CreateMultiple or UpdateMultiple.</remarks>
        /// <typeparam name="TEntity">The type of the entities in the post-image collection.</typeparam>
        /// <param name="name">The name of the post-image collection to retrieve. Defaults to "PostImage".</param>
        /// <returns>A list of entities of the specified type from the post-image collection, or an empty list if not found.</returns>
        public IReadOnlyList<TEntity> GetPostImages<TEntity>(string name = "PostImage") where TEntity : Entity
        {
            if (context is not IPluginExecutionContext4 context4) return [];

            return context4.PostEntityImagesCollection.Where(x => x.ContainsKey(name)).Select(x => x[name].ToEntity<TEntity>()).ToList().AsReadOnly();
        }

        public string GetFormattedExecutionStage() =>
            context.Stage switch
            {
                StagePreValidation => "PreValidation",
                StagePreOperation => "PreOperation",
                StageMainOperation => "MainOperation",
                StagePostOperation => "PostOperation",
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
