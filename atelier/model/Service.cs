using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atelier.model
{
    // Classe métier
    public class Service
    {
        public int Idservice { get; }
        public string Nom { get; }

        // Valorise les propriétés
        public Service(int idservice, string nom)
        {
            this.Idservice = idservice;
            this.Nom = nom;
        }

        // Définit l'information à afficher (juste le nom)
        public override string ToString()
        {
            return this.Nom;
        }
    }
}
