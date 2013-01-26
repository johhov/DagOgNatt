using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
	class Overlay : ScreenObject
	{
		private int alpha;

		public int Alpha
		{
			set { alpha = value; }
			get { return alpha; }
		}
		public Overlay(int alpha, Vector2 position, Vector2 origin, Vector2 center)
		{
			this.alpha = alpha;
			this.position = position;
			startingPosition = position;
			this.origin = origin;
			this.center = origin;
		}

		public void Update(GameTime gameTime)
		{
			if (gameTime.TotalGameTime.Seconds >= 5)
			{
				alpha = 255 -(gameTime.TotalGameTime.Milliseconds %1000);
			}

		}
		
		public void Draw(SpriteBatch spriteBatch)
		{
			if (alpha > 0)
			{
				spriteBatch.Draw(texture, position, null, new Color(255, 255, 255, alpha));
			}
		}
	}
}
