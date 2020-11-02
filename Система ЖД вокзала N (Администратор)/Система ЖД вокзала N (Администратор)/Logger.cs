using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Система_ЖД_вокзала_N__Администратор_
{
    class Logger
    {
        /// <summary>
        /// Создание лог-файла
        /// </summary>
        public void CreateLogFile()
        {
            File.CreateText(Environment.CurrentDirectory + @"/logs/log.log");
        }
        /// <summary>
        /// Удаление лог файла
        /// </summary>
        public void DeleteLogFile()
        {
            if (File.Exists(Environment.CurrentDirectory + @"/logs/log.log"))
            {
                File.Delete(Environment.CurrentDirectory + @"/logs/log.log");
            }
        }
        /// <summary>
        /// Добавление записи в лог
        /// </summary>
        /// <param name="sellHistory"></param>
        public void AddRecordToLog(SellHistory sellHistory)
        {
            if (File.Exists(Environment.CurrentDirectory + @"/logs/log.log"))
            {
                StreamWriter streamWriter = File.AppendText(Environment.CurrentDirectory + @"/logs/log.log");
                streamWriter.WriteLine(sellHistory.GetDateTime()+"/ " + sellHistory.GetAction().ToString()+ "/ " + sellHistory.GetWorkersFIO() + "/ " + sellHistory.GetTargetInfo());
                streamWriter.Flush();
                streamWriter.Close();
            }
            else
            {
                File.CreateText(Environment.CurrentDirectory + @"/logs/log.log");
                StreamWriter streamWriter = File.AppendText(Environment.CurrentDirectory + @"/logs/log.log");
                streamWriter.WriteLine(sellHistory.GetDateTime() + "/ " + sellHistory.GetAction().ToString() + "/ " + sellHistory.GetWorkersFIO() + "/ " + sellHistory.GetTargetInfo());
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
        /// <summary>
        /// Вывод лога на экран
        /// </summary>
        /// <param name="richTextBox"></param>
        public void OutLogToScreen(RichTextBox richTextBox)
        {
            string[] mas = File.ReadAllLines(Environment.CurrentDirectory + @"/logs/log.log");
            for (int i=0; i<mas.Length; i++)
            {
                richTextBox.Text += (mas[i]+"\n");
            }
        }
    }
}
