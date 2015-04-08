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
        private string state;

        // constructor
        public GameScreen(Map mp)
        {
            map = mp;
            mainFont = GlobalVariables.mainFont;
            knight = new Knight(GlobalVariables.textureDictionary["knight"], new Rectangle(25 * 32, 12 * 32, 32, 32), map.WallList);
            thief = new Thief(GlobalVariables.textureDictionary["thief"], new Rectangle(25 * 32, 11 * 32, 32, 32), map.WallList);
            mage = new Mage(GlobalVariables.textureDictionary["mage"], new Rectangle(25 * 32, 10 * 32, 32, 32), map.WallList);
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
                        knight.Update(newState, oldState);
                        movePoints = knight.MovePoints;
                        state = knight.GetState();
                        if (movePoints == 0)
                            this.NextTurn();
                        break;
                    }
                case Turn.Thief:
                    {
                        thief.Update(newState, oldState);
                        movePoints = thief.MovePoints;
                        state = thief.GetState();
                        if (movePoints == 0)
                            this.NextTurn();
                        break;
                    }
                case Turn.Mage:
                    {
                        mage.Update(newState, oldState);
                        movePoints = mage.MovePoints;
                        state = mage.GetState();
                        if (movePoints == 0)
                            this.NextTurn();
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
            spriteBatch.DrawString(mainFont, "Move Points: " + movePoints + "   State: " + state, new Vector2(32, 32), Color.White);
        }

        private void NextTurn()
        {
            switch(currentTurn)
            {
                case Turn.Dungeon:
                    {
                        currentTurn = Turn.Knight;
                        knight.MovePoints = 0;
                        break;
                    }
                case Turn.Knight:
                    {
                        currentTurn = Turn.Thief;
                        thief.MovePoints = 0;
                        break;
                    }
                case Turn.Thief:
                    {
                        currentTurn = Turn.Mage;
                        mage.MovePoints = 0;
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
