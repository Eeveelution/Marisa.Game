using osu.Framework.Audio;
using osu.Framework.IO.Stores;
using osu.Framework.Threading;

namespace Marisa.Game.AudioManagers
{
    public class FileAudioManager : AudioManager
    {
        public FileAudioManager(AudioThread audioThread, ResourceStore<byte[]> trackStore, ResourceStore<byte[]> sampleStore)
            : base(audioThread, trackStore, sampleStore)
        {
        }
    }
}
