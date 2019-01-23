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
using System.Data.SQLite;
using System.Diagnostics;

namespace Repoz
{
    public partial class FormStart : Form

    {
        Baza db = new Baza();
        SysLogic sy = new SysLogic();
        
        public FormStart()
        {
            InitializeComponent();           
            labRepozName.Text = db.GetRepozName(); //show repository name in label on the form(if repository is created and in t_repoz table).
            labLoggedUser.Text = glob.loggedUser;
            labRole.Text = glob.role;
            labLevel.Text = Convert.ToString(glob.passLevel);
            db.GetProjectsInCombo(comboProjects);
            labProjName.Text = glob.ProjectName;            
        }


        private void FormStart_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Text = "Main form";
            if (glob.passLevel < 9 && labRepozName.Text == "No repository loaded")
            {
                MessageBox.Show("No repository created !!! - Login with access level above 8", "No repository !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (glob.passLevel < 9 ) btnSettings.Visible = false;
            if (glob.role != "Commissioning eng.") btnSupport.Visible = false;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormSettings FrmSet  = new FormSettings();
            this.Hide();
            FrmSet.ShowDialog();
            this.Show();

            //Refresh does not work, so....manualy :)
            Baza db = new Baza();
            labRepozName.Text = db.GetRepozName(); //show repository name in label on the form(if repository is created and in t_repoz table).
            labProjName.Text = glob.ProjectName;
            db.GetProjectsInCombo(comboProjects);
            if (!String.IsNullOrEmpty(glob.ProjectName)) { comboProjects.Text = glob.ProjectName; }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sqlString = string.Format(@"SELECT filename FROM t_workingdoc WHERE workinguser LIKE '{0}';", glob.loggedUser); //check if there is notcommited file
            string FileNotCommited = (db.GetSingleLastValue(sqlString, "filename"));
            if (String.IsNullOrEmpty(FileNotCommited))
            {
                string TempFolderPath = db.GetRepozPath() + @"\\" + db.GetRepozName() + @"\\Temp"; //Delete repository temp folder
                sy.ClearFolder(TempFolderPath);
                this.Hide();
                FormLogin FrmLogin = new FormLogin();
                FrmLogin.ShowDialog();
                //this.Close();
            }
            else
            {
                MessageBox.Show("There are documents to be commited before exit");
            }
        }

        private void btnOpenProject_Click_1(object sender, EventArgs e) //Opens(activates) selected project, and enables project setting button
        {
            if (listBoxWorkDoc.Items.Count < 1)
            {
                if (!String.IsNullOrEmpty(comboProjects.Text))
                {
                    string sqlString = null;
                    string TempFolderPath = null;
                    glob.ProjectName = comboProjects.SelectedValue.ToString();
                    labProjName.Text = glob.ProjectName;
                    btnProjSet.Enabled = true; //Enable button for project settings form open
                    listViewProjDoc.Items.Clear(); //Clear list, and load all file names from db (Query is hardcoded)
                    db.LoadVeiwListProjectDocuments(listViewProjDoc);

                    listBoxWorkDoc.Items.Clear(); //Load working docs
                    sqlString = string.Format(@"SELECT * FROM t_workingdoc WHERE workinguser LIKE '{0}';", glob.loggedUser); //Load listBox - working folder
                    db.LoadTextList(listBoxWorkDoc, "filename", sqlString);

                    TempFolderPath = db.GetRepozPath() + @"\\" + db.GetRepozName() + @"\\Temp"; //Delete repository temp folder
                    sy.ClearFolder(TempFolderPath);

                    listViewSupport.Items.Clear(); //Load suport requests
                    db.LoadVeiwListSupportRequests(listViewSupport);
                    //Load comboMsg with message subjects and sent-timestamp
                    comboMsgSubject.Text = null;
                    textBoxMsgFrom.Text = null;
                    textBoxMessageBody.Text = null;
                    sqlString = string.Format(@"SELECT * FROM t_msg WHERE project LIKE '{0}' AND receiver LIKE '{1}' AND deleted = 0;", glob.ProjectName, glob.loggedUser); 
                    db.LoadComboMsgTopicTimesamp(comboMsgSubject, sqlString);
                }
                else MessageBox.Show("No project selected");
            }
            else MessageBox.Show("There are documents to be commited before exiting active project");
        }

        private void btnProjSet_Click(object sender, EventArgs e)
        { 
            if (!String.IsNullOrEmpty(glob.ProjectName) && glob.passLevel > 8)
            {
                FormProjectSettings FrmProjSet = new FormProjectSettings();
                FrmProjSet.ShowDialog();
                //Refresh does not work, so....manualy :)
                Baza db = new Baza();
                labRepozName.Text = db.GetRepozName(); //show repository name in label on the form(if repository is created and in t_repoz table).
                labProjName.Text = glob.ProjectName;
                db.GetProjectsInCombo(comboProjects);
                listViewProjDoc.Items.Clear(); //Clear list, and load all file names from db (Query is hardcoded)
                db.LoadVeiwListProjectDocuments(listViewProjDoc);
            }
            else MessageBox.Show("No active project or access level < 9");
        }

        private void btnEditDoc_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(glob.ProjectName) & (sy.FindInColumn(glob.loggedUser, "username", "t_team") == true))
            {
                string sqlString = null;
                string TempFolderPath = db.GetRepozPath() + @"\\" + db.GetRepozName() + @"\\Temp"; //Delete repository temp folder

                if (listViewProjDoc.SelectedItems.Count < 1) //if NO file is selected
                {
                    MessageBox.Show("Document is not selected");
                }
                else
                {
                    String DocName = listViewProjDoc.SelectedItems[0].SubItems[0].Text; //selected item
                    sqlString = string.Format(@"SELECT locked FROM t_doc WHERE filename like '{0}';", DocName); //Check if file is locked
                    string locked = db.GetSingleLastValue(sqlString, "locked");

                    if (locked == "True") //if file is locked (already loaded in working folder)
                    {
                        MessageBox.Show("Document is locked for editing");
                    }
                    else
                    {
                        string SourcePath = Path.Combine(db.GetRepozPath(), db.GetRepozName(), "Projects", glob.ProjectName, "Doc", DocName);
                        string DestinationPath = Path.Combine(sy.GetUsersWorkingFolderPath(glob.loggedUser), DocName);
                        File.Copy(SourcePath, DestinationPath); //Copy selected file from project Doc folder to User working folder

                        sqlString = @"UPDATE t_doc SET locked = 1 WHERE filename like '" + DocName + "';"; //Mark the file opened for edid, as locked
                        db.SendQueryToDb(sqlString);
                        sqlString = string.Format(@"INSERT INTO t_workingdoc (filename,workinguser) VALUES ('{0}','{1}');", DocName, glob.loggedUser); //Add document on working folder list
                        db.SendQueryToDb(sqlString);

                        listBoxWorkDoc.Items.Clear();
                        sqlString = string.Format(@"SELECT * FROM t_workingdoc WHERE workinguser LIKE '{0}';", glob.loggedUser); //Load listBox - working folder
                        db.LoadTextList(listBoxWorkDoc, "filename", sqlString);

                        Process.Start(DestinationPath); //opens file in working folder
                    }
                }
        }
            else
            {
                MessageBox.Show("No active project or user is not memeber of development team");
            }

}

        private void btnOpenDoc_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(comboProjects.Text))
            {
                string TempFolderPath = db.GetRepozPath() + @"\\" + db.GetRepozName() + @"\\Temp"; //Delete repository temp folder
                sy.ClearFolder(TempFolderPath);


                if (listViewProjDoc.SelectedItems.Count > 0) //if file is selected
                {
                    String DocName = listViewProjDoc.SelectedItems[0].SubItems[0].Text; //selected item
                    string SourcePath = Path.Combine(db.GetRepozPath(), db.GetRepozName(), "Projects", glob.ProjectName, "Doc", DocName);
                    string DestinationPath = Path.Combine(TempFolderPath, DocName);
                    File.Copy(SourcePath, DestinationPath); //Copy selected file from project Doc folder to Repoz temp folder

                    Process.Start(DestinationPath);

                }
                else
                {
                    MessageBox.Show("Document is not selected");
                }
            }
            else
            {
                MessageBox.Show("No active project");
            }
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            string docName = null;
            string folderPath = null;
            string sqlString = null;
            docName = listBoxWorkDoc.GetItemText(listBoxWorkDoc.SelectedItem);

            if (listBoxWorkDoc.SelectedItems.Count > 0)
            {
                folderPath = Path.Combine(db.GetRepozPath(), db.GetRepozName(), "Projects", glob.ProjectName, "Doc");
                sy.DeleteFile(docName, folderPath); //Delete file form project Doc folder

                string SourcePath = Path.Combine(db.GetRepozPath(), db.GetRepozName(), "Users", glob.loggedUser, docName);
                string DestinationPath = Path.Combine(db.GetRepozPath(), db.GetRepozName(), "Projects", glob.ProjectName, "Doc", docName);
                File.Copy(SourcePath, DestinationPath); //Copy selected file from project Doc folder to Repoz temp folder                

                folderPath = Path.Combine(db.GetRepozPath(), db.GetRepozName(), "Users", glob.loggedUser);
                sy.DeleteFile(docName, folderPath); //Delete file form users working folder

                sqlString = string.Format(@"DELETE FROM t_workingdoc WHERE filename LIKE '{0}';", docName); //Delete file from table - working folder
                db.SendQueryToDb(sqlString);

                sqlString = @"UPDATE t_doc SET locked = 0 WHERE filename like '" + docName + "';"; //Mark the file unlocked
                db.SendQueryToDb(sqlString);

                sqlString = string.Format(@"SELECT rev FROM t_doc WHERE filename LIKE '{0}';", docName);  //ger current revision
                int irev = Convert.ToInt32(db.GetSingleLastValue(sqlString, "rev"));
                irev++;
                sqlString = string.Format(@"UPDATE t_doc SET rev = {0} WHERE filename like'{1}';", irev, docName);  //increse revision
                db.SendQueryToDb(sqlString);

                sqlString = string.Format(@"UPDATE t_doc SET commituser = '{0}' WHERE filename like'{1}';", glob.loggedUser, docName);  //change last commit user
                db.SendQueryToDb(sqlString);

                listBoxWorkDoc.Items.Clear();
                sqlString = string.Format(@"SELECT * FROM t_workingdoc WHERE workinguser LIKE '{0}';", glob.loggedUser); //Refresh - Load listBox - working folder
                db.LoadTextList(listBoxWorkDoc, "filename", sqlString);

                listViewProjDoc.Items.Clear(); //Clear list, and load all file names from db (Query is hardcoded)
                db.LoadVeiwListProjectDocuments(listViewProjDoc);
            }
            else
            {
                MessageBox.Show("No Document selected for commit");
            }
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(glob.ProjectName))
            {
                FormSupport FrmSupport = new FormSupport();
                this.Hide();
                FrmSupport.ShowDialog();
                this.Show();

                //Refresh support request list and messages
                listViewSupport.Items.Clear(); //Load suport requests
                db.LoadVeiwListSupportRequests(listViewSupport);
                //Load comboMsg with message subjects and sent-timestamp
                comboMsgSubject.Text = null;
                textBoxMsgFrom.Text = null;
                textBoxMessageBody.Text = null;
                string sqlString = null;
                sqlString = string.Format(@"SELECT * FROM t_msg WHERE project LIKE '{0}' AND receiver LIKE '{1}' AND deleted = 0;", glob.ProjectName, glob.loggedUser);
                db.LoadComboMsgTopicTimesamp(comboMsgSubject, sqlString);
            }
            else
            {
                MessageBox.Show("No active project");
            }

        }

        private void btnOpenSupport_Click(object sender, EventArgs e)
        {
            if (listViewSupport.SelectedItems.Count > 0) //if file is selected
            {
                String DirName = listViewSupport.SelectedItems[0].SubItems[0].Text; //selected item
                string dirPath = Path.Combine(db.GetRepozPath(), db.GetRepozName(), "Projects", glob.ProjectName, "Support", DirName);
                if (Directory.Exists(dirPath))
                {
                    Process.Start(dirPath);
                }

            }
            else
            {
                MessageBox.Show("Support request subject is not selected");
            }
        }

        private void btnSolved_Click(object sender, EventArgs e)
        {
            if (listViewSupport.SelectedItems.Count > 0)
            {
                String Subject = listViewSupport.SelectedItems[0].SubItems[0].Text; //selected item
                string sqlString = string.Format(@"SELECT issuesolved FROM t_support WHERE subject like '{0}';", Subject);

                if (db.GetSingleLastValue(sqlString, "issuesolved") == "False")
                {
                    string sDate = DateTime.Now.ToString("yyyy-MM-dd hh-mm-ss");
                    sqlString = string.Format(@"UPDATE t_support SET issuesolved = 1, usersolved = '{0}', solvedtime = '{1}' WHERE subject like '{2}';", glob.loggedUser, sDate, Subject); //Mark selected support request as solved
                    db.SendQueryToDb(sqlString);

                    listViewSupport.Items.Clear(); //Load suport requests
                    db.LoadVeiwListSupportRequests(listViewSupport);
                }
                else MessageBox.Show("This support request is already resolved");
            }
            else MessageBox.Show("No support request selected");
        }

        private void comboMsgSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboMsgSubject.SelectedIndex != -1)
            {
                string subject = comboMsgSubject.SelectedValue.ToString();

                //get sender in txtBox
                string sqlString = string.Format(@" SELECT sender FROM t_msg WHERE project LIKE '{0}' AND subject LIKE '{1}' AND receiver LIKE '{2}' AND deleted = 0;", glob.ProjectName, subject, glob.loggedUser);
                string user = db.GetSingleLastValue(sqlString, "sender");
                textBoxMsgFrom.Text = sy.GetNameSurnameFromUsername(user);

                //Get message text in txtBox
                sqlString = string.Format(@" SELECT message FROM t_msg WHERE project LIKE '{0}' AND subject LIKE '{1}' AND receiver LIKE '{2}' AND deleted = 0;", glob.ProjectName, subject, glob.loggedUser);
                textBoxMessageBody.Text = db.GetSingleLastValue(sqlString, "message");
            }

        }

        private void btnDeleteMsg_Click(object sender, EventArgs e)
        {
            if ((comboMsgSubject.SelectedIndex != -1) & (sy.FindInColumn(glob.loggedUser, "receiver", "t_msg") == true))
            {
                string subject = comboMsgSubject.SelectedValue.ToString();
                string sqlString = null;
                //mark message as deleted
                sqlString = string.Format(@"UPDATE t_msg SET deleted = 1 WHERE subject like '{0}' AND project LIKE '{1}' AND receiver LIKE '{2}';", subject, glob.ProjectName, glob.loggedUser); //Load combo messages for active project and user
                db.SendQueryToDb(sqlString);
                //reload
                comboMsgSubject.Text = null;
                textBoxMsgFrom.Text = null;
                textBoxMessageBody.Text = null;
                sqlString = string.Format(@"SELECT * FROM t_msg WHERE project LIKE '{0}' AND receiver LIKE '{1}' AND deleted = 0;", glob.ProjectName, glob.loggedUser); //Load combo messages for active project and user
                db.LoadComboMsgTopicTimesamp(comboMsgSubject, sqlString);

                MessageBox.Show("Deleted message:  " + subject);

            }
            else MessageBox.Show("No message is selected or message to be deleted is for another user");

        }

        private void btnTeamMembers_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(glob.ProjectName))
            {
                FormTeamMembers FrmProjSet = new FormTeamMembers();
                FrmProjSet.ShowDialog();
            }
            else MessageBox.Show("No active project");
        }

    }
}
