// Copyright (c) DIGITALL Nature. All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using Digitall.Plugins;
using Digitall.Plugins.Extensions;
using Microsoft.Xrm.Sdk;

namespace SamplePlugin;

/// <summary>
/// Audits Account name changes by creating a related note.
/// Register on Account Update and configure a pre-image containing the name attribute.
/// </summary>
public class AccountNameChangeAuditSample : PluginSkeleton
{
    private const string AccountEntityName = "account";
    private const string NameAttribute = "name";

    protected override void ExecuteInternal(IServiceProvider serviceProvider)
    {
        if (serviceProvider == null) throw new ArgumentNullException(nameof(serviceProvider));

        var context = serviceProvider.GetExecutionContext();
        var target = context.GetTarget<Entity>();

        if (target == null ||
            !string.Equals(target.LogicalName, AccountEntityName, StringComparison.OrdinalIgnoreCase))
        {
            return;
        }

        var preImage = context.GetPreImage<Entity>();
        if (preImage == null)
        {
            throw new InvalidPluginExecutionException(
                "Register a pre-image containing the account name attribute.");
        }

        if (!context.IsEntityAttributeValueChanged<string>(NameAttribute))
        {
            return;
        }

        var previousName = preImage.GetAttributeValue<string>(NameAttribute);
        var currentName = target.GetAttributeValue<string>(NameAttribute);
        var note = new Entity("annotation")
        {
            ["subject"] = "Account name changed",
            ["notetext"] = $"Account name changed from '{previousName}' to '{currentName}'.",
            ["objectid"] = new EntityReference(target.LogicalName, target.Id)
        };

        serviceProvider.GetOrganizationService().Create(note);
    }
}
