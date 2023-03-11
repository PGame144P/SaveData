using System;
using System.Collections;
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
    /// Логика взаимодействия для SaveDataGrid.xaml
    /// </summary>
    public partial class SaveDataGrid : Page
    {
        public SaveDataGrid()
        {
            InitializeComponent();
            AppConnect.modelOdb = new SaveDataEntities();
            
            var save = AppConnect.modelOdb.Сотрудники.ToList();
            saveDataGrid.ItemsSource = save;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        { 
            var data = ((sender as Button).DataContext as Сотрудники);
            FrameManager.NavigationFrame.NavigationService.Navigate(new SaveEditPage(data));
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            var data = saveDataGrid.SelectedItems.Cast<Сотрудники>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие выделенные элементы?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AppConnect.modelOdb.Сотрудники.RemoveRange(data);
                    AppConnect.modelOdb.SaveChanges();
                    MessageBox.Show("Данные удалены!", "Операция выполнена", MessageBoxButton.OK, MessageBoxImage.Information);

                    saveDataGrid.ItemsSource = AppConnect.modelOdb.Сотрудники.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}
