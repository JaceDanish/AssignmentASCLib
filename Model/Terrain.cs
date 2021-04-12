using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentASCLib.Model
{
    public class Terrain : WorldObjectBase
    {
        //terrain items not implemented
        public Terrain(String name, bool traversable)
        {
            Name = name;
            Traversable = traversable;
        }

        public bool Traversable { get; set; }
        //public Iitem Treasure { get; set; }
        public String Name { get; set; }
        public override String ToString()
        {
            return $"Terrain: {Name}, treasure: None, traversable: {(Traversable ? "yes" : "no")}";
        }
    }
}
