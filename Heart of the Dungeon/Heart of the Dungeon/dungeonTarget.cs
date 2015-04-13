using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heart_of_the_Dungeon
{
    class DungeonTarget : MoveableGamePiece
    {
        // attributes

        // properties

        // constructor
        public DungeonTarget(Rectangle rect) : base(GlobalVariables.textureDictionary["dungeonImage"], rect)
        {

        }

        
    }
}
