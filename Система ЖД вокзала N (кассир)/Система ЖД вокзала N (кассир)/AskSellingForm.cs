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
    public partial class AskSellingForm : Form
    {
        public AskSellingForm()
        {
            InitializeComponent();
        }

        private void AskSellingForm_Load(object sender, EventArgs e)
        {
            label1.Text = "Действительно ли Вы хотите продать билет...";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
