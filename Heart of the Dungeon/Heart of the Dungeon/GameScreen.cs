﻿using Microsoft.Xna.Framework;
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
        private List<Wall> wallList;
        private List<Rectangle> spawnList;
        private List<Heart> heartList;
        private int dungeonHealth;

        // properties
        public int DungeonHealth
        {
            get { return dungeonHealth; }
            set { dungeonHealth = value; }
        }
        public List<Heart> HeartList
        {
            get { return heartList; }
        }
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
        public List<Rectangle> SpawnList
        {
            get { return spawnList; }
        }

        // constructor
        public GameScreen(Map mp)
        {
            map = mp;
            wallList = map.WallList;
            spawnList = map.SpawnList;
            heartList = map.HeartList;
            foreach (Heart h in heartList)
            {
                h.gameScreen = this;
            }
            dungeonHealth = heartList.Count;
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
        }

        // methods
        /// <summary>
        /// Updates the game
        /// </summary>
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
                        dungeon.Update(newState, oldState);  
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
        /// <summary>
        /// Draws the game with the specified spritebatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            map.Draw(spriteBatch);
            knight.Draw(spriteBatch);
            thief.Draw(spriteBatch);
            mage.Draw(spriteBatch);
            dungeon.Draw(spriteBatch);
            foreach (Heart h in heartList)
            {
                h.Draw(spriteBatch);
            }
            spriteBatch.DrawString(mainFont, "Turn: " + currentTurn + "   Move Points: " + movePoints + "   State: " + state + 
                "\nKnight Health: " + knight.Health + "  Thief Health: " + thief.Health + "  Mage Health: " + mage.Health +
                "\nDungeon State: " + dungeon.CurrentState + "   Dungeon Spawn Points: " + dungeon.SpawnPoints, new Vector2(32, 16), Color.White);
        }
        /// <summary>
        /// Ends the game
        /// </summary>
        private void EndGame()      // end the game (expand later, it just closes for now)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Handles turn order
        /// </summary>
        private void NextTurn()
        {
            int lifeCount = 0;
            foreach (Hero h in heroList)
            {
                if (h.IsAlive)
                    lifeCount++;
            }
            if (lifeCount == 0 || dungeonHealth == 0)
                this.EndGame();
            switch(currentTurn)
            {
                case Turn.Dungeon:
                    {
                        dungeon.CurrentState = Dungeon.State.Inactive;
                        dungeon.Update(Keyboard.GetState(), Keyboard.GetState());
                        foreach(Monster m in monsterList)
                        {
                            m.CurrentAttackState = Monster.AttackState.Inactive;
                            m.Update(Keyboard.GetState(), Keyboard.GetState());
                        }
                        if (!knight.IsAlive)
                        {
                            currentTurn = Turn.Knight;
                            this.NextTurn();
                            return;
                        }
                        currentTurn = Turn.Knight;
                        knight.MovePoints = 0;
                        knight.Roll();
                        break;
                    }
                case Turn.Knight:
                    {
                        if (!thief.IsAlive)
                        {
                            currentTurn = Turn.Thief;
                            this.NextTurn();
                            return;
                        }
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
                        if (!mage.IsAlive)
                        {
                            currentTurn = Turn.Mage;
                            this.NextTurn();
                            return;
                        }
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
                        dungeon.IsTurnStart = true;
                        dungeon.CurrentState = Dungeon.State.Spawning;
                        break;
                    }
            }
        }
    }
}
