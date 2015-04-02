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
    class DrawGame
    {
        #region Attributes
        // attributes
        List<Map> mapList;
        List<MoveableGamePiece> moveableGamePieceList;
        #endregion Attributes

        #region Constructor
        // constructor
        public DrawGame(List<Map> mL, List<MoveableGamePiece> mGPL)
        {
            mapList = mL;
            moveableGamePieceList = mGPL;
        }
        #endregion Constructor

        #region Methods
        public void DrawMap(SpriteBatch spriteBatch)
        {
            foreach (Map m in mapList)
            {
                m.Draw(spriteBatch);
            }
        }
        
        public void DrawMoveablePieces(SpriteBatch spriteBatch)
        {
            foreach (MoveableGamePiece mgp in moveableGamePieceList)
            {
                mgp.Draw(spriteBatch);
            }
        }
        #endregion Methods
    }
}
