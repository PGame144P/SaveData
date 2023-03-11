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
    /// Interaction logic for EmploymentContractAddPage.xaml
    /// </summary>
    public partial class EmploymentContractAddPage : Page
    {
        public EmploymentContractAddPage()
        {
            InitializeComponent();

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var newContract = new Трудовые_договоры()
            {
                Номер_договора = int.Parse(contractNumber.Text),
                Дата_заключения = editContractDatePickerStart.SelectedDate.Value.Date,
                Дата_расторжения = editContractDatePickerEnd.SelectedDate.Value.Date,
                Заработная_плата = decimal.Parse(payment.Text),
                Код_сотрудника = int.Parse(SaveCode.Text)
            };

            try
            {
                AppConnect.modelOdb.Трудовые_договоры.Add(newContract);
                AppConnect.modelOdb.SaveChanges();

                MessageBox.Show("Данные успешно добавлены!", "Успешное добавление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка добавления данных!", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("EmploymentContractDataGrid.xaml", UriKind.Relative));
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("EmploymentContractDataGrid.xaml", UriKind.Relative));
        }

    }
}

