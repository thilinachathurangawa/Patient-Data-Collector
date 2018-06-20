using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Econtact.econtactClasses
{
    class contactClass
    {
        public String id { get; set; }
        public String name { get; set; }
        public String phone { get; set; }
        public String email { get; set; }
        public String gender { get; set; }
        public String address { get; set; }

        static String myconnStrig = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;

        public DataTable Select() {
            SqlConnection conn = new SqlConnection(myconnStrig);
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from contact";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally {
                conn.Close();
            }
            return dt;
        }

        public bool insert(contactClass c) {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnStrig);
            try
            {
                string sql = "insert into contact(name,phone,email,gender,address) values (@name,@phone,@email,@gender,@address)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name",c.name);
                cmd.Parameters.AddWithValue("@phone", c.phone);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@gender", c.gender);
                cmd.Parameters.AddWithValue("@address", c.address);

                conn.Open();
                int raws = cmd.ExecuteNonQuery();
                if (raws > 0)
                {
                    isSuccess = true;
                }
                else {
                    isSuccess = false;
                }
            }
            catch (Exception ex) {

            }
            finally {
                conn.Close();
            }
            return isSuccess;
        }

        public bool Update(contactClass c) {

            bool isSuccess = true;
            SqlConnection conn = new SqlConnection(myconnStrig);
            try
            {
                string sql = "update table contact set name=@name,phone=@pnone,email=@email,gender=@gender,address=@address where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@phone", c.phone);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@gender", c.gender);
                cmd.Parameters.AddWithValue("@address", c.address);
                cmd.Parameters.AddWithValue("@id", c.id);

                conn.Open();
                int raws = cmd.ExecuteNonQuery();
                if (raws > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally {
                conn.Close();
            }

            return isSuccess;
}
        public bool delete(contactClass c) {

            bool isSucess = false;
            SqlConnection conn = new SqlConnection(myconnStrig);
            try
            {
                string sql = "delete from contact where id=@id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", c.id);
                conn.Open();

                int raws = cmd.ExecuteNonQuery();
                if (raws > 0)
                {
                   isSucess = true;
                }
                else
                {
                    isSucess = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }


            return isSucess;
        }

    }
}
