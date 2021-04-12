using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentASCLib.Model
{
    public class DeadCreature : WorldObjectBase
    {
        public String Name { get; set; }

        public DeadCreature(String name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"Dead {Name}";
        }
    }
}
