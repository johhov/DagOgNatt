using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Dag_og_Natt
{
	internal class ScreenObject
	{
		protected Vector2 startingPosition;
		public Vector2 position;
		protected Vector2 origin;
		protected Vector2 center;
		protected Texture2D textureDay;
		protected Texture2D textureNight;
		protected Rectangle currentAnimation;
		protected bool moving;
		protected Song sound;

		public Vector2 Position
		{
			get { return position; }
		}

		public Song Song
		{
			get { return sound; }
			set { this.sound = value; }
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

		public ScreenObject()
		{
			startingPosition = new Vector2(0, 0);
			position = new Vector2(0, 0);
			origin = new Vector2(0, 0);
			center = new Vector2(0, 0);
			currentAnimation = new Rectangle(0, 0, 0, 0);
			moving = false;
		}
	}
}