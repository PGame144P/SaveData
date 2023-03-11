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
    public partial class PaymentsDataGrid : Page
    {
        public PaymentsDataGrid()
        {
            InitializeComponent();

            AppConnect.modelOdb = new SaveDataEntities();
            var payments = AppConnect.modelOdb.Начисление_ЗП.ToList();

            paymentsDataGrid.ItemsSource = payments;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var data = ((sender as Button).DataContext as Начисление_ЗП);
            FrameManager.NavigationFrame.NavigationService.Navigate(new PaymentsEditPage(data));
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            var data = paymentsDataGrid.SelectedItems.Cast<Начисление_ЗП>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить выделенные элементы?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AppConnect.modelOdb.Начисление_ЗП.RemoveRange(data);
                    AppConnect.modelOdb.SaveChanges();

                    MessageBox.Show("Данные удалены!", "Операция выполнена", MessageBoxButton.OK, MessageBoxImage.Information);

                    paymentsDataGrid.ItemsSource = AppConnect.modelOdb.Начисление_ЗП.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
