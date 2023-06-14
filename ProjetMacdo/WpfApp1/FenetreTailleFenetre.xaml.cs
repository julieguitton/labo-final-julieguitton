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
    /// Logique d'interaction pour FenetreTailleFenetre.xaml
    /// </summary>
    public partial class FenetreTailleFenetre : Window
    {
        public int FenetreHeight;
        public int FenetreWidth;
        public FenetreTailleFenetre()
        {
            InitializeComponent();
        }

        private void BoutonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Close();    

        }

        private void BoutonValider_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FenetreHeight = Int32.Parse(TBHeight.Text);
                FenetreWidth = Int32.Parse(TBWidth.Text);
                Close();

            }
            catch (FormatException)
            {
                MessageBox.Show("Veuillez remplir les deux champs");
            }
        }
    }
}
