using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace RTS_GAME_2019
{
    class GameEngine
    {
        Map map;
        int remainingRounds;
        int roundCount;
        System.Timers.Timer myTimer;
        RichTextBox killFeed;
       TextBox resTeam0;

        TextBox resTeam1;
        Label winLabel;
        public GameEngine(Map map, int roundLimit, System.Timers.Timer timer, RichTextBox killFeed, Label winLabel, TextBox resTeam0, TextBox resTeam1)
        {
            this.winLabel = winLabel;
            this.killFeed = killFeed;
            this.resTeam0 = resTeam0;
            this.resTeam1 = resTeam1;
            roundCount = 0;
            myTimer = timer;
            this.map = map;
            remainingRounds = roundLimit;

        }

        public void StartTimer()
        {
            myTimer.Enabled = true;
        }

        public void StopTimer()
        {
            myTimer.Enabled = false;
        }

        public bool isTimerRunning()
        {
            return myTimer.Enabled;
        }

        public static void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        public int PerformRound()
        {
            if(remainingRounds <= 0)
            {
                //done!!!
                winLabel.Invoke(new Action(() => winLabel.Text = "Round Limit Reached! It's a draw!"));

                return roundCount;
            }

            int totalReasourcesTeam0 = 0;
            int totalReasourcesTeam1 = 0;

            foreach (Building b in map.buildingList)
            {
                if(b is ResourceBuilding)
                {
                ResourceBuilding r = (ResourceBuilding)b;

                
                Debug.WriteLine("GENERATING RESOURCES");
                    r.GenerateResourcesForRound();
                //now resourcesgenerated has been updated
                    if(r.Team == 0)
                {
                    totalReasourcesTeam0 += r.ResourcesGenerated;
                }else if(r.Team == 1)
                {
                    totalReasourcesTeam1 += r.ResourcesGenerated;
                }
                }
            }
            resTeam0.Invoke(new Action(() => resTeam0.Text = "" + totalReasourcesTeam0));
            resTeam1.Invoke(new Action(() => resTeam1.Text = "" + totalReasourcesTeam1));

            //first the factories should spawn units then the round battle commenses 
            foreach (Building b in map.buildingList)
            {
                if(b is FactoryBuilding) {
                    FactoryBuilding f = (FactoryBuilding)b;
                    int prodSpeed = f.GetProductionSpeed();
                    if(roundCount % prodSpeed == 0)
                    {
                        Debug.WriteLine("" + roundCount + " % " + prodSpeed);
                        f.SpawnUnit(map);
                    }

                }

                killFeed.Invoke(new Action(() => AppendText(killFeed, "\n" + b.ToString(), ((b.Team == 0) ? Color.Blue : Color.Red))));
                killFeed.Invoke(new Action(() => killFeed.ScrollToCaret()));
            }


            List<Unit> unitList = map.GetUnitList();

            for (int i =0; i < unitList.Count; i++)
            {
                Unit u = unitList.ElementAt(i);
                //Case 1: below health so run away
                if((u.Health / (double) u.MaxHealth) * 100.0 <= 25)
                {
                    map.MoveUnitRandomly(u);
                    continue;
                }

                //Case 2: Finding enemy and decide on attacking

                //Debug.WriteLine("Unit searching -- " + u.ToString());
                Unit closestEnemy = u.FindClosestUnit(map);

                if (closestEnemy != null)
                {
                   // Debug.WriteLine("closest enemy -- " + closestEnemy.ToString());
                    if(map.IsWithinRange(u, closestEnemy))
                    {
                        // we can attack
                        bool didDie = u.AttackUnit(closestEnemy, map);
                        if (didDie)
                        {
                            unitList.RemoveAt(i);
                            i--;
                        }
                    }
                    else
                    {
                        //we cant attack so move towards
                        map.MoveTowardsEnemy(u, closestEnemy);
                    }
                    killFeed.Invoke(new Action(() => AppendText(killFeed, "\n" + u.ToString(), ((u.Team == 0) ? Color.Blue : Color.Red))));
                    killFeed.Invoke(new Action(() => killFeed.ScrollToCaret()));
                    
                }
                else
                {
                    Debug.WriteLine("Team " + u.Team + " WINS!!! -- no enemies left");
                    winLabel.Invoke(new Action(() => winLabel.Text = "Team " + u.Team + " has won the game!"));
                    StopTimer();
                    return roundCount;
                }
            }
                //now round is done
                roundCount++;
                remainingRounds--;
                return roundCount;
        }
        
    }

    
}
