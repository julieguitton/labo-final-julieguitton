using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public string ModePaiement { get; private set; }
        public string Lieu { get; private set; }
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CB.IsChecked == true)
            {
                ModePaiement = "Carte Bancaire";
            }
            else 
                ModePaiement = "Especes";

            if (SurPlace.IsChecked == true)
            {
                Lieu = "Sur Place";
            }
            else Lieu = "A Emporter";

            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
