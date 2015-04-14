using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heart_of_the_Dungeon
{
    class SelectionSpace : GamePiece        // this is essentially the dungeon's cursor
    {
        // constructor

        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
            }
        }

        public SelectionSpace(Rectangle rect) : base(GlobalVariables.textureDictionary["dungeonImage"], rect)
        {
            isVisible = false;
        }

        public void Toggle()
        {
            if (isVisible)
                isVisible = false;
            else
                isVisible = true;
        }
    }
}
