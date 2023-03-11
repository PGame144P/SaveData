using System;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Text;

namespace SaveData
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();

            AppConnect.modelOdb = new SaveDataEntities();

            txtBoxPassword.Visibility = Visibility.Hidden;
            txtBoxPasswordRepeat.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            
            mainWindow.Show();
            
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var isUserExists = AppConnect.modelOdb.Пользователи.FirstOrDefault(x => x.Логин == txtLogin.Text) != null;

                if (isUserExists)
                {
                    MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                    var new_user = new Пользователи()
                    {
                        Логин = txtLogin.Text,
                        Пароль = HashPassword(txtPassword.Password),
                        Тип_учетной_записи = "пользователь"
                    };
                    
                    AppConnect.modelOdb.Пользователи.Add(new_user);
                    AppConnect.modelOdb.SaveChanges();
                   
                    MessageBox.Show("Вы успешно зарегистрировались!", "Успешная регистрация", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    var authorization = new MainWindow();
                    authorization.Show();
                    
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка", "Ошибка приложения", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                //this.DragMove();
            }
        }

        private void textLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtLogin.Focus();
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLogin.Text) && txtLogin.Text.Length > 0)
            {
                textLogin.Visibility = Visibility.Collapsed;
            }
            else
            {
                textLogin.Visibility = Visibility.Visible;
            }
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
            PasswordCheck();
        }

        private void txtPassworRepeat_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPasswordRepeat.Password) && txtPasswordRepeat.Password.Length > 0)
            {
                textPasswordRepeat.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPasswordRepeat.Visibility = Visibility.Visible;
            }
            PasswordCheck();
        }

        private void textPasswordRepeat_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPasswordRepeat.Focus();
        }

        private void PasswordCheck()
        {
            if ((txtPassword.Password.Length < 8 && txtPassword.Password.Length > 0) || !txtPassword.Password.Any(char.IsDigit) || !txtPassword.Password.Any(char.IsUpper))
            {
                errorWarnings.Text = "Пароль должен быть не менее 8 символов, содержать цифры и заглавные буквы.";
                registrationButton.IsEnabled = false;
                passwordBorder.BorderBrush = new SolidColorBrush(Colors.Red);
                passwordRepeatBorder.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else if (txtPassword.Password != txtPasswordRepeat.Password)
            {
                errorWarnings.Text = "Пароли не совпадают";
                registrationButton.IsEnabled = false;
                passwordBorder.BorderBrush = new SolidColorBrush(Colors.Red);
                passwordRepeatBorder.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                errorWarnings.Text = String.Empty;
                registrationButton.IsEnabled = true;
                passwordBorder.BorderBrush = new SolidColorBrush(Colors.Green);
                passwordRepeatBorder.BorderBrush = new SolidColorBrush(Colors.Green);
            }
        }

        void ShowPassword()
        {
            txtBoxPassword.Visibility = Visibility.Visible;
            txtBoxPasswordRepeat.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Hidden;
            txtBoxPassword.Text = txtPassword.Password;
            txtBoxPasswordRepeat.Text = txtPasswordRepeat.Password;
        }
        void HidePassword()
        {
            txtBoxPassword.Visibility = Visibility.Hidden;
            txtBoxPasswordRepeat.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Visible;
            txtPassword.Focus();
        }

        private void PackIconMaterial_MouseLeave(object sender, MouseEventArgs e)
        {
            HidePassword();
        }

        private void PackIconMaterial_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ShowPassword();
        }

        private void PackIconMaterial_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            HidePassword();
        }

        public static string HashPassword(string password)
        {
            MD5 md5 = MD5.Create();

            byte[] b = Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(b);

            StringBuilder sb = new StringBuilder();
            foreach (var a in hash)
            {
                sb.Append(a.ToString("X2"));
            }
            return Convert.ToString(sb);
        }

    }
}
