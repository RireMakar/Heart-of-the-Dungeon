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
        private Texture2D spawn;
        private Texture2D enemySpawn;
        private Texture2D heart;
        private int[,] tileType;
        private bool[,] wallMap;
        private bool[,] spawnMap;
        private bool[,] enemySpawnMap;
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

        public bool[,] WallMap
        {
            get { return wallMap; }
            set
            {
                wallMap = value;
            }
        }

        public bool[,] SpawnMap
        {
            get { return spawnMap; }
            set
            {
                spawnMap = value;
            }
        }

        public bool[,] EnemySpawnMap
        {
            get { return enemySpawnMap; }
            set
            {
                enemySpawnMap = value;
            }
        }
        #endregion Properties

        #region Constructor
        // constructor
        public Map()
        {
            floortiles = GlobalVariables.textureDictionary["floortiles"];
            walltiles = GlobalVariables.textureDictionary["walltiles"];
            spawn = GlobalVariables.textureDictionary["spawn"];
            enemySpawn = GlobalVariables.textureDictionary["enemySpawn"];
            heart = GlobalVariables.textureDictionary["heart"];
            rand = new Random();
            wallMap = new bool[32, 24];
            spawnMap = new bool[32, 24];
            enemySpawnMap = new bool[32, 24];
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
                    else if (mapData[i,j] == 53)
                    {
                        spriteBatch.Draw(spawn, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                    }
                    else if (mapData[i, j] == 54)
                    {
                        spriteBatch.Draw(enemySpawn, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
                    }
                    else if (mapData[i, j] == 55)
                    {
                        spriteBatch.Draw(heart, new Rectangle(i * 32, j * 32, 32, 32), Color.White);
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
