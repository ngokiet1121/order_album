using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for MadeInDao
/// </summary>
public class ProducerDao
{
    public ProducerDao()
    {

    }
    public bool Insert(Producers item)
    {
        string sql = "insert into Producers values(@Name)";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Name", item.name);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
    public bool Insert(ref Producers item)
    {
        string sql = "insert into Producers values(@Name);SELECT SCOPE_IDENTITY;";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Name", item.name);
                item.producerId = (int)cmd.ExecuteScalar();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
    public bool Update(Producers item)
    {
        string sql = "update Producers set Name = @Name where ProducerId = @ProducerId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("ProducerId", item.producerId);
                cmd.Parameters.AddWithValue("Name", item.name);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
    public List<Producers> FindAll()
    {
        List<Producers> list = new List<Producers>();
        string sql = "select * from Producers";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Producers item = new Producers
                    {
                        producerId = reader.GetInt32(0),
                        name = reader.GetString(1)
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }
    public DataTable FindAll2()
    {
        string sql = "select * from Producers";
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

    public bool DeleteData(int id)
    {
        string sql = "delete from Producers where ProducerId = @ProducerId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("ProducerId", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public Producers SearchId(int id)
    {
        Producers item;
        string sql = "select * from Producers where ProducerId=@ProducerId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("ProducerId", id);
                SqlDataReader reader = cmd.ExecuteReader();              
                reader.Read();
                item = new Producers
                {
                    producerId = reader.GetInt32(0),
                    name = reader.GetString(1)
                };
                reader.Close();
                return item;
            }
        }
    }
    public Producers Search(Producers pro)
    {
        
        string sql = "select * from Producers where ProducerId=@ProducerId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("ProducerId", pro.producerId);
                Producers item = null;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new Producers
                    {
                        producerId = reader.GetInt32(0),
                        name = reader.GetString(1)
                    };
                }
                reader.Close();
                return item;
            }
        }
    }
}