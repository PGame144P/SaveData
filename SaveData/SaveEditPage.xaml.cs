using System;
using System.Windows;
using System.Windows.Controls;

namespace SaveData
{

    public partial class SaveEditPage : Page
    {
        public Сотрудники _currentSave = new Сотрудники();
        public SaveEditPage(Сотрудники selectedSave)
        {
            InitializeComponent();
            if (selectedSave != null)
                _currentSave = selectedSave;
            DataContext = _currentSave;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppConnect.modelOdb.SaveChanges();
                MessageBox.Show("Данные успешно сохранены!", "Успешное сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка сохранения данных!", "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("SaveDataGrid.xaml", UriKind.Relative));
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("SaveDataGrid.xaml", UriKind.Relative));
        }
    }
}
