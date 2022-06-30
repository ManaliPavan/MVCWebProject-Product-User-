using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebProject.Models
{
    public class UserDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public UserDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        public List<User> GetAllUsers()
        {
            List<User> list = new List<User>();
            string str = "select * from User";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    User u = new User();
                    u.Uid = Convert.ToInt32(dr["Uid"]);
                    u.Uname = dr["Uname"].ToString();
                    u.EmailID = dr["EmailID"].ToString();
                    u.Password = dr["Password"].ToString();
                    list.Add(u);
                }
                con.Close();
                return list;
            }
            else
            {
                return list;
            }

        }
        public User GetUserById(int uid)
        {
            User u = new User();
            string str = "select * from User where Uid=@uid";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@uid", uid);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    u.Uid = Convert.ToInt32(dr["Uid"]);
                    u.Uname = dr["Uname"].ToString();
                    u.EmailID = dr["EmailID"].ToString();
                    u.Password= dr["password"].ToString();

                }
                con.Close();
                return u;
            }
            else
            {
                con.Close();
                return u;
            }
        }
        public int Save(User u)
        {
            string str = "insert into User values(@uname,@emailid,@password)";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@uname", u.Uname);
            cmd.Parameters.AddWithValue("@emailid", u.EmailID);
            cmd.Parameters.AddWithValue("@password", u.Password);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int Update(User u)
        {
            string str = "update User set Uname=@uname,EmailID=@emailid where Uid=@uid";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@uid", u.Uid);
            cmd.Parameters.AddWithValue("@uname", u.Uname);
            cmd.Parameters.AddWithValue("@emailid", u.EmailID);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int Delete(int uid)
        {
            string str = "delete from User where Uid=@uid";
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.Parameters.AddWithValue("@uid", uid);
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}

