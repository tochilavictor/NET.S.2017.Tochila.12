using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmergenceLogic
{
    public class PolandGovernment
    {
        public void RegisterEarthShake(Eemergency emg)
        {
            emg.EarthShake += ResponseToThePeople;
        }
        public void UnregisterEarthShake(Eemergency emg)
        {
            emg.EarthShake -= ResponseToThePeople;
        }
        public void ResponseToThePeople(object obj, EarthShakeEventArgs args)
        {
            if (string.Compare(args.Country, "Poland", StringComparison.OrdinalIgnoreCase) != 0)
                Console.WriteLine("It's not our country, so be quiet");
            else if (args.Grade < 3)
                Console.WriteLine("It's not so serious earthshake, so be quiet , but don't go out");
            else Console.WriteLine("It's a disaster, so sit strongly in your house,if it's rather durable ofcourse");
        }
    }
    public class LatviaGovernment
    {
        public void RegisterEarthShake(Eemergency emg)
        {
            emg.EarthShake += ResponseToThePeople;
        }
        public void UnregisterEarthShake(Eemergency emg)
        {
            emg.EarthShake -= ResponseToThePeople;
        }
        public void ResponseToThePeople(object obj, EarthShakeEventArgs args)
        {
            if (string.Compare(args.Country, "Poland", StringComparison.OrdinalIgnoreCase) == 0)
                Console.WriteLine("We need to send humanitarian assistance to our neighboor");
            else if (string.Compare(args.Country, "Latvia", StringComparison.OrdinalIgnoreCase) != 0)
                Console.WriteLine("We cant help this country, it's situated too far");
            else if (args.Grade < 5)
                Console.WriteLine("It's not so serious earthshake, help will come soon");
            else Console.WriteLine("Wait until you will be taken to the nearest fortified position");
        }
    }
}
