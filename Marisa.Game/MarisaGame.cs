using Marisa.Game.AudioManagers;
using osu.Framework.Allocation;
using osu.Framework.Audio.Sample;
using osu.Framework.Graphics;
using osu.Framework.Input.Events;
using osu.Framework.Screens;
using osuTK.Input;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using osu.Framework.IO.Stores;
using osu.Framework.Statistics;
using System.Linq;
using System.Threading.Tasks;
using osu.Framework.Audio.Track;
using osu.Framework.Logging;
using osu.Framework.Graphics.Shapes;
using osuTK.Graphics;
using osu.Framework.Graphics.Sprites;
using ManagedBass;
using Marisa.Game.GameObjects;
using Marisa.Game.GameObjects.Enums;

namespace Marisa.Game
{
    public class MarisaGame : MarisaGameBase
    {
        private ScreenStack screenStack;

        private FileAudioStore AudioStore = new FileAudioStore();
        //private FileAudioManager AudioManager = new FileAudioManager(Host.AudioThread, AudioStore, AudioStore);

        private Beatmap map = Beatmap.FromJson(File.ReadAllText("charts/messed up gravity/diff.json"));

        [BackgroundDependencyLoader]
        private void load()
        {
            // Add your top-level game components here.
            // A screen stack and sample screen has been provided for convenience, but you can replace it if you don't want to use screens.
            Child = screenStack = new ScreenStack { RelativeSizeAxes = Axes.Both };

            #region MainScreenLoad

            Logger.Log("Running in: " + Environment.CurrentDirectory, LoggingTarget.Information, LogLevel.Debug, true);
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


            Bass.Init(0);

            foreach (Hit h in map.Hits)
            {
                AddInternal(new DrumHit(h.Time, (HitColor)h.Color));
            }
            
            StartAudio("charts/messed up gravity/audio.mp3");
            #endregion

        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            //StartAudio();

            map.LogBeatmap();
        }

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            if(!e.AltPressed && !e.ControlPressed)
            {
                switch (e.Key)
                {
                    case Key.B:
                        map.LogBeatmap();
                        break;
                }
            }

            return base.OnKeyDown(e);
        }

        public void StartAudio(string Filename)
        {
            Logger.Log($"Started Audio File \"{Filename}\"", LoggingTarget.Runtime, LogLevel.Verbose, true);
            TrackBass test = new TrackBass(AudioStore.GetStream(Filename));
            Audio.AddItem(test);
            test.Start();
        }
    }
}
