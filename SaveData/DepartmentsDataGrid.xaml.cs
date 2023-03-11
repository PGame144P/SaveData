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
    /// Логика взаимодействия для DepartmentsDataGrid.xaml
    /// </summary>
    public partial class DepartmentsDataGrid : Page
    {
        public DepartmentsDataGrid()
        {
            InitializeComponent();
            
            AppConnect.modelOdb = new SaveDataEntities();
            
            var departments = AppConnect.modelOdb.Отделы.ToList();
            departmentsDataGrid.ItemsSource = departments;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var data = ((sender as Button).DataContext as Отделы);
            FrameManager.NavigationFrame.NavigationService.Navigate(new DepartmentsEditPage(data));

        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            var data = departmentsDataGrid.SelectedItems.Cast<Отделы>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие выделенные элементы?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AppConnect.modelOdb.Отделы.RemoveRange(data);
                    AppConnect.modelOdb.SaveChanges();
                    MessageBox.Show("Данные удалены!", "Операция выполнена", MessageBoxButton.OK, MessageBoxImage.Information);

                    departmentsDataGrid.ItemsSource = AppConnect.modelOdb.Отделы.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
