using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Система_ЖД_вокзала_N__Администратор_
{
    public enum Type
    {
        Admin,
        User
    }
    class Worker
    {
        private string login_;
        private string password_;
        private string FIO_;
        private Type type_;
        #region Конструкторы
        public Worker()
        {
            login_ = string.Empty;
            password_ = string.Empty;
            FIO_ = string.Empty;
            type_ = Type.User;
        }
        public Worker(string login, string password, string FIO, Type type)
        {
            login_ = login;
            password_ = password;
            FIO_ = FIO;
            type_ = type;            
        }
        #endregion
        #region Сеттеры
        public void SetLogin(string login)
        {
            login_ = login;
        }
        public void SetPassword(string password)
        {
            password_ = password;
        }
        public void SetFIO(string FIO)
        {
            FIO_ = FIO;
        }
        public void SetType(Type type)
        {
            type_ = type;
        }
        #endregion
        #region Геттеры
        public string GetLogin()
        {
            return login_;
        }
        public string GetPassword()
        {
            return password_;
        }
        public string GetFIO()
        {
            return FIO_;
        }
        public Type GetType()
        {
            return type_;
        }
        #endregion
        #region Конвертеры
        public static Type TypeFromString(string s)
        {
            switch (s)
            {
                case "Администратор":
                case "Admin":
                    return Type.Admin;
                case "Кассир":
                case "User":
                    return Type.User;
                default:
                    throw new Exception();
            }
        }
        public static string StringFromType(Type type)
        {
            switch (type)
            {
                case Type.Admin:
                    return "Администратор";
                case Type.User:
                    return "Кассир";
                default:
                    return null;
            }
        }
        #endregion
        #region Работа с БД
        public void AddToDatabase()
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=AdminDB.mdb;";
            OleDbConnection connection;
            connection = new OleDbConnection(connectionString);
            connection.Open();            
            string request = "INSERT INTO Workers (ФИО, Логин, Пароль, Тип) VALUES ('" + FIO_ + "', '" + login_ + "', '" + password_ + "', '" + type_.ToString() + "')";
            OleDbCommand oleDbCommand = new OleDbCommand(request, connection);
            oleDbCommand.ExecuteNonQuery();
            connection.Close();
        }
        public void RemoveFromDatabase(int code)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=AdminDB.mdb;";
            OleDbConnection connection;
            connection = new OleDbConnection(connectionString);
            connection.Open();
            string request = $"DELETE FROM Workers WHERE Код={code}";
            OleDbCommand oleDbCommand = new OleDbCommand(request, connection);
            oleDbCommand.ExecuteNonQuery();
            connection.Close();
        }
        public void ConfirmUpdates(int code)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=AdminDB.mdb;";
            OleDbConnection connection;
            connection = new OleDbConnection(connectionString);
            connection.Open();
            string request = $"UPDATE Workers SET ФИО = \"{FIO_}\", Логин = = \"{login_}\", Пароль = = \"{password_}\", Тип = = \"{type_.ToString()}\" WHERE Код = {code}";
            OleDbCommand oleDbCommand = new OleDbCommand(request, connection);
            oleDbCommand.ExecuteNonQuery();
            connection.Close();
        }
        public static void FromDBToList(List<Worker> workers, OleDbConnection connection)
        {
            workers.Clear();
            string request = "SELECT ФИО, Логин, Пароль, Тип FROM Workers";
            connection.Open();
            OleDbCommand command = new OleDbCommand(request, connection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                workers.Add(new Worker(reader[1].ToString(), reader[2].ToString(), reader[0].ToString(), Worker.TypeFromString(reader[3].ToString())));
            }
            connection.Close();
        }
        #endregion
    }
}
