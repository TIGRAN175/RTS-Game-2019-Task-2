using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTS_GAME_2019
{
    public partial class Form1 : Form
    {
        GameEngine gameEngine;
        Map map;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            DataGridView grid = (DataGridView)this.Controls["grid"];
            grid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
            grid.RowHeadersVisible = false;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            lblRound.Text = "Round 1";
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 2000;
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;

            map = new Map(10, 2);
            map.GenerateMap(grid);
            gameEngine = new GameEngine(map, 20, timer, textBox, lblWinner, txtResources0, txtResources1);
            gameEngine.StartTimer();
            //gameEngine.PerformRound();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            int roundToUpdate = gameEngine.PerformRound();
            lblRound.Invoke(new Action(() => lblRound.Text  = "Round " + roundToUpdate));


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!gameEngine.isTimerRunning())
            {
            gameEngine.StartTimer();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            gameEngine.StopTimer();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            gameEngine.StopTimer();
            var systemPath = Directory.GetCurrentDirectory();
            string dirPath = Path.Combine(systemPath, "units/");
            System.IO.DirectoryInfo di = new DirectoryInfo(dirPath);

            //delete all units previously saved
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            systemPath = Directory.GetCurrentDirectory();
            dirPath = Path.Combine(systemPath, "buildings/");
            di = new DirectoryInfo(dirPath);
      
            //delete all buildings
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            //save all units
            for(int i =0; i < map.MAP_ROWS; i++)
            {
                for(int j =0; j < map.MAP_COLS; j++)
                {
                    if(map.unitMap[i, j] != null)
                    {
                         map.unitMap[i, j].Save();
                    }

                }
            }

            //save all buildings
            foreach(Building b in map.buildingList)
            {
                b.Save();
            }

            gameEngine.StartTimer();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            gameEngine.StopTimer();
            map.LoadUnitsAndBuildings();
            gameEngine.StartTimer();
        }
    }
}
