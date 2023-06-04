using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atelier.model;
using atelier.dal;

namespace atelier.dal
{
    public class ResponsableAccess
    {
        //Instance unique d'accès aux données
        private readonly Access access = null;

        //constructeur pour crée l'accès au données
        public ResponsableAccess()
        {
            access = Access.GetInstance();
        }

        //Controle le doit de se connecter
        public Boolean ControleAuthentification(Responsable responsable)
        {
            if (access.Manager != null)
            {
                string req = "select * from responsable ";
                req += "where login=@login and pwd=SHA2(@pwd, 256);";
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@login", responsable.Login);
                parameters.Add("@pwd", responsable.Pwd);
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req, parameters);
                    if (records != null)
                    {
                        return (records.Count > 0);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return false;
        }
    }
}
