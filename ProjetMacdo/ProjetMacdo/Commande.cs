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
            set { prixTotal = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("PrixTotal"));
        }
            }
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
                    PropertyChanged(this, new PropertyChangedEventArgs("Lieu"));
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

        public void AjouterBurger(Burger b)
        {
            int trouve = 0;
            foreach (Burger burger in burgers)
            {
                if(burger.Equals(b))
                { 
                    trouve = 1;
                    burger.Quantite += 1;
                     break;
                }

            }
            if (trouve != 1)
            {
                burgers.Add(b);

            }
            prixTotal = CalculerPrixTotal();

        }
        public void AjouterBoisson(Boisson b)
        {
            int trouve = 0;
            foreach (Boisson boisson in boissons)
            {
                if (boisson.Equals(b))
                {
                    trouve = 1;
                    boisson.Quantite += 1;
                    break;
                }
            }
            if (trouve != 1)
            {
                boissons.Add(b);
            }
            prixTotal = CalculerPrixTotal();
        }
        public void AjouterFrites(Accompagnement f)
        {
            int trouve = 0;
            foreach (Accompagnement frite in accompagnements)
            {
                if (frite.Equals(f))
        {         
                    trouve = 1;
                    frite.Quantite += 1;
                    break;
                }
        }
            if (trouve != 1)
        {
                accompagnements.Add(f);
            }
            prixTotal = CalculerPrixTotal();
        }
        public void AjouterMenu(Menu m)
        {
            int trouve = 0;
            foreach (Menu menu in menus)
            {
                if (menu.Equals(m))
        {
                    trouve = 1;
                    menu.Quantite += 1;
                    break;
                }
        }
            if (trouve != 1)
        {
                menus.Add(m);
            }
            prixTotal = CalculerPrixTotal();
        }

        public void RetirerBurger(Burger burger)
        {
            burgers.Remove(burger);
            prixTotal = CalculerPrixTotal();
        }
        public void RetirerBoisson(Boisson boisson)
        {
            boissons.Remove(boisson);
            prixTotal = CalculerPrixTotal();
        }
        public void RetirerFrites(Accompagnement frite)
        {
            accompagnements.Remove(frite);
            prixTotal = CalculerPrixTotal();
        }
        public void RetirerMenu(Menu menu)
        {
            menus.Remove(menu);
            prixTotal = CalculerPrixTotal();
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
