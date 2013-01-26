using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dag_og_Natt
{
    class Movable : ScreenObject
    {
	    public void move(int moveInX, int moveInY)
	    {
		    positionX += moveInX;
		    positionY += moveInY;
	    }



    }
}
