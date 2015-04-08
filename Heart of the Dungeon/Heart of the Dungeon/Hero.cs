using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Heart_of_the_Dungeon
{
    class Hero : MoveableGamePiece
    {
        // attributes
        protected int movePoints;
        protected List<Wall> wallList;
        protected bool isFirstTurn;
        protected AttackSpace[,] attackGrid;
        protected enum State { Attack, Move, Ability };
        protected State currentState;
        protected enum AttackState { Inactive, Activating, Choosing, Attacking };
        AttackState currentAttackState;
        protected string name;
        KeyboardState oldState, newState;
        protected int currentGridSpaceX;
        protected int currentGridSpaceY;
        protected int damage;
        protected int health;

        // properties
        public int MovePoints
        {
            get { return movePoints; }
            set
            {
                movePoints = value;
            }
        }

        // constructor
        public Hero(Texture2D text, Rectangle rect, List<Wall> wL)
            : base(text, rect)
        {
            wallList = wL;
            movePoints = 0;
            isFirstTurn = true;
            currentAttackState = AttackState.Inactive;
            currentState = State.Move;
            currentGridSpaceX = 0;
            currentGridSpaceY = 0;
        }

        // methods
        public void Update(KeyboardState nS, KeyboardState oS)
        {
            newState = nS;
            oldState = oS;

            if (movePoints == 0)
                this.Roll();
            if (newState.IsKeyDown(Keys.X) && oldState.IsKeyUp(Keys.X) && movePoints != 0 && currentState == State.Attack)
                currentAttackState = AttackState.Attacking;
            if (newState.IsKeyDown(Keys.Space) && oldState.IsKeyUp(Keys.Space))
            {
                if (currentState == State.Move)
                {
                    currentState = State.Attack;
                    currentAttackState = AttackState.Activating;
                }
                else
                {
                    currentState = State.Move;
                    currentAttackState = AttackState.Inactive;
                }
            }

            switch (currentState)
            {
                case State.Move:
                    {
                        if (newState.IsKeyDown(Keys.W) && oldState.IsKeyUp(Keys.W) && movePoints > 0)
                        {
                            this.Move(3);
                        }
                        if (newState.IsKeyDown(Keys.D) && oldState.IsKeyUp(Keys.D) && movePoints > 0)
                        {
                            this.Move(0);
                        }
                        if (newState.IsKeyDown(Keys.S) && oldState.IsKeyUp(Keys.S) && movePoints > 0)
                        {
                            this.Move(1);
                        }
                        if (newState.IsKeyDown(Keys.A) && oldState.IsKeyUp(Keys.A) && movePoints > 0)
                        {
                            this.Move(2);
                        }
                        break;
                    }
                case State.Ability:
                    {
                        break;
                    }
                case State.Attack:
                    {
                        this.Attack();
                        break;
                    }
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            if (currentAttackState == AttackState.Choosing)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (attackGrid[i,j] != null && attackGrid[i, j].IsVisible)
                            attackGrid[i, j].Draw(spriteBatch);
                    }
                }
            }            
        }
        public string GetState()
        {
            return currentState.ToString();
        }
        public void Roll()
        {
            Random rand = new Random();
            movePoints = rand.Next(1, 7);
        }

        public void Attack()
        {            
            switch (currentAttackState)
            {
                case AttackState.Inactive:
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (attackGrid[i, j] != null && attackGrid[i, j].IsVisible)
                                {
                                    attackGrid[i, j].Toggle();
                                }
                            }
                        }
                        break;
                    }
                case AttackState.Activating:
                    {
                        this.UpdateAttackGrid();
                        if (name == "mage")
                        {
                            attackGrid[0, 0].Toggle();
                            currentGridSpaceX = 0;
                            currentGridSpaceY = 0;
                        }
                        else
                        {
                            attackGrid[1, 1].Toggle();
                            currentGridSpaceX = 1;
                            currentGridSpaceY = 1;
                        }
                        currentAttackState = AttackState.Choosing;
                        break;
                    }
                case AttackState.Choosing:
                    {
                        if (newState.IsKeyDown(Keys.W) && oldState.IsKeyUp(Keys.W) && currentGridSpaceX - 1 >= 0 && attackGrid[currentGridSpaceX - 1, currentGridSpaceY] != null)
                        {
                            attackGrid[currentGridSpaceX, currentGridSpaceY].Toggle();
                            attackGrid[currentGridSpaceX - 1, currentGridSpaceY].Toggle();
                            currentGridSpaceX--;
                        }
                        if (newState.IsKeyDown(Keys.S) && oldState.IsKeyUp(Keys.S) && currentGridSpaceX + 1 <= 4 && attackGrid[currentGridSpaceX + 1, currentGridSpaceY] != null)
                        {
                            attackGrid[currentGridSpaceX, currentGridSpaceY].Toggle();
                            attackGrid[currentGridSpaceX + 1, currentGridSpaceY].Toggle();
                            currentGridSpaceX++;
                        }
                        if (newState.IsKeyDown(Keys.A) && oldState.IsKeyUp(Keys.A) && currentGridSpaceY - 1 >= 0 && attackGrid[currentGridSpaceX, currentGridSpaceY - 1] != null)
                        {
                            attackGrid[currentGridSpaceX, currentGridSpaceY].Toggle();
                            attackGrid[currentGridSpaceX, currentGridSpaceY - 1].Toggle();
                            currentGridSpaceY--;
                        }
                        if (newState.IsKeyDown(Keys.D) && oldState.IsKeyUp(Keys.D) && currentGridSpaceY + 1 <= 4 && attackGrid[currentGridSpaceX, currentGridSpaceY + 1] != null)
                        {
                            attackGrid[currentGridSpaceX, currentGridSpaceY].Toggle();
                            attackGrid[currentGridSpaceX, currentGridSpaceY + 1].Toggle();
                            currentGridSpaceY++;
                        }
                        
                        break;
                    }
                case AttackState.Attacking:
                    {
                        movePoints = 0;
                        break;
                    }
            }
        }
        public virtual void UpdateAttackGrid() { }

        public virtual void Move(int direction)
        {
            bool collision = false;
            switch (direction)
            {
                case 0:
                    {
                        Rectangle testRectangle = new Rectangle(rectangle.X + 32, rectangle.Y, rectangle.Width, rectangle.Height);
                        foreach (Wall w in wallList)
                        {
                            if (w.Rectangle.Intersects(testRectangle))
                            {
                                collision = true;
                                break;
                            }
                        }
                        if (collision)
                            break;
                        movePoints--;
                        rectangle = testRectangle;
                        break;
                    }
                case 1:
                    {
                        Rectangle testRectangle = new Rectangle(rectangle.X, rectangle.Y + 32, rectangle.Width, rectangle.Height);
                        foreach (Wall w in wallList)
                        {
                            if (w.Rectangle.Intersects(testRectangle))
                            {
                                collision = true;
                                break;
                            }
                        }
                        if (collision)
                            break;
                        movePoints--;
                        rectangle = testRectangle;
                        break;
                    }
                case 2:
                    {
                        Rectangle testRectangle = new Rectangle(rectangle.X - 32, rectangle.Y, rectangle.Width, rectangle.Height);
                        foreach (Wall w in wallList)
                        {
                            if (w.Rectangle.Intersects(testRectangle))
                            {
                                collision = true;
                                break;
                            }
                        }
                        if (collision)
                            break;
                        movePoints--;
                        rectangle = testRectangle;
                        break;
                    }
                case 3:
                    {
                        Rectangle testRectangle = new Rectangle(rectangle.X, rectangle.Y - 32, rectangle.Width, rectangle.Height);
                        foreach (Wall w in wallList)
                        {
                            if (w.Rectangle.Intersects(testRectangle))
                            {
                                collision = true;
                                break;
                            }
                        }
                        if (collision)
                            break;
                        movePoints--;
                        rectangle = testRectangle;
                        break;
                    }
            }
        }
    }
}