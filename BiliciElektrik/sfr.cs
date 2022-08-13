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

    public partial class sfr : Form
    {

        static string veritabani = @"bilicielektrik.mdb";

        OleDbConnection vt_baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + veritabani + ";" + "Jet OLEDB:Database Password=3934683;");
        public sfr()
        {
            InitializeComponent();
        }
        public static int sifred = 0;
        private void sfr_Load(object sender, EventArgs e)
        {
            vt_baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("Select sifreistermisiniz, sifre, yetkiliismisoyismi, ilkayaryapildimi from ayarlar where id=1", vt_baglanti);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //textBox1.Text = dr["id"].ToString();
                if (dr["sifreistermisiniz"].ToString() == "f")
                {
                    sifred = 1;
                    this.Close();
                }
            }
            vt_baglanti.Close();
        }
        int s = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            vt_baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("Select sifreistermisiniz, sifre, yetkiliismisoyismi, ilkayaryapildimi from ayarlar where id=1", vt_baglanti);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {


                if (dr["sifre"].ToString() == textBox1.Text)
                {
                    MessageBox.Show("Şifre doğrulandı!");
                    sifred = 1;
                    this.Close();
                }
                else
                {
                    s++;
                    if (s == 2)
                    {
                        MessageBox.Show("Şifreyi tekrar yanlış girdiniz! Güvenlik için uygulama kapatılacaktır.");
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Şifre yanlış! Lütfen tekrar deneyiniz!");
                    }

                }
            }

            vt_baglanti.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //checkBox işaretli ise
            if (checkBox1.Checked)
            {
                //karakteri göster.
                textBox1.PasswordChar = '\0';
            }
            //değilse karakterlerin yerine * koy.
            else
            {
                textBox1.PasswordChar = '*'; // "*" yerine ne eklerseniz şifreyi gizlerken ne yazmışsanız o şekilde gizler .
            }
        }
        int g1 = 0;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (g1 == 0)
            {
                textBox1.PasswordChar = '\0';
                g1++;
            }
            else
            {
                g1 = 0;
                textBox1.PasswordChar = '*';

            }


        }
    }
}
