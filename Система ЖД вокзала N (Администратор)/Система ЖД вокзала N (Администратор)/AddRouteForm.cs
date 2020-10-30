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
    public partial class AddRouteForm : Form
    {
        public AddRouteForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty)
                {
                    MessageBox.Show("Ошибка ввода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Route route = new Route(textBox1.Text, textBox2.Text, ushort.Parse(textBox4.Text), ushort.Parse(textBox3.Text), monthCalendar1.SelectionStart.Date.ToShortDateString() + " " + domainUpDown1.Text, monthCalendar2.SelectionStart.Date.ToShortDateString() + " " + domainUpDown2.Text);
                    route.AddToDatabase();
                    MessageBox.Show("Успех!", "Добавление нового рейса", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddRouteForm_Load(object sender, EventArgs e)
        {
            List<string> vals = InitValues();
            domainUpDown1.Items.AddRange(vals);
            domainUpDown2.Items.AddRange(vals);
        }
        public List<string> InitValues()
        {
            List<string> values = new List<string>();
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    if (i < 10 && j < 10)
                    {
                        values.Add($"0{i}:0{j}");
                    }
                    else if (i < 10 && j >= 10)
                    {
                        values.Add($"0{i}:{j}");
                    }
                    else if (i >= 10 && j < 10)
                    {
                        values.Add($"{i}:0{j}");
                    }
                    else
                    {
                        values.Add($"{i}:{j}");
                    }
                }
            }
            return values;
        }
        // закрываем форму
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
