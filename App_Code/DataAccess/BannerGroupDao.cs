using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BannerGroupDao
/// </summary>
public class BannerGroupDao
{
	public BannerGroupDao()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool Insert(BannerGroups item)
    {
        string sql = "insert into BannerGroups values(@Image,@GroupId)";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Image", item.image);
                cmd.Parameters.AddWithValue("GroupId", item.groupId.groupId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool Update(BannerGroups item)
    {
        string sql = "update BannerGroups set"
            + " Image = @Image,GroupId =  @GroupId"
            + " where BannerId = @BannerId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("BannerId", item.bannerId);
                cmd.Parameters.AddWithValue("Image", item.image);
                cmd.Parameters.AddWithValue("GroupId", item.groupId.groupId);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public bool DeleteData(int id)
    {
        string sql = "delete from BannerGroups where BannerId = @BannerId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("BannerId", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    /*public BannerGroups SearchId(int id)
    {
        BannerGroups item;
        string sql = "select * from BannerGroups where BannerId=@BannerId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("BannerId", id);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                item = new BannerGroups();
                item.bannerId = reader.GetInt32(0);
                item.image = reader.GetString(1);
                item.groupId.groupId = reader.GetInt32(2);
                return item;
            }
        }
    }
    */

    public BannerGroups SearchId(int bannerId)
    {
        BannerGroups bannergr;
        string sql = "SELECT * FROM BannerGroups WHERE BannerId = @BannerId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("BannerId", bannerId);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                bannergr = new BannerGroups
                {
                    bannerId = reader.GetInt32(reader.GetOrdinal("BannerId")),
                    image = reader.GetString(reader.GetOrdinal("Image")),
      
                    groupId = new Groups
                    {
                        groupId = reader.GetInt32(reader.GetOrdinal("GroupId")),
                        //name = reader.GetString(reader.GetOrdinal("Name"))
                    }
                };
                reader.Close();
                return bannergr;
            }
        }
    }

    public List<BannerGroups> FindAll()
    {
        List<BannerGroups> list = new List<BannerGroups>();
        string sql = @"select *, b.Name as group_name 
                    FROM BannerGroups as a, Groups as b WHERE a.GroupId=b.GroupId ";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BannerGroups item = new BannerGroups
                    {
                        bannerId = reader.GetInt32(0),
                        image = reader.GetString(1),
                        groupId = new Groups
                        {
                            groupId = reader.GetInt32(reader.GetOrdinal("GroupId")),
                            name    = reader.GetString(reader.GetOrdinal("group_name"))
                        }
                    };
                     list.Add(item);   
                }
                reader.Close();
                return list;
            }
        }
    }


}