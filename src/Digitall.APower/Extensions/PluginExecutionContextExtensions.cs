using System.Collections.Generic;
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
        extension(IPluginExecutionContext context)
        {
            /// <summary>
            /// Retrieves an input parameter from the plugin execution context.
            /// </summary>
            /// <typeparam name="T">The type of the input parameter.</typeparam>
            /// <param name="name">The name of the input parameter.</param>
            /// <param name="value">The value of the input parameter.</param>
            /// <returns>True if the parameter exists and is successfully retrieved; otherwise, false.</returns>
            public bool GetInputParameter<T>(string name, out T value) => context.InputParameters.TryGetValue(name, out value);

            /// <summary>
            /// Retrieves an output parameter from the plugin execution context.
            /// </summary>
            /// <typeparam name="T">The type of the output parameter.</typeparam>
            /// <param name="name">The name of the output parameter.</param>
            /// <param name="value">The value of the output parameter.</param>
            /// <returns>True if the parameter exists and is successfully retrieved; otherwise, false.</returns>
            public bool GetOutputParameter<T>(string name, out T value) => context.OutputParameters.TryGetValue(name, out value);

            /// <summary>
            /// Sets the output parameter in the plugin execution context.
            /// </summary>
            /// <param name="name">The name of the output parameter.</param>
            /// <param name="value">The value of the output parameter.</param>
            /// <typeparam name="T">The type of the output parameter.</typeparam>
            public void SetOutputParameter<T>(string name, T value) => context.OutputParameters[name] = value;

            /// <summary>
            /// Retrieves the target entity from the plugin execution context and converts it to the specified entity type.
            /// </summary>
            /// <typeparam name="TEntity">The type of the target entity.</typeparam>
            /// <returns>The target entity cast to the specified type or null if the target entity is not present or cannot be cast.</returns>
            public TEntity GetTarget<TEntity>() where TEntity : Entity
            {
                if (context.GetInputParameter("Target", out Entity target)) return target.ToEntity<TEntity>();

                return null;
            }

            /// <summary>
            /// Retrieves the target entity reference from the plugin execution context.
            /// </summary>
            /// <returns>The target entity reference if it exists; otherwise, null.</returns>
            public EntityReference GetTarget()
            {
                if (context.GetInputParameter("Target", out EntityReference target)) return target;

                return null;
            }

            /// <summary>
            /// Retrieves a list of target entities from the plugin execution context.
            /// </summary>
            /// <typeparam name="TEntity">The type of the target entities.</typeparam>
            /// <returns>A list of target entities if available; otherwise, null.</returns>
            public List<TEntity> GetTargets<TEntity>() where TEntity : Entity
            {
                if (context.GetInputParameter("Targets", out EntityCollection targets)) return targets.Entities.Select(e => e.ToEntity<TEntity>()).ToList();

                return null;
            }

            /// <summary>
            /// Retrieves the relationship data from the plugin execution context.
            /// </summary>
            /// <returns>The Relationship object if it exists in the input parameters; otherwise, null.</returns>
            public Relationship GetRelationship()
            {
                if (context.GetInputParameter("Relationship", out Relationship relationship)) return relationship;

                return null;
            }

            /// <summary>
            /// Retrieves a collection of related entities from the plugin execution context.
            /// </summary>
            /// <returns>An <see cref="EntityReferenceCollection"/> representing the related entities if available; otherwise, null.</returns>
            public EntityReferenceCollection GetRelatedEntities()
            {
                if (context.GetInputParameter("RelatedEntities", out EntityReferenceCollection collection)) return collection;

                return null;
            }

            /// <summary>
            /// Retrieves the column set from the plugin execution context's input parameters.
            /// </summary>
            /// <returns>The retrieved column set if it exists in the input parameters; otherwise, null.</returns>
            public ColumnSet GetColumnSet()
            {
                if (context.GetInputParameter("ColumnSet", out ColumnSet columnSet)) return columnSet;

                return null;
            }

            /// <summary>
            /// Retrieves the entity object from the plugin execution context associated with the "BusinessEntity" input parameter.
            /// </summary>
            /// <returns>The entity object if it exists in the input parameters; otherwise, null.</returns>
            public Entity GetRetrieveEntity()
            {
                if (context.GetInputParameter("BusinessEntity", out Entity entity)) return entity;

                return null;
            }

            /// <summary>
            /// Retrieves the collection of entities resulting from a RetrieveMultiple operation in the plugin execution context.
            /// </summary>
            /// <returns>The collection of retrieved entities if available; otherwise, null.</returns>
            public EntityCollection GetRetrieveMultipleEntities()
            {
                if (context.GetInputParameter("BusinessEntityCollection", out EntityCollection collection)) return collection;

                return null;
            }

            /// <summary>
            /// Retrieves a QueryExpression along with its associated ColumnSet from the plugin execution context's input parameters.
            /// </summary>
            /// <param name="query">The retrieved QueryExpression object if it exists in the input parameters.</param>
            /// <param name="columnSet">
            /// The ColumnSet associated with the query. If the ColumnSet is not provided separately,
            /// it will default to the ColumnSet from the QueryExpression.
            /// </param>
            /// <returns>True if the QueryExpression is successfully retrieved; otherwise, false.</returns>
            public bool GetQuery(out QueryExpression query, out ColumnSet columnSet)
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

            /// <summary>
            /// Retrieves a QueryByAttribute instance and an optional ColumnSet from the plugin execution context's input parameters.
            /// </summary>
            /// <param name="query">The retrieved QueryByAttribute instance if it exists in the input parameters.</param>
            /// <param name="columnSet">The ColumnSet associated with the query, either retrieved from the input parameters or from the query itself.</param>
            /// <returns>True if the query exists and is successfully retrieved; otherwise, false.</returns>
            public bool GetQuery(out QueryByAttribute query, out ColumnSet columnSet)
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

            /// <summary>
            /// Retrieves a FetchExpression query and its associated column set from the plugin execution context's input parameters.
            /// </summary>
            /// <param name="query">The FetchExpression query retrieved from the input parameters.</param>
            /// <param name="columnSet">The associated column set retrieved or inferred from the query.</param>
            /// <returns>True if the query and column set are successfully retrieved; otherwise, false.</returns>
            public bool GetQuery(out FetchExpression query, out ColumnSet columnSet)
            {
                columnSet = context.GetColumnSet();
                // ReSharper disable once InvertIf
                if (context.GetInputParameter("Query", out query))
                {
                    if (columnSet == default(ColumnSet))
                    {
                        columnSet = new ColumnSet(XDocument.Load(XmlReader.Create(new StringReader(query.Query))).Descendants("attribute").Select(d => d.Attribute("name")).ToList()
                            .Select(e => e.Value.ToString()).ToArray());
                    }

                    return true;
                }

                return false;
            }

            /// <summary>
            /// Retrieves a pre-image entity from the plugin execution context by name.
            /// </summary>
            /// <typeparam name="TEntity">The type of the entity to cast the pre-image to.</typeparam>
            /// <param name="name">The name of the pre-image in the context's PreEntityImages collection. Defaults to "PreImage" if not specified.</param>
            /// <returns>The pre-image entity cast to the specified type or null if the pre-image does not exist.</returns>
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
            /// <returns>A list of entities of type <typeparamref name="TEntity"/> representing the pre-images associated with the specified name. Returns an empty list if no pre-images are found.</returns>
            public List<TEntity> GetPreImages<TEntity>(string name = "PreImage") where TEntity : Entity
            {
                // these entity images are only available when you use the IPluginExecutionContext4 interface
                if (context is not IPluginExecutionContext4 context4) return [];

                return context4.PreEntityImagesCollection.Where(x => x.ContainsKey(name)).Select(x => x[name].ToEntity<TEntity>()).ToList();
            }

            /// <summary>
            /// Retrieves the specified post-image entity from the plugin execution context.
            /// </summary>
            /// <typeparam name="TEntity">The type of the post-image entity to retrieve.</typeparam>
            /// <param name="name">The name of the post-image entity. Defaults to "PostImage".</param>
            /// <returns>The post-image entity of the specified type if available; otherwise, null.</returns>
            public TEntity GetPostImage<TEntity>(string name = "PostImage") where TEntity : Entity
            {
                // these entity images are only available when you use the IPluginExecutionContext4 interface
                if (context.PostEntityImages.TryGetValue(name, out var postImage)) return postImage.ToEntity<TEntity>();

                return null;
            }

            /// <summary>
            /// Retrieves a collection of post-images from the plugin execution context.
            /// </summary>
            /// <remarks>Only available when registering the plugin on CreateMultiple or UpdateMultiple.</remarks>
            /// <typeparam name="TEntity">The type of the entities in the post-image collection.</typeparam>
            /// <param name="name">The name of the post-image collection to retrieve. Defaults to "PostImage".</param>
            /// <returns>A list of entities of the specified type from the post-image collection. If the collection is not found, an empty list is returned.</returns>
            public List<TEntity> GetPostImages<TEntity>(string name = "PostImage") where TEntity : Entity
            {
                if (context is not IPluginExecutionContext4 context4) return [];

                return context4.PostEntityImagesCollection.Where(x => x.ContainsKey(name)).Select(x => x[name].ToEntity<TEntity>()).ToList();
            }

            /// <summary>
            /// Returns the formatted representation of the execution stage based on the context's stage value.
            /// </summary>
            /// <returns>A string representing the execution stage such as "PreValidation", "PreOperation", "MainOperation", or "PostOperation". Returns null if the stage does not match any predefined values.</returns>
            public string GetFormattedExecutionStage()
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
            /// Retrieves a formatted execution mode string based on the mode of the plugin execution context.
            /// </summary>
            /// <returns>
            /// A string representing the execution mode, either "Synchronous" for mode 0 or "Asynchronous" for mode 1.
            /// Returns null if the mode is not recognized.
            /// </returns>
            public string GetFormattedExecutionMode()
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
}
