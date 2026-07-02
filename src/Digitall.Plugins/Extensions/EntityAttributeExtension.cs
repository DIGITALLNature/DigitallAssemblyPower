// Copyright (c) DIGITALL Nature. All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xrm.Sdk;
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Digitall.Plugins.Extensions;

/// <summary>
///     EntityAttribute extensions
/// </summary>
public static class EntityAttributeExtension
{
    /// <param name="executor">self</param>
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
        ///     Evaluates if Entity contains attribute and PreEntityImage does not
        /// </summary>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public bool IsEntityAttributeValueNew(string attribute) => executor.Core.IsEntityAttributeValueNew(attribute);

        /// <summary>
        ///     Evaluates if attribute in Entity is set and is different from PreEntityImage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public bool IsEntityAttributeValueChanged<T>(string attribute) => executor.Core.IsEntityAttributeValueChanged<T>(attribute);

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
    }

    /// <param name="pluginExecutionContext">self</param>
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
        ///     Evaluates if attribute contained in Entity or PreEntityImage and not null.
        /// </summary>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public bool IsEntityAttributeValueNullOrEmpty(string attribute)
        {
            Debug.Assert(pluginExecutionContext != null, nameof(pluginExecutionContext) + " != null");
            var entity = pluginExecutionContext.GetTarget<Entity>();
            var preImage = pluginExecutionContext.GetPreImage<Entity>();

            if (entity == null) return false;
            var entityAttributeNullOrMissing = !entity.Contains(attribute) || entity[attribute] == null;
            var preImageAttributeNullOrMissing = preImage == null || !preImage.Contains(attribute) || preImage[attribute] == null;
            return entityAttributeNullOrMissing && preImageAttributeNullOrMissing;
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
}
