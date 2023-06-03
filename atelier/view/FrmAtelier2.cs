﻿using System;
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
        private FrmAterlierController controller;
        //Objet pour remplir la liste des absences
        private Personnel personnelSel;

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
            controller = new FrmAterlierController(); ///////////// GROS DOUTE pour cette commande
            RemplirListeMotif();
            RemplirCboList();
        }

        //Affiche la data grid view avec les absences
        private void RemplirListeAbsence(Personnel personnelSel)
        {
            List<Absence> lesAbsences = controller.GetLesAbsences(personnelSel);
            bdgAbsences.DataSource = lesAbsences;
            dgvAbsence.DataSource = bdgAbsences;
            dgvAbsence.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        //rempli le combo
        private void RemplirCboList()
        {
            List<Personnel> lesPersonnels = controller.GetLesPersonnels();
            bdgPersonnelsABS.DataSource = lesPersonnels;
            cboPersonnelsABS.DataSource = bdgPersonnelsABS;
            cboPersonnelsABS.DisplayMember = "Nom";

        }
        //Affiche les motifs
        private void RemplirListeMotif()
        {
            List<Motif> lesMotifs = controller.GetLesMotifs();
            bdgMotif.DataSource = lesMotifs;
            cboPersonnelsABS.DataSource = bdgMotif;
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

    }
}
