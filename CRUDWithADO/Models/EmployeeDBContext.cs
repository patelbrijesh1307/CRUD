using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace CRUDWithADO.Models
{
    public class EmployeeDBContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
       
        public List<Employee> GetEmployees()
        {
            List<Employee> EmployeesList = new List<Employee>();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand query = new SqlCommand("spGetEmployees", con);
            query.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader sqlDatareader = query.ExecuteReader();
            while(sqlDatareader.Read())
            {
                Employee employee = new Models.Employee();
                employee.id = Convert.ToInt32(sqlDatareader.GetValue(0).ToString());
                employee.name = sqlDatareader.GetValue(1).ToString();
                employee.gender = sqlDatareader.GetValue(2).ToString();
                employee.age = Convert.ToInt32(sqlDatareader.GetValue(3).ToString());
                employee.city = sqlDatareader.GetValue(4).ToString();
                employee.salary = Convert.ToInt32(sqlDatareader.GetValue(5).ToString());

                EmployeesList.Add(employee);
            }
            con.Close();
            return EmployeesList;
        }

        public bool AddEmployee(Employee emp)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand query = new SqlCommand("spAddEmployee", con);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.AddWithValue("@name", emp.name);
            query.Parameters.AddWithValue("@gender", emp.gender);
            query.Parameters.AddWithValue("@age", emp.age);
            query.Parameters.AddWithValue("@city", emp.city);
            query.Parameters.AddWithValue("@salary", emp.salary);
            con.Open();
            int a = query.ExecuteNonQuery();
            if(a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            con.Close();

        }

        public bool UpdateEmployee(Employee emp)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand query = new SqlCommand("spUpdateEmployee", con);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.AddWithValue("@id", emp.id);
            query.Parameters.AddWithValue("@name", emp.name);
            query.Parameters.AddWithValue("@gender", emp.gender);
            query.Parameters.AddWithValue("@age", emp.age);
            query.Parameters.AddWithValue("@city", emp.city);
            query.Parameters.AddWithValue("@salary", emp.salary);
            con.Open();
            int a = query.ExecuteNonQuery();
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            con.Close();

        }


        public bool DeleteEmployee(int id)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand query = new SqlCommand("spDeleteEmployee", con);
            query.CommandType = CommandType.StoredProcedure;
            query.Parameters.AddWithValue("@id", id);
            con.Open();
            int a = query.ExecuteNonQuery();
            if (a > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            con.Close();

        }


    }
}