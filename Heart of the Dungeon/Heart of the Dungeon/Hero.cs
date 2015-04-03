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
        }

        // methods
        public void Roll()
        {
            Random rand = new Random();
            movePoints = rand.Next(1, 7);
        }

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