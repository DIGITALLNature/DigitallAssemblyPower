// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System.Runtime.Serialization;
using System.Threading.Tasks;
using Digitall.Plugins.Services;

namespace Digitall.Plugins.Tests;

public class SerializerServiceTests
{
    private readonly SerializerService _service = new();

    [Test]
    public async Task JsonSerialize_NullData_ReturnsNull()
    {
        var result = _service.JsonSerialize<string>(null);

        await Assert.That(result).IsNull();
    }

    [Test]
    public async Task JsonSerialize_SimpleObject_ReturnsJson()
    {
        var data = new SampleData { Name = "Test", Value = 42 };

        var json = _service.JsonSerialize<SampleData>(data);

        await Assert.That(json).IsNotNull();
        await Assert.That(json).Contains("Test");
        await Assert.That(json).Contains("42");
    }

    [Test]
    public async Task JsonDeserialize_NullJson_ReturnsDefault()
    {
        var result = _service.JsonDeserialize<SampleData>(null);

        await Assert.That(result).IsNull();
    }

    [Test]
    public async Task JsonRoundtrip_PreservesAllProperties()
    {
        const int expectedValue = 99;
        var original = new SampleData { Name = "RoundtripTest", Value = expectedValue };

        var json = _service.JsonSerialize<SampleData>(original);
        var restored = _service.JsonDeserialize<SampleData>(json);

        await Assert.That(restored).IsNotNull();
        await Assert.That(restored!.Name).IsEqualTo("RoundtripTest");
        await Assert.That(restored.Value).IsEqualTo(expectedValue);
    }

    [Test]
    public async Task JsonDeserialize_TidyMode_ReplacesEmptyStringWithNull()
    {
        const string json = "{\"Name\":\"\",\"Value\":0}";

        var result = _service.JsonDeserialize<SampleData>(json, tidy: true);

        await Assert.That(result).IsNotNull();
        await Assert.That(result!.Name).IsNull();
    }

    [DataContract]
    private sealed class SampleData
    {
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Value")]
        public int Value { get; set; }
    }
}
