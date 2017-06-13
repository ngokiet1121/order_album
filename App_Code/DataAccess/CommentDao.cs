using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommentDao
/// </summary>
public class CommentDao
{
	public CommentDao()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool Insert(Comments item)
    {
        string sql = "insert into Comments values(@CustomerEmail,@AlbumId,@Comment,@Status,@Date)";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("CustomerEmail", item.customerEmail.email);
                cmd.Parameters.AddWithValue("AlbumId", item.albumId.albumId);
                cmd.Parameters.AddWithValue("Comment", item.comment);
                cmd.Parameters.AddWithValue("Status", item.status);
                cmd.Parameters.AddWithValue("Date", item.date);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool Update(Comments item)
    {
        string sql = "update Comments set"
            + " CustomerEmail = @CustomerEmail,AlbumId =  @AlbumId, Comment= @Comment, Status=@Status"
            + " where CommentId = @CommentId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("CommentId", item.commentId);
                cmd.Parameters.AddWithValue("CustomerEmail", item.customerEmail.email);
                cmd.Parameters.AddWithValue("AlbumId", item.albumId.albumId);
                cmd.Parameters.AddWithValue("Comment", item.comment);
                cmd.Parameters.AddWithValue("Status", item.status);               
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
    public bool DeleteData(int id)
    {
        string sql = "delete from Comments where CommentId = @CommentId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("CodeId", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public Comments SearchId(int id)
    {
        Comments item;
        string sql = "select * from Comments where CommentId=@CommentId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("CommentId", id);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                item = new Comments
                {
                    commentId = reader.GetInt32(reader.GetOrdinal("CommentId")),
                    

                    customerEmail = new Customers
                    {
                        email = reader.GetString(reader.GetOrdinal("CustomerEmail")),
                    },
                    albumId = new Albums
                    {
                        albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                    },
                    comment = reader.GetString(reader.GetOrdinal("Comment")),
                    status = reader.GetInt32(reader.GetOrdinal("Status"))
                };
                reader.Close();
                return item;
            }
        }
    }
    public List<Comments> FindAll()
    {
        List<Comments> list = new List<Comments>();
        string sql = "select *,c.Email,b.Name as album_name from Comments a,Albums b,Customers c where a.CustomerEmail = c.Email and a.AlbumId = b.AlbumId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Comments item = new Comments
                    {
                        commentId = reader.GetInt32(reader.GetOrdinal("CommentId")),
                        customerEmail = new Customers
                        {
                            email = reader.GetString(reader.GetOrdinal("Email")),

                        },
                        albumId = new Albums
                        {
                            albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                            name    = reader.GetString(reader.GetOrdinal("album_name"))
                        },
                        

                        comment = reader.GetString(reader.GetOrdinal("Comment")),
                        status = reader.GetInt32(reader.GetOrdinal("Status")),
                        date = reader.GetDateTime(reader.GetOrdinal("Date"))
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }


    public List<Comments> FindAll2(int albumid)
    {
        List<Comments> list = new List<Comments>();
        string sql = @"select CustomerEmail,Comment,Date from Comments where AlbumId = @AlbumId and status = 1";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {

            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("AlbumId", albumid);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Comments item = new Comments
                    {
                       
                        customerEmail = new Customers
                        {
                            email = reader.GetString(reader.GetOrdinal("CustomerEmail")),
                        },
                        comment = reader.GetString(reader.GetOrdinal("Comment")),
                        date = reader.GetDateTime(reader.GetOrdinal("Date"))
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }

}