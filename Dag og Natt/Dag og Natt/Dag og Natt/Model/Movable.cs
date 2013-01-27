using Microsoft.Xna.Framework;

namespace Dag_og_Natt
{
    internal class Movable : ScreenObject
    {
        protected bool passableAtDay = true;
        protected bool passableAtNight = true;
        protected bool passable = true;
        protected Vector2 moveTo;

        public bool PassableAtDay
        {
            set { passable = value; }
            get { return passable; }
        }

        public bool PassableAtNight
        {
            set { passable = value; }
            get { return passable; }
        }

        public bool Passable
        {
            get { return passable; }
        }

        public Movable()
        {
        }

        public Movable(Vector2 position, bool passableAtDay, bool passableAtNight, Rectangle currentAnimation)
        {
            this.position = position;
            this.startingPosition = position;
            moveTo = position;
            this.passableAtDay = passableAtDay;
            this.passableAtNight = passableAtNight;
            this.currentAnimation = currentAnimation;
        }

        public void Update()
        {
            if ((passableAtDay && Global.day) || (passableAtNight && !Global.day))
            {
                passable = true;
            }
            else
            {
                passable = false;
            }

            this.position.X = startingPosition.X - Global.offset;
        }

        public void Move(Vector2 direction)
        {
            moveTo = position + direction;
        }
    }
}