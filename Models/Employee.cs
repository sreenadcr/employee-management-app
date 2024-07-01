using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace employee_management_app.Model
{
    public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropetyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropetyChanged("Id"); }
        }

        private string name ;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropetyChanged("Name"); }
        }

        private string job_Title ;

        public string Job_Title
        {
            get { return job_Title; }
            set { job_Title = value; OnPropetyChanged("Job_Title"); }
        }

        private string department_Name;

        public string Department_Name
        {
            get { return department_Name; }
            set { department_Name = value; OnPropetyChanged("Department_Name"); }
        }
    }
}
