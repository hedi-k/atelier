using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atelier.model
{
    //calsse métier
    public class Motif
    {
        //valorise les propriétés
        public Motif (int idmotif, string libelle)
        {
            this.Idmotif = idmotif;
            this.Libelle = libelle;
        }
        public int Idmotif { get; }
        public string Libelle { get; }

        //Définit l'information à afficher (juste le libelle)
        public override string ToString()
        {
            return this.Libelle;
        }
    }
}
