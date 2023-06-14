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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjetMacdo;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour FenetreMenuBurger.xaml
    /// </summary>
    public partial class FenetreMenuBurger : Window
    {
        
        public Burger burgerchoisi;
        public ObservableCollection<Burger> listburgermenu = new ObservableCollection<Burger>(Burger.LoadBurgersFromCSV("C:/Users/Julie/source/repos/labo-1-5-julieguitton/ProjetMacdo/WpfApp1/fichiers/burgersmenu.csv"));
        public FenetreMenuBurger()
        {
            
            InitializeComponent();
            BurgersMenuLV.DataContext= listburgermenu;
        }

        private void BurgersMenuLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = BurgersMenuLV.SelectedIndex;
            if(i>=0) 
            {
                burgerchoisi = new Burger(listburgermenu[i]);
                DialogResult = true;
                Close();
            }
        }

        private void FenetreMenuBurger_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
    
}
