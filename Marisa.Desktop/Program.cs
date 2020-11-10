using osu.Framework.Platform;
using osu.Framework;
using Marisa.Game;

namespace Marisa.Desktop
{
    public static class Program
    {
        public static void Main()
        {
            using (GameHost host = Host.GetSuitableHost(@"Marisa"))
            using (osu.Framework.Game game = new MarisaGame())
                host.Run(game);
        }
    }
}
