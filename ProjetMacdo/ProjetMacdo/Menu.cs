using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetMacdo
{
    [Serializable]
    public class Menu : Produit
    {
        [XmlElement("Boisson")]
        private Boisson boisson;
        [XmlElement("Burger")]
        private Burger burger;
        [XmlElement("Accompagnement")]
        private Accompagnement frites;

        public Menu() : base()
        {
            Nom = "Menu";
            boisson=new Boisson();
            burger=new Burger();
            frites=new Accompagnement();
        }
        public Boisson Boisson{ get { return boisson; }set { boisson = value; } }
        public Burger Burger
        { get { return burger; } 
            set 
            { 
                burger = value;
                if (!Nom.Contains(burger.Nom))
                {
                    Nom = Nom + " " + (burger.Nom);
                }
                  
            } 
        }
        public Accompagnement Accompagnement { get { return frites; } set { frites = value; } }

        public float CalculPrixMenu()
        {
            if(Boisson.Taille==2 && Accompagnement.Taille==2)
                Prix = Burger.Prix + Boisson.Prix + Accompagnement.Prix - 2f;
            if (Boisson.Taille == 3 && Accompagnement.Taille == 3)
                Prix = Burger.Prix + Boisson.Prix + Accompagnement.Prix - 2.5f;
            return Prix;
        }

   
    public override bool Equals(object obj)
        {


            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            Menu other = (Menu)obj;
            return base.Equals(obj) &&
                   Boisson.Equals(other.Boisson) &&
                   Burger.Equals(other.Burger) &&
                   Accompagnement.Equals(other.Accompagnement);
        }

    }
}
