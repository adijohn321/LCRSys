using DateTimeToStringWithSuffix;
using MySql.Data.MySqlClient;
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
    public partial class Form102 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=lcr_db;");
        Database db = new Database();
        Database db1 = new Database();
        Database db2 = new Database();
        Database db3 = new Database();
        MySqlConnection con = new Database().getConnection();
        string attendant = null;
        public Form102()
        {
            InitializeComponent();
            load();
        }

        public Form102(string registry)
        {
            this.registry = registry;
            InitializeComponent();
            setdata();
            button2.Visible = false;
        }
        void setdata() {
            MySqlDataReader data =  db.reprint("SELECT * FROM `form102_tbl` WHERE registryno='"+registry+"'");
            if (data.Read()) {
                txtregistryno.Text = data.GetValue(0).ToString();
                txt1first.Text = data.GetValue(1).ToString();
                txt1middle.Text = data.GetValue(2).ToString();
                txt1last.Text = data.GetValue(3).ToString();
                if (data.GetValue(4).ToString().Equals("Male"))
                    txtMale.Checked = true;
                else
                    txtFemale.Checked = true;
                txt3dob.Value = DateTime.Parse( parser(data.GetValue(5).ToString()));
                txt4barangay.Text = data.GetValue(6).ToString();
                txt4citymun.Text = data.GetValue(7).ToString();
                txt4province.Text = data.GetValue(8).ToString();
                txt5a.Text = data.GetValue(9).ToString();
                txt5b.Text = data.GetValue(10).ToString();
                txt5c.Text = data.GetValue(11).ToString();
                txt6.Text = data.GetValue(12).ToString();
                txt7first.Text = data.GetValue(13).ToString();
                txt7middle.Text = data.GetValue(14).ToString();
                txt7last.Text = data.GetValue(15).ToString();
                txt8.Text = data.GetValue(16).ToString();
                txt9.Text = data.GetValue(17).ToString();
                txt10a.Text = data.GetValue(18).ToString();
                txt10b.Text = data.GetValue(19).ToString();
                txt10c.Text = data.GetValue(20).ToString();
                txt11.Text = data.GetValue(21).ToString();
                txt12.Text = data.GetValue(22).ToString();
                txt13barangay.Text = data.GetValue(23).ToString();
                txt13citymun.Text = data.GetValue(24).ToString();
                txt13province.Text = data.GetValue(25).ToString();
                txt13country.Text = data.GetValue(26).ToString();
                txt14first.Text = data.GetValue(27).ToString();
                txt14middle.Text = data.GetValue(28).ToString();
                txt14last.Text = data.GetValue(29).ToString();
                txt15.Text = data.GetValue(30).ToString();
                txt16.Text = data.GetValue(31).ToString();
                txt17.Text = data.GetValue(32).ToString();
                txt18.Text = data.GetValue(33).ToString();
                txt19barangay.Text = data.GetValue(34).ToString();
                txt19citymun.Text = data.GetValue(35).ToString();
                txt19province.Text = data.GetValue(36).ToString();
                txt19country.Text = data.GetValue(37).ToString();
                if(!data.GetValue(38).ToString().ToLower().Equals("not married")&& !data.GetValue(38).ToString().ToLower().Equals("n/a"))
                    txt20a.Value = DateTime.Parse(parser(data.GetValue(38).ToString()));
                string address = data.GetValue(39).ToString();
                if (address.ToLower().Trim().Equals("not married"))
                {
                    checknotmarried.Checked = true;
                }
                else if (address.ToLower().Trim().Equals("n/a"))
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    txt20bcitymun.Text = address.Substring(0, address.IndexOf("$"));
                    address = address.Substring(address.IndexOf("$") + 1, address.Length - address.IndexOf("$") - 1);
                    txt20bProvince.Text = address.Substring(0, address.IndexOf("$"));
                    address = address.Substring(address.IndexOf("$") + 1, address.Length - address.IndexOf("$") - 1);
                    txt20bcountry.Text = address;

                }
                string att = data.GetValue(40).ToString();
                if (att.Equals("Physician"))
                    txt21a1.Checked = true;
                else if (att.Equals("Nurse"))
                    txt21a2.Checked = true;
                else if (att.Equals("Midwife"))
                    txt21a3.Checked = true;
                else if (att.Equals("Hilot"))
                    txt21a4.Checked = true;
                else
                {
                    txt21a5.Checked = true;
                    txt21aspecify.Text = att;
                }
                txt21btime.Text = data.GetValue(41).ToString().Substring(0,5);
                if (data.GetValue(41).ToString().Substring(5, 2).Equals("AM"))
                {
                    rdam.Checked = true;
                }
                else {
                    rdpm.Checked = true;
                }
                txt21bname.Text = data.GetValue(42).ToString();
                txt21bposition.Text = data.GetValue(43).ToString();
                txt21baddress.Text = data.GetValue(44).ToString();
                txt21bdate.Text = data.GetValue(45).ToString();
                txt22name.Text = data.GetValue(46).ToString();
                txt22relationship.Text = data.GetValue(47).ToString();
                txt22address.Text = data.GetValue(48).ToString();
                txt22date.Text = data.GetValue(49).ToString();

            }
            MySqlDataReader data1 = db1.reprint("SELECT * FROM `form102_conti_tbl` WHERE registryno='" + registry + "'");
            if (data1.Read())
            {
                string preparedby   = data1.GetValue(1).ToString();
                txt23name.Text = preparedby.Substring(0, preparedby.IndexOf("$"));
                preparedby = preparedby.Substring(preparedby.IndexOf("$") + 1, preparedby.Length - preparedby.IndexOf("$") - 1);
                txt23position.Text = preparedby.Substring(0, preparedby.IndexOf("$"));
                preparedby = preparedby.Substring(preparedby.IndexOf("$") + 1, preparedby.Length - preparedby.IndexOf("$") - 1);
                txt23date.Text = preparedby;

                string recievedby = data1.GetValue(2).ToString();
                txt24name.Text = recievedby.Substring(0, recievedby.IndexOf("$"));
                recievedby = recievedby.Substring(recievedby.IndexOf("$") + 1, recievedby.Length - recievedby.IndexOf("$") - 1);
                txt24position.Text = recievedby.Substring(0, recievedby.IndexOf("$"));
                recievedby = recievedby.Substring(recievedby.IndexOf("$") + 1, recievedby.Length - recievedby.IndexOf("$") - 1);
                txt24date.Text = recievedby;

                string registeredby = data1.GetValue(3).ToString();
                txt25name.Text = registeredby.Substring(0, registeredby.IndexOf("$"));
                registeredby = registeredby.Substring(registeredby.IndexOf("$") + 1, registeredby.Length - registeredby.IndexOf("$") - 1);
                txt25position.Text = registeredby.Substring(0, registeredby.IndexOf("$"));
                registeredby = registeredby.Substring(registeredby.IndexOf("$") + 1, registeredby.Length - registeredby.IndexOf("$") - 1);
                txt25date.Text = registeredby;

                txtremarks.Text = data1.GetValue(4).ToString();
            }
            MySqlDataReader data2 = db2.reprint("SELECT * FROM `form102_affi1_tbl` WHERE registryno='" + registry + "'");
            if (data2.Read())
            {
                txt08.Text = data2.GetValue(1).ToString();
                txt09.Text = data2.GetValue(2).ToString();
                txt10.Text = data2.GetValue(3).ToString();
                txt011.Text = data2.GetValue(4).ToString();
                txt012.Text = data2.GetValue(5).ToString();
            }
            MySqlDataReader data3 = db3.reprint("SELECT * FROM `form102_affi2_tbl` WHERE registryno='" + registry + "'");
            if (data3.Read())
            {
                string a = data3.GetValue(1).ToString();
                if (a.Equals("the birth"))
                {
                    check2.Checked = true;
                    lbl5.Text = txt1first.Text.ToUpper() + " " + txt1middle.Text.ToUpper() + " " + txt1last.Text.ToUpper();
                    lbl6.Text = txt4barangay.Text + " " + txt4citymun.Text + " " + txt4province.Text;
                    lbl7.Text = txt3dob.Value.ToString("dd MMMM, yyyy");

                }
                else 
                {
                    check1.Checked = true;
                    lbl3.Text = txt4barangay.Text + " " + txt4citymun.Text + " " + txt4province.Text;
                    lbl4.Text = txt3dob.Text;
                }
                string b = data3.GetValue(2).ToString();
                if (b.Equals("married"))
                {
                    check3.Checked = true;
                    lbl11.Text = txt20a.Value.ToString("dd MMMM, yyyy");
                    lbl12.Text = txt20bcitymun.Text + " " + txt20bProvince.Text + " " + txt20bcountry.Text;
                    
                }
                else
                {
                    check4.Checked = true;
                    lbl13.Text = txt14first.Text + " " + txt14middle.Text + " " + txt14last.Text;
                }
                lbl14.Text = data3.GetValue(3).ToString();
                lbl15marriedto.Text = data3.GetValue(4).ToString();
                lbl17.Text = data3.GetValue(5).ToString();
                lbl18.Text = data3.GetValue(6).ToString();
                lbl19.Text = data3.GetValue(7).ToString();
                lbl21.Text = data3.GetValue(8).ToString();
                lbl22.Text = data3.GetValue(9).ToString();
                lbl23.Text = data3.GetValue(10).ToString();
                lbl24.Text = data3.GetValue(11).ToString();
                lbl25.Text = data3.GetValue(12).ToString();
                lbl26.Text = data3.GetValue(13).ToString();
                lbl27.Text = data3.GetValue(14).ToString();
                lbl28.Text = data3.GetValue(15).ToString();
                lbl29.Text = data3.GetValue(16).ToString();
                lbl30.Text = data3.GetValue(17).ToString();
                    
            }
        }
        string parser(string load) {
            string ret = "";
            string day = load.Substring(0,2);
            string year = load.Substring(load.Length - 4, 4);
            load = load.Substring(2, load.Length - 8);
            switch (load.Trim()) {
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
            return day+"/"+ret+"/"+year;
        }
        string registry;

        private void load()
        {
            txt3dob.MinDate = DateTime.Now.AddYears(-100);
            txt3dob.MaxDate = DateTime.Now;
            txt21bdate.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txt22date.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txt23date.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txt24date.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txt25date.Text = DateTime.Today.AddDays(2).ToString("MMMM dd, yyyy");
            txt21aspecify.Enabled = false;
            createRegistryNo();
            affi2();
            affidavit3False();

        }
        public bool validateEntry(string firstname, string middlename, string lastname)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from form102_tbl where firstname='" + firstname + "' and middlename='" + middlename + "' and lastname='" + lastname + "'";
                cmd.ExecuteNonQuery();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {
                    connection.Close();
                    return false;
                }
                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }
        void clear()
        {
            txt1first.Text = "";
            txt1middle.Text = "";
            txt1last.Text = "";
            txtMale.Checked = false;
            txtFemale.Checked = false;
            txt3dob.Text = DateTime.Now.ToString("dd MMMM, yyyy");
            txt4barangay.Text = "";
            txt4citymun.Text = "";
            txtprovince.Text = "";
            txt5a.Text = "";
            check5b.Checked = false;
            txt5b.Text = "";
            txt5c.Text = "";
            txt6.Text = "";
            txt7first.Text = "";
            txt7middle.Text = "";
            txt7last.Text = "";
            txt8.Text = "";
            txt9.Text = "";
            txt10a.Text = "";
            txt10b.Text = "";
            txt10c.Text = "";
            txt11.Text = "";
            txt12.Text = "";
            txt13barangay.Text = "";
            txt13citymun.Text = "";
            txt13province.Text= "";
            txt13country.Text = "";
            checkBox1.Checked = false;
            txt14first.Text = "";
            txt14middle.Text = "";
            txt14last.Text = "";
            txt15.Text = "";
            txt16.Text = "";
            txt17.Text = "";
            txt18.Text = "";
            txt19barangay.Text = "";
            txt19citymun.Text = "";
            txt19province.Text = "";
            txt19country.Text = "";
            checknotmarried.Checked = false;
            txtnotmarried1.Text = "";
            txtnotmarried2.Text = "";
            txt20a.Text = DateTime.Now.ToString("dd MMMM, yyyy");
            txt20bcitymun.Text = "";
            txt20bProvince.Text = "";
            txt20bcountry.Text = "";
            txt21a1.Checked = false;
            txt21a2.Checked = false;
            txt21a3.Checked = false;
            txt21a4.Checked = false;
            txt21a5.Checked = false;
            txt21aspecify.Text = "";
            txt21bdate.Text = "";
            rdam.Checked = false;
            rdpm.Checked = false;
            txt21bname.Text = "";
            txt21bposition.Text = "";
            txt21bdate.Text = "";
            txt22name.Text = "";
            txt22relationship.Text = "";
            txt22address.Text = "";
            txt21bdate.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txt22date.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txt23date.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txt24date.Text = DateTime.Today.ToString("MMMM dd, yyyy");
            txt25date.Text = DateTime.Today.AddDays(2).ToString("MMMM dd, yyyy");
            txtremarks.Text = "";
            createRegistryNo();
        } 
        private void button2_Click(object sender, EventArgs e)
        {
            if (!(txt1first.Text == "" || txt1last.Text == "" || txt3dob.Text == "" || txt4citymun.Text == "" || txt4province.Text == "" || txt5a.Text == "" || txt5b.Text == "" || txt5c.Text == "" || txt6.Text == ""|| txt7first.Text == ""|| txt7last.Text == ""|| txt8.Text == ""|| txt9.Text == ""|| txt10a.Text == ""|| txt10b.Text == ""|| txt10c.Text == ""|| txt11.Text == ""|| txt12.Text == ""|| txt13citymun.Text == ""|| txt13province.Text == ""|| txt13country.Text == ""|| txt14first.Text == ""|| txt14last.Text == ""||txt15.Text == ""|| txt16.Text == ""|| txt17.Text == ""|| txt18.Text == ""|| txt19citymun.Text == ""|| txt19province.Text == ""|| txt19country.Text == ""|| txt21bname.Text == ""|| txt21bposition.Text == "" || txt22name.Text == "" || txt22relationship.Text == "" || txt22address.Text == "" || txt22date.Text == "" || txt23name.Text == "" || txt23position.Text == "" || txt23date.Text == "" || txt24name.Text == "" || txt24position.Text == "" || txt24date.Text == "" || txt25name.Text == "" || txt25position.Text == "" || txt25date.Text == ""))
            {
                if (validateEntry(txt1first.Text, txt1middle.Text, txt1last.Text))
                {
                    MessageBox.Show("System detect data duplication.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   
                    return;
                }
                if (db.insertchild(txtregistryno.Text, txt1first.Text, txt1middle.Text, txt1last.Text, txtMale.Checked ? "Male" : "Female", txt3dob.Text, txt4barangay.Text, txt4citymun.Text, txt4province.Text, txt5a.Text, txt5b.Text, txt5c.Text, txt6.Text, txt7first.Text, txt7middle.Text, txt7last.Text, txt8.Text, txt9.Text, txt10a.Text, txt10b.Text, txt10c.Text, txt11.Text, txt12.Text, txt13barangay.Text, txt13citymun.Text, txt13province.Text, txt13country.Text, txt14first.Text, txt14middle.Text, txt14last.Text, txt15.Text, txt16.Text, txt17.Text, txt18.Text, txt19barangay.Text, txt19citymun.Text, txt19province.Text, txt19country.Text, checknotmarried.Checked ? "Not Married" : (checkBox1.Checked?"N/A":txt20a.Text), checknotmarried.Checked ? "Not Married" : (checkBox1.Checked ? "N/A" : (txt20bcitymun.Text + "$" + txt20bProvince.Text + "$" + txt20bcountry.Text)), getAttendant(), txt21btime.Text + (rdam.Checked ? "AM" : "PM"), txt21bname.Text, txt21bposition.Text, txt21baddress.Text, txt21bdate.Text, txt22name.Text, txt22relationship.Text, txt22address.Text, txt22date.Text))
                {
                    MessageBox.Show("Saved Successfully.", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                if (db.insertchildcontinue(txtregistryno.Text, (txt23name.Text + "$" + txt23position.Text + "$" + txt23date.Text), (txt24name.Text + "$" + txt24position.Text + "$" + txt24date.Text), (txt25name.Text + "$" + txt25position.Text + "$" + txt25date.Text), txtremarks.Text))
                {
                   
                }
            }
            else
            {
                MessageBox.Show("Please fill all required fields", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            if (txtremarks.Text.ToLower().Equals("late registration"))
            {
                if (db.insertaffi2(check1.Checked ? "my birth" : "the birth", check3.Checked ? "married" : "notmarried", lbl14.Text, lbl15marriedto.Text, lbl17.Text, lbl18.Text, lbl19.Text, lbl21.Text, lbl22.Text, lbl23.Text, lbl24.Text, lbl25.Text, lbl26.Text, lbl27.Text, lbl28.Text, lbl29.Text, lbl30.Text, txtregistryno.Text))
                {
                }
            }

            if (checknotmarried.Checked)
            {
                if (db.insertaffi1(txt08.Text, txt09.Text, txt10.Text, txt13.Text, txt014.Text, txt015.Text, txt016.Text, txt017.Text, txt018.Text, txtregistryno.Text))
                {
                }
            }
            

        }

        private void txtMale_CheckedChanged(object sender, EventArgs e)
        {
            txtMale.Checked = !txtFemale.Checked;
        }

        private void txtFemale_CheckedChanged(object sender, EventArgs e)
        {
            txtFemale.Checked = !txtMale.Checked;
        }

       
        public MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=lcr_db;");
        public MySqlCommand cmd1;
        MySqlDataReader dr1;
        string id;
        void createRegistryNo()
        {

            conn.Close();
            conn.Open();
            cmd1 = new MySqlCommand("Select * from form102_tbl", conn);
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
        private void txt21a1_Click(object sender, EventArgs e)
        {
            attendant = "Physician";
            txt21aspecify.Text = "";
            txt21a2.Checked = false;
            txt21a3.Checked = false;
            txt21a4.Checked = false;
            txt21a5.Checked = false;
        }

        private void txt21a2_Click(object sender, EventArgs e)
        {
            attendant = "Nurse";
            txt21aspecify.Text = "";
            txt21a1.Checked = false;
            txt21a3.Checked = false;
            txt21a4.Checked = false;
            txt21a5.Checked = false;
        }

        private void txt21a3_Click(object sender, EventArgs e)
        {
            attendant = "Midwife";
            txt21aspecify.Text = "";
            txt21a2.Checked = false;
            txt21a1.Checked = false;
            txt21a4.Checked = false;
            txt21a5.Checked = false;
        }

        private void txt21a4_Click(object sender, EventArgs e)
        {
            attendant = "Hilot";
            txt21aspecify.Text = "";
            txt21a2.Checked = false;
            txt21a3.Checked = false;
            txt21a1.Checked = false;
            txt21a5.Checked = false;
        }

        private void txt21a5_Click(object sender, EventArgs e)
        {
            txt21a2.Checked = false;
            txt21a3.Checked = false;
            txt21a4.Checked = false;
            txt21a1.Checked = false;
        }
        string getAttendant() {
            if (txt21a5.Checked)
                attendant = "Others - "+txt21aspecify.Text;
            return attendant;
        }

        private void checknotmarried_CheckStateChanged(object sender, EventArgs e)
        {
            if (checknotmarried.Checked == true)
            {
                txt20a.Visible = false;
                txt20bcitymun.Visible = false;
                txt20bProvince.Visible = false;
                txt20bcountry.Visible = false;
                txtnotmarried1.Text = "NOT MARRIED";
                txtnotmarried2.Text = "NOT MARRIED";
                
                //PAGE2
                affi1();
                txt1.Text = txt14first.Text.ToUpper() + " "+txt14middle.Text.ToUpper() + " "+txt14last.Text.ToUpper();
                txt2.Text = txt7first.Text.ToUpper() + " "+txt7middle.Text.ToUpper() + " " + txt7last.Text.ToUpper();
                txt3.Text = txt1first.Text.ToUpper() + " "+txt1middle.Text.ToUpper() + " " + txt1last.Text.ToUpper();
                txt4.Text = txt3dob.Text;
                txt5.Text = txt4barangay.Text + " " + txt4citymun.Text + " " + txt4province.Text;
                txt06.Text = txt14first.Text.ToUpper() + " " + txt14middle.Text.ToUpper() + " " + txt14last.Text.ToUpper();
                txt07.Text = txt7first.Text.ToUpper() + " " + txt7middle.Text.ToUpper() + " " + txt7last.Text.ToUpper();
                DateTime dt = DateTime.Now;
                string d2d = dt.ToString("dd").Substring(1);
                string suffix =(dt.Day == 11 || dt.Day == 12 || dt.Day == 13) ? "th"
               : (d2d == "1") ? "st"
               : (d2d == "2") ? "nd"
               : (d2d == "3") ? "rd"
               : "th";
                txt08.Text = DateTime.Today.Day.ToString("d") + suffix;
                string theMonth = DateTime.Now.ToString("MMMM");
                txt09.Text = theMonth;
                txt10.Text = DateTime.Today.Year.ToString();
                txt011.Text = txt14first.Text.ToUpper() + " " + txt14middle.Text.ToUpper() + " " + txt14last.Text.ToUpper();
                txt012.Text = txt7first.Text.ToUpper() + " " + txt7middle.Text.ToUpper() + " " + txt7last.Text.ToUpper();
                a1.Visible = true;
            }
            else
            {
                txt20a.Visible = true;
                txt20bcitymun.Visible = true;
                txt20bProvince.Visible = true;
                txt20bcountry.Visible = true;
                txtnotmarried1.Text = "";
                txtnotmarried2.Text = "";
                affi2();
            }
            
        }

        private void check5b_CheckStateChanged(object sender, EventArgs e)
        {
            if (check5b.Checked == true)
                txt5b.Text = "N/A";

            else
                txt5b.Text = "";


        }
        private void txt3dob_ValueChanged(object sender, EventArgs e)
        {
            DateTime from = txt3dob.Value;
            from = DateTime.Parse(from.ToString("yyyy/MM/dd"));
            DateTime to = DateTime.Now;
            to = DateTime.Parse(to.ToString("yyyy/MM/dd"));
            if (DateTime.Compare(from, to) >= 0)
            {
                txtremarks.Text = "";
            }
            else { 
                txtremarks.Text = "Late Registration";
            }
            
        }

        ///
        ///PAGE2
        ///
        void affi1()
        {
            txt1.Visible = true;
            txt2.Visible = true;
            txt3.Visible = true;
            txt4.Visible = true;
            txt5.Visible = true;
            txt06.Visible = true;
            txt07.Visible = true;
            txt08.Visible = true;
            txt09.Visible = true;
            txt10.Visible = true;
            txt011.Visible = true;
            txt012.Visible = true;
            txt13.Visible = true;
            txt014.Visible = true;
            txt015.Visible = true;
            txt016.Visible = true;
            txt017.Visible = true;
            txt018.Visible = true;
        }

        void affi2()
        {
            txt1.Visible = false;
            txt2.Visible = false;
            txt3.Visible = false;
            txt4.Visible = false;
            txt5.Visible = false;
            txt06.Visible = false;
            txt07.Visible = false;
            txt08.Visible = false;
            txt09.Visible = false;
            txt10.Visible = false;
            txt011.Visible = false;
            txt012.Visible = false;
            txt13.Visible = false;
            txt014.Visible = false;
            txt015.Visible = false;
            txt016.Visible = false;
            txt017.Visible = false;
            txt018.Visible = false;
            a1.Visible = false;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

            
        }

        //
        //Affidavit of Late Reg
        //
        void affidavit3False()
        {
            lbl1.Visible = false;
            lbl2.Visible = false;
            check1.Visible = false;
            lbl3.Visible = false;
            lbl4.Visible = false;
            check2.Visible = false;
            lbl5.Visible = false;
            lbl6.Visible = false;
            lbl7.Visible = false;
            lbl8.Visible = false;
            lbl9.Visible = false;
            lbl10.Visible = false;
            check3.Visible = false;
            lbl11.Visible = false;
            lbl12.Visible = false;
            check4.Visible = false;
            lbl13.Visible = false;
            lbl14.Visible = false;
            lbl15marriedto.Visible = false;
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
            lbl26.Visible = false;
            lbl27.Visible = false;
            lbl28.Visible = false;
            lbl29.Visible = false;
            lbl30.Visible = false;
            a2.Visible = false;
        }
        void affidavitTrue()
        {
            lbl1.Visible = true;
            lbl2.Visible = true;
            check1.Visible = true;
            check2.Visible = true;
            lbl8.Visible = true;
            lbl9.Visible = true;
            lbl10.Visible = true;
            check3.Visible = true;
            check4.Visible = true;
            lbl14.Visible = true;
            lbl17.Visible = true;
            lbl18.Visible = true;
            lbl19.Visible = true;
            lbl20.Visible = true;
            lbl21.Visible = true;
            lbl22.Visible = true;
            lbl23.Visible = true;
            lbl24.Visible = true;
            lbl25.Visible = true;
            lbl26.Visible = true;
            lbl27.Visible = true;
            lbl28.Visible = true;
            lbl29.Visible = true;
            lbl30.Visible = true;
            

            

        }
        private void txtremarks_TextChanged(object sender, EventArgs e)
        {
            if (txtremarks.Text.Equals("Late Registration"))
            {
                affidavitTrue();
                lbl1.Text = txt22name.Text.ToUpper();
                lbl2.Text = txt22address.Text;
                lbl3.Text = txt4barangay.Text + " " + txt4citymun.Text + " " + txt4province.Text;
                lbl4.Text = txt3dob.Text;
                lbl5.Text = txt1first.Text.ToUpper() + " " + txt1middle.Text.ToUpper() + " " + txt1last.Text.ToUpper();
                lbl6.Text = txt4barangay.Text + " " + txt4citymun.Text + " " + txt4province.Text;
                lbl7.Text = txt3dob.Text;
                lbl8.Text = txt21bname.Text.ToUpper();
                lbl9.Text = txt21baddress.Text;
                lbl10.Text = "Philippines";
                lbl11.Text = txt20a.Text;
                lbl12.Text = txt20bcitymun.Text + " " + txt20bProvince.Text + " " + txt20bcountry.Text;
                lbl13.Text = txt14first.Text.ToUpper() + " " + txt14middle.Text.ToUpper() + " " + txt14last.Text.ToUpper();
                DateTime dt = DateTime.Now;
                string d2d = dt.ToString("dd").Substring(1);
                string suffix = (dt.Day == 11 || dt.Day == 12 || dt.Day == 13) ? "th"
               : (d2d == "1") ? "st"
               : (d2d == "2") ? "nd"
               : (d2d == "3") ? "rd"
               : "th";
                lbl17.Text = DateTime.Today.Day.ToString("d") + suffix;
                string theMonth = DateTime.Now.ToString("MMMM");
                lbl18.Text = theMonth + " " + DateTime.Now.Year.ToString();
                lbl20.Text = txt22name.Text.ToUpper();
                lbl21.Text = DateTime.Today.Day.ToString("d") + suffix;
                lbl22.Text = theMonth;
                lbl23.Text = DateTime.Now.Year.ToString();
                lbl28.Text = txt25name.Text;
                lbl29.Text = txt25position.Text;
                lbl30.Text = "Sultan Kudarat Maguindanao";
                a2.Visible = true;



                if (txt22relationship.Text.ToLower().Equals("himself") || (txt22relationship.Text.ToLower().Equals("herself")))
                {
                    lbl15marriedto.Visible = true;
                    lbl16.Visible = false;
                }
                else
                {
                    lbl15marriedto.Visible = false;
                    lbl16.Visible = true;
                    lbl16.Text = txt22relationship.Text.ToLower();

                }



            }
            else
            {
                affidavit3False();
            }
        }

        private void check1_Click(object sender, EventArgs e)
        {
            if (check1.Checked == true)
            {
                check2.Checked = false;
                lbl3.Visible = true;
                lbl4.Visible = true;
                lbl5.Visible = false;
                lbl6.Visible = false;
                lbl7.Visible = false;
            }
            else 
            {
                lbl3.Visible = false;
                lbl4.Visible = false;
            }
            
        }

        private void check2_Click(object sender, EventArgs e)
        {
            if (check2.Checked == true)
            {
                check1.Checked = false;
                lbl5.Visible = true;
                lbl6.Visible = true;
                lbl7.Visible = true;
                lbl3.Visible = false;
                lbl4.Visible = false;
               
            }
            else
            {
                lbl5.Visible = false;
                lbl6.Visible = false;
                lbl7.Visible = false;
            }
        }

        private void check3_Click(object sender, EventArgs e)
        {
            check4.Checked = false;
            lbl11.Visible = true;
            lbl12.Visible = true;
            lbl13.Visible = false;

        }

        private void check4_Click(object sender, EventArgs e)
        {
            check3.Checked = false;
            lbl13.Visible = true;
            lbl11.Visible = false;
            lbl12.Visible = false;

        }

        private void txt22relationship_TextChanged(object sender, EventArgs e)
        {

            if (txtremarks.Text.Equals("Late Registration")) {
                string female = "herself";
                string male = "himself";

                if (txt22relationship.Text.ToLower().Equals(female) || (txt22relationship.Text.ToLower().Equals(male)))
                {
                    lbl15marriedto.Visible = true;
                    lbl16.Visible = false;

                    check1.Checked = true;
                    
                }
                else
                {
                    lbl15marriedto.Visible = false;
                    lbl16.Visible = true;
                    lbl16.Text = txt22relationship.Text.ToLower();
                    check2.Checked = true;
                    
                }
            }

        }

        private void rdam_Click(object sender, EventArgs e)
        {
            rdam.Checked = true;
            rdpm.Checked = false;
        }

        private void rdpm_Click(object sender, EventArgs e)
        {
            rdam.Checked = false;
            rdpm.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] data =
            {
                txtregistryno.Text,
                txt1first.Text,
                txt1middle.Text,
                txt1last.Text,
                txtMale.Checked ? "Male":"Female",
                txt3dob.Text,
                txt4barangay.Text,
                txt4citymun.Text,
                txtprovince.Text,
                txt5a.Text,
                txt5b.Text,
                txt5c.Text,
                txt6.Text,
                txt7first.Text,
                txt7middle.Text,
                txt7last.Text,
                txt8.Text,
                txt9.Text,
                txt10a.Text,
                txt10b.Text,
                txt10c.Text,
                txt11.Text,
                txt12.Text,
                txt13barangay.Text,
                txt13citymun.Text,
                txt13province.Text, 
                txt13country.Text,
                txt14first.Text,
                txt14middle.Text,
                txt14last.Text,
                txt15.Text, 
                txt16.Text,
                txt17.Text,
                txt18.Text,
                txt19barangay.Text,
                txt19citymun.Text,
                txt19province.Text,
                txt19country.Text,
                txt20a.Text,
                txt20bcitymun.Text,
                txt20bProvince.Text,
                txt20bcountry.Text,
                txt21aspecify.Text,
                txt21btime.Text + " " + (rdam.Checked ? "am":"pm"),
                txt21bname.Text,
                txt21bposition.Text,
                txt21baddress.Text,
                txt21bdate.Text, 
                txt22name.Text, 
                txt22relationship.Text,
                txt22address.Text,
                txt22date.Text,
                txt23name.Text,
                txt23position.Text, 
                txt23date.Text,
                txt24name.Text,
                txt24position.Text, 
                txt24date.Text, 
                txt25name.Text,
                txt25position.Text,
                txt25date.Text,
                txtremarks.Text


            };
            string[] x=
            {
                txt21a1.Checked ? "X":"",
                txt21a2.Checked ? "X":"",
                txt21a3.Checked ? "X":"",
                txt21a4.Checked ? "X":"",
                txt21a5.Checked ? "X":"",
            };
            Previewer frm = new Previewer(data, x, "Form102page1");
            frm.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string[] data = 
            {
                txt1.Text,
                txt2.Text,
                txt3.Text,
                txt4.Text,
                txt5.Text,
                txt06.Text,
                txt07.Text,
                txt08.Text,
                txt09.Text,
                txt10.Text,
                txt011.Text,
                txt012.Text,
                txt13.Text,
                txt014.Text,
                txt015.Text,
                txt016.Text,
                txt017.Text,
                txt018.Text,

                ///
                lbl1.Text,
                lbl2.Text,
                lbl3.Text,
                lbl4.Text,
                lbl5.Text,
                lbl6.Text,
                lbl7.Text,
                lbl8.Text,
                lbl9.Text,
                lbl10.Text,
                lbl11.Text,
                lbl12.Text,
                lbl13.Text,
                lbl14.Text,
                lbl15marriedto.Text,
                lbl16.Text,
                lbl17.Text,
                lbl18.Text,
                lbl19.Text,
                lbl20.Text,
                lbl21.Text,
                lbl22.Text,
                lbl23.Text,
                lbl24.Text,
                lbl25.Text,
                lbl26.Text,
                lbl27.Text,
                lbl28.Text,
                lbl29.Text,
                lbl30.Text,
            };

            string[] x =
            {
                check1.Checked ? "X":"",
                check2.Checked ? "X":"",
                check3.Checked ? "X":"",
                check4.Checked ? "X":""
            };
            Previewer frm = new Previewer(data, x, "Form102page2");
            frm.Show();
            clear();
            this.Close();

        }

        private void additional_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void Form102_Load(object sender, EventArgs e)
        {

        }

        private void txt014_KeyUp(object sender, KeyEventArgs e)
        {

            if (txt014.Text.Length == 2)
            {
                if (e.KeyValue == Convert.ToChar(Keys.Back))
                {
                    txt014.Text = txt014.Text.Substring(0, 1);
                    txt014.SelectionStart = 1;
                    return;
                }
                txt014.Text = txt014.Text + "/";
                txt014.SelectionStart = 3;
            }
            if (txt014.Text.Length == 5)
            {
                if (e.KeyValue == Convert.ToChar(Keys.Back))
                {
                    txt014.Text = txt014.Text.Substring(0, 4);
                    txt014.SelectionStart = 4;
                    return;
                }
                txt014.Text = txt014.Text + "/";
                txt014.SelectionStart = 6;
            }
        }

        private void lbl26_KeyUp(object sender, KeyEventArgs e)
        {

            if (lbl26.Text.Length == 2)
            {
                if (e.KeyValue == Convert.ToChar(Keys.Back))
                {
                    lbl26.Text = lbl26.Text.Substring(0, 1);
                    lbl26.SelectionStart = 1;
                    return;
                }
                lbl26.Text = lbl26.Text + "/";
                lbl26.SelectionStart = 3;
            }
            if (lbl26.Text.Length == 5)
            {
                if (e.KeyValue == Convert.ToChar(Keys.Back))
                {
                    lbl26.Text = lbl26.Text.Substring(0, 4);
                    lbl26.SelectionStart = 4;
                    return;
                }
                lbl26.Text = lbl26.Text + "/";
                lbl26.SelectionStart = 6;
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

        private void txt4barangay_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || (Keys)e.KeyChar == Keys.Space || char.IsDigit(e.KeyChar));
            if (txt4barangay.Text.Length == 0 && e.KeyChar == ' ')
            {
                e.Handled = true;
            }
        }

        private void txt6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar));
           
        }

        private void txt21btime_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt21btime.Text.Length == 2)
            {
                if (e.KeyValue == Convert.ToChar(Keys.Back))
                {
                    txt21btime.Text = txt21btime.Text.Substring(0, 1);
                    txt21btime.SelectionStart = 1;
                    return;
                }
                txt21btime.Text = txt21btime.Text + ":";
                txt21btime.SelectionStart = 3;
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txt14first.Text = "N/A";
                txt14middle.Text = "N/A";
                txt14last.Text = "N/A";
                txt15.Text = "N/A";
                txt16.Text = "N/A";
                txt17.Text = "N/A";
                txt18.Text = "N/A";
                txt19barangay.Text = "N/A";
                txt19citymun.Text = "N/A";
                txt19province.Text = "N/A";
                txt19country.Text = "N/A";
                txtnotmarried1.Text = "N/A";
                txtnotmarried2.Text = "N/A";
                txt20a.Visible = false;
                txt20bcitymun.Visible = false;
                txt20bProvince.Visible = false;
                txt20bcountry.Visible = false;
            }
            else
            {
                txt14first.Text = "";
                txt14middle.Text = "";
                txt14last.Text = "";
                txt15.Text = "";
                txt16.Text = "";
                txt17.Text = "";
                txt18.Text = "";
                txt19barangay.Text = "";
                txt19citymun.Text = "";
                txt19province.Text = "";
                txt19country.Text = "";
                txtnotmarried1.Text = "";
                txtnotmarried2.Text = "";
            }
        }

        private void Form102_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
