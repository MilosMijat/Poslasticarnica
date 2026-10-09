namespace Client
{
    partial class FrmMusterija
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
            label1 = new Label();
            txtIme = new TextBox();
            txtPrezime = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtBrojTelefona = new TextBox();
            label4 = new Label();
            cmbGrad = new ComboBox();
            btnDodaj = new Button();
            rbFizicko = new RadioButton();
            rbPravno = new RadioButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(95, 55);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 0;
            label1.Text = "Ime:";
            // 
            // txtIme
            // 
            txtIme.Location = new Point(95, 73);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(145, 23);
            txtIme.TabIndex = 1;
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(95, 117);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(145, 23);
            txtPrezime.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 99);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 2;
            label2.Text = "Prezime:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(95, 197);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 6;
            label3.Text = "Grad:";
            // 
            // txtBrojTelefona
            // 
            txtBrojTelefona.Location = new Point(95, 171);
            txtBrojTelefona.Name = "txtBrojTelefona";
            txtBrojTelefona.Size = new Size(145, 23);
            txtBrojTelefona.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(95, 153);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 4;
            label4.Text = "Broj telefona:";
            // 
            // cmbGrad
            // 
            cmbGrad.FormattingEnabled = true;
            cmbGrad.Location = new Point(95, 215);
            cmbGrad.Name = "cmbGrad";
            cmbGrad.Size = new Size(145, 23);
            cmbGrad.TabIndex = 7;
            // 
            // btnDodaj
            // 
            btnDodaj.Location = new Point(95, 244);
            btnDodaj.Name = "btnDodaj";
            btnDodaj.Size = new Size(145, 48);
            btnDodaj.TabIndex = 8;
            btnDodaj.Text = "DODAJ";
            btnDodaj.UseVisualStyleBackColor = true;
            // 
            // rbFizicko
            // 
            rbFizicko.AutoSize = true;
            rbFizicko.Location = new Point(95, 22);
            rbFizicko.Name = "rbFizicko";
            rbFizicko.Size = new Size(61, 19);
            rbFizicko.TabIndex = 9;
            rbFizicko.TabStop = true;
            rbFizicko.Text = "Fizicko";
            rbFizicko.UseVisualStyleBackColor = true;
            // 
            // rbPravno
            // 
            rbPravno.AutoSize = true;
            rbPravno.Location = new Point(178, 22);
            rbPravno.Name = "rbPravno";
            rbPravno.Size = new Size(62, 19);
            rbPravno.TabIndex = 10;
            rbPravno.TabStop = true;
            rbPravno.Text = "Pravno";
            rbPravno.UseVisualStyleBackColor = true;
            // 
            // FrmMusterija
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 317);
            Controls.Add(rbPravno);
            Controls.Add(rbFizicko);
            Controls.Add(btnDodaj);
            Controls.Add(cmbGrad);
            Controls.Add(label3);
            Controls.Add(txtBrojTelefona);
            Controls.Add(label4);
            Controls.Add(txtPrezime);
            Controls.Add(label2);
            Controls.Add(txtIme);
            Controls.Add(label1);
            Name = "FrmMusterija";
            Text = "FrmMusterija";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtIme;
        private TextBox txtPrezime;
        private Label label2;
        private Label label3;
        private TextBox txtBrojTelefona;
        private Label label4;
        private ComboBox cmbGrad;
        private Button btnDodaj;
        private RadioButton rbFizicko;
        private RadioButton rbPravno;
    }
}