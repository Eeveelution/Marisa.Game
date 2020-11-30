using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Marisa.Game.Audio;
using Marisa.Game.GameObjects;
using Marisa.Game.GameObjects.Enums;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK.Graphics;

namespace Marisa.Game.Screens
{
    class GameplayScreen : IMarisaScreen
    {
        private Beatmap map = Beatmap.FromJson(File.ReadAllText("charts/messed up gravity/diff.json"));
        private AudioPlayback playback = new AudioPlayback("charts/messed up gravity/audio.mp3");

        public GameplayScreen(MarisaGame ctx)
        {
            InternalChildren = new Drawable[]
            {
                new Box
                {
                    Colour = Color4.DimGray,
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

            foreach (Hit h in map.Hits)
            {
                AddInternal(new DrumHit(h.Time, (HitColor)h.Color));
            }

            ctx.AddAudioItem(playback.GetAudioComponent());

            LoadComplete();
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            //Starts Audio
            playback.Start();
            //Currently stuff's broken so this is here
            map.LogBeatmap();
        }
    }
}
