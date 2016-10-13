using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
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
using ClickerHeroes.Entities;

namespace ClickerHeroes.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Hero> _heroList;
        private ObservableCollection<Monster> _monsterList;
        private ObservableCollection<Place> _placeList;
        private int _currentMonsterId;
        private int _mouseAttack = 3;

        private Image _monsterImage;
        //private List<Hero> heroList = new List<Hero>();
        // public List<Hero> HeroList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            //Ładowanie listy herosów
            IEnumerable<Hero> heroes = EntitesList.HeroList;
            List<Hero> startHeroes = new List<Hero>();

            foreach (var hero in heroes)
            {
                if (hero.Id <= 5)
                {
                    startHeroes.Add(hero);
                }
                else
                {
                    startHeroes.Add(new Hero() { Name = "???" });
                }
            }

            HeroList = new ObservableCollection<Hero>(startHeroes);
            HeroListView.ItemsSource = HeroList;


            //Ładwanie pierwszego potwora.
            IEnumerable<Monster> monsters = EntitesList.MonsterList;
            MonsterList = new ObservableCollection<Monster>(monsters);

            LabelMonsterName.Content = MonsterList[0].Name + " Lvl " + MonsterList[0].Level;
            LabelHealth.Content = MonsterList[0].Health;
            HealthBar.Maximum = MonsterList[0].Health;
            HealthBar.Value = MonsterList[0].Health;
            _currentMonsterId = 1;
            // HealthBar.Foreground = new SolidColorBrush(Colors.Red);

            //Ładowanie poziomów
            IEnumerable<Place> places = EntitesList.PlaceList;
            PlaceList = new ObservableCollection<Place>();

        }

        public void Update(int monsterhealth)
        {
            if (monsterhealth > 0)
            {
                LabelHealth.Content = monsterhealth;
                HealthBar.Value = monsterhealth;
            }
            else
            {
                //Załaduj nowego przeciwnika.
                var monster = MonsterList.Single(x => x.Id == _currentMonsterId+1);

                LabelMonsterName.Content = monster.Name + " Lvl " + monster.Level;
                LabelHealth.Content = monster.Health;
                HealthBar.Maximum = monster.Health;
                HealthBar.Value = monster.Health;

                Uri uri = new Uri(monster.ImagePath, UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                _monsterImage.Source = imgSource;
            }
        }

        public void MouseAttack()
        {
            int monsterhealth = int.Parse(LabelHealth.Content.ToString());
            monsterhealth -= _mouseAttack;
            Update(monsterhealth);
        }

        private void MouseClick(object sender, RoutedEventArgs e)
        {
            //Odtworzenie dźwięku ataku
            SoundPlayer sound = new SoundPlayer("../../Sounds/Punch.wav");
            sound.Play();

            //Funkcje, które mają zostać uaktywnione po naciśnięciu przycisku.
            MouseAttack();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public ObservableCollection<Hero> HeroList
        {
            get { return _heroList; }
            set
            {
                if (_heroList != value)
                {
                    _heroList = value;
                }
            }
        }

        public ObservableCollection<Monster> MonsterList
        {
            get { return _monsterList; }
            set
            {
                if (_monsterList != value)
                {
                    _monsterList = value;
                }
            }
        }

        public ObservableCollection<Place> PlaceList
        {
            get { return _placeList; }
            set
            {
                if (_placeList != value)
                {
                    _placeList = value;
                }
            }
        }

        private void MonsterLoaded(object sender, RoutedEventArgs e)
        {
            //Ładowanie pierwszego potwora.
            Button button = sender as Button;
            _monsterImage = button.Template.FindName("ImageEnemy", button) as Image;
            Uri uri = new Uri(MonsterList[0].ImagePath, UriKind.Relative);
            ImageSource imgSource = new BitmapImage(uri);
            _monsterImage.Source = imgSource;
        }

        private void BuyHero(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            var hero = item as Hero;

            //TODO: Wprowadź tu kod do kupienia herosa.
        }
    }
}
