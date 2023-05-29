using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using atelier.model;

namespace atelier.dal
{
    public class PersonnelAccess
    {

        private readonly Access access = null;

        public PersonnelAccess()
        {
            access = Access.GetInstance();
        }


        public List<Personnel> GetLesPersonnels()
        {
            List<Personnel> lesPersonnels = new List<Personnel>();
            
            if (access.Manager != null)
            {                                        //int idpersonnel, int service, string nom, string prenom, string tel, string mai
                            string req = "select p.idpersonnel as personnel, p.idservice as service, p.nom as nom, p.prenom as prenom, p.tel as tel, p.mail as mail from personnel as p  ";
                            
                // req += "from developpeur d join profil p on (d.idprofil = p.idprofil) ";
                //req += "order by nom, prenom;";
                
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req);
                    if (records != null)
                    {
                        foreach (Object[] record in records)
                        {
                            System.Diagnostics.Debug.WriteLine("monmessage");
                           
                            Personnel personnel = new Personnel( (int)record[0], (int)record[1] ,(string)record[2], (string)record[3],
                            (string)record[4], (string)record[5]);

                            

                            lesPersonnels.Add(personnel);

                            
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
                
            }
            Console.WriteLine("juste avant le return");
            return lesPersonnels;
          
        }

    }
}
