using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Dag_og_Natt
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		public enum GameState
		{
			Menu,
			Running,
			End
		}

		public static GameState gameState;
		public int gameStateNumber;

		
		private const int MENUBUTTONOFFSET_X = 200;

		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;
		private Input input;
		private List<Parallax> parallaxLayersSuburb;
		private Movable gate;
		private Movable plant;
		private NPC monster;
		private Overlay pulse;
	private Scoreboard score;
	private Scoreboard numbOne;
	

		private Texture2D testNightOverlay;
		private Song heartbeat;
		private Song dayOne;
		private List<Movable> collidables;
		private List<Button> menuButtons;
		private Vector2 mousePosition;
		private Texture2D mouseTexture;

		private Player player;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";

			graphics.PreferredBackBufferHeight = Global.WINDOWHEIGHT;
			graphics.PreferredBackBufferWidth = Global.WINDOWWIDTH;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			gameState = GameState.Menu;

			//Game objects
			input = new Input();
			player = new Player();
			
			parallaxLayersSuburb = new List<Parallax>();
			for (int i = 2; i >= 0; i--)
			{
				parallaxLayersSuburb.Add(new Parallax(1/*(float)(0.5+(0.5*i))*/));
			}
				

			Global.offset = 0;
			Global.day = true;
			
			gate = new Movable(new Vector2(1000, 550), false, true);
			plant = new Movable(new Vector2(700, 550), false, true);
		monster = new NPC(new Vector2(1700, 550), true, false);
		pulse = new Overlay(0, new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0));
	    score = new Scoreboard(new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0));
	    numbOne = new Scoreboard(new Vector2(5, 5), new Vector2(0, 0), new Vector2(0, 0));
	    
			collidables = new List<Movable>();
			collidables.Add(gate);
			collidables.Add(plant);

			//Manu objects
			menuButtons = new List<Button>();
			menuButtons.Add(new Button(new Vector2(100, 100), "Start Game", Keys.Enter));
			menuButtons.Add(new Button(new Vector2(100, 300), "Exit Game", Keys.Escape));

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
			parallaxLayersSuburb[0].TexturesDay = Content.Load<Texture2D>("Parallax\\Floor line");
            parallaxLayersSuburb[0].TexturesDay = Content.Load<Texture2D>("Parallax\\City_excavator");
			parallaxLayersSuburb[1].TexturesDay = Content.Load<Texture2D>("Parallax\\Forground 1");
            parallaxLayersSuburb[1].TexturesDay = Content.Load<Texture2D>("Parallax\\City_road_first_row");
			parallaxLayersSuburb[2].TexturesDay = Content.Load<Texture2D>("Parallax\\Background 2");
            parallaxLayersSuburb[2].TexturesDay = Content.Load<Texture2D>("Parallax\\City_second_row");
			
			testNightOverlay = Content.Load<Texture2D>("TestNightOverlay");
			player.Texture = Content.Load<Texture2D>("Player\\TestGray");
			gate.TextureDay = Content.Load<Texture2D>("Gate");
			plant.TextureDay = Content.Load<Texture2D>("Plant");
		    monster.TextureDay = Content.Load<Texture2D>("Monster");
		    pulse.TextureDay = Content.Load<Texture2D>("Hjertebank");
	    score.TextureDay = Content.Load<Texture2D>("SolUI");
	    numbOne.TextureDay = Content.Load<Texture2D>("numbers");
	    heartbeat = Content.Load<Song>("Song\\Heartbeat");
	//	dayOne = Content.Load<Song>("Song\\
			MediaPlayer.IsRepeating = true;
			MediaPlayer.Volume = 0.3f;
			MediaPlayer.Play(heartbeat);
	

			Mouse.WindowHandle = this.Window.Handle;
			mouseTexture = Content.Load<Texture2D>("Mouse");

			// Menu button events
			foreach (Button button in menuButtons)
			{
				button.TextureDay = Content.Load<Texture2D>("Gate");
				button.clicked += new Button.EventHandler(ButtonClicked);
			}
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

			if (gameState == GameState.Menu)
			{
				foreach (Button button in menuButtons)
				{
					button.Update();
				}
			}
			else if (gameState == GameState.Running)
			{
				if (input.IsKeyPressedOnce(Keys.Escape))
				{
					gameState = GameState.Menu;
				}

				if (input.IsKeyPressedOnce(Keys.LeftControl))
				{
					Global.day = !Global.day;
				}

				if (input.IsKeyPressed(Keys.Left))
				{
					player.Move(new Vector2(-1, 0), collidables);
				}

				if (input.IsKeyPressed(Keys.Right))
				{
					player.Move(new Vector2(1, 0), collidables);
				}

				plant.Update();
		gate.Update();
		plant.Update();
		monster.Update();
				player.Update();
		pulse.Update(gameTime);
	    score.Update(gameTime);
	    numbOne.Update(gameTime);

				Global.offset += player.Speed * player.AtEdge;

				for (int i = (parallaxLayersSuburb.Count-1); i >= 0; i--)
				{
					parallaxLayersSuburb[i].Update(player);
				}

				//Character
			}

			mousePosition.X = Mouse.GetState().X;
			mousePosition.Y = Mouse.GetState().Y;

			base.Update(gameTime);
		}



		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.White);
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);//punches graphics at .end and allows alpha

           

			if (gameState == GameState.Running)
			{
				foreach (Parallax layer in parallaxLayersSuburb)
				{
					layer.Draw(spriteBatch);
				}

				gate.Draw(spriteBatch);

				if (Global.day)
				{
					plant.Draw(spriteBatch);
				}

				player.Draw(spriteBatch);
		monster.Draw(spriteBatch);
		pulse.Draw(spriteBatch);
		score.Draw(spriteBatch);
		numbOne.Drawfirst(spriteBatch);

				if (!Global.day)
				{
					spriteBatch.Draw(testNightOverlay, new Vector2(0, 0), Color.White);
				}
			}


		
	    if (gameState == GameState.End)
			{ 
				//Draw ending screen
			}
	    if (gameState == GameState.Menu)
            {
                foreach (Button button in menuButtons)
                {
                    button.Draw(spriteBatch);
                }
            }

			spriteBatch.Draw(mouseTexture, mousePosition, new Color(255, 255, 255, 255));
			spriteBatch.End();
			base.Draw(gameTime);
		}

		/// <summary>
		/// Is triggered by the user clicking on a button. The action string then tells it what to do.
		/// </summary>
		private void ButtonClicked(string actionType)
		{
			switch (actionType)
			{
				case "Start Game":
					gameState = GameState.Running;
					break;
				case "Exit Game":
					this.Exit();
					break;
				default:
					break;
			}
		}

	}
}