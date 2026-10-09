using Common.Domain;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmPoslastice : Form
    {
        public FrmPoslastice()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            try
            {
                string naziv = txtNaziv.Text.Trim();
                string vrsta = txtVrsta.Text.Trim();
                string opis = rtxtOpis.Text.Trim();

                if (string.IsNullOrWhiteSpace(naziv))
                {
                    MessageBox.Show("Unesite naziv poslastice.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(vrsta))
                {
                    MessageBox.Show("Unesite vrstu poslastice.");
                    return;
                }

                if (!double.TryParse(
                    txtCena.Text.Trim(),
                    NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands,
                    CultureInfo.InvariantCulture,
                    out double cena) &&
                    !double.TryParse(
                        txtCena.Text.Trim(),
                        NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands,
                        new CultureInfo("sr-RS"),
                        out cena))
                {
                    MessageBox.Show("Cena mora biti broj.");
                    return;
                }

                if (cena <= 0)
                {
                    MessageBox.Show("Cena mora biti veca od nule.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(opis))
                {
                    MessageBox.Show("Unesite opis poslastice.");
                    return;
                }

                Poslastica poslastica = new Poslastica
                {
                    Naziv = naziv,
                    Vrsta = vrsta,
                    Cena = cena,
                    Opis = opis
                };

                Communication.Instance.KreirajPoslasticu(poslastica);
                MessageBox.Show("Poslastica je uspesno sacuvana.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri cuvanju poslastice: " + ex.Message);
            }
        }
    }
}
