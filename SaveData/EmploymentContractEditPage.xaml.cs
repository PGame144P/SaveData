using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SaveData
{
    /// <summary>
    /// Interaction logic for EmploymentContractEditPage.xaml
    /// </summary>
    public partial class EmploymentContractEditPage : Page
    {
        public ТрудовыеДоговорыView _currentContract = new ТрудовыеДоговорыView();
        public Трудовые_договоры realContract = new Трудовые_договоры();

        public EmploymentContractEditPage(ТрудовыеДоговорыView selectedContract)
        {
            InitializeComponent();

            if (selectedContract != null)
                _currentContract = selectedContract;
            
            editContractDatePickerStart.SelectedDate = _currentContract.Дата_заключения;
            editContractDatePickerEnd.SelectedDate = _currentContract.Дата_расторжения;
            
            realContract = AppConnect.modelOdb.Трудовые_договоры.FirstOrDefault(x => x.Код_договора == _currentContract.Код_договора);
            DataContext = realContract;

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if (editContractDatePickerEnd.SelectedDate.Value < editContractDatePickerStart.SelectedDate.Value)
            {
                MessageBox.Show("Ошибка сохранения данных!", "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                realContract.Дата_заключения = editContractDatePickerStart.SelectedDate.Value.Date;
                realContract.Дата_расторжения = editContractDatePickerEnd.SelectedDate.Value.Date;

                AppConnect.modelOdb.SaveChanges();

                MessageBox.Show("Данные успешно сохранены!", "Успешное сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка сохранения данных!", "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("EmploymentContractDataGrid.xaml", UriKind.Relative));
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("EmploymentContractDataGrid.xaml", UriKind.Relative));
        }
    }
}
