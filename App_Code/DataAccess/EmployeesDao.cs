using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for EmployeesDao
/// </summary>
public class EmployeesDao
{
	public EmployeesDao()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool Insert(Employees emp)
    {
        string conSt = WebConfigurationManager.ConnectionStrings["OrderAlbumDBConnectionString"].ToString();
        string sql = "INSERT INTO Employees VALUES(@Email,@FullName,@Password,@Phone, "+
                    " @DateOfBirth,@Address,@Gender,@Role,@Status)";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Email", emp.email);
                cmd.Parameters.AddWithValue("FullName",emp.fullName);
                cmd.Parameters.AddWithValue("Password", emp.password);
                cmd.Parameters.AddWithValue("Phone", emp.phone);
                cmd.Parameters.AddWithValue("DateOfBirth", emp.dateOfBirth);
                cmd.Parameters.AddWithValue("Address", emp.address);
                cmd.Parameters.AddWithValue("Gender", emp.gender);
                cmd.Parameters.AddWithValue("Role", emp.role);
                cmd.Parameters.AddWithValue("Status", emp.status);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool Update(Employees emp)
    {
        string sql = "UPDATE Employees SET FullName=@FullName,"
        +"Phone=@Phone, DateOfBirth=@DateOfBirth, Address=@Address, Gender=@Gender "
        +" WHERE Email = @Email";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("FullName", emp.fullName);
                cmd.Parameters.AddWithValue("Phone", emp.phone);
                cmd.Parameters.AddWithValue("DateOfBirth", emp.dateOfBirth);
                cmd.Parameters.AddWithValue("Address", emp.address);
                cmd.Parameters.AddWithValue("Gender", emp.gender);
                cmd.Parameters.AddWithValue("Email", emp.email);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
    public bool UpdateStaff(Employees emp)
    {
        string sql = "UPDATE Employees SET FullName=@FullName,"
        + "Phone=@Phone, DateOfBirth=@DateOfBirth, Address=@Address, Gender=@Gender,Role=@Role, "
        + "Status=@Status WHERE Email = @Email";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("FullName", emp.fullName);
                cmd.Parameters.AddWithValue("Phone", emp.phone);
                cmd.Parameters.AddWithValue("DateOfBirth", emp.dateOfBirth);
                cmd.Parameters.AddWithValue("Address", emp.address);
                cmd.Parameters.AddWithValue("Gender", emp.gender);
                cmd.Parameters.AddWithValue("Role", emp.role);
                cmd.Parameters.AddWithValue("Status", emp.status);
                cmd.Parameters.AddWithValue("Email", emp.email);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public List<Employees> FindAll()
    {
        List<Employees> list = new List<Employees>();
        string sql = "SELECT * FROM Employees";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Employees emp = new Employees
                    {
                        email = reader.GetString(0),
                        fullName = reader.GetString(1),
                        password = reader.GetString(2),
                        phone   = reader.GetString(3),
                        dateOfBirth = reader.GetDateTime(4), 
                        address = reader.GetString(5),
                        gender = reader.GetBoolean(6),
                        role=reader.GetInt32(7),
                        status=reader.GetInt32(8)
                    };
                    list.Add(emp);
                }
                reader.Close();
                return list;
            }
        }
    }

    public DataTable FindAllEmployee()
    {
        string sql = "SELECT * FROM Employees";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand(sql))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
    public bool DeleteData(string email)
    {
        string sql = "DELETE FROM Employees WHERE Email = @Email";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Email", email);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public Employees FindId(string email)
    {
        Employees emp;
        string sql = "SELECT * FROM Employees WHERE Email=@Email";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Email", email);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                emp = new Employees
                {
                    email = reader.GetString(reader.GetOrdinal("Email")),
                    fullName = reader.GetString(reader.GetOrdinal("FullName")),
                    password = reader.GetString(reader.GetOrdinal("Password")),
                    phone = reader.GetString(reader.GetOrdinal("Phone")),
                    dateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                    address = reader.GetString(reader.GetOrdinal("Address")),
                    gender = reader.GetBoolean(reader.GetOrdinal("Gender")),
                    role = reader.GetInt32(reader.GetOrdinal("role")),
                    status = reader.GetInt32(reader.GetOrdinal("Status"))
                };
                reader.Close();
                return emp;
            }
        }
    }

    public Employees Search(Employees emp)
    {

        string sql = "SELECT * FROM Employees WHERE Email=@Email";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Email", emp.email);
                Employees item = null;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new Employees
                    {
                        email = reader.GetString(0),
                        fullName = reader.GetString(1),
                        password = reader.GetString(2),
                        phone = reader.GetString(3),
                        dateOfBirth = reader.GetDateTime(4),
                        gender = reader.GetBoolean(5),
                        address = reader.GetString(6),
                        role = reader.GetInt32(7),
                        status = reader.GetInt32(8)
                    };
                }
                reader.Close();
                return item;
            }
        }
    }
}