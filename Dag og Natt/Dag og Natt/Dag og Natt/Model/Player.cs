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
		}
		public void Move(Vector2 direction)
		{
			position += direction * speed;

			if(position.X <= boundingBoxLeftEdge)
			{
				atEdge = -1;
				position.X = boundingBoxLeftEdge + 1;
			}
			else if (position.X >= boundingBoxRightEdge)
			{
				atEdge = 1;
				position.X = boundingBoxRightEdge - 1;
			}
			else
			{
				atEdge = 0;
			}
		}
		public void Jump()
		{
		}
	}
}
