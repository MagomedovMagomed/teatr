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
using WpfApp1.ApplicationData;

namespace WpfApp1.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
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

            var dateString = "1/1/1900";
            DateTime date1 = DateTime.Parse(dateString,
                                      System.Globalization.CultureInfo.InvariantCulture);

            if (string.IsNullOrEmpty(_currentUser.Name))
                error.AppendLine("Укажите Имя пользователя");
            if (string.IsNullOrEmpty(_currentUser.Surename))
                error.AppendLine("Укажите Фамилию пользователя");
            if (string.IsNullOrEmpty(_currentUser.Father_name))
                error.AppendLine("Укажите Отчество пользователя");
            if (_currentUser.Teleph < 0)
                error.AppendLine("Укажите телефон пользователя");
            if (string.IsNullOrEmpty(_currentUser.Login))
                error.AppendLine("Укажите Логин пользователя");
            if (string.IsNullOrEmpty(_currentUser.Email))
                error.AppendLine("Укажите Email пользователя");
            if (string.IsNullOrEmpty(_currentUser.idRole.ToString()))
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
                    Telephon = teleph.Text,
                    Data_Birth = Birt.DisplayDate,
                    Email = Email.Text
                };
                if (_currentUser.id == 0)
                    Entities.GetContext().User.Add(_currentUser);
                try
                {
                    // AppContent.Model1.Spectacle.Add(specobj);
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
                teleph.Background = Brushes.LightGreen;
                teleph.Background = Brushes.Green;
            }
        }
    }
}
