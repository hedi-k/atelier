using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using atelier.view;
using atelier.model;
using atelier.controller;

namespace atelier.view
{
    public partial class FrmAtelier2 : Form
    {
        //Objet pour gérer la liste des absences
        private BindingSource bdgAbsences = new BindingSource();
       
        //Controleur de la fenêtre*********************Si tu effaces controller = new FrmAterlierController() efface elle aussi
        private FrmAterlierController controller;

        // construction des composants graphiques et appel des autres initialisations
        public FrmAtelier2()
        {
            InitializeComponent();
            Init2();
        }

        //Initialisation
        private void Init2()
        {
            controller = new FrmAterlierController(); ///////////// GROS DOUTE pour cette commande
            RemplirListeAbsence();
        }

        //Affiche les absences
        private void RemplirListeAbsence()
        {
            List<Absence> lesAbsences = controller.GetLesAbsences();
            bdgAbsences.DataSource = lesAbsences;
            dgvAbsence.DataSource = bdgAbsences;
            dgvAbsence.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        //action du bouton Absence
        private void btnAbscence_Click(object sender, EventArgs e)
        {
            FrmAtelier frmAtelier = new FrmAtelier();
            frmAtelier.Show();
            this.Hide();
        }
    }
}
