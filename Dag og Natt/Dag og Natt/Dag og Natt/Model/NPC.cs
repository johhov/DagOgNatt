using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
    internal class NPC : Movable
    {
        private int objectOffset;

        new public void Update()
        {
            if (Global.offset >= 800 && !Global.day)
            {
                objectOffset -= 2;
            }

            if ((passableAtDay && Global.day) || (passableAtNight && !Global.day))
            {
                passable = true;
            }
            else
            {
                passable = false;
            }

            this.position.X = startingPosition.X - Global.offset + objectOffset;
        }

        public NPC(Vector2 position, bool passableAtDay, bool passableAtNight, Rectangle currentAnimation)
            : base(position, passableAtDay, passableAtNight, currentAnimation)
        {
            objectOffset = 0;
        }
	public void Draw(SpriteBatch spriteBatch)
	{
		spriteBatch.Draw(TextureDay, position, currentAnimation, Color.White);
			//if (advance)
			{
				currentAnimation.X += currentAnimation.Width;
				if (currentAnimation.X >= textureDay.Width)
				{
					currentAnimation.X = 0;

					currentAnimation.Y += currentAnimation.Height;
					if (currentAnimation.Y >= textureDay.Height)
					{
						currentAnimation.Y = 0;
					}

				}
			}
			//advance = !advance;


	}

    }
}