using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dag_og_Natt
{
    internal class Button : ScreenObject
    {
        public enum MouseStatus
        {
            Normal,
            Clicked,
            Released
        }

        private MouseStatus state;
        private Rectangle bounds;
        private Input input;
        private string type;
        private Keys key;

        private static int offset = 50;

        public event EventHandler clicked;

        public delegate void EventHandler(string n);

        new public Texture2D TextureDay
        {
            get { return textureDay; }
            set
            {
                this.textureDay = value;
                offset += (int)(this.textureDay.Height*2);
                this.position = new Vector2(Global.WINDOWWIDTH / 2 - textureDay.Width / 2, offset);
            }
        }

        public Button(Vector2 position, string type, Keys key)
        {
            this.position = position;
            bounds = new Rectangle(0, 0, 0, 0);
            input = new Input();
            this.type = type;
            this.key = key;
        }

        public void Update()
        {
            input.Update();
            state = MouseStatus.Normal;

            if (bounds == new Rectangle(0, 0, 0, 0))
            {
                bounds = new Rectangle((int)Position.X, (int)Position.Y, TextureDay.Width, TextureDay.Height);
            }

            bool isMouseOver = bounds.Contains((int)input.Position.X, (int)input.Position.Y);

            if (isMouseOver && !input.LeftClick)
            {
                state = MouseStatus.Released;
            }
            else if (!isMouseOver && !input.LeftClick)
            {
                state = MouseStatus.Normal;
            }
            else if (isMouseOver && input.LeftClick)
            {
                state = MouseStatus.Clicked;
            }

            if (input.NewLeftClick)
            {
                if (isMouseOver)
                {
                    state = MouseStatus.Clicked;
                }
            }

            if (input.ReleaseLeftClick)
            {
                if (isMouseOver)
                {
                    state = MouseStatus.Released;
                }
            }

            if (input.IsKeyPressed(key))
            {
                if (clicked != null)
                {
                    clicked(this.type);
                }
            }
        }

        new public void Draw(SpriteBatch spriteBatch)
        {
            switch (state)
            {
                case MouseStatus.Normal:
                    spriteBatch.Draw(TextureDay, bounds, Color.White);
                    break;

                case MouseStatus.Released:
                    spriteBatch.Draw(TextureDay, bounds, Color.DarkGray);
                    break;

                case MouseStatus.Clicked:
                    if (input.currentMouseState.LeftButton != input.previousMouseState.LeftButton)
                    {
                        if (clicked != null)
                        {
                            clicked(this.type);
                            state = MouseStatus.Normal;
                        }
                    }
                    spriteBatch.Draw(TextureDay, bounds, Color.Red);
                    break;

                default:
                    spriteBatch.Draw(TextureDay, bounds, Color.Black);
                    break;
            }
        }
    }
}