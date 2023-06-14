using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using ProjetMacdo;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Burger> listburger = new ObservableCollection<Burger>(Burger.LoadBurgersFromCSV("C:/Users/Julie/source/repos/labo-1-5-julieguitton/ProjetMacdo/WpfApp1/fichiers/burgers.csv"));
        public ObservableCollection<Boisson> listboisson = new ObservableCollection<Boisson>(Boisson.LoadBoissonsFromCSV("C:/Users/Julie/source/repos/labo-1-5-julieguitton/ProjetMacdo/WpfApp1/fichiers/boissons.csv"));
        public ObservableCollection<Produit> listproduit = new ObservableCollection<Produit>();
        
        UserControl1 userControl1 = new UserControl1();
        UserControl2 userControl2 = new UserControl2();
        UserControl3 userControl3 = new UserControl3();
        Window1 fenetre;
        Window2 fenetre2;

        public MainWindow()
        {
            FastFood.LoadCommandes();
            InitializeComponent();

            this.Left = MyAppParamManager.PositionX;
            this.Top = MyAppParamManager.PositionY;
            this.Height = MyAppParamManager.Height;
            this.Width = MyAppParamManager.Width;


            FastFood.Instance.ResetCommandeEnCours();
            userControl1.BurgersLV.DataContext = listburger;
            userControl2.BoissonsLV.DataContext = listboisson;
            GridProduits.DataContext = listproduit;
            Closing += MainWindow_Closing;
        }

        private void LVMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = LVMenu.SelectedIndex;
            switch(i)
            {
                case 0:
                    GrilleProduits.Children.Clear();
                    GrilleProduits.Children.Add(userControl1);
                    break;
                case 1:
                    GrilleProduits.Children.Clear();
                    GrilleProduits.Children.Add(userControl2);
                    break;
                case 2:
                    GrilleProduits.Children.Clear();
                    GrilleProduits.Children.Add(userControl3);
                    break;
                default:
                    GrilleProduits.Children.Clear();
                    break;
            }
        }

        private void RetirerProduit_Click(object sender, RoutedEventArgs e)
        {
            int i = GridProduits.SelectedIndex;
            if(i>=0)
            {
                if(listproduit[i] is Burger burger) 
                {
                    FastFood.CommandeEnCours.RetirerBurger(burger);
                }
                else if (listproduit[i] is Boisson boisson)
                {
                    FastFood.CommandeEnCours.RetirerBoisson(boisson);
                }
                else if (listproduit[i] is Accompagnement frites)
                {
                    FastFood.CommandeEnCours.RetirerFrites(frites);
                }
                else if (listproduit[i] is ProjetMacdo.Menu menu)
                {
                    FastFood.CommandeEnCours.RetirerMenu(menu);
                }
                listproduit.RemoveAt(i);
                TBPrix.Text = FastFood.CommandeEnCours.CalculerPrixTotal().ToString() + " €";
            }
            else
                MessageBox.Show("Veuillez selectionner un produit à retirer");
        }

        private void PayerCommande_Click(object sender, RoutedEventArgs e)
        {
            fenetre2 = new Window2();
            if (FastFood.CommandeEnCours.CalculerPrixTotal() != 0)
            {
                // Afficher la fenetre au milieu
                fenetre2.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                fenetre2.Owner = Application.Current.MainWindow;
                if (fenetre2.ShowDialog() == true)
                {
                    FastFood.CommandeEnCours.Lieu = fenetre2.Lieu;
                    FastFood.CommandeEnCours.Reglement = fenetre2.ModePaiement;
                    FastFood.CommandeEnCours.Numero = Commande.numCommande;
                    FastFood.CommandeEnCours.Date = DateTime.Now;
                    FastFood.Instance.AjouterCommande(FastFood.CommandeEnCours);
                    listproduit.Clear();
                    FastFood.CommandeEnCours.PrixTotal = FastFood.CommandeEnCours.CalculerPrixTotal();
                    FastFood.Instance.ResetCommandeEnCours();
                    TBPrix.Text = FastFood.CommandeEnCours.CalculerPrixTotal().ToString() + " €";
                    MessageBox.Show("Votre commande a été payée, veuillez la récupérer au comptoir !","Paiement");
                }
            }
            else
                MessageBox.Show("Votre commande est vide, veuillez rajouter des articles !");
        }

        private void BoutonHistorique_Click(object sender, RoutedEventArgs e)
        {
            FenetreCodeAdmin fenetreCode = new FenetreCodeAdmin();
            // Afficher la fenetre au milieu
            fenetreCode.WindowStartupLocation = WindowStartupLocation.CenterOwner;          
            fenetreCode.Owner = Application.Current.MainWindow;

            fenetreCode.ShowDialog();
            if (fenetreCode.codeOK == true)
            {
                fenetre = new Window1();
                fenetre.GridCommandes.DataContext = FastFood.Instance.Commandes;
                fenetre.ShowDialog();
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FastFood.SaveCommandes();
            MyAppParamManager.PositionX = (int)this.Left;
            MyAppParamManager.PositionY = (int)this.Top;
            MyAppParamManager.Height = (int)this.Height;
            MyAppParamManager.Width = (int)this.Width;
        }

        private void ModifTailleFenetre_Click(object sender, RoutedEventArgs e)
        {
            FenetreCodeAdmin fenetreCode = new FenetreCodeAdmin();
            // Afficher la fenetre au milieu
            fenetreCode.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            fenetreCode.Owner = Application.Current.MainWindow;
            fenetreCode.ShowDialog();
            if(fenetreCode.codeOK == true)
            {
                FenetreTailleFenetre maFenetre = new FenetreTailleFenetre();

                maFenetre.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                maFenetre.Owner = Application.Current.MainWindow;
                maFenetre.ShowDialog();
                if (maFenetre.FenetreHeight >= 500 && maFenetre.FenetreHeight <= 1080)
                {                                      
                    if (maFenetre.FenetreWidth >= 800 && maFenetre.FenetreWidth <= 1980)
                    {
                        this.Height = maFenetre.FenetreHeight;
                        this.Width = maFenetre.FenetreWidth;
                        MyAppParamManager.Height = (int)this.Height;
                        MyAppParamManager.Width = (int)this.Width;
                    }
                    else
                    {
                        MessageBox.Show("Valeur Width trop grande ou trop petite");
                    }
                }
                else
                {
                    MessageBox.Show("Valeur Height trop grande ou trop petite");
                }

                

            }
           
        }
    }
}
