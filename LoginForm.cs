using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using blood_bank_management_Csharp.Entity;
using blood_bank_management_Csharp.GUI.admin;
using blood_bank_management_Csharp.Repository;

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
                User_Table user = new User_Table();
                user = User_Repository.GetUserDetail(this.txt_email.Text, this.txt_password.Text);

                if (object.ReferenceEquals(null, user) || object.Equals(null, user))
                {
                    MessageBox.Show("No User Found");
                    return;
                }
                else
                {
                    if (user.email == this.txt_email.Text && user.password == this.txt_password.Text)
                    {
                        if(user.role == "Admin")
                        {
                            DashBoard adminDash = new DashBoard(this,user);
                            this.Hide();
                            adminDash.ShowDialog();
                        }
                        else if (user.role == "Donor")
                        {
                            DashBoard donorDash = new DashBoard(this, user);
                            this.Hide();
                            donorDash.ShowDialog();
                        }
                        else if (user.role == "Requester")
                        {
                            DashBoard requesterDash = new DashBoard(this, user);
                            this.Hide();
                            requesterDash.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No User Found");
                    }
                }
            }
        }

        private void lbl_signup_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm();
            this.Hide();
            signUpForm.StartPosition = FormStartPosition.CenterScreen;
            signUpForm.ShowDialog();
        }

        private void lbl_signup_MouseHover(object sender, EventArgs e)
        {
            this.lbl_signup.ForeColor = Color.CadetBlue;
        }

        private void lbl_signup_MouseLeave(object sender, EventArgs e)
        {
            this.lbl_signup.ForeColor = Color.Black;
        }

        private void btn_signin_MouseHover(object sender, EventArgs e)
        {
            this.btn_signin.BackColor = Color.DarkSlateBlue;
            this.btn_signin.ForeColor = Color.White;
        }

        private void btn_signin_MouseLeave(object sender, EventArgs e)
        {
            this.btn_signin.BackColor = Color.DarkSlateGray;
            this.btn_signin.ForeColor = Color.DeepSkyBlue;
        }
    }
}
