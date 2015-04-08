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
using System.IO;

namespace Heart_of_the_Dungeon
{
    class MapHandler
    {
        #region Attributes
        // attributes
        private List<Map> mapList;
        #endregion Attributes

        #region Properties
        // properties
        public List<Map> MapList
        {
            get { return mapList; }
            set
            {
                mapList = value;
            }
        }
        #endregion Properties

        #region Constructor
        // constructor
        public MapHandler()
        {
            mapList = new List<Map>();
        }
        #endregion Constructor

        #region Methods
        // methods
        public void LoadMap(string fileName)
        {
            try
            {
                StreamReader streamReader = new StreamReader(fileName);
                string line = "";
                
                int[,] mapData = new int[32, 24];
                int row = 0;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] lineArr = line.Split(' ');
                    int col = 0;
                    foreach (string s in lineArr)
                    {
                        mapData[col, row] = int.Parse(s);
                        col++;
                    }
                    row++;
                }
                Map map = new Map(mapData);
                map.Name = fileName;
                mapList.Add(map);
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error loading map " + fileName + ". " + ioe.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Bad data in map file " + fileName + ". " + fe.Message);
            }
        }
        #endregion Methods
    }
}
