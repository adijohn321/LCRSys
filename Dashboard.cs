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
    public partial class Dashboard : Form
    {
        public Dashboard(string name, string level)
        {
            InitializeComponent();
            lblname.Text = name;
            lbllevel.Text = SetUserLevel(level);
        }

        private void dgvData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIndex = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            dgvData.DataSource = db.getForm102();
            title.Text = "Certificate of Live Birth";
            timer1.Start();
            lbldate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            lbltime.Text = DateTime.Now.ToString("hh:mm tt");
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
        Database db = new Database();
        int form = 102;
        private void btnform102_Click(object sender, EventArgs e)
        {
            form = 102;
            title.Text = "Certificate of Live Birth";
            dgvData.DataSource = db.getForm102();
        }

        private void btnform97_Click(object sender, EventArgs e)
        {
            form = 97;
            title.Text = "Certificate of Marriage";
            dgvData.DataSource = db.getForm97();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form = 103;
            title.Text = "Certificate of Death";
            dgvData.DataSource = db.getForm103();

        }

        private void Form102_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (form == 97)
            {

                dgvData.DataSource = db.getForm97(txtsearch.Text);

            }
            else if (form == 102)
            {
                dgvData.DataSource = db.getForm102(txtsearch.Text);
            }
            else if (form == 103)
            {
                dgvData.DataSource = db.getForm103(txtsearch.Text);
            }
        }


        private void btnnewentry_Click(object sender, EventArgs e)
        {
        Form97 form97 = new Form97();
        Form102 form102 = new Form102();
        Form103 form103 = new Form103();
            if (form == 97)
            {
                form97.Show();

            }
            else if (form == 102)
            {
                form102.Show();
            }
            else if (form == 103) {
                form103.Show();
            }

            form97.FormClosing += new FormClosingEventHandler(Form102_FormClosing);
            form102.FormClosing += new FormClosingEventHandler(Form102_FormClosing);
            form103.FormClosing += new FormClosingEventHandler(Form102_FormClosing);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            this.lbltime.Text = dt.ToString("hh:mm tt");
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            string registryno = dgvData.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (form == 97)
            {
                Form97 form97 = new Form97(registryno);
                form97.Show();
                form97.setdata();
            }
            else if (form == 102)
            {
                Form102 form97 = new Form102(registryno);
                form97.Show();
            }
            else if (form == 103)
            {
                Form103 form97 = new Form103(registryno);
                form97.Show();
                form97.setdata();
            }

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (form == 97)
            {

                dgvData.DataSource = db.getForm97(txtsearch.Text);

            }
            else if (form == 102)
            {
                dgvData.DataSource = db.getForm102(txtsearch.Text);
            }
            else if (form == 103)
            {
                dgvData.DataSource = db.getForm103(txtsearch.Text);
            }
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to close the application?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.OK)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.Cancel)
            {

            }
        }
    }
}
