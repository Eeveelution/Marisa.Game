using System;
using System.Collections.Generic;
using System.Text;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Logging;
using Marisa.Game.GameObjects.Abstracts;

namespace Marisa.Game.GameObjects
{
    class DrumHit : HitObject
    {
        public DrumHit()
        {
            
            AutoSizeAxes = Axes.Both;
            Origin = Anchor.Centre;
        }

        protected override void Update()
        {
            this.UpdateObjectPosition(128);
            base.Update();
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
        }

        private void UpdateObjectPosition(int HitArea)
        {
            this.X = (float)(HitArea + (5000 - this.Time.Current) * 0.25);

        }
    }
}
