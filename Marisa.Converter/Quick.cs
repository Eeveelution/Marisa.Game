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

            int Index = 0;
            string[] file = File.ReadAllLines(filename);

            for(int i = 0; i != file.Length; i++)
            {
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
