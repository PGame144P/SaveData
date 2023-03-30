using System;
using System.Windows;
using System.Windows.Controls;

namespace SaveData
{

    public partial class DepartmentsEditPage : Page
    {
        public Отделы _currentDepartment = new Отделы();

        public DepartmentsEditPage(Отделы selectedDepartment)
        {
            InitializeComponent();
            if (selectedDepartment != null)
                _currentDepartment = selectedDepartment;

            DataContext = _currentDepartment;
     }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppConnect.modelOdb.SaveChanges();

                MessageBox.Show("Данные успешно сохранены!", "Успешное сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка сохранения данных!", "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("DepartmentsDataGrid.xaml", UriKind.Relative));
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("DepartmentsDataGrid.xaml", UriKind.Relative));
        }
    }
}
