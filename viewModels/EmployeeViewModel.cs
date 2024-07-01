using System;
using System.Collections.Generic;
using System.ComponentModel;
using employee_management_app.Model;
using employee_management_app.Commands;
using System.Collections.ObjectModel;

namespace employee_management_app.viewModels
{
    internal class EmployeeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private EmployeeService ObjEmployeeService;
        public EmployeeViewModel()
        {
            ObjEmployeeService = new EmployeeService();
            LoadData(); // Initialize the employee list when the ViewModel is created
            currentEmployee = new Employee();
            saveCommand = new RelayCommand(save);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
        }

        private ObservableCollection<Employee> employeesList;
        public ObservableCollection<Employee> EmployeesList
        {
            get { return employeesList; }
            set
            {
                if (employeesList != value)
                {
                    employeesList = value;
                    OnPropertyChanged(nameof(EmployeesList));
                }
            }
        }

        private void LoadData()
        {
            EmployeesList = new ObservableCollection<Employee>(ObjEmployeeService.getAll());
        }

        private Employee currentEmployee;
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set
            {
                if (currentEmployee != value)
                {
                    currentEmployee = value;
                    OnPropertyChanged(nameof(CurrentEmployee));
                }
            }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                if (message != value)
                {
                    message = value;
                    OnPropertyChanged(nameof(Message));
                }
            }
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void save()
        {
            try
            {
                var IsSaved = ObjEmployeeService.Add(CurrentEmployee);
                LoadData();
                if (IsSaved)
                {
                    Message = "Employee saved";
                }
                else
                {
                    Message = "Save operation failed";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
        }
        public void Update()
        {
            try
            {
                var IsUpdated = ObjEmployeeService.Update(CurrentEmployee);
                if (IsUpdated)
                {
                    LoadData();
                }
                else
                {
                    Message = "employee updated";

                }
            }
            catch (Exception ex)
            {
                Message = "update operation failed";
            }
        }
        private RelayCommand deleteCommand;

        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
        }
        public void Delete()
        {
            try
            {
                var IsDelecte = ObjEmployeeService.Delete(currentEmployee.Id);
                if (IsDelecte)
                {
                    Message = "employee delected";
                    LoadData();
                }
                else
                {
                    Message = "delete operation failde";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
    }
}
