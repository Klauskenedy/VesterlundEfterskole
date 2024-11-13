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
using FunctionLayer;

namespace VesterlundEfterskole2._0
{
    public partial class OpretBog : Window
    {
        VesterlundFunction function;
        public OpretBog(VesterlundFunction f)
        {
            InitializeComponent();
            function = f;
        }

        private void btnOpretNyBog_Click(object sender, RoutedEventArgs e)
        {
            string forfatter = tbxForfatterTilføj.Text;
            string titel = tbxTitelTilføj.Text;
            string udgiver = tbxUdgiverTilføj.Text;
            int udgivelsesaar = int.Parse(tbxUdgivelsesaarTilføj.Text);
            int antal = int.Parse(tbxAntalTilføj.Text);
            int isbn = int.Parse(tbxISBNTilføj.Text);

            function.TilføjBog(forfatter, titel, udgiver, udgivelsesaar, antal, isbn);

            Window p = OpretBog.GetWindow(this);
            p.Hide();
        }

        private void tbxUdgivelsesaarTilføj_TextChanged(object sender, TextChangedEventArgs e)
        {
            string messageBoxText = "Felt skal være et tal.";
            string caption = "Fejl!";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            Regex regex = new Regex("[^0-9]+");
            bool handle = regex.IsMatch(tbxUdgivelsesaarTilføj.Text);
            if (handle)
            {
                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                tbxUdgivelsesaarTilføj.Text = "";
            }
        }

        private void tbxAntalTilføj_TextChanged(object sender, TextChangedEventArgs e)
        {
            string messageBoxText = "Felt skal være et tal.";
            string caption = "Fejl!";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            Regex regex = new Regex("[^0-9]+");
            bool handle = regex.IsMatch(tbxAntalTilføj.Text);
            if (handle)
            {
                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                tbxAntalTilføj.Text = "";
            }
        }

        private void tbxISBNTilføj_TextChanged(object sender, TextChangedEventArgs e)
        {
            string messageBoxText = "Felt skal være et tal.";
            string caption = "Fejl!";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            Regex regex = new Regex("[^0-9]+");
            bool handle = regex.IsMatch(tbxISBNTilføj.Text);
            if (handle)
            {
                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                tbxISBNTilføj.Text = "";
            }
        }
    }
}
