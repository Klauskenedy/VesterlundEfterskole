using DataClasses;
using FunctionLayer;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VesterlundEfterskole2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VesterlundFunction function = new VesterlundFunction();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = function;
        }

        private void btnOpretBog_Click(object sender, RoutedEventArgs e)
        {
            Window p = new OpretBog(function);
            p.Owner = this;
            p.Show();
        }

        private void btnRedigerBog_Click(object sender, RoutedEventArgs e)
        {
            Bog selectedbog = dtgBøger.SelectedItem as Bog;
            string messageBoxText = "Vælg en bog for at redigere";
            string caption = "Fejl!";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            if (selectedbog != null)
            {
                Window q = new RedigerBog(function, selectedbog);
                q.Owner = this;
                q.Show();
            }
            else
            {
                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }

        private void btnSletBog_Click(object sender, RoutedEventArgs e)
        {
            Bog valgtebog = dtgBøger.SelectedItem as Bog;
            function.SletBog(valgtebog);
        }

        private void btnTilføjUdlaan_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                function.TilføjUdlaan((cbxBog.SelectedItem as Bog), (cbxLaaner.SelectedItem as Laaner));
                cbxBog.SelectedIndex = -1;
                cbxLaaner.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl i nyt Udlån");
            }
        }

        private void btnSletUdlaan_Click(object sender, RoutedEventArgs e)
        {
            function.UdlaanFjern(dtgUdlån.SelectedItem as Udlaan);
        }

        private void btnOpretLåner_Click(object sender, RoutedEventArgs e)
        {
            Window a = new OpretLaaner(function);
            a.Owner = this;
            a.Show();
        }

        private void btnRedigerLåner_Click(object sender, RoutedEventArgs e)
        {
            Laaner selectedlaaner = dtgLåner.SelectedItem as Laaner;
            string messageBoxText = "Vælg en Låner for at redigere";
            string caption = "Fejl!";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            if (selectedlaaner != null)
            {
                Window q = new RedigerLaaner(function, selectedlaaner);
                q.Owner = this;
                q.Show();
            }
            else
            {
                MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
            }
        }
    }
}