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

        private static readonly string connectionString ="server=localhost;user id=avasarala;password=-E2(Zly8TrtK8lfy;database=atelier;SslMode=none";

        private static Access instance = null;
     
        public BddManager Manager { get; }

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
