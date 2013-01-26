using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
    class Parallax : Movable
    {
        public void Update(Player player)
        {
            if (player.atEdge)
            {
                position += player.speed;
            }
        }
    }
}
