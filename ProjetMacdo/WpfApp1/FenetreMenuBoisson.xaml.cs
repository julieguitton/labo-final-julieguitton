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
    /// Logique d'interaction pour FenetreMenuBoisson.xaml
    /// </summary>
    public partial class FenetreMenuBoisson : Window
    {
        public Boisson boissonchoisie;
        public ObservableCollection<Boisson> listboisson = new ObservableCollection<Boisson>(Boisson.LoadBoissonsFromCSV("C:/Users/Julie/source/repos/labo-1-5-julieguitton/ProjetMacdo/WpfApp1/fichiers/boissons.csv"));
        public FenetreMenuBoisson()
        {
            
            InitializeComponent();
            BoissonsMenuLV.DataContext = listboisson;
        }

        private void BoissonsMenuLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = BoissonsMenuLV.SelectedIndex;
            if (i >= 0)
            {
                boissonchoisie = new Boisson(listboisson[i]);
                DialogResult = true;
                Close();
            }
        }
        private void FenetreMenuBoisson_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
