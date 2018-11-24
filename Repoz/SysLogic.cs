using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace Repoz
{
    class SysLogic
    {
        Baza db = new Baza();
        public void ClearFolder(string FolderName)
        {
            try
            {
                if (Directory.Exists(FolderName))
                {
                    DirectoryInfo dir = new DirectoryInfo(FolderName);
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        fi.Delete();
                    }
                    foreach (DirectoryInfo di in dir.GetDirectories())
                    {
                        ClearFolder(di.FullName);
                        di.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
}

        public void DeleteFile(string fileName, string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    DirectoryInfo dir = new DirectoryInfo(folderPath);
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        string fiName = fi.Name;
                        if (fiName == fileName) fi.Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public string GetUsersWorkingFolderPath(string username)
        {
            string WorkingFolderPath = Path.Combine(db.GetRepozPath(), db.GetRepozName(), "Users", username);
            return WorkingFolderPath;
        }

        public bool FindInColumn(string valToCheck, string column, string table) //Check if valToCheck is already in table
        {
            string foundValue = null;
            string sqlString = null;
            bool FoundDuplicates = false;

            sqlString = string.Format(@"SELECT {0} FROM {1} WHERE {0} like '{2}';", column, table, valToCheck); 
            foundValue = db.GetSingleLastValue(sqlString, column);
            if (!String.IsNullOrEmpty(foundValue)) FoundDuplicates = true;

            return FoundDuplicates;
        }

        public string GetNameSurnameFromUsername(string username)
        {
            string name = null;
            string surName = null;
            string nameSurname = null;
            string sqlString = null;
            sqlString = string.Format(@"SELECT name FROM t_members WHERE username like '{0}';", username);
            name  = db.GetSingleLastValue(sqlString, "name");
            sqlString = string.Format(@"SELECT surname FROM t_members WHERE username like '{0}';", username);
            surName = db.GetSingleLastValue(sqlString, "surname");
            nameSurname = name + " " + surName;

            return nameSurname;
        }

    }
}
