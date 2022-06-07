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
using System.Windows.Shapes;
using WpfApp1.PageMain;
using WpfApp1.ApplicationData;
using System.Windows.Threading;

namespace WpfApp1.PageMain
{
	/// <summary>
	/// Логика взаимодействия для Catch2.xaml
	/// </summary>
	public partial class Catch2 : Window
	{
		private int time = 10;
		private DispatcherTimer timer;
		public Catch2()
		{
			//Open2.IsEnabled = true;
			InitializeComponent();
			timer = new DispatcherTimer();
			timer.Interval = new TimeSpan(0, 0, 10);
			timer.Tick += Timer_Tick;
			timer.Start();
			Random rnd = new Random();
			MessageBox.Show("Кнопка заблокирована на 10с" + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
			capt.Content = (char)rnd.Next('\u0041', '\u007A') + "" + (char)rnd.Next('\u0041', '\u007A') + "" + (char)rnd.Next('\u0041', '\u007A') + "" + (char)rnd.Next('\u0041', '\u007A');
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			if(time > 10)
			{
				time--;
			}
			else
			{
				Open2.IsEnabled = true;
				timer.Stop();
			}	
		}

		private void Open_Click(object sender, RoutedEventArgs e)
		{
			if (captha.Text == capt.Content.ToString())
			{
				this.Close();
				MessageBox.Show("Здравствуйте, Ученик " + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
				AppFrame.frameMain.Navigate(new PageAdmin.AdminPage());
			}
			else
			{
				this.Close();
				Catch2 capth2 = new Catch2();
				capth2.Show();
			}
		}
	}
}
