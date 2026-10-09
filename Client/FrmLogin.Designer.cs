namespace Client
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblKorIme = new Label();
            label2 = new Label();
            txtKorIme = new TextBox();
            txtSifra = new TextBox();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblKorIme
            // 
            lblKorIme.AutoSize = true;
            lblKorIme.Location = new Point(66, 51);
            lblKorIme.Name = "lblKorIme";
            lblKorIme.Size = new Size(88, 15);
            lblKorIme.TabIndex = 0;
            lblKorIme.Text = "Korisnicko ime:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(121, 96);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 1;
            label2.Text = "Sifra:";
            // 
            // txtKorIme
            // 
            txtKorIme.Location = new Point(177, 51);
            txtKorIme.Name = "txtKorIme";
            txtKorIme.Size = new Size(204, 23);
            txtKorIme.TabIndex = 2;
            // 
            // txtSifra
            // 
            txtSifra.Location = new Point(177, 93);
            txtSifra.Name = "txtSifra";
            txtSifra.Size = new Size(204, 23);
            txtSifra.TabIndex = 3;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(66, 141);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(315, 43);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "LOGIN";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 209);
            Controls.Add(btnLogin);
            Controls.Add(txtSifra);
            Controls.Add(txtKorIme);
            Controls.Add(label2);
            Controls.Add(lblKorIme);
            Name = "FrmLogin";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblKorIme;
        private Label label2;
        private TextBox txtKorIme;
        private TextBox txtSifra;
        private Button btnLogin;
    }
}
