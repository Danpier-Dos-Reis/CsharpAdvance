namespace MyApp
{
    partial class MainForm
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
            btnOpenDebugReader = new Button();
            btnError = new Button();
            btnClearLog = new Button();
            SuspendLayout();
            // 
            // btnOpenDebugReader
            // 
            btnOpenDebugReader.BackColor = Color.White;
            btnOpenDebugReader.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOpenDebugReader.Location = new Point(12, 12);
            btnOpenDebugReader.Name = "btnOpenDebugReader";
            btnOpenDebugReader.Size = new Size(165, 87);
            btnOpenDebugReader.TabIndex = 0;
            btnOpenDebugReader.Text = "Open Debug Reader";
            btnOpenDebugReader.UseVisualStyleBackColor = false;
            btnOpenDebugReader.Click += btnOpenDebugReader_Click;
            // 
            // btnError
            // 
            btnError.BackColor = Color.FromArgb(192, 0, 0);
            btnError.Font = new Font("Times New Roman", 24F);
            btnError.ForeColor = Color.FromArgb(255, 192, 192);
            btnError.Location = new Point(205, 120);
            btnError.Name = "btnError";
            btnError.Size = new Size(386, 162);
            btnError.TabIndex = 2;
            btnError.Text = "Generate Error";
            btnError.UseVisualStyleBackColor = false;
            btnError.Click += btnError_Click;
            // 
            // btnClearLog
            // 
            btnClearLog.BackColor = Color.SteelBlue;
            btnClearLog.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClearLog.ForeColor = Color.White;
            btnClearLog.Location = new Point(12, 136);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(165, 87);
            btnClearLog.TabIndex = 1;
            btnClearLog.Text = "Clear Log";
            btnClearLog.UseVisualStyleBackColor = false;
            btnClearLog.Click += btnClearLog_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(800, 450);
            Controls.Add(btnClearLog);
            Controls.Add(btnError);
            Controls.Add(btnOpenDebugReader);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btnOpenDebugReader;
        private Button btnError;
        private Button btnClearLog;
    }
}
