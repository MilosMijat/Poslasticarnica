namespace Client
{
    partial class FrmPoslastice
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
            rtxtOpis = new RichTextBox();
            txtNaziv = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtVrsta = new TextBox();
            label3 = new Label();
            txtCena = new TextBox();
            label4 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // rtxtOpis
            // 
            rtxtOpis.Location = new Point(104, 140);
            rtxtOpis.Name = "rtxtOpis";
            rtxtOpis.Size = new Size(190, 96);
            rtxtOpis.TabIndex = 0;
            rtxtOpis.Text = "";
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(104, 53);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(190, 23);
            txtNaziv.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 53);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 2;
            label1.Text = "Naziv:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 82);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 4;
            label2.Text = "Vrsta:";
            // 
            // txtVrsta
            // 
            txtVrsta.Location = new Point(104, 82);
            txtVrsta.Name = "txtVrsta";
            txtVrsta.Size = new Size(190, 23);
            txtVrsta.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(60, 111);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 6;
            label3.Text = "Cena:";
            // 
            // txtCena
            // 
            txtCena.Location = new Point(104, 111);
            txtCena.Name = "txtCena";
            txtCena.Size = new Size(190, 23);
            txtCena.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(60, 143);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 7;
            label4.Text = "Opis:";
            // 
            // button1
            // 
            button1.Location = new Point(60, 242);
            button1.Name = "button1";
            button1.Size = new Size(234, 65);
            button1.TabIndex = 8;
            button1.Text = "DODAJ";
            button1.UseVisualStyleBackColor = true;
            // 
            // FrmPoslastice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtCena);
            Controls.Add(label2);
            Controls.Add(txtVrsta);
            Controls.Add(label1);
            Controls.Add(txtNaziv);
            Controls.Add(rtxtOpis);
            Name = "FrmPoslastice";
            Text = "FrmPoslastice";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox rtxtOpis;
        private TextBox txtNaziv;
        private Label label1;
        private Label label2;
        private TextBox txtVrsta;
        private Label label3;
        private TextBox txtCena;
        private Label label4;
        private Button button1;
    }
}