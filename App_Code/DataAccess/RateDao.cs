using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for RateDao
/// </summary>
public class RateDao
{
	public RateDao()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool Insert(Rates rates)
    {
        string conSt = WebConfigurationManager.ConnectionStrings["OrderAlbumDBConnectionString"].ToString();
        string sql = "INSERT INTO Rates(AlbumId,Rate) VALUES(@AlbumId,@Rate)";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("AlbumId", rates.albumId.albumId);
                cmd.Parameters.AddWithValue("Rate", rates.rate);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool Update(Rates rates)
    {
        string sql = "UPDATE Rates SET AlbumId=@AlbumId, " +
                     "Rate=@Rate" +
                     " WHERE RateId = @RateId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("OrderId", rates.albumId.albumId);
                cmd.Parameters.AddWithValue("Rate", rates.rate);
                cmd.Parameters.AddWithValue("RateId", rates.rateId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public List<Rates> FindAll()
    {
        List<Rates> list = new List<Rates>();
        string sql = "SELECT a.*,b.AlbumId FROM Rates a, Albums b " +
                    "WHERE a.AlbumId=b.AlbumId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Rates rates = new Rates()
                    {
                        rateId = reader.GetInt32(reader.GetOrdinal("RateId")),
                        albumId = new Albums
                        {
                            albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                            name = reader.GetString(reader.GetOrdinal("Name"))
                        },
                        rate = reader.GetFloat(reader.GetOrdinal("Rate"))
                        
                    };
                    list.Add(rates);
                }
                reader.Close();
                return list;
            }
        }
    }

    public DataTable FindAllRates()
    {
        string sql = "SELECT * FROM Rates";
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

    public bool DeleteData(int rateId)
    {
        string sql = "DELETE FROM Rates WHERE RateId = @RateId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("RateId", rateId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public Rates FindId(int rateId)
    {
        Rates rates;
        string sql = "SELECT * FROM Rates WHERE RateId = @RateId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("RateId", rateId);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                rates = new Rates
                {
                    rateId = reader.GetInt32(reader.GetOrdinal("RateId")),
                    albumId = new Albums
                    {
                        albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                        name = reader.GetString(reader.GetOrdinal("Name"))
                    },
                    rate = reader.GetFloat(reader.GetOrdinal("Rate"))
                };
                reader.Close();
                return rates;
            }
        }
    }

    public Rates Search(Rates rates)
    {

        string sql = "SELECT * FROM Rates WHERE RateId = @RateId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("RateId", rates.rateId);
                cmd.Parameters.AddWithValue("AlbumId", rates.albumId.albumId);
                cmd.Parameters.AddWithValue("Rate", rates.rate);
                Rates item = null;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new Rates
                    {
                        rateId = reader.GetInt32(reader.GetOrdinal("RateId")),
                        albumId = new Albums
                        {
                            albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                            name = reader.GetString(reader.GetOrdinal("Name"))
                        },
                        rate = reader.GetFloat(reader.GetOrdinal("Rate"))
                    };
                }
                reader.Close();
                return item;
            }
        }
    }
}