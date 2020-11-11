namespace Marisa.Game.GameObjects
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Beatmap
    {
        [JsonProperty("version")]
        public long Version { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("artist_unicode")]
        public string ArtistUnicode { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("title_unicode")]
        public string TitleUnicode { get; set; }

        [JsonProperty("difficulty")]
        public string Difficulty { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("creator")]
        public string Creator { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }

        [JsonProperty("hits")]
        public List<Hit> Hits { get; set; }
    }

    public partial class Hit
    {
        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("color")]
        public long Color { get; set; }

        [JsonProperty("note_speed")]
        public double NoteSpeed { get; set; }

        [JsonProperty("hitsound_override")]
        public string HitsoundOverride { get; set; }
    }

    public partial class Settings
    {
        [JsonProperty("note_velocity")]
        public long NoteVelocity { get; set; }

        [JsonProperty("hit_size")]
        public long HitSize { get; set; }
    }
    public partial class Beatmap
    {
        public static Beatmap FromJson(string json) => JsonConvert.DeserializeObject<Beatmap>(json, Marisa.Game.GameObjects.Reader.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Beatmap self) => JsonConvert.SerializeObject(self, Marisa.Game.GameObjects.Writer.Settings);
    }

    internal static class Reader
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
    internal static class Writer
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
                {
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
        };
    }
}
