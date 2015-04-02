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
        protected int abilityCost;
        protected string name;
        protected int movePoints;
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

        public bool IsFirstTurn
        {
            get { return isFirstTurn; }
            set
            {
                isFirstTurn = value;
            }
        }

        public Hero(Texture2D text, Rectangle rect)
            : base(text, rect)
        {
            isFirstTurn = true;
            isAlive = true;
            isVisible = false;
        }

        public string GetName()
        {
            return name;
        }

        public virtual void ResetStats()
        {
            movePoints = 0;
        }
    }
}
