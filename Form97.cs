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
    public partial class Form97 : Form
    {
        Database db = new Database();
        Database db1 = new Database();
        Database db2 = new Database();
        Database db3 = new Database();
        Database db4 = new Database();
        Database db5 = new Database();
        public Form97()
        {
            InitializeComponent();
            txtdom.MaxDate = DateTime.Now;
            txthdob.MaxDate = DateTime.Now;
            txtwdob.MaxDate = DateTime.Now;
        }
        string registry = null;

        public Form97(string registryno)
        {
            this.registry = registryno;
            InitializeComponent();
            button2.Visible = false;
        }

        public void setdata()
        {
            MySqlDataReader data = db.reprint("SELECT * FROM `form97_husbanddata_tbl` WHERE registryno='" + registry + "'");
            if (data.Read())
            {
                txth1.Text = data.GetValue(1).ToString();
                txth2.Text = data.GetValue(2).ToString();
                txth3.Text = data.GetValue(3).ToString();
                label3.Text = txth1.Text + " " + txth2.Text + " " + txth3.Text;
                txthdob.Value = DateTime.Parse(parser(data.GetValue(4).ToString()));
                txthage.Text = data.GetValue(5).ToString();
                txthpob.Text = data.GetValue(6).ToString();
                txthsex.Text = data.GetValue(7).ToString();
                txthcitezenship.Text = data.GetValue(8).ToString();
                txthresidence.Text = data.GetValue(9).ToString();
                txthreligion.Text = data.GetValue(10).ToString();
                txthcs.Text = data.GetValue(11).ToString();
                txthf1.Text = data.GetValue(12).ToString();
                txthf2.Text = data.GetValue(13).ToString();
                txthf3.Text = data.GetValue(14).ToString();
                txthfcit.Text = data.GetValue(15).ToString();
                txthm1.Text = data.GetValue(16).ToString();
                txthm2.Text = data.GetValue(17).ToString();
                txthm3.Text = data.GetValue(18).ToString();
                txthmcit.Text = data.GetValue(19).ToString();
                txthw1.Text = data.GetValue(20).ToString();
                txthw2.Text = data.GetValue(21).ToString();
                txthw3.Text = data.GetValue(22).ToString();
                txthrelationship.Text = data.GetValue(23).ToString();
                txthwresidence.Text = data.GetValue(24).ToString();
            }
            MySqlDataReader data1 = db1.reprint("SELECT * FROM `form97_wifedata_tbl` WHERE registryno='" + registry + "'");
            if (data1.Read())
            {
                txtw1.Text = data1.GetValue(1).ToString();
                txtw2.Text = data1.GetValue(2).ToString();
                txtw3.Text = data1.GetValue(3).ToString();
                label4.Text = txtw1.Text + " " + txtw2.Text + " " + txtw3.Text;
                txtwdob.Value = DateTime.Parse(parser(data1.GetValue(4).ToString()));
                txtwage.Text = data1.GetValue(5).ToString();
                txtwpob.Text = data1.GetValue(6).ToString();
                txtwsex.Text = data1.GetValue(7).ToString();
                txtwcitizenship.Text = data1.GetValue(8).ToString();
                txtwresidence.Text = data1.GetValue(9).ToString();
                txtwreligion.Text = data1.GetValue(10).ToString();
                txtwcs.Text = data1.GetValue(11).ToString();
                txtwf1.Text = data1.GetValue(12).ToString();
                txtwf2.Text = data1.GetValue(13).ToString();
                txtwf3.Text = data1.GetValue(14).ToString();
                txtwfcit.Text = data1.GetValue(15).ToString();
                txtwm1.Text = data1.GetValue(16).ToString();
                txtwm2.Text = data1.GetValue(17).ToString();
                txtwm3.Text = data1.GetValue(18).ToString();
                txtwmcit.Text = data1.GetValue(19).ToString();
                txtww1.Text = data1.GetValue(20).ToString();
                txtww2.Text = data1.GetValue(21).ToString();
                txtww3.Text = data1.GetValue(22).ToString();
                txtwrelationship.Text = data1.GetValue(23).ToString();
                txtwwresidence.Text = data1.GetValue(24).ToString();
            }
            MySqlDataReader data2 = db2.reprint("SELECT * FROM `form97_tbl` WHERE registryno='" + registry + "'");
            if (data2.Read())
            {
                txtregistryno.Text = data2.GetValue(0).ToString();
                string pom = data2.GetValue(1).ToString();
                txtpom1.Text = pom.Substring(0, pom.IndexOf("$"));
                pom = pom.Substring(pom.IndexOf("$") + 1, pom.Length - pom.IndexOf("$") - 1);
                txtpom2.Text = pom.Substring(0, pom.IndexOf("$"));
                pom = pom.Substring(pom.IndexOf("$") + 1, pom.Length - pom.IndexOf("$") - 1);
                txtpom3.Text = pom;
                txtdom.Value = DateTime.Parse(parser(data2.GetValue(2).ToString()));
                txtom.Text = data2.GetValue(3).ToString().Substring(0, 5);
                if (data2.GetValue(3).ToString().Substring(5, 2).Equals("AM"))
                {
                    rdam.Checked = true;
                }
                else
                {
                    rdpm.Checked = true;
                }
                string settlement = data2.GetValue(4).ToString();
                if (settlement.Equals("have entered"))
                    checkhave.Checked = true;
                else
                    checkhavenot.Checked = true;
                lbldd.Text = data2.GetValue(5).ToString();
                lblmm.Text = data2.GetValue(6).ToString();
                lblyyyy.Text = data2.GetValue(7).ToString();


                string cso = data2.GetValue(8).ToString();
                if (cso[0] == 'a') {
                    checka.Checked = true;
                    cso = cso.Substring(cso.IndexOf("$") + 1, cso.Length - cso.IndexOf("$") - 1);
                    txtml1.Text = cso.Substring(0, cso.IndexOf("$"));
                    cso = cso.Substring(cso.IndexOf("$") + 1, cso.Length - cso.IndexOf("$") - 1);
                    txtml2.Text = cso.Substring(0, cso.IndexOf("$"));
                    cso = cso.Substring(cso.IndexOf("$") + 1, cso.Length - cso.IndexOf("$") - 1);
                    txtml3.Text = cso;
                    txtml1.Visible = true;
                    txtml2.Visible = true;
                    txtml3.Visible = true;


                }
                else if (cso[0] == 'b') {
                    checkb.Checked = true;

                    cso = cso.Substring(cso.IndexOf("$") + 1, cso.Length - cso.IndexOf("$") - 1);
                    txtml4.Text = cso;
                    txtml4.Visible = true;


                }
                else {
                    checkc.Checked = true;
                }
                txtsoname.Text = data2.GetValue(9).ToString();
                txtsoposition.Text = data2.GetValue(10).ToString();
                txtsoreligion.Text = data2.GetValue(11).ToString();


                string witnesses = data2.GetValue(12).ToString();
                string[] witness = witnesses.Split('$');
                txtwitness1.Text = witness[0];
                txtwitness2.Text = witness[1];
                if (witness.Length >= 3) {
                    txtwitness3.Text = witness[2];
                }
                if (witness.Length >= 4)
                {
                    txtwitness4.Text = witness[3];
                }
                if (witness.Length >= 5)
                {
                    txtwitness5.Text = witness[4];
                }
                if (witness.Length >= 6)
                {
                    txtwitness6.Text = witness[5];
                }
                txtrecievename.Text = data2.GetValue(13).ToString();
                txtrecieveposition.Text = data2.GetValue(14).ToString();
                txtrecievedate.Text = data2.GetValue(15).ToString();
                txtregisteredname.Text = data2.GetValue(16).ToString();
                txtregisteredposition.Text = data2.GetValue(17).ToString();
                txtregistereddate.Text = data2.GetValue(18).ToString();
                txtremarks.Text = data2.GetValue(19).ToString();
            }
            MySqlDataReader data3 = db3.reprint("SELECT * FROM `form97_affidavitofsolemnizingofficer_tbl` WHERE registryno='" + registry + "'");
            if (data3.Read())
            {
                txtsoaddress.Text = data3.GetValue(1).ToString();
                string party = data3.GetValue(2).ToString();
                if (party[0] == 'a')
                {
                    chka.Checked = true;
                }
                else if (party[0] == 'b')
                {
                    chkb.Checked = true;
                }
                else if (party[0] == 'c')
                {
                    chkc.Checked = true;

                    party = party.Substring(party.IndexOf("$") + 1, party.Length - party.IndexOf("$") - 1);
                    label9.Text = party.Substring(0, party.IndexOf("$"));
                    label9.Visible = true;
                    party = party.Substring(party.IndexOf("$") + 1, party.Length - party.IndexOf("$") - 1);
                    label10.Text = party;
                    label10.Visible = true;
                }
                else if (party[0] == 'd')
                {
                    chkd.Checked = true;
                }
                else 
                {
                    chke.Checked = true;
                }
                string date = data3.GetValue(3).ToString();
                label13.Text = date.Substring(0, date.IndexOf("$"));
                date = date.Substring(date.IndexOf("$") + 1, date.Length - date.IndexOf("$") - 1);
                label12.Text = date.Substring(0, date.IndexOf("$"));
                date = date.Substring(date.IndexOf("$") + 1, date.Length - date.IndexOf("$") - 1);
                label11.Text = date;
                string ctc = data3.GetValue(4).ToString();
                if (ctc.Length != 0)
                {
                    text1.Text = ctc.Substring(0, ctc.IndexOf("$"));
                    ctc = ctc.Substring(ctc.IndexOf("$") + 1, ctc.Length - ctc.IndexOf("$") - 1);
                    text2.Text = ctc.Substring(0, ctc.IndexOf("$"));
                    ctc = ctc.Substring(ctc.IndexOf("$") + 1, ctc.Length - ctc.IndexOf("$") - 1);
                    text3.Text = ctc;
                }

            }
            MySqlDataReader data5 = db5.reprint("SELECT * FROM `form97_affidavitofdelayregistration_tbl` WHERE registryno='" + registry + "'");
            if (data5.Read())
            {
                textBox1.Text = data5.GetValue(1).ToString();
                textBox3.Text = data5.GetValue(2).ToString();
                string affi = data5.GetValue(3).ToString();
                if (affi[0] == 'a') {
                    cka.Checked = true;
                    affi = affi.Substring(affi.IndexOf("$") + 1, affi.Length - affi.IndexOf("$") - 1);
                    label23.Text = affi.Substring(0, affi.IndexOf("$"));
                    affi = affi.Substring(affi.IndexOf("$") + 1, affi.Length - affi.IndexOf("$") - 1);
                    label24.Text = affi.Substring(0, affi.IndexOf("$"));
                    affi = affi.Substring(affi.IndexOf("$") + 1, affi.Length - affi.IndexOf("$") - 1);
                    label25.Text = affi;
                    label23.Visible = true;
                    label24.Visible = true;
                    label25.Visible = true;
                }
                else
                if (affi[0] == 'b')
                {
                    ckb.Checked = true;
                    affi = affi.Substring(affi.IndexOf("$") + 1, affi.Length - affi.IndexOf("$") - 1);
                    label26.Text = affi.Substring(0, affi.IndexOf("$"));
                    affi = affi.Substring(affi.IndexOf("$") + 1, affi.Length - affi.IndexOf("$") - 1);
                    label27.Text = affi.Substring(0, affi.IndexOf("$"));
                    affi = affi.Substring(affi.IndexOf("$") + 1, affi.Length - affi.IndexOf("$") - 1);
                    label28.Text = affi.Substring(0, affi.IndexOf("$"));
                    affi = affi.Substring(affi.IndexOf("$") + 1, affi.Length - affi.IndexOf("$") - 1);
                    label29.Text = affi;
                    label26.Visible = true;
                    label27.Visible = true;
                    label28.Visible = true;
                    label29.Visible = true;

                }
                if (data5.GetValue(4).ToString().ToLower().Equals("religious ceremony"))
                        ca.Checked = true;
                else if (data5.GetValue(4).ToString().ToLower().Equals("civil ceremony"))
                        cb.Checked = true;
                else if (data5.GetValue(4).ToString().ToLower().Equals("muslim rites"))
                        cc.Checked = true;
                else if (data5.GetValue(4).ToString().ToLower().Equals("tribal rites"))
                        cc.Checked = true;
                string solem = data5.GetValue(5).ToString();

                if (solem[0] == 'a')
                {
                    checkBox12.Checked = true;
                    solem = solem.Substring(solem.IndexOf("$") + 1, solem.Length - solem.IndexOf("$") - 1);
                    txtml32.Text = affi.Substring(0, affi.IndexOf("$"));
                    solem = solem.Substring(solem.IndexOf("$") + 1, solem.Length - solem.IndexOf("$") - 1);
                    txtmd32.Text = affi.Substring(0, affi.IndexOf("$"));
                    solem = solem.Substring(solem.IndexOf("$") + 1, solem.Length - solem.IndexOf("$") - 1);
                    txtmp32.Text = affi;

                }
                else {

                    checkBox13.Checked = true;
                    solem = solem.Substring(solem.IndexOf("$") + 1, solem.Length - solem.IndexOf("$") - 1);
                    txtart2.Text = affi;
                }

                string citizen = data5.GetValue(6).ToString();
                if (citizen[0] == 'a')
                {
                    citizen = citizen.Substring(citizen.IndexOf("$") + 1, citizen.Length - citizen.IndexOf("$") - 1);
                    txtcth.Text = citizen.Substring(0, citizen.IndexOf("$"));
                    citizen = citizen.Substring(citizen.IndexOf("$") + 1, citizen.Length - citizen.IndexOf("$") - 1);
                    txtctw.Text = citizen;

                }
                else
                {
                    citizen = citizen.Substring(citizen.IndexOf("$") + 1, citizen.Length - citizen.IndexOf("$") - 1);
                    txtcth2.Text = citizen.Substring(0, citizen.IndexOf("$"));
                    citizen = citizen.Substring(citizen.IndexOf("$") + 1, citizen.Length - citizen.IndexOf("$") - 1);
                    txtctw2.Text = citizen;
                }

                textBox4.Text = data5.GetValue(7).ToString();
                string date = data5.GetValue(8).ToString();
                label31.Text = date.Substring(0, date.IndexOf("$"));
                date = date.Substring(date.IndexOf("$") + 1, date.Length - date.IndexOf("$") - 1);
                label32.Text = date.Substring(0, date.IndexOf("$"));
                date = date.Substring(date.IndexOf("$") + 1, date.Length - date.IndexOf("$") - 1);
                label33.Text = date;
                string[] ctc = data5.GetValue(9).ToString().Split('$');

                textBox6.Text = ctc[0];
                textBox7.Text = ctc[1];
                textBox8.Text = ctc[2];
                textBox9.Text = ctc[3];


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
        public MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=lcr_db;");
        public MySqlCommand cmd1;
        MySqlDataReader dr1;
        string id;
        void createRegistryNo()
        {

            conn.Close();
            conn.Open();
            cmd1 = new MySqlCommand("Select * from form97_tbl", conn);
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

        private void Form97_Load(object sender, EventArgs e)
        {
            createRegistryNo();
            visibleFalse();
            setddMMyyyy();
            txtrecievedate.Text = DateTime.Today.ToString("MMMM dd, yyyy");

        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            getChoice();
            if (db.insertmarrriagecertificate(txtregistryno.Text, ( txtpom1.Text + "$" + txtpom2.Text + "$" + txtpom3.Text), txtdom.Text, txtom.Text + (rdam.Checked ? "AM" : "PM"), checkhave.Checked ? "have entered" : "have not entered", lbldd.Text, lblmm.Text, lblyyyy.Text, choice, txtsoname.Text, txtsoposition.Text, txtsoreligion.Text, (txtwitness1.Text + "$" + txtwitness2.Text + "$" + txtwitness3.Text + "$" + txtwitness4.Text + "$" + txtwitness5.Text + "$" + txtwitness6.Text), txtrecievename.Text, txtrecieveposition.Text, txtregistereddate.Text, txtregisteredname.Text, txtregisteredposition.Text, txtregistereddate.Text, txtremarks.Text))
            {
                MessageBox.Show("Saved Successfully.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (db.inserthusband(txtregistryno.Text, txth1.Text, txth2.Text, txth3.Text, txthdob.Text, txthage.Text, txthpob.Text, txthsex.Text, txthcitezenship.Text, txthresidence.Text, txthreligion.Text, txthcs.Text, txthf1.Text, txthf2.Text, txthf3.Text, txthfcit.Text, txthm1.Text, txthm2.Text, txthm3.Text, txthmcit.Text, txthw1.Text, txthw2.Text, txthw3.Text, txthrelationship.Text, txthwresidence.Text))
            {}
            if (db.insertwife(txtregistryno.Text, txtw1.Text, txtw2.Text, txtw3.Text, txtwdob.Text, txtwage.Text, txtwpob.Text, txtwsex.Text, txtwcitizenship.Text, txtwresidence.Text, txtwreligion.Text, txtwcs.Text, txtwf1.Text, txtwf2.Text, txtwf3.Text, txtwfcit.Text, txtwm1.Text, txtwm2.Text, txtwm3.Text, txtwmcit.Text, txtww1.Text, txtww2.Text, txtww3.Text, txtwrelationship.Text, txtwwresidence.Text))
            {}
            getChoice2();
            if (db.insertaso(txtregistryno.Text, txtsoaddress.Text, ans,(lbldd.Text + "$" + lblmm.Text + "$" + lblyyyy.Text), text1.Text + "$" + text2.Text + "$" + text3.Text))
            {}
            getAffiant1();
            getsolimnized();
            if (txtremarks.Text.ToLower().ToString().Equals("late registration"))
            {
                if (db.insertmarriageadr(txtregistryno.Text, textBox1.Text, textBox3.Text, affiant1, under, m, citizenship, textBox4.Text, (lbldd.Text + "$" + lblmm.Text + "$" + lblyyyy.Text ), textBox6.Text + "$" + textBox7.Text + "$" + textBox8.Text + "$" + textBox9.Text))
                {}
            }

        }
        void visibleFalse() 
        {

            label9.Visible = false;
            label10.Visible = false;
            checkc.Checked = true;
                      


        }
        void setddMMyyyy()
        {
            label3.Text = txth1.Text.ToUpper() + " " + txth2.Text.ToUpper() + " " + txth3.Text.ToUpper();
            label4.Text = txtw1.Text.ToUpper() + " " + txtw2.Text.ToUpper() + " " + txtw3.Text.ToUpper();
            DateTime dt = DateTime.Now;
            string d2d = dt.ToString("dd").Substring(1);
            string suffix = (dt.Day == 11 || dt.Day == 12 || dt.Day == 13) ? "th"
           : (d2d == "1") ? "st"
           : (d2d == "2") ? "nd"
           : (d2d == "3") ? "rd"
           : "th";
            lbldd.Text = DateTime.Today.Day.ToString("d") + suffix;
            string theMonth = DateTime.Now.ToString("MMMM");
            lblmm.Text = theMonth;
            lblyyyy.Text = DateTime.Today.Year.ToString();
        }
        private void checka_Click(object sender, EventArgs e)
        {
            choice = "a";
            checkb.Checked = false;
            checkc.Checked = false;
            txtml1.Visible = true;
            txtml2.Visible = true;
            txtml3.Visible = true;
            txtml4.Visible = false;
            checkBox12.Checked = true;
        }
        string choice;
        void getChoice()
        {
            if (checka.Checked)
            {
                choice += "$" +txtml1.Text + "$" + txtml2.Text + "$" + txtml3.Text;
            }
            else if (checkb.Checked)
            {
                choice += "$"+txtml4.Text;
            }
            else {
                choice = "c";
            }
        }
        private void checkb_Click(object sender, EventArgs e)
        {
            choice = "b";
            checka.Checked = false;
            checkc.Checked = false;
            txtml1.Visible = false;
            txtml2.Visible = false;
            txtml3.Visible = false;
            txtml4.Visible = true;
        }

        private void checkc_Click(object sender, EventArgs e)
        {
            choice = "c";
            checka.Checked = false;
            checkb.Checked = false;
            txtml1.Visible = false;
            txtml2.Visible = false;
            txtml3.Visible = false;
            txtml4.Visible = false;


        }

        private void txtdom_ValueChanged(object sender, EventArgs e)
        {
            DateTime dom = txtdom.Value;
            DateTime today = DateTime.Now;



            if (DateTime.Compare(dom.AddYears(1), today) <= 0)
            {
                txtremarks.Text = "Late Registration";
            }
            else {
                txtremarks.Text = "";
            }

        }



        int calculateAge(DateTime a, DateTime b) {
            a = DateTime.Parse(a.ToString("yyyy-MM-dd"));
            b = DateTime.Parse(b.ToString("yyyy-MM-dd"));
            int def = a.Year - b.Year;
            if (DateTime.Compare(b.AddYears(def), a) <= 0)
                return def;
            else
                def--;

            return def;
        }

        private void txthdob_ValueChanged(object sender, EventArgs e)
        {
            int age = calculateAge(txtdom.Value,txthdob.Value);
            txthage.Text = "" + age;
        }

        private void txtwdob_ValueChanged(object sender, EventArgs e)
        {
            int age = calculateAge(txtdom.Value,txtwdob.Value);
            txtwage.Text = "" + age;
        }

       

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label5.Text = txtsoname.Text;
            label6.Text = txtsoreligion.Text;
            label7.Text = txth1.Text + " " + txth2.Text + " " + txth3.Text;
            label8.Text = txtw1.Text + " " + txtw2.Text + " " + txtw3.Text;
            label9.Text = txth1.Text + " " + txth2.Text + " " + txth3.Text;
            label10.Text = txtw1.Text + " " + txtw2.Text + " " + txtw3.Text;
            label13.Text = lbldd.Text;
            label12.Text = lblmm.Text;
            label11.Text = lblyyyy.Text;
            label15.Text = txtsoname.Text;
            label16.Text = lbldd.Text;
            label19.Text = lblmm.Text;
            label18.Text = lblyyyy.Text;
            label20.Text = txtsoname.Text;
            label21.Text = txtsoposition.Text;

            if (registry == null)
            {
            label26.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
            label29.Visible = false;

            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            }
            txtml32.Visible = false;
            txtmd32.Visible = false;
            txtmp32.Visible = false;
            txtart2.Visible = false;

            if (!txtremarks.Text.ToLower().Equals("late registration"))
            {



                label30.Visible = false;
                label31.Visible = false;
                label32.Visible = false;
                label33.Visible = false;
                label34.Visible = false;
                label35.Visible = false;
                label36.Visible = false;
                label38.Visible = false;
                label39.Visible = false;
                label40.Visible = false;
                label41.Visible = false;

                textBox1.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
                textBox9.Visible = false;
                cka.Visible = false;
                ckb.Visible = false;
                ca.Visible = false;
                cb.Visible = false;
                cc.Visible = false;
                cd.Visible = false;

                checkBox12.Visible = false;
                checkBox13.Visible = false;

                txtcth.Visible = false;
                txtctw.Visible = false;
                txtcth2.Visible = false;
                txtctw2.Visible = false;

                label30.Text = txtsoname.Text;
                label31.Text = lbldd.Text;
                label32.Text = lblmm.Text;
                label33.Text = lblyyyy.Text;
                label39.Text = txtregisteredname.Text;
                
                label41.Text = txtregisteredposition.Text;
                
                txtmd32.Text = DateTime.Now.ToString("MM/dd/yyyy");
            }
            else {

                label30.Text = txtsoname.Text;
                txtml32.Text = txtml1.Text;
                txtmd32.Text = txtml2.Text;
                txtmp32.Text = txtml3.Text;
                label31.Text = lbldd.Text;
                label32.Text = lblmm.Text;
                label33.Text = lblyyyy.Text;
                label39.Text = txtregisteredname.Text;
                label41.Text = txtregisteredposition.Text;
                label40.Text = "SULTAN KUDARAT MAGUINDANAO";
                textBox5.Text = "SULTAN KUDARAT MAGUINDANAO";

            }
        }

        string ans;
        void getChoice2()
        {

            if (chka.Checked)
            {
                ans = "a";
            }
            else if (chkb.Checked)
            {
                ans = "b";
            }
            else if (chkc.Checked)
            {
                ans += "$"+label9.Text + "$" + label10.Text;
            }
            else if (chkd.Checked)
            {
                ans = "d";
            }
            else
            {
                ans = "e";
            }
        }
        private void chka_Click(object sender, EventArgs e)
        {
            ans = "a";
            chkb.Checked = false;
            chkc.Checked = false;
            chkd.Checked = false;
            chke.Checked = false; 
            label9.Visible = false;
            label10.Visible = false;
        }

        private void chkb_Click(object sender, EventArgs e)
        {
            ans = "b";
            chka.Checked = false;
            chkc.Checked = false;
            chkd.Checked = false;
            chke.Checked = false;
            label9.Visible = false;
            label10.Visible = false;
        }

        private void chkc_Click(object sender, EventArgs e)
        {
            ans = "c";
            chka.Checked = false;
            chkb.Checked = false;
            chkd.Checked = false;
            chke.Checked = false;
            label9.Visible = true;
            label10.Visible = true;
        }

        private void chkd_Click(object sender, EventArgs e)
        {
            ans = "d";
            chka.Checked = false;
            chkb.Checked = false;
            chkc.Checked = false;
            chke.Checked = false;
            label9.Visible = false;
            label10.Visible = false;
        }

        private void chke_Click(object sender, EventArgs e)
        {
            ans = "e";
            chka.Checked = false;
            chkb.Checked = false;
            chkc.Checked = false;
            chkd.Checked = false;
            label9.Visible = false;
            label10.Visible = false;
        }
        string affiant1;
        string citizenship;
        void getAffiant1()
        {
            if (cka.Checked)
            {
                affiant1 += "$" + label23.Text + "$" + label24.Text + "$" + label25.Text;
                citizenship += "$" + txtcth.Text + "$" + txtctw.Text;
                
            }
            else
            {
                affiant1 += "$" + label26.Text + "$" + label27.Text + "$" + label28.Text + "$" + label29.Text;
                citizenship += "$" + txtcth2.Text + "$" + txtctw2.Text;
            }
        }
        
        private void cka_Click(object sender, EventArgs e)
        {
            affiant1 = "a";
            citizenship = "a";
            label23.Visible = true;
            label24.Visible = true;
            label25.Visible = true;
            txtcth.Visible = true;
            txtctw.Visible = true;
            label37.Visible = true;

            ckb.Checked = false;
            label23.Text = txth1.Text + " " + txth2.Text + " " + txth3.Text;
            label24.Text = txtpom2.Text + " " + txtpom3.Text;
            label25.Text = txtdom.Text;
            label37.Text = textBox1.Text;

            label26.Visible = false;
            label27.Visible = false;
            label28.Visible = false;
            label29.Visible = false;
            txtcth2.Visible = false;
            txtctw2.Visible = false;

        }

        private void ckb_Click(object sender, EventArgs e)
        {
            affiant1 = "b";
            citizenship = "b";
            label26.Visible = true;
            label27.Visible = true;
            label28.Visible = true;
            label29.Visible = true;
            txtcth2.Visible = true;
            txtctw2.Visible = true;
            label37.Visible = true;

            cka.Checked = false;
            label26.Text = txth1.Text + " " + txth2.Text + " " + txth3.Text;
            label27.Text = txtw1.Text + " " + txtw2.Text + " " + txtw3.Text;
            label28.Text = txtpom2.Text + " " + txtpom3.Text;
            label29.Text = txtdom.Text;
            label37.Text = textBox1.Text;

            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            txtcth.Visible = false;
            txtctw.Visible = false;
        }

        string under;
        private void ca_Click(object sender, EventArgs e)
        {
            under = "religious ceremony";
            cb.Checked = false;
            cc.Checked = false;
            cd.Checked = false;
        }
        
        private void cb_Click(object sender, EventArgs e)
        {
            under = "civil ceremony";
            ca.Checked = false;
            cc.Checked = false;
            cd.Checked = false;
        }

        private void cc_Click(object sender, EventArgs e)
        {
            under = "muslim rites";
            ca.Checked = false;
            cb.Checked = false;
            cd.Checked = false;
        }

        private void cd_Click(object sender, EventArgs e)
        {
            under = "tribal rites";
            ca.Checked = false;
            cb.Checked = false;
            cc.Checked = false;
        }
        string m;
        void getsolimnized()
        {
            if (checkBox12.Checked)
            {
                m += "$" + txtml32.Text + "$" + txtmd32.Text + "$" + txtmp32.Text;
            }
            else
            {
                m += "$" + txtart2.Text;
            }
        }
        private void checkBox12_Click(object sender, EventArgs e)
        {
            m = "a";
            checkBox13.Checked = false;
            txtml32.Visible = true;
            txtmd32.Visible = true;
            txtmp32.Visible = true;
            txtart2.Visible = false;

        }

        private void checkBox13_Click(object sender, EventArgs e)
        {
            m = "b";
            checkBox12.Checked = false;
            txtml32.Visible = false;
            txtmd32.Visible = false;
            txtmp32.Visible = false;
            txtart2.Visible = true;
        }

        private void additional_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void checkc_CheckedChanged(object sender, EventArgs e)
        {

            choice = "c";
            checka.Checked = false;
            checkb.Checked = false;
            txtml1.Visible = false;
            txtml2.Visible = false;
            txtml3.Visible = false;
            txtml4.Visible = false;
        }

        private void page1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }
        void clear()
        {
            txth1.Text = "";
            txth2.Text = "";
            txth3.Text = "";
            txthdob.Text = "";
            txthage.Text = "";
            txthpob.Text = DateTime.Now.ToString("dd MMMM, yyyy");
            txthsex.Text = "";
            txthcitezenship.Text = "";
            txthresidence.Text = "";
            txthreligion.Text = ""; 
            txthcs.Text = "";
            txthf1.Text = "";
            txthf2.Text = "";
            txthf3.Text = ""; 
            txthfcit.Text = ""; 
            txthm1.Text = "";
            txthm2.Text = "";
            txthm3.Text = "";
            txthmcit.Text = "";
            txthw1.Text = "";
            txthw2.Text = ""; 
            txthw3.Text = ""; 
            txthrelationship.Text = "";
            txthwresidence.Text = "";
            txtw1.Text = "";
            txtw2.Text = "";
            txtw3.Text = "";
            txtwdob.Text = DateTime.Now.ToString("dd MMMM, yyyy");
            txtwage.Text = "";
            txtwpob.Text = "";
            txtwsex.Text = "";
            txtwcitizenship.Text = "";
            txtwresidence.Text = "";
            txtwreligion.Text = "";
            txtwcs.Text = "";
            txtwf1.Text = "";
            txtwf2.Text = "";
            txtwf3.Text = "";
            txtwfcit.Text = "";
            txtwm1.Text = "";
            txtwm2.Text = "";
            txtwm3.Text = "";
            txtwmcit.Text = "";
            txtww1.Text = "";
            txtww2.Text = ""; 
            txtww3.Text = ""; 
            txtwrelationship.Text = ""; 
            txtwwresidence.Text = "";
            txtpom1.Text = ""; 
            txtpom2.Text = "";
            txtpom3.Text = "";
            txtdom.Text = DateTime.Now.ToString("dd MMMM, yyyy");
            txtom.Text = "";
            rdam.Checked = false;
            rdpm.Checked = false;
            label3.Text = "";
            label4.Text = "";
            lbldd.Text = "";
            lblmm.Text = "";
            lblyyyy.Text = "";
            txtml1.Text = "";
            txtml2.Text = "";
            txtml3.Text = "";
            txtml4.Text = "";
            txtsoname.Text = "";
            txtsoposition.Text = "";
            txtsoreligion.Text = "";
            txtwitness1.Text = "";
            txtwitness2.Text = "";
            txtrecievename.Text = "";
            txtrecieveposition.Text = "";
            txtrecievedate.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txtregisteredname.Text = "";
            txtregisteredposition.Text = "";
            txtregistereddate.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txtremarks.Text = "";
            checkhave.Checked = false;
            checkhavenot.Checked = false;
            checka.Checked = false;
            checkb.Checked = false;
            checkc.Checked = false;
            txtwitness3.Text = "";
            txtwitness4.Text = "";
            txtwitness5.Text = "";
            txtwitness6.Text = "";
            label5.Text = "";
            label6.Text = "";
            txtsoaddress.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            label13.Text = "";
            label14.Text = "";
            label15.Text = "";
            label16.Text = "";
            label19.Text = "";
            label18.Text = "";
            label17.Text = "";
            text1.Text = "";
            text2.Text = "";
            text2.Text = "";
            text3.Text = "";
            label20.Text = "";
            label21.Text = "";
            label22.Text = "";
            ///
            textBox1.Text = "";
            textBox3.Text = "";
            label23.Text = "";
            label24.Text = "";
            label25.Text = "";
            label26.Text = "";
            label27.Text = "";
            label28.Text = "";
            label29.Text = "";
            label30.Text = "";
            txtml32.Text = "";
            txtmd32.Text = "";
            txtmp32.Text = "";
            txtart2.Text = "";
            txtcth.Text = "";
            txtctw.Text = "";
            txtcth2.Text = "";
            txtctw2.Text = "";
            textBox4.Text = "";
            label31.Text = "";
            label32.Text = "";
            label33.Text = "";
            textBox5.Text = "";
            label37.Text = "";
            label34.Text = "";
            label35.Text = "";
            label36.Text = "";
            label38.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            label39.Text = "";
            label41.Text = "";
            label40.Text = "";
            chka.Checked = false;
            chkb.Checked = false;
            chkc.Checked = false;
            chkd.Checked = false;
            chke.Checked = false;
            ///
            cka.Checked = false;
            ckb.Checked = false;
            ca.Checked = false;
            cb.Checked = false;
            cc.Checked = false;
            cd.Checked = false;


            checkBox12.Checked = false;
            checkBox13.Checked = false;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string[] data = {
                txtregistryno.Text,
                //husband info
                txth1.Text, txth2.Text, txth3.Text, txthdob.Text, txthage.Text, txthpob.Text, txthsex.Text, txthcitezenship.Text, txthresidence.Text, txthreligion.Text, txthcs.Text, txthf1.Text, txthf2.Text, txthf3.Text, txthfcit.Text, txthm1.Text, txthm2.Text, txthm3.Text, txthmcit.Text, txthw1.Text, txthw2.Text, txthw3.Text, txthrelationship.Text, txthwresidence.Text,
                //wife info
                txtw1.Text, txtw2.Text, txtw3.Text, txtwdob.Text, txtwage.Text, txtwpob.Text, txtwsex.Text, txtwcitizenship.Text, txtwresidence.Text, txtwreligion.Text, txtwcs.Text, txtwf1.Text, txtwf2.Text, txtwf3.Text, txtwfcit.Text, txtwm1.Text, txtwm2.Text, txtwm3.Text, txtwmcit.Text, txtww1.Text, txtww2.Text, txtww3.Text, txtwrelationship.Text, txtwwresidence.Text,
                //additional
                txtpom1.Text + " " + txtpom2.Text + " " + txtpom3.Text,
                txtdom.Text, 
                txtom.Text + " " + (rdam.Checked ? "am":"pm"),
                label3.Text,
                label4.Text,
                lbldd.Text,
                lblmm.Text,
                lblyyyy.Text,
                txtml1.Text,
                txtml2.Text,
                txtml3.Text,
                txtml4.Text,
                txtsoname.Text,
                txtsoposition.Text,
                txtsoreligion.Text,
                txtwitness1.Text,
                txtwitness2.Text,
                txtrecievename.Text,
                txtrecieveposition.Text,
                txtrecievedate.Text,
                txtregisteredname.Text,
                txtregisteredposition.Text,
                txtregistereddate.Text,
                txtremarks.Text
                
                

            };
            string[] x = {

                checkhave.Checked?"X":" ",
                checkhavenot.Checked?"X":" ",
                checka.Checked?"X":" ",
                checkb.Checked?"X":" ",
                checkc.Checked?"X":" ",



            };

            Previewer frm = new Previewer(data,x,"Form97page1");
            frm.Show();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string[] data = {
                txtwitness3.Text,
                txtwitness4.Text,
                txtwitness5.Text,
                txtwitness6.Text,
                label5.Text,
                label6.Text,
                txtsoaddress.Text,
                label7.Text,
                label8.Text,
                label9.Text,
                label10.Text,
                label11.Text,
                label12.Text,
                label13.Text,
                label14.Text,
                label15.Text,
                label16.Text,
                label19.Text,
                label18.Text,
                label17.Text,
                text1.Text,
                text2.Text.Substring(0,5),
                text2.Text.Substring(6,4),
                text3.Text,
                label20.Text,
                label21.Text,
                label22.Text,
                ///
                textBox1.Text,
                textBox3.Text,
                label23.Text,
                label24.Text,
                label25.Text,
                label26.Text,
                label27.Text,
                label28.Text,
                label29.Text,
                label30.Text,
                txtml32.Text,
                txtmd32.Text,
                txtmp32.Text,
                txtart2.Text,
                txtcth.Text,
                txtctw.Text,
                txtcth2.Text,
                txtctw2.Text,
                textBox4.Text,
                label31.Text,
                label32.Text,
                label33.Text,
                textBox5.Text,
                label37.Text,
                label34.Text,
                label35.Text,
                label36.Text,
                label38.Text,
                textBox6.Text,
                textBox7.Text,
                textBox8.Text,
                textBox9.Text,
                label39.Text,
                label41.Text,
                label40.Text

            };
            string[] x = {
                chka.Checked ? "X":"",
                chkb.Checked ? "X":"",
                chkc.Checked ? "X":"",
                chkd.Checked ? "X":"",
                chke.Checked ? "X":"",
                ///
                cka.Checked ? "X":"",
                ckb.Checked ? "X":"",
                ca.Checked ? "X":"",
                cb.Checked ? "X":"",
                cc.Checked ? "X":"",
                cd.Checked ? "X":"",

                checkBox12.Checked ? "X":"",
                checkBox13.Checked ? "X":"",
            };




            Previewer frm = new Previewer(data, x, "Form97page2");
            frm.Show();
            clear();
            this.Close();

        }


        private void txtom_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (txtom.Text.Length == 2)
            {
                if (e.KeyValue == Convert.ToChar(Keys.Back))
                {
                    txtom.Text = txtom.Text.Substring(0,1);
                    txtom.SelectionStart = 1;
                    return;
                }
                txtom.Text = txtom.Text + ":";
                txtom.SelectionStart = 3;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void text2_KeyUp_1(object sender, KeyEventArgs e)
        {


            if (text2.Text.Length == 2)
            {
                if (e.KeyValue == Convert.ToChar(Keys.Back))
                {
                    text2.Text = text2.Text.Substring(0, 1);
                    text2.SelectionStart = 1;
                    return;
                }
                text2.Text = text2.Text + "/";
                text2.SelectionStart = 3;
            }
            if (text2.Text.Length == 5)
            {
                if (e.KeyValue == Convert.ToChar(Keys.Back))
                {
                    text2.Text = text2.Text.Substring(0, 4);
                    text2.SelectionStart = 4;
                    return;
                }
                text2.Text = text2.Text + "/";
                text2.SelectionStart = 6;
            }
        }

        private void textBox7_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox7.Text.Length == 2)
            {
                if (e.KeyValue == Convert.ToChar(Keys.Back))
                {
                    textBox7.Text = textBox7.Text.Substring(0, 1);
                    textBox7.SelectionStart = 1;
                    return;
                }
                textBox7.Text = textBox7.Text + ":";
                textBox7.SelectionStart = 3;
            }
        }

        private void txth1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (Keys)e.KeyChar == Keys.Space);
            if (txth1.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void txth1_TextChanged(object sender, EventArgs e)
        {
            label3.Text = txth1.Text + " " + txth2.Text + " " + txth3.Text;
        }

        private void txtw1_TextChanged(object sender, EventArgs e)
        {
            label4.Text = txtw1.Text + " " + txtw2.Text + " " + txtw3.Text;
        }

        private void txthwresidence_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (Keys)e.KeyChar == Keys.Space || char.IsDigit(e.KeyChar));
            if (txthwresidence.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void txtml2_KeyUp(object sender, KeyEventArgs e)
        {

            if (txtml2.Text.Length == 2)
            {
                if (e.KeyValue == Convert.ToChar(Keys.Back))
                {
                    txtml2.Text = txtml2.Text.Substring(0, 1);
                    txtml2.SelectionStart = 1;
                    return;
                }
                txtml2.Text = txtml2.Text + "/";
                txtml2.SelectionStart = 3;
            }
            if (txtml2.Text.Length == 5)
            {
                if (e.KeyValue == Convert.ToChar(Keys.Back))
                {
                    txtml2.Text = txtml2.Text.Substring(0, 4);
                    txtml2.SelectionStart = 4;
                    return;
                }
                txtml2.Text = txtml2.Text + "/";
                txtml2.SelectionStart = 6;
            }
        }
    }
    
}
