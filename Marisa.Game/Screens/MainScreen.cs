using System;
using System.IO;
using System.Threading;
using ManagedBass;
using Marisa.Game.GameObjects;
using Marisa.Game.GameObjects.Enums;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Sample;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Logging;
using osu.Framework.Screens;
using osu.Framework.Threading;
using osuTK.Graphics;

namespace Marisa.Game.Screens
{
    public class MainScreen : Screen
    {

        private SampleChannelBass bassSample;

        [BackgroundDependencyLoader]
        private void load(ISampleStore samples)
        {
            SampleChannel channel;
            //bassSample = (SampleChannelBass)samples.Get("test.mp3");

            Logger.Log("Running in: " + Environment.CurrentDirectory, LoggingTarget.Information, LogLevel.Debug, true);
            InternalChildren = new Drawable[]
            {
                new Box
                {
                    Colour = Color4.Violet,
                    RelativeSizeAxes = Axes.Both,
                },
                new SpriteText
                {
                    Y = 20,
                    Text = "Main Screen",
                    Anchor = Anchor.TopCentre,
                    Origin = Anchor.TopCentre,
                    Font = FontUsage.Default.With(size: 40)
                },
                
            };

            Bass.Init(0);

            Beatmap map = Beatmap.FromJson(File.ReadAllText("charts/messed up gravity/diff.json"));

            foreach(Hit h in map.Hits)
            {
                AddInternal(new DrumHit(h.Time, (HitColor)h.Color));
            }
            
        }

        protected override void Update()
        {
            
            base.Update();
        }
    }
}
