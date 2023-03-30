using System;
using System.Windows;
using System.Windows.Controls;

namespace SaveData
{
    public partial class ScheduleEditPage : Page
    {
        public Штатное_расписание _currentSchedule = new Штатное_расписание();
        public ScheduleEditPage(Штатное_расписание selectedSave)
        {
            InitializeComponent();
            if (selectedSave != null)
                _currentSchedule = selectedSave;
            DataContext = _currentSchedule;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppConnect.modelOdb.SaveChanges();
                MessageBox.Show("Данные успешно сохранениы!", "Успешное сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка сохранения данных!", "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("ScheduleDataGrid.xaml", UriKind.Relative));
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("ScheduleDataGrid.xaml", UriKind.Relative));
        }
    }
}
