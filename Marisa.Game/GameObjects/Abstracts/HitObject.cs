using System;
using System.Collections.Generic;
using System.Text;
using Marisa.Game.GameObjects.Enums;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;

namespace Marisa.Game.GameObjects.Abstracts
{
    public abstract class HitObject : CompositeDrawable
    {
        public int HitTime;
        public HitColor HitColor;

        private Container box;


        public Container GetContainer(TextureStore textures)
        {
            return new Container
            {
                AutoSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Children = new Drawable[]
                {
                    new Box
                    {
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                    },
                    new Sprite
                    {
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Texture = textures.Get("logo")
                    },
                }

            };
        }
        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            InternalChild = box = this.GetContainer(textures);
        }

    }
}
