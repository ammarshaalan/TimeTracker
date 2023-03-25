using System;

namespace TimeTracker   
{
    public class EmployeeViewModel
    {
        public string Name { get; set; }
        public double TotalTimeWorked
        {
            get { return _totalTimeWorked; }
            set { _totalTimeWorked = Math.Round(value, 2); }
        }

        private double _totalTimeWorked;
    }
}
