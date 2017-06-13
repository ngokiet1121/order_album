using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderDao
/// </summary>
public class OrderDao
{
    public OrderDao()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool Insert(ref Orders item)
    {
        string sql = "insert into Orders values(@Status,@CustomerEmail,@OrderDate,@TotalAmount,@Note,@EmployeeEmail,@ReceivedDate,@ShipmentId);SELECT SCOPE_IDENTITY()";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Status", item.status);
                cmd.Parameters.AddWithValue("CustomerEmail", item.customerEmail.email);
                cmd.Parameters.AddWithValue("OrderDate", item.orderDate);
                cmd.Parameters.AddWithValue("TotalAmount", item.totalAmount);
                cmd.Parameters.AddWithValue("Note", item.note);
                cmd.Parameters.AddWithValue("EmployeeEmail", item.employeeEmail.email);
                cmd.Parameters.AddWithValue("ReceivedDate", item.receivedDate);
                cmd.Parameters.AddWithValue("ShipmentId", item.shipmentId.shipmentId);
                item.orderId = Convert.ToInt32(cmd.ExecuteScalar());
                return item.orderId > 0;
            }
        }
    }

    public bool Update(Orders item)
    {
        string sql = @"update Orders set EmployeeEmail = @EmployeeEmail ,Status = @Status where OrderId = @OrderId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("OrderId", item.orderId);
                cmd.Parameters.AddWithValue("EmployeeEmail", item.employeeEmail.email);
                cmd.Parameters.AddWithValue("Status", item.status);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool CancelOrder(Orders item)
    {
        string sql = @"update Orders set Status = @Status where OrderId = @OrderId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("OrderId", item.orderId);
                cmd.Parameters.AddWithValue("Status", item.status);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    //public DataTable FindAll()
    //{
    //    string sql = "select * from Orders";
    //    using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
    //    {
    //        using (SqlCommand cmd = new SqlCommand(sql))
    //        {
    //            using (SqlDataAdapter sda = new SqlDataAdapter())
    //            {
    //                cmd.Connection = con;
    //                sda.SelectCommand = cmd;
    //                using (DataTable dt = new DataTable())
    //                {
    //                    sda.Fill(dt);
    //                    return dt;
    //                }
    //            }
    //        }
    //    }
    //}
    public bool DeleteData(int id)
    {
        string sql = "delete from Orders where OrderId = @OrderId";
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

    public Orders SearchId(int id)
    {
        Orders item;
        string sql = @"select *,b.Email as Email,c.Email as EmailStaff,d.ShipmentId as email 
                    from Orders a, Customers b,Employees c,Shipments d 
                    where a.CustomerEmail = b.Email and a.EmployeeEmail = c.Email and a.ShipmentId = d.ShipmentId and OrderId=@OrderId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("OrderId", id);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                item = new Orders
                {
                    orderId = reader.GetInt32(reader.GetOrdinal("OrderId")),
                    status = reader.GetInt32(reader.GetOrdinal("Status")),

                    customerEmail = new Customers
                    {
                        email = reader.GetString(reader.GetOrdinal("Email")),
                    },
                    orderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                    totalAmount = double.Parse(reader.GetValue(reader.GetOrdinal("TotalAmount")).ToString()),
                    note = reader.GetString(reader.GetOrdinal("Note")),
                    employeeEmail = new Employees
                    {
                        email = reader.GetString(reader.GetOrdinal("EmailStaff")),
                    },
                    receivedDate = reader.GetDateTime(reader.GetOrdinal("ReceivedDate")),
                    shipmentId = new Shipments
                    {
                        shipmentId = reader.GetInt32(reader.GetOrdinal("ShipmentId")),
                        email = reader.GetString(reader.GetOrdinal("Email"))
                    }
                };
                return item;
            }
        }
    }

    public List<Orders> FillAll()
    {
        List<Orders> list = new List<Orders>();
        string sql = @"select *,b.FullName as FullName,c.FullName as empFullName,d.ShipmentId as email 
from Orders a, Customers b,Employees c,Shipments d 
where a.CustomerEmail = b.Email and a.EmployeeEmail = c.Email and a.ShipmentId = d.ShipmentId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Orders item = new Orders
                    {
                        orderId = reader.GetInt32(reader.GetOrdinal("OrderId")),
                        status = reader.GetInt32(reader.GetOrdinal("Status")),
                        customerEmail = new Customers
                        {
                            email = reader.GetString(reader.GetOrdinal("Email")),
                            fullName = reader.GetString(reader.GetOrdinal("FullName"))
                        },
                        orderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                        totalAmount = double.Parse(reader.GetValue(reader.GetOrdinal("TotalAmount")).ToString()),
                        note = reader.GetString(reader.GetOrdinal("Note")),
                        employeeEmail = new Employees
                        {
                            email = reader.GetString(reader.GetOrdinal("Email")),
                            fullName = reader.GetString(reader.GetOrdinal("empFullName")),
                        },
                        receivedDate = reader.GetDateTime(reader.GetOrdinal("ReceivedDate")),
                        shipmentId = new Shipments
                        {
                            shipmentId = reader.GetInt32(reader.GetOrdinal("ShipmentId")),
                            email = reader.GetString(reader.GetOrdinal("Email"))
                        }
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }

    public List<Orders> FindAllByCustomer(string email)
    {
        List<Orders> list = new List<Orders>();
        string sql = @"select * from Orders Where CustomerEmail = @CustomerEmail and status = 1 or status = 2 or status = 4";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("CustomerEmail", email);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Orders item = new Orders
                    {
                        orderId = reader.GetInt32(reader.GetOrdinal("OrderId")),
                        status = reader.GetInt32(reader.GetOrdinal("Status")),                        
                        orderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                        totalAmount = double.Parse(reader.GetValue(reader.GetOrdinal("TotalAmount")).ToString()),
                        note = reader.GetString(reader.GetOrdinal("Note")),                      
                        receivedDate = reader.GetDateTime(reader.GetOrdinal("ReceivedDate")),                        
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }

    public bool Changestatus(int orderId,int status)
    {
        string sql = @"update Orders set Status = @Status where OrderId = @OrderId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("OrderId", orderId);
                cmd.Parameters.AddWithValue("Status", status);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}