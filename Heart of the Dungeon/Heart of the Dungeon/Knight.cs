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
    class Knight : Hero
    {
        // attributes
        private int castleBuffer;



        public Knight(Texture2D text, Rectangle rect)
            : base(text, rect)
        {
            name = "knight";
            abilityCost = 4;
            movementMap = new bool[3, 3] { { false, true, false }, { true, false, true }, { false, true, false } };
            attackMap = new bool[3, 3] { { true, true, true }, { true, false, true }, { true, true, true } };
            health = 25;
            damage = 2;
            castleBuffer = 3;
        }
        public  void Ability(int movePoints)
        {
            if (movePoints >= abilityCost)
            {
                castleBuffer = 3;
                health += 3;
            }
        }

        public override void ResetStats()
        {
            if (castleBuffer > 0)
            {
                castleBuffer = 0;                
            }
            movePoints = 0;
        }
    }
}
