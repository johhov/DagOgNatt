﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Dag_og_Natt
{
    class ScreenObject
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
