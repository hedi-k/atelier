using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atelier.model;

namespace atelier.dal
{
    //classse qui gère les demande de access
    public class MotifAccess
    {
        //instance unique de l'accès aux données
        private readonly Access access = null;
        // Constructeur pour créer l'accès aux données
        public MotifAccess()
        {
            access = Access.GetInstance();
        }

        //Récupère et retourne les motifs
        public List<Motif> GetLesMotifs()
        {
            List<Motif> lesMotifs = new List<Motif>();
            if (access.Manager != null)
            {
                string req = "select * from motif order by libelle;";
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req);
                    if (records != null)
                    {
                        foreach (Object[] record in records)
                        {
                            Motif motif = new Motif((int)record[0], (string)record[1]);
                            lesMotifs.Add(motif);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return lesMotifs;
        }
    }
}
