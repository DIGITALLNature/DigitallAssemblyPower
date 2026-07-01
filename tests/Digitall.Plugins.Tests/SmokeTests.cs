// Copyright (c) DIGITALL Nature.All rights reserved
// DIGITALL Nature licenses this file to you under the Microsoft Public License.

using System.Threading.Tasks;
using TUnit.Assertions;

namespace Digitall.Plugins.Tests;

public class SmokeTests
{
    [Test]
    public async Task TUnit_Is_Configured()
    {
        bool configured = System.DateTime.UtcNow.Year >= 2000;
        await Assert.That(configured).IsTrue();
    }
}
