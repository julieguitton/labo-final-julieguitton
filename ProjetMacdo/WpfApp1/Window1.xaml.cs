using ProjetMacdo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string l;
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int i = GridCommandes.SelectedIndex;
           
            if(i>=0)
            {
                LabelNumero.DataContext = FastFood.Instance.Commandes[i].Numero;
                
                LabelLieu.DataContext = FastFood.Instance.Commandes[i].Lieu;
                ImageLieu.DataContext = FastFood.Instance.Commandes[i].Lieu;
                ImageReglement.DataContext = FastFood.Instance.Commandes[i].Reglement;

                
                LabelReglement.DataContext = FastFood.Instance.Commandes[i].Reglement;
                GridBurger.DataContext = FastFood.Instance.Commandes[i].Burger;
                GridBoisson.DataContext = FastFood.Instance.Commandes[i].Boisson;
                GridFrites.DataContext = FastFood.Instance.Commandes[i].Accompagnement;
                GridMenu.DataContext = FastFood.Instance.Commandes[i].Menu;

                
            }
        }

    }
}
