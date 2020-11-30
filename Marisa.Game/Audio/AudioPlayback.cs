using System;
using System.Collections.Generic;
using System.Text;
using Marisa.Game.AudioManagers;
using osu.Framework.Audio;
using osu.Framework.Audio.Track;
using osu.Framework.Graphics;
using osu.Framework.Logging;

namespace Marisa.Game.Audio
{
    class AudioPlayback
    {
        private FileAudioStore AudioStore = new FileAudioStore();
        private TrackBass Audio;
        /// <summary>
        /// Creates AudioPlayback Class, used for Managing Audio Playback
        /// </summary>
        /// <param name="AudioFilename">Path to Requested Filename</param>
        public AudioPlayback(string AudioFilename)
        {
            Audio = new TrackBass(AudioStore.GetStream(AudioFilename));
        }
        /// <summary>
        /// Starts/Resumes Audio Playback
        /// </summary>
        public void Start() { Audio.Start(); }
        /// <summary>
        /// Seeks Audio to Certain Position
        /// </summary>
        /// <param name="ms">Millisecond Position to Seek to</param>
        public void Seek(double ms) { Audio.Seek(ms); }
        /// <summary>
        /// Stops/Pauses Audio Playback
        /// </summary>
        public void Stop() { Audio.Stop(); }
        /// <summary>
        /// Gets Audio Component to add to the Game's AudioManager
        /// </summary>
        /// <returns>Component that can be added using Audio.Add(returned);</returns>
        public AdjustableAudioComponent GetAudioComponent() { return Audio; }
    }
}
