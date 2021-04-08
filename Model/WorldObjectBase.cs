using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentASCLib.Model
{
    //Composite pattern
    public abstract class WorldObjectBase
    {
        public Coordinates Position { get; set; }
        
    }
    public struct Coordinates
    {
        int x;
        int y;
    }
}
