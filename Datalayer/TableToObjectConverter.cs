using DataClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    class TableToObjectConverter
    {
        SqlAccess sqlAccess;
        public TableToObjectConverter(SqlAccess sqlAccess)
        {
            this.sqlAccess = sqlAccess;
        }
        public ObservableCollection<Bog> GetBogListe(DataTable table)
        {
            ObservableCollection<Bog> liste = new ObservableCollection<Bog>();
            foreach (DataRow row in table.Rows)
            {
                Bog bog = GetBog(row);
                liste.Add(bog);
            }
            return liste;
        }

        private DataTable GetBogTable(int id)
        {
            return sqlAccess.ExcecuteSql($"select * from Bog where Id = {id}");
        }


        private Bog GetBog(DataRow row)
        {
            Bog bog = new Bog((int)row["Id"], (string)row["Forfatter"], (string)row["Titel"], (string)row["Udgiver"], (int)row["Udgivelsesaar"], (int)row["Antal"], (int)row["ISBN"]);
            return bog;
        }
        public ObservableCollection<Laaner> GetLaanerListe(DataTable table)
        {
            ObservableCollection<Laaner> liste = new ObservableCollection<Laaner>();
            foreach (DataRow row in table.Rows)
            {
                Laaner laaner = GetLaaner(row);
                liste.Add(laaner);
            }
            return liste;
        }

        private DataTable GetLaanerTable(int id)
        {
            return sqlAccess.ExcecuteSql($"select * from Laaner where Id = {id}");
        }

        private Laaner GetLaaner(DataRow row)
        {
            Laaner laaner = new Laaner((int)row["Id"], (int)row["Nummer"], (string)row["Email"]);
            return laaner;
        }

        public ObservableCollection<Udlaan> GetUdlaan(DataTable table)
        {
            ObservableCollection<Udlaan> liste = new ObservableCollection<Udlaan>();
            foreach (DataRow row in table.Rows)
            {
                Udlaan udlaan = GetUdlaaner(row);
                liste.Add(udlaan);
            }
            return liste;
        }


        private Udlaan GetUdlaaner(DataRow row)
        {
            DataTable dt = GetBogTable((int)row["BogId"]);
            DataRow bogRow = dt.Rows[0];
            Bog bog = GetBog(bogRow);
            DataTable qt = GetLaanerTable((int)row["LaanerId"]);
            DataRow qtRow = qt.Rows[0];
            Laaner laaner = GetLaaner(qtRow);
            Udlaan udlaaner = new Udlaan((int)row["ID"], bog, laaner);
            return udlaaner;
        }


        //public ObservableCollection<Bestilling> GetBestillinger(DataTable table)
        //{
        //    ObservableCollection<Bestilling> liste = new ObservableCollection<Bestilling>();
        //    foreach (DataRow row in table.Rows)
        //    {
        //        Bestilling bestilling = GetBestilling(row);
        //        liste.Add(bestilling);
        //    }
        //    return liste;
        //}
        //public Bestilling GetBestilling(DataRow row)
        //{
        //    DataTable t = GetVareTable((int)row["VareId"]); //Håndterer fremmednøglen
        //    DataRow vareRow = t.Rows[0];
        //    Vare vare = GetVare(vareRow);
        //    Bestilling bestilling = new Bestilling((int)row["Id"], vare, (int)row["antal"]);
        //    return bestilling;
        //}
    }
}
