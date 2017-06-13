using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GenresDao
/// </summary>
public class GenresDao
{
	public GenresDao()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Insert(Genres item)
    {
        string sql = "insert into Genres values(@Name)";
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

    public bool Update(Genres item)
    {
        string sql = "update Genres set Name = @Name where GenresId = @GenresId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("GenresId", item.genresId);
                cmd.Parameters.AddWithValue("Name", item.name);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public DataTable FindAll2()
    {
        string sql = "select * from Genres";
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
        string sql = "delete from Genres where GenresId = @GenresId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("GenresId", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public Genres SearchId(int id)
    {
        Genres item;
        string sql = "select * from Genres where GenresId=@GenresId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("GenresId", id);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                item = new Genres
                {
                    genresId = reader.GetInt32(0),
                    name = reader.GetString(1)
                };
                reader.Close();
                return item;
            }
        }
    }
    public List<Genres> FindByName(string name) 
    {
        List<Genres> list = new List<Genres>();
        string sql = "select * from Genres where Name=@Name";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Name", name);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Genres item = new Genres
                    {
                        genresId = reader.GetInt32(0),
                        name = reader.GetString(1)
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }
    public List<Genres> FindAll()
    {
        List<Genres> list = new List<Genres>();
        string sql = "select * from Genres";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Genres item = new Genres
                    {
                        genresId = reader.GetInt32(0),
                        name = reader.GetString(1)
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }
    public Genres Search(Genres gen)
    {
        Genres item;
        string sql = "select * from Genres where GenresId=@GenresId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("GenresId", gen.genresId);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                item = new Genres
                {
                    genresId = reader.GetInt32(0),
                    name = reader.GetString(1)
                };
                reader.Close();
                return item;
            }
        }
    }
}