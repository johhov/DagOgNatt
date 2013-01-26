using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
	internal class Movable : ScreenObject
	{
		protected void move(Vector2 position)
		{
			this.position += position;
		}
	}
}
