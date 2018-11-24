namespace Repoz
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.txtPasswordEntered = new System.Windows.Forms.TextBox();
            this.btnLoginEnter = new System.Windows.Forms.Button();
            this.comboUsers = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtPasswordEntered
            // 
            this.txtPasswordEntered.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordEntered.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPasswordEntered.Location = new System.Drawing.Point(86, 165);
            this.txtPasswordEntered.Name = "txtPasswordEntered";
            this.txtPasswordEntered.Size = new System.Drawing.Size(253, 26);
            this.txtPasswordEntered.TabIndex = 4;
            this.txtPasswordEntered.Text = "Insert password";
            // 
            // btnLoginEnter
            // 
            this.btnLoginEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoginEnter.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginEnter.ForeColor = System.Drawing.Color.Silver;
            this.btnLoginEnter.Location = new System.Drawing.Point(230, 207);
            this.btnLoginEnter.Name = "btnLoginEnter";
            this.btnLoginEnter.Size = new System.Drawing.Size(109, 33);
            this.btnLoginEnter.TabIndex = 5;
            this.btnLoginEnter.Text = "Login";
            this.btnLoginEnter.UseCompatibleTextRendering = true;
            this.btnLoginEnter.UseVisualStyleBackColor = false;
            this.btnLoginEnter.Click += new System.EventHandler(this.btnLoginEnter_Click);
            // 
            // comboUsers
            // 
            this.comboUsers.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboUsers.FormattingEnabled = true;
            this.comboUsers.Location = new System.Drawing.Point(86, 122);
            this.comboUsers.Name = "comboUsers";
            this.comboUsers.Size = new System.Drawing.Size(253, 26);
            this.comboUsers.TabIndex = 26;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(754, 381);
            this.Controls.Add(this.comboUsers);
            this.Controls.Add(this.btnLoginEnter);
            this.Controls.Add(this.txtPasswordEntered);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtPasswordEntered;
        private System.Windows.Forms.Button btnLoginEnter;
        private System.Windows.Forms.ComboBox comboUsers;
    }
}