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
using ClickerHeroes.Logic;
using System.Timers;
using System.Windows.Threading;
using Timer = System.Timers.Timer;
using System.Threading;
using System.Globalization;

namespace ClickerHeroes.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ObservableCollection<Hero> _heroList;
        private static ObservableCollection<Monster> _monsterList;
        private static ObservableCollection<Place> _placeList;
        private int _currentMonsterId;
        private double _mouseAttack = 3;
        private Label _moneyLabel;
        private Label _damagePerClickLabel;
        private Label _heroSoulLabel;
        private Label _DamagePerSecLabel;
        private Image _monsterImage;
        private AutoDamager _autoDamager;

        private DispatcherTimer _timer;
       // private int Interval { get { return 1000; } }

        public MainWindow()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _autoDamager = new AutoDamager();
            _timer = new DispatcherTimer()
            {
                Interval = new TimeSpan(0,0,0,0,1),
            };
            _timer.Tick += new EventHandler(dispatcherTimer_Tick);

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

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            double hp = double.Parse(LabelHealth.Content.ToString());
            var monsterhelath = _autoDamager.Attack(hp);
            Update(monsterhelath);
        }

        public void Update(double monsterhealth)
        {
            if (monsterhealth > 0)
            {
                LabelHealth.Content = monsterhealth;
                HealthBar.Value = monsterhealth;
            }
            else
            {
               // _autoDamager.Wait();
                _timer.Stop();

                //Dodanie zarobionej kasy z przeciwnika
                var killedMonster = MonsterList.Single(x => x.Id == _currentMonsterId);
                var currentMoney = int.Parse(_moneyLabel.Content.ToString());
                currentMoney += killedMonster.Money;
                _moneyLabel.Content = currentMoney;

                //Remove monster from the list
                MonsterList.RemoveAt(0);
                MonsterGenerator.GenerateNewMonster();

                //Załaduj nowego przeciwnika.
                var monster = MonsterList.Single(x => x.Id == _currentMonsterId+1);
                _currentMonsterId = monster.Id;

                LabelMonsterName.Content = monster.Name + " Lvl " + monster.Level;
                LabelHealth.Content = monster.Health;
                HealthBar.Maximum = monster.Health;
                HealthBar.Value = monster.Health;

                //TODO: Napraw crasha, który powstaje kiedy monster nie ma imagepath.
                Uri uri = new Uri(monster.ImagePath, UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                _monsterImage.Source = imgSource;

                //_autoDamager.Start(monster.Health);
                _timer.Start();
            }
        }

        public void MouseAttack()
        {
            double monsterhealth = double.Parse(LabelHealth.Content.ToString());
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

        public static ObservableCollection<Hero> HeroList
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

        public static ObservableCollection<Monster> MonsterList
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

        public static ObservableCollection<Place> PlaceList
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
            if (!_timer.IsEnabled) _timer.Start();
            
            //TODO: Kupienie herosa przesówa go na koniec listy. Trzeba to naprawić.

            var item = (sender as FrameworkElement).DataContext;
            var hero = item as Hero;
            var heroIndex = _heroList.IndexOf(hero);

            _mouseAttack += hero.Damage/4;

            _autoDamager.AddDamage(hero.Damage);

            hero.Level += 1;
            hero.Damage *= 1.5f;

            _heroList.RemoveAt(heroIndex);
            _heroList.Add(hero);

            //TODO: Wprowadź tu kod do kupienia herosa.
        }

        private void LoadClickDamage(object sender, RoutedEventArgs e)
        {
            Label label = sender as Label;
            _damagePerClickLabel = label.Template.FindName("LabelDamagePerClick", label) as Label;
            _damagePerClickLabel.Content = 0;
        }

        private void LoadMoney(object sender, RoutedEventArgs e)
        {
            Label label = sender as Label;
            _moneyLabel = label.Template.FindName("LabelPlayerMoney", label) as Label;
            _moneyLabel.Content = 0;
        }

        private void LoadHeroSouls(object sender, RoutedEventArgs e)
        {
            Label label = sender as Label;
            _heroSoulLabel = label.Template.FindName("LabelHeroSouls", label) as Label;
            _heroSoulLabel.Content = 0;
        }

        private void LoadDamagePerSec(object sender, RoutedEventArgs e)
        {
            Label label = sender as Label;
            _DamagePerSecLabel = label.Template.FindName("LabelDamagePerSec", label) as Label;
            _DamagePerSecLabel.Content = 0;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //TODO: Dodaj kod, który będzie zadawał obrażenia przeciwnikowi.

            double hp = MonsterList.Single(x=>x.Id == _currentMonsterId).Health;
            var monsterhelath = _autoDamager.Attack(hp);
            Update(monsterhelath);
        }
    }
}
