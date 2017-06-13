using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NationalityDao
/// </summary>
public class NationalityDao
{
	public NationalityDao()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Insert(Nationalities item)
    {
        string sql = "insert into Nationalities values(@NationalityId,@Name)";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {

                cmd.Parameters.AddWithValue("NationalityId", item.nationalityId);
                cmd.Parameters.AddWithValue("Name", item.name);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool Update(Nationalities item)
    {
        string sql = "update Nationalities set Name = @Name where NationalityId = @NationalityId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("NationalityId", item.nationalityId);
                cmd.Parameters.AddWithValue("Name", item.name);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public Nationalities SearchId(string id)
    {
        Nationalities item;
        string sql = "select * from Nationalities where NationalityId=@NationalityId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("NationalityId", id);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                item = new Nationalities
                {
                    nationalityId = reader.GetString(0),
                    name = reader.GetString(1)
                };
                reader.Close();
                return item;
            }
        }
    }
    public bool DeleteData(string id)
    {
        string sql = "delete from Nationalities where NationalityId = @NationalityId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("NationalityId", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public List<Nationalities> FindByName(string name)
    {
        List<Nationalities> list = new List<Nationalities>();
        string sql = "select * from Nationalities where Name=@Name";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Name", name);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Nationalities item = new Nationalities
                    {
                        nationalityId = reader.GetString(0),
                        name = reader.GetString(1)
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }
    public List<Nationalities> FindAll()
    {
        List<Nationalities> list = new List<Nationalities>();
        string sql = "select * from Nationalities";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Nationalities item = new Nationalities
                    {
                        nationalityId = reader.GetString(0),
                        name = reader.GetString(1)
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }
}