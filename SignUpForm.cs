using blood_bank_management_Csharp.Entity;
using blood_bank_management_Csharp.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace blood_bank_management_Csharp
{
    public partial class SignUpForm : Form
    {
        private User_Table user { get; set; }
        private string file_path { get; set; }
        private string targetPath = "E:/AIUB 10th SEM/SIYAM/C#/blood_bank_management_Csharp/resource_file";

        public SignUpForm()
        {
            InitializeComponent();
            this.user = new User_Table();
        }

        private void btn_signUp_Click(object sender, EventArgs e)
        {
            var name = this.txt_name.Text;
            var email = this.txt_email.Text;
            var password = this.txt_password.Text;
            var retypePass = this.txt_retypePass.Text;
            var phone = this.txt_phone.Text;
            var address = this.txt_address.Text;
            var terms = this.chk_terms.Checked;
            var role = this.cmb_role.Text;
            var blood_group = this.cmb_bloodGroup.Text;
            
            if (String.IsNullOrEmpty(phone))
            {
                this.user.phone = "";
            }
            else if (String.IsNullOrEmpty(address))
            {
                this.user.address = "";
            }
            else if (String.IsNullOrEmpty(this.user.image))
            {
                this.user.image = null;
            }
            else
            {
                this.user.address = address; 
                this.user.phone = phone;
            }

            if (terms == true)
            {
                if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password) || 
                    String.IsNullOrEmpty(retypePass) || String.IsNullOrEmpty(role) || String.IsNullOrEmpty(blood_group))
                {
                    MessageBox.Show("Please insert all informations..");
                }
                else
                {
                    if (String.IsNullOrEmpty(password) || String.IsNullOrEmpty(retypePass) && !password.Equals(retypePass))
                    {
                        MessageBox.Show("Please insert same password..");
                    }
                    else
                    {
                        bool validEmail = User_Repository.CheckUserExist(email);
                        if (validEmail == true)
                        {
                            this.user.name = name;
                            this.user.email = email;
                            this.user.password = password;
                            this.user.role = role;
                            this.user.join_date = DateTime.Now;


                            var insert = User_Repository.InsertUser(this.user);

                            if (insert == true)
                            {
                                if ( !String.IsNullOrEmpty(this.user.image) )
                                {
                                    string destFile = Path.Combine(targetPath, this.user.image);

                                    File.Copy(this.file_path, destFile);
                                }

                                this.Hide();
                                new LoginForm().ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Error 404\n\n");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error 404...");
                            this.Hide();
                            new LoginForm().ShowDialog();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Terms and Conditions not selected..");
            }
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                this.user.image = Path.GetFileName(open.FileName);
                this.file_path = open.FileName;
            }
        }
    }
}
