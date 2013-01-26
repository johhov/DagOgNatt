using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Dag_og_Natt
{
    internal class Player : Movable
    {
        private int speed;
        private int atEdge;
        public int boundingBoxLeftEdge;
        public int boundingBoxRightEdge;

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

        new public Texture2D Texture
        {
            get { return textureDay; }
            set { 
                this.textureDay = value;
                boundingBoxRightEdge = 810 - textureDay.Width;
            }
        }

        public Player()
        {
            position = new Vector2(490, 350);
            origin = new Vector2(0, 0);
            center = new Vector2(0, 0);
            speed = 4;
            atEdge = 0;
            boundingBoxLeftEdge = 270;
            boundingBoxRightEdge = 810;
            moveTo = position;
        }

        new public void Update()
        {
            position = moveTo;
	        if (Global.day)
	        {
		        speed = 4;
	        }
	        else
	        {
		        speed = 2;
	        }

            if (position.X <= boundingBoxLeftEdge)
            {
                atEdge = -1;
                position.X = boundingBoxLeftEdge + speed;
                moveTo.X = position.X;

                if (Global.offset <= 0)
                {
                    atEdge = 0;
                }
            }
            else if (position.X >= boundingBoxRightEdge)
            {
                atEdge = 1;
                position.X = boundingBoxRightEdge - speed;
                moveTo.X = position.X;
            }
            else
            {
                atEdge = 0;
            }
        }

        public void Move(Vector2 direction, List<Movable> collidables)
        {
            moveTo = position + direction * speed;

            foreach (Movable collidable in collidables)
            {
                if (!collidable.Passable)
                {
                    if (collidable.Position.X <= (moveTo.X+Texture.Width) && moveTo.X <= (collidable.Position.X + collidable.TextureDay.Width))
                    {
                        moveTo = position;
                    }
                }
            }
        }
    }
}