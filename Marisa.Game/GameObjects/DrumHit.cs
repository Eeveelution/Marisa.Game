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
using Marisa.Game.GameObjects.Enums;

namespace Marisa.Game.GameObjects
{
    class DrumHit : HitObject
    {
        private int HitArea = 128;
        private double Speed = 1;

        public DrumHit(long hitTime, HitColor hitColor)
        {
            this.HitTime = hitTime;
            this.HitColor = hitColor;

            this.X = (float)(-HitArea + (hitTime - 0) * (1 * Speed));
            this.Y = (float)768 / 2;

            AutoSizeAxes = Axes.Both;
            Origin = Anchor.Centre;
        }

        protected override void Update()
        {
            this.UpdateObjectPosition();
            base.Update();
        }

        

        protected override void LoadComplete()
        {
            base.LoadComplete();
        }

        private void UpdateObjectPosition()
        {
            this.X = (float)(-HitArea + (this.HitTime - this.Time.Current) * Speed);

        }
    }
}
