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
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }
        static string veritabani = @"bilicielektrik.mdb";

        OleDbConnection vt_baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + veritabani + ";" + "Jet OLEDB:Database Password=3934683;");
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            sfrtkr_lbl.Visible = true;
            sfr_lbl.Visible = true;
            sifre_txt.Visible = true;
            sifretekrar_txt.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sfrtkr_lbl.Visible = false;
            sfr_lbl.Visible = false;
            sifre_txt.Visible = false;
            sifretekrar_txt.Visible = false;
        }
        string sifre;
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                sifre = "t";
            }
            else
            {
                sifre = "f";
            }


            if (sifre_txt.Text == sifretekrar_txt.Text)
            {
                
            }
            else
            {
                MessageBox.Show("Şifreler eşleşmiyor. Lütfen şifreyi tekrar giriniz.");
                sifre_txt.Text = "";
                sifretekrar_txt.Text = "";
            }

          
        }
        
        OleDbDataAdapter da;        
        DataSet ds;
        private void settings_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            radioButton1.Checked = true;

            
            
            //vt_baglanti.Open();
            //OleDbCommand cmd = new OleDbCommand("Select sifreistermisiniz, sifre, yetkiliismisoyismi, ilkayaryapildimi from ayarlar where id=1", vt_baglanti);
            //OleDbDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    if (dr["ilkayaryapildimi"].ToString() == "evet")
            //    {
                    
            //    }              
            //}
            //vt_baglanti.Close();


            //if (true)
            //{

            //}
            //else
            //{

            //}
        }

        private void sifre_txt_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //karakteri göster.
                sifre_txt.PasswordChar = '\0';
            }
            //değilse karakterlerin yerine * koy.
            else
            {
                sifre_txt.PasswordChar = '*'; // "*" yerine ne eklerseniz şifreyi gizlerken ne yazmışsanız o şekilde gizler .
            }
        }

        private void sifretekrar_txt_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //karakteri göster.
                sifretekrar_txt.PasswordChar = '\0';
            }
            //değilse karakterlerin yerine * koy.
            else
            {
                sifretekrar_txt.PasswordChar = '*'; // "*" yerine ne eklerseniz şifreyi gizlerken ne yazmışsanız o şekilde gizler .
            }
        }
        int g1 = 0;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (g1 == 0)
            {
                sifre_txt.PasswordChar = '\0';
                sifretekrar_txt.PasswordChar = '\0';

                g1++;
            }
            else
            {
                g1 = 0;
                sifre_txt.PasswordChar = '*';
                sifretekrar_txt.PasswordChar = '*';


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vt_baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("Select sifreistermisiniz, sifre, yetkiliismisoyismi, ilkayaryapildimi from ayarlar where id=1", vt_baglanti);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //textBox1.Text = dr["id"].ToString();

                if (dr["ilkayaryapildimi"].ToString() == "hayır")
                {
                    MessageBox.Show("İlk ayar yapılmadı!");
                }
                else if (dr["ilkayaryapildimi"].ToString() == "evet")
                {
                    this.Close();
                }
            }
            vt_baglanti.Close();
        }
    }
}
