using System.Diagnostics;
using Robin.NetStandard.Entities;
using Slack.NetStandard.Tests;

namespace Robin.NetStandard.Tests;

public class Entities
{
    [Fact]
    public void Device()
    {
        EnsureEntityMatches<Device>("last_reported_at");
    }

    [Fact]
    public void Event()
    {
        EnsureEntityMatches<Event>("date_time", "started_at", "ended_at");
    }

    [Fact]
    public void Location()
    {
        EnsureEntityMatches<Location>();
    }

    [Fact]
    public void Organization()
    {
        EnsureEntityMatches<Organization>();
    }

    [Fact]
    public void User()
    {
        EnsureEntityMatches<User>();
    }

    [Fact]
    public void Space()
    {
        EnsureEntityMatches<Space>("last_presence_at");
    }

    [Fact]
    public void FreeBusy()
    {
        EnsureEntityMatches<FreeBusy>("FreeBusy.json", "from", "to", "date_time", "started_at", "ended_at");
    }

    [Fact]
    public void Presence()
    {
        EnsureEntityMatches<Presence>("last_seen_at", "arrived_at", "expired_at");
    }

    [Fact]
    public void Zone()
    {
        EnsureEntityMatches<Zone>();
    }

    private void EnsureEntityMatches<T>(params string[] excludedProperties) where T : Entity
    {
        var filename = $"{typeof(T).Name}.json";
        var entity = Utility.ExampleFileContent<T>(filename)!;
        Assert.Null(entity.OtherProperties);
        Assert.True(Utility.CompareJson(entity, filename, excludedProperties.Concat(new []{ "created_at", "updated_at" }).ToArray()));
    }
}