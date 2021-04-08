using AssignmentASCLib.Model.Interface;
using AssignmentASCLib.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentASCLib.Model
{
    public class Creature : WorldObjectBase
    {
        private int _maxHp;
        private Tracer tracer = Tracer.GetTracer;
        private IWeapon _hand1;
        private Iitem _hand2;
        private int _baseDamage;
        private int _hitPoints;

        public Creature(String name, int maxHp, int armor = 0, int baseDamage = 1)
        {
            Name = name;
            Alive = true;
            Armor = armor;
            _maxHp = maxHp;
            _hitPoints = maxHp;
            _baseDamage = baseDamage;
        }
        /// <summary>
        /// Attacks enemy and fights till death. Returns true if attacker won, false if attacker lost.
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public bool AttackEnemy(Creature enemy)
        {
            while(Alive && enemy.Alive)
            {
                enemy.TakeDamage(DealDamage());
                if (enemy.Alive)
                {
                    TakeDamage(enemy.DealDamage());
                }
            }
            return Alive;
        }

        public void TakeDamage(int damage)
        {
            if ((HitPoints =- (damage - Armor)) <= 0)
            {
                Alive = false;
                tracer.TraceInfo(1, "die");
            }
        }

        public int DealDamage()
        {
            if (_hand1 == null) return _baseDamage;
            return _hand1.Damage;
        }

        //make set public or make healing-method
        public int HitPoints
        {
            get { return _hitPoints; }
            protected set
            {
                _ = (_hitPoints + value > _maxHp) ? _hitPoints = _maxHp : _hitPoints += value;
            }
        }
        public bool Alive { get; protected set; }
        public int Armor { get; protected set; }
        public IWeapon MainHand
        {
            set { _hand1 = value; }
            get { return _hand1; }
        }
        public Iitem OffHand
        {
            set { _hand2 = value; }
            get { return _hand2; }
        }
        public String Name { get; protected set; }
    }
}
