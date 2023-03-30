using System;
using System.Windows;
using System.Windows.Controls;

namespace SaveData
{
    /// <summary>
    /// Interaction logic for PositionsEditPage.xaml
    /// </summary>
    public partial class PositionsEditPage : Page
    {
        public Должности _currentPosition = new Должности();

        public PositionsEditPage(Должности selectedPosition)
        {
            InitializeComponent();
            if (selectedPosition != null)
                _currentPosition = selectedPosition;

            DataContext = _currentPosition;
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

            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("PositionsDataGrid.xaml", UriKind.Relative));
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("PositionsDataGrid.xaml", UriKind.Relative));
        }
    }
}
