using Common.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmPovezivanje : Form
    {
        private List<Prodavac> prodavci = new List<Prodavac>();
        private List<StrucnaSprema> strucneSpreme = new List<StrucnaSprema>();

        public FrmPovezivanje()
        {
            InitializeComponent();
            Load += FrmPovezivanje_Load;
            button1.Click += button1_Click;
        }

        private void FrmPovezivanje_Load(object? sender, EventArgs e)
        {
            try
            {
                prodavci = Communication.Instance.VratiSveProdavce();
                strucneSpreme = Communication.Instance.VratiSveStrucneSpreme() ?? new List<StrucnaSprema>();

                cmbProdavac.DataSource = null;
                cmbProdavac.DataSource = prodavci;
                cmbProdavac.DisplayMember = "ImePrezime";
                cmbProdavac.ValueMember = "Id";
                cmbProdavac.SelectedIndex = prodavci.Count > 0 ? 0 : -1;

                cmbStrucnaSprema.DataSource = null;
                cmbStrucnaSprema.DataSource = strucneSpreme;
                cmbStrucnaSprema.DisplayMember = "Naziv";
                cmbStrucnaSprema.ValueMember = "Id";
                cmbStrucnaSprema.SelectedIndex = strucneSpreme.Count > 0 ? 0 : -1;

                if (string.IsNullOrWhiteSpace(txtDatum.Text))
                {
                    txtDatum.Text = DateTime.Today.ToString("dd.MM.yyyy.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri ucitavanju podataka: " + ex.Message);
            }
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            try
            {
                if (cmbProdavac.SelectedItem is not Prodavac prodavac)
                {
                    MessageBox.Show("Izaberite prodavca.");
                    return;
                }

                if (cmbStrucnaSprema.SelectedItem is not StrucnaSprema strucnaSprema)
                {
                    MessageBox.Show("Izaberite strucnu spremu.");
                    return;
                }

                if (!int.TryParse(txtStepen.Text.Trim(), out int stepenSS) || stepenSS <= 0)
                {
                    MessageBox.Show("Stepen strucne spreme mora biti pozitivan broj.");
                    return;
                }

                if (!DateTime.TryParseExact(
                    txtDatum.Text.Trim(),
                    "dd.MM.yyyy.",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime datumSticanja))
                {
                    MessageBox.Show("Datum mora biti u formatu dd.MM.yyyy.");
                    return;
                }

                PrSs veza = new PrSs
                {
                    Prodavac = prodavac,
                    StrucnaSprema = strucnaSprema,
                    StepenSS = stepenSS,
                    DatumSticanja = datumSticanja
                };

                Communication.Instance.DodajStrucnuSpremuProdavcu(veza);
                MessageBox.Show("Prodavac i strucna sprema su uspesno povezani.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri povezivanju: " + ex.Message);
            }
        }
    }
}
