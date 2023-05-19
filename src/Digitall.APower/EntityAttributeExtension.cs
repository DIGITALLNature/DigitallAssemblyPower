// Copyright (c) DIGITALL Nature. All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System.Collections.Generic;
using System.Linq;
using Microsoft.Xrm.Sdk;

namespace Digitall.APower
{
    /// <summary>
    ///     EntityAttribute extensions
    /// </summary>
    public static class EntityAttributeExtension
    {
        /// <summary>
        ///     Get value T from entity. Lookup order 1st Entity, 2nd PreEntityImage, 3rd default!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="executor">self</param>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public static T GetEntityAttributeValue<T>(this Executor executor, string attribute) => executor.Core.GetEntityAttributeValue<T>(attribute);


        /// <summary>
        ///     Evaluates if Entity contains attribute and PreEntityImage does not
        /// </summary>
        /// <param name="executor">self</param>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public static bool IsEntityAttributeValueNew(this Executor executor, string attribute) => executor.Core.IsEntityAttributeValueNew(attribute);

        /// <summary>
        ///     Evaluates if attribute in Entity is set and is different from PreEntityImage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="executor">self</param>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public static bool IsEntityAttributeValueChanged<T>(this Executor executor, string attribute) => executor.Core.IsEntityAttributeValueChanged<T>(attribute);

        /// <summary>
        ///     Evaluates if attribute contained in Entity or PreEntityImage and not null.
        /// </summary>
        /// <param name="executor">self</param>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public static bool IsEntityAttributeValueNullOrEmpty(this Executor executor, string attribute) => executor.Core.IsEntityAttributeValueNullOrEmpty(attribute);

        /// <summary>
        ///     Merge Entity and PreEntityImage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="executor">self</param>
        /// <returns></returns>
        public static T MergeEntity<T>(this Executor executor) where T : Entity => executor.Core.MergeEntity<T>();

        /// <summary>
        ///     Get value T from entity. Lookup order 1st Entity, 2nd PreEntityImage, 3rd default!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pluginCore">self</param>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public static T GetEntityAttributeValue<T>(this PluginCore pluginCore, string attribute)
        {
            if (pluginCore.Entity != null && pluginCore.Entity.Attributes.Contains(attribute))
            {
                return (T)pluginCore.Entity.Attributes[attribute];
            }

            if (pluginCore.PreEntityImage != null && pluginCore.PreEntityImage.Attributes.Contains(attribute))
            {
                return (T)pluginCore.PreEntityImage.Attributes[attribute];
            }

            return default;
        }

        /// <summary>
        ///     Evaluates if Entity contains attribute and PreEntityImage does not
        /// </summary>
        /// <param name="pluginCore">self</param>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public static bool IsEntityAttributeValueNew(this PluginCore pluginCore, string attribute) => pluginCore.Entity != null && pluginCore.Entity.Contains(attribute) &&
                                                                                                      (pluginCore.PreEntityImage == null || !pluginCore.PreEntityImage.Contains(attribute));

        /// <summary>
        ///     Evaluates if attribute in Entity is set and is different from PreEntityImage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pluginCore">self</param>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public static bool IsEntityAttributeValueChanged<T>(this PluginCore pluginCore, string attribute)
        {
            //not in target
            if (pluginCore.Entity != null && !pluginCore.Entity.Contains(attribute))
            {
                return false;
            }

            //no pre-image
            if (pluginCore.PreEntityImage == null)
            {
                return true;
            }

            if (typeof(T) != typeof(string))
            {
                //was empty, stays empty
                if (!pluginCore.PreEntityImage.Contains(attribute) && pluginCore.Entity[attribute] == null)
                {
                    return false;
                }
            }
            else
            {
                //was empty, stays empty
                if (!pluginCore.PreEntityImage.Contains(attribute) && string.IsNullOrEmpty((string)pluginCore.Entity[attribute]))
                {
                    return false;
                }

                //treat null == "" as true
                if (pluginCore.PreEntityImage.Contains(attribute) && string.IsNullOrEmpty((string)pluginCore.PreEntityImage[attribute]) && string.IsNullOrEmpty((string)pluginCore.Entity[attribute]))
                {
                    return false;
                }
            }

            var cacheKey = $"EntityAttributeExtension-{typeof(T).FullName}";
            IEqualityComparer<T> typeEqualizer;
            if (pluginCore.CacheService.TryGet(cacheKey, out var value))
            {
                typeEqualizer = value as EqualityComparer<T>;
            }
            else
            {
                typeEqualizer = EqualityComparer<T>.Default;
                pluginCore.CacheService.SetSliding(cacheKey, typeEqualizer, 1800);
            }

            return !(pluginCore.PreEntityImage.Contains(attribute) && typeEqualizer.Equals((T)pluginCore.PreEntityImage[attribute], (T)pluginCore.Entity[attribute]));
        }

        /// <summary>
        ///     Evaluates if attribute contained in Entity or PreEntityImage and not null.
        /// </summary>
        /// <param name="pluginCore">self</param>
        /// <param name="attribute">lookup attribute</param>
        /// <returns></returns>
        public static bool IsEntityAttributeValueNullOrEmpty(this PluginCore pluginCore, string attribute) =>
            pluginCore.Entity != null && (!pluginCore.Entity.Contains(attribute) || pluginCore.Entity[attribute] == null) &&
            (pluginCore.PreEntityImage == null || !pluginCore.PreEntityImage.Contains(attribute) || pluginCore.PreEntityImage[attribute] == null);

        /// <summary>
        ///     Merge Entity and PreEntityImage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="executor">self</param>
        /// <returns></returns>
        public static T MergeEntity<T>(this PluginCore executor) where T : Entity
        {
            if (executor.PreEntityImage == null)
            {
                return executor.Entity.ToEntity<T>();
            }

            var mergedEntity = new Entity
            {
                Id = executor.PreEntityImage.Id,
                LogicalName = executor.PreEntityImage.LogicalName
            };

            // return all AttributeLogicalNameAttribute from the given type
            var attributes = from property in typeof(T).GetProperties()
                from attribute in
                    property.GetCustomAttributes(typeof(AttributeLogicalNameAttribute), false).OfType<AttributeLogicalNameAttribute>()
                select attribute;

            foreach (var attribute in attributes)
            {
                if (executor.Entity.Contains(attribute.LogicalName))
                {
                    mergedEntity[attribute.LogicalName] = executor.Entity[attribute.LogicalName];
                    if (executor.Entity.FormattedValues.ContainsKey(attribute.LogicalName))
                    {
                        mergedEntity.FormattedValues.Add(attribute.LogicalName, executor.Entity.FormattedValues[attribute.LogicalName]);
                    }
                }
                else if (executor.PreEntityImage.Contains(attribute.LogicalName))
                {
                    mergedEntity[attribute.LogicalName] = executor.PreEntityImage[attribute.LogicalName];
                    if (executor.PreEntityImage.FormattedValues.ContainsKey(attribute.LogicalName))
                    {
                        mergedEntity.FormattedValues.Add(attribute.LogicalName, executor.PreEntityImage.FormattedValues[attribute.LogicalName]);
                    }
                }
            }

            return mergedEntity.ToEntity<T>();
        }
    }
}
