namespace Client
{
    partial class FrmPretraziMusterije
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
            btnPretrazi = new Button();
            cmbGrad = new ComboBox();
            label3 = new Label();
            txtBrojTelefona = new TextBox();
            label4 = new Label();
            txtPrezime = new TextBox();
            label2 = new Label();
            txtIme = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            rbPravno = new RadioButton();
            rbFizicko = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnPretrazi
            // 
            btnPretrazi.Location = new Point(27, 267);
            btnPretrazi.Name = "btnPretrazi";
            btnPretrazi.Size = new Size(140, 53);
            btnPretrazi.TabIndex = 17;
            btnPretrazi.Text = "Pretrazi";
            btnPretrazi.UseVisualStyleBackColor = true;
            // 
            // cmbGrad
            // 
            cmbGrad.FormattingEnabled = true;
            cmbGrad.Location = new Point(27, 238);
            cmbGrad.Name = "cmbGrad";
            cmbGrad.Size = new Size(140, 23);
            cmbGrad.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 220);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 15;
            label3.Text = "Grad:";
            // 
            // txtBrojTelefona
            // 
            txtBrojTelefona.Location = new Point(27, 194);
            txtBrojTelefona.Name = "txtBrojTelefona";
            txtBrojTelefona.Size = new Size(140, 23);
            txtBrojTelefona.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 176);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 13;
            label4.Text = "Broj telefona:";
            // 
            // txtPrezime
            // 
            txtPrezime.Location = new Point(27, 140);
            txtPrezime.Name = "txtPrezime";
            txtPrezime.Size = new Size(140, 23);
            txtPrezime.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 122);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 11;
            label2.Text = "Prezime:";
            // 
            // txtIme
            // 
            txtIme.Location = new Point(27, 96);
            txtIme.Name = "txtIme";
            txtIme.Size = new Size(140, 23);
            txtIme.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 78);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 9;
            label1.Text = "Ime:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(191, 47);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(576, 273);
            dataGridView1.TabIndex = 18;
            // 
            // rbPravno
            // 
            rbPravno.AutoSize = true;
            rbPravno.Location = new Point(110, 47);
            rbPravno.Name = "rbPravno";
            rbPravno.Size = new Size(62, 19);
            rbPravno.TabIndex = 20;
            rbPravno.TabStop = true;
            rbPravno.Text = "Pravno";
            rbPravno.UseVisualStyleBackColor = true;
            // 
            // rbFizicko
            // 
            rbFizicko.AutoSize = true;
            rbFizicko.Location = new Point(27, 47);
            rbFizicko.Name = "rbFizicko";
            rbFizicko.Size = new Size(61, 19);
            rbFizicko.TabIndex = 19;
            rbFizicko.TabStop = true;
            rbFizicko.Text = "Fizicko";
            rbFizicko.UseVisualStyleBackColor = true;
            // 
            // FrmPretraziMusterije
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 356);
            Controls.Add(rbPravno);
            Controls.Add(rbFizicko);
            Controls.Add(dataGridView1);
            Controls.Add(btnPretrazi);
            Controls.Add(cmbGrad);
            Controls.Add(label3);
            Controls.Add(txtBrojTelefona);
            Controls.Add(label4);
            Controls.Add(txtPrezime);
            Controls.Add(label2);
            Controls.Add(txtIme);
            Controls.Add(label1);
            Name = "FrmPretraziMusterije";
            Text = "FrmPretraziMusterije";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPretrazi;
        private ComboBox cmbGrad;
        private Label label3;
        private TextBox txtBrojTelefona;
        private Label label4;
        private TextBox txtPrezime;
        private Label label2;
        private TextBox txtIme;
        private Label label1;
        private DataGridView dataGridView1;
        private RadioButton rbPravno;
        private RadioButton rbFizicko;
    }
}