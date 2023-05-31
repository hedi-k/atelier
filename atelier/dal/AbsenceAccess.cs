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
                /*
                string req = "select absence.idpersonnel as idABS, personnel.idpersonnel as idpersonnel, personnel.nom as nom, personnel.prenom as prenom, personnel.tel as tel, personnel.mail as mail," +
                    "service.idservice as idservice, service.nom as Service, absence.datedebut, absence.datefin, motif.idmotif, motif.libelle " +
                    "from absence, personnel, motif, service; ";
                */
                string req ="select absence.idpersonnel, personnel.nom, personnel.prenom, absence.datedebut, absence.datefin, motif.idmotif as idmotif, motif.libelle as libelle " +
                    "from personnel, motif, absence where absence.idpersonnel = personnel.idpersonnel;";
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req);
                    if (records != null)
                    {
                        foreach (Object[] record in records)
                        {
                            /*
                            //                                        idservice        Service
                            Service service = new Service((int)record[6], (string)record[7]);
                            //                                             idperso         nom                 prenom             tel                mail
                            Personnel personnel = new Personnel((int)record[1], (string)record[2], (string)record[3], (string)record[4], (string)record[5], service);
                            //                                 idMotif          libelle
                            Motif motif = new Motif((int)record[10], (string)record[11]);
                            //                                       idperso                   datedebut              datefin
                            Absence absence = new Absence((int)record[0],personnel, (DateTime)record[8], (DateTime)record[9], motif);
                            */

                            //                                 idMotif          libelle
                            Motif motif = new Motif((int)record[5], (string)record[6]);
                            //                                   idperso               nom                prenom      datedebut    datefin
                            Absence absence = new Absence((int)record[0],(string)record[1],(string)record[2],(DateTime)record[3], (DateTime)record[4], motif);

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

        //supprime un absent
        public void DelAbsence(Absence absence)
        {
            if (access.Manager != null)
            {
                string req = "delete from absence where datedebut = @datedebut;";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@datedebut", absence.Datedebut);
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
        }
    }
}
