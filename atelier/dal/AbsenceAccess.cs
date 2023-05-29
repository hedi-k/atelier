using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atelier.model;

namespace atelier.dal
{
    //classe qui gère les demandes de absence
    public class AbsenceAccess
    {
        // Instance unique de l'accès aux données
        private readonly Access access = null;

        //constructeur pour créer l'accès aux données
        public AbsenceAccess()
        {
            access = Access.GetInstance();
        }

        // Récupère et retourne les absences
        public List<Absence> GetLesAbsences()
        {
            List<Absence> lesAbsences = new List<Absence>();

            if (access.Manager != null)
            {
                string req = "select absence.idpersonnel as idpersonnel, absence.datedebut as datedebut, absence.idmotif as idmotif, absence.datefin as datefin from absence ;";

                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req);
                    if (records != null)
                    {
                        foreach (Object[] record in records)
                        {
                            //La boucle a coder*************************************
                            //Service service = new Service((int)record[5], (string)record[6]); a faire pareil avec motif
                            Absence absence = new Absence((int)record[0], (DateTime)record[1], (int)record[2],
                            (DateTime)record[3]);
                            lesAbsences.Add(absence);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }

            }

            return lesAbsences;
        }
    }
}
