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
        //Objet pour gérer la liste des motif
        private BindingSource bdgMotif = new BindingSource();
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
            RemplirListeMotif();
        }

        //Affiche les absences
        private void RemplirListeAbsence()
        {
            List<Absence> lesAbsences = controller.GetLesAbsences();
            bdgAbsences.DataSource = lesAbsences;
            dgvAbsence.DataSource = bdgAbsences;
            dgvAbsence.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        //Affiche les motifs
        private void RemplirListeMotif()
        {
            List<Motif> lesMotifs = controller.GetLesMotifs();
            bdgMotif.DataSource = lesMotifs;
            cboMotif.DataSource = bdgMotif;
        }

        //action du bouton Absence
        private void btnAbscence_Click(object sender, EventArgs e)
        {
            FrmAtelier frmAtelier = new FrmAtelier();
            frmAtelier.Show();
            this.Hide();
        }

        //action du bouton supprimer
        private void btnSupprimer2_Click(object sender, EventArgs e)
        {
            if(dgvAbsence.SelectedRows.Count > 0)
            {
                Absence absence = (Absence)bdgAbsences.List[bdgAbsences.Position];
                if(MessageBox.Show("Voulez-vous vraiment supprimer l'absence de " + absence.Nom+" "+absence.Prenom + "?" , "Confirmation de suppression", MessageBoxButtons.YesNo)== DialogResult.Yes)
                {
                    controller.DelAbsence(absence);
                    RemplirListeAbsence();
                }
            }
            else
            {
                MessageBox.Show("Une ligne doit être sélectionnée.", "Information");
            }

        }
    }
}
