using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqTestSQLSERVER
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnTestDBConnection_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();
            if (controller.TestDBConection()) { MessageBox.Show("Connection Successfully"); }
            else { MessageBox.Show("Error Connecting To DataBase"); }
        }

        private void btnSellsPerArticle_Click(object sender, EventArgs e)
        {
            IEnumerable<object> table = new Controller().GetSellsPerArticle();
            dgMain.DataSource = table.ToList(); dgMain.Refresh();
        }

        private void btnAVLeftFV_Click(object sender, EventArgs e)
        {
            IEnumerable<object> table = new Controller().GetAVLeftFV();
            dgMain.DataSource = table.ToList(); dgMain.Refresh();
        }
    }
}
