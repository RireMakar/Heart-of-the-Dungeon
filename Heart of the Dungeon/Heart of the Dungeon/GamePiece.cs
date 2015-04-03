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
    class GamePiece
    {
        #region Attributes
        // attributes
        protected Rectangle rectangle;
        protected Texture2D texture;
        protected bool isVisible;
        #endregion Attributes
        
        // properties
        public Rectangle Rectangle
        {
            get { return rectangle; }
            set
            {
                rectangle = value;
            }
        }

        #region Constructor
        // constructor
        public GamePiece(Texture2D text, Rectangle rect)
        {
            texture = text;
            rectangle = rect;
            isVisible = true;
        }
        #endregion Constructor

        #region Methods
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
                spriteBatch.Draw(texture, rectangle, Color.White);
        }
        #endregion Methods
    }
}
