using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataClasses
{
    public class Udlaan
    {
        public Laaner Laaner {  get; set; }
        public Bog Bog { get; set; }
        public int ID { get; set; }
        
        public Udlaan(int id, Bog bog, Laaner laaner)
        {
            ID = id;
            Bog = bog;
            Laaner = laaner;
        }
        public Udlaan(Bog bog, Laaner laaner)
        {
            Bog = bog;
            Laaner = laaner;
        }
    }
}
