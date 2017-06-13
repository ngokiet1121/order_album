using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GroupDao
/// </summary>
public class GroupDao
{
	public GroupDao()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool Insert(Groups item)
    {
        string sql = "insert into Groups values(@Name,@Image,@Type,@Description)";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Name", item.name);
                cmd.Parameters.AddWithValue("Image", item.image);
                cmd.Parameters.AddWithValue("Type", item.type);
                cmd.Parameters.AddWithValue("Description", item.description);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
    //public bool Insert(ref Groups item)
    //{
    //    string sql = "insert into Groups values(@Name);SELECT SCOPE_IDENTITY;";
    //    using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
    //    {
    //        con.Open();
    //        using (SqlCommand cmd = new SqlCommand(sql, con))
    //        {
    //            cmd.Parameters.AddWithValue("Name", item.name);
    //            cmd.Parameters.AddWithValue("Name", item.name);
    //            cmd.Parameters.AddWithValue("Image", item.image);
    //            cmd.Parameters.AddWithValue("Type", item.type);
    //            cmd.Parameters.AddWithValue("Description", item.description);
    //            item.genresId = (int)cmd.ExecuteScalar();
    //            return cmd.ExecuteNonQuery() > 0;
    //        }
    //    }
    //}
    public bool Update(Groups item)
    {
        string sql = "update Groups set Name = @Name,Image = @Image,Type = @Type, Description = @Description where GroupId = @GroupId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("GroupId", item.groupId);
                cmd.Parameters.AddWithValue("Name", item.name);
                cmd.Parameters.AddWithValue("Image", item.image);
                cmd.Parameters.AddWithValue("Type", item.type);
                cmd.Parameters.AddWithValue("Description", item.description);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public DataTable FindAll2()
    {
        string sql = "select * from Groups";
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
        string sql = "delete from Groups where GroupId = @GroupId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("GroupId", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

    public Groups SearchId(int id)
    {
        Groups item;
        string sql = "select * from Groups where GroupId=@GroupId";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("GroupId", id);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                item = new Groups
                {
                    groupId = reader.GetInt32(0),
                    name = reader.GetString(1),
                    image = reader.GetString(2),
                    type = reader.GetInt32(3),
                    description = reader.GetString(4)
                };
                reader.Close();
                return item;
            }
        }
    }
    public List<Groups> FindByName(string name)
    {
        List<Groups> list = new List<Groups>();
        string sql = "select * from Groups where Name=@Name";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("Name", name);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Groups item = new Groups
                    {
                        groupId = reader.GetInt32(0),
                        name = reader.GetString(1),
                        image = reader.GetString(2),
                        type = reader.GetInt32(3),
                        description = reader.GetString(4)
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }

    public List<Groups> FindAll()
    {
        List<Groups> list = new List<Groups>();
        string sql = "select * from Groups";
        using (SqlConnection con = new SqlConnection(DataConfig.ConnectionString))
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Groups item = new Groups
                    {
                        groupId = reader.GetInt32(0),
                        name = reader.GetString(1),
                        image = reader.GetString(2),
                        type = reader.GetInt32(3),
                        description = reader.GetString(4)
                    };
                    list.Add(item);
                }
                reader.Close();
                return list;
            }
        }
    }

}