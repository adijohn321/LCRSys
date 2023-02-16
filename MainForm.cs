using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LCRSys
{
    public partial class MainForm : Form
    {
        public MainForm(string name, string level)
        {
            InitializeComponent();
            lblname.Text = name;
            lbllevel.Text = SetUserLevel(level);
        }
        public string SetUserLevel(string input)
        {
            switch (input)
            {
                case "1":
                    return "Administrator";
                case "0":
                    return "Clerk 1";
                default:
                    return "Invalid";
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {

            timer1.Start();
            lbldate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            lbltime.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            this.lbltime.Text = dt.ToString("hh:mm tt");
        }
        Form102 form102 = new Form102();
        Form103 form103 = new Form103();
        Form97 Form97 = new Form97();
        private void birthCertificateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                form102.MdiParent = MainForm.ActiveForm;
                if (this.ActiveMdiChild != null)
                    this.ActiveMdiChild.Hide();
                form102.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void marriageCertificateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form97.MdiParent = MainForm.ActiveForm;
                if (this.ActiveMdiChild != null)
                    this.ActiveMdiChild.Hide();
                Form97.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void deathCertificateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                form103.MdiParent = MainForm.ActiveForm;
                if (this.ActiveMdiChild != null)
                    this.ActiveMdiChild.Hide();
                form103.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
