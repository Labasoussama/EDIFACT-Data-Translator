using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (key.Text == "somaport2006")
            {

                new Form1().Show();
                //this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong password");
                key.Clear();
                key.Focus();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(key.PasswordChar == '*')
            {
                button3.BringToFront();
                key.PasswordChar = '\0';
            }
            else if (key.PasswordChar == '\0')
            {
                button3.BringToFront();
                key.PasswordChar = '*';
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (key.PasswordChar == '\0')
            {
                button3.BringToFront();
                key.PasswordChar = '*';
            }
            else if (key.PasswordChar == '*')
            {
                button3.BringToFront();
                key.PasswordChar = '\0';
            }
        }
        private void key_TextChanged(object sender, EventArgs e)
        {
            
            if (key.PasswordChar == '\0')
            {
                key.PasswordChar = '*';
            }
        }
    private void button4_Click(object sender, EventArgs e)
        {
            key.Clear();
            key.Focus();
        }
    }
}
