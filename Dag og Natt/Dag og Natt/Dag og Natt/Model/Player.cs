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
		private Texture2D textureDie;
		private Texture2D textureRun;
		private Texture2D textureCan;
		private bool dying;
		private bool advance;
		private bool facingLeft;
		public bool running;
		private bool watercan;

		public Texture2D TextureDie
		{
			get { return textureDie; }
			set
			{
				this.textureDie = value;
			}
		}
		public Texture2D TextureRun
		{
			get { return textureRun; }
			set
			{
				this.textureRun = value;
			}
		}
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

		public Texture2D Texture
		{
			get { return textureDay; }
			set
			{
				this.textureDay = value;
			}
		}

		public Player()
		{
			position = new Vector2(239, 350);
			origin = new Vector2(0, 0);
			center = new Vector2(0, 0);
			speed = 4;
			atEdge = 0;
			boundingBoxLeftEdge = 290;
			boundingBoxRightEdge = 520;
			moveTo = position;
			dying = false;
			moving = true;
			currentAnimation = new Rectangle(0, 0, 300, 300);
			advance = false;
			facingLeft = false;
			running = false;
			watercan = false;
		}

		new public void Update()
		{
			if (moveTo == position)
			{
				moving = false;
			}
			else
			{
				moving = true;
			}

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
			if (direction.X < 0)
			{
				facingLeft = true;
			}
			if (direction.X > 0)
			{
				facingLeft = false;
			}

			foreach (Movable collidable in collidables)
			{
				if (!collidable.Passable)
				{
					if (collidable.Position.X <= (moveTo.X + currentAnimation.Width) && moveTo.X <= (collidable.Position.X + collidable.TextureDay.Width))
					{
						moveTo = position;
					}
				}
			}
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			if (dying)
			{
				spriteBatch.Draw(TextureDie, position, currentAnimation, Color.White);
				if (advance)
				{
					currentAnimation.X += currentAnimation.Width;
					if (currentAnimation.X >= textureDie.Width)
					{
						currentAnimation.X = 0;

						currentAnimation.Y += currentAnimation.Height;
						if (currentAnimation.Y >= textureDie.Height)
						{
							currentAnimation.Y = 0;
							Restart();
						}
					}
				}
				advance = !advance;
			}
			else if (moving)
			{
				if (watercan)
				{
					if (facingLeft)
					{
						spriteBatch.Draw(TextureRun, new Rectangle((int)position.X, (int)position.Y, 300, 300), currentAnimation, Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0.0f);
					}
					if (!facingLeft)
					{
						spriteBatch.Draw(TextureRun, position, currentAnimation, Color.White);
					}

					if (advance)
					{
						currentAnimation.X += currentAnimation.Width;
						if (currentAnimation.X >= textureRun.Width)
						{
							currentAnimation.X = 0;

							currentAnimation.Y += currentAnimation.Height;
							if (currentAnimation.Y >= textureRun.Height)
							{
								currentAnimation.Y = 0;
							}
						}
					}
					advance = !advance;
				}

				else if (running)
				{
					if (facingLeft)
					{
						spriteBatch.Draw(TextureRun, new Rectangle((int)position.X, (int)position.Y, 300, 300), currentAnimation, Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0.0f);
					}
					if (!facingLeft)
					{
						spriteBatch.Draw(TextureRun, position, currentAnimation, Color.White);
					}

					if (advance)
					{
						currentAnimation.X += currentAnimation.Width;
						if (currentAnimation.X >= textureRun.Width)
						{
							currentAnimation.X = 0;

							currentAnimation.Y += currentAnimation.Height;
							if (currentAnimation.Y >= textureRun.Height)
							{
								currentAnimation.Y = 0;
							}
						}
					}
					advance = !advance;
				}
				else
				{
					if (facingLeft)
					{
						spriteBatch.Draw(TextureDay, new Rectangle((int)position.X, (int)position.Y, 300, 300), currentAnimation, Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0.0f);
					}
					if (!facingLeft)
					{
						spriteBatch.Draw(TextureDay, position, currentAnimation, Color.White);
					}

					if (advance)
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
					advance = !advance;
				}
			}

			else
			{
				spriteBatch.Draw(TextureDay, position, currentAnimation, Color.White);
			}
		}

		public void Die()
		{
			dying = true;
			currentAnimation.X = 0;
			currentAnimation.Y = 0;
			currentAnimation.Width = 187;
			currentAnimation.Height = 400;
		}

		public void Restart()
		{
			facingLeft = false;
			position = new Vector2(239, 350);
			moveTo = position;
			dying = false;
			Global.gamestart = 0;
			Global.offset = 1;
			Global.day = true;
			currentAnimation = new Rectangle(0, 0, 300, 300);
		}
		public void Running()
		{
			running = true;
			currentAnimation = new Rectangle(0, 0, 300, 300);
		}
		public bool DayChange(List<Movable> collidables) //should fix so that you can stand close, for now it's a feature
		{
			foreach (Movable collidable in collidables)
			{

				if (collidable.Position.X <= (moveTo.X + currentAnimation.Width) && moveTo.X <= (collidable.Position.X + collidable.TextureDay.Width))
				{
					return false;
				}

			}
			return true;


		}
		public bool DownAction()
		{
			if (Global.offset > 3800 && Global.offset < 4200)
			{
				watercan = true;

			}
			if (Global.offset > 5000 && Global.offset < 6300 && watercan && Global.day)
			{
				watercan = false;
				return true;
			}
			return false;
		}
	}
}