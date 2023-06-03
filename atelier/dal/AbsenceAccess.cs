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

        public List<Absence> GetLesAbsences(Personnel personnelSel)
        {
            List<Absence> lesAbsences = new List<Absence>();
            if (access.Manager != null)
            { 
                string req = "select absence.idpersonnel, personnel.nom, personnel.prenom, absence.datedebut, absence.datefin, motif.idmotif, motif.libelle from personnel join absence on (personnel.idpersonnel = absence.idpersonnel) join motif on (absence.idmotif = motif.idmotif) where absence.idpersonnel = @idpersonnel ;";
                try
                {

                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    parameters.Add("@idPersonnel", personnelSel.Idpersonnel);
                    List<Object[]> records = access.Manager.ReqSelect(req, parameters);
                    if (records != null)
                    {
                        foreach (Object[] record in records)
                        {
                            //                                 idMotif          libelle
                            Motif motif = new Motif((int)record[5], (string)record[6]);
                            //                                   idperso               nom                prenom      datedebut    datefin
                            Absence absence = new Absence((int)record[0], (string)record[1], (string)record[2], (DateTime)record[3], (DateTime)record[4], motif);
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
