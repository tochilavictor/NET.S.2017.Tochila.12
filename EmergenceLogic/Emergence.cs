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
            else if (grade > 12) this.grade = 12;
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
        /// <summary>
        /// simulate new earthshake
        /// </summary>
        /// <param name="timetoshake">time to event in miliseconds</param>
        /// <param name="args">event arguments</param>
        public void NewShake(int timetoshake, EarthShakeEventArgs args)
        {
            NewShake(timetoshake,args.Country,args.Grade);
        }
        /// <summary>
        /// simulate new earthshake
        /// </summary>
        /// <param name="timetoshake">time to event in miliseconds</param>
        /// <param name="country">country, where event will happen</param>
        /// <param name="grade">points of earthshake (0 to 12)</param>
        public void NewShake(int timetoshake, string country, int grade)
        {
            if (string.IsNullOrEmpty(country)) throw new ArgumentException();
            if (timetoshake<0) throw new ArgumentException();
            int notificationInterval = 1000;
            while (timetoshake > notificationInterval)
            {
                Console.WriteLine("Event will happen in " + (double)timetoshake/1000 + " seconds");
                Thread.Sleep(notificationInterval);
                timetoshake -= notificationInterval;
            }
            Console.WriteLine("Event will happen in "+ timetoshake +" miliseconds");
            Thread.Sleep(timetoshake);
           
            OnEarthShake(this, new EarthShakeEventArgs(country, grade));
        }
    }
}
