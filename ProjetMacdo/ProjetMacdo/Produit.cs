using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace ProjetMacdo
{
    [Serializable]
    public class Produit : INotifyPropertyChanged
    {
        [XmlElement("Nom")]
        private string nom;
        [XmlElement("Prix")]
        private float prix;
        [XmlElement("Quantite")]
        private int quantite;
        [XmlElement("Image")]
        private string image;

        public event PropertyChangedEventHandler PropertyChanged;

        public Produit()
        {
            Nom = "produit";
            Prix = 0;
            Quantite = 0;
            Image = string.Empty;
        }
        public Produit(string n, float p, int q, string i)
        {
            Nom = n;
            Prix = p;
            Quantite = q;
            Image = i;   
        }
        public Produit(Produit other)
        {
            Nom = other.Nom;
            Prix = other.Prix;
            Quantite = other.Quantite;
            Image = other.Image;
        }
        public float PrixTotal
        {
            get { return prix * quantite; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value;
                  if(PropertyChanged!=null)
                  {
                    PropertyChanged(this,new PropertyChangedEventArgs("Nom"));
                  }
                }
        }
        public float Prix
        {
            get { return prix; }
            set { prix = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Prix"));
                }
            }
        }
        public int Quantite
        {
            get { return quantite; }
            set { quantite = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Quantite"));
                    PropertyChanged(this, new PropertyChangedEventArgs("PrixTotal"));
                }
            }
        }
        public string Image
        {
            get { return image; }
            set { image = value; }
        }
    }
}
