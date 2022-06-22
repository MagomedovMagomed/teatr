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
using WpfApp1.Properties;

namespace WpfApp1.PageMain
{
	/// <summary>
	/// Логика взаимодействия для Page1.xaml
	/// </summary>
	public partial class Login : Page
	{
		public Login()
		{
			InitializeComponent();
			//AppFrame.mainFrame;
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				var usetObj = AppContent.Model1.User.FirstOrDefault(x => x.Login == login.Text && x.Password == password.Password);
				if(usetObj==null)
				{
					MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
					Capth capth = new Capth();
					capth.ShowDialog();
				}
				else
				{
					switch (usetObj.idRole)
					{
						case 1: AppFrame.mainFrame.Navigate(new Page1());
							AppFrame.frameMain.Navigate(new PageAdmin.AdminPage()); 
							MessageBox.Show("Здравствуйте, Администратор " + usetObj.Name + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
							break;
						case 2: AppFrame.mainFrame.Navigate(new Page1());
							AppFrame.frameMain.Navigate(new PageClient.ClientPage()); 
							MessageBox.Show("Здравствуйте, Ученик " + usetObj.Name + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
							break;
						case 3:
							AppFrame.mainFrame.Navigate(new Page1());
							AppFrame.frameMain.Navigate(new PageClient.ClientPage());
							MessageBox.Show("Здравствуйте, Менеджер " + usetObj.Name + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
							break;
						default: MessageBox.Show("Данные не обнаружены !", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
							break;
					}
				}
			}
			catch(Exception Ex)
			{
				MessageBox.Show("Ошибка " + Ex.Message.ToString() + "Критическая работа приложения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
				Capth capth = new Capth();
				capth.ShowDialog();
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			AppFrame.frameMain.Navigate(new CreateAcc());
		}

        private void TextBlock_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
			AppFrame.mainFrame.Navigate(new Page1());
			AppFrame.frameMain.Navigate(new PageClient.ClientPage());
			MessageBox.Show("Здравствуйте, Гость " + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
		}
    }
}