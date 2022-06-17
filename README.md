# pcscThaiNationalCard
  Reader Status Example

	using PCSC;
	...
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
	
Thai National Card Example
	
	      using System;
          using ThaiNationalIDCard;
          namespace pcscThaiNationalCard{
          internal class ThaiNationalCard{
              public void readCard(){
                ThaiIDCard idcard = new ThaiIDCard();
                Personal personal = idcard.readAll();
                if (personal != null)
                {
                    Console.WriteLine(personal.Citizenid);//personID
                    Console.WriteLine(personal.Birthday.ToString("dd/MM/yyyy"));//birthday
                    Console.WriteLine(personal.Sex);//gender
                    Console.WriteLine(personal.Th_Prefix);//thai prefix
                    Console.WriteLine(personal.Th_Firstname);//thai firstname
                    Console.WriteLine(personal.Th_Lastname);//thai lastname
                    Console.WriteLine(personal.En_Prefix);//english prefix
                    Console.WriteLine(personal.En_Firstname);//english firstname
                    Console.WriteLine(personal.En_Lastname);//english lastname
                    Console.WriteLine(personal.Issue.ToString("dd/MM/yyyy"));//issue date
                    Console.WriteLine(personal.Expire.ToString("dd/MM/yyyy")); //expire date
                    Console.WriteLine(personal.Address);//all detail in address
                    Console.WriteLine(personal.addrHouseNo); //house no.
                    Console.WriteLine(personal.addrVillageNo); //village no.
                    Console.WriteLine(personal.addrLane); //lane no.
                    Console.WriteLine(personal.addrRoad); //road
                    Console.WriteLine(personal.addrTambol);//subdistrict
                    Console.WriteLine(personal.addrAmphur);//district
                    Console.WriteLine(personal.addrProvince);//province
                    Console.WriteLine(personal.Issuer);
                }
                else if (idcard.ErrorCode() > 0)
                {
                    Console.WriteLine(idcard.Error());
                }
            }
        }
    }
	
