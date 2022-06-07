using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.ApplicationData;
using WpfApp1.PageMain;


namespace WpfApp1.PageMain
{
	/// <summary>
	/// Логика взаимодействия для Capth.xaml
	/// </summary>
	public partial class Capth : Window
	{
		public Capth()
		{
			InitializeComponent();
			Random rnd = new Random();
			capt.Content = (char)rnd.Next('\u0041', '\u007A') + ""+ (char)rnd.Next('\u0041', '\u007A') + ""+ (char)rnd.Next('\u0041', '\u007A') + ""+ (char)rnd.Next('\u0041', '\u007A');
		}

		private void Open_Click(object sender, RoutedEventArgs e)
		{
			if (captha.Text == capt.Content.ToString())
			{
				this.Close();
				MessageBox.Show("Здравствуйте, Ученик " + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
				AppFrame.frameMain.Navigate(new PageAdmin.AdminPage()); ;
			}
			else
			{
				this.Close();
				WpfApp1.PageMain.Catch2 capth2 = new Catch2();
				capth2.Show();
			}
		}
	}
}
