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
using DataClasses;
using FunctionLayer;

namespace VesterlundEfterskole2._0
{
    public partial class RedigerBog : Window
    {
        VesterlundFunction function;
        Bog bogen;
        public RedigerBog(VesterlundFunction f, Bog bog)
        {
            InitializeComponent();
            function = f;
            tbxForfatterRediger.Text = bog.Forfatter.ToString();
            tbxTitelRediger.Text = bog.Titel.ToString();
            tbxUdgiverRediger.Text = bog.Udgiver.ToString();
            tbxUdgivelsesaarRediger.Text = bog.Udgivelsesaar.ToString();
            tbxAntalRediger.Text = bog.Antal.ToString();
            bogen = bog;
        }

        private void tbxUdgivelsesaarRediger_TextChanged(object sender, TextChangedEventArgs e)
        {
            string messageBoxText = "Felt skal være et tal.";
            string caption = "Fejl!";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            Regex regex = new Regex("[^0-9]+");
            bool handle = regex.IsMatch(tbxUdgivelsesaarRediger.Text);
            if (handle)
            {
                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                tbxUdgivelsesaarRediger.Text = bogen.Udgivelsesaar.ToString();
            }
        }

        private void tbxAntalRediger_TextChanged(object sender, TextChangedEventArgs e)
        {
            string messageBoxText = "Felt skal være et tal.";
            string caption = "Fejl!";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            Regex regex = new Regex("[^0-9]+");
            bool handle = regex.IsMatch(tbxAntalRediger.Text);
            if (handle)
            {
                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                tbxAntalRediger.Text = bogen.Antal.ToString();
            }
        }

        private void btnRedigerBog_Click(object sender, RoutedEventArgs e)
        {
            string nyforfatter = tbxForfatterRediger.Text;
            string nytitel = tbxTitelRediger.Text;
            string nyudgiver = tbxUdgiverRediger.Text;
            int nyudgivelsesaar = int.Parse(tbxUdgivelsesaarRediger.Text);
            int nyantal = int.Parse(tbxAntalRediger.Text);
            int ISBN = bogen.ISBN;
            function.GemRedigering(bogen, nyforfatter, nytitel, nyudgiver, nyudgivelsesaar, nyantal);

            Window p = OpretBog.GetWindow(this);
            p.Hide();
        }
    }
}
