using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heart_of_the_Dungeon
{
    abstract class GameState
    {
        SpriteFont mainFont;
        #region Constructor
        // constructor
        public GameState()
        { 
            mainFont = GlobalVariables.fontDictionary["mainFont"];
        }
        #endregion Constructor

        #region Methods
        // methods
        abstract public void Update();

        abstract public void Draw(SpriteBatch spriteBatch);
        #endregion Methods
    }
}
