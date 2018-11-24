namespace Repoz
{
    partial class FormTeamMembers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTeamMembers));
            this.grpRepoz = new System.Windows.Forms.GroupBox();
            this.labProjName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewTeam = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.grpRepoz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // grpRepoz
            // 
            this.grpRepoz.Controls.Add(this.labProjName);
            this.grpRepoz.Controls.Add(this.label1);
            this.grpRepoz.Controls.Add(this.listViewTeam);
            this.grpRepoz.Controls.Add(this.pictureBox3);
            this.grpRepoz.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRepoz.ForeColor = System.Drawing.Color.Silver;
            this.grpRepoz.Location = new System.Drawing.Point(12, 12);
            this.grpRepoz.Name = "grpRepoz";
            this.grpRepoz.Size = new System.Drawing.Size(979, 317);
            this.grpRepoz.TabIndex = 4;
            this.grpRepoz.TabStop = false;
            this.grpRepoz.Text = "Team members";
            // 
            // labProjName
            // 
            this.labProjName.AutoSize = true;
            this.labProjName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labProjName.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.labProjName.Location = new System.Drawing.Point(13, 67);
            this.labProjName.Name = "labProjName";
            this.labProjName.Size = new System.Drawing.Size(103, 18);
            this.labProjName.TabIndex = 31;
            this.labProjName.Text = "Project Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Active Project:";
            // 
            // listViewTeam
            // 
            this.listViewTeam.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader3,
            this.columnHeader6});
            this.listViewTeam.FullRowSelect = true;
            this.listViewTeam.GridLines = true;
            this.listViewTeam.Location = new System.Drawing.Point(172, 40);
            this.listViewTeam.MultiSelect = false;
            this.listViewTeam.Name = "listViewTeam";
            this.listViewTeam.Size = new System.Drawing.Size(773, 254);
            this.listViewTeam.TabIndex = 29;
            this.listViewTeam.UseCompatibleStateImageBehavior = false;
            this.listViewTeam.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Surname";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Username";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Role";
            this.columnHeader5.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Level";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "E-mail";
            this.columnHeader6.Width = 200;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(16, 149);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(137, 143);
            this.pictureBox3.TabIndex = 28;
            this.pictureBox3.TabStop = false;
            // 
            // FormTeamMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(1004, 344);
            this.Controls.Add(this.grpRepoz);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTeamMembers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormTeamMembers";
            this.Load += new System.EventHandler(this.FormTeamMembers_Load);
            this.grpRepoz.ResumeLayout(false);
            this.grpRepoz.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox grpRepoz;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ListView listViewTeam;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        public System.Windows.Forms.Label labProjName;
        private System.Windows.Forms.Label label1;
    }
}