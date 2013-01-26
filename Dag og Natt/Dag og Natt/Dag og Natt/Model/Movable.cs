namespace Dag_og_Natt
{
    internal class Movable : ScreenObject
    {
	    public void move(int moveInX, int moveInY)
	    {
		    positionX += moveInX;
		    positionY += moveInY;
	    }



    }
}
