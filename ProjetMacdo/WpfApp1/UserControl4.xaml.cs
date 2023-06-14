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
using ProjetMacdo;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour UserControl4.xaml
    /// </summary>
    public partial class UserControl4 : UserControl
    {
        public ProjetMacdo.Menu menu;
        public UserControl4()
        {

            
            InitializeComponent();
        }

        private void AjoutMenu_Click(object sender, RoutedEventArgs e)
        {
            if (LVMenus.SelectedIndex>= 0)
            {
                FenetreMenuBurger fenetreburger = new FenetreMenuBurger();
                fenetreburger.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                fenetreburger.Owner = Application.Current.MainWindow;
                if (fenetreburger.ShowDialog() == true)
                {
                    FenetreMenuBoisson fenetreboisson = new FenetreMenuBoisson();
                    fenetreboisson.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    fenetreboisson.Owner = Application.Current.MainWindow;
                    if (fenetreboisson.ShowDialog() == true)
                    {
                        FenetreMenuFrites fenetrefrites = new FenetreMenuFrites();
                        fenetrefrites.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        fenetrefrites.Owner = Application.Current.MainWindow;
                        if (fenetrefrites.ShowDialog() == true)
                        {

                            menu = new ProjetMacdo.Menu();                   
                            menu.Boisson = fenetreboisson.boissonchoisie;
                            menu.Accompagnement = fenetrefrites.fritechoisie;
                            if (LVMenus.SelectedIndex == 0)
                            {                               
                                menu.Burger = fenetreburger.burgerchoisi;
                                menu.Boisson.Taille = 2;
                                menu.Accompagnement.Taille = 2;
                                menu.CalculPrixMenu();
                            }
                            else if(LVMenus.SelectedIndex == 1)
                            {
                                menu.Nom = "Menu Maxi";
                                menu.Burger = fenetreburger.burgerchoisi;
                                menu.Boisson.Taille = 3;
                                menu.Accompagnement.Taille = 3;
                                menu.CalculPrixMenu();
                            }
                            MainWindow mainWindow = Window.GetWindow(Parent) as MainWindow;
                            int trouve = 0;
                            FastFood.CommandeEnCours.AjouterMenu(menu);
                            FastFood.Instance.RemplirListeProduit();

                            mainWindow.TBPrix.Text = FastFood.CommandeEnCours.CalculerPrixTotal().ToString() + " €";
                                }

                            }
                        else
                            MessageBox.Show("Menu annulé (Burger)");
                    }
                    else
                        MessageBox.Show("Menu annulé (Boisson)");
                }
                else
                    MessageBox.Show("Menu annulé(Frites)");
            }
        }

    
}
