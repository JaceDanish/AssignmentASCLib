using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentASCLib.Model
{
    public class Consumable : Iitem
    {
        public Consumable(Potion type, int effectiveness)
        {
            Type = type;
            Effectiveness = effectiveness;
        }
        public string Name { get; set; }
        public Potion Type { get; private set; }
        public int Effectiveness { get; private set; }
    }
    public enum Potion
    {
        Healing
    }
}
