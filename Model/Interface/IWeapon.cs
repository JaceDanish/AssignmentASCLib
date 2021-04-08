using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentASCLib.Model.Interface
{
    public interface IWeapon : Iitem
    {
        public int Damage { get; set; }
    }
}
