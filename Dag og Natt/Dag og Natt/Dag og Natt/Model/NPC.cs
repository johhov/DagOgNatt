using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
	internal class NPC : Movable
	{
		private int objectOffset;

		public void Update(Player player)
		{
			if (Global.offset >= 8000 && !Global.day)
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
			if (player.position.X >= position.X - 300)
			{
				if (!player.Dying)
				{
					player.Die();
				}
			}
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