using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atelier.model
{
    //classe métier
    public class Absence
    {
        //valorise les propriétés
        public Absence (int idpersonnel, DateTime datedebut , Motif motif, DateTime datefin)
        {
            this.Idpersonnel = idpersonnel;
            this.Datedebut = datedebut;
            this.Motif = motif;
            this.Datefin = datefin;
        }

        public int Idpersonnel { get; }
        public DateTime Datedebut { get; set; }
        public Motif Motif { get; set; }
        public DateTime Datefin { get; set; }
       

    }
}
