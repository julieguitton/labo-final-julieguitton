using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetMacdo
{
    [Serializable]
    public class Accompagnement : Produit
    {
        [XmlElement("Taille")]
        private int taille; //petit, moyen, grand

        public Accompagnement() : base() { }
        public Accompagnement(string n, float p, int q, string i,int t) :base(n,p,q,i)
        {
            taille = 1;
        }
        public int Taille
        { 
            get { return taille; } 
            set 
            {  
                taille = value;
                if (value == 1 && !Nom.Contains("P "))
                {
                    Prix = 3.00f;

                    Nom = "P " + Nom;
                }
                else if (value == 2 && !Nom.Contains("M "))
                {
                    Prix = 3.50f;
                    Nom = "M " + Nom;
                }
                else if (value == 3 && !Nom.Contains("G "))
                {
                    Prix = 4.00f;
                    Nom = "G " + Nom;
                }
            } 
        }
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            Accompagnement other = (Accompagnement)obj;

            // Comparez les propriétés de l'objet courant (this) avec les propriétés de l'autre objet (other)
            // Excluez les propriétés Prix et Quantite de la comparaison

            return base.Equals(obj) 
                    && Taille == other.Taille;
        }
    }


}
