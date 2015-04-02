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
    class Tile : GamePiece
    {
        #region Attributes
        // attributes
        Rectangle sourceRectangle;
        #endregion Attributes

        #region Constructor
        // constructor
        public Tile(Texture2D text, Rectangle posRect, int tileVer)
            : base(text, posRect)
        {
            int posX = tileVer * 32;
            sourceRectangle = new Rectangle(posX, 0, 32, 32);
            isVisible = true;
        }
        #endregion Constructor

        #region Methods
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
                spriteBatch.Draw(texture, initialRectangle, sourceRectangle, Color.White);
        }
        #endregion Methods
    }
}
