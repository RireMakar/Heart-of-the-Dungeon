using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heart_of_the_Dungeon
{
    class Heart : GamePiece     // the heart of the dungeon
    {
        public GameScreen gameScreen;
        public Heart(Rectangle rect) : base(GlobalVariables.textureDictionary["heart"], rect)
        {

        }

        public void Destroy()
        {
            isVisible = false;
            gameScreen.DungeonHealth--;
        }
    }
}
