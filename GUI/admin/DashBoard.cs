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

namespace blood_bank_management_Csharp.GUI.admin
{
    public partial class DashBoard : Form
    {
        LoginForm form { get; set; }
        User_Table user { get; set; }
        public DashBoard()
        {
            InitializeComponent();
        }

        public DashBoard(LoginForm form, User_Table user)
        {
            InitializeComponent();
            this.form = form;
            this.user = user;
        }
    }
}
