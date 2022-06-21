using System;
using ThaiNationalIDCard;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
namespace pcscThaiNationalCard
{
    internal class ThaiNationalCard
    {
        public void ReadCard()
        {
            ThaiIDCard idcard = new ThaiIDCard();
            Personal personal = idcard.readAllPhoto();
            const string path_thaicardpic = "D:\\grgbanking\\ecat\\thainationalcard\\pic\\";
            if (!Directory.Exists(path_thaicardpic))
            {
                Directory.CreateDirectory(path_thaicardpic);
            }
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
                using (Image img = Image.FromStream(new MemoryStream(personal.PhotoRaw)))
                {
                    string path = Path.GetFullPath(path_thaicardpic + personal.Citizenid + "_" + DateTime.Now.ToString("yyyymmdd_hhmmss") + ".jpg");
                    img.Save(path, ImageFormat.Jpeg);
                }
            }
            else if (idcard.ErrorCode() > 0)
            {
                Console.WriteLine(idcard.Error());
            }
        }

      
    }
}
