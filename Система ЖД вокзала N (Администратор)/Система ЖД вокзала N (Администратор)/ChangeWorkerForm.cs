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
    public partial class ChangeWorkerForm : Form
    {
        Worker worker;
        int code_ = 0;
        public ChangeWorkerForm(string FIO, string login, string password, string type, int code)
        {
            InitializeComponent();
            worker = new Worker(login, password, FIO, Worker.TypeFromString(type));
            code_ = code;
        }
        public ChangeWorkerForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ChangeWorkerForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = worker.GetLogin();
            textBox2.Text = worker.GetPassword();
            string[] mas = worker.GetFIO().Split(' ');
            textBox3.Text = mas[0];
            textBox4.Text = mas[1];
            textBox5.Text = mas[2];
            comboBox1.Text = Worker.StringFromType(worker.GetType());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || textBox5.Text == string.Empty || comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Ошибка ввода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    worker.SetLogin(textBox1.Text);
                    worker.SetPassword(textBox2.Text);
                    worker.SetFIO(textBox3.Text+" "+textBox4.Text+" "+textBox5.Text);
                    worker.SetType(Worker.TypeFromString(comboBox1.SelectedItem.ToString()));
                    worker.ConfirmUpdates(code_);
                    MessageBox.Show("Успех!", "Изменение информации о сотруднике", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
