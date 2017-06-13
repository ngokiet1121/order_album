using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MessageDao
/// </summary>
public class MessageDao
{
	public MessageDao()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool Insert(Messages item)
    {
        string sql = "insert into Messages values(@CustomerEmail,@Subject,@Message,@Status,@DateSend)";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("CustomerEmail", item.customerEmail.email);
                cmd.Parameters.AddWithValue("Subject", item.subject);
                cmd.Parameters.AddWithValue("Message", item.message);
                cmd.Parameters.AddWithValue("Status", item.status);
                cmd.Parameters.AddWithValue("DateSend", item.dateSend);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool Update(Messages item)
    {
        string sql = "update Messages set"
            + " Status = @Status"
            + " where MessageId = @MessageId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("MessageId", item.messageId);
                cmd.Parameters.AddWithValue("Status", item.status);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
    public bool DeleteData(int id)
    {
        string sql = "delete from Messages where MessageId = @MessageId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("MessageId", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public Messages SearchId(int id)
    {
        Messages item;
        string sql = "select *,b.Email from Messages a, Customers b where a.CustomerEmail = b.Email and MessageId=@MessageId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("MessageId", id);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                item = new Messages {
                    messageId = reader.GetInt32(reader.GetOrdinal("MessageId")),
                    customerEmail = new Customers
                    {
                        email = reader.GetString(reader.GetOrdinal("Email")),
                    },
                    message = reader.GetString(reader.GetOrdinal("Message")),
                    status = reader.GetInt32(reader.GetOrdinal("Status")),
                    dateSend = reader.GetDateTime(reader.GetOrdinal("DateSend"))
                };
              
                return item;
            }
        }
    }
    public List<Messages> FindAllStatus2()
    {
        List<Messages> list = new List<Messages>();
        string sql = "select *,b.FullName as Name from Messages a,Customers b where a.CustomerEmail = b.Email and a.Status = 2";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Messages item = new Messages
                    {
                        messageId = reader.GetInt32(reader.GetOrdinal("MessageId")),
                        customerEmail = new Customers
                        {
                            email = reader.GetString(reader.GetOrdinal("Email")),
                            fullName = reader.GetString(reader.GetOrdinal("Name"))
                        },                    
                        message = reader.GetString(reader.GetOrdinal("Message")),
                        status = reader.GetInt32(reader.GetOrdinal("Status")),
                        dateSend = reader.GetDateTime(reader.GetOrdinal("DateSend"))
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }
    public List<Messages> FindAllStatus1()
    {
        List<Messages> list = new List<Messages>();
        string sql = "select *,b.FullName as Name from Messages a,Customers b where a.CustomerEmail = b.Email and a.Status = 1";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Messages item = new Messages
                    {
                        messageId = reader.GetInt32(reader.GetOrdinal("MessageId")),
                        customerEmail = new Customers
                        {
                            email = reader.GetString(reader.GetOrdinal("Email")),
                            fullName = reader.GetString(reader.GetOrdinal("Name"))
                        },
                        message = reader.GetString(reader.GetOrdinal("Message")),
                        status = reader.GetInt32(reader.GetOrdinal("Status")),
                        dateSend = reader.GetDateTime(reader.GetOrdinal("DateSend"))
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }

    public List<Messages> FindAll()
    {
        List<Messages> list = new List<Messages>();
        string sql = "select *,b.FullName as Name from Messages a,Customers b where a.CustomerEmail = b.Email";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Messages item = new Messages
                    {
                        messageId = reader.GetInt32(reader.GetOrdinal("MessageId")),
                        customerEmail = new Customers
                        {
                            email = reader.GetString(reader.GetOrdinal("Email")),
                            fullName = reader.GetString(reader.GetOrdinal("Name"))
                        },
                        message = reader.GetString(reader.GetOrdinal("Message")),
                        status = reader.GetInt32(reader.GetOrdinal("Status")),
                        dateSend = reader.GetDateTime(reader.GetOrdinal("DateSend"))
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }
}