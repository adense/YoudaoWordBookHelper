using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adense.Tool.YouDaoWordBookHelper
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void YouDaoWordStyleCreator_Click(object sender, EventArgs e)
        {
            FrmYouDaoWordStyleCreator frm = new FrmYouDaoWordStyleCreator();
            frm.WindowState = FormWindowState.Maximized;
            frm.MdiParent = this;

            frm.MaximizeBox = true;
            frm.MinimizeBox = true;

            frm.Show();
        }
    }
}
