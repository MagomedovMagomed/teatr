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
using WpfApp1.PageMain;

namespace WpfApp1.PageMain
{
	/// <summary>
	/// Логика взаимодействия для CreateAcc.xaml
	/// </summary>
	public partial class CreateAcc : Page
	{
		bool isValid(string email)
		{
			string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
			Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
			return isMatch.Success;
		}
		public CreateAcc()
		{
			InitializeComponent();
		}
		private void Back_Click(object sender, RoutedEventArgs e)
		{
			AppFrame.frameMain.GoBack();
		}
		private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
		{
			if(psbPass.Password != txbPass.Text)
			{
				Create.IsEnabled = false;
				psbPass.Background = Brushes.LightCoral;
				psbPass.BorderBrush = Brushes.Red;
			}
			else
			{
				Create.IsEnabled = true;
				psbPass.Background = Brushes.LightGreen;
				psbPass.BorderBrush = Brushes.Green;
			}
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if(AppContent.Model1.User.Count(x=>x.Login==login.Text)>0)
			{
				MessageBox.Show("Пользователь с таким логином есть!", "Уведомление",MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}
			if(isValid(EMail.Text) == false)
            {
				MessageBox.Show("Укажите правильно Email пользователя");
				return;
			}
			if (Convert.ToDouble(Telepho) < 10000000000)
			{
				MessageBox.Show("Укажите правильно телефон");
				return;
			}
			try
			{
				User userObj = new User()
				{
					Login = login.Text,
					Password = txbPass.Text,
					idRole = 2,
					Name = Name.Text,
					Surename = Surename.Text,
					Father_name = Father_name.Text,
					Teleph = Convert.ToInt32(Telepho.Text),
					Data_Birth = Birth.DisplayDate,
					Email = EMail.Text
				};

				AppContent.Model1.User.Add(userObj);
				AppContent.Model1.SaveChanges();
				MessageBox.Show("Данные успешно добавлены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			catch
			{
				MessageBox.Show("Ошибка при добавлении данных", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

        private void Birth_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
			if (Birth.SelectedDate > DateTime.Now.AddYears(-18) || Birth.SelectedDate < DateTime.Now.AddYears(-99))
			{
				MessageBox.Show("Регистрироваться могут только люди страше 18 и младше 99", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
				Create.IsEnabled = false;
			}
			else
			{
				Create.IsEnabled = true;
			}
		}
    }
}
