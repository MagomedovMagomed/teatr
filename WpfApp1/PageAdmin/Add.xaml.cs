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
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        private Spectacle _currentSpec = new Spectacle();
        public Add(Spectacle specspec) 
        {
            InitializeComponent();
            Post.ItemsSource = Entities1.GetContext().Postanovshik.ToList();
            Screen.ItemsSource = Entities1.GetContext().Screenwriter.ToList();
            Poin.ItemsSource = Entities1.GetContext().Pointer.ToList();
            Zanr.ItemsSource = Entities1.GetContext().Zanr.ToList();
            DataContext = _currentSpec;

            if(specspec != null)
            {
                _currentSpec = specspec;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            var zanr = Zanr.SelectedItem as Zanr;
            var id_zan = 0;

            if(zanr != null)
            {
                id_zan = zanr.id_zanr;
            }

            var writer = Screen.SelectedItem as Screenwriter;
            var id_wr = 0;

            if (writer != null)
            {
                id_wr = writer.id_Scen;
            }
            var post = Post.SelectedItem as Postanovshik;
            var id_pos = 0;

            if (post != null)
            {
                id_pos = post.id_post;
            }
            var point = Poin.SelectedItem as Pointer;
            var id_point = 0;

            if (point != null)
            {
                id_point = point.id_xyd;
            }


            if (string.IsNullOrEmpty(_currentSpec.Nazvanie))
                error.AppendLine("Укажите название спектакля");
            if (_currentSpec.Time < 0)
                error.AppendLine("Укажите продолжительность спектакля");
            if (id_pos == 0)
                error.AppendLine("Выберите постановщика");
            if(id_wr == 0)
                error.AppendLine("Выберите сценариста");
            if(id_point == 0)
                error.AppendLine("Выберите художника");
            if (id_zan == 0)
                error.AppendLine("Выберите жанр");
            if (_currentSpec.Ostatok < 0)
                error.AppendLine("Укажите правильное количество билетов");
            if (string.IsNullOrEmpty(_currentSpec.Poster))
                error.AppendLine("Введите url картинки");

            
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                Spectacle specobj = new Spectacle()
                {
                    Nazvanie = Nazv.Text,
                    Time = Convert.ToInt32(Tim.Text),
                    Ostatok = Convert.ToInt32(Ost.Text),
                    id_post = id_pos,
                    id_scen = id_wr,
                    id_xydoz = id_point,
                    id_zanr = id_zan,
                    Poster = Poste.Text,
                };
                if (_currentSpec.id_spectacle == 0)
                    Entities1.GetContext().Spectacle.Add(_currentSpec);
                try
                {
                    _currentSpec.id_post = id_pos;
                    _currentSpec.id_scen = id_wr;
                    _currentSpec.id_xydoz = id_point;
                    _currentSpec.id_zanr = id_zan;
                    AppContent.Model1.Spectacle.Add(specobj);
                    AppContent.Model1.SaveChanges();
                    MessageBox.Show("Информация сохранена!");
                    AppFrame.frameMain.GoBack();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при изменении!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}