using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiliciElektrik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int say = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
         
            if (say == 2)
            {
                timer1.Enabled = false;
                Form2 y = new Form2();
                y.Show();
                this.Hide();
            }
            else
            {
                say++;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}
