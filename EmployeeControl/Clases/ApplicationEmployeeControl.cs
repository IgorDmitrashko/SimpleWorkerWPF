using StaffEmployee;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace EmployeeControl
{
    public class ApplicationEmployeeControl : INotifyPropertyChanged {
        IMainWindow _view;
        IAddEmployee _add;

        public ApplicationEmployeeControl() {

        }
        public ApplicationEmployeeControl(IMainWindow view, IAddEmployee add) {
            _view = view;
            _add = add;
            _view.DeleteSelectItemSource += DeleteSelectItemSource;
            
            _add.AddEmployeeToData += AddEmployeeInItemSource;

            //Test Data
            Employees = new ObservableCollection<Employee>
            {
                new Employee{ Name = "Иван", Place = "Руководитель отдела разработки", Age = 36, SetToWork= true},
                new Employee{ Name = "Николай", Place = "Ведущий разработчик", Age = 31},
                new Employee{ Name = "Евгений", Place = "Разработчик", Age = 30},
                new Employee{ Name = "Константин", Place = "Разработчик", Age = 27},
                new Employee{ Name = "Сергей", Place = "Стажер", Age = 23,SetToWork = true},
            };
            
        }

        private Employee selectedEmployee;
        public Employee SelectedEmployee {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                selectedEmployee.СurrentDate = DateTime.Now.ToString("HH:mm:ss");
                OnPropertyChanged("Worker");
            }
        }

        private RelayCommand addCommand;

        public RelayCommand AddCommand {//Не понимаю где ошибся, не работает данная команда. Реализовал добавление через метод AddEmployeeInItemSource()
            get {return addCommand??
                    (addCommand = new RelayCommand(obj => 
                    {
                        Employee employee = new Employee();
                        Employees.Insert(0, employee);
                        SelectedEmployee = employee;
                    }));
            }
        }
            
       
        public ObservableCollection<Employee> Employees { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #region Добавление удаление записей

        private void AddEmployeeInItemSource(object sender, EventArgs e) {            
            Employee em = (Employee)sender;
            Employees.Add(em);
        }

        private void DeleteSelectItemSource(object sender, EventArgs e) {
            DataGrid list = (DataGrid)sender;
            if(list.SelectedItem != null)
            {
                Employee ep = (Employee)list.SelectedItems[0];
                ObservableCollection<Employee> data = (ObservableCollection<Employee>)list.ItemsSource;
                data.Remove(ep);               
            }
        }
        #endregion
    }
}
