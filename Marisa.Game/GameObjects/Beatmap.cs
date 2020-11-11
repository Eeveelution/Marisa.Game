namespace Marisa.Game.GameObjects
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using osu.Framework.Logging;

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

        public void LogBeatmap()
        {
            string Format = "";
            {
                Format += "Artist: {0}\n";
                Format += "ArtistUnicode: {1}\n";
                Format += "Title: {2}\n";
                Format += "TitleUnicode: {3}\n";
                Format += "Creator: {4}\n";
                Format += "Difficulty: {5}\n";
                Format += "Source: {6}\n";
                Format += "Tags: {7}\n";
                Format += "DifficultySetings:\n";
                Format += "    NoteVelocity: {8}\n";
                Format += "    HitSize: {9}\n";
                Format += "HitObjects: {10}";
            }

            string Message = String.Format(Format,
                this.Artist, this.ArtistUnicode,
                this.Title, this.TitleUnicode,
                this.Creator, this.Difficulty,
                this.Source, this.Tags,
                this.Settings.NoteVelocity,
                this.Settings.HitSize,
                this.Hits.Count
                ); 

            foreach(string s in Message.Split('\n'))
            {
                Logger.Log(s, LoggingTarget.Information, LogLevel.Verbose, true);
            }
            
        }
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
