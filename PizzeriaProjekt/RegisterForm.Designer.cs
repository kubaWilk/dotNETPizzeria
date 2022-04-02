namespace PizzeriaProjekt
{
    partial class RegisterForm
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.surnnameBox = new System.Windows.Forms.TextBox();
            this.phonenrBox = new System.Windows.Forms.TextBox();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.confirmPassword = new System.Windows.Forms.TextBox();
            this.rulesBox = new System.Windows.Forms.CheckBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.rulesLink = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.rulesPanel = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.rulesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(83, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(650, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dołącz do grona smakoszy w kilku prostych krokach!";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(338, 72);
            this.nameBox.Name = "nameBox";
            this.nameBox.PlaceholderText = "Imię";
            this.nameBox.Size = new System.Drawing.Size(100, 23);
            this.nameBox.TabIndex = 1;
            // 
            // surnnameBox
            // 
            this.surnnameBox.Location = new System.Drawing.Point(338, 131);
            this.surnnameBox.Name = "surnnameBox";
            this.surnnameBox.PlaceholderText = "Nazwisko";
            this.surnnameBox.Size = new System.Drawing.Size(100, 23);
            this.surnnameBox.TabIndex = 2;
            // 
            // phonenrBox
            // 
            this.phonenrBox.Location = new System.Drawing.Point(338, 194);
            this.phonenrBox.Name = "phonenrBox";
            this.phonenrBox.PlaceholderText = "Numer Telefonu";
            this.phonenrBox.Size = new System.Drawing.Size(100, 23);
            this.phonenrBox.TabIndex = 3;
            // 
            // emailBox
            // 
            this.emailBox.Location = new System.Drawing.Point(338, 248);
            this.emailBox.Name = "emailBox";
            this.emailBox.PlaceholderText = "Email";
            this.emailBox.Size = new System.Drawing.Size(100, 23);
            this.emailBox.TabIndex = 4;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(338, 292);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.PlaceholderText = "Hasło";
            this.passwordBox.Size = new System.Drawing.Size(100, 23);
            this.passwordBox.TabIndex = 5;
            // 
            // confirmPassword
            // 
            this.confirmPassword.Location = new System.Drawing.Point(338, 344);
            this.confirmPassword.Name = "confirmPassword";
            this.confirmPassword.PasswordChar = '*';
            this.confirmPassword.PlaceholderText = "Potwierdź hasło";
            this.confirmPassword.Size = new System.Drawing.Size(100, 23);
            this.confirmPassword.TabIndex = 6;
            // 
            // rulesBox
            // 
            this.rulesBox.AutoCheck = false;
            this.rulesBox.AutoSize = true;
            this.rulesBox.Location = new System.Drawing.Point(62, 394);
            this.rulesBox.Name = "rulesBox";
            this.rulesBox.Size = new System.Drawing.Size(15, 14);
            this.rulesBox.TabIndex = 7;
            this.rulesBox.UseVisualStyleBackColor = true;
            this.rulesBox.Click += new System.EventHandler(this.rulesBox_Click);
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(302, 394);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(161, 23);
            this.registerButton.TabIndex = 8;
            this.registerButton.Text = "Zarejestruj się!";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // rulesLink
            // 
            this.rulesLink.AutoSize = true;
            this.rulesLink.Location = new System.Drawing.Point(104, 408);
            this.rulesLink.Name = "rulesLink";
            this.rulesLink.Size = new System.Drawing.Size(107, 15);
            this.rulesLink.TabIndex = 9;
            this.rulesLink.TabStop = true;
            this.rulesLink.Text = "Regulamin Serwisu";
            this.rulesLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.rulesLink_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 393);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Zapoznałem się i akceptuję";
            // 
            // rulesPanel
            // 
            this.rulesPanel.Controls.Add(this.richTextBox1);
            this.rulesPanel.Location = new System.Drawing.Point(139, 41);
            this.rulesPanel.Name = "rulesPanel";
            this.rulesPanel.Size = new System.Drawing.Size(519, 347);
            this.rulesPanel.TabIndex = 11;
            this.rulesPanel.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(519, 347);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rulesPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rulesLink);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.rulesBox);
            this.Controls.Add(this.confirmPassword);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.phonenrBox);
            this.Controls.Add(this.surnnameBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.Name = "RegisterForm";
            this.Text = "Formularz Rejestracyjny";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.rulesPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox nameBox;
        private TextBox surnnameBox;
        private TextBox phonenrBox;
        private TextBox emailBox;
        private TextBox passwordBox;
        private TextBox confirmPassword;
        private CheckBox rulesBox;
        private Button registerButton;
        private LinkLabel rulesLink;
        private Label label2;
        private Panel rulesPanel;
        private RichTextBox richTextBox1;
    }
}