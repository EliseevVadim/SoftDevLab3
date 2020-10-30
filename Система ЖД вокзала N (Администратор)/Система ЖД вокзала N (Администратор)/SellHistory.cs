using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Система_ЖД_вокзала_N__Администратор_
{
    public enum Action
    {
        Add, 
        Remove,
        Update
    }
    class SellHistory
    {
        private string dateTime_;
        private Action action_;
        private string workers_fio_;
        private string target_info_;
        public SellHistory(string dateTime, Action action, string workers_fio, string target_info)
        {
            dateTime_ = dateTime;
            action_ = action;
            workers_fio_ = workers_fio;
            target_info_ = target_info;
        }
        public string GetDateTime()
        {
            return dateTime_;
        }
        public Action GetAction()
        {
            return action_;
        }
        public string GetWorkersFIO()
        {
            return workers_fio_;
        }
        public string GetTargetInfo()
        {
            return target_info_;
        }
    }
}
