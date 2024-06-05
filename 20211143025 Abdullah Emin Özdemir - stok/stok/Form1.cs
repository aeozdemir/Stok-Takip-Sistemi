using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    x.Text = "";
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = stokveri.dtGetir("select * from musteriler order by satis_id");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgStok.Rows.Add(
                    dt.Rows[i]["satis_id"].ToString(),
                    dt.Rows[i]["tc"].ToString(),
                    dt.Rows[i]["ad_soyad"].ToString(),
                    dt.Rows[i]["mail"].ToString(),
                    dt.Rows[i]["telefon"].ToString()
                    );
            }
        }

        private void dgStok_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgStok.CurrentRow.Cells[0].Value.ToString();
            txtTC.Text = dgStok.CurrentRow.Cells[1].Value.ToString();
            txtAdSoyad.Text = dgStok.CurrentRow.Cells[2].Value.ToString();
            txtMail.Text = dgStok.CurrentRow.Cells[3].Value.ToString();
            txtTelefon.Text = dgStok.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            if (txtBarkod.Text == "" || txtUrunAdi.Text == "" || txtMiktar.Text == "" || txtSatisF.Text == "" || txtToplamF.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
