
namespace gta5_tools
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timerGame = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timerNetwork = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownNetwork = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownGame = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.buttonFreeze = new System.Windows.Forms.Button();
            this.listBoxInterface = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNetwork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGame)).BeginInit();
            this.SuspendLayout();
            // 
            // timerGame
            // 
            this.timerGame.Interval = 7000;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Press";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(52, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ctrl+Alt+F6";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "to disconnect the network adapter.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Press";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(52, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ctrl+Alt+F7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(130, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "to freeze the game.";
            // 
            // timerNetwork
            // 
            this.timerNetwork.Interval = 15000;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(181, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Network disconnection duration:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(124, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Game freeze duration:";
            // 
            // numericUpDownNetwork
            // 
            this.numericUpDownNetwork.Location = new System.Drawing.Point(253, 56);
            this.numericUpDownNetwork.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownNetwork.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownNetwork.Name = "numericUpDownNetwork";
            this.numericUpDownNetwork.Size = new System.Drawing.Size(72, 23);
            this.numericUpDownNetwork.TabIndex = 0;
            this.numericUpDownNetwork.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownNetwork.ValueChanged += new System.EventHandler(this.numericUpDownNetwork_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(331, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "s";
            // 
            // numericUpDownGame
            // 
            this.numericUpDownGame.Location = new System.Drawing.Point(253, 85);
            this.numericUpDownGame.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDownGame.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDownGame.Name = "numericUpDownGame";
            this.numericUpDownGame.Size = new System.Drawing.Size(72, 23);
            this.numericUpDownGame.TabIndex = 1;
            this.numericUpDownGame.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDownGame.ValueChanged += new System.EventHandler(this.numericUpDownGame_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(331, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(12, 15);
            this.label10.TabIndex = 13;
            this.label10.Text = "s";
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(12, 240);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(75, 23);
            this.buttonDisconnect.TabIndex = 3;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // buttonFreeze
            // 
            this.buttonFreeze.Location = new System.Drawing.Point(93, 240);
            this.buttonFreeze.Name = "buttonFreeze";
            this.buttonFreeze.Size = new System.Drawing.Size(75, 23);
            this.buttonFreeze.TabIndex = 4;
            this.buttonFreeze.Text = "Freeze";
            this.buttonFreeze.UseVisualStyleBackColor = true;
            this.buttonFreeze.Click += new System.EventHandler(this.buttonFreeze_Click);
            // 
            // listBoxInterface
            // 
            this.listBoxInterface.FormattingEnabled = true;
            this.listBoxInterface.ItemHeight = 15;
            this.listBoxInterface.Location = new System.Drawing.Point(12, 140);
            this.listBoxInterface.Name = "listBoxInterface";
            this.listBoxInterface.Size = new System.Drawing.Size(331, 94);
            this.listBoxInterface.TabIndex = 2;
            this.listBoxInterface.SelectedIndexChanged += new System.EventHandler(this.listBoxInterface_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(179, 15);
            this.label11.TabIndex = 17;
            this.label11.Text = "Network interface to disconnect:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 275);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.listBoxInterface);
            this.Controls.Add(this.buttonFreeze);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numericUpDownGame);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numericUpDownNetwork);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "GTA5 Tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNetwork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerGame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timerNetwork;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownNetwork;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownGame;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.Button buttonFreeze;
        private System.Windows.Forms.ListBox listBoxInterface;
        private System.Windows.Forms.Label label11;
    }
}

