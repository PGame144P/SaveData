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
    /// Логика взаимодействия для PositionsDataGrid.xaml
    /// </summary>
    public partial class PositionsDataGrid : Page
    {
        public PositionsDataGrid()
        {
            InitializeComponent();
            AppConnect.modelOdb = new SaveDataEntities();
            
            var positions = AppConnect.modelOdb.Должности.ToList();
            positionsDataGrid.ItemsSource = positions;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var data = ((sender as Button).DataContext as Должности);
            FrameManager.NavigationFrame.NavigationService.Navigate(new PositionsEditPage(data));
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            var data = positionsDataGrid.SelectedItems.Cast<Должности>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие выделенные элементы?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AppConnect.modelOdb.Должности.RemoveRange(data);
                    AppConnect.modelOdb.SaveChanges();
                    MessageBox.Show("Данные удалены!", "Операция выполнена", MessageBoxButton.OK, MessageBoxImage.Information);

                    positionsDataGrid.ItemsSource = AppConnect.modelOdb.Должности.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
