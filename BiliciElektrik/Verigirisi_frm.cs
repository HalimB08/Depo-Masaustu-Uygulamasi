using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BiliciElektrik
{
    public partial class Verigirisi_frm : Form
    {
        static string veritabani = @"bilicielektrik.mdb";

        OleDbConnection vt_baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + veritabani + ";" + "Jet OLEDB:Database Password=3934683;");
        OleDbDataAdapter da;
        DataSet ds;
        OleDbCommand cmd;
        public Verigirisi_frm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "Seçiniz")
                {
                    if (textBox1.Text != "")
                    {
                        if (textBox2.Text != "")
                        {
                            if (textBox4.Text != "")
                            {
                                if (textBox3.Text != "")
                                {
                                    

                                }
                                else
                                {
                                    MessageBox.Show("Lütfen ürün adetini giriniz");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Lütfen ürün adet fiyatını giriniz");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Lütfen ürün adını giriniz");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen ürün markasını giriniz");
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen ürün nerede kısmını seçiniz!");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Bir sorun meydana geldi! Kayıt yapılamadı.");
            }


            





        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void Verigirisi_frm_Load(object sender, EventArgs e)
        {

        }
    }
}

