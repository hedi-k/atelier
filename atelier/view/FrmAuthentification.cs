using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using atelier.controller;
using atelier.model;

namespace atelier.view
{
    // Fenêtre d'authentification
    public partial class FrmAuthentification : Form
    {
        //Controleur de la fenêtre
        private FrmAterlierController controller;
        // Conrtuction des composants graphiques
        public FrmAuthentification()
        {
            InitializeComponent();
            Init();
        }

        // Création du controleur
        private void Init()
        {
            
            controller = new FrmAterlierController(); ///////////// GROS DOUTE pour cette commande
        }

        //action du bouton connecter
        private void btnConnect_Click(object sender, EventArgs e)
        {
            String login = txtLogin.Text;
            String pwd = txtPwd.Text;
            if (String.IsNullOrEmpty(login) || String.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("Tous les champs doivent être remplis.", "Information");
            }
            else
            {
                Responsable responsable = new Responsable(login, pwd);
                if (controller.ControleAuthentification(responsable))
                {
                    this.Hide();
                    FrmAtelier frm = new FrmAtelier();
                    frm.ShowDialog();
                    
                }
                else
                {
                    MessageBox.Show("Authentification incorrecte ou vous n'êtes pas admin", "Alerte");
                }
            }
        }
    }
}
