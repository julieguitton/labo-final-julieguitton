using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ProjetMacdo
{
    [Serializable]
    [XmlRoot("FastFood")]
    public class FastFood
    {
        private string mdp ="1234";
        private static FastFood instance;
        private static Commande commandeEnCours;
        [XmlArray("Commandes")]
        [XmlArrayItem("Commande")]
        private List<Commande> commandes;
        private List<Menu> menus;
        private List<Burger> burgers;
        private List<Boisson> boissons;
        private List<Accompagnement> accompagnements;

        private FastFood()
        {
            Commandes = new List<Commande>();
            menus = new List<Menu>();
            burgers = new List<Burger>();
            boissons= new List<Boisson> { };
            accompagnements = new List<Accompagnement>();
            commandeEnCours = null;
        }
         public bool VerifCode(string code)
        {
            if(code == mdp ) { return true; }
            else
                return false;
        }
        public static FastFood Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FastFood();
                }
                return instance;
            }
        }

        public void ResetCommandeEnCours()
        {
            commandeEnCours = new Commande();
        }
        public static void SaveCommandes()
        {
            string filename = "C:/Users/Julie/source/repos/labo-1-5-julieguitton/ProjetMacdo/WpfApp1/fichiers/Commandes.xml";
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Commande>));

            using (Stream fStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, FastFood.Instance.Commandes);
            }
        }

        public static void LoadCommandes()
        {           
            string filePath = "C:/Users/Julie/source/repos/labo-1-5-julieguitton/ProjetMacdo/WpfApp1/fichiers/Commandes.xml";
            if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
            {

                    XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Commande>));
                    using (Stream fStream = File.OpenRead(filePath))
                    {
                        Instance.Commandes = (List<Commande>)xmlFormat.Deserialize(fStream);
                    }

                    Commande lastCommande = Instance.Commandes.Last();
                    if (lastCommande != null)
                    {
                        Commande.numCommande = lastCommande.Numero + 1;
                    }
               
            }
        }
        public void AjouterCommande(Commande commande)
        {
            Commande.numCommande++;
            Commandes.Add(commande);
        }
        public void RetirerCommande(Commande commande)
        {
            commandes.Remove(commande);
        }
        public List<Accompagnement> Accompagnement
        {
            get { return accompagnements; }
            set { accompagnements = value; }
        }
        public List<Boisson> Boisson
        {
            get { return boissons; }
            set { boissons = value; }
        }
        public List<Burger> Burger
        {
            get { return burgers; }
            set { burgers = value; }
        }
        public List<Menu> Menu
        {
            get { return menus; }
            set { menus = value; }
        }
        public List<Commande> Commandes
        {
            get { return commandes; }
            set { commandes = value; }
        }

        public static Commande CommandeEnCours
        {
            get
            {
                if (commandeEnCours == null)
                {
                    commandeEnCours = new Commande();
                }
                return commandeEnCours;
            }
           
        }
        
    }
}
