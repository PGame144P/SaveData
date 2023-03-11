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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
