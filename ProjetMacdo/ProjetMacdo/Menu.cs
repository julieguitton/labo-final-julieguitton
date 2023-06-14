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

        public Menu()
        {
            boisson=new Boisson();
            burger=new Burger();
            frites=new Accompagnement();
        }
        public Boisson Boisson{ get { return boisson; }set { boisson = value; } }
        public Burger Burger { get { return burger; } set { burger = value; } }
        public Accompagnement Accompagnement { get { return frites; } set { frites = value; } }
    }
}
