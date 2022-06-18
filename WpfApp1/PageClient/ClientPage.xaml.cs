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

namespace WpfApp1.PageClient
{
	/// <summary>
	/// Логика взаимодействия для ClientPage.xaml
	/// </summary>
	public partial class ClientPage : Page
	{
		public ClientPage()
		{
			InitializeComponent();

			Filtr.Items.Add("Все жанры");
            foreach (var i in AppContent.Model1.Zanr)
			{
				Filtr.Items.Add(i.Name);
            }
			Sort.Items.Add("По продолжителдьности");
			Sort.SelectedIndex = 0;
			Filtr.SelectedIndex = 0;
			var _currentSpec = Entities.GetContext().Spectacle.ToList();
			Spectacle.ItemsSource = _currentSpec;
			UpdateSpectacle();
		}

		public void UpdateSpectacle()
        {
			var CurrentSpec = Entities.GetContext().Spectacle.ToList();

			if (Filtr.SelectedIndex > 0)
            {
				var tesr = Filtr.SelectedItem.ToString();
				CurrentSpec = CurrentSpec.Where(p => p.Zanr.Name == Filtr.SelectedItem.ToString()).ToList();
            }

			CurrentSpec = CurrentSpec.Where(p => p.Nazvanie.ToLower().Contains(Search.Text.ToLower())).ToList();

			
			Spectacle.ItemsSource = CurrentSpec.OrderBy(p => p.Ostatok).ToList();
		}

		private void Search_TextChanged(object sender, TextChangedEventArgs e)
		{
			UpdateSpectacle();
		}
		private void Filtr_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateSpectacle();
		}
	}
}
