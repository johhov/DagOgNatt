using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
    internal class ScreenObject
    {
        protected Vector2 staringPosition;
        protected Vector2 position;
        protected Vector2 origin;
        protected Vector2 center;
        protected Texture2D texture;

        public Vector2 Position
        {
            get { return position; }
        }

        public Texture2D Texture
        {
            get { return texture; }
            set { this.texture = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }
    }
}