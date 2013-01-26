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
			position = new Vector2(550, 600);
			origin = new Vector2(0, 0);
			center = new Vector2(0, 0);
		}
		public void MoveLeft()
		{
			move(new Vector2(-1, 0));
		}
		public void MoveRight()
		{
			move(new Vector2(1, 0));
		}
		public void Jump()
		{
		}
	}
}
