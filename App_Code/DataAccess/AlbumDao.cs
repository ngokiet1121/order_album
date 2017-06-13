using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Album
/// </summary>
public class AlbumDao
{
    public AlbumDao()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    ProducerDao dao = new ProducerDao();
    public bool Insert(Albums item)
    {
        string sql = "insert into Albums values(@Name,@Quantity,@MadeIn,@UnitPrice,@Status,@Description,@Image,@PublishedDate,@EnteredDate,@Rate,@Tags)";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Name", item.name);
                cmd.Parameters.AddWithValue("Quantity", item.quantity);
                cmd.Parameters.AddWithValue("MadeIn", item.producerId.producerId);
                cmd.Parameters.AddWithValue("UnitPrice", item.unitPrice);
                cmd.Parameters.AddWithValue("Image", item.image);
                cmd.Parameters.AddWithValue("PublishedDate", item.publishedDate);
                cmd.Parameters.AddWithValue("EnteredDate", item.enteredDate);
                cmd.Parameters.AddWithValue("Description", item.description);
                cmd.Parameters.AddWithValue("Status", item.status);
                cmd.Parameters.AddWithValue("Rate", item.rate);
                cmd.Parameters.AddWithValue("Tags", item.tags);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
    public bool Update(Albums item)
    {
        string sql = "update Albums set"
            + " Name = @Name,Quantity =  @Quantity,ProducerId = @ProducerId,UnitPrice = @UnitPrice,Status = @Status,Description = @Description,Image = @Image, PublishedDate = @PublishedDate,EnteredDate = @EnteredDate,Rate = @Rate,Tags = @Tags"
            + " where AlbumId = @AlbumId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("AlbumId", item.albumId);
                cmd.Parameters.AddWithValue("Name", item.name);
                cmd.Parameters.AddWithValue("Quantity", item.quantity);
                cmd.Parameters.AddWithValue("ProducerId", item.producerId.producerId);
                cmd.Parameters.AddWithValue("UnitPrice", item.unitPrice);
                cmd.Parameters.AddWithValue("Image", item.image);
                cmd.Parameters.AddWithValue("PublishedDate", item.publishedDate);
                cmd.Parameters.AddWithValue("EnteredDate", item.enteredDate);
                cmd.Parameters.AddWithValue("Description", item.description);
                cmd.Parameters.AddWithValue("Status", item.status);
                cmd.Parameters.AddWithValue("Rate", item.rate);
                cmd.Parameters.AddWithValue("Tags", item.tags);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool UpdateStatus(Albums item)
    {
        string sql = "update Albums set"
            + " Status=@Status"
            + " where AlbumId = @AlbumId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                
                cmd.Parameters.AddWithValue("Status", item.status);
                cmd.Parameters.AddWithValue("AlbumId", item.albumId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
    public bool UpdateQuantity(Albums item)
    {
        string sql = "update Albums set"
            + " Quantity=@Quantity"
            + " where AlbumId = @AlbumId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {

                cmd.Parameters.AddWithValue("Quantity", item.quantity);
                cmd.Parameters.AddWithValue("AlbumId", item.albumId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
    public bool UpdateQuantity(List<Albums> items)
    {
        string sql = "update Albums set"
            + " Quantity=Quantity-@Quantity"
            + " where AlbumId = @AlbumId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                foreach (var item in items)
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Transaction = trans;
                        cmd.Parameters.AddWithValue("Quantity", item.quantity);
                        cmd.Parameters.AddWithValue("AlbumId", item.albumId);
                        cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            
        }
    }
    public bool UpdateQuantityAdd(List<Albums> items)
    {
        string sql = "update Albums set"
            + " Quantity=Quantity+@Quantity"
            + " where AlbumId = @AlbumId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            SqlTransaction trans = con.BeginTransaction();
            try
            {
                foreach (var item in items)
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Transaction = trans;
                        cmd.Parameters.AddWithValue("Quantity", item.quantity);
                        cmd.Parameters.AddWithValue("AlbumId", item.albumId);
                        cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }

        }
    }
    public DataTable FindAll2()
    {
        string sql = "select * from Albums";
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
        string sql = "delete from Albums where AlbumId = @AlbumId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("AlbumId", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public Albums SearchId(int id)
    {
        Albums item;
        string sql = "select *,b.Name as PName from Albums a, Producers b where a.ProducerId=b.ProducerId and a.AlbumId=@AlbumId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("AlbumId", id);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                item = new Albums
                {
                    albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                    name = reader.GetString(reader.GetOrdinal("Name")),
                    quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    producerId = new Producers
                    {
                        producerId = reader.GetInt32(reader.GetOrdinal("ProducerId")),
                        name = reader.GetString(reader.GetOrdinal("PName"))
                    },
                    unitPrice = float.Parse(reader.GetValue(reader.GetOrdinal("UnitPrice")).ToString()),
                    status = reader.GetInt32(reader.GetOrdinal("Status")),
                    description = reader.GetString(reader.GetOrdinal("Description")),
                    image = reader.GetString(reader.GetOrdinal("Image")),
                    publishedDate = reader.GetDateTime(reader.GetOrdinal("PublishedDate")),
                    enteredDate = reader.GetDateTime(reader.GetOrdinal("EnteredDate")),
                    rate = float.Parse(reader.GetValue(reader.GetOrdinal("Rate")).ToString()),
                    tags = reader.GetString(reader.GetOrdinal("Tags"))
                };
                reader.Close();
                return item;
            }
        }
    }
    public List<Albums> FindAll()
    {
        List<Albums> list = new List<Albums>();
        string sql = "select *,b.Name as producer_name from Albums a,Producers b where a.ProducerId = b.ProducerId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Albums item = new Albums
                    {
                        albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                        name = reader.GetString(reader.GetOrdinal("Name")),
                        quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                        producerId = new Producers
                        {
                            producerId = reader.GetInt32(reader.GetOrdinal("ProducerId")),
                            name = reader.GetString(reader.GetOrdinal("producer_name"))
                        },
                        //unitPrice = reader.GetDouble(reader.GetOrdinal("UnitPrice")),
                        unitPrice = float.Parse(reader.GetValue(reader.GetOrdinal("UnitPrice")).ToString()),
                        status = reader.GetInt32(reader.GetOrdinal("Status")),
                        description = reader.GetString(reader.GetOrdinal("Description")),
                        image = reader.GetString(reader.GetOrdinal("Image")),
                        publishedDate = reader.GetDateTime(reader.GetOrdinal("PublishedDate")),
                        enteredDate = reader.GetDateTime(reader.GetOrdinal("EnteredDate")),
                       // rate = reader.GetFloat(reader.GetOrdinal("Rate")),
                        rate = float.Parse(reader.GetValue(reader.GetOrdinal("Rate")).ToString()),                       
                        tags = reader.GetString(reader.GetOrdinal("Tags"))
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }

    public List<Albums> FindAlbumsByGroups(int groupId)
    {
        List<Albums> list = new List<Albums>();
        string sql = @"SELECT Albums.AlbumId,Albums.Name, Albums.UnitPrice, Albums.Image
                    FROM Albums INNER JOIN Songs 
                    ON Albums.AlbumId=Songs.AlbumId
                    WHERE Songs.GroupId=@GroupId
                    GROUP BY Albums.AlbumId,Albums.Name, Albums.UnitPrice, Albums.Image";
        // string sql = "@SELECT * FROM Albums WHERE Albums.Gr";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("GroupId", groupId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Albums item = new Albums
                    {
                        albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                        name = reader.GetString(reader.GetOrdinal("Name")),
                        //unitPrice = reader.GetDouble(reader.GetOrdinal("UnitPrice")),
                        unitPrice = float.Parse(reader.GetValue(reader.GetOrdinal("UnitPrice")).ToString()),
                        //description = reader.GetString(reader.GetOrdinal("Description")),
                        image = reader.GetString(reader.GetOrdinal("Image")),

                        // rate = reader.GetFloat(reader.GetOrdinal("Rate")),

                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }

    public List<Albums> FindAlbumsByGenres(int genresId)
    {
        List<Albums> list = new List<Albums>();
        string sql = @"SELECT Albums.AlbumId,Albums.Name, Albums.UnitPrice, Albums.Image
                    FROM Albums INNER JOIN Songs 
                    ON Albums.AlbumId=Songs.AlbumId
                    WHERE Songs.GenresId=@GenresId
                    GROUP BY Albums.AlbumId,Albums.Name, Albums.UnitPrice, Albums.Image";
        // string sql = "@SELECT * FROM Albums WHERE Albums.Gr";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("GenresId", genresId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Albums item = new Albums
                    {
                        albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                        name = reader.GetString(reader.GetOrdinal("Name")),
                        unitPrice = float.Parse(reader.GetValue(reader.GetOrdinal("UnitPrice")).ToString()),
                        image = reader.GetString(reader.GetOrdinal("Image")),
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }

    public List<Albums> FindAlbumsByProducer(int producerId)
    {
        List<Albums> list = new List<Albums>();
        string sql = @"select * from Albums where ProducerId = @ProducerId";
        // string sql = "@SELECT * FROM Albums WHERE Albums.Gr";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("ProducerId", producerId);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Albums item = new Albums
                    {
                        albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                        name = reader.GetString(reader.GetOrdinal("Name")),
                        unitPrice = float.Parse(reader.GetValue(reader.GetOrdinal("UnitPrice")).ToString()),
                        image = reader.GetString(reader.GetOrdinal("Image")),
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }
    public List<Albums> FindAlbumsByStatus(int status)
    {
        List<Albums> list = new List<Albums>();
        string sql = @"select * from Albums where Status = @Status";
        // string sql = "@SELECT * FROM Albums WHERE Albums.Gr";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Status", status);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Albums item = new Albums
                    {
                        albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                        name = reader.GetString(reader.GetOrdinal("Name")),
                        unitPrice = float.Parse(reader.GetValue(reader.GetOrdinal("UnitPrice")).ToString()),
                        image = reader.GetString(reader.GetOrdinal("Image")),
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }
    public Albums SearchByName(string name)
    {
        Albums item;
        string sql = "select *,b.Name as PName from Albums a, Producers b where a.ProducerId=b.ProducerId and a.Name like @Name";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Name", name);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                item = new Albums
                {
                    albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                    name = reader.GetString(reader.GetOrdinal("Name")),
                    quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                    producerId = new Producers
                    {
                        producerId = reader.GetInt32(reader.GetOrdinal("ProducerId")),
                        name = reader.GetString(reader.GetOrdinal("PName"))
                    },
                    unitPrice = float.Parse(reader.GetValue(reader.GetOrdinal("UnitPrice")).ToString()),
                    status = reader.GetInt32(reader.GetOrdinal("Status")),
                    description = reader.GetString(reader.GetOrdinal("Description")),
                    image = reader.GetString(reader.GetOrdinal("Image")),
                    publishedDate = reader.GetDateTime(reader.GetOrdinal("PublishedDate")),
                    enteredDate = reader.GetDateTime(reader.GetOrdinal("EnteredDate")),
                    rate = float.Parse(reader.GetValue(reader.GetOrdinal("Rate")).ToString()),
                    tags = reader.GetString(reader.GetOrdinal("Tags"))
                };
                reader.Close();
                return item;
            }
        }
    }
}