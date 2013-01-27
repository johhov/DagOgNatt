using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
    internal class Scoreboard : ScreenObject
    {
        private int timeLeft;
        private int timestart;

        public Scoreboard(Vector2 position, Vector2 origin, Vector2 center)
        {
            this.position = position;
            startingPosition = position;
            this.origin = origin;
            this.center = origin;
        }

        public void Update(GameTime gameTime)
        {
            timeLeft = (int)(90 - gameTime.TotalGameTime.TotalSeconds + Global.gamestart);//not actually working, should use game start time as a saved variable.
        }

        public void Drawfirst(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureDay, position, new Rectangle((timeLeft / 10 * 20), 0, 20, 20), Color.White);
            spriteBatch.Draw(textureDay, new Vector2(position.X + 20, position.Y), new Rectangle((timeLeft % 10 * 20), 0, 20, 20), Color.White);
        }
    }
}