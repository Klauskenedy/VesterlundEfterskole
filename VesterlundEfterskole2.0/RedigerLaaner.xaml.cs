using DataClasses;
using FunctionLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VesterlundEfterskole2._0
{
    /// <summary>
    /// Interaction logic for RedigerLaaner.xaml
    /// </summary>
    public partial class RedigerLaaner : Window
    {
        VesterlundFunction function;
        Laaner laaneren;
        public RedigerLaaner(VesterlundFunction f, Laaner laaner)
        {
            InitializeComponent();
            function = f;
            tbxRedigerMail.Text = laaner.Email.ToString();
            int nummer;
            if (laaner.Elevnummer == 0 )
            {
                nummer = laaner.LæreId;
            }
            else
            {
                nummer = laaner.Elevnummer;
            }

            laaneren = laaner;
        }



        private void btnRedigerLaanerGem_Click(object sender, RoutedEventArgs e)
        {
            string mail = tbxRedigerMail.Text;
            int nummer;
            if (laaneren.Elevnummer == 0)
            {
                nummer = laaneren.LæreId;
            }
            else
            {
                nummer = laaneren.Elevnummer;
            }

            function.GemRedigeringLaaner(laaneren, nummer, mail);

            Window p = RedigerLaaner.GetWindow(this);
            p.Hide();
        }
    }
}
