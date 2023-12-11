using System.Diagnostics;
using Robin.NetStandard.Entities;
using Slack.NetStandard.Tests;

namespace Robin.NetStandard.Tests;

public class Entities
{
    [Fact]
    public void Device()
    {
        var device = Utility.ExampleFileContent<Device>("Device.json");
        Assert.NotNull(device);
    }
}