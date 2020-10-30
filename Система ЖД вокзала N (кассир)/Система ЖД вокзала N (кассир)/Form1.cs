using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Система_ЖД_вокзала_N__кассир_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // возврат билета
        private void button2_Click(object sender, EventArgs e)
        {
            AskReturningForm askReturningForm = new AskReturningForm();
            askReturningForm.ShowDialog();
        }
        // продажа билета
        private void button1_Click(object sender, EventArgs e)
        {
            AskSellingForm askSellingForm = new AskSellingForm();
            askSellingForm.ShowDialog();
        }
    }
}
