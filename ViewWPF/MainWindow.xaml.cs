using EmployeeControl;
using StaffEmployee;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using ViewWPF.FormAddEmployee;

namespace ViewWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        private CollectionView collectionView;
        AddEmployee formAdd;

        public MainWindow() {
            InitializeComponent();
            formAdd = new AddEmployee(dataGridEmploes);
            DataContext = new ApplicationEmployeeControl(this, formAdd);
            dataGridEmploes.Items.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));

        }

        //Keeps track of Text Box changes
        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e) {
            CollectionViewSource.GetDefaultView(dataGridEmploes.ItemsSource).Refresh();

        }

        // Data Grid Filling

        // Track changes in the Date Grid
        private void Employees_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e) {
            switch(e.ListChangedType)
            {
                case System.ComponentModel.ListChangedType.Reset:
                break;
                case System.ComponentModel.ListChangedType.ItemAdded:
                break;
                case System.ComponentModel.ListChangedType.ItemDeleted:
                break;
                case System.ComponentModel.ListChangedType.ItemMoved:
                break;
                case System.ComponentModel.ListChangedType.ItemChanged:
                break;
                case System.ComponentModel.ListChangedType.PropertyDescriptorAdded:
                break;
                case System.ComponentModel.ListChangedType.PropertyDescriptorDeleted:
                break;
                case System.ComponentModel.ListChangedType.PropertyDescriptorChanged:
                break;
                default:
                break;
            }
        }

        public event EventHandler DeleteSelectItemSource;

        // throwing events

        private void Button_Click_CopySelectItemSource(object sender, RoutedEventArgs e) {
            formAdd.Show();
        }

        private void Button_Click_DeleteSelectItemSource(object sender, RoutedEventArgs e) {
            DeleteSelectItemSource?.Invoke(dataGridEmploes, EventArgs.Empty);
        }

        #region Фильтры

        private bool UserFilterName(object item) {
            if(String.IsNullOrEmpty(filterName.Text))
                return true;
            else
                return ((item as Employee).Name.Contains(filterName.Text));
        }

        private void filterName_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e) {

            collectionView = (CollectionView)CollectionViewSource.GetDefaultView(dataGridEmploes.ItemsSource);
            collectionView.Filter = UserFilterName;
            //Filter by name
        }

        private bool UserFilterPlace(object item) {
            if(String.IsNullOrEmpty(filterPlace.Text))
                return true;
            else
                return ((item as Employee).Place.Contains(filterPlace.Text));
        }

        private void filterPlace_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e) {
            collectionView = (CollectionView)CollectionViewSource.GetDefaultView(dataGridEmploes.ItemsSource);
            collectionView.Filter = UserFilterPlace;
            //Filter by place
        }

        private bool UserFilterAge(object item) {
            if(String.IsNullOrEmpty(filterDateBirth.Text))
                return true;
            else
                return ((item as Employee).Age.ToString().Contains(filterDateBirth.Text));
        }

        private void filterDateBirth_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e) {
            collectionView = (CollectionView)CollectionViewSource.GetDefaultView(dataGridEmploes.ItemsSource);
            collectionView.Filter = UserFilterAge;
            //Filter by age
        }
        #endregion

    }
}
