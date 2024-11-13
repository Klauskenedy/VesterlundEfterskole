using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClasses
{
    public class Bog
    {
        public string Forfatter {  get; set; }
        public string Titel { get; set; }
        public string Udgiver { get; set; }
        public int Udgivelsesaar { get; set; }
        public int Antal {  get; set; }
        public int ISBN { get; set; }

        public int Id { get; set; }

        public Bog(int id, string forfatter, string titel, string udgiver, int udgivelsesaar, int antal, int isbn)
        {
            Forfatter = forfatter;
            Titel = titel;
            Udgiver = udgiver;
            Udgivelsesaar = udgivelsesaar;
            Antal = antal;
            ISBN = isbn;
            Id = id;
        }
        public Bog(string forfatter, string titel, string udgiver, int udgivelsesaar, int antal, int isbn)
        {
            Forfatter = forfatter;
            Titel = titel;
            Udgiver = udgiver;
            Udgivelsesaar = udgivelsesaar;
            Antal = antal;
            ISBN = isbn;
            Id = 0;
        }
        public Bog(string forfatter, string titel, int antal)
        {
            Forfatter = forfatter;
            Titel = titel;
            Antal = antal;
        }


    }
}
