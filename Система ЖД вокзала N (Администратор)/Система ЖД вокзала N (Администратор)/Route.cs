using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Система_ЖД_вокзала_N__Администратор_
{
    class Route
    {
        private string start_point_;
        private string destination_point_;
        private ushort number_of_places_coupe_;
        private ushort number_of_places_reserved_;
        private string departue_time_;
        private string arrival_time_;
        #region Конструкторы
        public Route()
        {
            start_point_ = string.Empty;
            destination_point_ = string.Empty;
            number_of_places_coupe_ = 0;
            number_of_places_reserved_ = 0;
            departue_time_ = string.Empty;
            arrival_time_ = string.Empty;
        }
        public Route(string start_point, string destination_point, ushort number_of_places_coupe, ushort number_of_places_reserved, string departure_time, string arrival_time)
        {
            start_point_ = start_point;
            destination_point_ = destination_point;
            number_of_places_reserved_ = number_of_places_reserved;
            number_of_places_coupe_ = number_of_places_coupe;
            departue_time_ = departure_time;
            arrival_time_ = arrival_time;
        }
        #endregion
        #region Сеттеры
        public void SetStartPoint(string start_point)
        {
            start_point_ = start_point;
        }
        public void SetNumberOfPlacesCoupe(ushort number_of_places_coupe)
        {
            number_of_places_coupe_ = number_of_places_coupe;
        }
        public void SetDestinationPoint(string destination_point)
        {
            destination_point_ = destination_point;
        }
        public void SetNumberOfPlacesReserved(ushort number_of_places_reserved)
        {
            number_of_places_reserved_ = number_of_places_reserved;
        }
        public void SetDepatrureTime(string departure_time)
        {
            departue_time_ = departure_time;
        }
        public void SetArrivalTime(string arrival_time)
        {
            arrival_time_ = arrival_time;
        }
        #endregion
        #region Геттеры
        public string GetStartPoint()
        {
            return start_point_;
        }
        public string GetDestinationPoint()
        {
            return destination_point_;
        }
        public ushort GetNumberOfPlacesReserved()
        {
            return number_of_places_reserved_;
        }
        public ushort GetNumberOfPlacesCoupe()
        {
            return number_of_places_coupe_;
        }
        public string GetDepartureTime()
        {
            return departue_time_;
        }
        public string GetArrivalTime()
        {
            return arrival_time_;
        }
        #endregion
        #region Работа с БД
        /// <summary>
        /// Добавление в БД
        /// </summary>
        public void AddToDatabase()
        {
            try
            {
                string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=AdminDB.mdb;";
                OleDbConnection connection;
                connection = new OleDbConnection(connectionString);
                connection.Open();
                string request = $"INSERT INTO Routes (Место_отправления, Место_прибытия, Плацкарт, Купе, Время_отправления, Время_прибытия) VALUES ('{start_point_}', '{destination_point_}', {number_of_places_reserved_}, {number_of_places_coupe_}, '{departue_time_}', '{arrival_time_}')";
                OleDbCommand oleDbCommand = new OleDbCommand(request, connection);
                oleDbCommand.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {

            }
        }
        /// <summary>
        /// Удаление из БД
        /// </summary>
        /// <param name="code"></param>
        public void RemoveFromDatabase(int code)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=AdminDB.mdb;";
            OleDbConnection connection;
            connection = new OleDbConnection(connectionString);
            connection.Open();
            string request = $"DELETE FROM Routes WHERE Код={code}";
            OleDbCommand oleDbCommand = new OleDbCommand(request, connection);
            oleDbCommand.ExecuteNonQuery();
            connection.Close();
        }
        /// <summary>
        /// Обновление в БД
        /// </summary>
        /// <param name="code"></param>
        public void ConfirmUpdates(int code)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=AdminDB.mdb;";
            OleDbConnection connection;
            connection = new OleDbConnection(connectionString);
            connection.Open();
            string request = $"UPDATE Routes SET Место_отправления = \"{start_point_}\", Место_прибытия = \"{destination_point_}\", Плацкарт = {number_of_places_reserved_}, Купе = {number_of_places_coupe_}, Время_отправления = \"{departue_time_}\", Время_прибытия = \"{arrival_time_}\" WHERE Код = {code}";
            OleDbCommand oleDbCommand = new OleDbCommand(request, connection);
            oleDbCommand.ExecuteNonQuery();
            connection.Close();
        }
        /// <summary>
        /// Перенос из БД в вектор объектов класса 
        /// </summary>
        /// <param name="routes"></param>
        /// <param name="connection"></param>
        public static void FromDBToList(List<Route> routes, OleDbConnection connection)
        {
            routes.Clear();
            string request = "SELECT Место_отправления, Место_прибытия, Купе, Плацкарт, Время_отправления, Время_прибытия FROM Routes";
            connection.Open();
            OleDbCommand command = new OleDbCommand(request, connection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                routes.Add(new Route(reader[0].ToString(), reader[1].ToString(), ushort.Parse(reader[2].ToString()), ushort.Parse(reader[3].ToString()), reader[4].ToString(), reader[5].ToString()));
            }
            connection.Close();
        }
        #endregion
    }
}
