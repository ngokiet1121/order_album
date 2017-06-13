using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for SingerDao
/// </summary>
public class SingerDao
{
	public SingerDao()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool Insert(Singers singer)
    {
        string conSt = WebConfigurationManager.ConnectionStrings["OrderAlbumDBConnectionString"].ToString();
        string sql = @"INSERT INTO Singers(SingerId, Name, Description,Image,Gender,
                    DateOfBirth,GroupId,NationalityId) 
                    VALUES(@SingerId, @Name,@Description,@Image,@Gender,
                    @DateOfBirth,@GroupId,@NationalityId)";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("SingerId", singer.singerId);
                cmd.Parameters.AddWithValue("Name", singer.name);
                cmd.Parameters.AddWithValue("Description", singer.description);
                cmd.Parameters.AddWithValue("Image", singer.image);
                cmd.Parameters.AddWithValue("Gender", singer.gender);
                cmd.Parameters.AddWithValue("DateOfBirth", singer.dateOfBirth);
                cmd.Parameters.AddWithValue("GroupId", singer.groupId.groupId);
                cmd.Parameters.AddWithValue("NationalityId", singer.nationalityId.nationalityId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool Update(Singers singer)
    {
        string sql = @"UPDATE Singers SET Name=@Name, Description=@Description, Image=@Image,
                    Gender=@Gender, DateOfBirth=@DateOfBirth, GroupId=@GroupId, 
                    NationalityId=@NationalityId WHERE SingerId = @SingerId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("SingerId", singer.singerId);
                cmd.Parameters.AddWithValue("Name", singer.name);
                cmd.Parameters.AddWithValue("Description", singer.description);
                cmd.Parameters.AddWithValue("Image", singer.image);
                cmd.Parameters.AddWithValue("Gender", singer.gender);
                cmd.Parameters.AddWithValue("DateOfBirth", singer.dateOfBirth);
                cmd.Parameters.AddWithValue("GroupId", singer.groupId.groupId);
                cmd.Parameters.AddWithValue("NationalityId", singer.nationalityId.nationalityId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public List<Singers> FindAll()
    {
        List<Singers> list = new List<Singers>();
        string sql = "SELECT a.*,b.Name as GroupName,c.Name as NationalName FROM Singers a, Groups b, Nationalities c " +
                    "WHERE a.GroupId=b.GroupId AND a.NationalityId=c.NationalityId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Singers singer = new Singers()
                    {
                        singerId = reader.GetString(reader.GetOrdinal("SingerId")),
                        name = reader.GetString(reader.GetOrdinal("Name")),
                        description = reader.GetString(reader.GetOrdinal("Description")),
                        image = reader.GetString(reader.GetOrdinal("Image")),
                        gender = reader.GetBoolean(reader.GetOrdinal("Gender")),
                        dateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                        groupId = new Groups
                        {
                            groupId = reader.GetInt32(reader.GetOrdinal("GroupId")),
                            name = reader.GetString(reader.GetOrdinal("GroupName"))
                        },
                        nationalityId = new Nationalities
                        {
                            nationalityId = reader.GetString(reader.GetOrdinal("NationalityId")),
                            name = reader.GetString(reader.GetOrdinal("NationalName"))
                        }
                    };
                    list.Add(singer);
                }
                reader.Close();
                return list;
            }
        }
    }

    public DataTable FindAllSinger()
    {
        string sql = "SELECT * FROM Singers";
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

    public bool DeleteData(string singerId)
    {
        string sql = "DELETE FROM Singers WHERE SingerId = @SingerId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("SingerId", singerId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public Singers FindId(string singerId)
    {
        Singers singer;
        string sql = "SELECT * FROM Singers WHERE SingerId = @SingerId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("SingerId", singerId);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                singer = new Singers
                {
                    singerId = reader.GetString(reader.GetOrdinal("SingerId")),
                    name = reader.GetString(reader.GetOrdinal("Name")),
                    description = reader.GetString(reader.GetOrdinal("Description")),
                    image = reader.GetString(reader.GetOrdinal("Image")),
                    gender = reader.GetBoolean(reader.GetOrdinal("Gender")),
                    dateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                    groupId = new Groups
                    {
                        groupId = reader.GetInt32(reader.GetOrdinal("GroupId")),
                        name = reader.GetString(reader.GetOrdinal("Name"))
                    },
                    nationalityId = new Nationalities
                    {
                        nationalityId = reader.GetString(reader.GetOrdinal("NationalityId")),
                        name = reader.GetString(reader.GetOrdinal("Name"))
                    }
                };
                reader.Close();
                return singer;
            }
        }
    }

    public Singers Search(Singers singer)
    {

        string sql = "SELECT * FROM Singers WHERE SingerId = @SingerId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("SingerId", singer.singerId);
                cmd.Parameters.AddWithValue("Name", singer.name);
                cmd.Parameters.AddWithValue("Description", singer.description);
                cmd.Parameters.AddWithValue("Image", singer.image);
                cmd.Parameters.AddWithValue("Gender", singer.gender);
                cmd.Parameters.AddWithValue("DateOfBirth", singer.dateOfBirth);
                cmd.Parameters.AddWithValue("GroupId", singer.groupId.groupId);
                cmd.Parameters.AddWithValue("NationalityId", singer.nationalityId.nationalityId);
                Singers item = null;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new Singers
                    {
                        singerId = reader.GetString(reader.GetOrdinal("SingerId")),
                        name = reader.GetString(reader.GetOrdinal("Name")),
                        description = reader.GetString(reader.GetOrdinal("Description")),
                        image = reader.GetString(reader.GetOrdinal("Image")),
                        gender = reader.GetBoolean(reader.GetOrdinal("Gender")),
                        dateOfBirth = reader.GetDateTime(reader.GetOrdinal("DateOfBirth")),
                        groupId = new Groups
                        {
                            groupId = reader.GetInt32(reader.GetOrdinal("GroupId")),
                            name = reader.GetString(reader.GetOrdinal("Name"))
                        },
                        nationalityId = new Nationalities
                        {
                            nationalityId = reader.GetString(reader.GetOrdinal("NationalityId")),
                            name = reader.GetString(reader.GetOrdinal("Name"))
                        }
                    };
                }
                reader.Close();
                return item;
            }
        }
    }
}