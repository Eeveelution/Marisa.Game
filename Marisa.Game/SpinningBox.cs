using Marisa.Game.Objects;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osuTK.Input;

namespace Marisa.Game
{
    public class SpinningBox : CompositeDrawable
    {
        private Container box;

        public SpinningBox()
        {
            AutoSizeAxes = Axes.Both;
            Origin = Anchor.Centre;
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            InternalChild = box = new Container
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

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            switch (e.Key)
            {
                case Key.D:
                    MoveRight(MoveDirection.Right);
                    break;
            }
            return base.OnKeyDown(e);
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            //box.Loop(b => b.RotateTo(0).RotateTo(360, 2500));
        }

        public void MoveRight(MoveDirection d)
        {
            switch (d)
            {
                case MoveDirection.Right:
                    this.MoveTo(new osuTK.Vector2(this.X + 15f, this.Y), 250, Easing.OutQuint);
                    break;
            } 
        }
    }
}
