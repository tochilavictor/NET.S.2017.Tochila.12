using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmergenceLogic
{
    public class EarthShakeEventArgs : EventArgs
    {
        private readonly string country;
        private readonly int grade;
        public EarthShakeEventArgs(string country, int grade)
        {
            if (string.IsNullOrEmpty(country)) throw new ArgumentException();
            this.country = country;
            if (grade < 0) this.grade = 0;
            else if (grade > 10) this.grade = 10;
            else { this.grade = grade; }
        }

        public string Country => country;
        public int Grade => grade;
    }
    public class Eemergency
    {
        public event EventHandler<EarthShakeEventArgs> EarthShake;
        protected virtual void OnEarthShake(object sender, EarthShakeEventArgs args)
        {
            if (ReferenceEquals(args, null)) throw new ArgumentException();
            if (ReferenceEquals(sender, null)) throw new ArgumentException();

            EventHandler<EarthShakeEventArgs> tmp = EarthShake;
            tmp?.Invoke(sender, args);
        }
        public void NewShake(int timetoshake, EarthShakeEventArgs args)
        {
            Thread.Sleep(timetoshake);
            if (ReferenceEquals(args, null)) throw new ArgumentException();
            OnEarthShake(this, args);
        }
        public void NewShake(int timetoshake, string country, int grade)
        {
            if(timetoshake<0) throw new ArgumentException();
            int notificationInterval = 1000;
            while (timetoshake > notificationInterval)
            {
                Console.WriteLine("Event will happen in " + (double)timetoshake/1000 + " seconds");
                Thread.Sleep(notificationInterval);
                timetoshake -= notificationInterval;
            }
            Console.WriteLine("Event will happen in "+ timetoshake +" miliseconds");
            Thread.Sleep(timetoshake);
            if (string.IsNullOrEmpty(country)) throw new ArgumentException();
            OnEarthShake(this, new EarthShakeEventArgs(country, grade));
        }
    }
}
