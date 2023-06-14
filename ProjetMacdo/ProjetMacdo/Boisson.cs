using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjetMacdo
{
    [Serializable]
    public class Boisson : Produit
    {
        [XmlElement("Glacons")]
        private bool glacons;
        [XmlElement("Taille")]
        private int taille;

		public Boisson():base()
		{
            glacons = true;
            taille = 2;

		}
		public Boisson(string n, float p, int q, string i,bool g, int t) : base(n,p,q,i)
		{
			glacons = g;
			taille = t;
		}
        public Boisson(Boisson autre) : base(autre)
        {
            glacons = autre.glacons;
            taille = autre.taille;

        }

        public int Taille
		{
			get { return taille;}
			set 
			{
				taille = value;
                if (value == 1 && !Nom.Contains("P "))
                {
                    Prix = 2.5f;

                    Nom = "P " + Nom;
                }
                else if (value == 2 && !Nom.Contains("M "))
                {
                    Prix = 3.50f;
                    Nom = "M " + Nom;
                }
                else if (value == 3 && !Nom.Contains("G "))
                {
                    Prix = 4.20f;
                    Nom = "G " + Nom;
                }
            }
        }
        public static List<Boisson> LoadBoissonsFromCSV(string filePath)
        {
            List<Boisson> listboisson = new List<Boisson>();

            string[] lines = File.ReadAllLines(filePath);

            // Ignorer la première ligne qui contient les en-têtes
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] fields = line.Split(';');

                if (fields.Length >= 4)
                {
                    Boisson boisson = new Boisson()
                    {
                        Nom = fields[0],
                        Prix = float.Parse(fields[1]),
                        Quantite = int.Parse(fields[2]),
                        Image = fields[3]


                    };

                    listboisson.Add(boisson);
                }
            }

            return listboisson;
        }
        public bool Glacons
		{
			//C'est quand même bizarre que la première chose que tu fais dans une boisson c'est les glaçons, mais bon je comprends c'est parce que tu bossais là et tu commençais par les mettre quand tu la préparais, mais dans du code je dois dire que ça m'aurait paru plus logique de commencer juste par le goût de ta boisson plutôt, mais voilà chacun son truc et ta logique est clairement différente. ps : ice eta original > ice tea pêche. Sinon comment tu fais si la personne commande de l'eau ? Tu lui mets des glaçons aussi ? pps : Bois pas trop de Kong c'est cancérigène. Pleure plus tu pisseras moins. Plus tu bois de la bière et plus ça te donnera envie de pisser. De la part de Marvin : Va te faire enculer salope (il voulait dire grosse mais au final il s'est dit que tu étais trop légère). Mojito = surcôté (Seb dit ça mais Marvin est pas d'accord). Contribution de Tony pour la conclusion : Non.
			get { return glacons; }
			set { 
                  glacons = value;
                  if( value==false && !Nom.Contains(" SG"))
                  {
                    Nom = Nom + " SG";
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
            Boisson other = (Boisson)obj;

            // Comparez les propriétés de l'objet courant (this) avec les propriétés de l'autre objet (other)
            // Excluez les propriétés Prix et Quantite de la comparaison

            return base.Equals(obj) &&
                   Glacons == other.Glacons && Taille == other.Taille;
        }

	}
}
