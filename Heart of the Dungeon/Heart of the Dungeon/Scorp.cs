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
    class Scorp : Monster
    {
        public Scorp(Texture2D text, Rectangle rect, GameScreen gS)
            : base(text, rect, gS)
        {

        }
    }
}
