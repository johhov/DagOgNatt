using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dag_og_Natt
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		private const int WINDOWHEIGHT = 720;
		private const int WINDOWWIDTH = 1080;

		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private Input input;
		private Parallax paraLayerOne;
		private Movable gate;
		private Movable plant;
		private Texture2D testNightOverlay;

        private List<Movable> collidables;
        
	    private Player player;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			graphics.PreferredBackBufferHeight = WINDOWHEIGHT;
			graphics.PreferredBackBufferWidth = WINDOWWIDTH;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			input = new Input();
			player = new Player();
			paraLayerOne = new Parallax();
			Global.offset = 0;
			gate = new Movable(new Vector2(700, 550));
			plant = new Movable(new Vector2(300, 550));
			Global.day = true;


            collidables = new List<Movable>();
			collidables.Add(gate);

			base.Initialize();//should be bottom	   
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
			paraLayerOne.Texture = Content.Load<Texture2D>("Parallax\\TestWhite");
			testNightOverlay = Content.Load<Texture2D>("TestNightOverlay");
			player.Texture = Content.Load<Texture2D>("Player\\TestGray");
			gate.Texture = Content.Load<Texture2D>("Gate");
			plant.Texture = Content.Load<Texture2D>("Plant");
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			//Input
			input.Update();

			if (input.IsKeyPressedOnce(Keys.Escape))
			{
				this.Exit();
			}

			if (input.IsKeyPressedOnce(Keys.LeftControl))
			{
                Global.day = !Global.day;
			}

			if (input.IsKeyPressed(Keys.Left))
			{
				player.Move(new Vector2(-1,0), collidables); 
			}

			if (input.IsKeyPressed(Keys.Right))
			{
				player.Move(new Vector2(1, 0), collidables);
			}



            gate.Update();
			player.Update();

			Global.offset += player.Speed * player.AtEdge;

			paraLayerOne.Update(player);

			//Character

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin();

			paraLayerOne.Draw(spriteBatch);

			gate.Draw(spriteBatch);

			if (Global.day)
			{
				plant.Draw(spriteBatch);
			}

            player.Draw(spriteBatch);

            if (!Global.day)
			{
				spriteBatch.Draw(testNightOverlay, new Vector2(0, 0), Color.White);
			}

			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}