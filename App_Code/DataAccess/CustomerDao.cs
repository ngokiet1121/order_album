using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CustomerDao
/// </summary>
public class CustomerDao
{
	public CustomerDao()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Insert(Customers cus)
    {

        string sql = "INSERT INTO Customers VALUES(@Email,@FullName,@Password,@DateOfBirth,@Phone, " +
                    " @Address,@Gender,@Status,@RegisterDate)";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Email", cus.email);
                cmd.Parameters.AddWithValue("FullName", cus.fullName);
                cmd.Parameters.AddWithValue("Password", cus.password);
                cmd.Parameters.AddWithValue("Phone", cus.phone);
                cmd.Parameters.AddWithValue("DateOfBirth", cus.dateOfBirth);
                cmd.Parameters.AddWithValue("Address", cus.address);
                cmd.Parameters.AddWithValue("Gender", cus.gender);
                cmd.Parameters.AddWithValue("Status", 1);
                cmd.Parameters.AddWithValue("RegisterDate", DateTime.Now);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool Update(Customers cus)
    {
        string sql = @"UPDATE Customers SET FullName=@FullName,
        DateOfBirth=@DateOfBirth, Phone=@Phone,  Address=@Address, Gender=@Gender
        WHERE Email = @Email";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("FullName", cus.fullName);
                cmd.Parameters.AddWithValue("DateOfBirth", cus.dateOfBirth);
                cmd.Parameters.AddWithValue("Phone", cus.phone);
                cmd.Parameters.AddWithValue("Address", cus.address);
                cmd.Parameters.AddWithValue("Gender", cus.gender);
                cmd.Parameters.AddWithValue("Email", cus.email);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public List<Customers> FindAll()
    {
        List<Customers> list = new List<Customers>();
        string sql = "SELECT * FROM Customers";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customers cus = new Customers
                    {
                        email = reader.GetString(0),
                        fullName = reader.GetString(1),
                        password = reader.GetString(2),
                        dateOfBirth = reader.GetDateTime(3),
                        phone = reader.GetString(4),
                        address = reader.GetString(5),
                        gender = reader.GetBoolean(6),
                        status = reader.GetInt32(7),
                        registeredDate = reader.GetDateTime(8)
                    };
                    list.Add(cus);
                }
                reader.Close();
                return list;
            }
        }
    }

    public bool DeleteData(string email)
    {
        string sql = "DELETE FROM Customers WHERE Email = @Email";
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

    public Customers FindCustomer(string email)
    {
        Customers emp;
        string sql = "SELECT * FROM Customers WHERE Email=@Email";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Email", email);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                emp = new Customers
                {
                    email = reader.GetString(0),
                    fullName = reader.GetString(1),
                    password = reader.GetString(2),
                    dateOfBirth = reader.GetDateTime(3),
                    phone = reader.GetString(4),
                    address = reader.GetString(5),
                    gender = reader.GetBoolean(6),
                    status = reader.GetInt32(7),
                    registeredDate = reader.GetDateTime(8)
                };
                reader.Close();
                return emp;
            }
        }
    }

    public Customers Search(Customers cus)
    {

        string sql = "SELECT * FROM Customers WHERE Email=@Email";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Email", cus.email);
                Customers item = null;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new Customers
                    {
                        email = reader.GetString(0),
                        fullName = reader.GetString(1),
                        password = reader.GetString(2),               
                        dateOfBirth = reader.GetDateTime(3),
                        phone = reader.GetString(5),
                        address = reader.GetString(6),
                        status = reader.GetInt32(8),
                        registeredDate = reader.GetDateTime(9)
                    };
                }
                reader.Close();
                return item;
            }
        }
    }

    public bool UpdateStatus(Customers cus)
    {
        string sql = "UPDATE Customers set Status=@Status"
        + " WHERE Email = @Email";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Status", cus.status);
                cmd.Parameters.AddWithValue("Email", cus.email);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool ChangePass(string email, string pass)
    {
        string sql = "UPDATE Customers set Password=@Password"
        + " WHERE Email = @Email";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("PassWord", pass);
                cmd.Parameters.AddWithValue("Email", email);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}