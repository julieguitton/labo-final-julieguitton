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
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        
        public UserControl1()
        {
            InitializeComponent();
        }

        private void AjoutBurger_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(Parent) as MainWindow;
            int quantite;
            bool check = int.TryParse(TBQuantite.Text, out quantite);
            if (check && quantite > 0)
            {
                int i = BurgersLV.SelectedIndex;
                if(i>=0)
                {
                    int trouve = 0;
                    Burger b = new Burger(mainWindow.listburger[i]);
                    b.Quantite = quantite;

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
                        FastFood.CommandeEnCours.AjouterBurger(b);
                    FastFood.Instance.RemplirListeProduit();       
                    mainWindow.TBPrix.Text = FastFood.CommandeEnCours.CalculerPrixTotal().ToString() + " €";
                }
                else
                {
                    MessageBox.Show("Veuillez selectionner un burger");
                }
                
            }
            else
            {
                MessageBox.Show("Veuillez entrer une quantité valide");
            }


        }
    }
}
