using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using System.Threading.Tasks;
using System.ComponentModel;

namespace ProjetMacdo
{
    [Serializable]
    public class Burger : Produit 
    {
       
        public Burger() : base()
        {
           
        }

    public Burger(string n, float p, int q, string i) : base(n, p, q, i)
        {
        }
        public Burger(Burger autre) : base(autre)
        {

        }

        public static List<Burger> LoadBurgersFromCSV(string filePath)
        {
            List<Burger> listburger = new List<Burger>();

            string[] lines = File.ReadAllLines(filePath);

            // Ignorer la première ligne qui contient les en-têtes
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] fields = line.Split(';');

                if (fields.Length >= 4)
                {
                    Burger burger = new Burger
                    {
                        Nom = fields[0],
                        Prix = float.Parse(fields[1]),
                        Quantite = int.Parse(fields[2]),
                        Image = fields[3]
                    };

                    listburger.Add(burger);
                }
            }

            return listburger;
        }

}
}
