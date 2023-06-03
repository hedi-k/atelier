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
        //*********************************Gestion du personnels**********************************************//
        //objet d'accès aux opérations possibles sur Developpeur
        private readonly PersonnelAccess personnelAccess;
        //objet d'accès aux opérations possible sur service
        private readonly ServiceAccess serviceAccess;

        //Récupère les acces aux données
        public FrmAterlierController()
        {
            personnelAccess = new PersonnelAccess();
            serviceAccess = new ServiceAccess();
            absenceAccess = new AbsenceAccess();
            motifAccess = new MotifAccess();
        }

        //Récupère et retourne les infos des personnels
        public List<Personnel> GetLesPersonnels()
        {
           
            return personnelAccess.GetLesPersonnels();
        }

        //Récupère et retourne les infos des services
        public List<Service> GetLesServices()
        {
            return serviceAccess.GetLesServices();
        }

        //Demande la modif d'un personnel
        public void UpdatePersonnel(Personnel personnel)
        {
            personnelAccess.UpdatePersonnel(personnel);
        }

        //Demande l'ajout d'un personnel
        public void AddPersonnel(Personnel personnel)
        {
            personnelAccess.AddPersonnel(personnel);
        }
        //Demande la suppression d'un personnel
        public void DelPersonnel(Personnel personnel)
        {
            personnelAccess.DelPersonnel(personnel);
        }

        //*********************************Gestion des absences**********************************************//
        //objet d'accès aux opérations possible sur absence
        private readonly AbsenceAccess absenceAccess;
        //objet d'accès aux opérations possible sur motif
        private readonly MotifAccess motifAccess;

        //Récupère et retourne les infos des absences
        public List<Absence> GetLesAbsences(Personnel personnelSel)
        {
            return absenceAccess.GetLesAbsences(personnelSel);
        }

        //Récupère et retourne les infos des motifs
        public List<Motif> GetLesMotifs()
        {
            return motifAccess.GetLesMotifs();
        }

        //Demande la suppression d'un absent
        public void DelAbsence(Absence absence)
        {
            absenceAccess.DelAbsence(absence);
        }

        //Demande la modif d'une absence
        public void UpdateAbsence(Absence absence)
        {
            absenceAccess.UpdateAbsence(absence);
        }

        //Demande l'ajout d'une absence
        public void AddAbsence(Absence absence)
        {
            absenceAccess.AddAbsence(absence);
        }
    }
}
