namespace Dag_og_Natt
{
    internal class ScreenObject
    {
	    protected int positionX;
	    protected int positionY;
	    protected int origin;
	    protected int center;
	    protected Texture2D texture;

	    public void draw(SpriteBatch spriteBatch)
	    {
		    spriteBatch.Draw(texture, new Vector2(positionX, positionY), Color.White);
	    }
	   

    }
}
