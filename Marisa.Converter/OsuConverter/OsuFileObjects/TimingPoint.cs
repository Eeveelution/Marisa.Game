using System;
using System.Collections.Generic;
using System.Text;
using Marisa.Converter.OsuConverter.OsuFileObjects.Enums;

namespace Marisa.Converter.OsuConverter.OsuFileObjects
{
    class TimingPoint
    {
        public int Time;
        public double BeatLength;
        public int Meter;
        public SampleSet SampleSet;
        public int SampleIndex;
        public int Volume;
        public bool Uninherited;
        public int Effects;
    }
}
