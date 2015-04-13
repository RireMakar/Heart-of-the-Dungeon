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
        private Dungeon dungeon;
        private enum Turn { Dungeon, Knight, Thief, Mage };
        Turn currentTurn;
        private List<Monster> monsterList;
        private List<Hero> heroList;
        private KeyboardState oldState;
        private SpriteFont mainFont;
        private int movePoints;
        private string state;
        private int activeMonsterID;
        private List<Wall> wallList;

        // properties
        public List<Monster> MonsterList
        {
            get { return monsterList; }
        }
        public List<Hero> HeroList
        {
            get { return heroList; }
        }
        public List<Wall> WallList
        {
            get { return wallList; }
        }

        // constructor
        public GameScreen(Map mp)
        {
            map = mp;
            wallList = map.WallList;
            mainFont = GlobalVariables.mainFont;
            knight = new Knight(GlobalVariables.textureDictionary["knight"], new Rectangle(25 * 32, 12 * 32, 32, 32), this);
            thief = new Thief(GlobalVariables.textureDictionary["thief"], new Rectangle(25 * 32, 11 * 32, 32, 32), this);
            mage = new Mage(GlobalVariables.textureDictionary["mage"], new Rectangle(25 * 32, 10 * 32, 32, 32), this);
            dungeon = new Dungeon(this);
            monsterList = new List<Monster>();
            heroList = new List<Hero>();
            heroList.Add(knight);
            heroList.Add(thief);
            heroList.Add(mage);
            currentTurn = Turn.Dungeon;
            oldState = Keyboard.GetState();
            activeMonsterID = 0;
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
                        if (oldState.IsKeyUp(Keys.Q) && newState.IsKeyDown(Keys.Q))
                        {
                            activeMonsterID--;
                            if (activeMonsterID < 0)
                                activeMonsterID = monsterList.Count;
                        }                            
                        if (oldState.IsKeyUp(Keys.E) && newState.IsKeyDown(Keys.E))
                        {
                            activeMonsterID++;
                            if (activeMonsterID >= monsterList.Count)
                                activeMonsterID = 0;
                        }                            
                        break;
                    }
                case Turn.Knight:
                    {
                        knight.Update(newState, oldState);
                        movePoints = knight.MovePoints;
                        state = knight.GetState();
                        break;
                    }
                case Turn.Thief:
                    {
                        thief.Update(newState, oldState);
                        movePoints = thief.MovePoints;
                        state = thief.GetState();
                        break;
                    }
                case Turn.Mage:
                    {
                        mage.Update(newState, oldState);
                        movePoints = mage.MovePoints;
                        state = mage.GetState();
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
            dungeon.Draw(spriteBatch);
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
                        knight.Roll();
                        break;
                    }
                case Turn.Knight:
                    {
                        knight.CurrentState = Hero.State.Move; 
                        knight.CurrentAttackState = Hero.AttackState.Inactive;
                        knight.Attack();
                        currentTurn = Turn.Thief;
                        thief.MovePoints = 0;
                        thief.Roll();
                        break;
                    }
                case Turn.Thief:
                    {
                        thief.CurrentState = Hero.State.Move; 
                        thief.CurrentAttackState = Hero.AttackState.Inactive;
                        thief.Attack();
                        currentTurn = Turn.Mage;
                        mage.MovePoints = 0;
                        mage.Roll();
                        break;
                    }
                case Turn.Mage:
                    {
                        mage.CurrentState = Hero.State.Move; 
                        mage.CurrentAttackState = Hero.AttackState.Inactive;
                        mage.Attack();
                        currentTurn = Turn.Dungeon;
                        break;
                    }
            }
        }
    }
}
