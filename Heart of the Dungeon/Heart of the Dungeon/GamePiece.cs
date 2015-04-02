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
    abstract class GamePiece
    {
        #region Attributes
        // attributes
        protected Rectangle initialRectangle;
        protected Texture2D texture;
        protected bool isVisible;
        protected bool isSolid;
        protected int posX;
        protected int posY;
        #endregion Attributes

        #region Constructor
        // constructor
        public GamePiece(Texture2D text, Rectangle rect)
        { 
            texture = text;
            initialRectangle = rect;
            posX = rect.X;
            posY = rect.Y;
            isVisible = true;
        }
        #endregion Constructor

        #region Methods
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
                spriteBatch.Draw(texture, new Rectangle(posX * 32, posY * 32, texture.Width, texture.Height), Color.White);
        }
        #endregion Methods
    }
}
