using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace LCRSys
{
    class Database
    {
        private MySqlCommand cmd;
        private MySqlConnection connection;

        public Database()
        {
            connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=lcr_db;");
            cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlDataReader getUserLevel(string username, string password)
        {
            openConnection();
            cmd.CommandText = "select * from users where username='" + username + "' and password='" + password + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        //BIRTH CERTIFICATE
        public Boolean insertchild(string id, string firstname, string middlename, string lastname, string sex, string dob, string barangay, string municipality, string province, string typeofbirth,string ifmultiplebirth, string birthorder, string birthweight, string mfirst, string mmiddle, string mlast, string m8, string m9, string m10a, string m10b, string m10c, string m11, string m12, string m13a, string m13b, string m13c, string m13d, string first14, string middle14, string last14, string h15, string h16, string h17, string h18, string h19a, string h19b, string h19c, string h19d, string a20, string b20, string a21, string time21, string name21, string position21, string address21, string date21, string a22, string b22, string b23, string b24)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `form102_tbl`(`registryno`, `firstname`, `middlename`, `lastname`, `sex`, `dob`, `barangay`, `municipality`, `province`, `typeofbirth`, `ifmultiplebirth`, `birthorder`, `weightatbirth`, `7first`, `7middle`, `7last`, `8`, `9`, `10a`, `10b`, `10c`, `11`, `12`, `13a`, `13b`, `13c`, `13d`, `14first`, `14middle`, `14last`, `15citizenship`, `16religion`, `17occupation`, `18age`, `19a`, `19b`, `19c`, `19d`, `20adate`, `20b`, `21a`, `21btime`, `21bname`, `21bposition`, `21baddress`, `21bdate`, `22name`, `22relationship`, `22address`, `22date`) VALUES " + "('"+id+"','"+firstname+"','"+middlename+"','"+lastname+"','"+sex+"','"+dob+"','"+barangay+"','"+municipality+"','"+province+"','"+typeofbirth+"','"+ifmultiplebirth+"','"+birthorder+"','"+birthweight+"', '"+mfirst+ "', '"+mmiddle+ "', '"+mlast+ "', '"+m8+ "', '"+m9+ "', '"+m10a+ "', '"+m10b+ "', '"+m10c+ "', '"+m11+ "', '"+m12+ "', '"+m13a+ "', '"+m13b+ "', '"+m13c+ "', '"+m13d+ "', '" + first14 + "', '" + middle14 + "', '" + last14 + "', '" + h15 + "', '" + h16 + "', '" + h17 + "', '" + h18 + "', '" + h19a + "', '" + h19b + "', '" + h19c + "', '" + h19d + "', '" + a20 + "', '" + b20 + "', '" + a21 + "', '" + time21 + "', '" + name21 + "', '" + position21 + "', '" + address21 + "', '" + date21 + "', '" + a22 + "', '" + b22 + "', '" + b23 + "', '" + b24 + "');"; 
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public Boolean insertchildcontinue(string registryno, string preparedby, string recievedby, string registeredatocr, string remarks)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `form102_conti_tbl`(`registryno`, `23preparedby`, `24recievedby`, `25registeredatocr`, `remarks`) VALUES ('"+registryno+"','"+preparedby+"','"+recievedby+"','"+registeredatocr+"','"+remarks+"');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public Boolean insertaffi1(string day, string month, string year, string ctc, string dateissued, string issuedaddress ,string name, string position, string address, string registryno)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `form102_affi1_tbl`(`id`, `day`, `month`, `year`, `ctc`, `dateissued`, `issuedaddress`, `name`, `position`, `address`, `registryno`) VALUES " + "(NULL,'"+day+ "','"+month+ "','"+year+ "','"+ctc+ "','"+dateissued+ "','"+issuedaddress+ "','"+name+ "','"+position+ "','"+address+"','"+registryno+"');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public Boolean insertaffi2(string check1, string check2, string no5, string no6, string lbl17, string lbl18, string lbl19, string lbl21, string lbl22, string lbl23, string lbl24, string lbl25, string lbl26, string lbl27, string lbl28, string lbl29, string lbl30, string registryno)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `form102_affi2_tbl`(`id`, `check1`, `check2`, `no5`, `no6`, `lbl17`, `lbl18`, `lbl19`, `lbl21`, `lbl22`, `lbl23`, `lbl24`, `lbl25`, `lbl26`, `lbl27`, `lbl28`, `lbl29`, `lbl30`, `registryno`) VALUES "+" (NULL,'"+check1+"','"+check2+"','"+no5+"','"+no6+"','"+lbl17+"','"+lbl18+"','"+lbl19+"','"+lbl21+"','"+lbl22+"','"+lbl23+"','"+lbl24+"','"+lbl25+"','"+lbl26+"','"+lbl27+"','"+lbl28+"','"+lbl29+"','"+lbl30+"', '"+registryno+"');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }

        //DEATH CERTIFICATE
        public Boolean insertdeathcertificate(string regno, string immediate, string interval1,string antecedent,string interval2, string underlying, string interval3, string othercause, string interval4, string matternalcondition, string mannerofdeath, string placeofaccurance, string autopsy, string attendant, string durationa, string durationb, string certattendant, string time, string name, string position, string address, string date2, string name2, string date3)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `form103_medicalcertificate_tbl`(`registryno`, `immediatecause`, `interval1`, `antecedentcause`, `interval2`, `underlyingcause`, `interval3`, `othercause`, `enterval4`, `maternalcondition`, `mannerofdeath`, `placeofaccurance`, `autopsy`, `attendant`, `durationa`, `durationb`, `certattendant`, `time`, `name`, `title`, `address`, `date2`, `name2`, `date3`) VALUES ('"+regno+"','"+immediate+"','"+interval1+"','"+antecedent+"','"+interval2+"','"+underlying+"','"+interval3+"','"+othercause+"','"+interval4+"','"+matternalcondition+"','"+mannerofdeath+"','"+placeofaccurance+"','"+autopsy+"','"+attendant+"','"+durationa+"','"+durationb+"','"+certattendant+"','"+time+"','"+name+"','"+position+"','"+address+"','"+date2+"','"+name2+"','"+date3+"')";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public Boolean insertform103(string registryno, string first, string middle, string last, string sex,string dod, string dob, string age, string a6, string b6, string c6, string status, string religion, string cit, string a10, string b10, string c10, string occupation, string father, string mother, string copsdisposal, string burialnum, string burialdate, string transfernum, string transferdate, string nameandadress, string name1, string relationship, string address, string date1, string name2, string position2,string date2, string name3, string position3, string date3, string name4, string position4, string date4, string remarks )
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `form103_tbl`(`registryno`, `first`, `middle`, `last`,`sex`, `dod`, `dob`, `age`, `6a`, `6b`, `6c`, `7status`, `8religion`, `9cit`, `10a`, `10b`, `10c`, `11occupation`, `12father`, `13mother`, `corspedisposal`, `burialnum`, `burialdate`, `transfernum`, `transferdate`, `nameandaddreescembur`, `name1`, `relationship`, `address`, `date1`, `name2`, `position1`, `date2`, `name3`, `postion3`, `date3`, `name4`, `position4`, `date4`, `remarks`) VALUES "+"('"+registryno+ "','"+first+ "','"+middle+ "','"+last+ "','"+sex+ "','"+dod+ "','"+dob+"','"+age+ "','"+a6+ "','"+b6+ "','"+c6+"','" + status+"','"+religion+ "','"+cit+ "','"+a10+"','"+b10+"','"+c10+"','"+occupation+ "','"+father+ "','"+mother+ "','"+copsdisposal+ "','"+burialnum+"','"+burialdate+"','"+transfernum+"','"+transferdate+ "','"+nameandadress+ "','"+name1+ "','"+relationship+ "','"+address+ "','"+date1+ "','"+name2+ "','"+position2+ "','"+date2+ "','"+name3+ "','"+position3+ "','"+date3+ "','"+name4+ "','"+position4+"','"+date4+"', '"+remarks+"');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public Boolean insertdeathcertificate2(string registryon, string motherage, string methodofdelivery, string lenghtofpregnancy, string typeofbirth, string ifmultiple,string causeofdeatha, string causeofdeathb, string causeofdeathc, string causeofdeathd, string causeofdeathe, string autopsy, string attendant, string attendedfrom, string attendedto, string certofdeath, string time, string name1, string position, string address, string date1, string name2, string date2)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `form103_medicalcertificate2_tbl`(`registryno`, `motherage`, `methodofdelivery`, `lenghtofpregnancy`, `typeofbirth`, `ifmultiple`, `causeofdeatha`, `causeofdeathb`, `causeofdeathc`, `causeofdeathd`, `causeofdeathe`, `autopsy`, `attendant`, `attendedfrom`, `attendedto`, `certofdeath`, `time`, `name1`, `position`, `address`, `date1`, `name2`, `date2`) VALUES " + " ('"+registryon+ "','"+motherage+ "','"+methodofdelivery+ "','"+lenghtofpregnancy+ "','"+typeofbirth+ "','"+ifmultiple+ "','"+causeofdeatha+ "','"+causeofdeathb+ "','"+causeofdeathc+ "','"+causeofdeathd+ "','"+causeofdeathe+ "','"+autopsy+ "','"+attendant+ "','"+attendedfrom+ "','"+attendedto+ "','"+certofdeath+"','"+time+ "','"+name1+ "','"+position+ "','"+address+ "','"+date1+ "','"+name2+ "','"+date2+"');";
            if (cmd.ExecuteNonQuery() == 1)
            { closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public Boolean insertcertificateofembalmer(string registryno, string name1, string embalmer, string address, string title, string license, string date, string address1, string expiration)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `form103_certificationofembalmer`(`registryno`, `name1`, `embalmer`, `address`, `title`, `licensenum`, `date`, `address1`, `expirationdate`) VALUES"+" ('"+registryno+ "','"+name1+ "','"+embalmer+ "','"+address+ "','"+title+ "','"+license+ "','"+date+ "','"+address1+ "','"+expiration+"');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public Boolean insertdeathpcod(string registryno, string certify, string name, string date, string title, string address)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `form103_pcod_tbl`(`registryno`, `certify`, `name`, `date`, `title`, `address`) VALUES ('"+registryno+ "','"+certify+ "','"+name+ "','"+date+ "','"+title+ "','"+address+"');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public Boolean insertform103lr( string registryno, string lbl1, string lbl2, string lbl3, string lbl4, string lbl5, string lbl6, string lbl7, string check, string lbl8, string lbl9, string lbl10, string lbl11, string lbl12, string lbl13, string lbl14, string lbl15, string lbl16, string lbl17, string lbl18, string lbl19, string lbl20, string lbl21, string lbl22, string lbl23, string lbl24, string lbl25)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `from103_lateregistration_tbl`(`registryno`, `lbl1`, `lbl2`, `lbl3`, `lbl4`, `lbl5`, `lbl6`, `lbl7`, `check`, `lbl8`, `lbl9`, `lbl10`, `lbl11`, `lbl12`, `lbl13`, `lbl14`, `lbl15`, `lbl16`, `lbl17`, `lbl18`, `lbl19`, `lbl20`, `lbl21`, `lbl22`, `lbl23`, `lbl24`, `lbl25`) VALUES  ('"+registryno+ "','"+lbl1+ "','"+lbl2+ "','"+lbl3+ "','"+lbl4+ "','"+lbl5+ "','"+lbl6+ "','"+lbl7+ "','"+check+"','" + lbl8+ "','"+lbl8+ "','"+lbl9+ "','"+lbl10+ "','"+lbl11+ "','"+lbl12+ "','"+lbl13+ "','"+lbl14+ "','"+lbl15+ "','"+lbl16+ "','"+lbl17+ "','"+lbl18+ "','"+lbl19+ "','"+lbl20+ "','"+lbl21+ "','"+lbl22+ "','"+lbl23+ "','"+lbl24+ "','"+lbl25+"');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }


        /// marriage
        /// 
        public Boolean insertmarrriagecertificate(string registryno, string placeofmarriage,  string dom, string tom, string settlement, string s1, string s2, string s3, string csofurtercertification, string soname, string soposition, string so3, string witnesses, string rcvdname, string rcvdposition, string rcvddate, string rocrname, string rocrposition, string rocrdate, string remarks )
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `form97_tbl`(`registryno`,`placeofmarriage`, `dom`, `tom`, `settlement`, `s1`, `s2`, `s3`, `csofurtercertification`, `soname`, `soposiiton`, `so3`, `witnesses`, `rcvdname`, `rcvdposition`, `rcvddate`, `rocrname`, `rocrposition`, `rocrdate`, `remarks`) VALUES " + " ('"+registryno+ "','"+placeofmarriage+"','"+dom+ "','"+tom+ "','"+settlement+"','"+s1+"','"+s2+"','"+s3+ "','" + csofurtercertification + "','" + soname+"','" +soposition +"','" + so3+ "','" + witnesses+"','" +rcvdname +"','" +rcvdposition +"','" + rcvddate+"','" + rocrname+ "','" +rocrposition +"','" + rocrdate+ "','" +remarks +"');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public Boolean inserthusband(string registryno, string first, string middle, string last, string dob, string age, string pob, string sex, string citizenship, string residence, string religion, string civilstatus, string f1, string f2, string f3, string citizenshipf, string m1, string m2, string m3, string citizenshipm, string w1, string w2, string w3, string relationship, string residencew)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `form97_husbanddata_tbl`(`registryno`, `first`, `middle`, `last`, `dob`, `age`, `pob`, `sex`, `citizenship`, `residence`, `religion`, `civilstatus`, `f1`, `f2`, `f3`, `citizenshipf`, `m1`, `m2`, `m3`, `citizenshipm`, `w1`, `w2`, `w3`, `relationship`, `residencew`) VALUES "+" ('"+registryno+ "','"+first+"','"+middle+"','"+last+ "','"+dob+"','"+age+ "','"+pob+"','"+sex+"','"+citizenship+ "','"+residence+"','"+religion+"','"+civilstatus+ "','"+f1+"','"+f2+"','"+f3+"','"+citizenshipf+"','"+m1+ "','"+m2+"','"+m3+ "','"+citizenshipm+ "','"+w1+"','"+w2+"','"+w3+"','"+relationship+ "','"+residencew+"');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public Boolean insertwife(string registryno, string first, string middle, string last, string dob, string age, string pob, string sex, string citizenship, string residence, string religion, string civilstatus, string f1, string f2, string f3, string citizenshipf, string m1, string m2, string m3, string citizenshipm, string w1, string w2, string w3, string relationship, string residencew)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `form97_wifedata_tbl`(`registryno`, `first`, `middle`, `last`, `dob`, `age`, `pob`, `sex`, `citizenship`, `residence`, `religion`, `civilstatus`, `f1`, `f2`, `f3`, `citizenshipf`, `m1`, `m2`, `m3`, `citizenshipm`, `w1`, `w2`, `w3`, `relationship`, `residencew`) VALUES " + " ('" + registryno + "','" + first + "','" + middle + "','" + last + "','" + dob + "','" + age + "','" + pob + "','" + sex + "','" + citizenship + "','"+residence+"','" + religion + "','" + civilstatus + "','" + f1 + "','" + f2 + "','" + f3 + "','" + citizenshipf + "','" + m1 + "','" + m2 + "','" + m3 + "','" + citizenshipm + "','" + w1 + "','" + w2 + "','" + w3 + "','" + relationship + "','" + residencew + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public Boolean insertaso(string registryno, string address, string choice, string date, string ctc)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `form97_affidavitofsolemnizingofficer_tbl`(`registryno`, `soaddress`, `choice`, `date`, `ctc`) VALUES "+"('"+registryno+ "','"+address+ "','"+choice+ "','"+date+"', '"+ctc+"');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public Boolean insertmarriageadr(string registryno, string affiantname, string address, string affiant1, string sounder, string solemnized, string citizenship, string reason, string dateplace, string ctc)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `form97_affidavitofdelayregistration_tbl`(`registryno`, `affiantname`, `adddress`, `affiant1`, `sounder`, `solemnized`, `citizenship`, `reason`, `dateandplace`, `ctc`)VALUE "+"('" + registryno+ "','"+affiantname+ "','"+address+ "','"+affiant1+ "','"+sounder+ "','"+solemnized+ "','"+citizenship+"','"+reason+ "','"+dateplace+ "','"+ctc+"');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }



        public MySqlDataReader getData(string query)
        {
            openConnection();
            cmd.CommandText = query;
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public DataTable getForm102()
        {
            openConnection();
            cmd.CommandText = "SELECT `registryno` as 'Registry Number', `firstname` as 'Firstname', `middlename` as 'Middlename', `lastname` as 'Lastname'  FROM `form102_tbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }


        public DataTable getForm103()
        {
            openConnection();
            cmd.CommandText = "SELECT `registryno` as 'Registry Number', `first` as 'Firstname', `middle` as 'Middlename', `last` as 'Lastname'  FROM `form103_tbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }

        public DataTable getForm97()
        {
            openConnection();
            cmd.CommandText = "SELECT form97_wifedata_tbl.registryno AS 'Registry Number', form97_wifedata_tbl.first AS 'Wife Firstname',form97_wifedata_tbl.last AS 'Wife Lastname',form97_husbanddata_tbl.first AS 'Husband Firstname',form97_husbanddata_tbl.last AS 'Husband Lastname' FROM form97_wifedata_tbl INNER JOIN form97_husbanddata_tbl ON form97_wifedata_tbl.registryno=form97_husbanddata_tbl.registryno;";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }

        public DataTable getForm102(string que)
        {
            openConnection();
            cmd.CommandText = "SELECT `registryno` as 'Registry Number', `firstname` as 'Firstname', `middlename` as 'Middlename', `lastname` as 'Lastname'  FROM `form102_tbl` WHERE CONCAT (registryno,firstname,lastname,middlename) LIKE '%" + que + "%'  ";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }


        public DataTable getForm103(string que)
        {
            openConnection();
            cmd.CommandText = "SELECT `registryno` as 'Registry Number', `first` as 'Firstname', `middle` as 'Middlename', `last` as 'Lastname'  FROM `form103_tbl` WHERE CONCAT (registryno,first,last,middle) LIKE '%" + que + "%'  ";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }

        public DataTable getForm97(string que)
        {
            openConnection();
            cmd.CommandText = "SELECT form97_wifedata_tbl.registryno, form97_wifedata_tbl.first AS" +
                " 'Wife Firstname',form97_wifedata_tbl.last AS 'Wife Lastname',form97_husbanddata_tbl.first AS 'Husband Firstname'," +
                "form97_husbanddata_tbl.last AS 'Husband Lastname' FROM form97_wifedata_tbl INNER JOIN form97_husbanddata_tbl ON" +
                " form97_wifedata_tbl.registryno=form97_husbanddata_tbl.registryno WHERE CONCAT (form97_husbanddata_tbl.registryno,form97_wifedata_tbl.first ,form97_wifedata_tbl.last,form97_husbanddata_tbl.first,form97_husbanddata_tbl.last) LIKE '%" + que + "%'  ";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }












        public MySqlDataReader reprint(string command)
        {
            openConnection();
            cmd.CommandText = command;
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }


















    }
}
