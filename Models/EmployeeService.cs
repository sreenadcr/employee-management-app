using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace employee_management_app.Model
{
    public class EmployeeService
    {
       SqlConnection ObjSqlConnection;
        SqlCommand ObjsqlCommand;
        public EmployeeService()
        {
           ObjSqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings
               ["EmployeeDbContext"].ConnectionString);
            ObjsqlCommand = new SqlCommand();
            ObjsqlCommand.Connection = ObjSqlConnection;
            ObjsqlCommand.CommandType = CommandType.StoredProcedure;
        }

        public List<Employee> getAll()
        {
            List<Employee> ObjEmployeeList = new List<Employee>();
            try
            {
                ObjsqlCommand.Parameters.Clear();
                ObjsqlCommand.CommandText = "udp_selectAllEmployees";

                ObjSqlConnection.Open();
                var Objsqldatareader = ObjsqlCommand.ExecuteReader();
                if (Objsqldatareader.HasRows)
                {
                    Employee ObjEmployee = null;
                    while (Objsqldatareader.Read())
                    {
                        ObjEmployee = new Employee();
                        ObjEmployee.Id = Objsqldatareader.GetInt32(0);
                        ObjEmployee.Name = Objsqldatareader.GetString(1);
                        ObjEmployee.Department_Name = Objsqldatareader.GetString(2);
                        ObjEmployee.Job_Title = Objsqldatareader.GetString(3);

                        ObjEmployeeList.Add(ObjEmployee);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            finally
            {
                ObjSqlConnection.Close();
            }
            return ObjEmployeeList;
        }

        public bool Add(Employee objNewEmployee)
        {
            bool Isadded = false;

            try
            {
                ObjsqlCommand.Parameters.Clear();
                ObjsqlCommand.CommandText = "udp_InsertEmployee";
                ObjsqlCommand.Parameters.AddWithValue("@Id", objNewEmployee.Id);
                ObjsqlCommand.Parameters.AddWithValue("@Nname", objNewEmployee.Name);
                ObjsqlCommand.Parameters.AddWithValue("@Jobtitle", objNewEmployee.Job_Title);
                ObjsqlCommand.Parameters.AddWithValue("@Departmentname", objNewEmployee.Department_Name);

                ObjSqlConnection.Open();
                int noofrowaffected = ObjsqlCommand.ExecuteNonQuery();
                Isadded = noofrowaffected > 0;
            }
            catch ( SqlException ex)
            {
                throw ex;
            }
            finally { ObjSqlConnection.Close(); }
            return Isadded;
        }

        public bool Update(Employee objEmployeeToUpdate)
        {
            bool IsUpdated = false;


            try
            {
                ObjsqlCommand.Parameters.Clear();
                ObjsqlCommand.CommandText = "udp_UpdateEmployee";
                ObjsqlCommand.Parameters.AddWithValue("@Id", objEmployeeToUpdate.Id);
                ObjsqlCommand.Parameters.AddWithValue("@Nname", objEmployeeToUpdate.Name);
                ObjsqlCommand.Parameters.AddWithValue("@Jobtitle", objEmployeeToUpdate.Job_Title);
                ObjsqlCommand.Parameters.AddWithValue("@Departmentname", objEmployeeToUpdate.Department_Name);

                ObjSqlConnection.Open();
                int noofrowaffected = ObjsqlCommand.ExecuteNonQuery();
                IsUpdated = noofrowaffected > 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally { ObjSqlConnection.Close(); }
        
            return IsUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;


            try
            {
                ObjsqlCommand.Parameters.Clear();
                ObjsqlCommand.CommandText = "udp_DeleteEmployee";
                ObjsqlCommand.Parameters.AddWithValue("@Id", id);
               
                ObjSqlConnection.Open();
                int noofrowaffected = ObjsqlCommand.ExecuteNonQuery();
                isDeleted = noofrowaffected > 0;
            }

            catch (SqlException ex)
            {
                throw ex;
            }
            finally { ObjSqlConnection.Close(); }
            return isDeleted;
        }
    }

}
