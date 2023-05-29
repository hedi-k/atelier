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

namespace atelier.view
{
    public partial class FrmAtelier2 : Form
    {
        public FrmAtelier2()
        {
            InitializeComponent();
        }

        private void FrmAtelier2_Load(object sender, EventArgs e)
        {

        }

        private void btnAbscence_Click(object sender, EventArgs e)
        {
            FrmAtelier frmAtelier = new FrmAtelier();
            frmAtelier.Show();
            this.Hide();
        }
    }
}
