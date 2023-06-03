using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using atelier.model;

namespace atelier.dal
{
    //classe qui gère les demandes de personnel
    public class PersonnelAccess
    {
        // Instance unique de l'accès aux données
        private readonly Access access = null;
        // Constructeur pour créer l'accès aux données
        public PersonnelAccess()
        {
            access = Access.GetInstance();
        }

        // Récupère et retourne les personnels
        public List<Personnel> GetLesPersonnels()
        {
            List<Personnel> lesPersonnels = new List<Personnel>();
            
            if (access.Manager != null)
            {
                 string req = "select personnel.idpersonnel as idpersonnel, personnel.nom as nom, personnel.prenom as prenom, personnel.tel as tel, personnel.mail as mail,service.idservice as idservice, service.nom as Service from personnel  join service  on (personnel.idservice = service.idservice) order by idpersonnel;";
                
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req);
                    if (records != null)
                    {
                        foreach (Object[] record in records)
                        {
                            //System.Diagnostics.Debug.WriteLine("ça bloque ici");     ***********************************************************************
                            Service service = new Service((int)record[5], (string)record[6]);
                            Personnel personnel = new Personnel((int)record[0],(string)record[1], (string)record[2],
                            (string)record[3], (string)record[4], service) ;
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
            
            return lesPersonnels;
        }
        //Demande modification d'un personnel
        public void UpdatePersonnel(Personnel personnel)
        {
            if (access.Manager != null)
            {
                string req = "update personnel set nom = @nom, prenom = @prenom, tel = @tel, mail = @mail, idservice = @idservice ";
                req += "where idpersonnel = @idpersonnel;";//********************
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idPersonnel", personnel.Idpersonnel);//****
                parameters.Add("@nom", personnel.Nom);
                parameters.Add("@prenom", personnel.Prenom);
                parameters.Add("@tel", personnel.Tel);
                parameters.Add("@mail", personnel.Mail);
                parameters.Add("idservice", personnel.Service.Idservice);//***
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

        //ajout un personnel
        public void AddPersonnel(Personnel personnel)
        {
            if (access.Manager != null)
            {
                string req = "insert into personnel(nom, prenom, tel, mail, idservice) ";
                req += "values (@nom, @prenom, @tel, @mail, @idservice);";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@nom", personnel.Nom);
                parameters.Add("@prenom", personnel.Prenom);
                parameters.Add("@tel", personnel.Tel);
                parameters.Add("@mail", personnel.Mail);
                parameters.Add("@idservice", personnel.Service.Idservice);
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

        //supprime un personnel
        public void DelPersonnel(Personnel personnel)
        {
            if (access.Manager != null)
            {
                string req = "delete from personnel where idpersonnel = @idpersonnel;";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idpersonnel", personnel.Idpersonnel);
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
