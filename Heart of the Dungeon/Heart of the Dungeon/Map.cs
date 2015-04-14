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
        private Texture2D spawnSpace;
        private int[,] tileType;
        private List<Wall> wallList;
        private List<Rectangle> spawnList;
        Random rand;
        private List<Heart> heartList;
        #endregion Attributes

        #region Properties
        // properties
        public List<Heart> HeartList
        {
            get { return heartList; }
        }
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

        public List<Wall> WallList
        {
            get { return wallList; }
            set
            {
                wallList = value;
            }
        }

        public List<Rectangle> SpawnList
        {
            get { return spawnList; }
            set
            {
                spawnList = value;
            }
        }
        #endregion Properties

        #region Constructor
        // constructor
        /// <summary>
        /// Loads the data for the map from a text file
        /// </summary>
        /// <param name="mpDt"></param>
        public Map(int[,] mpDt) 
        {
            floortiles = GlobalVariables.textureDictionary["floortiles"];
            walltiles = GlobalVariables.textureDictionary["walltiles"];
            spawnSpace = GlobalVariables.textureDictionary["spawnSpace"];
            mapData = mpDt;
            rand = new Random();
            
            tileType = new int[32, 24];
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    tileType[i, j] = rand.Next(3);
                }
            }

            wallList = new List<Wall>();
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    if (mapData[i, j] > 0 && mapData[i,j] < 53)
                    {
                        wallList.Add(new Wall(walltiles, new Rectangle(i * 32, j * 32, 32, 32)));
                    }
                }
            }

            spawnList = new List<Rectangle>();
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    if (mapData[i, j] == 54)
                    {
                        spawnList.Add(new Rectangle(i * 32, j * 32, 32, 32));
                    }
                }
            }

            heartList = new List<Heart>();
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    if (mapData[i, j] == 55)
                    {
                        heartList.Add(new Heart(new Rectangle(i * 32, j * 32, 32, 32)));
                    }
                }
            }
        }
        #endregion Constructor

        #region Methods
        // methods
        /// <summary>
        /// Draws the map
        /// </summary>
        /// <param name="spriteBatch"></param>
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
                    else if (mapData[i, j] == 54)
                    {
                        spriteBatch.Draw(floortiles, new Rectangle(i * 32, j * 32, 32, 32), new Rectangle(tileType[i, j] * 32, 0, 32, 32), Color.White);
                        spriteBatch.Draw(spawnSpace, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                    }
                    else if (mapData[i, j] == 55)
                    {
                        spriteBatch.Draw(floortiles, new Rectangle(i * 32, j * 32, 32, 32), new Rectangle(tileType[i, j] * 32, 0, 32, 32), Color.White);
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


