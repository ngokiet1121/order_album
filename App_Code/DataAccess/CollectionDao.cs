using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for CollectionDao
/// </summary>
public class CollectionDao
{
    public CollectionDao()
    {
    }
    public bool CheckLogin(string email,string password)
    {
        string sql = "select * from Employees where Email=@Email and Password=@Password";

        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            //SqlDataReader reader = new SqlDataReader();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Email", email);
                cmd.Parameters.AddWithValue("Password", password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return true;
            }
        }
        return false;
    }

    public bool CheckAdmin(string email, int adminRole)
    {
        string sql = "SELECT * FROM Employees WHERE Email=@Email AND Role=@Role";

        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            //SqlDataReader reader = new SqlDataReader();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Email", email);
                cmd.Parameters.AddWithValue("Role", adminRole);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return true;
            }
        }
        return false;
    }
   
    public bool ChangePass(string email,string password) 
    {
        string sql = "update Employees set Password=@Password where Email=@Email";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            //SqlDataReader reader = new SqlDataReader();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Email", email);
                cmd.Parameters.AddWithValue("Password", password);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool ChangePassCus(string email, string password)
    {
        string sql = "update Customers set Password=@Password where Email=@Email";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            //SqlDataReader reader = new SqlDataReader();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Email", email);
                cmd.Parameters.AddWithValue("Password", password);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public void SendEmail(string customerEmail,string subject,string body)
    {      
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        mail.From = new MailAddress("ngoletuankiet1@gmail.com");
        mail.To.Add(customerEmail);
        mail.Subject = subject;
        mail.Body = body;
        SmtpServer.Port = 587;
        SmtpServer.Credentials = new System.Net.NetworkCredential("ngoletuankiet1@gmail.com", "kirito1121");
        SmtpServer.EnableSsl = true;
        SmtpServer.Send(mail);
    }

    public bool CheckCustomer(string email)
    {
        string sql = "SELECT * FROM Customers WHERE Email=@Email AND Status=@Status";

        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            //SqlDataReader reader = new SqlDataReader();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Email", email);
                cmd.Parameters.AddWithValue("Status", 1);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return true;
            }
        }
        return false;
    }

    public bool checkCusLogin(string email, string password)
    {
        string sql = "select * from customers where Email=@Email and Password=@Password";

        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            //SqlDataReader reader = new SqlDataReader();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Email", email);
                cmd.Parameters.AddWithValue("Password", password);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    return true;
            }
        }
        return false;
    }
}