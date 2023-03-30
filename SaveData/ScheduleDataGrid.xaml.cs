using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SaveData
{
    /// <summary>
    /// Interaction logic for ScheduleDataGrid.xaml
    /// </summary>
    public partial class ScheduleDataGrid : Page
    {
        public ScheduleDataGrid()
        {
            InitializeComponent();
            AppConnect.modelOdb = new SaveDataEntities();

            var schedule = AppConnect.modelOdb.Штатное_расписание.ToList();
            scheduleDataGrid.ItemsSource = schedule;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var data = ((sender as Button).DataContext as Штатное_расписание);
            FrameManager.NavigationFrame.NavigationService.Navigate(new ScheduleEditPage(data));
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            var data = scheduleDataGrid.SelectedItems.Cast<Штатное_расписание>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие выделенные элементы?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AppConnect.modelOdb.Штатное_расписание.RemoveRange(data);
                    AppConnect.modelOdb.SaveChanges();
                    MessageBox.Show("Данные удалены!", "Операция выполнена", MessageBoxButton.OK, MessageBoxImage.Information);

                    scheduleDataGrid.ItemsSource = AppConnect.modelOdb.Должности.ToList();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ошибка удаления данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
