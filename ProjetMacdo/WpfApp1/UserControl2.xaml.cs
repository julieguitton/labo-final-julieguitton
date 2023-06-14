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
    /// Logique d'interaction pour UserControl2.xaml
    /// </summary>
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void AjoutBoisson_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(Parent) as MainWindow;
            int quantite;
            bool check = int.TryParse(TBQuantite.Text, out quantite);
            if (check && quantite > 0)
            {
                int i = BoissonsLV.SelectedIndex;
                if (i >= 0)
                {
                    int trouve = 0;
                    Boisson b = new Boisson(mainWindow.listboisson[i]);
                    b.Quantite = quantite;

                    //glacons
                    if(GlaconsAvec.IsChecked==true) { b.Glacons = true; }
                    else 
                    { 
                        b.Glacons = false; 
                    }

                    //Taille
                    if(RBPetit.IsChecked==true) { b.Taille = 1;  }
                    else if(RBMoyen.IsChecked==true) { b.Taille = 2;  }
                    else { b.Taille = 3; }


                    foreach (Produit produit in mainWindow.listproduit)
                    {
                        if (produit.Nom == b.Nom)
                        {
                            trouve = 1;
                            produit.Quantite += b.Quantite;
                            foreach (Burger burger in FastFood.CommandeEnCours.Burger)
                            {
                                if (burger.Nom == b.Nom)
                                {
                                    burger.Quantite = produit.Quantite;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    if (trouve != 1)
                    {
                        FastFood.CommandeEnCours.AjouterBoisson(b);
                        mainWindow.listproduit.Add(b);
                    }
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


    }
}
