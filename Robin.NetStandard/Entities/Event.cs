using System.Text.Json.Serialization;
using Robin.NetStandard.Converters;

namespace Robin.NetStandard.Entities;

public class Event:Entity
{
   [JsonPropertyName("id")]
   public string Id { get; set; }
   
   [JsonPropertyName("organizer_id")]
   public int OrganizerId { get; set; }
   
   [JsonPropertyName("organizer_email")]
   public string OrganizerEmail { get; set; }
   
   [JsonPropertyName("creator_id")]
   public int CreatorId { get; set; }
   
   [JsonPropertyName("creator_email")]
   public string CreatorEmail { get; set; }
   
   [JsonPropertyName("space_id")]
   public int SpaceId { get; set; }
   
   [JsonPropertyName("title")]
   public string Title { get; set; }
   
   [JsonPropertyName("description")]
   public string Description { get; set; }
   
   [JsonPropertyName("location")]
   public string Location { get; set; }
   
   [JsonPropertyName("remote_event_id")]
   public string RemoteEventId { get; set; }
   
   [JsonPropertyName("remote_type")]
   public string RemoteType { get; set; }
   
   [JsonPropertyName("creation_type")]
   public string CreationType { get; set; }
   
   [JsonPropertyName("uid")]
   public string UID { get; set; }
   
   [JsonPropertyName("started_at")]
   [JsonConverter(typeof(DateTimeOffsetParseConverter))]
   public DateTimeOffset? StartedAt { get; set; }
   
   [JsonPropertyName("ended_at")]
   [JsonConverter(typeof(DateTimeOffsetParseConverter))]
   public DateTimeOffset? EndedAt { get; set; }
   
   [JsonPropertyName("start")]
   public DateTimeZone Start { get; set; }
   
   [JsonPropertyName("end")]
   public DateTimeZone End { get; set; }
   
   [JsonPropertyName("series_id")]
   public string SeriesId { get; set; }
   
   [JsonPropertyName("recurrence_id")]
   public string RecurrenceId { get; set; }
   
   [JsonPropertyName("status")]
   public string Status { get; set; }
   
   [JsonPropertyName("recurrence")]
   public string[] Recurrence { get; set; }
   
   [JsonPropertyName("is_all_day")]
   public bool? IsAllDay { get; set; }
   
   [JsonPropertyName("visibility")]
   public string Visibility { get; set; }
   
   [JsonPropertyName("invitees")]
   public Invitee[] Invitees { get; set; }
}