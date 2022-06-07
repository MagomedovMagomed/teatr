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
            Post.ItemsSource = Entities.GetContext().Postanovshik.ToList();
            Screen.ItemsSource = Entities.GetContext().Screenwriter.ToList();
            Poin.ItemsSource = Entities.GetContext().Pointer.ToList();
            Zanr.ItemsSource = Entities.GetContext().Zanr.ToList();
            DataContext = _currentSpec;
            //if (specspec != null)
            //{
            //    this._currentSpec = specspec;
            //    Post.Text = _currentSpec.id_post.ToString();
            //    Screen.Text = _currentSpec.id_scen.ToString();
            //    Pointer.Text = _currentSpec.id_xydoz.ToString();
            //    Zanr.Text = _currentSpec.id_zanr.ToString();
            //}
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var timespec = new TimeSpan(0, 0, 1);
            var timetime = _currentSpec.Time;
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
            var id_post = 0;

            if (post != null)
            {
                id_post = post.id_post;
            }
            var point = Poin.SelectedItem as Pointer;
            var id_point = 0;

            if (point != null)
            {
                id_point = point.id_xyd;
            }


            if (string.IsNullOrEmpty(_currentSpec.Nazvanie))
                error.AppendLine("Укажите название спектакля");
            if (timetime > timespec)
                error.AppendLine("Укажите продолжительность спектакля");
            if (id_post == 0)
                error.AppendLine("Выберите постановщика");
            if(id_wr == 0)
                error.AppendLine("Выберите сценариста");
            if(id_point == 0)
                error.AppendLine("Выберите художника");
            if (id_zan == 0)
                error.AppendLine("Выберите жанр");
            if (_currentSpec.Ostatok < 0)
                error.AppendLine("Укажите правильное количество билетов");

            //_currentSpec.id_post = Post.Text;
            //Screen.Text = _currentSpec.id_scen.ToString();
            //Pointer.Text = _currentSpec.id_xydoz.ToString();
            //Zanr.Text = _currentSpec.id_zanr.ToString();

            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            if (_currentSpec.id_spectacle == 0)
                Entities.GetContext().Spectacle.Add(_currentSpec);
            try
            {
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}