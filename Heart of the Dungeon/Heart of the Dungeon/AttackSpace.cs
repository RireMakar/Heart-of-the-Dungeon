using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heart_of_the_Dungeon
{
    class AttackSpace : GamePiece
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

        public AttackSpace(Rectangle rect) : base(GlobalVariables.textureDictionary["targetImage"], rect)
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
