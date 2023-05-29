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
        public Absence (int idpersonnel, DateTime datedebut ,int idmotif, DateTime datefin)
        {
            this.Idpersonnel = idpersonnel;
            this.Datedebut = datedebut;
            this.Idmotif = idmotif;
            this.Datefin = datefin;
        }

        public int Idpersonnel { get; }
        public DateTime Datedebut { get; set; }
        public int Idmotif { get; set; } // ************* ici il va faloir changer comme profil
        public DateTime Datefin { get; set; }
       

    }
}
