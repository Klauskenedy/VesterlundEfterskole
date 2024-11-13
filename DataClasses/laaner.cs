using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClasses
{
    public class Laaner
    {
        public int Elevnummer { get; set; }
        public int LæreId { get; set; }
        public string Email { get; set; }

        public int ID { get; set; }

        public Laaner(int id, int nummer, string email)
        {
            ID = id;

            if (nummer > 1000)
            {
                Elevnummer = nummer;
                Email = email;
            }
            else
            {
                LæreId = nummer;
                Email = email;
            }
        }
        public Laaner(int nummer, string email)
        {
            if (nummer > 1000)
            {
                Elevnummer = nummer;
                Email = email;
            }
            else
            {
                LæreId = nummer;
                Email = email;
            }
        }
    }
}
