namespace Repoz
{
    partial class FormProjectSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProjectSettings));
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.labProjName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labRepozName = new System.Windows.Forms.Label();
            this.labLoggedUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.Label();
            this.btnAssignUser = new System.Windows.Forms.Button();
            this.btnRemoveUser = new System.Windows.Forms.Button();
            this.btnAddDoc = new System.Windows.Forms.Button();
            this.btnRemoveDoc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboUsers = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listProjectTeam = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBoxDoc = new System.Windows.Forms.ListBox();
            this.grpLogin.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLogin
            // 
            this.grpLogin.Controls.Add(this.labProjName);
            this.grpLogin.Controls.Add(this.label2);
            this.grpLogin.Controls.Add(this.label9);
            this.grpLogin.Controls.Add(this.labRepozName);
            this.grpLogin.Controls.Add(this.labLoggedUser);
            this.grpLogin.Controls.Add(this.txtUser);
            this.grpLogin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpLogin.ForeColor = System.Drawing.Color.Silver;
            this.grpLogin.Location = new System.Drawing.Point(3, 3);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(914, 54);
            this.grpLogin.TabIndex = 10;
            this.grpLogin.TabStop = false;
            // 
            // labProjName
            // 
            this.labProjName.AutoSize = true;
            this.labProjName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labProjName.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.labProjName.Location = new System.Drawing.Point(464, 22);
            this.labProjName.Name = "labProjName";
            this.labProjName.Size = new System.Drawing.Size(103, 18);
            this.labProjName.TabIndex = 22;
            this.labProjName.Text = "Project Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Location = new System.Drawing.Point(401, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 21;
            this.label2.Text = "Project";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label9.Location = new System.Drawing.Point(9, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 18);
            this.label9.TabIndex = 12;
            this.label9.Text = "Repository:";
            // 
            // labRepozName
            // 
            this.labRepozName.AutoSize = true;
            this.labRepozName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labRepozName.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.labRepozName.Location = new System.Drawing.Point(102, 22);
            this.labRepozName.Name = "labRepozName";
            this.labRepozName.Size = new System.Drawing.Size(125, 18);
            this.labRepozName.TabIndex = 13;
            this.labRepozName.Text = "RepositoryName";
            // 
            // labLoggedUser
            // 
            this.labLoggedUser.AutoSize = true;
            this.labLoggedUser.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labLoggedUser.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.labLoggedUser.Location = new System.Drawing.Point(780, 22);
            this.labLoggedUser.Name = "labLoggedUser";
            this.labLoggedUser.Size = new System.Drawing.Size(97, 18);
            this.labLoggedUser.TabIndex = 5;
            this.labLoggedUser.Text = "not logged in";
            // 
            // txtUser
            // 
            this.txtUser.AutoSize = true;
            this.txtUser.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtUser.Location = new System.Drawing.Point(736, 22);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(45, 18);
            this.txtUser.TabIndex = 2;
            this.txtUser.Text = "User:";
            // 
            // btnAssignUser
            // 
            this.btnAssignUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAssignUser.BackgroundImage")));
            this.btnAssignUser.FlatAppearance.BorderSize = 0;
            this.btnAssignUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssignUser.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignUser.ForeColor = System.Drawing.Color.Silver;
            this.btnAssignUser.Location = new System.Drawing.Point(323, 120);
            this.btnAssignUser.Name = "btnAssignUser";
            this.btnAssignUser.Size = new System.Drawing.Size(130, 128);
            this.btnAssignUser.TabIndex = 12;
            this.btnAssignUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAssignUser.UseCompatibleTextRendering = true;
            this.btnAssignUser.UseVisualStyleBackColor = false;
            this.btnAssignUser.Click += new System.EventHandler(this.btnAssignUser_Click);
            // 
            // btnRemoveUser
            // 
            this.btnRemoveUser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveUser.BackgroundImage")));
            this.btnRemoveUser.FlatAppearance.BorderSize = 0;
            this.btnRemoveUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveUser.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveUser.ForeColor = System.Drawing.Color.Silver;
            this.btnRemoveUser.Location = new System.Drawing.Point(323, 279);
            this.btnRemoveUser.Name = "btnRemoveUser";
            this.btnRemoveUser.Size = new System.Drawing.Size(130, 133);
            this.btnRemoveUser.TabIndex = 14;
            this.btnRemoveUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemoveUser.UseCompatibleTextRendering = true;
            this.btnRemoveUser.UseVisualStyleBackColor = false;
            this.btnRemoveUser.Click += new System.EventHandler(this.btnRemoveUser_Click);
            // 
            // btnAddDoc
            // 
            this.btnAddDoc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddDoc.BackgroundImage")));
            this.btnAddDoc.FlatAppearance.BorderSize = 0;
            this.btnAddDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDoc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDoc.ForeColor = System.Drawing.Color.Blue;
            this.btnAddDoc.Location = new System.Drawing.Point(314, 120);
            this.btnAddDoc.Name = "btnAddDoc";
            this.btnAddDoc.Size = new System.Drawing.Size(123, 128);
            this.btnAddDoc.TabIndex = 15;
            this.btnAddDoc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddDoc.UseCompatibleTextRendering = true;
            this.btnAddDoc.UseVisualStyleBackColor = false;
            this.btnAddDoc.Click += new System.EventHandler(this.btnAddDoc_Click);
            // 
            // btnRemoveDoc
            // 
            this.btnRemoveDoc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveDoc.BackgroundImage")));
            this.btnRemoveDoc.FlatAppearance.BorderSize = 0;
            this.btnRemoveDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveDoc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveDoc.ForeColor = System.Drawing.Color.Silver;
            this.btnRemoveDoc.Location = new System.Drawing.Point(317, 279);
            this.btnRemoveDoc.Name = "btnRemoveDoc";
            this.btnRemoveDoc.Size = new System.Drawing.Size(120, 128);
            this.btnRemoveDoc.TabIndex = 16;
            this.btnRemoveDoc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRemoveDoc.UseCompatibleTextRendering = true;
            this.btnRemoveDoc.UseVisualStyleBackColor = false;
            this.btnRemoveDoc.Click += new System.EventHandler(this.btnRemoveDoc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboUsers);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listProjectTeam);
            this.groupBox1.Controls.Add(this.btnAssignUser);
            this.groupBox1.Controls.Add(this.btnRemoveUser);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(3, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 427);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project team members";
            // 
            // comboUsers
            // 
            this.comboUsers.FormattingEnabled = true;
            this.comboUsers.Location = new System.Drawing.Point(9, 64);
            this.comboUsers.Name = "comboUsers";
            this.comboUsers.Size = new System.Drawing.Size(285, 26);
            this.comboUsers.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 23;
            this.label3.Text = "Users:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label1.Location = new System.Drawing.Point(7, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 22;
            this.label1.Text = "Project team:";
            // 
            // listProjectTeam
            // 
            this.listProjectTeam.FormattingEnabled = true;
            this.listProjectTeam.ItemHeight = 18;
            this.listProjectTeam.Location = new System.Drawing.Point(9, 120);
            this.listProjectTeam.Name = "listProjectTeam";
            this.listProjectTeam.Size = new System.Drawing.Size(285, 292);
            this.listProjectTeam.TabIndex = 18;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBoxDoc);
            this.groupBox2.Controls.Add(this.btnAddDoc);
            this.groupBox2.Controls.Add(this.btnRemoveDoc);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Silver;
            this.groupBox2.Location = new System.Drawing.Point(469, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 427);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Project documents";
            // 
            // listBoxDoc
            // 
            this.listBoxDoc.FormattingEnabled = true;
            this.listBoxDoc.ItemHeight = 18;
            this.listBoxDoc.Location = new System.Drawing.Point(23, 45);
            this.listBoxDoc.Name = "listBoxDoc";
            this.listBoxDoc.Size = new System.Drawing.Size(285, 364);
            this.listBoxDoc.TabIndex = 17;
            // 
            // FormProjectSettings
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(923, 515);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProjectSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormProjectSettings";
            this.Load += new System.EventHandler(this.FormProjectSettings_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormProjectSettings_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormProjectSettings_DragEnter);
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLogin;
        public System.Windows.Forms.Label labLoggedUser;
        public System.Windows.Forms.Label txtUser;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label labRepozName;
        public System.Windows.Forms.Label labProjName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAssignUser;
        private System.Windows.Forms.Button btnRemoveUser;
        private System.Windows.Forms.Button btnAddDoc;
        private System.Windows.Forms.Button btnRemoveDoc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listProjectTeam;
        private System.Windows.Forms.ListBox listBoxDoc;
        private System.Windows.Forms.ComboBox comboUsers;
    }
}