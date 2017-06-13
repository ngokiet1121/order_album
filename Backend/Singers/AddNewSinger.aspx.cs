using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Backend_Singers_AddNewSinger : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack){
            BindDataGroup();
            BindDataNational();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            SingerDao dao = new SingerDao();
            Singers singer = new Singers
            {
                singerId = txtIdSinger.Text,
                name = txtName.Text,
                description = txtDescription.Text,
                dateOfBirth =Convert.ToDateTime(txtDOB.Text),
                gender = Convert.ToBoolean(ddlGender.SelectedValue),
                image = txtImage.FileName,
                groupId = new Groups
                {
                    groupId = Convert.ToInt32(ddlGroup.SelectedValue)
                },
                nationalityId = new Nationalities
                {
                    nationalityId = Convert.ToString(ddlNationality.SelectedValue)
                }
                
            };
            if (dao.Insert(singer))
            {
                string fileName = Path.GetFileName(txtImage.FileName);
                txtImage.SaveAs(Server.MapPath("~/Images/Singer/") + fileName);
                Response.Redirect("ListSingers.aspx");
            }
            else
            {
                lblMessage.Text = "Error Add";
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    public void BindDataGroup()
    {
        try
        {
            GroupDao dao = new GroupDao();
            List<Groups> list = dao.FindAll();
            ddlGroup.DataSource = list;
            ddlGroup.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }

    public void BindDataNational()
    {
        try
        {
            NationalityDao dao = new NationalityDao();
            List<Nationalities> list = dao.FindAll();
            ddlNationality.DataSource = list;
            ddlNationality.DataBind();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
    }
}