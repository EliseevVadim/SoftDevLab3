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
    public partial class ChangeRouteForm : Form
    {
        int code_ = 0;
        Route route;

        private void ChangeRouteForm_Load(object sender, EventArgs e)
        {
            List<string> vals = InitValues();
            domainUpDown1.Items.AddRange(vals);
            domainUpDown2.Items.AddRange(vals);
            textBox1.Text = route.GetStartPoint();
            textBox2.Text = route.GetDestinationPoint();
            textBox3.Text = route.GetNumberOfPlacesReserved().ToString();
            textBox4.Text = route.GetNumberOfPlacesCoupe().ToString();
            domainUpDown1.Text = route.GetDepartureTime().Remove(0,10);
            domainUpDown2.Text = route.GetArrivalTime().Remove(0,10);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                route.SetStartPoint(textBox1.Text);
                route.SetDestinationPoint(textBox2.Text);
                route.SetNumberOfPlacesReserved(ushort.Parse(textBox3.Text));
                route.SetNumberOfPlacesCoupe(ushort.Parse(textBox4.Text));
                route.SetDepatrureTime(monthCalendar1.SelectionStart.Date.ToShortDateString() + " " + domainUpDown1.Text);
                route.SetArrivalTime(monthCalendar2.SelectionStart.Date.ToShortDateString() + " " + domainUpDown2.Text);
                route.ConfirmUpdates(code_);
                MessageBox.Show("Успех!", "Изменение информации о рейсе", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ChangeRouteForm(string st, string end, string dt, string at, ushort c, ushort r, int code)
        {
            InitializeComponent();
            route = new Route(st, end, c, r, dt, at);
            code_ = code;
        }
        public ChangeRouteForm()
        {
            InitializeComponent();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
