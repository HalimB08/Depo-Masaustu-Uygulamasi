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
    public partial class islemler_frm : Form
    {
        static string veritabani = @"bilicielektrik.mdb";

        OleDbConnection vt_baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + veritabani + ";" + "Jet OLEDB:Database Password=3934683;");
        public islemler_frm()
        {
            InitializeComponent();
        }

        private void islemler_frm_Load(object sender, EventArgs e)
        {
            griddoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
        }
        int t_id;
        private void button3_Click(object sender, EventArgs e)
        {



        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                t_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                textBox6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                richTextBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                button3.Enabled = true;
                button4.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Güncelleme kısmında bir problem oluştu!");

            }
        }
        void griddoldur()
        {
            OleDbDataAdapter da = new OleDbDataAdapter("Select *from depo", vt_baglanti);
            DataSet ds = new DataSet();
            vt_baglanti.Open();
            da.Fill(ds, "depo");
            dataGridView1.DataSource = ds.Tables["depo"];
            vt_baglanti.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
}
