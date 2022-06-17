using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThaiNationalIDCard;
using PCSC;

namespace pcscThaiNationalCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ThaiNationalCard thaicard = new ThaiNationalCard();
            ReaderStatus readstat = new ReaderStatus();
            readstat.ReaderStatusNow();
            thaicard.readCard();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
        
    }
  
}
