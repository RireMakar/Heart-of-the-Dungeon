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
        private Map map;
        private Knight knight;
        private Thief thief;
        private Mage mage;
        private enum Turn { Dungeon, Knight, Thief, Mage };
        Turn currentTurn;
        private List<Monster> monsterList;
        private KeyboardState oldState;
        private SpriteFont mainFont;
        private int movePoints;

        // constructor
        public GameScreen(Map mp)
        {
            map = mp;
            mainFont = GlobalVariables.mainFont;
            knight = new Knight(GlobalVariables.textureDictionary["knight"], new Rectangle(0, 0, 32, 32), map.WallList);
            thief = new Thief(GlobalVariables.textureDictionary["thief"], new Rectangle(0, 0, 0, 0), map.WallList);
            mage = new Mage(GlobalVariables.textureDictionary["mage"], new Rectangle(0, 0, 0, 0), map.WallList);
            monsterList = new List<Monster>();
            currentTurn = Turn.Knight;
            oldState = Keyboard.GetState();
        }

        // methods
        public override void Update()
        {
            KeyboardState newState = Keyboard.GetState();
            if (oldState.IsKeyUp(Keys.Enter) && newState.IsKeyDown(Keys.Enter))
            {
                this.NextTurn();
            }

            switch (currentTurn)
            {
                case Turn.Dungeon:
                    {
                        
                        break;
                    }
                case Turn.Knight:
                    {
                        if (newState.IsKeyDown(Keys.R) && oldState.IsKeyUp(Keys.R))
                            knight.Roll();
                        if (newState.IsKeyDown(Keys.W) && oldState.IsKeyUp(Keys.W) && knight.MovePoints > 0)
                        {
                            knight.Move(3);
                        }
                        if (newState.IsKeyDown(Keys.D) && oldState.IsKeyUp(Keys.D) && knight.MovePoints > 0)
                        {
                            knight.Move(0);
                        }
                        if (newState.IsKeyDown(Keys.S) && oldState.IsKeyUp(Keys.S) && knight.MovePoints > 0)
                        {
                            knight.Move(1);
                        }
                        if (newState.IsKeyDown(Keys.A) && oldState.IsKeyUp(Keys.A) && knight.MovePoints > 0)
                        {
                            knight.Move(2);
                        }
                        movePoints = knight.MovePoints;
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

            oldState = newState;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch);
            knight.Draw(spriteBatch);
            thief.Draw(spriteBatch);
            mage.Draw(spriteBatch);
            foreach (Monster m in monsterList)
            {
                m.Draw(spriteBatch);
            }
            spriteBatch.DrawString(mainFont, "Move Points: " + movePoints, new Vector2(32, 32), Color.White);
        }

        private void NextTurn()
        {
            switch(currentTurn)
            {
                case Turn.Dungeon:
                    {
                        currentTurn = Turn.Knight;
                        break;
                    }
                case Turn.Knight:
                    {
                        currentTurn = Turn.Thief;
                        break;
                    }
                case Turn.Thief:
                    {
                        currentTurn = Turn.Mage;
                        break;
                    }
                case Turn.Mage:
                    {
                        currentTurn = Turn.Dungeon;
                        break;
                    }
            }
        }
    }
}
