using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace ClickerHeroes.Logic
{
    public class AutoDamager
    {
        private float _totalDamage;
        //private readonly Timer _timer;
        //private int Interval { get { return 1000; } }
        private const float _damageMultiplier = 0.2f;

        public AutoDamager()
        {
            _totalDamage = 0;
           // _timer = new Timer
           // {
           //     Interval = Interval,
           //     AutoReset = true
           // };
           // _timer.Elapsed += _timer_Elapsed;
           //// _timer.Start();


        }

        //Dodawanie obrażeń do AutoDamagera.
        //Jeśli nowy heros zostanie kupiony, jego obrażenia dodadzą się do AutoDamagera za pomocą tej funkcji.
        public void AddDamage(float damage)
        {
            _totalDamage = (float)Math.Round(_totalDamage + damage, 2);
        }

        public void ReturnHealth()
        {

        }

        public float Attack(float health)
        {
            //TODO: Funkcja powinna odbierać życie potworowi i zwracać nową wartość.

            float currentHealth = health;

            currentHealth -= (float)Math.Round(_totalDamage * _damageMultiplier, 2);

            return currentHealth;
        }

        public void Wait()
        {
            //TODO:Timer powinien wyłaczać się gdy HP przeciwnika spadnie do 0... i włączać się kiedy pojawi się kolejny.

            //_timer.Stop();
            Thread.Sleep(500);

        }

        //public void Stop()
        //{
        //    //Bądźmy szczerzy... ta funkcja nigdy się nie włączy.
        //    _timer.Dispose();
        //}

        //public void Start(double health)
        //{
        //    _timer.Start();

        //}
    }
}
