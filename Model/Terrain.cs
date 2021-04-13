using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentASCLib.Model
{
    public class Terrain : WorldObjectBase
    {
        public Terrain(String name, bool traversable)
        {
            Name = name;
            Traversable = traversable;
        }

        public bool Traversable { get; set; }
        public Iitem Treasure { get; set; }
        public String Name { get; set; }
        public override String ToString()
        {
            return $"Terrain: {Name}, treasure: {(Treasure == null ? "none" : Treasure.Name)}, traversable: {(Traversable ? "yes" : "no")}";
        }
    }
}
