using AssignmentASCLib.Model.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentASCLib.Model
{
    public class RangedWeapon : IWeapon
    {
        public RangedWeapon(String name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public String Name { get; set; }
        public int Damage { get; set; }
    }
}
