using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CodeSaleDao
/// </summary>
public class CodeSaleDao
{
    public CodeSaleDao()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool Insert(CodeSales item)
    {
        string sql = "insert into CodeSales values(@BeginDate,@EndDate,@PercentSales,@Status,@Code)";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("BeginDate", item.beginDate);
                cmd.Parameters.AddWithValue("EndDate", item.endDate);
                cmd.Parameters.AddWithValue("PercentSales", item.percentSales);
                cmd.Parameters.AddWithValue("Status", item.status);
                cmd.Parameters.AddWithValue("Code", item.code);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool Update(CodeSales item)
    {
        string sql = "update CodeSales set"
            + " BeginDate = @BeginDate,EndDate =  @EndDate, PercentSales= @PercentSales, Status=@Status,Code=@Code"
            + " where CodeId = @CodeId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("CodeId", item.codeId);
                cmd.Parameters.AddWithValue("BeginDate", item.beginDate);
                cmd.Parameters.AddWithValue("EndDate", item.endDate);
                cmd.Parameters.AddWithValue("PercentSales", item.percentSales);
                cmd.Parameters.AddWithValue("Status", item.status);
                cmd.Parameters.AddWithValue("Code", item.code);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
    public List<CodeSales> FindAll()
    {
        List<CodeSales> list = new List<CodeSales>();
        string sql = "select * from CodeSales";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();

               while( reader.Read()){
                   CodeSales item = new CodeSales
                   {
                       codeId = reader.GetInt32(0),
                       beginDate = reader.GetDateTime(1),
                       endDate = reader.GetDateTime(2),
                       percentSales = reader.GetInt32(3),
                       status = reader.GetInt32(4),
                       code = reader.GetString(5)
                   };
                   list.Add(item);
                }
               reader.Close();
               return list;
            }
        }
    }
    public bool DeleteData(int id)
    {
        string sql = "delete from CodeSales where CodeId = @CodeId";
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

    public CodeSales SearchId(string code)
    {
        CodeSales item;
        string sql = "select * from CodeSales where Code LIKE @Code";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Code", code);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                item = new CodeSales();
                item.codeId = reader.GetInt32(0);
                item.beginDate = reader.GetDateTime(1);
                item.endDate = reader.GetDateTime(2);
                item.percentSales = reader.GetInt32(3);
                item.status = reader.GetInt32(4);
                item.code = reader.GetString(5);
                return item;
            }
        }
    }
}