using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Petkunas__Lukas___Doherty_Cars
{
    public partial class frmHelpRoles : Form
    {
        public frmHelpRoles()
        {
            InitializeComponent();
        }

        private void frmHelpRoles_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
