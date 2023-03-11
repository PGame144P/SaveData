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
    public partial class LaborBookDataGrid : Page
    {
        public LaborBookDataGrid()
        {
            InitializeComponent();

            AppConnect.modelOdb = new SaveDataEntities();
            var laborBook = AppConnect.modelOdb.ТрудоваяКнигаView.ToList();

            laborBookDataGrid.ItemsSource = laborBook;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var data = ((sender as Button).DataContext as ТрудоваяКнигаView);
            FrameManager.NavigationFrame.NavigationService.Navigate(new LaborBookEditPage(data));
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {   
            var selectedBooks = laborBookDataGrid.SelectedItems.Cast<ТрудоваяКнигаView>().ToList();
            var selectedIds = from book in selectedBooks select book.Код_трудовой_книги;
            var data = AppConnect.modelOdb.Трудовая_книга.Where(x => selectedIds.Contains(x.Код_трудовой_книги));

            if (MessageBox.Show($"Вы точно хотите удалить выделенные элементы?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AppConnect.modelOdb.Трудовая_книга.RemoveRange(data);
                    AppConnect.modelOdb.SaveChanges();

                    MessageBox.Show("Данные удалены!", "Операция выполнена", MessageBoxButton.OK, MessageBoxImage.Information);

                    laborBookDataGrid.ItemsSource = AppConnect.modelOdb.ТрудоваяКнигаView.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
