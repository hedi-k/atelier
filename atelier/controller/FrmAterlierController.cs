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
        private readonly PersonnelAccess personnelAccess;

        public FrmAterlierController()
        {
            personnelAccess = new PersonnelAccess();
        }

        public List<Personnel> GetLesPersonnels()
        {
           
            return personnelAccess.GetLesPersonnels();
        }
    }
}
