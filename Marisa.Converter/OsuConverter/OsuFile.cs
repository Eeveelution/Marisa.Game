using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Marisa.Converter.OsuConverter.OsuFileObjects;

namespace Marisa.Converter.OsuConverter
{
    class OsuFile
    {
        public int OsuFileFormatVersion { get; private set; }

        public General GeneralMetadata { get; private set; }
        public Editor EditorSettings { get; private set; }
        public Metadata Metadata { get; private set; }
        public Difficulty DiffucltySettings { get; private set; }

        public List<Event> StoryboardEvents { get; private set; }
        public List<TimingPoint> TimingPoints { get; private set; }
        public List<HitObject> HitObjects { get; private set; }

        public OsuFile(string FileLocation)
        {
            string[] Document = File.ReadAllLines(FileLocation);

            FileSection CurrentSection = FileSection.General;

            for(int i = 0; i != Document.Length; i++)
            {
                if      (Document[i].Contains("[General]"))      CurrentSection = FileSection.General;
                else if (Document[i].Contains("[Editor]"))       CurrentSection = FileSection.Editor;
                else if (Document[i].Contains("[Metadata]"))     CurrentSection = FileSection.Metadata;
                else if (Document[i].Contains("[Difficulty]"))   CurrentSection = FileSection.Difficulty;
                else if (Document[i].Contains("[Events]"))       CurrentSection = FileSection.Events;
                else if (Document[i].Contains("[TimingPoints]")) CurrentSection = FileSection.TimingPoints;
                else if (Document[i].Contains("[HitObjects]"))   CurrentSection = FileSection.HitObjects;

                switch (CurrentSection)
                {
                    case FileSection.General:

                        break;
                }
            }

        }
    }
}
