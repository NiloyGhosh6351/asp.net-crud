using System.Data;
using System.Data.SqlClient;

namespace CRUDAPPDOTNETCORE1.Models
{
    public class DAL
    {
        public Response GetActive(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblCrudNetCore where IsActive=1", connection);
            DataTable dt = new DataTable();
            List<Employee> IstEmployees = new List<Employee>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    employee.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    employee.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    employee.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);

                    IstEmployees.Add(employee);
                }
            }
            if (IstEmployees.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.listEmployee = IstEmployees;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = " No Data found";
                response.listEmployee = null;
            }
            return response;
        }
        public Response GetAllEmployees(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblCrudNetCore", connection);
            DataTable dt = new DataTable();
            List<Employee> IstEmployees = new List<Employee>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    employee.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    employee.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    employee.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);

                    IstEmployees.Add(employee);
                }
            }
            if (IstEmployees.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.listEmployee = IstEmployees;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = " No Data found";
                response.listEmployee = null;
            }
            return response;
        }

        public Response GetEmployeeById(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblCrudNetCore WHERE ID = '" + id + "' AND IsActive = 1", connection);
            DataTable dt = new DataTable();
            Employee Employees = new Employee();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Employee employee = new Employee();
                employee.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                employee.Name = Convert.ToString(dt.Rows[0]["Name"]);
                employee.Email = Convert.ToString(dt.Rows[0]["Email"]);
                employee.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);
                response.StatusCode = 200;
                response.StatusMessage = "Data found";
                response.Employee = employee;

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = " No Data found";
                response.Employee = null;
            }
            return response;
        }


        public Response AddEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO tblCrudNetCore(Name,Email,IsActive,CreateOn) VALUES('" + employee.Name + "','" + employee.Email + "','" + employee.IsActive + "',GETDATE())", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Employee added";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = " No Data inserted";
            }
            return response;
        }

        public Response UpdateEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE tblCrudNetCore SET Name = '" + employee.Name + "', Email ='" + employee.Email + "' WHERE ID = '" + employee.Id + "'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();

            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Employee updated";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = " No Data updated";
            }
            return response;
        }


        public Response DeleteEmployee(SqlConnection connection, int id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE From tblCrudNetCore WHERE ID = '" + id + "' ", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Employee deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No employee deleted";
            }
            return response;
        }
    }
}
