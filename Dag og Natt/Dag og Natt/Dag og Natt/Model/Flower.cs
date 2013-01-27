using Microsoft.Xna.Framework;


namespace Dag_og_Natt 
{
	class Flower : Movable
	{
		public bool watered;

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
	if (watered && !Global.day)
		{
		textureDay = TextureNight;
		}

            this.position.X = startingPosition.X - Global.offset;
		}
		public Flower(Vector2 position, bool passableAtDay, bool passableAtNight, Rectangle currentAnimation)
		: base(position, passableAtDay, passableAtNight, currentAnimation)
		{
			watered = false;
		}
	}
}
