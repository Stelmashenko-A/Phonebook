namespace UserInterface
{
    partial class NewUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.dataGridViewPhones = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAddNumber = new System.Windows.Forms.Button();
            this.buttonRemovePhone = new System.Windows.Forms.Button();
            this.buttonSaveAccount = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhones)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Full name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(58, 9);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(245, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // dataGridViewPhones
            // 
            this.dataGridViewPhones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPhones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Description});
            this.dataGridViewPhones.Location = new System.Drawing.Point(58, 35);
            this.dataGridViewPhones.Name = "dataGridViewPhones";
            this.dataGridViewPhones.Size = new System.Drawing.Size(245, 107);
            this.dataGridViewPhones.TabIndex = 2;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Phones";
            // 
            // buttonAddNumber
            // 
            this.buttonAddNumber.Location = new System.Drawing.Point(58, 148);
            this.buttonAddNumber.Name = "buttonAddNumber";
            this.buttonAddNumber.Size = new System.Drawing.Size(94, 23);
            this.buttonAddNumber.TabIndex = 4;
            this.buttonAddNumber.Text = "Add number";
            this.buttonAddNumber.UseVisualStyleBackColor = true;
            this.buttonAddNumber.Click += new System.EventHandler(this.buttonAddNumber_Click);
            // 
            // buttonRemovePhone
            // 
            this.buttonRemovePhone.Location = new System.Drawing.Point(206, 148);
            this.buttonRemovePhone.Name = "buttonRemovePhone";
            this.buttonRemovePhone.Size = new System.Drawing.Size(94, 23);
            this.buttonRemovePhone.TabIndex = 5;
            this.buttonRemovePhone.Text = "Remove phone";
            this.buttonRemovePhone.UseVisualStyleBackColor = true;
            this.buttonRemovePhone.Click += new System.EventHandler(this.buttonRemovePhone_Click);
            // 
            // buttonSaveAccount
            // 
            this.buttonSaveAccount.Location = new System.Drawing.Point(58, 177);
            this.buttonSaveAccount.Name = "buttonSaveAccount";
            this.buttonSaveAccount.Size = new System.Drawing.Size(245, 23);
            this.buttonSaveAccount.TabIndex = 6;
            this.buttonSaveAccount.Text = "Save account";
            this.buttonSaveAccount.UseVisualStyleBackColor = true;
            this.buttonSaveAccount.Click += new System.EventHandler(this.buttonSaveAccount_Click);
            // 
            // NewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 219);
            this.Controls.Add(this.buttonSaveAccount);
            this.Controls.Add(this.buttonRemovePhone);
            this.Controls.Add(this.buttonAddNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewPhones);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "NewUser";
            this.Text = "NewUser";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPhones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.DataGridView dataGridViewPhones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonAddNumber;
        private System.Windows.Forms.Button buttonRemovePhone;
        private System.Windows.Forms.Button buttonSaveAccount;
    }
}