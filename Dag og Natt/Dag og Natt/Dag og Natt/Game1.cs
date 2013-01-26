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

        private Texture2D backgroundTestWhite;
        private Texture2D backgroundTestBlack;

        private bool day;

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

            day = true;

            base.Initialize();

	    player = new Player();
	   
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundTestWhite = Content.Load<Texture2D>("Parallax\\TestWhite");
            backgroundTestBlack = Content.Load<Texture2D>("Parallax\\TestBlack");
	    player.texture = Content.Load<Texture2D>("Player\\TestGray");
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
                day = !day;
            }

	    if (input.IsKeyPressed(Keys.Left))
	    {
		    player.MoveLeft(); 
	    }
	    if (input.IsKeyPressed(Keys.Right))
	    {
		    player.MoveRight();
	    }


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

            if (day)
            {
                spriteBatch.Draw(backgroundTestWhite, new Vector2(0, 0), Color.White);
            }
            else
            {
                spriteBatch.Draw(backgroundTestBlack, new Vector2(0, 0), Color.White);
            }

	    player.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}