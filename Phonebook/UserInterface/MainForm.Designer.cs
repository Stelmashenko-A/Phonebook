namespace UserInterface
{
    partial class MainForm
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
            this.listBoxUsers = new System.Windows.Forms.ListBox();
            this.dataGridViewPhones = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAddPhone = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.buttonRemoveAccount = new System.Windows.Forms.Button();
            this.buttonRemovePhone = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhones)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxUsers
            // 
            this.listBoxUsers.FormattingEnabled = true;
            this.listBoxUsers.Location = new System.Drawing.Point(12, 12);
            this.listBoxUsers.Name = "listBoxUsers";
            this.listBoxUsers.Size = new System.Drawing.Size(201, 342);
            this.listBoxUsers.TabIndex = 0;
            this.listBoxUsers.SelectedIndexChanged += new System.EventHandler(this.listBoxUsers_SelectedIndexChanged);
            // 
            // dataGridViewPhones
            // 
            this.dataGridViewPhones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPhones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Description});
            this.dataGridViewPhones.Location = new System.Drawing.Point(219, 12);
            this.dataGridViewPhones.Name = "dataGridViewPhones";
            this.dataGridViewPhones.Size = new System.Drawing.Size(243, 342);
            this.dataGridViewPhones.TabIndex = 3;
            // 
            // Number
            // 
            this.Number.HeaderText = "Number";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // buttonAddPhone
            // 
            this.buttonAddPhone.Location = new System.Drawing.Point(219, 360);
            this.buttonAddPhone.Name = "buttonAddPhone";
            this.buttonAddPhone.Size = new System.Drawing.Size(97, 23);
            this.buttonAddPhone.TabIndex = 4;
            this.buttonAddPhone.Text = "Add Phone";
            this.buttonAddPhone.UseVisualStyleBackColor = true;
            this.buttonAddPhone.Click += new System.EventHandler(this.buttonAddPhone_Click);
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Location = new System.Drawing.Point(12, 360);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(97, 23);
            this.buttonAddUser.TabIndex = 5;
            this.buttonAddUser.Text = "Add user";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            this.buttonAddUser.Click += new System.EventHandler(this.buttonAddUser_Click);
            // 
            // buttonRemoveAccount
            // 
            this.buttonRemoveAccount.Location = new System.Drawing.Point(116, 360);
            this.buttonRemoveAccount.Name = "buttonRemoveAccount";
            this.buttonRemoveAccount.Size = new System.Drawing.Size(97, 23);
            this.buttonRemoveAccount.TabIndex = 6;
            this.buttonRemoveAccount.Text = "Remove account";
            this.buttonRemoveAccount.UseVisualStyleBackColor = true;
            this.buttonRemoveAccount.Click += new System.EventHandler(this.buttonRemoveAccount_Click);
            // 
            // buttonRemovePhone
            // 
            this.buttonRemovePhone.Location = new System.Drawing.Point(365, 360);
            this.buttonRemovePhone.Name = "buttonRemovePhone";
            this.buttonRemovePhone.Size = new System.Drawing.Size(97, 23);
            this.buttonRemovePhone.TabIndex = 7;
            this.buttonRemovePhone.Text = "Remove phone";
            this.buttonRemovePhone.UseVisualStyleBackColor = true;
            this.buttonRemovePhone.Click += new System.EventHandler(this.buttonRemovePhone_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 397);
            this.Controls.Add(this.buttonRemovePhone);
            this.Controls.Add(this.buttonRemoveAccount);
            this.Controls.Add(this.buttonAddUser);
            this.Controls.Add(this.buttonAddPhone);
            this.Controls.Add(this.dataGridViewPhones);
            this.Controls.Add(this.listBoxUsers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Phonebook";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxUsers;
        private System.Windows.Forms.DataGridView dataGridViewPhones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.Button buttonAddPhone;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonRemoveAccount;
        private System.Windows.Forms.Button buttonRemovePhone;
    }
}

