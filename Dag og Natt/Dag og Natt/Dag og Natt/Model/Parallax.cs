using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
    internal class Parallax : Movable
    {
        private float speed;
        private int playerBoundingBoxLeft;
        private int playerBoundingBoxRight;

        private List<Texture2D> texturesDay;
        private List<Texture2D> texturesNight;

        public Texture2D TexturesDay
        {
            set { this.texturesDay.Add(value); }
        }

        public Texture2D TexturesNight
        {
            set { this.texturesNight.Add(value); }
        }

        public Parallax(float speed)
        {
            this.speed = speed;
            this.position = new Vector2(0, 0);
            texturesDay = new List<Texture2D>();
            texturesNight = new List<Texture2D>();
        }

        public void Update(Player player)
        {
            if (player.AtEdge != 0)
            {
                position = new Vector2(-Global.offset * speed, 0);
            }

            playerBoundingBoxLeft = player.boundingBoxLeftEdge;
            playerBoundingBoxRight = player.boundingBoxRightEdge;
        }

        new public void Draw(SpriteBatch spriteBatch)
        {
            if (position.X + texturesDay[0].Width < Global.WINDOWWIDTH)
            {
                spriteBatch.Draw(texturesDay[1], new Vector2(position.X + texturesDay[0].Width, 0), Color.White);
                spriteBatch.Draw(texturesDay[0], position, Color.White);
            }
            else
            {
                spriteBatch.Draw(texturesDay[0], position, Color.White);
            }
        }
    }
}