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
        //Objet pour gérer les peronnel de la combo
        private BindingSource bdgPersonnelsABS = new BindingSource();
        //Controleur de la fenêtre
        private FrmAtelierController controller;
        //Objet pour remplir la liste des absences
        private Personnel personnelSel;
        // Booléen pour savoir si une modification est demandée
        private Boolean enCoursDeModifABS = false;

        // construction des composants graphiques et appel des autres initialisations
        public FrmAtelier2(Personnel personnelSel)
        {
            this.personnelSel = personnelSel;
            InitializeComponent();
            Init2();
            RemplirListeAbsence(personnelSel);
        }

        //Initialisation
        private void Init2()
        {
            controller = new FrmAtelierController(); ///////////// GROS DOUTE pour cette commande
            RemplirListeMotif();
            RemplirCboList();
            EnCoursDeModifABS(false);
        }

        //Affiche la data grid view avec les absences
        private void RemplirListeAbsence(Personnel personnelSel)
        {
            List<Absence> lesAbsences = controller.GetLesAbsences(personnelSel);
            bdgAbsences.DataSource = lesAbsences;
            dgvAbsence.DataSource = bdgAbsences;
            dgvAbsence.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        //rempli la combo
        private void RemplirCboList()
        {
            List<Motif> motifABS = controller.GetLesMotifs();
            bdgPersonnelsABS.DataSource = motifABS;
            //cboPersonnelsABS.DataSource = bdgPersonnelsABS;
            //cboPersonnelsABS.DisplayMember = "Nom";

        }
        //Affiche les motifs
        private void RemplirListeMotif()
        {
            List<Motif> lesMotifs = controller.GetLesMotifs();
            bdgMotif.DataSource = lesMotifs;
            cboMotif.DataSource = bdgMotif;
        }

        private void EnCoursDeModifABS(Boolean modif)
        {
            enCoursDeModifABS = modif;
        }

        //action du bouton Personnel
        private void btnPersonnel_Click(object sender, EventArgs e)
        {
            FrmAtelier frmAtelier = new FrmAtelier();
            frmAtelier.Show();
            this.Hide();
        }
        //action du bouton supprimer
        private void btnSupprimer2_Click(object sender, EventArgs e)
        {
            if (dgvAbsence.SelectedRows.Count > 0)
            {
                Personnel personnelSel = this.personnelSel;
                Absence absence = (Absence)bdgAbsences.List[bdgAbsences.Position];
                if (MessageBox.Show("Voulez-vous vraiment supprimer l'absence de " + absence.Nom + " " + absence.Prenom + "?", "Confirmation de suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    controller.DelAbsence(absence);
                    RemplirListeAbsence(personnelSel);
                }
            }
            else
            {
                MessageBox.Show("Une ligne doit être sélectionnée.", "Information");
            }
        }

        //action du bouton ajouter
        private void btnAjouter_Click(object sender, EventArgs e)
        {
           
            if (dtpDebut.Value < dtpFin.Value)
            {
                Motif motif = (Motif)bdgMotif.List[bdgMotif.Position];
                Personnel personnelSel = this.personnelSel;
                if (enCoursDeModifABS)
                {
                    Absence absence = (Absence)bdgAbsences.List[bdgAbsences.Position];
                    absence.Datedebut = dtpDebut.Value;
                    absence.Datedebut = dtpFin.Value;
                    absence.Motif = motif;
                    controller.UpdateAbsence(absence);
                }
                else
                {
                   
                    Absence absence = new Absence(personnelSel.Idpersonnel, personnelSel.Nom, personnelSel.Prenom, dtpDebut.Value, dtpFin.Value, motif);
                    controller.AddAbsence(absence);
                }
                RemplirListeAbsence(personnelSel);
                EnCoursDeModifABS(false);

            }
            else
            {
                MessageBox.Show("La date de début doit être avant la date de fin.", "Information");
            }
        }

        //action du bouton modifier
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvAbsence.SelectedRows.Count > 0)
            {
                EnCoursDeModifABS(true);
                Absence absence = (Absence)bdgAbsences.List[bdgAbsences.Position];
                dtpDebut.Value = absence.Datedebut;
                dtpFin.Value = absence.Datefin;
                cboMotif.SelectedIndex = cboMotif.FindStringExact(absence.Motif.Libelle);
            }
            else
            {
                MessageBox.Show("Une ligne doit être sélectionnée.", "Information");
            }
        }
    }
}
