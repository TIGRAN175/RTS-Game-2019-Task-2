using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS_GAME_2019
{
    public struct Position
    {
        public int x, y;
        public Position(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }
    [Serializable]
    abstract class Unit
    {
        
        protected int xPos, yPos, health, maxHealth, speed, attack, attackRange, team;
        protected string name;
        protected char symbol;
        protected bool isAttacking;

        public Unit(int xPos, int yPos, int maxHealth, int speed, int attack, int attackRange,int team, char symbol, string name)
        {
            this.name = name;
            isAttacking = false;
            this.symbol = symbol;
            this.xPos = xPos;
            this.yPos = yPos;
            this.maxHealth = maxHealth;
            this.health = maxHealth;
            this.speed = speed;
            this.attack = attack;
            this.attackRange = attackRange;
            this.team = team;
        }
        public abstract void MoveToPosition(int xPos, int yPos);
        public abstract bool AttackUnit(Unit unitToAttack, Map map); // returns false if the unit died in battle, true otherwise
        public abstract bool IsInRange(Map map, Unit enemy);
        public abstract Unit FindClosestUnit(Map map);
        public abstract void DeathHandler(Map map);
        public abstract string ToString();
        public abstract void Save();
         
        public abstract int Team { get; set; }
        public abstract string Name { get; set; }
        public abstract int XPos { get; set; }
        public abstract int YPos { get; set; }
        public abstract int MaxHealth { get; }
        public abstract int Health { get; set;}
        public abstract int Speed { get; set;}
        public abstract int Attack { get; set;}
        public abstract char Symbol{get; set;}
        public abstract int AttackRange { get; set; }
    }
}
