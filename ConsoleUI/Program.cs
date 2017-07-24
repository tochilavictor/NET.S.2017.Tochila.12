using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmergenceLogic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Eemergency emg1 = new Eemergency();
            PolandGovernment pl = new PolandGovernment();
            LatviaGovernment lg = new LatviaGovernment();
            lg.RegisterEarthShake(emg1);
            pl.RegisterEarthShake(emg1);
            emg1.NewShake(4500, "Latvia", 10);
            emg1.NewShake(10000, "Poland", 2);
            emg1.NewShake(3860, "Cuba", 7);
            Console.ReadKey();
        }
    }
}
