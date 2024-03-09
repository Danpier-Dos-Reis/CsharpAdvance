namespace LinqTestSQLSERVER
{
    partial class MainForm
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
            dgMain = new DataGridView();
            btnTestDBConnection = new Button();
            btnSellsPerArticle = new Button();
            btnAVLeftFV = new Button();
            ((System.ComponentModel.ISupportInitialize)dgMain).BeginInit();
            SuspendLayout();
            // 
            // dgMain
            // 
            dgMain.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgMain.Dock = DockStyle.Bottom;
            dgMain.Location = new Point(0, 201);
            dgMain.Name = "dgMain";
            dgMain.RowHeadersWidth = 62;
            dgMain.Size = new Size(940, 313);
            dgMain.TabIndex = 0;
            // 
            // btnTestDBConnection
            // 
            btnTestDBConnection.BackColor = Color.PaleGreen;
            btnTestDBConnection.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTestDBConnection.Location = new Point(28, 22);
            btnTestDBConnection.Name = "btnTestDBConnection";
            btnTestDBConnection.Size = new Size(234, 73);
            btnTestDBConnection.TabIndex = 1;
            btnTestDBConnection.Text = "TestDBConnection";
            btnTestDBConnection.UseVisualStyleBackColor = false;
            btnTestDBConnection.Click += btnTestDBConnection_Click;
            // 
            // btnSellsPerArticle
            // 
            btnSellsPerArticle.BackColor = Color.Cyan;
            btnSellsPerArticle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSellsPerArticle.Location = new Point(28, 115);
            btnSellsPerArticle.Name = "btnSellsPerArticle";
            btnSellsPerArticle.Size = new Size(234, 73);
            btnSellsPerArticle.TabIndex = 2;
            btnSellsPerArticle.Text = "SellsPerArticle";
            btnSellsPerArticle.UseVisualStyleBackColor = false;
            btnSellsPerArticle.Click += btnSellsPerArticle_Click;
            // 
            // btnAVLeftFV
            // 
            btnAVLeftFV.BackColor = Color.Salmon;
            btnAVLeftFV.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAVLeftFV.Location = new Point(278, 22);
            btnAVLeftFV.Name = "btnAVLeftFV";
            btnAVLeftFV.Size = new Size(240, 166);
            btnAVLeftFV.TabIndex = 3;
            btnAVLeftFV.Text = "AlbaranesVenta Left FacturasVenta";
            btnAVLeftFV.UseVisualStyleBackColor = false;
            btnAVLeftFV.Click += btnAVLeftFV_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 514);
            Controls.Add(btnAVLeftFV);
            Controls.Add(btnSellsPerArticle);
            Controls.Add(btnTestDBConnection);
            Controls.Add(dgMain);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dgMain).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgMain;
        private Button btnTestDBConnection;
        private Button btnSellsPerArticle;
        private Button btnAVLeftFV;
    }
}