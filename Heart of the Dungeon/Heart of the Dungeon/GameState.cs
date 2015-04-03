using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heart_of_the_Dungeon
{
    abstract class GameState
    {
        public abstract void Update();

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
