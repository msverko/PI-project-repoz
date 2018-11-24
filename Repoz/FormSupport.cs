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
    public partial class FormSupport : Form
    {
        Baza db = new Baza();
        public FormSupport()
        {
            InitializeComponent();
        }

        private void FormSupport_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.Text = "Support request";
            labProjName.Text = glob.ProjectName;
            string sqlString = string.Format(@"SELECT t_members.name, t_members.surname, t_team.username FROM t_team, t_members WHERE t_team.username LIKE t_members.username AND project like '{0}';", glob.ProjectName);
            db.LoadComboNameSurname(comboTeamMember, sqlString);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //close form (retun to previous)
            this.DialogResult = DialogResult.OK;
        }

        private void btnSendReq_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSubject.Text) && !string.IsNullOrEmpty(richTxtIssue.Text))
            {
                string issueDir = txtSubject.Text;
                string supportFoledrPath = Path.Combine(db.GetRepozPath(), db.GetRepozName(), "Projects", glob.ProjectName, "Support", issueDir); //Create dir in support dir, with name form txtBox
                if (!Directory.Exists(supportFoledrPath))
                {
                    Directory.CreateDirectory(supportFoledrPath); //Create dir if not exists, but below file writes on every btn click - overwrite exsiting file(if created)
                }
                string supportFilePath = Path.Combine(db.GetRepozPath(), db.GetRepozName(), "Projects", glob.ProjectName, "Support", issueDir, "IssueDescription.rtf");
                TextWriter twr = new StreamWriter(supportFilePath);
                twr.Write(richTxtIssue.Text);
                twr.Close();

                //insert support request details in t_support
                string sqlString = string.Format(@"INSERT INTO t_support (subject,project,usersent) values ('{0}', '{1}', '{2}');", txtSubject.Text, glob.ProjectName, glob.loggedUser);
                db.SendQueryToDb(sqlString);

                MessageBox.Show("Support request for project " + glob.ProjectName + " has been generated");
                //reset elements on form
                richTxtIssue.Text = null;
                txtSubject.Text = null;
                richTextMsgToUser.Text = null;
            }
            else
            {
                MessageBox.Show("No subject enered and/or no description text");
            }

        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSubject.Text) && !string.IsNullOrEmpty(richTxtIssue.Text))
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string sourceFullPath = ofd.FileName; //full path
                    string sourceFile = ofd.SafeFileName; //file name
                    string path = sourceFullPath.Replace(sourceFile, ""); //folder path
                    string projSupportPath = db.GetRepozPath() + @"\\" + db.GetRepozName() + @"\\Projects\\" + glob.ProjectName + @"\\Support\\" + txtSubject.Text;
                    string targetFile = projSupportPath + @"\\" + sourceFile;
                    if (!Directory.Exists(projSupportPath))
                    {
                        Directory.CreateDirectory(projSupportPath); //Create dir if not exists
                    }

                    if (!File.Exists(targetFile))
                    {
                        File.Copy(sourceFullPath, Path.Combine(projSupportPath, ofd.SafeFileName)); //Copy selected file to project support folder
                    }
                    else
                    {
                        MessageBox.Show("File already exists in project folder");
                    }
                }

            }
            else
            {
                MessageBox.Show("No subject enered and/or no description text");
            }
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextMsgToUser.Text) && !string.IsNullOrEmpty(comboTeamMember.SelectedValue.ToString()) && !string.IsNullOrEmpty(txtSubject.Text)) //If there is message text, and selected user form combo.
            {
                //insert message to selected user in t_msg
                string msgReceiver = comboTeamMember.SelectedValue.ToString();
                string sqlString = string.Format(@"INSERT INTO t_msg (project,subject,sender,receiver,message) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}');", glob.ProjectName, txtSubject.Text, glob.loggedUser, msgReceiver, richTextMsgToUser.Text);
                db.SendQueryToDb(sqlString);
                MessageBox.Show("message to " + comboTeamMember.Text + " has been sent");
                richTextMsgToUser.Text = null;
            }
            else
            {
                MessageBox.Show("No subject enered and/or no message text and/or no recipient selected");
            }
        }
    }
}

