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
    public partial class FormProjectSettings : Form
    {
        Baza db = new Baza();
        SysLogic sy = new SysLogic();

        public FormProjectSettings()
        {
            InitializeComponent();
        }

        private void FormProjectSettings_Load(object sender, EventArgs e)
        {
            this.Text = "Project settings";
            string sqlString = null;
            Baza db = new Baza();
            labRepozName.Text = db.GetRepozName(); 
            labLoggedUser.Text = glob.loggedUser;
            labProjName.Text = glob.ProjectName;
            sqlString = @"SELECT username FROM t_members;";
            db.LoadCombo(comboUsers, "username", sqlString);
            listProjectTeam.Items.Clear();
            sqlString = string.Format(@"SELECT username FROM t_team WHERE project like'{0}';", glob.ProjectName);
            db.LoadTextList(listProjectTeam, "username", sqlString);
            sqlString = string.Format(@"SELECT filename FROM t_doc WHERE project like'{0}';", glob.ProjectName);

            db.LoadTextList(listBoxDoc, "filename", sqlString);
        }

        private void btnAssignUser_Click(object sender, EventArgs e)
        {
            string sqlString = null;
            String username = comboUsers.Text;
            sqlString = string.Format(@"INSERT INTO  t_team (username, project) values( '{0}', '{1}');", username, glob.ProjectName);
            db.SendQueryToDb(sqlString);
            listProjectTeam.Items.Clear();
            sqlString = string.Format(@"SELECT username FROM t_team WHERE project like'{0}';", glob.ProjectName);
            db.LoadTextList(listProjectTeam, "username", sqlString);
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            string sqlString = null;
            string userToRemove = null;
            userToRemove = listProjectTeam.GetItemText(listProjectTeam.SelectedItem);
            if (!string.IsNullOrEmpty(userToRemove))
            {
                sqlString = string.Format(@"DELETE FROM t_team WHERE username like'{0}';", userToRemove);
                db.SendQueryToDb(sqlString);
                listProjectTeam.Items.Clear();
                sqlString = string.Format(@"SELECT username FROM t_team WHERE project like'{0}';", glob.ProjectName);
                db.LoadTextList(listProjectTeam, "username", sqlString);

            }
            else
            {
                MessageBox.Show("Select team member form the list");
            }

        }

        private void btnAddDoc_Click(object sender, EventArgs e)  //Add new file in project folder
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string sourceFullPath = ofd.FileName; //full path
                string sourceFile = ofd.SafeFileName; //file name
                string path = sourceFullPath.Replace(sourceFile, ""); //folder path
                string projPath = db.GetRepozPath() + @"\\" + db.GetRepozName() + @"\\Projects\\" + glob.ProjectName + @"\\Doc";
                string targetFile = projPath + @"\\" + sourceFile;

                if (!sy.FindInColumn(sourceFile, "filename", "t_doc"))
                {

                    if (!File.Exists(targetFile))
                    {
                        File.Copy(sourceFullPath, Path.Combine(projPath, ofd.SafeFileName)); //Copy selected file to project folder

                        string sqlString = null; // New file entry in db
                        sqlString = string.Format(@"INSERT INTO t_doc (filename,project,owner,commituser,locked,rev) values ('{0}', '{1}', '{2}', '{2}', 0, 0 );", sourceFile, glob.ProjectName, glob.loggedUser);
                        db.SendQueryToDb(sqlString);
                        listBoxDoc.Items.Clear();  //Clear document list, and reload form db
                        sqlString = string.Format(@"SELECT filename FROM t_doc WHERE project like'{0}';", glob.ProjectName);
                        db.LoadTextList(listBoxDoc, "filename", sqlString);
                    }
                    else MessageBox.Show("File already exists in project folder");
                }
                else MessageBox.Show("File with this name is already added in this(or another) project");
            }
        }

        private void FormProjectSettings_DragEnter(object sender, DragEventArgs e) //Get data form Drag event
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void FormProjectSettings_DragDrop(object sender, DragEventArgs e) //Do on drop event
        {
            String[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in droppedFiles)
            {
                string sourcefile = getFileName(file);
                string sourceFullPath = Path.Combine(getFolderPath(file), sourcefile);
                string projPath = db.GetRepozPath() + @"\\" + db.GetRepozName() + @"\\Projects\\" + glob.ProjectName + @"\\Doc";
                string targetFile = projPath + @"\\" + sourcefile;

                if (!File.Exists(targetFile))
                {
                    File.Copy(sourceFullPath, Path.Combine(projPath, sourcefile)); //sourcefile selected file to project folder
                    string sqlString = null; // New file entry in db
                    sqlString = string.Format(@"INSERT INTO t_doc (filename,project,owner,commituser,locked,rev) values ('{0}', '{1}', '{2}', '{2}', 0, 0 );", sourcefile, glob.ProjectName, glob.loggedUser);
                    db.SendQueryToDb(sqlString);
                    listBoxDoc.Items.Clear();  //Clear document list, and reload form db
                    sqlString = string.Format(@"SELECT filename FROM t_doc WHERE project like'{0}';", glob.ProjectName);
                    db.LoadTextList(listBoxDoc, "filename", sqlString);
                }
                else
                {
                    MessageBox.Show("File already exists in project folder");
                }
            }
        }

        //get file name
        private string getFileName(string path)
        {
            return Path.GetFileName(path);
        }

        //get folder path
        private string getFolderPath(string path)
        {
            //return Path.GetFullPath(path);
            return Path.GetDirectoryName(path);
        }

        private void btnRemoveDoc_Click(object sender, EventArgs e)
        {
            string sqlString = null;
            string fileToRemove = null;
            string projPath = null;
            fileToRemove = listBoxDoc.GetItemText(listBoxDoc.SelectedItem);
            if (!string.IsNullOrEmpty(fileToRemove))
            {
                projPath = db.GetRepozPath() + @"\\" + db.GetRepozName() + @"\\Projects\\" + glob.ProjectName + @"\\Doc\\" + fileToRemove;
                if (File.Exists(projPath)) File.Delete(projPath);  // Delete file in project folder             

                sqlString = string.Format(@"DELETE FROM t_doc WHERE filename like'{0}';", fileToRemove); //remove db entry
                db.SendQueryToDb(sqlString);
                listBoxDoc.Items.Clear();  //Clear document list, and reload form db
                sqlString = string.Format(@"SELECT filename FROM t_doc WHERE project like'{0}';", glob.ProjectName);
                db.LoadTextList(listBoxDoc, "filename", sqlString);
            }
            else
            {
                MessageBox.Show("Select document form the list");
            }
        }

    }
}
