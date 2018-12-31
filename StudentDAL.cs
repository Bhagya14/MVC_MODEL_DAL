using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Mvc;

namespace MVC_Model_DAL.Models
{
    public class StudentDAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
        public int Addstudent(StudentModel model)
        {
            SqlCommand com_add = new SqlCommand("proc_addstudent", con);
            com_add.Parameters.AddWithValue("@name", model.studentname);
            com_add.Parameters.AddWithValue("@email", model.studentemailid);
            com_add.Parameters.AddWithValue("@password", model.studentpassword);
            com_add.Parameters.AddWithValue("@mobile", model.studentmobileno);
            com_add.Parameters.AddWithValue("@city", model.studentcity);
            com_add.Parameters.AddWithValue("@gender", model.studentgender);
            com_add.Parameters.AddWithValue("@imgaddress", model.studentimageaddress);
            com_add.CommandType = CommandType.StoredProcedure;
            SqlParameter para_return = new SqlParameter();
            para_return.Direction = ParameterDirection.ReturnValue;
            com_add.Parameters.Add(para_return);
            con.Open();
            com_add.ExecuteNonQuery();
            con.Close();
            int id = Convert.ToInt32(para_return.Value);
            return id;
        }
        public bool Login(LoginViewModel model)
        {
            SqlCommand com_login = new SqlCommand("proc_login", con);
            com_login.Parameters.AddWithValue("@loginid", model.loginid);
            com_login.Parameters.AddWithValue("@password", model.password);
            com_login.CommandType = CommandType.StoredProcedure;
            SqlParameter para_return = new SqlParameter();
            para_return.Direction = ParameterDirection.ReturnValue;
            com_login.Parameters.Add(para_return);
            con.Open();
            com_login.ExecuteNonQuery();
            con.Close();
            int count = Convert.ToInt32(para_return.Value);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<SelectListItem> GetCities()
        {
            List<SelectListItem> cities = new List<SelectListItem>();
            cities.Add(new SelectListItem { Text = "Select", Value = "" });
            cities.Add(new SelectListItem { Text = "BGL", Value = "BGL" });
            cities.Add(new SelectListItem { Text = "chennai", Value = "chennai" });
            return cities;

        }

        public List<StudentProjectionModel> Search(string key)
        {
            SqlCommand com_search = new SqlCommand("proc_search", con);
            com_search.Parameters.AddWithValue("@key", key);
            com_search.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = com_search.ExecuteReader();
            List<StudentProjectionModel> list = new List<StudentProjectionModel>();
            while (dr.Read())
            {
                StudentProjectionModel model = new StudentProjectionModel();
                model.studentid = dr.GetInt32(0);
                model.studentname = dr.GetString(1);
                model.studentgender = dr.GetString(2);
                model.studentimageaddress = dr.GetString(3);
                list.Add(model);
            }
            con.Close();
            return list;
        }
        public StudentModel Find(int id)
        {
            SqlCommand com_find = new SqlCommand("proc_find", con);
            com_find.Parameters.AddWithValue("@id", id);
            com_find.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = com_find.ExecuteReader();
            if (dr.Read())
            {
                StudentModel model = new StudentModel();
                model.studentID = dr.GetInt32(0);
                model.studentname = dr.GetString(1);
                model.studentemailid = dr.GetString(2);
                model.studentpassword = dr.GetString(3);
                model.studentmobileno = dr.GetString(4);
                model.studentcity = dr.GetString(5);
                model.studentgender = dr.GetString(6);
                model.studentimageaddress = dr.GetString(7);
                con.Close();
                return model;
            }
            else
            {
                con.Close();
                return null;
            }
        }

        public bool Update(int id,string password,string mobileno)
        {
            SqlCommand com_update = new SqlCommand("proc_update", con);
            com_update.Parameters.AddWithValue("@id", id);
            com_update.Parameters.AddWithValue("@password", password);
            com_update.Parameters.AddWithValue("@mobileno", mobileno);
            com_update.CommandType = CommandType.StoredProcedure;
            SqlParameter para_return = new SqlParameter();
            para_return.Direction = ParameterDirection.ReturnValue;
            com_update.Parameters.Add(para_return);
            con.Open();
            com_update.ExecuteNonQuery();
            con.Close();
            int count = Convert.ToInt32(para_return.Value);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            SqlCommand com_delete = new SqlCommand("proc_delete", con);
            com_delete.Parameters.AddWithValue("@id", id);
            com_delete.CommandType = CommandType.StoredProcedure;
            SqlParameter para_return = new SqlParameter();
            para_return.Direction = ParameterDirection.ReturnValue;
            com_delete.Parameters.Add(para_return);
            con.Open();
            com_delete.ExecuteNonQuery();
            con.Close();
            int count = Convert.ToInt32(para_return.Value);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}