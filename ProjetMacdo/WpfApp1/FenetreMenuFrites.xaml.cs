using ProjetMacdo;
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
    /// Logique d'interaction pour FenetreMenuFrites.xaml
    /// </summary>
    public partial class FenetreMenuFrites : Window
    {
        public Accompagnement fritechoisie;
        public FenetreMenuFrites()
        {
            InitializeComponent();
        }

        private void FritesMenuLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = FritesMenuLV.SelectedIndex;
            if(i==0)
            {
                fritechoisie = new Accompagnement();
                fritechoisie.Nom = "Frites";
                fritechoisie.Image = "images/frites/frites.jpg";
                DialogResult = true;
                Close();
            }
            else if(i==1) 
            {
                fritechoisie = new Accompagnement();
                fritechoisie.Nom = "Potatoes";
                fritechoisie.Image = "images/frites/potatoes2.png";
                DialogResult = true;
                Close();
            }

        }
        private void FenetreMenuFrites_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
