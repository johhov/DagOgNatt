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

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Input input;
        private List<Parallax> parallaxLayers;
        private Movable gate;
        private Movable plant;
        private NPC monster;
        private Overlay pulse;
        private Scoreboard score;
        private Scoreboard numbOne;
        private ScreenObject startScreen;
        //private ScreenObject startButton;

        private Texture2D nightOverlay;
        private Song heartbeat;
        private Song dayOne;
        private Song nightOne;
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

            parallaxLayers = new List<Parallax>();
            for (int i = 0; i < 3; i++)
            {
                parallaxLayers.Add(new Parallax(1, i));
            }

            Global.offset = 0;
            Global.day = true;
            Global.gamestart = 0;
            startScreen = new ScreenObject();
            //startButton = new ScreenObject();
            gate = new Movable(new Vector2(7000, 550), false, true, new Rectangle(0, 0, 200, 50));
            plant = new Movable(new Vector2(2340, 550), false, true, new Rectangle(0, 0, 0, 0));
            monster = new NPC(new Vector2(1700, 300), true, false, new Rectangle(0, 0, 327, 360));
            pulse = new Overlay(0, new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0));
            score = new Scoreboard(new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0));
            numbOne = new Scoreboard(new Vector2(5, 5), new Vector2(0, 0), new Vector2(0, 0));

            collidables = new List<Movable>();
            collidables.Add(gate);
            collidables.Add(plant);

            //Menu objects
            menuButtons = new List<Button>();
            menuButtons.Add(new Button(new Vector2(0, 0), "Start Game", Keys.Enter));
            menuButtons.Add(new Button(new Vector2(0, 0), "Exit Game", Keys.Escape));

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

            //parallaxLayers[0].TexturesDay = Content.Load<Texture2D>("Parallax\\City_Background");
            //parallaxLayers[0].TexturesDay = Content.Load<Texture2D>("Parallax\\Forest1_Background");

            //parallaxLayers[1].TexturesDay = Content.Load<Texture2D>("Parallax\\City_middleground");
            //parallaxLayers[1].TexturesDay = Content.Load<Texture2D>("Parallax\\Forground 1");

            //parallaxLayers[2].TexturesDay = Content.Load<Texture2D>("Parallax\\City_construction");
            //parallaxLayers[2].TexturesDay = Content.Load<Texture2D>("Parallax\\Forest1_foreground");

            parallaxLayers[0].TexturesDay = Content.Load<Texture2D>("Parallax\\MyCityBackground");
            parallaxLayers[0].TexturesDay = Content.Load<Texture2D>("Parallax\\Forest1_Background");

            parallaxLayers[1].TexturesDay = Content.Load<Texture2D>("Parallax\\City_construction");
            parallaxLayers[1].TexturesDay = Content.Load<Texture2D>("Parallax\\MyBlank");

            parallaxLayers[2].TexturesDay = Content.Load<Texture2D>("Parallax\\City_foreground");
            parallaxLayers[2].TexturesDay = Content.Load<Texture2D>("Parallax\\Forest1_foreground");

            nightOverlay = Content.Load<Texture2D>("Parallax\\Night_layer");

            //player.Texture = Content.Load<Texture2D>("Player\\Walk0000");
            player.Texture = Content.Load<Texture2D>("Player\\WalkLoopSheet_04");

            //startButton.TextureDay = Content.Load<Texture2D>("Start Game Btn Large size");
            startScreen.TextureDay = Content.Load<Texture2D>("StartScreen");

            player.TextureDie = Content.Load<Texture2D>("Player\\deathAnimation");
            gate.TextureDay = Content.Load<Texture2D>("Gate");
            plant.TextureDay = Content.Load<Texture2D>("Plant");
            monster.TextureDay = Content.Load<Texture2D>("UlvMonsterHode_Spritesheet5x5");
            pulse.TextureDay = Content.Load<Texture2D>("Hjertebank");
            score.TextureDay = Content.Load<Texture2D>("SolUI");
            numbOne.TextureDay = Content.Load<Texture2D>("numbers");
            heartbeat = Content.Load<Song>("Song\\Heartbeat");

            //  dayOne = Content.Load<Song>("Song\\music.full.dawn");
            // nightOne = Content.Load<Song>("Song\\music.full.dusk");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.3f;
            MediaPlayer.Play(heartbeat);
            if (Global.day)
            {
                //	MediaPlayer.Play(dayOne);
            }
            if (!Global.day)
            {
                //	MediaPlayer.Play(nightOne);
            }

            Mouse.WindowHandle = this.Window.Handle;
            mouseTexture = Content.Load<Texture2D>("Cursor_v03");

            // Menu button events
            menuButtons[0].TextureDay = Content.Load<Texture2D>("StartGameButtonSmallSize");
            menuButtons[0].clicked += new Button.EventHandler(ButtonClicked);

            menuButtons[1].TextureDay = Content.Load<Texture2D>("StartGameButtonSmallSize");
            menuButtons[1].clicked += new Button.EventHandler(ButtonClicked);
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

            if (Global.gamestart < 1)
            {
                Global.gamestart = gameTime.TotalGameTime.TotalSeconds;
            }

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
                }

                if (input.IsKeyPressed(Keys.Left))
                {
                    player.Move(new Vector2(-1, 0), collidables);
                }

                if (input.IsKeyPressed(Keys.Right))
                {
                    player.Move(new Vector2(1, 0), collidables);
                }
                if (input.IsKeyPressedOnce(Keys.Space))
                {
                    Global.day = !Global.day;
                    if (Global.day)
                    {
                        //music.dusk.til.dawn
                    }
                    if (Global.day)
                    {
                        //music.dawn.til.dusk
                    }
                }
                if (input.IsKeyPressedOnce(Keys.R))
                {
                    player.Die();
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

                parallaxLayers[0].Update(player);
                parallaxLayers[1].Update(player);
                parallaxLayers[2].Update(player);

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
                if (Global.day)
                {
                    plant.Draw(spriteBatch);
                }

                parallaxLayers[0].Draw(spriteBatch);
                parallaxLayers[1].Draw(spriteBatch);

                gate.Draw(spriteBatch);
                player.Draw(spriteBatch);
                monster.Draw(spriteBatch);
                pulse.Draw(spriteBatch);
                score.Draw(spriteBatch);
                numbOne.Drawfirst(spriteBatch);

                parallaxLayers[2].Draw(spriteBatch);

                if (!Global.day)
                {
                    spriteBatch.Draw(nightOverlay, new Vector2(0, 0), Color.White);
                }
            }

            if (gameState == GameState.End)
            {
                //Draw ending screen
            }
            if (gameState == GameState.Menu)
            {
                startScreen.Draw(spriteBatch);

                //startButton.Draw(spriteBatch);

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