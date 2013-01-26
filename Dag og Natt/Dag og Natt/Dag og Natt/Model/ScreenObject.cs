using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
	internal class ScreenObject
	{
		protected Vector2 position;
		protected Vector2 origin;
		protected Vector2 center;
		public Texture2D texture
		{
			get { return texture; }
			set {this.texture = value;}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, position, Color.White);
		}

	}
}
