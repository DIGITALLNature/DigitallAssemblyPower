// Copyright (c) DIGITALL Nature. All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Digitall.Dataverse.Testing;
using Digitall.Plugins.Extensions;
using Digitall.Plugins.Serialization.SystemTextJson;

namespace Digitall.Plugins.Tests.Serialization;

public class SystemTextJsonSerializerServiceTests
{
    [Test]
    public async Task GetSerializerService_WithSystemTextJsonFactory_RoundtripsContractAttributes()
    {
        var serviceProvider = new PluginExecutionContextBuilder(new FakeOrganizationService()).BuildServiceProvider();
        var serializer = serviceProvider.GetSerializerService(new SystemTextJsonSerializerServiceFactory());
        const string input = "{\"display_name\":\"PBV contract\",\"status\":\"Accepted\",\"future_field\":{\"enabled\":true}}";

        var data = serializer.JsonDeserialize<SampleContract>(input);

        await Assert.That(data).IsNotNull();
        await Assert.That(data!.DisplayName).IsEqualTo("PBV contract");
        await Assert.That(data.Status).IsEqualTo(SampleStatus.Accepted);
        await Assert.That(data.AdditionalProperties["future_field"].GetProperty("enabled").GetBoolean()).IsTrue();

        var json = serializer.JsonSerialize(new SampleContract
        {
            DisplayName = data.DisplayName,
            Status = data.Status,
            AdditionalProperties = new Dictionary<string, JsonElement>
            {
                ["future_field"] = data.AdditionalProperties["future_field"]
            }
        });

        await Assert.That(json).Contains("\"display_name\":\"PBV contract\"");
        await Assert.That(json).Contains("\"status\":\"Accepted\"");
        await Assert.That(json).Contains("\"future_field\":{\"enabled\":true}");

        var rejected = serializer.JsonDeserialize<SampleContract>("{\"status\":\"Rejected\"}");
        await Assert.That(rejected!.Status).IsEqualTo(SampleStatus.Rejected);
    }

    [Test]
    public async Task GetSerializerService_WithNullFactory_ThrowsArgumentNullException()
    {
        var serviceProvider = new PluginExecutionContextBuilder(new FakeOrganizationService()).BuildServiceProvider();

        var ex = await Assert.That(() => serviceProvider.GetSerializerService(null)).ThrowsException();

        await Assert.That(ex).IsTypeOf<ArgumentNullException>();
    }

    private sealed class SampleContract
    {
        [JsonPropertyName("display_name")]
        public string DisplayName { get; init; }

        [JsonPropertyName("status")]
        [JsonConverter(typeof(JsonStringEnumConverter<SampleStatus>))]
        public SampleStatus Status { get; init; }

        [JsonExtensionData]
        public IDictionary<string, JsonElement> AdditionalProperties { get; init; } = new Dictionary<string, JsonElement>();
    }

    private enum SampleStatus
    {
        Accepted,
        Rejected
    }
}
