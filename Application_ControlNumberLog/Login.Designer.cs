namespace Application_ControlNumberLog
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.labelFailPassword = new System.Windows.Forms.Label();
            this.Cancel = new System.Windows.Forms.Button();
            this.Ok = new System.Windows.Forms.Button();
            this.dropName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserlevel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.motionDataSet = new Application_ControlNumberLog.MotionDataSet();
            this.user_InfoTableAdapter = new Application_ControlNumberLog.MotionDataSetTableAdapters.User_InfoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.motionDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFailPassword
            // 
            this.labelFailPassword.AutoSize = true;
            this.labelFailPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.labelFailPassword.ForeColor = System.Drawing.Color.Red;
            this.labelFailPassword.Location = new System.Drawing.Point(90, 69);
            this.labelFailPassword.Name = "labelFailPassword";
            this.labelFailPassword.Size = new System.Drawing.Size(137, 13);
            this.labelFailPassword.TabIndex = 24;
            this.labelFailPassword.Text = "This password is not valid...";
            // 
            // Cancel
            // 
            this.Cancel.AutoSize = true;
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Cancel.Location = new System.Drawing.Point(154, 191);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(96, 29);
            this.Cancel.TabIndex = 21;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Ok
            // 
            this.Ok.AutoSize = true;
            this.Ok.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Ok.Location = new System.Drawing.Point(37, 191);
            this.Ok.Name = "Ok";
            this.Ok.Size = new System.Drawing.Size(96, 29);
            this.Ok.TabIndex = 20;
            this.Ok.Text = "Ok";
            this.Ok.UseVisualStyleBackColor = true;
            this.Ok.Click += new System.EventHandler(this.Ok_Click);
            // 
            // dropName
            // 
            this.dropName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.dropName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.dropName.FormattingEnabled = true;
            this.dropName.Location = new System.Drawing.Point(110, 93);
            this.dropName.Name = "dropName";
            this.dropName.Size = new System.Drawing.Size(165, 28);
            this.dropName.TabIndex = 16;
            this.dropName.SelectedIndexChanged += new System.EventHandler(this.dropName_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Name";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(110, 138);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.MaxLength = 25;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(165, 26);
            this.txtPassword.TabIndex = 18;
            // 
            // txtUserlevel
            // 
            this.txtUserlevel.Enabled = false;
            this.txtUserlevel.Location = new System.Drawing.Point(28, 31);
            this.txtUserlevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserlevel.Name = "txtUserlevel";
            this.txtUserlevel.ReadOnly = true;
            this.txtUserlevel.Size = new System.Drawing.Size(247, 26);
            this.txtUserlevel.TabIndex = 19;
            this.txtUserlevel.TabStop = false;
            this.txtUserlevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "User Level";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "User_Info";
            this.bindingSource1.DataSource = this.motionDataSet;
            // 
            // motionDataSet
            // 
            this.motionDataSet.DataSetName = "MotionDataSet";
            this.motionDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // user_InfoTableAdapter
            // 
            this.user_InfoTableAdapter.ClearBeforeFill = true;
            // 
            // Login
            // 
            this.AcceptButton = this.Ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(290, 242);
            this.Controls.Add(this.labelFailPassword);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Ok);
            this.Controls.Add(this.dropName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserlevel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.motionDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFailPassword;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Ok;
        private System.Windows.Forms.ComboBox dropName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserlevel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private MotionDataSet motionDataSet;
        private MotionDataSetTableAdapters.User_InfoTableAdapter user_InfoTableAdapter;
    }
}