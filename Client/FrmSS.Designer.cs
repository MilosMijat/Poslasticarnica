namespace Client
{
    partial class FrmSS
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
            txtNaziv = new TextBox();
            txtTrajanje = new TextBox();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 47);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Naziv:";
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(42, 65);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(129, 23);
            txtNaziv.TabIndex = 1;
            // 
            // txtTrajanje
            // 
            txtTrajanje.Location = new Point(42, 120);
            txtTrajanje.Name = "txtTrajanje";
            txtTrajanje.Size = new Size(129, 23);
            txtTrajanje.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 102);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 2;
            label2.Text = "Trajanje:";
            // 
            // button1
            // 
            button1.Location = new Point(42, 149);
            button1.Name = "button1";
            button1.Size = new Size(129, 36);
            button1.TabIndex = 4;
            button1.Text = "DODAJ";
            button1.UseVisualStyleBackColor = true;
            // 
            // FrmSS
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(222, 226);
            Controls.Add(button1);
            Controls.Add(txtTrajanje);
            Controls.Add(label2);
            Controls.Add(txtNaziv);
            Controls.Add(label1);
            Name = "FrmSS";
            Text = "FrmSS";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNaziv;
        private TextBox txtTrajanje;
        private Label label2;
        private Button button1;
    }
}