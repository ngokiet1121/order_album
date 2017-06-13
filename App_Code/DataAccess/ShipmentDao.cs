using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Summary description for ShipmentDao
/// </summary>
public class ShipmentDao
{
	public ShipmentDao()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool Insert(ref Shipments ship)
    {
        string conSt = WebConfigurationManager.ConnectionStrings["OrderAlbumDBConnectionString"].ToString();
        string sql = @"INSERT INTO Shipments(Name,Email,Phone,Address) 
                    VALUES(@Name,@Email,@Phone,@Address);SELECT SCOPE_IDENTITY()";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Name", ship.name);
                cmd.Parameters.AddWithValue("Email", ship.email);
                cmd.Parameters.AddWithValue("Phone", ship.phone);
                cmd.Parameters.AddWithValue("Address", ship.address);
                ship.shipmentId = Convert.ToInt32(cmd.ExecuteScalar());
                return ship.shipmentId > 0;
            }
        }
    }

    public bool Update(Shipments ship)
    {
        string sql = @"UPDATE Shipments SET Name = @Name, 
                    Email=@Email, Phone=@Phone, Address=@Address
                    WHERE ShipmentId = @ShipmentId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("ShipmentId", ship.shipmentId);
                cmd.Parameters.AddWithValue("Name", ship.name);
                cmd.Parameters.AddWithValue("Email", ship.email);
                cmd.Parameters.AddWithValue("Phone", ship.phone);
                cmd.Parameters.AddWithValue("Address", ship.address);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
    public List<Shipments> FindAll()
    {
        List<Shipments> list = new List<Shipments>();
        string sql = "SELECT * FROM Shipments";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Shipments item = new Shipments
                    {
                        shipmentId = reader.GetInt32(0),
                        name = reader.GetString(1),
                        email = reader.GetString(2),
                        phone = reader.GetString(3),
                        address = reader.GetString(4)
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }

    public DataTable FindAllShipments()
    {
        string sql = "SELECT * FROM Shipments";
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
        string sql = "DELETE FROM Shipments WHERE ShipmentId = @ShipmentId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("ShipmentId", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public Shipments FindId(int id)
    {
        Shipments ship;
        string sql = "SELECT * FROM Shipments WHERE ShipmentId=@ShipmentId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("ShipmentId", id);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                ship = new Shipments
                {
                    shipmentId = reader.GetInt32(0),
                    name = reader.GetString(1),
                    email = reader.GetString(2),
                    phone = reader.GetString(3),
                    address = reader.GetString(4)
                };
                reader.Close();
                return ship;
            }
        }
    }

    public Shipments Search(Shipments ship)
    {

        string sql = "SELECT * FROM Shipments WHERE ShipmentsId=@ShipmentsId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("ShipmentsId", ship.shipmentId);
                Shipments item = null;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    item = new Shipments
                    {
                        shipmentId = reader.GetInt32(0),
                        name = reader.GetString(1),
                        email = reader.GetString(2),
                        phone = reader.GetString(3),
                        address = reader.GetString(4)
                    };
                }
                reader.Close();
                return item;
            }
        }
    }
}