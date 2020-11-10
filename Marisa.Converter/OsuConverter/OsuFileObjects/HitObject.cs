using System;
using System.Collections.Generic;
using System.Text;
using Marisa.Converter.OsuConverter.OsuFileObjects.Enums;

namespace Marisa.Converter.OsuConverter.OsuFileObjects
{
    class HitObject
    {
        public int X, Y;
        public int Time;
        public HitObjectType Type;
        public HitSound HitSound;
        public string ObjectParams;
        public string HitSampleParams;
    }
}
