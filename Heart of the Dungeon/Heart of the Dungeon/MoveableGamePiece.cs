﻿using System;
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
    class MoveableGamePiece : GamePiece
    {
        public MoveableGamePiece(Texture2D text, Rectangle rect)
            : base(text, rect)
        {

        }
    }
}
