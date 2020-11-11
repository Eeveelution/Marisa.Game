using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Marisa.Converter.OsuConverter.OsuFileObjects.Enums;
using Marisa.Game.GameObjects;

namespace Marisa.Converter
{
    class Quick
    {
        public static void Writezzz(string filename)
        {
            Beatmap map = new Beatmap();
            map.Hits = new List<Hit>();

            map.Version = 1;

            map.Settings = new Settings();
            map.Settings.HitSize = 2;
            map.Settings.NoteVelocity = 1;

            int Index = 0;
            string[] file = File.ReadAllLines(filename);

            for(int i = 0; i != file.Length; i++)
            {
                if (file[i].Contains("Title:")) map.Title = file[i].Replace("Title:", "");
                if (file[i].Contains("TitleUnicode:")) map.TitleUnicode = file[i].Replace("TitleUnicode:", "");
                if (file[i].Contains("Artist:")) map.Artist = file[i].Replace("Artist:", "");
                if (file[i].Contains("ArtistUnicode:")) map.ArtistUnicode = file[i].Replace("ArtistUnicode:", "");
                if (file[i].Contains("Creator:")) map.Creator = file[i].Replace("Creator:", "");
                if (file[i].Contains("Version:")) map.Difficulty = file[i].Replace("Version:", "");
                if (file[i].Contains("Source:")) map.Source = file[i].Replace("Source:", "");
                if (file[i].Contains("Tags:")) map.Tags = file[i].Replace("Tags:", "");
                if (file[i].Contains("HitObjects"))
                {
                    Index = i;
                    break;
                }
            }

            for(int i = Index+1; i != file.Length; i++)
            {
                string ToParse = file[i];
                HitObjectType type = (HitObjectType)int.Parse(ToParse.Split(',')[3]);

                if(type == HitObjectType.HitCircle || type == HitObjectType.NewCombo || type ==HitObjectType.Slider)
                {
                    Hit hit = new Hit();
                    
                    int Sound = int.Parse(ToParse.Split(',')[4]);

                    if (Sound == 0 || Sound == 4) hit.Color = 0;
                    if (Sound == 8 || Sound == 12) hit.Color = 1;

                    hit.Time = int.Parse(ToParse.Split(',')[2]);
                    hit.HitsoundOverride = "none";
                    hit.NoteSpeed = 2.0;

                    map.Hits.Add(hit);
                }
            }

            File.WriteAllText("text.json", map.ToJson());
        }
    }
}
