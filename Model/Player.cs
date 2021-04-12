using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentASCLib.Model
{
    public class Player : Creature
    {
        public BackPack Inventory { get; set; }
        public Player(String name, int maxHp, int armor = 0, int baseDamage = 1, int inventoryMax = 5, params Iitem[] inventoryContent) : base(name, maxHp, armor, baseDamage)
        {
            Inventory = new BackPack(inventoryMax, inventoryContent);
        }
    }
}
