using Common.Domain;
using System;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmSS : Form
    {
        public FrmSS()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNaziv.Text))
                {
                    MessageBox.Show("Unesite naziv strucne spreme.");
                    return;
                }

                if (!int.TryParse(txtTrajanje.Text.Trim(), out int trajanje) || trajanje <= 0)
                {
                    MessageBox.Show("Trajanje mora biti pozitivan ceo broj.");
                    return;
                }

                StrucnaSprema strucnaSprema = new StrucnaSprema
                {
                    Naziv = txtNaziv.Text.Trim(),
                    Trajanje = trajanje
                };

                int id = Communication.Instance.KreirajStrucnuSpremu(strucnaSprema);
                if (id <= 0)
                {
                    MessageBox.Show("Strucna sprema nije sacuvana.");
                    return;
                }

                MessageBox.Show("Strucna sprema je uspesno sacuvana.");
                txtNaziv.Clear();
                txtTrajanje.Clear();
                txtNaziv.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri cuvanju strucne spreme: " + ex.Message);
            }
        }
    }
}
