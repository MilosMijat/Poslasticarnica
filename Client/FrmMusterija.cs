using Common.Domain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmMusterija : Form
    {
        private List<Grad> gradovi = new List<Grad>();
        private readonly Musterija? musterijaZaIzmenu;
        private readonly bool editMode;

        public FrmMusterija()
        {
            InitializeComponent();
            Load += FrmMusterija_Load;
            btnDodaj.Click += btnDodaj_Click;
            rbFizicko.CheckedChanged += TipMusterije_CheckedChanged;
            rbPravno.CheckedChanged += TipMusterije_CheckedChanged;
        }

        public FrmMusterija(Musterija musterija) : this()
        {
            musterijaZaIzmenu = musterija ?? throw new ArgumentNullException(nameof(musterija));
            editMode = true;
        }

        private void FrmMusterija_Load(object? sender, EventArgs e)
        {
            try
            {
                gradovi = Communication.Instance.VratiSveGradove();
                cmbGrad.DataSource = null;
                cmbGrad.DataSource = gradovi;
                cmbGrad.DisplayMember = "Naziv";
                cmbGrad.ValueMember = "Id";
                cmbGrad.SelectedIndex = gradovi.Count > 0 ? 0 : -1;

                if (editMode && musterijaZaIzmenu != null)
                {
                    if (musterijaZaIzmenu.JePravnoLice)
                    {
                        rbPravno.Checked = true;
                        txtIme.Text = musterijaZaIzmenu.NazivPravnogLica;
                        txtPrezime.Text = musterijaZaIzmenu.PIB;
                    }
                    else
                    {
                        rbFizicko.Checked = true;
                        txtIme.Text = musterijaZaIzmenu.Ime;
                        txtPrezime.Text = musterijaZaIzmenu.Prezime;
                    }

                    txtBrojTelefona.Text = musterijaZaIzmenu.BrojTelefona;
                    cmbGrad.SelectedValue = musterijaZaIzmenu.Grad.Id;
                    btnDodaj.Text = "IZMENI";
                }
                else
                {
                    rbFizicko.Checked = true;
                }

                OsveziLabeleZaTipMusterije();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri ucitavanju gradova: " + ex.Message);
            }
        }

        private void TipMusterije_CheckedChanged(object? sender, EventArgs e)
        {
            OsveziLabeleZaTipMusterije();
        }

        private void OsveziLabeleZaTipMusterije()
        {
            if (rbPravno.Checked)
            {
                label1.Text = "Naziv:";
                label2.Text = "PIB:";
                return;
            }

            label1.Text = "Ime:";
            label2.Text = "Prezime:";
        }

        private void btnDodaj_Click(object? sender, EventArgs e)
        {
            try
            {
                if (!rbFizicko.Checked && !rbPravno.Checked)
                {
                    MessageBox.Show("Izaberite tip musterije.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtIme.Text))
                {
                    MessageBox.Show(rbPravno.Checked ? "Unesite naziv pravnog lica." : "Unesite ime musterije.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPrezime.Text))
                {
                    MessageBox.Show(rbPravno.Checked ? "Unesite PIB." : "Unesite prezime musterije.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtBrojTelefona.Text))
                {
                    MessageBox.Show("Unesite broj telefona musterije.");
                    return;
                }

                if (cmbGrad.SelectedItem is not Grad grad)
                {
                    MessageBox.Show("Izaberite grad.");
                    return;
                }

                Musterija musterija = new Musterija
                {
                    Id = editMode && musterijaZaIzmenu != null ? musterijaZaIzmenu.Id : 0,
                    BrojTelefona = txtBrojTelefona.Text.Trim(),
                    Grad = grad,
                    TipMusterije = rbPravno.Checked ? "Pravno" : "Fizicko",
                    Ime = rbPravno.Checked ? string.Empty : txtIme.Text.Trim(),
                    Prezime = rbPravno.Checked ? string.Empty : txtPrezime.Text.Trim(),
                    NazivPravnogLica = rbPravno.Checked ? txtIme.Text.Trim() : string.Empty,
                    PIB = rbPravno.Checked ? txtPrezime.Text.Trim() : string.Empty
                };

                if (editMode)
                {
                    var response = Communication.Instance.IzmeniMusteriju(musterija);
                    if (!string.IsNullOrEmpty(response.ExceptionMessage))
                    {
                        MessageBox.Show("Musterija nije izmenjena.");
                        return;
                    }

                    MessageBox.Show("Musterija je uspesno izmenjena.");
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                int id = Communication.Instance.KreirajMusteriju(musterija);
                if (id <= 0)
                {
                    MessageBox.Show("Musterija nije sacuvana.");
                    return;
                }

                MessageBox.Show("Musterija je uspesno sacuvana.");
                txtIme.Clear();
                txtPrezime.Clear();
                txtBrojTelefona.Clear();
                rbFizicko.Checked = true;
                if (cmbGrad.Items.Count > 0)
                    cmbGrad.SelectedIndex = 0;
                txtIme.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri cuvanju musterije: " + ex.Message);
            }
        }
    }
}
