namespace Repoz
{
    partial class FormSupport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSupport));
            this.btnReturn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.grpRepoz = new System.Windows.Forms.GroupBox();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.btnSendReq = new System.Windows.Forms.Button();
            this.comboTeamMember = new System.Windows.Forms.ComboBox();
            this.richTextMsgToUser = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.richTxtIssue = new System.Windows.Forms.RichTextBox();
            this.labProjName = new System.Windows.Forms.Label();
            this.btnAttach = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.grpRepoz.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReturn.ForeColor = System.Drawing.Color.Silver;
            this.btnReturn.Location = new System.Drawing.Point(706, 524);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(146, 33);
            this.btnReturn.TabIndex = 3;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseCompatibleTextRendering = true;
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(148, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Active project:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(17, 42);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(98, 99);
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // grpRepoz
            // 
            this.grpRepoz.Controls.Add(this.btnSendMsg);
            this.grpRepoz.Controls.Add(this.label4);
            this.grpRepoz.Controls.Add(this.txtSubject);
            this.grpRepoz.Controls.Add(this.btnSendReq);
            this.grpRepoz.Controls.Add(this.comboTeamMember);
            this.grpRepoz.Controls.Add(this.richTextMsgToUser);
            this.grpRepoz.Controls.Add(this.label2);
            this.grpRepoz.Controls.Add(this.label1);
            this.grpRepoz.Controls.Add(this.richTxtIssue);
            this.grpRepoz.Controls.Add(this.labProjName);
            this.grpRepoz.Controls.Add(this.btnAttach);
            this.grpRepoz.Controls.Add(this.pictureBox2);
            this.grpRepoz.Controls.Add(this.label3);
            this.grpRepoz.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRepoz.ForeColor = System.Drawing.Color.Silver;
            this.grpRepoz.Location = new System.Drawing.Point(12, 12);
            this.grpRepoz.Name = "grpRepoz";
            this.grpRepoz.Size = new System.Drawing.Size(853, 506);
            this.grpRepoz.TabIndex = 4;
            this.grpRepoz.TabStop = false;
            this.grpRepoz.Text = "New Support request";
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.ForeColor = System.Drawing.Color.Silver;
            this.btnSendMsg.Location = new System.Drawing.Point(511, 367);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(146, 33);
            this.btnSendMsg.TabIndex = 38;
            this.btnSendMsg.Text = "Send message";
            this.btnSendMsg.UseCompatibleTextRendering = true;
            this.btnSendMsg.UseVisualStyleBackColor = false;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 18);
            this.label4.TabIndex = 37;
            this.label4.Text = "Subject:";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(151, 115);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(354, 26);
            this.txtSubject.TabIndex = 36;
            // 
            // btnSendReq
            // 
            this.btnSendReq.ForeColor = System.Drawing.Color.Silver;
            this.btnSendReq.Location = new System.Drawing.Point(694, 367);
            this.btnSendReq.Name = "btnSendReq";
            this.btnSendReq.Size = new System.Drawing.Size(146, 33);
            this.btnSendReq.TabIndex = 35;
            this.btnSendReq.Text = "Send request";
            this.btnSendReq.UseCompatibleTextRendering = true;
            this.btnSendReq.UseVisualStyleBackColor = false;
            this.btnSendReq.Click += new System.EventHandler(this.btnSendReq_Click);
            // 
            // comboTeamMember
            // 
            this.comboTeamMember.FormattingEnabled = true;
            this.comboTeamMember.Location = new System.Drawing.Point(151, 371);
            this.comboTeamMember.Name = "comboTeamMember";
            this.comboTeamMember.Size = new System.Drawing.Size(354, 26);
            this.comboTeamMember.TabIndex = 34;
            // 
            // richTextMsgToUser
            // 
            this.richTextMsgToUser.Location = new System.Drawing.Point(151, 406);
            this.richTextMsgToUser.Name = "richTextMsgToUser";
            this.richTextMsgToUser.Size = new System.Drawing.Size(689, 80);
            this.richTextMsgToUser.TabIndex = 33;
            this.richTextMsgToUser.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(260, 18);
            this.label2.TabIndex = 32;
            this.label2.Text = "Message to team member(optional):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 18);
            this.label1.TabIndex = 31;
            this.label1.Text = "Isssue description:";
            // 
            // richTxtIssue
            // 
            this.richTxtIssue.Location = new System.Drawing.Point(151, 183);
            this.richTxtIssue.Name = "richTxtIssue";
            this.richTxtIssue.Size = new System.Drawing.Size(689, 147);
            this.richTxtIssue.TabIndex = 30;
            this.richTxtIssue.Text = "";
            // 
            // labProjName
            // 
            this.labProjName.AutoSize = true;
            this.labProjName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labProjName.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.labProjName.Location = new System.Drawing.Point(260, 42);
            this.labProjName.Name = "labProjName";
            this.labProjName.Size = new System.Drawing.Size(103, 18);
            this.labProjName.TabIndex = 29;
            this.labProjName.Text = "Project Name";
            // 
            // btnAttach
            // 
            this.btnAttach.ForeColor = System.Drawing.Color.Silver;
            this.btnAttach.Location = new System.Drawing.Point(511, 111);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(146, 33);
            this.btnAttach.TabIndex = 28;
            this.btnAttach.Text = "Attach file";
            this.btnAttach.UseCompatibleTextRendering = true;
            this.btnAttach.UseVisualStyleBackColor = false;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // FormSupport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.ClientSize = new System.Drawing.Size(877, 569);
            this.Controls.Add(this.grpRepoz);
            this.Controls.Add(this.btnReturn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSupport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSupport";
            this.Load += new System.EventHandler(this.FormSupport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.grpRepoz.ResumeLayout(false);
            this.grpRepoz.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.GroupBox grpRepoz;
        public System.Windows.Forms.Button btnAttach;
        public System.Windows.Forms.Label labProjName;
        private System.Windows.Forms.RichTextBox richTxtIssue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextMsgToUser;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btnSendReq;
        private System.Windows.Forms.ComboBox comboTeamMember;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubject;
        public System.Windows.Forms.Button btnSendMsg;
    }
}