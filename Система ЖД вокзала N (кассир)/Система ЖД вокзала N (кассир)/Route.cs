using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Система_ЖД_вокзала_N__Администратор_
{
    class Route
    {
        private string start_point_;
        private string destination_point_;
        private ushort number_of_places_;
        private string departue_time_;
        private string arrival_time_;
        public Route()
        {
            start_point_ = string.Empty;
            destination_point_ = string.Empty;
            number_of_places_ = 0;
            departue_time_ = string.Empty;
            arrival_time_ = string.Empty;
        }
        public Route(string start_point, string destination_point, ushort number_of_places, string departure_time, string arrival_time)
        {
            start_point_ = start_point;
            destination_point_ = destination_point;
            number_of_places_ = number_of_places;
            departue_time_ = departure_time;
            arrival_time_ = arrival_time;
        }
        public void SetStartPoint(string start_point)
        {
            start_point_ = start_point;
        }
        public void SetDestinationPoint(string destination_point)
        {
            destination_point_ = destination_point;
        }
        public void SetNumberOfPlaces(ushort number_of_places)
        {
            number_of_places_ = number_of_places;
        }
        public void SetDepatrureTime(string departure_time)
        {
            departue_time_ = departure_time;
        }
        public void SetArrivalTime(string arrival_time)
        {
            arrival_time_ = arrival_time;
        }
        public string GetStartPoint()
        {
            return start_point_;
        }
        public string GetDestinationPoint()
        {
            return destination_point_;
        }
        public ushort GetNumberOfPlaces()
        {
            return number_of_places_;
        }
        public string GetDepartureTime()
        {
            return departue_time_;
        }
        public string GetArrivalTime()
        {
            return arrival_time_;
        }
        public void AddToDatabase()
        {

        }
        public void RemoveFromDatabase()
        {

        }
        public void ConfirmUpdates()
        {

        }
    }
}
