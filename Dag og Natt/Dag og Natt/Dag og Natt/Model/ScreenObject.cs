using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
    internal class ScreenObject
    {
        protected Vector2 startingPosition;
        protected Vector2 position;
        protected Vector2 origin;
        protected Vector2 center;
        protected Texture2D textureDay;
        protected Texture2D textureNight;

        public Vector2 Position
        {
            get { return position; }
        }

        public Texture2D TextureDay
        {
            get { return textureDay; }
            set { this.textureDay = value; }
        }

        public Texture2D TextureNight
        {
            get { return textureNight; }
            set { this.textureNight = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureDay, position, Color.White);
        }
    }
}