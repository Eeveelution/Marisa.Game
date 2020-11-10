using System;
using System.Collections.Generic;
using System.Text;
using Marisa.Converter.OsuConverter.OsuFileObjects.Enums;

namespace Marisa.Converter.OsuConverter.OsuFileObjects
{
    class General
    {
        public string AudioFilename;
        public int AudioLeadIn;
        public int PreviewTime;
        public CountdownSpeed Countdown;
        public SampleSet SampleSet;
        public double StackLeniency;
        public Mode Mode;
        public bool LetterboxInBreaks;
        public bool WidescreenStoryboard;
    }
}
