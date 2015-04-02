using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heart_of_the_Dungeon
{
    class GameScreen : GameState
    {
        // attributes
        private List<Map> mapList;
        private List<MoveableGamePiece> moveableGamePieceList;
        private List<Hero> heroList;
        private List<Monster> monsterList;
        private DrawGame drawGame;
        private MapHandler mapHandler;
        private enum Turn { Dungeon, Knight, Thief, Mage }
        private Turn currentTurn;
        private Random rand;
        private KeyboardState oldState;
        private MouseState oldMouseState;
        private int map;
        private SpriteFont mainFont;

        public GameScreen(MapHandler mH, int mp)
        {
            mainFont = GlobalVariables.fontDictionary["mainFont"];
            rand = new Random();
            map = mp;
            GlobalVariables.monsterCostDictionary = new Dictionary<string, int>();
            mapList = new List<Map>();
            moveableGamePieceList = new List<MoveableGamePiece>();
            heroList = new List<Hero>();
            monsterList = new List<Monster>();
            Texture2D floortiles = GlobalVariables.textureDictionary["floortiles"];
            Texture2D walltiles = GlobalVariables.textureDictionary["walltiles"];
            mapHandler = mH;            
            mapList.Add(mapHandler.MapList[map]);
            drawGame = new DrawGame(mapList, moveableGamePieceList);
            currentTurn = Turn.Knight;
            oldState = Keyboard.GetState();
            oldMouseState = Mouse.GetState();
            Knight knight = new Knight(GlobalVariables.textureDictionary["knight"], new Rectangle(0,0,32,32));
            Thief thief = new Thief(GlobalVariables.textureDictionary["thief"], new Rectangle(0,0,32,32));
            Mage mage = new Mage(GlobalVariables.textureDictionary["mage"], new Rectangle(0,0,32,32));
            heroList.Add(knight);
            heroList.Add(thief);
            heroList.Add(mage);
        }

        public override void Update()
        {
            KeyboardState newState = Keyboard.GetState();
            MouseState newMouseState = Mouse.GetState();
            switch (currentTurn)
            {
                case Turn.Dungeon:
                    {

                        break;
                    }
                case Turn.Knight:
                    {
                        if (heroList[0].IsFirstTurn)
                        {

                            
                        }
                        break;
                    }
                case Turn.Thief:
                    {

                        break;
                    }
                case Turn.Mage:
                    {

                        break;
                    }
            }
            if (newState.IsKeyDown(Keys.Enter) && oldState.IsKeyUp(Keys.Enter))
                this.NextTurn();
            oldState = newState;
            oldMouseState = newMouseState;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            mapList[0].Draw(spriteBatch);
            foreach (Hero h in heroList)
                h.Draw(spriteBatch);
            foreach (Monster m in monsterList)
                m.Draw(spriteBatch);
            switch (currentTurn)
            {
                case Turn.Dungeon:
                    {
                        spriteBatch.DrawString(mainFont, "Turn: Dungeon", new Vector2(32, 32), Color.White);
                        break;
                    }
                case Turn.Knight:
                    {
                        spriteBatch.DrawString(mainFont, "Turn: Knight", new Vector2(32, 32), Color.White);
                        break;
                    }
                case Turn.Thief:
                    {
                        spriteBatch.DrawString(mainFont, "Turn: Thief", new Vector2(32, 32), Color.White);
                        break;
                    }
                case Turn.Mage:
                    {
                        spriteBatch.DrawString(mainFont, "Turn: Mage", new Vector2(32, 32), Color.White);
                        break;
                    }
            }
        }

        public void NextTurn()
        {
            switch (currentTurn)
            {
                case Turn.Dungeon:
                    {
                        currentTurn = Turn.Knight;
                        startTurn(heroList[0]);
                        break;
                    }
                case Turn.Knight:
                    {
                        currentTurn = Turn.Thief;
                        startTurn(heroList[1]);
                        break;
                    }
                case Turn.Thief:
                    {
                        currentTurn = Turn.Mage;
                        startTurn(heroList[2]);
                        break;
                    }
                case Turn.Mage:
                    {
                        currentTurn = Turn.Dungeon;
                        break;
                    }
            }
        }

        public void startTurn(Hero hero)
        {
            hero.ResetStats();
            hero.MovePoints = rand.Next(1, 7);
        }

        
    }
}
