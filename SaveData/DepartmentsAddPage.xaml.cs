using System;
using System.Windows;
using System.Windows.Controls;

namespace SaveData
{
    /// <summary>
    /// Interaction logic for DepartmentsAddPage.xaml
    /// </summary>
    public partial class DepartmentsAddPage : Page
    {
        public DepartmentsAddPage()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var newDepartement = new Отделы()
            {
                Наименование_отдела = departmentName.Text,
                Табельный_номер = int.Parse(departmentNumber.Text)
            };

            try
            {
                AppConnect.modelOdb.Отделы.Add(newDepartement);
                AppConnect.modelOdb.SaveChanges();

                MessageBox.Show("Данные успешно добавлены!", "Успешное добавление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка добавления данных!", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("DepartmentsDataGrid.xaml", UriKind.Relative));
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("DepartmentsDataGrid.xaml", UriKind.Relative));
        }
    }
}
