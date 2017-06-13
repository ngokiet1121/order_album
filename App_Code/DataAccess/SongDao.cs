using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for SongDao
/// </summary>
public class SongDao
{
	public SongDao()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Insert(Songs song)
    {
        string conSt = WebConfigurationManager.ConnectionStrings["OrderAlbumDBConnectionString"].ToString();
        string sql = @"INSERT INTO Songs(Name, AlbumId,GroupId,GenresId,Authors) 
                    VALUES(@Name,@AlbumId,@GroupId,@GenresId,@Authors)";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Name", song.name);
                cmd.Parameters.AddWithValue("AlbumId", song.albumId.albumId);
                cmd.Parameters.AddWithValue("GroupId", song.groupId.groupId);
                cmd.Parameters.AddWithValue("GenresId", song.genreId.genresId);
                cmd.Parameters.AddWithValue("Authors", song.authors);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool Update(Songs song)
    {
        string sql = @"UPDATE Songs SET Name=@Name, AlbumId=@AlbumId, GroupId=@GroupId,
                    GenresId=@GenresId, Authors=@Authors WHERE SongId = @SongId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("SongId", song.songId);
                cmd.Parameters.AddWithValue("Name", song.name);
                cmd.Parameters.AddWithValue("AlbumId", song.albumId.albumId);
                cmd.Parameters.AddWithValue("GroupId", song.groupId.groupId);
                cmd.Parameters.AddWithValue("GenresId", song.genreId.genresId);
                cmd.Parameters.AddWithValue("Authors", song.authors);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public List<Songs> FindAll()
    {
        List<Songs> list = new List<Songs>();
        string sql = @"SELECT a.*,b.Name as group_name,c.Name as album_name,d.Name as genres_name FROM Songs a, Groups b, Albums c, Genres d 
                        WHERE a.GroupId=b.GroupId AND a.AlbumId=c.AlbumId AND a.GenresId=d.GenresId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Songs song = new Songs()
                    {
                        songId = reader.GetInt32(reader.GetOrdinal("SongId")),
                        name = reader.GetString(reader.GetOrdinal("Name")),

                        albumId = new Albums
                        {
                            albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                            name = reader.GetString(reader.GetOrdinal("album_name"))
                        },
                        groupId = new Groups
                        {
                            groupId = reader.GetInt32(reader.GetOrdinal("GroupId")),
                            name = reader.GetString(reader.GetOrdinal("group_name"))
                        },
                        genreId = new Genres
                        {
                            genresId = reader.GetInt32(reader.GetOrdinal("GenresId")),
                            name = reader.GetString(reader.GetOrdinal("genres_name"))
                        },
                        authors = reader.GetString(reader.GetOrdinal("Authors"))
                    };
                    list.Add(song);
                }
                reader.Close();
                return list;
            }
        }
    }

    public DataTable FindAllSong()
    {
        string sql = "SELECT * FROM Songs";
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

    public bool DeleteData(int songId)
    {
        string sql = "DELETE FROM Songs WHERE SongId = @SongId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("SongId", songId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
    public Songs FindId(int songId)
    {
        Songs song;
        string sql = "SELECT * FROM Songs WHERE SongId = @SongId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("SongId", songId);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                song = new Songs
                {
                    songId = reader.GetInt32(reader.GetOrdinal("SongId")),
                    name = reader.GetString(reader.GetOrdinal("Name")),

                    albumId = new Albums
                    {
                        albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                        name = reader.GetString(reader.GetOrdinal("Name"))
                    },
                    groupId = new Groups
                    {
                        groupId = reader.GetInt32(reader.GetOrdinal("GroupId")),
                        name = reader.GetString(reader.GetOrdinal("Name"))
                    },
                    genreId = new Genres
                    {
                        genresId = reader.GetInt32(reader.GetOrdinal("GenresId")),
                        name = reader.GetString(reader.GetOrdinal("Name"))
                    },
                    authors = reader.GetString(reader.GetOrdinal("Authors"))
                };
                reader.Close();
                return song;
            }
        }
    }

    public Songs Search(Songs song)
    {

        string sql = "SELECT * FROM Songs WHERE SongId = @SongId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("SongId", song.songId);
                cmd.Parameters.AddWithValue("Name", song.name);
                cmd.Parameters.AddWithValue("AlbumId", song.albumId.albumId);
                cmd.Parameters.AddWithValue("GroupId", song.groupId.groupId);
                cmd.Parameters.AddWithValue("GenresId", song.genreId.genresId);
                cmd.Parameters.AddWithValue("Authors", song.authors);
                Songs item = null;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new Songs
                    {
                        songId = reader.GetInt32(reader.GetOrdinal("SongId")),
                        name = reader.GetString(reader.GetOrdinal("Name")),

                        albumId = new Albums
                        {
                            albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                            name = reader.GetString(reader.GetOrdinal("Name"))
                        },
                        groupId = new Groups
                        {
                            groupId = reader.GetInt32(reader.GetOrdinal("GroupId")),
                            name = reader.GetString(reader.GetOrdinal("Name"))
                        },
                        genreId = new Genres
                        {
                            genresId = reader.GetInt32(reader.GetOrdinal("GenresId")),
                            name = reader.GetString(reader.GetOrdinal("Name"))
                        },
                        authors = reader.GetString(reader.GetOrdinal("Authors"))
                    };
                }
                reader.Close();
                return item;
            }
        }
    }
}