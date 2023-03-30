using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SaveData
{
    /// <summary>
    /// Interaction logic for EmploymentContractDataGrid.xaml
    /// </summary>
    public partial class EmploymentContractDataGrid : Page
    {
        public EmploymentContractDataGrid()
        {
            InitializeComponent();

            AppConnect.modelOdb = new SaveDataEntities();
            var employmentContracts = AppConnect.modelOdb.ТрудовыеДоговорыView.ToList();

            employmentContractDataGrid.ItemsSource = employmentContracts;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var data = ((sender as Button).DataContext as ТрудовыеДоговорыView);
            FrameManager.NavigationFrame.NavigationService.Navigate(new EmploymentContractEditPage(data));
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            var selectedContracts = employmentContractDataGrid.SelectedItems.Cast<ТрудовыеДоговорыView>().ToList();
            var selectedIds = from book in selectedContracts select book.Код_договора;
            var data = AppConnect.modelOdb.Трудовые_договоры.Where(x => selectedIds.Contains(x.Код_договора));

            if (MessageBox.Show($"Вы точно хотите удалить выделенные элементы?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AppConnect.modelOdb.Трудовые_договоры.RemoveRange(data);
                    AppConnect.modelOdb.SaveChanges();

                    MessageBox.Show("Данные удалены!", "Операция выполнена", MessageBoxButton.OK, MessageBoxImage.Information);

                    employmentContractDataGrid.ItemsSource = AppConnect.modelOdb.ТрудовыеДоговорыView.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }
    }
}
