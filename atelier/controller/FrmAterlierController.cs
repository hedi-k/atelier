using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atelier.model;
using atelier.dal;
using System.Windows.Forms;

namespace atelier.controller
{
    public class FrmAterlierController
    {
        //objet d'accès aux opérations possibles sur Developpeur
        private readonly PersonnelAccess personnelAccess;
        //objet d'accès aux opérations possible sur service
        private readonly ServiceAccess serviceAccess;

        //Récupère les acces aux données
        public FrmAterlierController()
        {
            personnelAccess = new PersonnelAccess();
            serviceAccess = new ServiceAccess();
        }

        //Récupère et retourne les infos des personnels
        public List<Personnel> GetLesPersonnels()
        {
           
            return personnelAccess.GetLesPersonnels();
        }

        //Demande la modif d'un personnel
        public void UpdatePersonnel(Personnel personnel)
        {
            personnelAccess.UpdatePersonnel(personnel);
        }

        //Récupère et retourne les infos des services
        public List<Service> GetLesServices()
        {
            return serviceAccess.GetLesServices();
        }

        public void AddPersonnel(Personnel personnel)
        {
            personnelAccess.AddPersonnel(personnel);
        }
    }
}
