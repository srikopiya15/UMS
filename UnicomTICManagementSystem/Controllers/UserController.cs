using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Controllers
{
    internal class UserController
    {
        public UserController() 

        { 

        }
        public UserController(User user) 
        {
            using (var conn = DbConfic.GetConnection()) 
            {
                string query = "INSERT INTO User (Username,Password,Role) VALUES ('Admin','admin','admin@123')," +
                               "INSERT INTO User (Username,Password,Role) VALUES ('Lecture','lecture','lecture@123')," +
                               "INSERT INTO User (Username,Password,Role) VALUES ('Staff','staff','staff@123')," +
                               "INSERT INTO User (Username,Password,Role) VALUES ('Student','student','student@123');";
                using (SQLiteCommand cmd = conn.CreateCommand()) 
                { 
                    cmd.Parameters.AddWithValue("@Username",user.Username);
                    cmd.Parameters.AddWithValue("@Password",user.Password);
                    cmd.Parameters.AddWithValue("@Role",user.Role);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
