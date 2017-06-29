using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningWindowForm_24_06_2017
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            txbUsername.ForeColor = Color.Gainsboro;
            txbUsername.Text = "UserName";
            txbPassword.ForeColor = Color.Gainsboro;
            txbPassword.Text = "Password";
            this.txbUsername.Leave += new System.EventHandler(this.txbUsername_Leave);
            this.txbUsername.Enter += new System.EventHandler(this.txbUsername_Enter);
            this.txbPassword.Leave += new System.EventHandler(this.txbPassword_Leave);
            this.txbPassword.Enter += new System.EventHandler(this.txbPassword_Enter);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txbUsername_Leave(object sender, EventArgs e)
        {
            if (txbUsername.Text == "")
            {
                txbUsername.Text = "UserName";
                txbUsername.ForeColor = Color.Gainsboro;
            }
        }

        private void txbUsername_Enter(object sender, EventArgs e)
        {
            if (txbUsername.Text == "UserName")
            {
                txbUsername.Text = "";
                txbUsername.ForeColor = Color.Black;
            }
        }

        private void txbPassword_Leave(object sender, EventArgs e)
        {
            if (txbPassword.Text == "")
            {
                txbPassword.Text = "Password";
                txbPassword.ForeColor = Color.Gainsboro;
            }
        }

        private void txbPassword_Enter(object sender, EventArgs e)
        {
            if (txbPassword.Text == "Password")
            {
                txbPassword.Text = "";
                txbPassword.ForeColor = Color.Black;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            //MessageBox.Show("Tes51515t");
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegister frm = new frmRegister();
            frm.Show();
        }
    }
}
