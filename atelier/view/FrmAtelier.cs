using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using atelier.model;
using atelier.controller;

namespace atelier
{
    public partial class FrmGestion : Form
    {
        private BindingSource bdgPersonnels = new BindingSource();
        private FrmAterlierController controller;
        public FrmGestion()
        {
            InitializeComponent();
            Init();
            
        }

        private void Init()
        {
            controller = new FrmAterlierController();
            RemplirListePersonnels();
        }

        private void RemplirListePersonnels()
        {
            List<Personnel> lesPersonnels = controller.GetLesPersonnels();
            bdgPersonnels.DataSource = lesPersonnels;
            dgvPersonnel.DataSource = lesPersonnels;
            dgvPersonnel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void dgvPersonnel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
