using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;  
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
	/// Логика взаимодействия для AdminPage.xaml
	/// </summary>
	public partial class AdminPage : Page
	{
		public AdminPage()
		{
			InitializeComponent();
			//DBSpec.ItemsSource = Entities.GetContext().Spectacle.ToList();
   //         DBUser.ItemsSource = Entities.GetContext().User.ToList();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Add((sender as Button).DataContext as Spectacle));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Add(null));
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var SpectacleRemove = DBSpec.SelectedItems.Cast<Spectacle>().ToList();
            var UserRemove = DBUser.SelectedItems.Cast<User>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {SpectacleRemove.Count() + UserRemove.Count()} элементов?", "Внимание", 
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Entities1.GetContext().Spectacle.RemoveRange(SpectacleRemove);
                    Entities1.GetContext().User.RemoveRange(UserRemove);
                    Entities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DBSpec.ItemsSource = Entities1.GetContext().Spectacle.ToList();
                    DBUser.ItemsSource = Entities1.GetContext().User.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                //Entities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DBSpec.ItemsSource = Entities1.GetContext().Spectacle.ToList();
                DBUser.ItemsSource = Entities1.GetContext().User.ToList();
            }
        }

        private void Edit_Click_1(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Edit(null));
        }

        private void Edit_Click_2(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new Edit((sender as Button).DataContext as User));
        }
    }
}
