using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using NetworkUtility.DNS;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        private readonly IDNS _dNS;
        public NetworkService(IDNS dNS)
        { 
            _dNS = dNS;
        }
        public string SendPing()
        {
            //Funktion ist gefaktt, return Wert der Funktion ist gefekt in test case
           var dnsSucces = _dNS.SendDNS();
            if (dnsSucces)
            {
                return "Succes: Ping Sent!";
            }
            else
            {
                return "Succes: Ping not sent!"; ;
            }
        }

        public int TimeOut(int a, int b)
        {
            return  a + b;
        }

        public DateTime LastPingDate()
        {
            Console.WriteLine("DateTime.Now!");
            Console.WriteLine(DateTime.Now);
            return DateTime.Now; 
        }

        public PingOptions GetPingOptions() 
        {
            return new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
        }

        public IEnumerable<PingOptions> GetPingOptionsList()
        {
            IEnumerable<PingOptions> pingOptions = new[]
            {
               new PingOptions()
               {
                    DontFragment = true,
                    Ttl = 1
               },
               new PingOptions()
               {
                    DontFragment = true,
                    Ttl = 1
               },
               new PingOptions()
               {
                    DontFragment = true,
                    Ttl = 1
               },
            };
            return pingOptions;
        }
    }
}
