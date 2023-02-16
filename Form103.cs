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
    public partial class Form103 : Form
    {
        Database db = new Database();
        Database db1 = new Database();
        Database db2 = new Database();
        Database db3 = new Database();
        Database db4 = new Database();
        Database db5 = new Database();
        MySqlConnection con = new Database().getConnection();
        public Form103()
        {
            InitializeComponent();
        }
        string registry;
        public Form103(string registry)
        {
            this.registry = registry;
            InitializeComponent();
            btnsave.Visible = false;
        }
        public void setdata()
        {
            MySqlDataReader data = db.reprint("SELECT * FROM `form103_tbl` WHERE registryno='" + registry + "'");
            if (data.Read())
            {
                txtregistryno.Text = data.GetValue(0).ToString();
                txt1first.Text = data.GetValue(1).ToString();
                txt1middle.Text = data.GetValue(2).ToString();
                txt1last.Text = data.GetValue(3).ToString();
                if (data.GetValue(4).ToString().Equals("Male"))
                    txtMale.Checked = true;
                else
                    txtFemale.Checked = true;
                txt3.Value = DateTime.Parse(parser(data.GetValue(5).ToString()));
                txt4.Value = DateTime.Parse(parser(data.GetValue(6).ToString()));
                ////age(7)
                txt6barangay.Text = data.GetValue(8).ToString();
                txt6citymun.Text = data.GetValue(9).ToString();
                txt6province.Text = data.GetValue(10).ToString();
                txt7.Text = data.GetValue(11).ToString();
                txt8.Text = data.GetValue(12).ToString();
                txt9.Text = data.GetValue(13).ToString();
                txt10a.Text = data.GetValue(14).ToString();
                txt10b.Text = data.GetValue(15).ToString();
                txt10c.Text = data.GetValue(16).ToString();
                txt11.Text = data.GetValue(17).ToString();
                txt12.Text = data.GetValue(18).ToString();
                txt13.Text = data.GetValue(19).ToString();
                if (data.GetValue(20).ToString().Equals("Burial"))
                {
                    chk23a.Checked = true;
                    txt24anum.Text = data.GetValue(21).ToString();
                    txt24adate.Text = data.GetValue(22).ToString();
                    txt24bnum.Text = data.GetValue(23).ToString();
                    txt24bdate.Text = data.GetValue(24).ToString();
                    txt24anum.Visible = true;
                    txt24adate.Visible = true;
                    txt24bnum.Visible = true;
                    txt24bdate.Visible = true;
                }
                else if (data.GetValue(20).ToString().Equals("Cremation"))
                {
                    chk23b.Checked = true;
                    txt24anum.Text = data.GetValue(21).ToString();
                    txt24adate.Text = data.GetValue(22).ToString();
                    txt24bnum.Text = data.GetValue(23).ToString();
                    txt24bdate.Text = data.GetValue(24).ToString();
                    txt24anum.Visible = true;
                    txt24adate.Visible = true;
                    txt24bnum.Visible = true;
                    txt24bdate.Visible = true;
                }
                else
                {
                    chk23c.Checked = true;
                    txt23specify.Text = data.GetValue(20).ToString();
                }

                txtFemale.Checked = true;

                txt25.Text = data.GetValue(25).ToString();
                txt26name.Text = data.GetValue(26).ToString();
                txt26relationship.Text = data.GetValue(27).ToString();
                txt26address.Text = data.GetValue(28).ToString();
                txt26date.Text = data.GetValue(29).ToString();
                txt27name.Text = data.GetValue(30).ToString();
                txt27position.Text = data.GetValue(31).ToString();
                txt27date.Text = data.GetValue(32).ToString();
                txt28name.Text = data.GetValue(33).ToString();
                txt28position.Text = data.GetValue(34).ToString();
                txt28date.Text = data.GetValue(35).ToString();
                txt29name.Text = data.GetValue(36).ToString();
                txt29position.Text = data.GetValue(37).ToString();
                txt29date.Text = data.GetValue(38).ToString();
                txtremarks.Text = data.GetValue(39).ToString();

            }

            MySqlDataReader data1 = db1.reprint("SELECT * FROM `form103_medicalcertificate_tbl` WHERE registryno='" + registry + "'");
            if (data1.Read())
            {
                txt19b1a.Text = data1.GetValue(1).ToString();
                txt19ba.Text = data1.GetValue(2).ToString();
                txt19b1b.Text = data1.GetValue(3).ToString();
                txt19bb.Text = data1.GetValue(4).ToString();
                txt19b1c.Text = data1.GetValue(5).ToString();
                txt19bc.Text = data1.GetValue(6).ToString();
                txt19b2.Text = data1.GetValue(7).ToString();
                txt19b23.Text = data1.GetValue(8).ToString();
                string maternalcase = data1.GetValue(9).ToString();
                if (maternalcase.Equals("pregnant not in labor"))
                    chk19c1.Checked = true;
                else if (maternalcase.Equals("pregnant in labor"))
                    chk19c2.Checked = true;
                else if (maternalcase.Equals("less than 42 days after delivery"))
                    chk19c3.Checked = true;
                else if (maternalcase.Equals("less than 42 days to 1 year after delivery"))
                    chk19c4.Checked = true;
                else if (maternalcase.Equals("None of the choices"))
                    chk19c5.Checked = true;
                txt19da.Text = data1.GetValue(10).ToString();
                txt19db.Text = data1.GetValue(11).ToString();
                if (data1.GetValue(12).ToString().ToLower().Equals("yes"))
                    rdyes.Checked = true;
                else
                    rdno.Checked = true;
                string attendant = data1.GetValue(13).ToString();
                if (attendant.Equals("Private Physician"))
                {
                    chk21a1.Checked = true;
                }
                else if (attendant.Equals("Public Health Officer"))
                {
                    chk21a2.Checked = true;
                }
                else if (attendant.Equals("Hospital Authority"))
                {
                    chk21a3.Checked = true;
                }
                else if (attendant.Equals("None"))
                {
                    chk21a4.Checked = true;
                }
                else if (attendant.Equals("Others"))
                {
                    chk21a5.Checked = true;
                    txtspecify.Text = data1.GetValue(13).ToString();
                }
                txt21bfrom.Value = DateTime.Parse(parser2(data1.GetValue(14).ToString()));
                txt21bto.Value = DateTime.Parse(parser2(data1.GetValue(15).ToString()));
                if (data1.GetValue(16).ToString().ToLower().Equals("attended"))
                    chk22a.Checked = true;
                else
                    chk22b.Checked = true;

                txt22time.Text = data1.GetValue(17).ToString().Substring(0, 5);
                if (data1.GetValue(17).ToString().Substring(5, 2).Equals("AM"))
                {
                    rdam.Checked = true;
                }
                else
                {
                    rdpm.Checked = true;
                }
                txt22name.Text = data1.GetValue(18).ToString();
                txt22position.Text = data1.GetValue(19).ToString();
                txt22adress.Text = data1.GetValue(20).ToString();
                txt22date.Value = DateTime.Parse(parser2(data1.GetValue(21).ToString()));
                txt22rname.Text = data1.GetValue(22).ToString();
                txt22rdate.Value = DateTime.Parse(parser2(data1.GetValue(21).ToString()));

            }
            MySqlDataReader data2 = db2.reprint("SELECT * FROM `form103_medicalcertificate2_tbl` WHERE registryno='" + registry + "'");
            if (data2.Read())
            {
                txt14.Text = data2.GetValue(1).ToString();
                txt15.Text = data2.GetValue(2).ToString();
                txt16.Text = data2.GetValue(3).ToString();
                txt17.Text = data2.GetValue(4).ToString();
                txt18.Text = data2.GetValue(5).ToString();
                txt19a1.Text = data2.GetValue(6).ToString();
                txt19a2.Text = data2.GetValue(7).ToString();
                txt19a3.Text = data2.GetValue(8).ToString();
                txt19a4.Text = data2.GetValue(9).ToString();
                txt19a5.Text = data2.GetValue(10).ToString();
                if (data2.GetValue(11).ToString().ToLower().Equals("yes"))
                    rdyes.Checked = true;
                else
                    rdno.Checked = true;
                string attendant = data2.GetValue(12).ToString();
                if (attendant.Equals("Private Physician"))
                {
                    chk21a1.Checked = true;
                }
                else if (attendant.Equals("Public Health Officer"))
                {
                    chk21a2.Checked = true;
                }
                else if (attendant.Equals("Hospital Authority"))
                {
                    chk21a3.Checked = true;
                }
                else if (attendant.Equals("None"))
                {
                    chk21a4.Checked = true;
                }
                else if (attendant.Equals("Others"))
                {
                    chk21a5.Checked = true;
                    txtspecify.Text = data2.GetValue(12).ToString();
                }
                txt21bfrom.Value = DateTime.Parse(parser2(data2.GetValue(13).ToString()));
                txt21bto.Value = DateTime.Parse(parser2(data2.GetValue(14).ToString()));

                if (data2.GetValue(15).ToString().ToLower().Equals("attended"))
                    chk22a.Checked = true;
                else
                    chk22b.Checked = true;

                txt22time.Text = data2.GetValue(16).ToString().Substring(0, 5);
                if (data2.GetValue(16).ToString().Substring(5, 2).Equals("AM"))
                {
                    rdam.Checked = true;
                }
                else
                {
                    rdpm.Checked = true;
                }
                txt22name.Text = data2.GetValue(17).ToString();
                txt22position.Text = data2.GetValue(18).ToString();
                txt22adress.Text = data2.GetValue(19).ToString();
                txt22date.Value = DateTime.Parse(parser2(data2.GetValue(20).ToString()));
                txt22rname.Text = data2.GetValue(21).ToString();
                txt22rdate.Value = DateTime.Parse(parser2(data2.GetValue(22).ToString()));
            }
            MySqlDataReader data3 = db3.reprint("SELECT * FROM `form103_pcod_tbl` WHERE registryno='" + registry + "'");
            if (data3.Read())
            {
                txtpcd.Text = data3.GetValue(1).ToString();
                txtpcdname.Text = data3.GetValue(2).ToString();
                txtpcddate.Value = DateTime.Parse(parser2(data3.GetValue(3).ToString()));
                txtpcdtitle.Text = data3.GetValue(4).ToString();
                txtpcdaddress.Text = data3.GetValue(5).ToString();

            }
            MySqlDataReader data4 = db4.reprint("SELECT * FROM `form103_certificationofembalmer` WHERE registryno='" + registry + "'");
            if (data4.Read())
            {
                txtcoe.Text = data4.GetValue(1).ToString();
                txtcoename.Text = data4.GetValue(2).ToString();
                txtcoeaddress.Text = data4.GetValue(3).ToString();
                txtcoetitle.Text = data4.GetValue(4).ToString();
                txtcoelicence.Text = data4.GetValue(5).ToString();
                txtceoissueddate.Value = DateTime.Parse(parser2(data4.GetValue(6).ToString()));
                txtceoissuedplace.Text = data4.GetValue(7).ToString();
                txtcoeexpirydate.Value = DateTime.Parse(parser2(data4.GetValue(8).ToString()));

            }



            MySqlDataReader data5 = db5.reprint("SELECT * FROM `from103_lateregistration_tbl` WHERE registryno='" + registry + "'");
            if (data5.Read()) {
                lbl1.Text = data5.GetValue(1).ToString();
                lbl2.Text = data5.GetValue(2).ToString();
                lbl3.Text = data5.GetValue(3).ToString();
                lbl4.Text = data5.GetValue(4).ToString();
                lbl5.Text = data5.GetValue(5).ToString();
                lbl6.Text = data5.GetValue(6).ToString();
                lbl7.Value =DateTime.Parse( parser2(data5.GetValue(7).ToString()));
                //
                if (data5.GetValue(8).ToString().ToLower().Equals("attended"))
                {
                    rdattended2.Checked = true;
                }
                else {
                    rdnotattended.Checked = true;
                }
                label1.Text = data5.GetValue(9).ToString();
                lbl9.Text = data5.GetValue(10).ToString();
                lbl10.Text = data5.GetValue(11).ToString();
                lbl11.Text = data5.GetValue(12).ToString();
                lbl12.Text = data5.GetValue(13).ToString();
                lbl13.Text = data5.GetValue(14).ToString();
                lbl14.Text = data5.GetValue(15).ToString();
                lbl15.Text = data5.GetValue(16).ToString();
                lbl16.Text = data5.GetValue(17).ToString();
                lbl17.Text = data5.GetValue(18).ToString();
                lbl18.Text = data5.GetValue(19).ToString();
                lbl19.Text = data5.GetValue(20).ToString();
                lbl20.Text = data5.GetValue(21).ToString();
                lbl21.Text = data5.GetValue(22).ToString();
                lbl22.Text = data5.GetValue(23).ToString();
                lbl23.Text = data5.GetValue(24).ToString();
                lbl24.Text = data5.GetValue(25).ToString();
                lbl25.Text = data5.GetValue(26).ToString();
            }

        }
        string parser(string load)
        {
            string ret = "";
            string day = load.Substring(0, 2);
            string year = load.Substring(load.Length - 4, 4);
            load = load.Substring(2, load.Length - 8);
            switch (load.Trim())
            {
                case "January":
                    ret = "01";
                    break;
                case "February":
                    ret = "02";
                    break;
                case "March":
                    ret = "03";
                    break;
                case "April":
                    ret = "04";
                    break;
                case "May":
                    ret = "05";
                    break;
                case "June":
                    ret = "06";
                    break;
                case "July":
                    ret = "07";
                    break;
                case "August":
                    ret = "08";
                    break;
                case "September":
                    ret = "09";
                    break;
                case "October":
                    ret = "10";
                    break;
                case "November":
                    ret = "11";
                    break;
                case "December":
                    ret = "12";
                    break;
            }
            return day + "/" + ret + "/" + year;
        }


        string parser2(string load)
        {
            string ret = "";
            string day = load.Substring(load.IndexOf(" ")+1, 2);
            string year = load.Substring(load.Length - 4, 4);
            load = load.Substring(0, load.IndexOf(" "));
            switch (load.Trim())
            {
                case "January":
                    ret = "01";
                    break;
                case "February":
                    ret = "02";
                    break;
                case "March":
                    ret = "03";
                    break;
                case "April":
                    ret = "04";
                    break;
                case "May":
                    ret = "05";
                    break;
                case "June":
                    ret = "06";
                    break;
                case "July":
                    ret = "07";
                    break;
                case "August":
                    ret = "08";
                    break;
                case "September":
                    ret = "09";
                    break;
                case "October":
                    ret = "10";
                    break;
                case "November":
                    ret = "11";
                    break;
                case "December":
                    ret = "12";
                    break;
            }
            return day + "/" + ret + "/" + year;
        }
        private void txt3_ValueChanged(object sender, EventArgs e)
        {
            //1.if n>7
            DateTime from = DateTime.Parse(txt4.Value.ToString("yyyy/MM/dd"));
            DateTime to = DateTime.Parse(txt3.Value.ToString("yyyy/MM/dd"));
            txt3.MinDate = txt4.Value;

            if (DateTime.Compare(from.AddDays(7), to) >= 0)
            {

                txt14.Visible = true;
                txt15.Visible = true;
                txt16.Visible = true;
                txt17.Visible = true;
                txt18.Visible = true;
                txt19a1.Visible = true;
                txt19a2.Visible = true;
                txt19a3.Visible = true;
                txt19a4.Visible = true;
                txt19a5.Visible = true;
                txt19b1a.Visible = false;
                txt19b1b.Visible = false;
                txt19b1c.Visible = false;
                txt19ba.Visible = false;
                txt19bb.Visible = false;
                txt19bc.Visible = false;
                txt19b2.Visible = false;
                txt19b23.Visible = false;
                chk19c1.Visible = false;
                chk19c2.Visible = false;
                chk19c3.Visible = false;
                chk19c4.Visible = false;
                chk19c5.Visible = false;
                txtspecify.Visible = false;

            }
            else
            {
                txt14.Visible = false;
                txt15.Visible = false;
                txt16.Visible = false;
                txt17.Visible = false;
                txt18.Visible = false;
                txt19a1.Visible = false;
                txt19a2.Visible = false;
                txt19a3.Visible = false;
                txt19a4.Visible = false;
                txt19a5.Visible = false;
                txt19b1a.Visible = true;
                txt19b1b.Visible = true;
                txt19b1c.Visible = true;
                txt19ba.Visible = true;
                txt19bb.Visible = true;
                txt19bc.Visible = true;
                txt19b2.Visible = true;
                txt19b23.Visible = true;
                txt19da.Visible = true;
                txt19db.Visible = true;

                chk19c1.Visible = false;
                chk19c2.Visible = false;
                chk19c3.Visible = false;
                chk19c4.Visible = false;
                chk19c5.Visible = false;

                if (DateTime.Compare(from.AddYears(15), to) <= 0 && DateTime.Compare(from.AddYears(49), to) >= 0 && txtFemale.Checked)
                {
                    chk19c1.Visible = true;
                    chk19c2.Visible = true;
                    chk19c3.Visible = true;
                    chk19c4.Visible = true;
                    chk19c5.Visible = true;


                }

            }
            DateTime ngayon = DateTime.Now;
            DateTime dod = DateTime.Parse(txt3.Value.ToString("yyyy/MM/dd"));
            if (DateTime.Compare(dod.AddYears(1), ngayon) <= 0)
            {
                txtremarks.Text = "Late Registration";
            }
            else
            {
                txtremarks.Text = "";
            }

            if (DateTime.Compare(from, to) == 0)
            {
                //24 hours old
                txt5c1.Visible = true;
                txt5c2.Visible = true;
                txt5b1.Visible = false;
                txt5b2.Visible = false;
                txt5.Visible = false;

            }
            else
            if (DateTime.Compare(from.AddYears(1), to) > 0)
            {
                
                //below one years old
                txt5c1.Visible = false;
                txt5c2.Visible = false;
                txt5b1.Visible = true;
                txt5b2.Visible = true;
                txt5.Visible = false;

                //calculate days and months

                int mon = to.Month - from.Month;
                if (to.Day < from.Day)
                    mon--;
                if (from.Year != to.Year)
                    mon += 12;
                int day = (to-from.AddMonths(mon)).Days;
                txt5b1.Text = "" + mon;
                txt5b2.Text = "" + day;




            }
            else
            {
                //above 1 y/o

                txt5c1.Visible = false;
                txt5c2.Visible = false;
                txt5b1.Visible = false;
                txt5b2.Visible = false;
                txt5.Visible = true;
                txt5.Text = "" + calculateAge(to,from);


            }

            /*if (DateTime.Compare(from.AddYears(1), DateTime.Now) <= 0)
            {
                txtremarks.Text = "Late Registration";

            }
            else
            {
                txtremarks.Text = "";

            }*/





        }



        int calculateAge(DateTime a, DateTime b)
        {
            a = DateTime.Parse(a.ToString("yyyy-MM-dd"));
            b = DateTime.Parse(b.ToString("yyyy-MM-dd"));
            int def = a.Year - b.Year;
            if (DateTime.Compare(b.AddYears(def), a) <= 0)
                return def;
            else
                def--;

            return def;
        }
        string pregnant;
        private void chk19c1_Click(object sender, EventArgs e)
        {
            pregnant = "pregnant not in labor";
            chk19c2.Checked = false;
            chk19c3.Checked = false;
            chk19c4.Checked = false;
            chk19c5.Checked = false;
        }
        
        
        private void chk19c2_Click(object sender, EventArgs e)
        {
            pregnant = "pregnant in labor";
            chk19c1.Checked = false;
            chk19c3.Checked = false;
            chk19c4.Checked = false;
            chk19c5.Checked = false;
        }

        private void chk19c3_Click(object sender, EventArgs e)
        {
            pregnant = "less than 42 days after delivery";
            chk19c1.Checked = false;
            chk19c2.Checked = false;
            chk19c4.Checked = false;
            chk19c5.Checked = false;
        }

        private void chk19c4_Click(object sender, EventArgs e)
        {
            pregnant = "less than 42 days to 1 year after delivery";
            chk19c1.Checked = false;
            chk19c2.Checked = false;
            chk19c3.Checked = false;
            chk19c5.Checked = false;
        }

        private void chk19c5_Click(object sender, EventArgs e)
        {
            chk19c1.Checked = false;
            chk19c2.Checked = false;
            chk19c3.Checked = false;
            chk19c4.Checked = false;
        }
        string getmaternalcase()
        {
            if (chk19c5.Checked)
                pregnant = "None of the choices";
            return pregnant;
        }

        private void txtMale_Click(object sender, EventArgs e)
        {
            txtFemale.Checked = false;
        }

        private void txtFemale_Click(object sender, EventArgs e)
        {
            txtMale.Checked = false;
        }

        private void chk21a1_Click(object sender, EventArgs e)
        {
            attendant = "Private Physician";
            txtspecify.Text = "";
            chk21a2.Checked = false;
            chk21a3.Checked = false;
            chk21a4.Checked = false;
            chk21a5.Checked = false;
        }
       
        private void chk21a2_Click(object sender, EventArgs e)
        {
            attendant = "Public Health Officer";
            txtspecify.Visible = false;
            chk21a1.Checked = false;
            chk21a3.Checked = false;
            chk21a4.Checked = false;
            chk21a5.Checked = false;
        }

        private void chk21a3_Click(object sender, EventArgs e)
        {
            attendant = "Hospital Authority";
            txtspecify.Visible = false;
            chk21a1.Checked = false;
            chk21a2.Checked = false;
            chk21a4.Checked = false;
            chk21a5.Checked = false;
        }

        private void chk21a4_Click(object sender, EventArgs e)
        {
            attendant = "None";
            txtspecify.Visible = false;
            chk21a1.Checked = false;
            chk21a2.Checked = false;
            chk21a3.Checked = false;
            chk21a5.Checked = false;
        }

        private void chk21a5_Click(object sender, EventArgs e)
        {
            attendant = "Others";
            txtspecify.Text = "";
            chk21a1.Checked = false;
            chk21a2.Checked = false;
            chk21a3.Checked = false;
            chk21a4.Checked = false;
            txtspecify.Visible = true;
        }
        string attendant;
        string getAttendant()
        {
            if (chk21a5.Checked)
                attendant = "Others - " + txtspecify.Text;
            return attendant;
        }

        private void chk22a_Click(object sender, EventArgs e)
        {
            chk22b.Checked = false;
            

        }
        private void chk22b_Click(object sender, EventArgs e)
        {
            chk22a.Checked = false;
           
            
        }
        private void chk23a_Click(object sender, EventArgs e)
        {
            chk23b.Checked = false;
            chk23c.Checked = false;
            txt23specify.Visible = false;
            txt24anum.Visible = true;
            txt24adate.Visible = true;
            txt24bnum.Visible = true;
            txt24bdate.Visible = true;
        }

        private void chk23b_Click(object sender, EventArgs e)
        {
            chk23a.Checked = false;
            chk23c.Checked = false;
            txt23specify.Visible = false;
            txt24anum.Visible = true;
            txt24adate.Visible = true;
            txt24bnum.Visible = true;
            txt24bdate.Visible = true;
        }

        private void chk23c_Click(object sender, EventArgs e)
        {
            chk23a.Checked = false;
            chk23b.Checked = false;
            txt24anum.Visible = false;
            txt24adate.Visible = false;
            txt24bnum.Visible = false;
            txt24bdate.Visible = false;
            txt23specify.Visible = true;
        }
        string corpsedisposal;
        string getCorpsedisposal()
        {


            if (chk23a.Checked)
                corpsedisposal = "Burial";

            else if (chk23b.Checked)
                corpsedisposal = "Cremation";
            else if (chk23c.Checked)
                corpsedisposal = "Others - " + txt23specify.Text;
            return corpsedisposal;
        }

        private void rdyes_Click(object sender, EventArgs e)
        {
            rdno.Checked = false;
        }

        private void rdno_Click(object sender, EventArgs e)
        {
            rdyes.Checked = false;
        }
        public MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=lcr_db;");
        public MySqlCommand cmd1;
        MySqlDataReader dr1;
        string id;
        void createRegistryNo()
        {

            conn.Close();
            conn.Open();
            cmd1 = new MySqlCommand("Select * from form103_tbl", conn);
            dr1 = cmd1.ExecuteReader();
            string date = DateTime.Now.ToString("yyyy"), date1 = date;
            int num = 0;
            while (dr1.Read())
            {
                num = Int32.Parse(dr1.GetString("registryno").ToString().Substring(5, 4));
                date1 = dr1.GetString("registryno").ToString().Substring(0, 4);
            }
            if (!(date.Equals(date1)))
                num = 0;
            id = date + "-" + numberToString(num);
            txtregistryno.Text = id;


            dr1.Close();
            conn.Close();
        }
        string numberToString(int input)
        {
            if (input >= 10000)
            {
                return "0001";
            }
            input++;
            string output = "00000" + input;


            return output.Substring(output.Length - 4, 4);
        }
        void visibleFalse()
        {
            txt5.Visible = false;
            txt5b1.Visible = false;
            txt5b2.Visible = false;
            txt5c1.Visible = false;
            txt5c2.Visible = false;
            txtspecify.Visible = false;
            txt23specify.Visible = false;
            txt24anum.Visible = false;
            txt24adate.Visible = false;
            txt24bnum.Visible = false;
            txt24bdate.Visible = false;

            chk19c1.Visible = false;
            chk19c2.Visible = false;
            chk19c3.Visible = false;
            chk19c4.Visible = false;
            chk19c5.Visible = false;

            txt14.Visible = false;
            txt15.Visible = false;
            txt16.Visible = false;;
            txt17.Visible = false;
            txt18.Visible = false;
            txt19a1.Visible = false;
            txt19a2.Visible = false;
            txt19a3.Visible = false;
            txt19a4.Visible = false;
            txt19a5.Visible = false;

            txt19b1a.Visible = false;
            txt19b1b.Visible = false;
            txt19b1c.Visible = false;
            txt19ba.Visible = false;
            txt19bb.Visible = false;
            txt19bc.Visible = false;
            txt19b2.Visible = false;
            txt19b23.Visible = false;
            txt19da.Visible = false;
            txt19db.Visible = false;

            txtpcd.Visible = false;
            txtpcdname.Visible = false;
            txtpcddate.Visible = false;
            txtpcdtitle.Visible = false;
            txtpcdaddress.Visible = false;

            txtcoe.Visible = false;
            txtcoename.Visible = false;
            txtcoeaddress.Visible = false;
            txtcoetitle.Visible = false;
            txtcoelicence.Visible = false;
            txtceoissueddate.Visible = false;
            txtceoissuedplace.Visible = false;
            txtcoeexpirydate.Visible = false;


            lbl1.Visible = false;
            lbl2.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;
            lbl9.Visible = false;
            lbl10.Visible = false;
            lbl11.Visible = false;
            lbl12.Visible = false;
            lbl13.Visible = false;
            lbl14.Visible = false;
            lbl15.Visible = false;
            lbl16.Visible = false;
            lbl17.Visible = false;
            lbl18.Visible = false;
            lbl19.Visible = false;
            lbl20.Visible = false;
            lbl21.Visible = false;
            lbl22.Visible = false;
            lbl23.Visible = false;
            lbl24.Visible = false;
            lbl25.Visible = false;
            rdattended2.Visible = false;
            rdnotattended.Visible = false;
            label1.Visible = false;




        }

        private void Form103_Load(object sender, EventArgs e)
        {
            txt26date.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txt27date.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txt28date.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txt29date.Text = DateTime.Today.AddDays(2).ToString("MMMM dd, yyyy");
            txt3.MaxDate = DateTime.Now;
            txt4.MaxDate = DateTime.Now;
            visibleFalse();
            createRegistryNo();



        }

        private void txtFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (txtFemale.Checked)
            {

                DateTime from = DateTime.Parse(txt4.Value.ToString("yyyy/MM/dd"));
                DateTime to = DateTime.Parse(txt3.Value.ToString("yyyy/MM/dd"));

                if (DateTime.Compare(from.AddYears(15), to) <= 0 && DateTime.Compare(from.AddYears(49), to) >= 0)
                {
                    chk19c1.Visible = true;
                    chk19c2.Visible = true;
                    chk19c3.Visible = true;
                    chk19c4.Visible = true;
                    chk19c5.Visible = true;


                }
            }
            else
            {
                chk19c1.Visible = false;
                chk19c2.Visible = false;
                chk19c3.Visible = false;
                chk19c4.Visible = false;
                chk19c5.Visible = false;
            }
        }
        string age;
        private void btnsave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Primary Information Saved.");
            if (db.insertform103(txtregistryno.Text, txt1first.Text, txt1middle.Text, txt1last.Text, txtMale.Checked ? "MALE":"FEMALE",txt3.Text, txt4.Text, txt5.Text, txt6barangay.Text, txt6citymun.Text, txt6province.Text, txt7.Text, txt8.Text, txt9.Text, txt10a.Text, txt10b.Text, txt10c.Text, txt11.Text, txt12.Text, txt13.Text, getCorpsedisposal(), txt24anum.Text, txt24adate.Text, txt24bnum.Text, txt24bdate.Text, txt25.Text, txt26name.Text, txt26relationship.Text, txt26address.Text, txt26date.Text, txt27name.Text, txt27position.Text, txt27date.Text, txt28name.Text, txt28position.Text, txt28date.Text, txt29name.Text, txt29position.Text, txt29date.Text, txtremarks.Text))
            {
                MessageBox.Show("Saved Successfully.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DateTime from = DateTime.Parse(txt4.Value.ToString("yyyy/MM/dd"));
            DateTime to = DateTime.Parse(txt3.Value.ToString("yyyy/MM/dd"));

            if (DateTime.Compare(from, to) == 0)
            {
                age = txt5c1.Text + ":" + txt5c2.Text;
            }
            else
            if (DateTime.Compare(from.AddYears(1), to) > 0)
            {
                age = txt5b1.Text + " Month/s and " + txt5b2.Text + " day/s old";
            }
            else
            {
                age = txt5.Text;
            }

            if (DateTime.Compare(from.AddDays(7), to) >= 0)
            {
                if (db.insertdeathcertificate2(txtregistryno.Text, txt14.Text, age, txt16.Text,txt17.Text, txt18.Text, txt19a1.Text, txt19a2.Text, txt19a3.Text, txt19a4.Text, txt19a5.Text, rdyes.Checked ? "Yes" : "No", getAttendant(), txt21bfrom.Text, txt21bto.Text, chk22a.Checked ? "attended" : "not attended", txt22time.Text + (rdam.Checked ? "AM" : "PM"), txt22name.Text, txt22position.Text, txt22adress.Text, txt22date.Text, txt22rname.Text, txt22rdate.Text))
                {
                }

            }
            else
            {
                if (db.insertdeathcertificate(txtregistryno.Text, txt19b1a.Text, txt19ba.Text, txt19b1b.Text, txt19bb.Text, txt19b1c.Text, txt19bc.Text, txt19b2.Text, txt19b23.Text, getmaternalcase(), txt19da.Text, txt19db.Text, rdyes.Checked ? "Yes" : "No", getAttendant(), txt21bfrom.Text, txt21bto.Text, chk22a.Checked ? "attended" : "not attended", txt22time.Text + (rdam.Checked ? "AM" : "PM"), txt22name.Text, txt22position.Text, txt22adress.Text, txt22date.Text, txt22rname.Text, txt22rdate.Text))
                {
                   
                }
            }
            if (!txt8.Text.ToLower().Equals("islam"))
            {
                if (db.insertcertificateofembalmer(txtregistryno.Text, txtcoe.Text, txtcoename.Text, txtcoeaddress.Text, txtcoetitle.Text, txtcoelicence.Text, txtceoissueddate.Text, txtceoissuedplace.Text, txtcoeexpirydate.Text))
                {
                   
                }
            }

            if (rdyes.Checked)
            {
                if (db.insertdeathpcod(txtregistryno.Text, txtpcd.Text, txtpcdname.Text, txtpcddate.Text, txtpcdtitle.Text, txtpcdaddress.Text))
                {
                    
                }
            }

            if (txtremarks.Text.ToLower().ToString().Equals("late registration"))
            {
                if (db.insertform103lr(txtregistryno.Text, lbl1.Text, lbl2.Text, lbl3.Text, lbl4.Text, lbl5.Text, lbl6.Text, lbl7.Text, rdattended2.Checked ? "attended":"not attended", label1.Text, lbl9.Text, lbl10.Text, lbl11.Text, lbl12.Text, lbl13.Text, lbl14.Text, lbl15.Text, lbl16.Text, lbl17.Text, lbl18.Text, lbl19.Text, lbl20.Text, lbl21.Text, lbl22.Text, lbl23.Text, lbl24.Text, lbl25.Text ))
                {
                  
                }
            }


        }

        private void rdyes_Click_1(object sender, EventArgs e)
        {
            rdno.Checked = false;
            txtpcd.Visible = true;
            txtpcdname.Visible = true;
            txtpcddate.Visible = true;
            txtpcdtitle.Visible = true;
            txtpcdaddress.Visible = true;
        }

        private void rdno_Click_1(object sender, EventArgs e)
        {
            rdyes.Checked = false;
            txtpcd.Visible = false;
            txtpcdname.Visible = false;
            txtpcddate.Visible = false;
            txtpcdtitle.Visible = false;
            txtpcdaddress.Visible = false;
        }


        private void txt8_TextChanged(object sender, EventArgs e)
        {
            if (txt8.Text.ToLower().ToString().Equals("islam"))
            {
                txtcoe.Visible = false;
                txtcoename.Visible = false;
                txtcoeaddress.Visible = false;
                txtcoetitle.Visible = false;
                txtcoelicence.Visible = false;
                txtceoissueddate.Visible = false;
                txtceoissuedplace.Visible = false;
                txtcoeexpirydate.Visible = false;
            }
            else
            {

                txtcoe.Visible = true;
                txtcoe.Text = txt1first.Text.ToUpper() + " " + txt1middle.Text.ToUpper() + " " + txt1last.Text.ToUpper();
                txtcoename.Visible = true;
                txtcoeaddress.Visible = true;
                txtcoetitle.Visible = true;
                txtcoelicence.Visible = true;
                txtceoissueddate.Visible = true;
                txtceoissuedplace.Visible = true;
                txtcoeexpirydate.Visible = true;

            }
        }

        private void txtremarks_TextChanged(object sender, EventArgs e)
        {
        }

        private void rdattended_Click(object sender, EventArgs e)
        {
            rdnotattended.Checked = false;
            label1.Visible = true;
            label1.Text = txt22name.Text;
        }

        private void rdnotattended_Click(object sender, EventArgs e)
        {
            rdattended2.Checked = false;
            label1.Visible = false;
        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (txtremarks.Text.ToString().Equals("Late Registration"))
            {
                if (rdattended2.Checked)
                {
                    label1.Visible = true;
                    label1.Text = txt22name.Text;

                }
                else {
                    label1.Visible = false;
                    label1.Text = "";
                }

                lbl1.Visible = true;
                lbl2.Visible = true;
                lbl3.Visible = true;
                lbl4.Visible = true;
                lbl5.Visible = true;
                lbl6.Visible = true;
                lbl7.Visible = true;
                lbl9.Visible = true;
                lbl10.Visible = true;
                lbl11.Visible = true;
                lbl12.Visible = true;
                lbl13.Visible = true;
                lbl14.Visible = true;
                lbl15.Visible = true;
                lbl16.Visible = true;
                lbl17.Visible = true;
                lbl18.Visible = true;
                lbl19.Visible = true;
                lbl20.Visible = true;
                lbl21.Visible = true;
                lbl22.Visible = true;
                lbl23.Visible = true;
                lbl24.Visible = true;
                lbl25.Visible = true;
                rdattended2.Visible = true;
                rdnotattended.Visible = true;

                lbl1.Text = txt26name.Text.ToUpper();
                lbl2.Text = txt26address.Text;
                lbl3.Text = txt1first.Text.ToUpper() + " " + txt1middle.Text.ToUpper() + " " + txt1last.Text.ToUpper();
                lbl4.Text = txt3.Text;
                lbl5.Text = txt6barangay.Text + " " + txt6citymun.Text + " " + txt6province.Text;
                lbl6.Text = txt25.Text;

                DateTime from = DateTime.Parse(txt4.Value.ToString("yyyy/MM/dd"));
                DateTime to = DateTime.Parse(txt3.Value.ToString("yyyy/MM/dd"));
                txt3.MinDate = txt4.Value;
                lbl15.Text = lbl1.Text.ToUpper();
                DateTime dt = DateTime.Now;
                string d2d = dt.ToString("dd").Substring(1);
                string suffix = (dt.Day == 11 || dt.Day == 12 || dt.Day == 13) ? "th"
               : (d2d == "1") ? "st"
               : (d2d == "2") ? "nd"
               : (d2d == "3") ? "rd"
               : "th";
                lbl11.Text = DateTime.Today.Day.ToString("d") + suffix;
                string theMonth = DateTime.Now.ToString("MMMM");
                lbl12.Text = theMonth;
                lbl13.Text = DateTime.Now.Year.ToString();
                lbl16.Text = DateTime.Today.Day.ToString("d") + suffix;
                lbl17.Text = theMonth;
                lbl18.Text = DateTime.Now.Year.ToString();
                lbl23.Text = txt29name.Text.ToUpper();
                lbl24.Text = txt29position.Text.ToUpper();
                lbl25.Text = txtprovince.Text.ToUpper() + " " + txtcitymun.Text.ToUpper();
            }
            else { }
        }

        private void chk22a_CheckedChanged(object sender, EventArgs e)
        {
            rdattended2.Checked = chk22a.Checked;
        }

        private void chk22b_CheckedChanged(object sender, EventArgs e)
        {
            rdnotattended.Checked = chk22b.Checked;
        }

        private void rdpm_Click(object sender, EventArgs e)
        {
            rdam.Checked = false;
        }

        private void rdam_Click(object sender, EventArgs e)
        {
            rdpm.Checked = false;
        }

        private void additional_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] data =
            {
                txtregistryno.Text,
                txt1first.Text,
                txt1middle.Text,
                txt1last.Text,
                txt3.Text,
                txt4.Text,
                txt5.Text,
                txt5b1.Text,
                txt5b2.Text,
                txt5c1.Text,
                txt5c2.Text,
                txt6barangay.Text,
                txt6citymun.Text,
                txt6province.Text,
                txt7.Text,
                txt8.Text, 
                txt9.Text,
                (txt10a.Text + " " + txt10b.Text + " " + txt10c.Text),
                txt11.Text,
                txt12.Text,
                txt13.Text,
                txt19b1a.Text,
                txt19ba.Text,
                txt19b1b.Text,
                txt19bb.Text,
                txt19b1c.Text,
                txt19bc.Text,
                txt19b2.Text,
                txt19b23.Text,
                txt19da.Text,
                txt19db.Text,
                txtspecify.Text,
                txt21bfrom.Text,
                txt21bto.Text, 
                txt22time.Text,
                txt22name.Text,
                txt22position.Text,
                txt22adress.Text,
                txt22date.Text,
                txt22rname.Text,
                txt22rdate.Text,
                getCorpsedisposal(),
                txt24anum.Text,
                txt24adate.Text,
                txt24bnum.Text,
                txt24bdate.Text,
                txt25.Text,
                txt26name.Text,
                txt26relationship.Text,
                txt26address.Text,
                txt26date.Text,
                txt27name.Text,
                txt27position.Text,
                txt27date.Text,
                txt28name.Text,
                txt28position.Text,
                txt28date.Text,
                txt29name.Text,
                txt29position.Text,
                txt29date.Text,
                txtremarks.Text




            };
            string[] x =
            {
                txtMale.Checked ? "Male":"Female",
                chk19c1.Checked ? "X":"",
                chk19c2.Checked ? "X":"",
                chk19c3.Checked ? "X":"",
                chk19c4.Checked ? "X":"",
                chk19c5.Checked ? "X":"",
                rdyes.Checked ? "Yes":"No",
                chk21a1.Checked ? "X":"",
                chk21a2.Checked ? "X":"",
                chk21a3.Checked ? "X":"",
                chk21a4.Checked ? "X":"",
                chk21a5.Checked ? "X":"",
                chk22a.Checked ? "X":"",
                chk22b.Checked ? "X":"",
                rdam.Checked ? "am":"pm",


            };
            
            Previewer frm = new Previewer(data, x, "Form103page1");
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] data =
            {
               txt14.Text,
               txt15.Text,
               txt16.Text,
               txt17.Text,
               txt18.Text,
               txt19a1.Text,
               txt19a2.Text,
               txt19a3.Text,
               txt19a4.Text,
               txt19a5.Text,

               txtpcd.Text,
               txtpcdname.Text,
               txtpcddate.Text,
               txtpcdtitle.Text,
               txtpcdaddress.Text,

               txtcoe.Text,
               txtcoename.Text,
               txtcoeaddress.Text,
               txtcoetitle.Text,
               txtcoelicence.Text,
               txtceoissueddate.Text,
               txtceoissuedplace.Text,
               txtcoeexpirydate.Text,

               lbl1.Text,
               lbl2.Text,
               lbl3.Text,
               lbl4.Text,
               lbl5.Text,
               lbl6.Text,
               lbl7.Text,
               label1.Text,
               lbl9.Text,
               lbl10.Text,
               lbl11.Text,
               lbl12.Text,
               lbl13.Text,
               lbl14.Text,
               lbl15.Text,
               lbl16.Text,
               lbl17.Text,
               lbl18.Text,
               lbl19.Text,
               lbl20.Text,
               lbl21.Text,
               lbl22.Text,
               lbl23.Text,
               lbl24.Text,
               lbl25.Text
            };

            string[] x =
            {
                rdattended2.Checked ? "X":"",
                rdnotattended.Checked ? "X":""
            };
            Previewer frm = new Previewer(data, x, "Form103page2");

            frm.Show();
        }

        private void lbl2_Click(object sender, EventArgs e)
        {

        }

        void clear()
        {
            txtregistryno.Text = "";
            txt1first.Text = "";
            txt1middle.Text = "";
            txt1last.Text = "";
            txt3.Text = "";
            txt4.Text = DateTime.Now.ToString("dd MMMM, yyyy");
            txt5.Text = DateTime.Now.ToString("dd MMMM, yyyy");
            txt5b1.Text = "";
            txt5b2.Text = "";
            txt5c1.Text = "";
            txt5c2.Text = "";
            txt6barangay.Text = "";
            txt6citymun.Text = "";
            txt6province.Text = "";
            txt7.Text = "";
            txt8.Text = "";
            txt9.Text = "";
            txt10a.Text = ""; 
            txt10b.Text = ""; 
            txt10c.Text = "";
            txt11.Text = "";
            txt12.Text = "";
            txt13.Text = "";
            txt19b1a.Text = "";
            txt19ba.Text = "";
            txt19b1b.Text = "";
            txt19bb.Text = "";
            txt19b1c.Text = "";
            txt19bc.Text = "";
            txt19b2.Text = "";
            txt19b23.Text = "";
            txt19da.Text = "";
            txt19db.Text = "";
            txtspecify.Text = "";
            txt21bfrom.Text = DateTime.Now.ToString("dd MMMM, yyyy");
            txt21bto.Text = DateTime.Now.ToString("dd MMMM, yyyy");
            txt22time.Text = "";
            txt22name.Text = "";
            txt22position.Text = "";
            txt22adress.Text = "";
            txt22date.Text = DateTime.Now.ToString("dd MMMM, yyyy");
            txt22rname.Text = "";
            txt22rdate.Text = DateTime.Now.ToString("dd MMMM, yyyy");
            chk23a.Checked = false;
            chk23b.Checked = false;
            chk23c.Checked = false;
            txt23specify.Text = "";
            txt24anum.Text = "";
            txt24adate.Text = "";
            txt24bnum.Text = "";
            txt24bdate.Text = "";
            txt25.Text = "";
            txt26name.Text = "";
            txt26relationship.Text = "";
            txt26address.Text = "";
            txt26date.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txt27name.Text = "";
            txt27position.Text = "";
            txt27date.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txt28name.Text = "";
            txt28position.Text = "";
            txt28date.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txt29name.Text = "";
            txt29position.Text = "";
            txt29date.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txtremarks.Text = "";

            txt14.Text = "";
            txt15.Text = "";
            txt16.Text = "";
            txt17.Text = "";
            txt18.Text = "";
            txt19a1.Text = "";
            txt19a2.Text = "";
            txt19a3.Text = "";
            txt19a4.Text = "";
            txt19a5.Text = "";

            txtpcd.Text = "";
            txtpcdname.Text = "";
            txtpcddate.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txtpcdtitle.Text = "";
            txtpcdaddress.Text = "";

            txtcoe.Text = "";
            txtcoename.Text = "";
            txtcoeaddress.Text = "";
            txtcoetitle.Text = "";
            txtcoelicence.Text = "";
            txtceoissueddate.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txtceoissuedplace.Text = "";
            txtcoeexpirydate.Text = DateTime.Today.ToString("MMMM dd, yyyy");

            lbl1.Text = "";
            lbl2.Text = "";
            lbl3.Text = "";
            lbl4.Text = "";
            lbl5.Text = "";
            lbl6.Text = "";
            lbl7.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            label1.Text = "";
            lbl9.Text = "";
            lbl10.Text = "";
            lbl11.Text = "";
            lbl12.Text = "";
            lbl13.Text = "";
            lbl14.Text = "";
            lbl15.Text = "";
            lbl16.Text = "";
            lbl17.Text = "";
            lbl18.Text = "";
            lbl19.Text = "";
            lbl20.Text = "";
            lbl21.Text = "";
            lbl22.Text = "";
            lbl23.Text = "";
            lbl24.Text = "";
            lbl25.Text = "";
            rdattended2.Checked = false;
            rdnotattended.Checked = false;
        }

        private void txt24bdate_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt24bdate.Text.Length == 2)
            {
                if (e.KeyValue == Convert.ToChar(Keys.Back))
                {
                    txt24bdate.Text = txt24bdate.Text.Substring(0, 1);
                    txt24bdate.SelectionStart = 1;
                    return;
                }
                txt24bdate.Text = txt24bdate.Text + "/";
                txt24bdate.SelectionStart = 3;
            }
            if (txt24bdate.Text.Length == 5)
            {
                if (e.KeyValue == Convert.ToChar(Keys.Back))
                {
                    txt24bdate.Text = txt24bdate.Text.Substring(0, 4);
                    txt24bdate.SelectionStart = 4;
                    return;
                }
                txt24bdate.Text = txt24bdate.Text + "/";
                txt24bdate.SelectionStart = 6;
            }
        }

        private void txt1first_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (Keys)e.KeyChar == Keys.Space);
            if (txt1first.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void txt19b1a_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (Keys)e.KeyChar == Keys.Space || char.IsDigit(e.KeyChar));
            if (txt19b1a.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void txt24anum_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || (Keys)e.KeyChar == Keys.Space);
            if (txt24anum.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void txt22time_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt22time.Text.Length == 2)
            {
                if (e.KeyValue == Convert.ToChar(Keys.Back))
                {
                    txt22time.Text = txt22time.Text.Substring(0, 1);
                    txt22time.SelectionStart = 1;
                    return;
                }
                txt22time.Text = txt22time.Text + ":";
                txt22time.SelectionStart = 3;
            }
        }
    }
}
