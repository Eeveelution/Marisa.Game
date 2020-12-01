using System;
using System.Collections.Generic;
using System.Text;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;
using osu.Framework.Logging;
using osuTK.Graphics;
using osuTK.Input;

namespace Marisa.Game.Screens
{
    class FrameworkTesting : IMarisaScreen
    {
        private BasicMenu Menu = new BasicMenu(Direction.Vertical, false);
        public FrameworkTesting(MarisaGame ctx)
        {
            Menu.Padding = new MarginPadding(4);
            Menu.Add(new MenuItem("test lmao"));
            Menu.Add(new MenuItem("test lmao"));
            Menu.Add(new MenuItem("test lmao"));
            Menu.Add(new MenuItem("test lmao"));
            Menu.Add(new MenuItem("test lmao"));
            Menu.Add(new MenuItem("test lmao"));
            Menu.Add(new MenuItem("test lmao"));
            Menu.Add(new MenuItem("test lmao"));
            Menu.Add(new MenuItem("test lmao"));
            Menu.Anchor = Anchor.Centre;
            
            Menu.Origin = Anchor.Centre;

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
                Menu
            };
            
            LoadComplete();
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
        }

        protected override bool OnKeyDown(KeyDownEvent e)
        {
            if(!e.AltPressed && !e.ControlPressed)
                switch (e.Key)
                {
                    case Key.Enter:
                        Logger.Log("shouldve worked..");
                        Menu.State = MenuState.Open;
                        break;
                }
            return base.OnKeyDown(e);
        }
    }
}
