using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using blood_bank_management_Csharp.Database;
using blood_bank_management_Csharp.Entity;

namespace blood_bank_management_Csharp.Repository
{
    class User_Repository
    {
        internal static User_Table GetUserDetail(string email, string password)
        {
            User_Table user = new User_Table();
            try
            {
                var query = @"SELECT * FROM user_table where email = '" + email + "' and password = '" + password + "';";
                var dt = DataAccess.GetDataTable(query);
                int index = 0;
                while (index < dt.Rows.Count)
                {
                    user = ConvertToEntity(dt.Rows[index]);
                    index++;
                }
            }
            catch
            {
                MessageBox.Show("Data Not Loaded \n Data :: NULL");
                return null;
            }
            return user;
        }

        private static User_Table ConvertToEntity(DataRow dataRow)
        {
            var user = new User_Table();
            user.id = Int32.Parse(dataRow["id"].ToString());
            user.name = dataRow["name"].ToString();
            user.email = dataRow["email"].ToString();
            user.join_date = DateTime.Parse(dataRow["join_date"].ToString());
            user.password = dataRow["password"].ToString();
            user.phone = dataRow["phone"].ToString();
            user.address = dataRow["address"].ToString();
            user.image = dataRow["image"].ToString();
            user.role = dataRow["role"].ToString();
            return user;
        }

        internal static bool UpdateUser(User_Table user)
        {
            bool inserted = false;
            try
            {
                string updateQuery = @"UPDATE [dbo].[user_table]
                                       SET [name] = '" + user.name +
                                          "',[email] = '" + user.email +
                                          "',[password] = '" + user.password +
                                          "',[phone] = '" + user.phone +
                                          "',[address] = '" + user.address +
                                          "',[image] = '" + user.image +
                                          "',[role] = '" + user.role +
                                     "WHERE user_id = '" + user.id + "'";
                int row = DataAccess.ExecuteQuery(updateQuery);
                if (row == 1)
                {
                    inserted = true;
                }
            }
            catch
            {
                return false;
            }
            return inserted;
        }

        internal static bool CheckUserExist(string email)
        {
            try
            {
                var query = @"SELECT * FROM [dbo].[user_table] where email LIKE '%" + email + "%';";
                var dt = DataAccess.GetDataTable(query);
                if (dt.Rows.Count == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        internal static bool InsertUser(User_Table user)
        {
            bool inserted = false;
            try
            {
                string query = @"INSERT INTO [dbo].[user_table] ([name]
                                                           ,[email]
                                                           ,[password]
                                                           ,[phone]
                                                           ,[address]
                                                           ,[image]
                                                           ,[join_date]
                                                           ,[role])
                                                     VALUES
                                                           ( '" + user.name + "','" + user.email + "','" + user.password + "','" + user.phone + "','" + user.address +
                                                             "','" + user.image + "','" + user.join_date + "','"+user.role +"')";
                int row = DataAccess.ExecuteQuery(query);
                if (row == 1)
                {
                    inserted = true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
            return inserted;
        }

        internal static bool DeleteUser(int user_id)
        {
            bool inserted = false;
            try
            {
                string query = @"DELETE FROM [dbo].[user_table] WHERE id='"+user_id+"'";
                int row = DataAccess.ExecuteQuery(query);
                if (row == 1)
                {
                    inserted = true;
                }
            }
            catch
            {
                return false;
            }
            return inserted;
        }
    }
}
