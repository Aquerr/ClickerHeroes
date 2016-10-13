using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace ClickerHeroes.Logic
{
    public class AutoDamager
    {
        private int _totalDamage;
        private readonly Timer _timer;
        private int Interval { get { return 1000; } }
        private float DamageMultiplier;

        public AutoDamager()
        {
            _totalDamage = 0;
            _timer = new Timer
            {
                Interval = Interval,
                AutoReset = true
            };
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();


        }

        //Dodawanie obrażeń do AutoDamagera.
        //Jeśli nowy heros zostanie kupiony, jego obrażenia dodadzą się do AutoDamagera za pomocą tej funkcji.
        public void AddDamage(int damage)
        {
            _totalDamage += damage;
        }

        //public int ReturnHealth()
        //{
            
        //}

        public int Attack(int health)
        {
            //TODO: Funkcja powinna odbierać życie potworowi i zwracać nową wartość.

            int currentHealth = health;

            currentHealth -= _totalDamage;

            return currentHealth;
        }

        public void Wait()
        {
            //TODO:Timer powinien wyłaczać się gdy HP przeciwnika spadnie do 0... i włączać się kiedy pojawi się kolejny.

            _timer.Stop();
            Thread.Sleep(500);

        }

        public void Stop()
        {
            //Bądźmy szczerzy... ta funkcja nigdy się nie włączy.
           _timer.Dispose();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //TODO: Dodaj kod, który będzie zadawał obrażenia przeciwnikowi.
            throw new NotImplementedException();

            //Attack()
        }
    }
}
