using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Repoz
{
    public partial class FormSettings : Form
    {
        Baza db = new Baza();
        BizLogic biz = new BizLogic();
        SysLogic sy = new SysLogic();

        public FormSettings()  
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Text = "Repository Settings";

            string repozFolderName = null;
            repozFolderName = db.GetRepozName();
            if (repozFolderName == "No repository loaded")
            {
                txtRepozName.Enabled = true;
                btnSelectFolder.Enabled = true;
            }
            else
            {
                txtRepozName.Enabled = false;
                btnSelectFolder.Enabled = false;
            }

            db.LoadCombo(comboTeamMemberRole, "name", @"SELECT name FROM t_role");
            listViewUsers.Items.Clear();
            string sqlString = string.Format(@"SELECT DISTINCT * FROM t_members"); //Load list of all users
            db.LoadVeiwListUsers(listViewUsers, sqlString);
        }

        //Repoz name textBox - START
        private void txtRepozName_Enter(object sender, EventArgs e)   //Clear on enter.
        {
            txtRepozName.Text = string.Empty;
        }

        private void txtRepozName_Leave(object sender, EventArgs e)  //Return initial value on leaving empty box.
        {
            if (String.IsNullOrEmpty(txtRepozName.Text))
            {
                txtRepozName.Text = "Insert repository name";
            }
        }
        //Repoz name textBox - END

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (txtRepozName.Text != "Insert repository name" && !String.IsNullOrEmpty(txtNewProjectName.Text))
            {
                FolderBrowserDialog browserDiag = new FolderBrowserDialog();
                if (browserDiag.ShowDialog() == DialogResult.OK)
                {
                    string repozFolderPath = browserDiag.SelectedPath;
                    db.SendQueryToDb(@"INSERT INTO t_repoz values ('" + txtRepozName.Text + @"','" + repozFolderPath + @"');"); //insert repoz name and path in db, so it can be read on app start
                    string repozFolderPathFull = repozFolderPath + @"\" + txtRepozName.Text;
                    Directory.CreateDirectory(repozFolderPathFull);
                    string repozProjectFolderPathFull = repozFolderPathFull + @"\Projects"; //Create folder for projects
                    Directory.CreateDirectory(repozProjectFolderPathFull);
                    repozProjectFolderPathFull = repozFolderPathFull + @"\Temp"; //Create folder for temp files (if any)
                    Directory.CreateDirectory(repozProjectFolderPathFull);
                    repozProjectFolderPathFull = repozFolderPathFull + @"\Users"; //Create folder for Users temp files (loaded documents for modifying before commit/discard)
                    Directory.CreateDirectory(repozProjectFolderPathFull);
                    repozProjectFolderPathFull = repozFolderPathFull + @"\Users\" + glob.loggedUser; //Create folder for ADMIN user
                    Directory.CreateDirectory(repozProjectFolderPathFull);
                    MessageBox.Show("Repository " + txtRepozName.Text + " is created.");


                }
            }
            else
            {
                MessageBox.Show("Insert repository name");
            }

        }

        //Project name textBox - START
        private void txtNewProjectName_Enter(object sender, EventArgs e)  //Clear on enter.
        {
            txtNewProjectName.Text = string.Empty;
        }

        private void txtNewProjectName_Leave(object sender, EventArgs e) //Return initial value on leaving empty box.
        {
            if (String.IsNullOrEmpty(txtNewProjectName.Text))
            {
                txtNewProjectName.Text = "Insert project name";
            }
        }
        //Project name textBox - END

        private void btnCreateProject_Click_1(object sender, EventArgs e)
        {

            if (txtNewProjectName.Text != "Insert project name" && !String.IsNullOrEmpty(txtNewProjectName.Text))
            {
                string repozFolderPathFull = db.GetRepozPath() + @"\" + db.GetRepozName() + @"\Projects\" + txtNewProjectName.Text;
                if (Directory.Exists(repozFolderPathFull)) MessageBox.Show("Folder " + repozFolderPathFull + " already exists");
                else
                {
                    Directory.CreateDirectory(repozFolderPathFull);
                    Directory.CreateDirectory(repozFolderPathFull + @"\Doc");
                    Directory.CreateDirectory(repozFolderPathFull + @"\Temp");
                    Directory.CreateDirectory(repozFolderPathFull + @"\Support");
                    db.SendQueryToDb(@"INSERT INTO t_projects(name, folder, owner) values ('" + txtNewProjectName.Text + "','" + txtNewProjectName.Text + "','" + glob.loggedUser + "'); "); //insert new project in db
                    MessageBox.Show("Created project folder " + repozFolderPathFull);
                }
            }
            else
            {
                MessageBox.Show("Insert name for project");
            }

        }

        private void btnAdduser_Click(object sender, EventArgs e)
        {
            string memberName = txtMemberName.Text;
            string memberSurname = txtMemberSurname.Text;
            string role = comboTeamMemberRole.Text;
            string mail = txtEmail.Text;
            string username = txtUsername.Text;
            string pass = txtPassword.Text;
            string accLevel = biz.GetAccLevelString(role);

            if (!String.IsNullOrEmpty(memberName) & !String.IsNullOrEmpty(memberSurname) & !String.IsNullOrEmpty(mail) & !String.IsNullOrEmpty(username) & !String.IsNullOrEmpty(pass))
            {
                if (!sy.FindInColumn(username, "username", "t_members"))
                {
                    string sqlquery = string.Format(@"INSERT INTO t_members (username, name, surname,role,mail,pass,passlevel) values ('{0}','{1}','{2}','{3}','{4}','{5}',{6});", username, memberName, memberSurname, role, mail, pass, accLevel);
                    db.SendQueryToDb(sqlquery);
                    Directory.CreateDirectory(sy.GetUsersWorkingFolderPath(username));
                    MessageBox.Show("Added user " + username);

                    listViewUsers.Items.Clear();
                    string sqlString = string.Format(@"SELECT DISTINCT * FROM t_members"); //Load list of all users
                    db.LoadVeiwListUsers(listViewUsers, sqlString);
                }
                else
                {
                    MessageBox.Show("Username is already used");
                }
            }
            else
            {
                MessageBox.Show("Not all fields are inserted");
            }
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedItems.Count > 0) //if file is selected
            {
                String userName = listViewUsers.SelectedItems[0].SubItems[2].Text; //selected username
                string sqlquery = string.Format(@"DELETE FROM t_members WHERE username like '{0}';", userName);
                db.SendQueryToDb(sqlquery);
                
                string sqlString = string.Format(@"SELECT DISTINCT * FROM t_members"); //Load list of all users
                listViewUsers.Items.Clear();
                db.LoadVeiwListUsers(listViewUsers, sqlString);

                MessageBox.Show("User " + userName + " is deleted");
            }
            else
            {
                MessageBox.Show("User is not selected");
            }



        }
    }

}
