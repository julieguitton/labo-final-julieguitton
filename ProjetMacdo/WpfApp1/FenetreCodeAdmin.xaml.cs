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
using ProjetMacdo;

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour FenetreCodeAdmin.xaml
    /// </summary>
    public partial class FenetreCodeAdmin : Window
    {
        public bool codeOK = false;
        public FenetreCodeAdmin()
        {
            InitializeComponent();
        }

        private void ValiderBouton_Click(object sender, RoutedEventArgs e)
        {
            char[] passwordChars = MdpBox.Password.ToCharArray();

            string password = new string(passwordChars);

            if (FastFood.Instance.VerifCode(password))
            {
                codeOK = true;
                Close();
            }
            else
            {
                MessageBox.Show("Code Incorrect");
            }
        }

        private void AnnulerBouton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
