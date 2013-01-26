namespace Dag_og_Natt
{
    internal class Player : Movable
    {
	    public void moveLeft()
	    {
		    move(-1, 0);		
	    }

	    public void moveRight()
	    {
		    move(1, 0);
	    }

	    public void jump()//WORK IN PROGRESS
	    {
		    move(0, -1);
	    }
    }
}
