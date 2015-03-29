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
    class DrawPieces
    {
        // attributes
        List<Tile> tileList;
        List<MoveableGamePiece> moveableGamePieceList;

        // constructor
        public DrawPieces(List<Tile> tL, List<MoveableGamePiece> mGPL)
        {
            tileList = tL;
            moveableGamePieceList = mGPL;
        }

        public void DrawTiles(SpriteBatch spriteBatch)
        {
            foreach (Tile t in tileList)
            {
                t.Draw(spriteBatch);
            }
        }
        
        public void DrawMoveablePieces(SpriteBatch spriteBatch)
        {
            foreach (MoveableGamePiece mgp in moveableGamePieceList)
            {
                mgp.Draw(spriteBatch);
            }
        }

    }
}
