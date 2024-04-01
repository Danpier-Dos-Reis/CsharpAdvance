namespace DebugViewer
{
    partial class DebugView
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
            menuStrip1 = new MenuStrip();
            rtxtboxMain = new RichTextBox();
            MainMenu = new MenuStrip();
            saveLogToolStripMenuItem = new ToolStripMenuItem();
            clearLogToolStripMenuItem = new ToolStripMenuItem();
            listenFileToolStripMenuItem = new ToolStripMenuItem();
            MainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Location = new Point(0, 40);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(839, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // rtxtboxMain
            // 
            rtxtboxMain.BackColor = Color.LightBlue;
            rtxtboxMain.Dock = DockStyle.Bottom;
            rtxtboxMain.ForeColor = Color.Black;
            rtxtboxMain.Location = new Point(0, 40);
            rtxtboxMain.Name = "rtxtboxMain";
            rtxtboxMain.ReadOnly = true;
            rtxtboxMain.Size = new Size(839, 585);
            rtxtboxMain.TabIndex = 1;
            rtxtboxMain.Text = "";
            // 
            // MainMenu
            // 
            MainMenu.BackColor = Color.Black;
            MainMenu.Font = new Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MainMenu.ImageScalingSize = new Size(24, 24);
            MainMenu.Items.AddRange(new ToolStripItem[] { saveLogToolStripMenuItem, clearLogToolStripMenuItem, listenFileToolStripMenuItem });
            MainMenu.Location = new Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Size = new Size(839, 40);
            MainMenu.TabIndex = 2;
            MainMenu.Text = "menuStrip2";
            // 
            // saveLogToolStripMenuItem
            // 
            saveLogToolStripMenuItem.BackColor = Color.Transparent;
            saveLogToolStripMenuItem.ForeColor = Color.White;
            saveLogToolStripMenuItem.Name = "saveLogToolStripMenuItem";
            saveLogToolStripMenuItem.Size = new Size(140, 36);
            saveLogToolStripMenuItem.Text = "Save Log";
            saveLogToolStripMenuItem.Click += saveLogToolStripMenuItem_Click;
            // 
            // clearLogToolStripMenuItem
            // 
            clearLogToolStripMenuItem.BackColor = Color.Transparent;
            clearLogToolStripMenuItem.ForeColor = Color.White;
            clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            clearLogToolStripMenuItem.Size = new Size(149, 36);
            clearLogToolStripMenuItem.Text = "Clear Log";
            clearLogToolStripMenuItem.Click += clearLogToolStripMenuItem_Click;
            // 
            // listenFileToolStripMenuItem
            // 
            listenFileToolStripMenuItem.BackColor = Color.Transparent;
            listenFileToolStripMenuItem.ForeColor = Color.White;
            listenFileToolStripMenuItem.Name = "listenFileToolStripMenuItem";
            listenFileToolStripMenuItem.Size = new Size(158, 36);
            listenFileToolStripMenuItem.Text = "Listen File";
            listenFileToolStripMenuItem.Click += listenFileToolStripMenuItem_Click;
            // 
            // DebugView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 625);
            Controls.Add(rtxtboxMain);
            Controls.Add(menuStrip1);
            Controls.Add(MainMenu);
            MainMenuStrip = menuStrip1;
            Name = "DebugView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DebugView";
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private RichTextBox rtxtboxMain;
        private MenuStrip MainMenu;
        private ToolStripMenuItem saveLogToolStripMenuItem;
        private ToolStripMenuItem clearLogToolStripMenuItem;
        private ToolStripMenuItem listenFileToolStripMenuItem;
    }
}