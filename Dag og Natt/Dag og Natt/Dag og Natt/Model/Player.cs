using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
	internal class Player : Movable
	{
		private int speed;
		private int atEdge;
		
		public Player()
		{
			position = new Vector2(550, 550);
			origin = new Vector2(0, 0);
			center = new Vector2(0, 0);
			speed = 4;
			atEdge = 0;
		}
		public void Move(Vector2 direction)
		{
			position += direction * speed;
		}
		public void Jump()
		{
		}
	}
}
