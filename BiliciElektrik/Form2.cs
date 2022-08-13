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
    public partial class Form2 : Form
    {
       
     
        public Form2()
        {
            InitializeComponent();
        }
        static string veritabani = @"bilicielektrik.mdb";

        OleDbConnection vt_baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + veritabani + ";" + "Jet OLEDB:Database Password=3934683;");
        private void Form2_Load(object sender, EventArgs e)
        {
            

            vt_baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("Select sifreistermisiniz, sifre, yetkiliismisoyismi, ilkayaryapildimi from ayarlar where id=1", vt_baglanti);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                //textBox1.Text = dr["id"].ToString();

                if (dr["ilkayaryapildimi"].ToString() == "hayır")
                {
                    settings y = new settings();
                    y.ShowDialog();
                }
                else if (dr["sifreistermisiniz"].ToString() =="t")
                {
                    sfr y = new sfr();
                    y.ShowDialog();
                }
            }
            vt_baglanti.Close();






        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sfr.sifred ==1)
            {
                depo_frm y = new depo_frm();
                y.ShowDialog();
            }
            else
            {
                sfr y = new sfr();
                y.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sfr.sifred == 1)
            {
                islemler_frm y = new islemler_frm();
                y.ShowDialog();
            }
            else
            {
                sfr y = new sfr();
                y.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sfr.sifred == 1)
            {
                Verigirisi_frm y = new Verigirisi_frm();
                y.ShowDialog();
            }
            else
            {
                sfr y = new sfr();
                y.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            vt_baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("Select sifreistermisiniz, sifre, yetkiliismisoyismi, ilkayaryapildimi from ayarlar where id=1", vt_baglanti);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr["sifreistermisiniz"].ToString() == "t")
                {
                    sfr.sifred = 0;
                    sfr y = new sfr();
                    y.ShowDialog();
                    if (sfr.sifred == 1)
                    {
                        settings s = new settings();
                        s.ShowDialog();
                    }
                }
            }
            vt_baglanti.Close();         
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
