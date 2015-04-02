using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heart_of_the_Dungeon
{
    public static class GlobalVariables
    {
        public static int ScreenWidth { get; set; }
        public static int ScreenHeight { get; set; }
        public static bool IsFullscreen { get; set; }
        public static Dictionary<string, Texture2D> textureDictionary { get; set; }
        public static Dictionary<string, int> monsterCostDictionary { get; set; }
        public static Dictionary<string, SpriteFont> fontDictionary { get; set; }
    }
}
