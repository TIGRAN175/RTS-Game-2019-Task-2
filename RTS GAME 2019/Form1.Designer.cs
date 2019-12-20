namespace RTS_GAME_2019
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grid = new System.Windows.Forms.DataGridView();
            this.lblRound = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.lblWinner = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblTeam0 = new System.Windows.Forms.Label();
            this.txtResources0 = new System.Windows.Forms.TextBox();
            this.lblResources1 = new System.Windows.Forms.Label();
            this.txtResources1 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(1, 0);
            this.grid.Name = "grid";
            this.grid.RowTemplate.Height = 24;
            this.grid.Size = new System.Drawing.Size(808, 644);
            this.grid.TabIndex = 2;
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Location = new System.Drawing.Point(1204, 45);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(46, 17);
            this.lblRound.TabIndex = 3;
            this.lblRound.Text = "label1";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(907, 65);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(632, 274);
            this.textBox.TabIndex = 4;
            this.textBox.Text = "";
            // 
            // lblWinner
            // 
            this.lblWinner.AutoSize = true;
            this.lblWinner.Location = new System.Drawing.Point(1097, 394);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(0, 17);
            this.lblWinner.TabIndex = 5;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(898, 355);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(184, 112);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(1347, 355);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(192, 112);
            this.btnStop.TabIndex = 7;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblTeam0
            // 
            this.lblTeam0.AutoSize = true;
            this.lblTeam0.Location = new System.Drawing.Point(895, 505);
            this.lblTeam0.Name = "lblTeam0";
            this.lblTeam0.Size = new System.Drawing.Size(128, 17);
            this.lblTeam0.TabIndex = 8;
            this.lblTeam0.Text = "Resources Team 0";
            // 
            // txtResources0
            // 
            this.txtResources0.Location = new System.Drawing.Point(898, 532);
            this.txtResources0.Name = "txtResources0";
            this.txtResources0.Size = new System.Drawing.Size(125, 22);
            this.txtResources0.TabIndex = 9;
            this.txtResources0.Text = "0";
            this.txtResources0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblResources1
            // 
            this.lblResources1.AutoSize = true;
            this.lblResources1.Location = new System.Drawing.Point(1368, 505);
            this.lblResources1.Name = "lblResources1";
            this.lblResources1.Size = new System.Drawing.Size(128, 17);
            this.lblResources1.TabIndex = 10;
            this.lblResources1.Text = "Resources Team 1";
            // 
            // txtResources1
            // 
            this.txtResources1.Location = new System.Drawing.Point(1371, 542);
            this.txtResources1.Name = "txtResources1";
            this.txtResources1.Size = new System.Drawing.Size(125, 22);
            this.txtResources1.TabIndex = 11;
            this.txtResources1.Text = "0";
            this.txtResources1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1120, 531);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(1239, 531);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 13;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1551, 698);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtResources1);
            this.Controls.Add(this.lblResources1);
            this.Controls.Add(this.txtResources0);
            this.Controls.Add(this.lblTeam0);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.grid);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.Label lblWinner;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblTeam0;
        private System.Windows.Forms.TextBox txtResources0;
        private System.Windows.Forms.Label lblResources1;
        private System.Windows.Forms.TextBox txtResources1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
    }
}

