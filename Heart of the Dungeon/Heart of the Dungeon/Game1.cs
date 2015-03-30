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
        List<Map> mapList;
        List<MoveableGamePiece> moveableGamePieceList;
        List<Hero> heroList;
        List<Monster> monsterList;
        public Texture2D creep;
        public Texture2D ghoul;
        public Texture2D skarch;
        public Texture2D scorp;
        public Texture2D minotaur;
        public Texture2D knight;
        public Texture2D mage;
        public Texture2D thief;
        public Texture2D floortiles;
        public Texture2D walltiles;
        public Texture2D background;
        Random rand;
        DrawGame drawGame;
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
            GlobalSettings.IsFullscreen = false;
            GlobalSettings.ScreenHeight = 768;
            GlobalSettings.ScreenWidth = 1024;


            graphics.PreferredBackBufferWidth = GlobalSettings.ScreenWidth;
            graphics.PreferredBackBufferHeight = GlobalSettings.ScreenHeight;
            graphics.IsFullScreen = GlobalSettings.IsFullscreen;
            graphics.ApplyChanges();

            IsMouseVisible = true;

            rand = new Random();

            mapList = new List<Map>();
            moveableGamePieceList = new List<MoveableGamePiece>();
            heroList = new List<Hero>();
            monsterList = new List<Monster>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            creep = Content.Load<Texture2D>("Creep");
            ghoul = Content.Load<Texture2D>("Ghoul");
            skarch = Content.Load<Texture2D>("Skarch");
            scorp = Content.Load<Texture2D>("Scorp");
            minotaur = Content.Load<Texture2D>("Minotaur");
            knight = Content.Load<Texture2D>("Knight");
            mage = Content.Load<Texture2D>("Mage");
            thief = Content.Load<Texture2D>("Thief");
            floortiles = Content.Load<Texture2D>("floortiles");
            walltiles = Content.Load<Texture2D>("walltiles");
            background = Content.Load<Texture2D>("background");

            MapHandler mapHandler = new MapHandler(floortiles, walltiles);
            mapHandler.LoadMap("Maps\\Map01.txt");
            mapList.Add(mapHandler.MapList[0]);
            

            drawGame = new DrawGame(mapList, moveableGamePieceList);
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


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            //spriteBatch.Draw(background, new Rectangle(0, 0, GlobalSettings.ScreenWidth, GlobalSettings.ScreenHeight), Color.White);  **NEEDS ACTUAL BACKGROUND**
            drawGame.DrawMap(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion GameloopMethods
    }
}
