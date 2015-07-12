using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using CriminalSearch.Repository.Entity;
using System;
using CriminalSearch.Utility;

namespace CriminalSearch.Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SqLiteHelper _sqliteHelper;

        public UserRepository(SqLiteHelper sqliteHelper)
        {
            _sqliteHelper = sqliteHelper;
        }

        public User GetUserByEmail(string email)
        {
            User result = null;
            SQLiteConnection con;
            SQLiteDataReader reader = _sqliteHelper.ExecuteCommand("Select * FROM User where Email='" + email + "'", out con);
            while (reader.Read())
            {
                result = new User { Username = reader["Username"].ToString(), Email = reader["Email"].ToString(), Password = reader["Password"].ToString() };
            }
            con.Close();
            return result;
        }

        public User GetUserByUsernme(string username)
        {
            User result = null;
            SQLiteConnection con;
            SQLiteDataReader reader = _sqliteHelper.ExecuteCommand("Select * FROM User where Username='" + username + "'", out con);
            while (reader.Read())
            {
                result = new User { ID = Convert.ToInt32(reader["ID"]), Username = reader["Username"].ToString(), Email = reader["Email"].ToString(), Password = reader["Password"].ToString() };
            }
            con.Close();
            return result;
        }

        public void Insert(User entity)
        {
            _sqliteHelper.ExecuteNonQuery("INSERT INTO User (Username,Email,Password) Values ('" + entity.Username + "','" + entity.Email + "','" + entity.Password + "')");
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public IList<User> GetAll()
        {
            List<User> result = new List<User>();
            SQLiteConnection con;
            SQLiteDataReader reader = _sqliteHelper.ExecuteCommand("Select * FROM User", out con);

            while (reader.Read())
            {
                result.Add(new User { ID = Convert.ToInt32(reader["ID"]), Username = reader["Username"].ToString(), Email = reader["Email"].ToString() });
            }
            con.Close();
            return result;
        }

        public User Get(int id)
        {
            User result = null;
            SQLiteConnection con;
            SQLiteDataReader reader = _sqliteHelper.ExecuteCommand("Select * FROM User where ID='" + id + "'", out con);
            while (reader.Read())
            {
                result = new User { ID = Convert.ToInt32(reader["ID"]), Username = reader["Username"].ToString(), Email = reader["Email"].ToString(), Password = reader["Password"].ToString() };
            }
            con.Close();
            return result;
        }
    }
}
