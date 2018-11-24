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
    public partial class FormTeamMembers : Form
    {
        Baza db = new Baza();
        public FormTeamMembers()
        {
            InitializeComponent();
        }

        private void FormTeamMembers_Load(object sender, EventArgs e)
        {

            this.Text = "Project team members";
            labProjName.Text = glob.ProjectName;
            listViewTeam.Items.Clear();
            string sqlString = string.Format(@"SELECT DISTINCT * FROM t_team,t_members WHERE t_team.project LIKE '{0}' AND t_team.username like t_members.username ;", glob.ProjectName);
            db.LoadVeiwListUsers(listViewTeam, sqlString);
        }
    }
}
