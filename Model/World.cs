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
        private String format = "{0:00}";

        public World()
        {
            LoadConfig();
            worldMap = new WorldObjectBase[x, y];

        }

        public WorldObjectBase[,] WorldMap { get { return worldMap; } set { worldMap = value; } }

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public void DisplayWorld(Player player)
        {
            for (int x = -1; x < X; x++)
            {
                Console.Write(String.Format(format, x + 1) + " ");
                for (int y = 0; y < Y; y++)
                {
                    if (x == -1)
                    {
                        Console.Write(String.Format(format, y + 1) + " ");
                    }
                    else if (player.Position.x == x && player.Position.y == y)
                    {
                        Console.Write("<A>");
                    }
                    else if (worldMap[x, y] is Creature)
                    {
                        Console.Write(" X ");
                    }
                    else if (worldMap[x, y] is Terrain)
                    {
                        Console.Write(((Terrain)worldMap[x, y]).Traversable ? "   " : " = ");
                    }
                    else
                    {
                        Console.Write(" _ ");
                    }
                }
                Console.WriteLine();
            }
        }

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
                x = 25;
                y = 25;
            }
        }
        #endregion
    }
}
