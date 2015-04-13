using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heart_of_the_Dungeon
{
    class Dungeon
    {
        // attributes
        GameScreen gameScreen;

        // properties

        
        public Dungeon(GameScreen gS)
        {
            gameScreen = gS;
        }

        public void Update()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Monster m in gameScreen.MonsterList)
            {
                m.Draw(spriteBatch);
            }
        }
    }
}
