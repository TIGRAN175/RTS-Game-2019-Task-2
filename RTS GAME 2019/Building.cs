using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS_GAME_2019
{
    [Serializable]
    abstract class Building
    {
        protected int xPos;
        protected int yPos;
        protected int health;
        protected int maxHealth;
        protected int team;
        protected char symbol;
        public Building(int xPos, int yPos, int health, int team, char symbol)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.health = health;
            this.team = team;
            this.symbol = symbol;
            maxHealth = health;
        }


        public abstract int XPos { get; set; }
        public abstract int YPos { get; set; }
        public abstract int MaxHealth { get; }
        public abstract int Health { get; set; }
        public abstract int Team { get; set; }
        public abstract char Symbol { get; set; }

        public abstract void Save();
        public abstract void DeathHandler(Map map);
        public abstract string ToString();

    }
}
