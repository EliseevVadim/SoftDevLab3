using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Система_ЖД_вокзала_N__Администратор_
{
    public partial class DeleteWorkerForm : Form
    {
        string FIO_;
        public DeleteWorkerForm(string FIO)
        {
            InitializeComponent();
            FIO_ = FIO;
        }
        public DeleteWorkerForm()
        {
            InitializeComponent();
        }

        private void DeleteWorkerForm_Load(object sender, EventArgs e)
        {
            label1.Text = "Вы действительно хотите удалить сотрудника "+FIO_+"?";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
