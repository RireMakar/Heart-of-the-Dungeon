#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Heart_of_the_Dungeon
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        #region Attributes
        // attributes
        
        Stack<GameState> gameStates;
        // misc
        Random rand;
        #endregion Attributes

        // temp attributes (for testing, delete when done)


        #region Constructor
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        #endregion Constructor

        #region OneTimeMethods
        protected override void Initialize()
        {
            GlobalVariables.IsFullscreen = false;
            GlobalVariables.ScreenHeight = 768;
            GlobalVariables.ScreenWidth = 1024;


            graphics.PreferredBackBufferWidth = GlobalVariables.ScreenWidth;
            graphics.PreferredBackBufferHeight = GlobalVariables.ScreenHeight;
            graphics.IsFullScreen = GlobalVariables.IsFullscreen;
            graphics.ApplyChanges();

            IsMouseVisible = true;

            rand = new Random();

            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D creep = Content.Load<Texture2D>("Creep");
            Texture2D ghoul = Content.Load<Texture2D>("Ghoul");
            Texture2D skarch = Content.Load<Texture2D>("Skarch");
            Texture2D scorp = Content.Load<Texture2D>("Scorp");
            Texture2D minotaur = Content.Load<Texture2D>("Minotaur");
            Texture2D knight = Content.Load<Texture2D>("Knight");
            Texture2D mage = Content.Load<Texture2D>("Mage");
            Texture2D thief = Content.Load<Texture2D>("Thief");
            Texture2D floortiles = Content.Load<Texture2D>("floortiles");
            Texture2D walltiles = Content.Load<Texture2D>("walltiles");
            Texture2D background = Content.Load<Texture2D>("background");
            Texture2D spawn = Content.Load<Texture2D>("spawn");
            Texture2D enemySpawn = Content.Load<Texture2D>("enemySpawn");
            Texture2D heart = Content.Load<Texture2D>("heart");

            SpriteFont mainFont = Content.Load<SpriteFont>("mainFont");

            GlobalVariables.fontDictionary = new Dictionary<string, SpriteFont>();
            GlobalVariables.fontDictionary.Add("mainFont", mainFont);            

            GlobalVariables.textureDictionary = new Dictionary<string, Texture2D>();
            GlobalVariables.textureDictionary.Add("creep", creep);
            GlobalVariables.textureDictionary.Add("ghoul", ghoul);
            GlobalVariables.textureDictionary.Add("skarch", skarch);
            GlobalVariables.textureDictionary.Add("scorp", scorp);
            GlobalVariables.textureDictionary.Add("minotaur", minotaur);
            GlobalVariables.textureDictionary.Add("knight", knight);
            GlobalVariables.textureDictionary.Add("mage", mage);
            GlobalVariables.textureDictionary.Add("thief", thief);
            GlobalVariables.textureDictionary.Add("floortiles", floortiles);
            GlobalVariables.textureDictionary.Add("walltiles", walltiles);
            GlobalVariables.textureDictionary.Add("spawn", spawn);
            GlobalVariables.textureDictionary.Add("enemySpawn", enemySpawn);
            GlobalVariables.textureDictionary.Add("heart", heart);

            MapHandler mapHandler = new MapHandler();
            mapHandler.LoadMap("Maps\\Map01.txt");

            gameStates = new Stack<GameState>();

            gameStates.Push(new GameScreen(mapHandler, 0));
        }

        protected override void UnloadContent()
        {
            
        }
        #endregion OneTimeMethods

        #region GameloopMethods
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            gameStates.Peek().Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            // spriteBatch.Draw(background, new Rectangle(0, 0, GlobalSettings.ScreenWidth, GlobalSettings.ScreenHeight), Color.White);  **NEEDS ACTUAL BACKGROUND**
            gameStates.Peek().Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion GameloopMethods
    }
}
