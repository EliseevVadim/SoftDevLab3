using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Система_ЖД_вокзала_N__Администратор_
{
    public partial class AddWorkerForm : Form
    {
        public static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=AdminDB.mdb;";
        OleDbConnection connection;
        public AddWorkerForm()
        {
            InitializeComponent();
            connection = new OleDbConnection(connectionString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text==string.Empty|| textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty || textBox5.Text == string.Empty || comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Ошибка ввода!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    connection.Open();
                    Worker worker = new Worker(textBox1.Text, textBox2.Text, textBox3.Text+" "+textBox4.Text+" "+textBox5.Text, Worker.TypeFromString((comboBox1.SelectedItem.ToString())));
                    worker.AddToDatabase();
                    MessageBox.Show("Успех!", "Добавление нового сотрудника", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    Close();                   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddWorkerForm_Load(object sender, EventArgs e)
        {
            //connection.Open();
        }

        private void AddWorkerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //connection.Close();
        }
    }
}
