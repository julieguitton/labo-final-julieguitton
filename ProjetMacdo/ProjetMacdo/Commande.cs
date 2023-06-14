using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetMacdo
{
    [Serializable]
    public class Commande : INotifyPropertyChanged
    {
        public static int numCommande = 1;
        [XmlElement("Numero")]
        private int numero;
        [XmlElement("Date")]
        private DateTime date;
        [XmlElement("Lieu")]
        private string lieu;//sur place/emporter
        [XmlArray("Menus")]
        [XmlArrayItem("Menu")]
        private List<Menu> menus;
        [XmlArray("Burgers")]
        [XmlArrayItem("Burger")]
        private List<Burger> burgers;
        [XmlArray("Boissons")]
        [XmlArrayItem("Boisson")]
        private List<Boisson> boissons;
        [XmlArray("Accompagnements")]
        [XmlArrayItem("Accompagnement")]
        private List<Accompagnement> accompagnements;
        [XmlElement("Reglement")]
        private string reglement;//CB,Especes...
        [XmlElement("PrixTotal")]
        private float prixTotal;

        public event PropertyChangedEventHandler PropertyChanged;

        public Commande()
        {
            reglement = "CB";
            prixTotal = 0;
            menus = new List<Menu>();
            burgers = new List<Burger>();
            boissons = new List<Boisson>();
            accompagnements = new List<Accompagnement>();
        }
        public Commande(int n, DateTime d, string l, string r, float pt)
        {
            numero = n;
            Date = d;
            Lieu = l;
            Reglement = r;
            PrixTotal = pt;
        }
        

  
        public float PrixTotal
        {
            get { return prixTotal; }
            set { prixTotal = value; }
        }
        public string Reglement
        {
            get { return reglement; }
            set { reglement = value; }
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
            get { return  burgers; }
            set {  burgers = value; }
        }
        public List<Menu> Menu
        {
            get { return menus; }
            set { menus = value; }
        }
        public string Lieu
        {
            get { return lieu; }
            set { lieu = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Nom"));
                }
            }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public void AjouterBurger(Burger burger)
        {         
            burgers.Add(burger);
        }
        public void AjouterBoisson(Boisson boisson)
        {
            boissons.Add(boisson);
        }
        public void AjouterFrites(Accompagnement frite)
        {
            accompagnements.Add(frite);
        }
        public void AjouterMenu(Menu menu)
        {
            menus.Add(menu);
        }

        public void RetirerBurger(Burger burger)
        {
            burgers.Remove(burger);
        }
        public void RetirerBoisson(Boisson boisson)
        {
            boissons.Remove(boisson);
        }
        public void RetirerFrites(Accompagnement frite)
        {
            accompagnements.Remove(frite);
        }
        public void RetirerMenu(Menu menu)
        {
            menus.Remove(menu);
        }
        public float CalculerPrixTotal()
        {
            float prixTotal = 0;

            foreach (Burger burger in burgers)
            {
                prixTotal += burger.PrixTotal;
            }

            foreach (Boisson boisson in boissons)
            {
                prixTotal += boisson.PrixTotal;
            }

            foreach (Menu menu in menus)
            {
                prixTotal += menu.PrixTotal;
            }

            foreach (Accompagnement accompagnement in accompagnements)
            {
                prixTotal += accompagnement.PrixTotal;
            }

            return prixTotal;
        }
    }
}
