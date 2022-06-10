using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WpfApp1.ApplicationData;

namespace WpfApp1.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        bool isValid(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
        private User _currentUser = new User();
        public Edit(User useruser)
        {
            InitializeComponent();
            if (useruser != null)
            {
                _currentUser = useruser;
            }
            DataContext = _currentUser;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrEmpty(_currentUser.Name))
                error.AppendLine("Укажите Имя пользователя");
            if (string.IsNullOrEmpty(_currentUser.Surename))
                error.AppendLine("Укажите Фамилию пользователя");
            if (string.IsNullOrEmpty(_currentUser.Father_name))
                error.AppendLine("Укажите Отчество пользователя");
            if (_currentUser.Teleph < 10000000000)
                error.AppendLine("Укажите телефон пользователя");
            if (string.IsNullOrEmpty(_currentUser.Login))
                error.AppendLine("Укажите Логин пользователя");
            if (string.IsNullOrEmpty(_currentUser.Email) || isValid(Email.Text) == false)
                error.AppendLine("Укажите правильно Email пользователя");
            if (_currentUser.idRole > 3)
                error.AppendLine("Укажите Роль пользователя");
            if (string.IsNullOrEmpty(_currentUser.Password))
                error.AppendLine("Укажите Пароль пользователя");

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                User userObj = new User()
                {
                    Login = Log.Text,
                    Password = Pass.Text,
                    idRole = 2,
                    Name = Im.Text,
                    Surename = Sun.Text,
                    Father_name = Fat.Text,
                    Teleph = Convert.ToInt32(teleph.Text),
                    Data_Birth = Birt.DisplayDate,
                    Email = Email.Text
                };
                if (_currentUser.id == 0)
                    Entities1.GetContext().User.Add(_currentUser);
                try
                {
                    AppContent.Model1.User.Add(userObj);
                    AppContent.Model1.SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    AppFrame.frameMain.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при изменении!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Birt_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Birt.SelectedDate > DateTime.Now.AddYears(-18) || Birt.SelectedDate < DateTime.Now.AddYears(-99))
            {
                MessageBox.Show("Регистрироваться могут только люди страше 18 и младше 99", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                Save.IsEnabled = false;
            }
            else
            {
                Save.IsEnabled=true;
            }
        }
    }
}
