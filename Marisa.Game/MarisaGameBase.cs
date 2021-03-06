using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.IO.Stores;
using osuTK;
using Marisa.Resources;
using System.IO;
using osu.Framework.Configuration;

namespace Marisa.Game
{
    public class MarisaGameBase : osu.Framework.Game
    {
        // Anything in this class is shared between the test browser and the game implementation.
        // It allows for caching global dependencies that should be accessible to tests, or changing
        // the screen scaling for all components including the test browser and framework overlays.

        protected override Container<Drawable> Content { get; }

        protected MarisaGameBase()
        {
            if (!Directory.Exists("charts"))
                Directory.CreateDirectory("charts");
            // Ensure game and tests scale with window size and screen DPI.
            base.Content.Add(Content = new DrawSizePreservingFillContainer
            {
                // You may want to change TargetDrawSize to your "default" resolution, which will decide how things scale and position when using absolute coordinates.
                TargetDrawSize = new Vector2(1366, 768)
            });
        }

        [BackgroundDependencyLoader]
        private void load(FrameworkConfigManager config)
        {
            config.GetBindable<FrameSync>(FrameworkSetting.FrameSync).Value = FrameSync.Limit8x;
            Resources.AddStore(new DllResourceStore(typeof(MarisaResources).Assembly));
        }
    }
}
