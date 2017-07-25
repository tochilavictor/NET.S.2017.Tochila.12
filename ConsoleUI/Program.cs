using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayLogic;
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
            //emg1.NewShake(4500, "Latvia", 10);
            //emg1.NewShake(10000, "Poland", 2);
            //emg1.NewShake(3860, "Cuba", 7);
            Console.WriteLine("Task2");
            int[] values = { 1, 22, 23, 45, 45, 45, 45, 47, 97 };
            int position = values.BinarySearch(23, new NormalComparer());
            Console.WriteLine(position);
            string[] values2 = { null, "aa","bb","cc" };
            string elem = null;
            int position2 = values2.BinarySearch(elem, new StringOrdinalComparer());
            Console.WriteLine(position2);
            Console.ReadKey();
        }
    }
    public class NormalComparer : IComparer<int>
    {
        public int Compare(int lhs, int rhs)
        {
            return lhs.CompareTo(rhs);
        }
    }
    public class StringOrdinalComparer : IComparer<string>
    {
        public int Compare(string lhs, string rhs)
        {
            return string.Compare(lhs,rhs,StringComparison.Ordinal);
        }
    }
}
