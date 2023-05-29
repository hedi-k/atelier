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
using atelier.view;

namespace atelier
{
    public partial class FrmAtelier : Form
    {
        //Objet pour gérer la liste des personnels
        private BindingSource bdgPersonnels = new BindingSource();
        //Objet pour gérer la liste des services
        private BindingSource bdgServices = new BindingSource();
        //Controleur de la fenêtre
        private FrmAterlierController controller;
        // Booléen pour savoir si une modification est demandée
        private Boolean enCoursDeModifPersonnel = false;

        // construction des composants graphiques et appel des autres initialisations
        public FrmAtelier()
        {
            InitializeComponent();
            Init();
        }

        //Initialisation
        private void Init()
        {
            controller = new FrmAterlierController();
            RemplirListePersonnels();
            RemplirListeService();
            EnCoursDeModifPersonnel(false);
        }

        //Affiche les personnels
        private void RemplirListePersonnels()
        {
            List<Personnel> lesPersonnels = controller.GetLesPersonnels();
            bdgPersonnels.DataSource = lesPersonnels;
            dgvPersonnel.DataSource = bdgPersonnels;
            dgvPersonnel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        //Affiche les service
        private void RemplirListeService()
        {
            List<Service> lesServices = controller.GetLesServices();
            bdgServices.DataSource = lesServices;
            cboService.DataSource = bdgServices;
        }

        //Action du bouton Ajouter
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (!txtNom.Text.Equals("") && !txtPrenom.Text.Equals("") && !txtTel.Text.Equals("") && !txtMail.Text.Equals("") && cboService.SelectedIndex != -1)
            {
                Service service = (Service)bdgServices.List[bdgServices.Position];
                if (enCoursDeModifPersonnel)
                {
                    Personnel personnel = (Personnel)bdgPersonnels.List[bdgPersonnels.Position];
                    personnel.Nom = txtNom.Text;
                    personnel.Prenom = txtPrenom.Text;
                    personnel.Tel = txtTel.Text;
                    personnel.Mail = txtMail.Text;
                    personnel.Service = service;
                    controller.UpdatePersonnel(personnel);
                }
                else
                {
                    Personnel personnel = new Personnel(0, txtNom.Text, txtPrenom.Text, txtTel.Text, txtMail.Text, service);
                    controller.AddPersonnel(personnel);
                }
                RemplirListePersonnels();
                EnCoursDeModifPersonnel(false);
            }
            else
            {
                MessageBox.Show("Tous les champs doivent être remplis.");
            }         
        }

        private void EnCoursDeModifPersonnel(Boolean modif)     
        {
            enCoursDeModifPersonnel = modif;
        }

        //action du bouton supprimer
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvPersonnel.SelectedRows.Count > 0)
            {
                Personnel personnel = (Personnel)bdgPersonnels.List[bdgPersonnels.Position];
                if (MessageBox.Show("Voulez-vous vraiment supprimer " + personnel.Nom + " " + personnel.Prenom + " ?", "Confirmation de suppression", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    controller.DelPersonnel(personnel);
                    RemplirListePersonnels();
                }
            }
            else
            {
                MessageBox.Show("Une ligne doit être sélectionnée.", "Information");
            }

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvPersonnel.SelectedRows.Count > 0)
            {
                EnCoursDeModifPersonnel(true);
                Personnel personnel = (Personnel)bdgPersonnels.List[bdgPersonnels.Position];
                txtNom.Text = personnel.Nom;
                txtPrenom.Text = personnel.Prenom;
                txtTel.Text = personnel.Tel;
                txtMail.Text = personnel.Mail;
                cboService.SelectedIndex = cboService.FindStringExact(personnel.Service.Nom);
            }
            else
            {
                MessageBox.Show("Une ligne doit être sélectionnée.", "Information");
            }
        }

        private void btnAbscence_Click(object sender, EventArgs e)
        {
            FrmAtelier2 frmAtelier2 = new FrmAtelier2();
            frmAtelier2.Show();
            this.Hide();
        }
    }
}
