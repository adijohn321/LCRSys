using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LCRSys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection con = new Database().getConnection();
        Database data = new Database();

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form103 form102 = new Form103();
            form102.Show();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from users where username='" + txtusername.Text.Trim() + "' and password='" + txtPassword.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Incorect username and/or password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtPassword.Text = "";
                    txtusername.Text = "";
                    btnLogin.Enabled = false;
                }
                else
                {
                    MySqlDataReader reader = data.getUserLevel(txtusername.Text.Trim(), txtPassword.Text);
                    reader.Read();
                    Form2 frm = new Form2(reader.GetValue(1).ToString(), reader.GetValue(4).ToString());
                    data.closeConnection();
                    frm.Show();
                    this.Hide();
                }
                con.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Enter(object sender, EventArgs e)
        {
        }
    }
}
