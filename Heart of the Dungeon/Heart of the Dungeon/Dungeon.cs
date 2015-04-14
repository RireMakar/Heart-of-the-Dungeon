using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heart_of_the_Dungeon
{
    class Dungeon
    {
        // attributes
        GameScreen gameScreen;
        KeyboardState oldState;
        KeyboardState newState;
        public enum State { Spawning, Choosing, Monster, Inactive };
        private State currentState;
        private int spawnPoints;
        private bool isTurnStart;
        private Random rand = new Random();
        private SelectionSpace selectionSpace;
        private int seleSpaceX;
        private int seleSpaceY;
        private Monster activeMonster;
        
        // properties
        public int SpawnPoints
        {
            get { return spawnPoints; }
            set { spawnPoints = value; }
        }
        public bool IsTurnStart
        {
            get { return isTurnStart; }
            set { isTurnStart = value; }
        }
        public State CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        
        public Dungeon(GameScreen gS)
        {
            gameScreen = gS;
            oldState = Keyboard.GetState();
            currentState = State.Spawning;
            isTurnStart = true;
            spawnPoints = 0;
            seleSpaceX = 5;
            seleSpaceY = 11;
            activeMonster = null;
            selectionSpace = new SelectionSpace(new Rectangle(seleSpaceX * 32, seleSpaceY * 32, 32, 32));
        }

        public void Update(KeyboardState nS, KeyboardState oS)
        {
            newState = nS;
            oldState = oS;
            
            if (newState.IsKeyDown(Keys.Q) && oldState.IsKeyUp(Keys.Q))
            {
                if (currentState == State.Spawning)
                    currentState = State.Choosing;
                else if (currentState == State.Monster)
                    currentState = State.Choosing;
                else
                    currentState = State.Spawning;
            }
            

            
            
            if (isTurnStart)
            {
                foreach(Monster m in gameScreen.MonsterList)
                {
                    m.MovePoints = -1;
                }
                spawnPoints += rand.Next(1, 9);
                isTurnStart = false;
            }

            if (currentState == State.Spawning || currentState == State.Choosing)
            {
                if(newState.IsKeyDown(Keys.W) && oldState.IsKeyUp(Keys.W))
                {
                    seleSpaceY--;
                    if (seleSpaceY < 0)
                        seleSpaceY++;
                }
                if(newState.IsKeyDown(Keys.S) && oldState.IsKeyUp(Keys.S))
                {
                    seleSpaceY++;
                    if (seleSpaceY > 23)
                        seleSpaceY--;
                }
                if(newState.IsKeyDown(Keys.A) && oldState.IsKeyUp(Keys.A))
                {
                    seleSpaceX--;
                    if (seleSpaceX < 0)
                        seleSpaceX++;
                }
                if(newState.IsKeyDown(Keys.D) && oldState.IsKeyUp(Keys.D))
                {
                    seleSpaceX++;
                    if (seleSpaceX > 31)
                        seleSpaceX--;
                }
                selectionSpace.Rectangle = new Rectangle(seleSpaceX * 32, seleSpaceY * 32, 32, 32);
            }
            switch(currentState)
            {
                case State.Spawning:
                    {
                        selectionSpace.IsVisible = true;
                        this.SpawnMonster(newState, oldState);
                        break;
                    }
                case State.Choosing:
                    {
                        selectionSpace.IsVisible = true;
                        if (newState.IsKeyDown(Keys.E) && oldState.IsKeyUp(Keys.E))
                        {
                            foreach (Monster m in gameScreen.MonsterList)
                            {
                                if (selectionSpace.Rectangle.Intersects(m.Rectangle))
                                {
                                    activeMonster = m;
                                    currentState = State.Monster;
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case State.Monster:
                    {
                        selectionSpace.IsVisible = false;
                        activeMonster.Update(newState, oldState);
                        break;
                    }
                case State.Inactive:
                    {
                        selectionSpace.IsVisible = false;
                        break;
                    }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Monster m in gameScreen.MonsterList)
            {
                m.Draw(spriteBatch);
            }
            selectionSpace.Draw(spriteBatch);
        }

        private void SpawnMonster(KeyboardState newState, KeyboardState oldState)
        {
            bool success = false;

            foreach(Rectangle r in gameScreen.SpawnList)
            {
                if (r.Intersects(selectionSpace.Rectangle))
                {
                    success = true;
                    break;
                }
            }       
            foreach(Wall w in gameScreen.WallList)
            {
                if (selectionSpace.Rectangle.Intersects(w.Rectangle))
                    success = false;
            }
            foreach(Monster m in gameScreen.MonsterList)
            {
                if (selectionSpace.Rectangle.Intersects(m.Rectangle))
                    success = false;
            }

            if(success)
            {
                if (newState.IsKeyDown(Keys.G) && oldState.IsKeyUp(Keys.G) && spawnPoints >= 2)
                {
                    gameScreen.MonsterList.Add(new Ghoul(GlobalVariables.textureDictionary["ghoul"], selectionSpace.Rectangle, gameScreen));
                    spawnPoints -= 2;
                }
            }
        }
    }
}
