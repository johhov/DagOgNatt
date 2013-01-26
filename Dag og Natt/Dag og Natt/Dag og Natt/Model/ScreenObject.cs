using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
	internal class ScreenObject
	{
		protected Vector2 position;
		protected int origin;
		protected int center;
		protected Texture2D texture;

		public void draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, position, Color.White);
		}
	}
}
