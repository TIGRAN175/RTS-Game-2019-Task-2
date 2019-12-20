using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RTS_GAME_2019
{
    [Serializable]
    class MeeleeUnit : Unit
    {

        public MeeleeUnit(int xPos, int yPos, int team, string name) : base( xPos,  yPos,  100,  1,  35,  1,  team, 'M', name)
        {

        }

        public override int XPos
        {
            get { return xPos; }
            set { xPos = value; }
        }
        public override int YPos
        {
            get { return yPos; }
            set { yPos = value; }
        }
        public override int MaxHealth
        {
            get { return maxHealth; }
        }

        public override int Health
        {
            get { return health; }
            set { health = value; }
        }

        public override int Speed
        {
            get { return speed; }
            set { speed = value; }
        }


        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
        public override int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public override int Team
        {
            get { return team; }
            set { team = value; }
        }

        public override char Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        public override int AttackRange
        {
            get { return attackRange; }
            set { attackRange = value; }
        }

        //returns false if the unit died in battle
        public override bool AttackUnit(Unit unitToAttack, Map map)
        {
            //Note that the range is checked by the map class called by the GameEngine.
            //The unitToAttack here is assumed to be in range.


            unitToAttack.Health = unitToAttack.Health - attack;
                if(unitToAttack.Health <= 0)
                {
                unitToAttack.Health = 0;
                unitToAttack.DeathHandler(map);
                return false;
                }
            return true;
        }

        public override void DeathHandler(Map map)
        {
            map.DestroyUnit(this);
        }

        //Case 1: closest enemy unit is returned
        //Case 2: no enemies left... return null
        public override Unit FindClosestUnit(Map map)
        {
            //origin xPos, yPos (x,y)
            int x = xPos;
            int y = yPos;

            
            int searchDepth = 1;
            bool hasFoundValidSpot;
            do
            {
               // Debug.WriteLine("in meelee unit ");

                hasFoundValidSpot = false;
                //top loop
                int rowTopFixed = x - searchDepth;
                for (int colTop = y - searchDepth; colTop < y + searchDepth + 1; colTop++)
                {
                    if (map.IsInMap(rowTopFixed, colTop))
                    {
                        hasFoundValidSpot = true;
                        //index is in map
                        Unit possibleUnit = map.unitMap[rowTopFixed, colTop];
                        if (possibleUnit == null)
                        {
                            continue;
                        }
                        else
                        {
                            if (team != possibleUnit.Team)
                            {
                                return possibleUnit;
                            }
                        }
                    }
                }

                //right side
                int rightColFixed = y + searchDepth;
                for (int rowRight = x - searchDepth; rowRight < x + searchDepth + 1; rowRight++)
                {
                    if (map.IsInMap(rowRight, rightColFixed))
                    {
                        hasFoundValidSpot = true;
                        Unit possibleUnit = map.unitMap[rowRight, rightColFixed];
                        if (possibleUnit == null)
                        {
                            continue;
                        }
                        else
                        {
                            if (team != possibleUnit.Team)
                            {
                                return possibleUnit;
                            }
                        }
                    }
                }

                //bottom side
                int bottomRowFixed = x + searchDepth;
                for (int colBottom = y - searchDepth; colBottom < y + searchDepth + 1; colBottom++)
                {
                    if (map.IsInMap(bottomRowFixed, colBottom))
                    {
                        hasFoundValidSpot = true;
                        Unit possibleUnit = map.unitMap[bottomRowFixed, colBottom];
                        if (possibleUnit == null)
                        {
                            continue;
                        }
                        else
                        {
                            if (team != possibleUnit.Team)
                            {
                                return possibleUnit;
                            }
                        }
                    }
                }

                //left loop
                int colLeftFixed = y - searchDepth;
                for (int rowLeft = x - searchDepth; rowLeft < x + searchDepth + 1; rowLeft++)
                {
                    if (map.IsInMap(rowLeft, colLeftFixed))
                    {
                        hasFoundValidSpot = true;
                        //index is in map
                        Unit possibleUnit = map.unitMap[rowLeft, colLeftFixed];
                        if (possibleUnit == null)
                        {
                            continue;
                        }
                        else
                        {
                            if (team != possibleUnit.Team)
                            {
                                return possibleUnit;
                            }
                        }
                    }
                }
                searchDepth++;
            } while (hasFoundValidSpot);

            return null;
        }

        public override bool IsInRange(Map map, Unit enemy)
        {
            return map.IsWithinRange(this, enemy);
        }

        public override void MoveToPosition(int x, int y)
        {
            XPos = x;
            YPos = y;
        }

        public override void Save()
        {
            string pathString =  System.IO.Path.GetRandomFileName() + ".dat";
            var systemPath = Directory.GetCurrentDirectory();
            string dirPath = Path.Combine(systemPath, "units/");
            var complete = Path.Combine(dirPath, pathString);

            if (Directory.Exists(dirPath))
            {
                File.Create(complete).Close();
            }
            else
            {          
                Directory.CreateDirectory(dirPath);
                File.Create(complete).Close();
            }
             Stream stream = new FileStream(complete, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
             BinaryFormatter b = new BinaryFormatter();
             b.Serialize(stream, this);
             stream.Close();
        }

        public override string ToString()
        {
            return "Type: Meelee " + Name + " (" +XPos+"," + YPos+")  HP: " + Health + "  maxHP: " + MaxHealth + "  attack: " + Attack + "  attackRange: " + attackRange + "  team: " + Team;
        } 
    }//xPos, yPos, health, maxHealth, speed, attack, attackRange, team;
}
