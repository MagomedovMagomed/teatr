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
using WpfApp1.PageMain;

namespace WpfApp1.PageMain
{
	/// <summary>
	/// Логика взаимодействия для CreateAcc.xaml
	/// </summary>
	public partial class CreateAcc : Page
	{
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
					Telephon = Telepho.Text,
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
	}
}
