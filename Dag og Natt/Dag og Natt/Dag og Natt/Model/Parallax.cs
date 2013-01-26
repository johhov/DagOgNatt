using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
    class Parallax : Movable
    {
        public Parallax()
        {

        }

        public void Update(Player player)
        {
            if (player.AtEdge != 0)
            {
                position += new Vector2(player.Speed*-player.AtEdge,0);
            }
        }
    }
}
