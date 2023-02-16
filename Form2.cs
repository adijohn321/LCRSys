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
    public partial class Form2 : Form
    {

        string name, level;
        public Form2(string name, string level)
        {
            InitializeComponent();
            this.name = name;
            this.level = level;
            lbllevel.Text = SetUserLevel(level);
            lblname.Text = name;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnsetdatetime_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process time = System.Diagnostics.Process.Start("timedate.cpl");
           
        }

        private void setDateTime_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.lbltime.Text = dateTime.ToString("hh:mm tt");
        }

        private void btnproceed_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(name, level);
            this.Hide();
            dashboard.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            timer1.Start();
            lbltime.Text = DateTime.Now.ToString("hh:mm tt");
            lbldate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            this.lbltime.Text = dt.ToString("hh:mm tt");
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
    }
}
