using System.Diagnostics;
using Robin.NetStandard.Entities;
using Slack.NetStandard.Tests;

namespace Robin.NetStandard.Tests;

public class Entities
{
    [Fact]
    public void Device()
    {
        EnsureEntityMatches<Device>("Device.json", 
            "last_reported_at", "created_at", "updated_at");
    }

    [Fact]
    public void Event()
    {
        EnsureEntityMatches<Event>("Event.json", 
            "date_time", "started_at", "ended_at", "updated_at", "created_at");
    }

    [Fact]
    public void Location()
    {
        EnsureEntityMatches<Location>("Location.json", "updated_at", "created_at");
    }

    private void EnsureEntityMatches<T>(string filename, params string[] excludedProperties) where T : Entity
    {
        var entity = Utility.ExampleFileContent<T>(filename)!;
        Assert.Null(entity.OtherProperties);
        Assert.True(Utility.CompareJson(entity, filename,excludedProperties));
    }
}