using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blood_bank_management_Csharp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txt_email.Text) || String.IsNullOrEmpty(this.txt_password.Text))
            {
                MessageBox.Show("Please Insert Informations");
            }
            else
            {
                MessageBox.Show("Value Not Empty");
            }
        }
    }
}
