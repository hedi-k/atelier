using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using atelier.bddmanager;

namespace atelier.dal
{
    public class Access
    {
        //chaine de connexion à la bdd
        private static readonly string connectionString ="server=localhost;user id=avasarala;password=-E2(Zly8TrtK8lfy;database=atelier;SslMode=none";
        //instance unique de la classe
        private static Access instance = null;
        //Getter sur l'objet d'accès aux données
        public BddManager Manager { get; }
        // Création unique de l'objet de type BddManager
        // Arrête le programme si l'accès à la BDD a échoué
        private Access()
        {
            try
            {
                Manager = BddManager.GetInstance(connectionString);
            }
            catch (Exception)
            {
                Environment.Exit(0);
            }
        }
        //Création d'une seule instance de la classe
        public static Access GetInstance()
        {
            if (instance == null)
            {
                instance = new Access();
            }
            return instance;
        }
    }
}
