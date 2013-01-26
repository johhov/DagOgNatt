using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
	internal class Player : Movable
	{
		private int speed;
		private int atEdge;
		private int boundingBoxLeftEdge;
		private int boundingBoxRightEdge;
		private Vector2 moveTo;

		public int AtEdge
		{
			get { return atEdge; }
			set { atEdge = value; }
		}

		public int Speed
		{
			get { return speed; }
			set { speed = value; }
		}

		public Player()
		{
			position = new Vector2(490, 550);
			origin = new Vector2(0, 0);
			center = new Vector2(0, 0);
			speed = 4;
			atEdge = 0;
			boundingBoxLeftEdge = 270;
			boundingBoxRightEdge = 760;
			moveTo = position;
		}
		public void Update()
		{
			position = moveTo;

			if (position.X <= boundingBoxLeftEdge)
			{
				atEdge = -1;
				position.X = boundingBoxLeftEdge + 1;
				moveTo.X = position.X;
			}
			else if (position.X >= boundingBoxRightEdge)
			{
				atEdge = 1;
				position.X = boundingBoxRightEdge - 1;
				moveTo.X = position.X;
			}
			else
			{
				atEdge = 0;
			}
		}
		public void Move(Vector2 direction)
		{
			moveTo = position + direction * speed;
		}
		public void Jump()
		{

		}
	}
}
