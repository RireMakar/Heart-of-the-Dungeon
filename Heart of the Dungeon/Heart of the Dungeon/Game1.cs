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
        private List<Map> mapList;
        private Stack<GameState> stateStack;

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
        #endregion Constructorw

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

            mapList = new List<Map>();

            stateStack = new Stack<GameState>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            GlobalVariables.textureDictionary = new Dictionary<string, Texture2D>();

            GlobalVariables.mainFont = Content.Load<SpriteFont>("mainFont");

            GlobalVariables.textureDictionary.Add("creep", Content.Load<Texture2D>("Creep"));
            GlobalVariables.textureDictionary.Add("ghoul", Content.Load<Texture2D>("Ghoul"));
            GlobalVariables.textureDictionary.Add("skarch", Content.Load<Texture2D>("Skarch"));
            GlobalVariables.textureDictionary.Add("scorp", Content.Load<Texture2D>("Scorp"));
            GlobalVariables.textureDictionary.Add("minotaur", Content.Load<Texture2D>("Minotaur"));
            GlobalVariables.textureDictionary.Add("knight", Content.Load<Texture2D>("Knight"));
            GlobalVariables.textureDictionary.Add("mage", Content.Load<Texture2D>("Mage"));
            GlobalVariables.textureDictionary.Add("thief", Content.Load<Texture2D>("Thief"));
            GlobalVariables.textureDictionary.Add("floortiles", Content.Load<Texture2D>("floortiles"));
            GlobalVariables.textureDictionary.Add("walltiles", Content.Load<Texture2D>("wallTiles"));
            GlobalVariables.textureDictionary.Add("background", Content.Load<Texture2D>("background"));
            GlobalVariables.textureDictionary.Add("targetImage", Content.Load<Texture2D>("targetImage"));
            GlobalVariables.textureDictionary.Add("spawnSpace", Content.Load<Texture2D>("spawnSpace"));
            GlobalVariables.textureDictionary.Add("dungeonImage", Content.Load<Texture2D>("dungeonImage"));

            MapHandler mapHandler = new MapHandler();
            mapHandler.LoadMap("Maps\\Map01.txt");
            mapList.Add(mapHandler.MapList[0]);
            stateStack.Push(new GameScreen(mapList[0]));
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

            stateStack.Peek().Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            stateStack.Peek().Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion GameloopMethods
    }
}
