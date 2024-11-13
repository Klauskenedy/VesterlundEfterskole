using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataClasses;
using System.Text.RegularExpressions;



namespace FunctionLayer
{
    public class VesterlundFunction : INotifyPropertyChanged
    {
        VesterlundData data = new VesterlundData();
        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<Bog> BogOversigt
        {
            get
            {
                return data.BogListe;
            }
        }
        public ObservableCollection<Laaner> LaanerOversigt
        {
            get
            {
                return data.LaanerListe;
            }
        }
        public ObservableCollection<Udlaan> UdlaanOversigt
        {
            get
            {
                return data.UdlaanListe;
            }
        }
        public void TilføjUdlaan(Bog bog, Laaner laaner)
        {
            Udlaan udlaan = new Udlaan(bog, laaner);
            data.UdlaanAdd(udlaan, bog, laaner);
            RaisePropertyChanged(nameof(UdlaanOversigt));
        }
        public bool IsIntCheck(string tal)
        {
            Regex regex = new Regex("[^0-9]+");
            bool handle = regex.IsMatch(tal);
            return handle;
        }
        public void TilføjLaaner(int nummer, string mail)
        {
            Laaner laaner = new Laaner(nummer, mail);
            data.LaanerAdd(laaner);
            RaisePropertyChanged(nameof(LaanerOversigt));
        }
        public void TilføjBog(string forfatter, string titel, string udgiver, int udgivelsesaar, int antal, int isbn)
        {
            Bog bog = new Bog(forfatter, titel, udgiver, udgivelsesaar, antal, isbn);
            data.BogAdd(bog);
            RaisePropertyChanged(nameof(BogOversigt));
        }
        public void SletBog(Bog bog)
        {
            data.BogSlet(bog);
            RaisePropertyChanged(nameof(BogOversigt));
        }
        public void GemRedigering(Bog bog, string nyforfatter, string nytitel, string nyudgiver, int nyudgivelsesaar, int nyantal)
        {
            data.GemRedigering(bog, nyforfatter, nytitel, nyudgiver, nyudgivelsesaar, nyantal);
            RaisePropertyChanged(nameof (BogOversigt));
        }
        public void UdlaanFjern(Udlaan udlaan)
        {
            data.SletUdlaan(udlaan);
            RaisePropertyChanged(nameof(UdlaanOversigt));
        }
        public void GemRedigeringLaaner(Laaner laaner, int nummer, string mail)
        {
            data.GemRedigeringLaaner(laaner, nummer, mail);
            RaisePropertyChanged(nameof(LaanerOversigt));
        }
    }
}
