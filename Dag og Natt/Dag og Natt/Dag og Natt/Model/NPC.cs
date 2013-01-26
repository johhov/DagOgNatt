using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dag_og_Natt
{
	class NPC : Movable
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
		public NPC(Vector2 position, bool passableAtDay, bool passableAtNight) : base(position, passableAtDay, passableAtNight)
		{
			objectOffset = 0;
		}
	}
}
