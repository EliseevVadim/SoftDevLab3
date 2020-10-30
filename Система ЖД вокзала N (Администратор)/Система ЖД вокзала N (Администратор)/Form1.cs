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
    public partial class Form1 : Form
    {
        public static string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=AdminDB.mdb;";
        OleDbConnection connection;
        List<Worker> workers = new List<Worker>();
        List<Route> routes = new List<Route>();
        int pos = 0;
        int rpos = 0;
        public Form1()
        {
            InitializeComponent();
            connection = new OleDbConnection(connectionString);
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // создание рейса
        private void button4_Click(object sender, EventArgs e)
        {
            AddRouteForm addRouteForm = new AddRouteForm();
            if (addRouteForm.ShowDialog() == DialogResult.OK)
            {
                this.routesTableAdapter.Fill(this.adminDBDataSet1.Routes);
                Route.FromDBToList(routes, connection);
            }
        }
        // изменение рейса
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeRouteForm changeRouteForm = new ChangeRouteForm(routes[rpos].GetStartPoint(), routes[rpos].GetDestinationPoint(), routes[rpos].GetDepartureTime(), routes[rpos].GetArrivalTime(), routes[rpos].GetNumberOfPlacesCoupe(), routes[rpos].GetNumberOfPlacesReserved(), int.Parse(dataGridView1[0, rpos].Value.ToString()));
                if (changeRouteForm.ShowDialog() == DialogResult.OK)
                {
                    this.routesTableAdapter.Fill(this.adminDBDataSet1.Routes);
                    Route.FromDBToList(routes, connection);
                }
            }
            catch
            {

            }
        }
        // добавить сотрудника
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                AddWorkerForm addWorkerForm = new AddWorkerForm();
                if (addWorkerForm.ShowDialog() == DialogResult.OK)
                {
                    this.workersTableAdapter.Fill(this.adminDBDataSet.Workers);
                    Worker.FromDBToList(workers, connection);
                }
            }
            catch
            {

            }
        }
        // изменить информацию о сотруднике
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeWorkerForm changeWorkerForm = new ChangeWorkerForm(workers[pos].GetFIO(), workers[pos].GetLogin(), workers[pos].GetPassword(), workers[pos].GetType().ToString(), int.Parse(dataGridView2[0, pos].Value.ToString()));
                if (changeWorkerForm.ShowDialog() == DialogResult.OK)
                {
                    this.workersTableAdapter.Fill(this.adminDBDataSet.Workers);
                    Worker.FromDBToList(workers, connection);
                }
            }
            catch
            {

            }
        }
        // удалить рейс
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteRouteForm deleteRouteForm = new DeleteRouteForm(routes[rpos].GetStartPoint(), routes[rpos].GetDestinationPoint());
                if (deleteRouteForm.ShowDialog() == DialogResult.OK)
                {
                    routes[pos].RemoveFromDatabase(int.Parse(dataGridView1[0, rpos].Value.ToString()));
                    this.routesTableAdapter.Fill(this.adminDBDataSet1.Routes);
                    Route.FromDBToList(routes, connection);
                }
            }
            catch
            {

            }
        }
        // чистим текстбокс
        private void button1_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }
        // выгружаем лог-файл
        private void button3_Click(object sender, EventArgs e)
        {
            Logger logger = new Logger();
            logger.OutLogToScreen(richTextBox1);
        }
        // удаляем лог-файл
        private void button2_Click(object sender, EventArgs e)
        {
            Logger logger = new Logger();
            logger.DeleteLogFile();
        }
        // удаляем сотрудника
        private void button9_Click_1(object sender, EventArgs e)
        {
            try
            {
                DeleteWorkerForm deleteWorkerForm = new DeleteWorkerForm(workers[pos].GetFIO());
                if (deleteWorkerForm.ShowDialog() == DialogResult.OK)
                {
                    workers[pos].RemoveFromDatabase(int.Parse(dataGridView2[0, pos].Value.ToString()));
                    this.workersTableAdapter.Fill(this.adminDBDataSet.Workers);
                    Worker.FromDBToList(workers, connection);
                }
            }
            catch 
            {
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'adminDBDataSet1.Routes' table. You can move, or remove it, as needed.
            this.routesTableAdapter.Fill(this.adminDBDataSet1.Routes);
            // TODO: This line of code loads data into the 'adminDBDataSet.Workers' table. You can move, or remove it, as needed.
            this.workersTableAdapter.Fill(this.adminDBDataSet.Workers);
            // TODO: This line of code loads data into the 'adminDBDataSet.Workers' table. You can move, or remove it, as needed.
            //this.workersTableAdapter.Fill(this.adminDBDataSet.Workers);
            // TODO: This line of code loads data into the 'adminDBDataSet1.Routes' table. You can move, or remove it, as needed.
            //this.routesTableAdapter.Fill(this.adminDBDataSet1.Routes);
            // TODO: This line of code loads data into the 'adminDBDataSet.Workers' table. You can move, or remove it, as needed.
            //this.workersTableAdapter.Fill(this.adminDBDataSet.Workers);
            Worker.FromDBToList(workers, connection);
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            pos = e.RowIndex;          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rpos = e.RowIndex;
        }
    }
}