using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
    internal class Parallax : Movable
    {
        public Parallax()
        {
        }

        public void Update(Player player)
        {
            if (player.AtEdge != 0)
            {
                position = new Vector2(-Global.offset, 0);
            }
        }

        new public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White); 
        }
    }
}