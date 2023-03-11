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
    /// Interaction logic for PaymentsEditPage.xaml
    /// </summary>
    public partial class PaymentsEditPage : Page
    {
        public Начисление_ЗП _currentPayment = new Начисление_ЗП();
        public PaymentsEditPage(Начисление_ЗП selectedPayment)
        {
            InitializeComponent();
            if (selectedPayment != null)
                _currentPayment = selectedPayment;
            DataContext = _currentPayment;
            editPaymentDatePicker.SelectedDate = _currentPayment.Дата_начисления;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _currentPayment.Дата_начисления = editPaymentDatePicker.SelectedDate.Value.Date;
                AppConnect.modelOdb.SaveChanges();
                MessageBox.Show("Данные успешно сохранениы!", "Успешное сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка сохранения данных!", "Ошибка сохранения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("PaymentsDataGrid.xaml", UriKind.Relative));
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("PaymentsDataGrid.xaml", UriKind.Relative));
        }
    }
}
