using EmployeeControl;
using StaffEmployee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ViewWPF.FormAddEmployee
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window, IAddEmployee
    {
        Employee employee;
  
        public DataGrid DataGridEmployee { get; set; }

        public AddEmployee(DataGrid dt) {
            InitializeComponent();
            DataGridEmployee = dt;

        }
     
        private void buttonAddContent_Click(object sender, RoutedEventArgs e) {
            AddEmployeeToData?.Invoke(GetContent(tBName, tBPlace, tBAge), EventArgs.Empty);
            /// <summary>
            /// Adding an Employee
            /// </summary>
        }

        private Employee GetContent(TextBox tBName, TextBox tBPlace, TextBox tBAge) {
            employee = new Employee();

            employee.Name = tBName.Text;
            employee.Place = tBPlace.Text;
            employee.Age = Convert.ToInt32(tBAge.Text);
            return employee;
        }
        
        public event EventHandler AddEmployeeToData;

        private void buttonCancel_Click(object sender, RoutedEventArgs e) {
            Hide();
        }
    }
}
