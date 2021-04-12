using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace AssignmentASCLib.Model
{
    public class World
    {
        private WorldObjectBase[,] worldMap;
        private int x;
        private int y;


        public World()
        {
            LoadConfig();
            worldMap = new WorldObjectBase[x, y];
        }

        public WorldObjectBase[,] WorldMaps { get { return worldMap; } set { worldMap = value; } }

        

        //should have its own class according to single-responsibility.
        #region Config creation/loading
        private XmlDocument conf = new XmlDocument();
        private void LoadConfig()
        {
            if (!File.Exists(@".\WorldConfiguration.config"))
            {
                FileStream fs = File.OpenWrite(@".\WorldConfiguration.config");
                StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
                sw.WriteLine("<WorldConfiguration>\n<WorldSizeX>100</WorldSizeX>\n<WorldSizeY>100</WorldSizeY>\n</WorldConfiguration>");
                sw.Flush();
                fs.Close();
            }
            try
            {
                conf.Load(@".\WorldConfiguration.config");
                XmlNode nodeX = conf.DocumentElement.SelectSingleNode("WorldSizeX");
                XmlNode nodeY = conf.DocumentElement.SelectSingleNode("WorldSizeY");
                if (nodeX != null && nodeY != null)
                {
                    String strX = nodeX.InnerText.Trim();
                    String strY = nodeY.InnerText.Trim();
                    x = Convert.ToInt32(strX);
                    y = Convert.ToInt32(strY);
                }
            }
            catch
            {
                x = 100;
                y = 100;
            }
        }
        #endregion
    }
}
