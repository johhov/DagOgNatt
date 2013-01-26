using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
	internal class Movable : ScreenObject
	{
        bool passable = false;
        protected Vector2 moveTo;

        public bool Passable
        {
            set { passable = value; }
            get { return passable; }
        }

		public Movable()
		{
            
		}

		public Movable(Vector2 position)
		{
			this.position = position;
            moveTo = position;
		}

		public void Update()
		{
            if (!Global.day /*&& Global.offset < this.position*/)
            {
                passable = true;
            }
            else
            {
                passable = false;
            }

			this.position = moveTo;
		}

        public void Move(Vector2 direction)
        {
            moveTo = position + direction;
        }
	}
}
