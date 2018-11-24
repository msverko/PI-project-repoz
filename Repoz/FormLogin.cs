using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Repoz
{
    public partial class FormLogin : Form
        
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        Baza db = new Baza();

        private void FormLogin_Load(object sender, EventArgs e)
        {
            glob.ProjectName = null;
            glob.loggedUser = null;
            glob.passLevel = 0;
            string sqlString = @"SELECT username FROM t_members;";
            db.LoadCombo(comboUsers, "username", sqlString);
        }

        private void btnLoginEnter_Click(object sender, EventArgs e)
        {

            string sqlString = @"SELECT pass FROM t_members WHERE username LIKE '" + comboUsers.Text + @"' ;";
            if (txtPasswordEntered.Text == db.GetSingleLastValue(sqlString, "pass"))
            {
                sqlString = @"SELECT name FROM t_members WHERE username LIKE '" + comboUsers.Text + @"' ;";
                string name = db.GetSingleLastValue(sqlString, "name");
                sqlString = @"SELECT surname FROM t_members WHERE username LIKE '" + comboUsers.Text + @"' ;";
                string surname = db.GetSingleLastValue(sqlString, "surname");
                MessageBox.Show("logged in:  " + name + " " + surname);

                sqlString = @"SELECT passlevel FROM t_members WHERE username LIKE '" + comboUsers.Text + @"' ;";
                glob.passLevel = Convert.ToInt32(db.GetSingleLastValue(sqlString, "passlevel")); //Transfer user and passsword level to static class members).
                glob.loggedUser = comboUsers.Text;
                sqlString = @"SELECT role FROM t_members WHERE username LIKE '" + comboUsers.Text + @"' ;";
                glob.role = db.GetSingleLastValue(sqlString, "role");

                this.Hide();
                FormStart frm = new FormStart();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong user name or password");
            }
        }


    }
}
