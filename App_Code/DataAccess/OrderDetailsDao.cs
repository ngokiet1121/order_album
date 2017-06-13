using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for OrderDetailsDao
/// </summary>
public class OrderDetailsDao
{
	public OrderDetailsDao()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool Insert(OrderDetails odDetail)
    {
        string conSt = WebConfigurationManager.ConnectionStrings["OrderAlbumDBConnectionString"].ToString();
        string sql = "INSERT INTO OrderDetails(OrderId,AlbumId,Quantity,Unitprice,CodeId,Tax,ShippingFee,Note,Image,TotalPrice) " +
                    "VALUES(@OrderId,@AlbumId,@Quantity,@Unitprice,@CodeId,@Tax,@ShippingFee,@Note,@Image,@TotalPrice)";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("OrderId", odDetail.orderId.orderId);
                cmd.Parameters.AddWithValue("AlbumId", odDetail.albumId.albumId);
                cmd.Parameters.AddWithValue("Quantity", odDetail.quantity);
                cmd.Parameters.AddWithValue("Unitprice", odDetail.unitprice);
                cmd.Parameters.AddWithValue("CodeId", odDetail.codeId.codeId);
                cmd.Parameters.AddWithValue("Tax", odDetail.tax);
                cmd.Parameters.AddWithValue("ShippingFee", odDetail.shippingFee);
                cmd.Parameters.AddWithValue("Note", odDetail.note);
                cmd.Parameters.AddWithValue("Image", odDetail.image);
                cmd.Parameters.AddWithValue("TotalPrice", odDetail.TotalPrice);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool Update(OrderDetails odDetail)
    {
        string sql = "UPDATE OrderDetails SET Quantity=@Quantity, "+
                     "Unitprice=@Unitprice,CodeId=@CodeId," +
                     " Tax=@Tax,ShippingFee=@ShippingFee,Note=@Note "+
                     " WHERE OrderId = @OrderId AND AlbumId = @AlbumId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("OrderId", odDetail.orderId.orderId);
                cmd.Parameters.AddWithValue("AlbumId", odDetail.albumId.albumId);
                cmd.Parameters.AddWithValue("Quantity", odDetail.quantity);
                cmd.Parameters.AddWithValue("Unitprice", odDetail.unitprice);
                cmd.Parameters.AddWithValue("CodeId", odDetail.codeId.codeId);
                cmd.Parameters.AddWithValue("Tax", odDetail.tax);
                cmd.Parameters.AddWithValue("ShippingFee", odDetail.shippingFee);
                cmd.Parameters.AddWithValue("Note", odDetail.note);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public List<OrderDetails> FindAll(int id)
    {
        List<OrderDetails> list = new List<OrderDetails>();
        string sql = @"SELECT a.*,b.OrderId as OrderId ,c.Name as AlbumName,d.Code as code
                      FROM OrderDetails a, Orders b, Albums c, CodeSales d
                      WHERE a.OrderId=b.OrderId AND a.AlbumId=c.AlbumId
                      AND a.CodeId=d.CodeId AND a.OrderId=@OrderId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString)) 
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("OrderId", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OrderDetails odDetail = new OrderDetails()
                    {
                        orderId = new Orders
                        {
                            orderId = reader.GetInt32(reader.GetOrdinal("OrderId"))
                        },
                        albumId = new Albums
                        {
                            albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                            name = reader.GetString(reader.GetOrdinal("AlbumName"))
                        },
                        quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                        unitprice = double.Parse(reader.GetValue(reader.GetOrdinal("Unitprice")).ToString()),
                        codeId = new CodeSales
                        {
                            codeId = reader.GetInt32(reader.GetOrdinal("CodeId")),
                            code = reader.GetString(reader.GetOrdinal("code"))
                        },
                        tax = float.Parse(reader.GetValue(reader.GetOrdinal("Tax")).ToString()),
                        shippingFee = float.Parse(reader.GetValue(reader.GetOrdinal("ShippingFee")).ToString()),
                        note=reader.GetString(reader.GetOrdinal("Note")),
                        image = reader.GetString(reader.GetOrdinal("Image")),
                        
                    }; 
                    list.Add(odDetail);
                }
                reader.Close();
                return list;
            }
        }
    }

    public OrderDetails FindId(int orderId, int albumId)
    {
        OrderDetails odDetail;
        string sql = "SELECT * FROM OrderDetails WHERE OrderId = @OrderId AND AlbumId=@AlbumId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("OrderId", orderId);
                cmd.Parameters.AddWithValue("AlbumId", albumId);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                odDetail = new OrderDetails
                {
                     orderId = new Orders
                        {
                            orderId = reader.GetInt32(reader.GetOrdinal("OrderId"))
                         
                        },
                        albumId = new Albums
                        {
                            albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                            name = reader.GetString(reader.GetOrdinal("Name"))
                        },
                        quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                        unitprice = reader.GetDouble(reader.GetOrdinal("Unitprice")),
                        codeId = new CodeSales
                        {
                            codeId=reader.GetInt32(reader.GetOrdinal("SaleId"))
                        },
                        tax = reader.GetFloat(reader.GetOrdinal("Tax")),
                        shippingFee = reader.GetFloat(reader.GetOrdinal("ShippingFee")),
                        note=reader.GetString(reader.GetOrdinal("Note")),
                        image = reader.GetString(reader.GetOrdinal("Image")),
                      
                };
                reader.Close();
                return odDetail;
            }
        }
    }
    public OrderDetails FindIdAlbum(int albumId)
    {
        OrderDetails odDetail;
        string sql = "SELECT * FROM OrderDetails WHERE AlbumId=@AlbumId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("AlbumId", albumId);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                odDetail = new OrderDetails
                {
                    quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),                   
                };
                reader.Close();
                return odDetail;
            }
        }
    }
    public OrderDetails Search(OrderDetails odDetail)
    {

        string sql = "SELECT * FROM OrderDetails WHERE OrderId = @OrderId AND AlbumId=@AlbumId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("OrderId", odDetail.orderId.orderId);
                cmd.Parameters.AddWithValue("AlbumId", odDetail.albumId.albumId);
                OrderDetails item = null;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new OrderDetails
                    {
                         orderId = new Orders
                        {
                            orderId = reader.GetInt32(reader.GetOrdinal("OrderId"))
                         
                        },
                        albumId = new Albums
                        {
                            albumId = reader.GetInt32(reader.GetOrdinal("AlbumId")),
                            name = reader.GetString(reader.GetOrdinal("Name"))
                        },
                        quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                         unitprice = reader.GetFloat(reader.GetOrdinal("unitprice")),
                        codeId = new CodeSales
                        {
                            codeId=reader.GetInt32(reader.GetOrdinal("SaleId"))
                        },
                        tax = reader.GetFloat(reader.GetOrdinal("Tax")),
                        shippingFee = reader.GetFloat(reader.GetOrdinal("ShippingFee")),
                        note=reader.GetString(reader.GetOrdinal("Note")),
                        image = reader.GetString(reader.GetOrdinal("Image")),
                       
                    };
                }
                reader.Close();
                return item;
            }
        }
    }

    public bool Delete(int id)
    {
        string sql = "delete from OrderDetails where OrderId = @OrderId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("OrderId", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}