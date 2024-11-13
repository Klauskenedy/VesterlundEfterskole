using DataClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataClasses;

namespace DataLayer
{
    public class VesterlundData
    {
        TableToObjectConverter converter;
        SqlAccess sqlAccess;
        public VesterlundData()
        {
            sqlAccess = new SqlAccess();
            converter = new TableToObjectConverter(sqlAccess);
        }
        public ObservableCollection<Bog> BogListe
        {
            get
            {
                return converter.GetBogListe(sqlAccess.ExcecuteSql("select * from Bog"));
            }
        }
        public ObservableCollection<Laaner> LaanerListe
        {
            get
            {
                return converter.GetLaanerListe(sqlAccess.ExcecuteSql("select * from Laaner"));
            }
        }
        public ObservableCollection<Udlaan> UdlaanListe
        {
            get
            {
                return converter.GetUdlaan(sqlAccess.ExcecuteSql("select * from Udlaan"));
            }
        }
        public void LaanerAdd(Laaner laaner)
        {
            string mail = laaner.Email;
            int nummer;
            if (laaner.Elevnummer == 0)
            {
                nummer = laaner.LæreId;
            }
            else
            {
                nummer = laaner.Elevnummer;
            }

            sqlAccess.ExcecuteSql($"insert into Laaner (Email, Nummer) values ('{mail}', '{nummer}')");
        }
        public void BogAdd(Bog bog)
        {
            string forfatter = bog.Forfatter;
            string titel = bog.Titel;
            string udgiver = bog.Udgiver;
            int udgivelsesaar = bog.Udgivelsesaar;
            int antal = bog.Antal;
            int isbn = bog.ISBN;

            sqlAccess.ExcecuteSql($"insert into Bog (forfatter, titel, udgiver, udgivelsesaar, antal, isbn) values ('{forfatter}', '{titel}', '{udgiver}', '{udgivelsesaar}', '{antal}', '{isbn}')");
        }
        public void BogSlet(Bog bog)
        {
            sqlAccess.ExcecuteSql($"delete from bog where isbn = {bog.ISBN}");
        }
        public void GemRedigering(Bog bog, string nyforfatter, string nytitel, string nyudgiver, int nyudgivelsesaar, int nyantal)
        {
            sqlAccess.ExcecuteSql($"update bog set forfatter = '{nyforfatter}', titel = '{nytitel}', udgiver = '{nyudgiver}', udgivelsesaar = '{nyudgivelsesaar}', antal = '{nyantal}' WHERE ISBN = '{bog.ISBN}'");
        }
        public void GemRedigeringLaaner(Laaner laaner, int nummer, string mail)
        {
            sqlAccess.ExcecuteSql($"update laaner set Email = '{mail}' WHERE Nummer = '{nummer}'");
        }
        public void UdlaanAdd(Udlaan udlaan, Bog bog, Laaner laaner)
        {
            int id;
            if (bog.Id == null)
            {
                throw new Exception("ingen bog valgt");
            }
            if (laaner.ID == null)
            {
                throw new Exception("ingen Laaner valgt");
            }
            //id = udlaan.Bog.Id;
            sqlAccess.ExcecuteSql($"insert into Udlaan (BogId, LaanerId) values ({bog.Id}, {laaner.ID})");
        }
        public void SletUdlaan(Udlaan udlaan)
        {
            int id;
            if (udlaan == null){
                throw new Exception("Intet lån valgt");
            }
            id = udlaan.ID;
            sqlAccess.ExcecuteSql($"delete from udlaan where Id = {id}");
        }
    }
}
