using Common.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    public partial class FrmPretraziPorudzbine : Form
    {
        private List<Prodavac> prodavci = new List<Prodavac>();
        private List<Musterija> musterije = new List<Musterija>();
        private List<Porudzbina> pronadjenePorudzbine = new List<Porudzbina>();

        public FrmPretraziPorudzbine()
        {
            InitializeComponent();
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }

        private void FrmPretraziPorudzbine_Load(object sender, EventArgs e)
        {
            try
            {
                prodavci = Communication.Instance.VratiSveProdavce();
                musterije = Communication.Instance.VratiSveMusterije();

                // Dodaj opciju "Svi prodavci"
                prodavci.Insert(0, new Prodavac
                {
                    Id = 0,
                    Ime = "Svi",
                    Prezime = "prodavci"
                });

                cmbProdavac.DataSource = null;
                cmbProdavac.DataSource = prodavci;
                cmbProdavac.DisplayMember = "ImePrezime";
                cmbProdavac.ValueMember = "Id";
                cmbProdavac.SelectedIndex = 0;

                // Dodaj opciju "Sve mušterije"
                musterije.Insert(0, new Musterija
                {
                    Id = 0,
                    Ime = "Sve",
                    Prezime = "mušterije",
                    BrojTelefona = string.Empty,
                    TipMusterije = "Fizicko",
                    Grad = new Grad()
                });

                cmbMusterija.DataSource = null;
                cmbMusterija.DataSource = musterije;
                cmbMusterija.DisplayMember = "ImePrezime";
                cmbMusterija.ValueMember = "Id";
                cmbMusterija.SelectedIndex = 0;

                rbKes.Checked = false;
                rbKartica.Checked = false;

                PripremiGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri učitavanju forme: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Porudzbina kriterijum = new Porudzbina();

                // Datum - opcioni kriterijum
                if (!string.IsNullOrWhiteSpace(txtDatum.Text))
                {
                    if (!DateTime.TryParseExact(
                        txtDatum.Text.Trim(),
                        "dd.MM.yyyy.",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime datum))
                    {
                        MessageBox.Show("Datum mora biti u formatu dd.MM.yyyy.");
                        return;
                    }

                    kriterijum.Datum = datum;
                }

                // Adresa - opcioni kriterijum
                if (!string.IsNullOrWhiteSpace(txtAdresa.Text))
                {
                    kriterijum.AdresaZaDostavu = txtAdresa.Text.Trim();
                }

                // Način plaćanja - opcioni kriterijum
                if (rbKes.Checked)
                {
                    kriterijum.NacinPlacanja = "Kes";
                }
                else if (rbKartica.Checked)
                {
                    kriterijum.NacinPlacanja = "Kartica";
                }

                // Prodavac - samo ako nije "Svi prodavci"
                if (cmbProdavac.SelectedItem is Prodavac prodavac && prodavac.Id > 0)
                {
                    kriterijum.Prodavac = prodavac;
                }

                // Mušterija - samo ako nije "Sve mušterije"
                if (cmbMusterija.SelectedItem is Musterija musterija && musterija.Id > 0)
                {
                    kriterijum.Musterija = musterija;
                }

                List<Porudzbina> rezultat = Communication.Instance.PretraziPorudzbine(kriterijum);

                if (rezultat == null || rezultat.Count == 0)
                {
                    pronadjenePorudzbine.Clear();
                    dataGridView1.DataSource = null;
                    MessageBox.Show("Nema porudžbina koje odgovaraju zadatom kriterijumu.");
                    return;
                }

                pronadjenePorudzbine = rezultat;
                dataGridView1.DataSource = rezultat.Select(p => new
                {
                    p.Id,
                    Datum = p.Datum.ToString("dd.MM.yyyy."),
                    p.UkupanIznos,
                    p.NacinPlacanja,
                    AdresaZaDostavu = string.IsNullOrWhiteSpace(p.AdresaZaDostavu) ? "/" : p.AdresaZaDostavu,
                    Prodavac = p.Prodavac != null ? p.Prodavac.ToString() : "",
                    Musterija = p.Musterija != null ? p.Musterija.ToString() : ""
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri pretrazi porudžbina: " + ex.Message);
            }
        }

        private void PripremiGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            DataGridViewTextBoxColumn colDatum = new DataGridViewTextBoxColumn();
            colDatum.HeaderText = "Datum";
            colDatum.DataPropertyName = "Datum";
            dataGridView1.Columns.Add(colDatum);

            DataGridViewTextBoxColumn colUkupno = new DataGridViewTextBoxColumn();
            colUkupno.HeaderText = "Ukupan iznos";
            colUkupno.DataPropertyName = "UkupanIznos";
            dataGridView1.Columns.Add(colUkupno);

            DataGridViewTextBoxColumn colPlacanje = new DataGridViewTextBoxColumn();
            colPlacanje.HeaderText = "Način plaćanja";
            colPlacanje.DataPropertyName = "NacinPlacanja";
            dataGridView1.Columns.Add(colPlacanje);

            DataGridViewTextBoxColumn colAdresa = new DataGridViewTextBoxColumn();
            colAdresa.HeaderText = "Adresa";
            colAdresa.DataPropertyName = "AdresaZaDostavu";
            colAdresa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns.Add(colAdresa);

            DataGridViewTextBoxColumn colProdavac = new DataGridViewTextBoxColumn();
            colProdavac.HeaderText = "Prodavac";
            colProdavac.DataPropertyName = "Prodavac";
            dataGridView1.Columns.Add(colProdavac);

            DataGridViewTextBoxColumn colMusterija = new DataGridViewTextBoxColumn();
            colMusterija.HeaderText = "Mušterija";
            colMusterija.DataPropertyName = "Musterija";
            dataGridView1.Columns.Add(colMusterija);
        }

        private void dataGridView1_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= pronadjenePorudzbine.Count)
                    return;

                Porudzbina izabranaPorudzbina = pronadjenePorudzbine[e.RowIndex];
                FrmPorudzbina formaPorudzbine = new FrmPorudzbina(izabranaPorudzbina);
                formaPorudzbine.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška pri otvaranju porudžbine: " + ex.Message);
            }
        }
    }
}
