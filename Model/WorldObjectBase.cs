using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentASCLib.Model
{
    //Composite pattern
    public abstract class WorldObjectBase
    {
        public WorldObjectBase()
        {
            Position = new Coordinates();
        }

        public Coordinates Position { get; set; }
        
    }
    public class Coordinates
    {
        public int x;
        public int y;
    }
}
