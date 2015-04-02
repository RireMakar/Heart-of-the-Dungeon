using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heart_of_the_Dungeon
{
    abstract  class MoveableGamePiece : GamePiece
    {
        #region Attributes
        // attributes
        protected bool[,] movementMap;
        protected bool[,] attackMap;
        protected int damage;
        protected int health;
        protected bool isAlive;

        #endregion Attributes

        public MoveableGamePiece(Texture2D text, Rectangle rect)
            : base(text, rect)
        {
            isSolid = true;
        }
        public virtual void Move(int direction)
        {
            switch (direction)
            {
                case 0:
                    {
                        posY--;
                        break;
                    }
                case 1:
                    {
                        posX++;
                        break;
                    }
                case 2:
                    {
                        posY++;
                        break;
                    }
                case 3:
                    {
                        posX--;
                        break;
                    }
            }
        }
    }
}
