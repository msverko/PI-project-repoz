using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Repoz
{
    class Baza
    {

        SQLiteConnection sqlite_conn;
        SQLiteCommand sqlite_cmd;
        SQLiteDataReader sqlite_datareader;
        string dbPath = Directory.GetCurrentDirectory() + "\\repository.db";     

        public string GetSingleLastValue(string sqlString, string col) //Get single(last) value in given column form db (as string).
        {
            string sqlResult = null;
            try
            {
                sqlite_conn = new SQLiteConnection("Data Source=" + dbPath + ";Version=3");
                sqlite_conn.Open();
                sqlite_cmd = new SQLiteCommand(sqlString, sqlite_conn);
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    sqlResult = sqlite_datareader[col].ToString();
                }
                sqlite_datareader.Close();
                sqlite_cmd.Dispose();
                sqlite_conn.Close();      
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return sqlResult;
        }

        public string GetRepozName() //Get reposiory names from t_repoz into arrays, and returns only first found
        {
            string sqlString = @"select rname from t_repoz;";
            string[] repoName = new string[10];
            int i = 0;
            try
            {
                sqlite_conn = new SQLiteConnection("Data Source=" + dbPath + ";Version=3");
                sqlite_conn.Open();
                sqlite_cmd = new SQLiteCommand(sqlString, sqlite_conn);
                sqlite_datareader = sqlite_cmd.ExecuteReader();
                while (sqlite_datareader.Read())
                {
                    repoName[i] = (string)sqlite_datareader["rname"];
                    i++;
                }
                sqlite_datareader.Close();
                sqlite_cmd.Dispose();
                sqlite_conn.Close();

                if (string.IsNullOrEmpty(repoName[0]))
                {
                    repoName[0] = "No repository loaded"; //Do not chang this text (used for validation if repoz exists)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return repoName[0];
        }

        public string GetRepozPath() //Get reposiory paths from t_repoz into arrays, and returns only first found
        {
            string sqlString = @"select rpath from t_repoz;";
            string[] repoPath = new string[10];
            int i = 0;
            sqlite_conn = new SQLiteConnection("Data Source=" + dbPath + ";Version=3");
            sqlite_conn.Open();
            sqlite_cmd = new SQLiteCommand(sqlString, sqlite_conn);
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                repoPath[i] = (string)sqlite_datareader["rpath"];
                i++;
            }
            sqlite_datareader.Close();
            sqlite_cmd.Dispose();
            sqlite_conn.Close();
            if (string.IsNullOrEmpty(repoPath[0]))
            {
                repoPath[0] = "Repozitory path is empty !";
            }
            return repoPath[0];
        }

        public void GetProjectsInCombo(ComboBox ComboName) //Load passed comboBox with lis of projects form db.
        {
            try
            {
                sqlite_conn = new SQLiteConnection("Data Source=" + dbPath + ";Version=3");
                sqlite_conn.Open();
                sqlite_cmd = new SQLiteCommand(@"SELECT name FROM t_projects;", sqlite_conn);
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Columns.Add("name", typeof(string));
                dt.Load(sqlite_datareader);

                ComboName.ValueMember = "name";
                ComboName.DisplayMember = "name";
                ComboName.DataSource = dt;

                sqlite_datareader.Close();
                sqlite_cmd.Dispose();
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void LoadCombo(ComboBox ComboName, string col, string sqlString) //Load passed comboBox with list of values form single column in db.
        {
            try
            {
                sqlite_conn = new SQLiteConnection("Data Source=" + dbPath + ";Version=3");
                sqlite_conn.Open();
                sqlite_cmd = new SQLiteCommand(sqlString, sqlite_conn);
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Columns.Add(col, typeof(string));
                dt.Load(sqlite_datareader);

                ComboName.ValueMember = col;
                ComboName.DisplayMember = col;
                ComboName.DataSource = dt;

                sqlite_datareader.Close();
                sqlite_cmd.Dispose();
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void LoadTextList(ListBox ListBoxName, string col, string sqlString) //Load passed ListBox with list of values form single column in db.
        {           
            try
            {
                sqlite_conn = new SQLiteConnection("Data Source=" + dbPath + ";Version=3");
                sqlite_conn.Open();
                sqlite_cmd = new SQLiteCommand(sqlString, sqlite_conn);
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                while (sqlite_datareader.Read())
                {
                   ListBoxName.Items.Add(sqlite_datareader[col]).ToString();
                }
                sqlite_datareader.Close();
                sqlite_cmd.Dispose();
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void LoadVeiwListProjectDocuments(ListView listViewName) //Loads List of documents from db, to listViewProjDoc
        {
            try
            {
                string sqlString = string.Format(@"SELECT * FROM t_doc WHERE project LIKE '{0}';", glob.ProjectName);
                sqlite_conn = new SQLiteConnection("Data Source=" + dbPath + ";Version=3");
                sqlite_conn.Open();
                sqlite_cmd = new SQLiteCommand(sqlString, sqlite_conn);
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                while (sqlite_datareader.Read())
                {
                    ListViewItem item = new ListViewItem(sqlite_datareader["filename"].ToString());
                    item.SubItems.Add(sqlite_datareader["rev"].ToString());
                    item.SubItems.Add(sqlite_datareader["commitdatetime"].ToString());
                    item.SubItems.Add(sqlite_datareader["commituser"].ToString());
                    item.SubItems.Add(sqlite_datareader["owner"].ToString());

                    listViewName.Items.Add(item);
                }
                sqlite_datareader.Close();
                sqlite_cmd.Dispose();
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void SendQueryToDb(string sqlString) //Send query to DB - no return value ! (INSERT INTO... UPDATE.... DELETE...)
        {
            try
            {
                sqlite_conn = new SQLiteConnection("Data Source=" + dbPath + ";Version=3");
                sqlite_conn.Open();
                sqlite_cmd = new SQLiteCommand(sqlString, sqlite_conn);

                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = sqlString;
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.Dispose();
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void LoadComboNameSurname(ComboBox ComboName, string sqlString) //Load passed comboBox with list of values form single column in db.
        {
            
            try
            {
                sqlite_conn = new SQLiteConnection("Data Source=" + dbPath + ";Version=3");
                sqlite_conn.Open();
                sqlite_cmd = new SQLiteCommand(sqlString, sqlite_conn);
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Columns.Add("name", typeof(string));
                dt.Columns.Add("surname", typeof(string));
                dt.Columns.Add("username", typeof(string));
                dt.Load(sqlite_datareader);

                DataColumn dcNameSurname = new DataColumn("NameSurname");  //Added column in DataTabel to concatenate name+surname
                dcNameSurname.Expression = string.Format("{0} + ' ' + {1}", "name", "surname");                
                dt.Columns.Add(dcNameSurname);

                ComboName.ValueMember = "username";
                ComboName.DisplayMember = "NameSurname"; //concatenated colunms (added as single column in dt)
                ComboName.DataSource = dt;

                sqlite_datareader.Close();
                sqlite_cmd.Dispose();
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void LoadVeiwListSupportRequests(ListView listViewName) //Loads List of support requests subjects(names like folders) from db, to listViewSupport
        {
            try
            {
                string sqlString = string.Format(@"SELECT * FROM t_support WHERE project LIKE '{0}';", glob.ProjectName);
                sqlite_conn = new SQLiteConnection("Data Source=" + dbPath + ";Version=3");
                sqlite_conn.Open();
                sqlite_cmd = new SQLiteCommand(sqlString, sqlite_conn);
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                while (sqlite_datareader.Read())
                {
                    ListViewItem item = new ListViewItem(sqlite_datareader["subject"].ToString());
                    item.SubItems.Add(sqlite_datareader["usersent"].ToString());
                    item.SubItems.Add(sqlite_datareader["senttime"].ToString());
                    item.SubItems.Add(sqlite_datareader["issuesolved"].ToString());
                    item.SubItems.Add(sqlite_datareader["usersolved"].ToString());
                    item.SubItems.Add(sqlite_datareader["solvedtime"].ToString());

                    listViewName.Items.Add(item);
                }
                sqlite_datareader.Close();
                sqlite_cmd.Dispose();
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void LoadComboMsgTopicTimesamp(ComboBox ComboName, string sqlString) //Load passed comboBox with list of message subject, and senttime.
        {

            try
            {
                sqlite_conn = new SQLiteConnection("Data Source=" + dbPath + ";Version=3");
                sqlite_conn.Open();
                sqlite_cmd = new SQLiteCommand(sqlString, sqlite_conn);
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Columns.Add("subject", typeof(string));
                dt.Columns.Add("senttime", typeof(string));
                dt.Load(sqlite_datareader);

                DataColumn dcNameSurname = new DataColumn("subjectsenttime");  //Added column in DataTabel to concatenate subject+senttime
                dcNameSurname.Expression = string.Format("{0} + ' (' + {1} +')'", "subject", "senttime");
                dt.Columns.Add(dcNameSurname);

                ComboName.ValueMember = "subject";
                ComboName.DisplayMember = "subjectsenttime"; //concatenated colunms (added as single column in dt)
                ComboName.DataSource = dt;

                sqlite_datareader.Close();
                sqlite_cmd.Dispose();
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public void LoadVeiwListUsers(ListView listViewName, string sqlString) //Loads List of documents from db, to listViewProjDoc
        {
            try
            {                
                sqlite_conn = new SQLiteConnection("Data Source=" + dbPath + ";Version=3");
                sqlite_conn.Open();
                sqlite_cmd = new SQLiteCommand(sqlString, sqlite_conn);
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                while (sqlite_datareader.Read())
                {
                    ListViewItem item = new ListViewItem(sqlite_datareader["name"].ToString());
                    item.SubItems.Add(sqlite_datareader["surname"].ToString());
                    item.SubItems.Add(sqlite_datareader["username"].ToString());
                    item.SubItems.Add(sqlite_datareader["role"].ToString());
                    item.SubItems.Add(sqlite_datareader["passlevel"].ToString());
                    item.SubItems.Add(sqlite_datareader["mail"].ToString());

                    listViewName.Items.Add(item);
                }
                sqlite_datareader.Close();
                sqlite_cmd.Dispose();
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
