using N_Tier.ORM.Entity;
using N_Tier.ORM.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N_Tier.WFUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KategoriListele();

        }
        public void KategoriListele()
        {
            dgvListe.DataSource = Kategoriler.Select();
            dgvListe.Columns[0].Visible = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Kategori ktg = new Kategori();
            ktg.KategoriAdi = txtKategoriAd.Text;
            ktg.Tanimi = txtTanim.Text;
            bool sonuc = Kategoriler.Insert(ktg);
            if (sonuc) //sonuc true ise
            {
                MessageBox.Show("Başarılı");
                KategoriListele();
            }
            else
            {
                MessageBox.Show("Başarısız");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Kategori ktg = new Kategori();
            ktg.KategoriAdi = txtKategoriAd.Text;
            ktg.Tanimi = txtTanim.Text;
            ktg.KategoriID = (int)txtKategoriAd.Tag;
            bool sonuc = Kategoriler.Update(ktg);

            if (sonuc) 
            {
                MessageBox.Show("Başarılı");
                KategoriListele();
            }
            else
            {
                MessageBox.Show("Başarısız");
            }
        }

        private void dgvListe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKategoriAd.Tag = dgvListe.CurrentRow.Cells[0].Value;
            txtKategoriAd.Text = dgvListe.CurrentRow.Cells[1].Value.ToString();
            txtTanim.Text = dgvListe.CurrentRow.Cells[2].Value.ToString();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Kategori ktg = new Kategori();
            ktg.KategoriID = (int)txtKategoriAd.Tag;
            bool sonuc = Kategoriler.Delete(ktg);

            if (sonuc)
            {
                MessageBox.Show("Başarılı");
                KategoriListele();
            }
            else
            {
                MessageBox.Show("Başarısız");
            }
        }
    }
}
