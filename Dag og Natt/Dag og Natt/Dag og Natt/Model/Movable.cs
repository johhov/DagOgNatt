using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
	internal class Movable : ScreenObject
	{
        bool passable = false;

		public Movable()
		{

		}

		public Movable(Vector2 position)
		{
			this.position = position;
		}

		protected void Update(Vector2 position, bool day)
		{
            if (!day && Global.offset < this.position)
            {
                passable = true;
            }
            else
            {
                passable = false;
            }

			this.position += position;
		}
	}
}
