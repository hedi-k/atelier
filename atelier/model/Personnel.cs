using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atelier.model
{
    public class Personnel
    {
        
        public Personnel (int idpersonnel, int service, string nom, string prenom, string tel, string mail)
        {
            this.Idpersonnel = idpersonnel;
            this.Service = service;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Tel = tel;
            this.Mail = mail;
        }

        
        public int Idpersonnel { get; }
        
        public int Service { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        
    }
    
}
