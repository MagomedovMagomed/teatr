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
using System.Windows.Navigation;

namespace WpfApp1.PageMain
{
	/// <summary>
	/// Логика взаимодействия для Capth.xaml
	/// </summary>
	public partial class Capth : Window
	{
		private int time = 10;
		private DispatcherTimer timer;
		Random rnd = new Random();
		private void Timer_Tick(object sender, EventArgs e)
		{
			if (time > 10)
			{
				time--;
			}
			else
			{
				Open.IsEnabled = true;
				timer.Stop();
			}
		}
		public void Timer()
		{
			timer = new DispatcherTimer();
			timer.Interval = new TimeSpan(0, 0, 10);
			timer.Tick += Timer_Tick;
			timer.Start();
			Open.IsEnabled = false;
		}
		public Capth()
		{
			InitializeComponent();

			capt.Content = (char)rnd.Next('\u0041', '\u007A') + "" + (char)rnd.Next('\u0041', '\u007A') + "" + (char)rnd.Next('\u0041', '\u007A') + "" + (char)rnd.Next('\u0041', '\u007A');
		}

		private void Open_Click(object sender, RoutedEventArgs e)
		{
			if (captha.Text == capt.Content.ToString())
			{
				this.Close();
			}
			else
			{
				Timer();
				capt.Content = "";
				capt.Content = (char)rnd.Next('\u0041', '\u007A') + "" + (char)rnd.Next('\u0041', '\u007A') + "" + (char)rnd.Next('\u0041', '\u007A') + "" + (char)rnd.Next('\u0041', '\u007A');
				MessageBox.Show("Кнопка заблокирована на 10с" + "!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
			}
		}
	}
}