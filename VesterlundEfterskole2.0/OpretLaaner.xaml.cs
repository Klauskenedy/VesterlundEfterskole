using DataClasses;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VesterlundEfterskole2._0
{
    /// <summary>
    /// Interaction logic for OpretLaaner.xaml
    /// </summary>
    public partial class OpretLaaner : Window
    {
        VesterlundFunction function;
        public OpretLaaner(VesterlundFunction f)
        {
            InitializeComponent();
            function = f;
        }

        private void tbxOpretLaanerNummer_TextChanged(object sender, TextChangedEventArgs e)
        {
            string messageBoxText = "Felt skal være et tal.";
            string caption = "Fejl!";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            Regex regex = new Regex("[^0-9]+");
            bool handle = regex.IsMatch(tbxOpretLaanerNummer.Text);
            if (handle)
            {
                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                tbxOpretLaanerNummer.Text = "";
            }
        }

        private void btnOpretLaaner_Click(object sender, RoutedEventArgs e)
        {
            string mail = tbxOpretLaanerMail.Text;
            int nummer = int.Parse(tbxOpretLaanerNummer.Text);

            function.TilføjLaaner(nummer, mail);

            Window p = OpretLaaner.GetWindow(this);
            p.Hide();

        }
    }
}
