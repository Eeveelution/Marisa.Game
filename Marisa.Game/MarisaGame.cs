﻿using Marisa.Game.AudioManagers;
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
using Marisa.Game.Audio;
using osu.Framework.Audio;
using Marisa.Game.Screens;

namespace Marisa.Game
{
    public class MarisaGame : MarisaGameBase
    {
        private ScreenStack screenStack;

        public void AddAudioItem(AdjustableAudioComponent audio) { this.Audio.AddItem(audio); }

        [BackgroundDependencyLoader]
        private void load()
        {
            // Add your top-level game components here.
            // A screen stack and sample screen has been provided for convenience, but you can replace it if you don't want to use screens.
            Child = screenStack = new ScreenStack { RelativeSizeAxes = Axes.Both };

            #region MainScreenLoad
            //Logs current directory the client is being run in
            Logger.Log("Running in: " + Environment.CurrentDirectory, LoggingTarget.Information, LogLevel.Debug, true);

            //screenStack.Push(new GameplayScreen(this));
            screenStack.Push(new FrameworkTesting(this));

            Bass.Init(0);
            #endregion
        }

    }
}
