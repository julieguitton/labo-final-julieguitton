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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour UserControl3.xaml
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        private void AjoutFrites_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(Parent) as MainWindow;
            int quantite;
            bool check = int.TryParse(TBQuantite.Text, out quantite);
            if (check && quantite > 0)
            {
                int i = LVFrites.SelectedIndex;
                if (i >= 0)
                {
                    
                    int trouve = 0;
                    Accompagnement b = new Accompagnement();
                    if (i == 0)
                    {
                        b.Nom = "Frites";
                    }
                    else b.Nom = "Potatoes";

                    b.Quantite = quantite;

                

                    //Taille
                    if (PetitFrite.IsChecked == true) { b.Taille = 1; }
                    else if (MoyenFrite.IsChecked == true) { b.Taille = 2; }
                    else { b.Taille = 3; }


                    FastFood.CommandeEnCours.AjouterFrites(b);
                    FastFood.Instance.RemplirListeProduit();
                    mainWindow.TBPrix.Text = FastFood.CommandeEnCours.CalculerPrixTotal().ToString() + " €";
                }
                else
                {
                    MessageBox.Show("Veuillez selectionner une boisson");
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer une quantité valide");
            }

        }

        private void LVFrites_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
