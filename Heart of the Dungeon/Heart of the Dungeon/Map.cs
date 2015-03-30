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
    class Map
    {
        #region Attributes
        // attributes
        private string name;
        private int[,] mapData;
        private Texture2D floortiles;
        private Texture2D walltiles;
        private int[,] tileType;
        Random rand;
        #endregion Attributes

        #region Properties
        // properties
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }
        
        public int[,] MapData
        {
            get { return mapData; }
            set
            {
                mapData = value;
            }
        }
        #endregion Properties

        #region Constructor
        // constructor
        public Map(Texture2D ft, Texture2D wt) 
        {
            floortiles = ft;
            walltiles = wt;
            rand = new Random();
            tileType = new int[32, 24];
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    tileType[i, j] = rand.Next(3);
                }
            }
            
        }
        #endregion Constructor

        #region Methods
        // methods
        public void Draw(SpriteBatch spriteBatch)
        {            
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    if (mapData[i,j] == 99) { }
                    else if (mapData[i,j] == 0)
                    {
                        spriteBatch.Draw(floortiles, new Rectangle(i * 32, j * 32, 32, 32), new Rectangle(tileType[i,j] * 32, 0, 32, 32), Color.White);
                    }
                    else if (mapData[i,j] % 13 == 0)
                    {
                        spriteBatch.Draw(walltiles, new Rectangle(i * 32, j * 32, 32, 32), new Rectangle(12 * 32, ((mapData[i,j] / 13) - 1) * 32, 32, 32), Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(walltiles, new Rectangle(i * 32, j * 32, 32, 32), new Rectangle((((mapData[i,j]) % 13) - 1) * 32, (mapData[i,j] / 13) * 32, 32, 32), Color.White);
                    }
                }
            }
        }
        #endregion Methods
    }
}
