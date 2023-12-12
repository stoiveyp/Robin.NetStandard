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
        Assert.True(Utility.CompareJson(device, "Device.json", 
            "last_reported_at", "created_at", "updated_at"));
    }

    [Fact]
    public void Event()
    {
        var evt = Utility.ExampleFileContent<Event>("Event.json");
        Assert.True(Utility.CompareJson(evt, "Event.json", 
            "date_time", "started_at", "ended_at", "updated_at", "created_at"));
    }
}