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
    class GamePiece
    {
        // attributes
        protected Rectangle rectangle;
        protected Texture2D texture;
        protected bool isVisible;
        protected bool isSolid;

        public virtual GamePiece(Texture2D text, Rectangle rect)
        {
            texture = text;
            rectangle = rect;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
                spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
