using System;
using System.Windows;
using System.Windows.Controls;

namespace SaveData
{
    /// <summary>
    /// Interaction logic for PaymentsAddPage.xaml
    /// </summary>
    public partial class PaymentsAddPage : Page
    {
        public PaymentsAddPage()
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            var newPayment = new Начисление_ЗП()
            {
                Код_сотрудника = int.Parse(SaveCode.Text),
                Дата_начисления = editPaymentDatePicker.SelectedDate.Value.Date,
                Кол_во_отработанных_дней = int.Parse(daysWorked.Text),
                Кол_во_рабочих_часов_в_день = int.Parse(hoursWorkedPerDay.Text),
                Всего_отработано_часов = int.Parse(totalHours.Text),
                Сколько_должен_отработать = int.Parse(mustWork.Text),
                Больничные_дни = int.Parse(illDays.Text),
                Отпускные_дни = int.Parse(holidays.Text),
                Командировочные_дни = int.Parse(travelDays.Text),
                Премия = decimal.Parse(bonus.Text),
                Зарплата = decimal.Parse(payment.Text),
            };

            try
            {
                AppConnect.modelOdb.Начисление_ЗП.Add(newPayment);
                AppConnect.modelOdb.SaveChanges();

                MessageBox.Show("Данные успешно добавлены!", "Успешное добавление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка добавления данных!", "Ошибка добавления", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("PaymentsDataGrid.xaml", UriKind.Relative));
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.NavigationFrame.NavigationService.Navigate(new Uri("PaymentsDataGrid.xaml", UriKind.Relative));
        }

    }
}
