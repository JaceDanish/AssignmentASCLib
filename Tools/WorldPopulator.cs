using AssignmentASCLib.Model;
using AssignmentASCLib.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentASCLib.Tools
{
    public class WorldPopulator
    {
        private readonly String[] creatureNames = { "Orc", "Elf", "Human" };
        private readonly String[] rangedWeapNames = { "Bow", "Crossbow", "Throwing knives" };
        private readonly String[] meleeWeapNames = { "Sword", "Axe", "Spear" };
        private readonly String[] terrainNames = { "Field", "Monestary", "Ruin" };
        private Random rand = new Random();
        private int weapMin, weapMax, healthMin, healthMax;
        private CreaturePopulation cPop;

        public WorldPopulator(int weapMin, int weapMax, int healthMin, int healthMax, CreaturePopulation creaturePop)
        {
            this.weapMax = weapMax;
            this.weapMin = weapMin;
            this.healthMin = healthMin;
            this.healthMax = healthMax;
            cPop = creaturePop;
        }

        public void Populate(World world)
        {
            for (int x = 0; x < world.X; x++)
            {
                for (int y = 0; y < world.Y; y++)
                {
                    world.WorldMap[x, y] = (rand.Next(0, (int)cPop) == 0 ? AddRandomCreature() : AddRandomTerrain());
                }
            }
        }

        private Terrain AddRandomTerrain()
        {
            return new Terrain(
                terrainNames[rand.Next(0, terrainNames.Length)],
                (rand.Next() % 3 == 0 ? false : true)
                );
        }

        private Creature AddRandomCreature()
        {
            var temp = new Creature(
                creatureNames[rand.Next(0, creatureNames.Length)],
                rand.Next(healthMin, healthMax)
                );
            temp.MainHand = AddRandomWeapon();
            return temp;
        }
        private IWeapon AddRandomWeapon()
        {
            switch (rand.Next(0,2))
            {
                case 0:
                    return new MeleeWeapon(
                        meleeWeapNames[rand.Next(0, meleeWeapNames.Length)],
                        rand.Next(weapMin, weapMax)
                        );
                case 1:
                    return new RangedWeapon(
                        rangedWeapNames[rand.Next(0, rangedWeapNames.Length)],
                        rand.Next(weapMin, weapMax)
                        );
                default: return null;
            }
        }
    }
    public enum CreaturePopulation
    {
        Low = 8,
        Medium = 5,
        High = 3
    }
}
