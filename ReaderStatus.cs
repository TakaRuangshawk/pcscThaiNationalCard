using PCSC;
using System;
using System.Collections.Generic;
namespace pcscThaiNationalCard
{
    internal class ReaderStatus
    {
        public void ReaderStatusNow()
        {
            var contextFactory = ContextFactory.Instance;
            using (var ctx = contextFactory.Establish(SCardScope.System))
            {
                var readerNames = ctx.GetReaders();

                if (IsEmpty(readerNames))
                {
                    //check readers
                    Console.WriteLine("No reader connected.");
                    Console.ReadKey();
                    return;
                }

                var readerStates = ctx.GetReaderStatus(readerNames);

                foreach (var state in readerStates)
                {
                    
                    Console.WriteLine("Reader_name : " + state.ReaderName);//readername :: ACS CCID USB READER
                    Console.WriteLine("State_now : " + state.EventState);
                    //sample value | State_now : Changed, Present << this state is Inserted Card.
                    //sample value | State_now : Changed, Empty << this state is Ejected Card or No Card.
                    //sample value | State_now : Changed, Present, Mute << this state is Inserted Card but reader can't read card.
                    //sample value | State_now : Changed, Present, Unpowered << this state is Inserted Card Already before program process.
                    state.Dispose();

                }
            }
        }
        private static bool IsEmpty(ICollection<string> readerNames) =>
            readerNames == null || readerNames.Count < 1;
    }
}
