using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.Services;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    public int idToEdit = 0;
    ObjectInfo obj = new ObjectInfo();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ShowOnPage(string name)
    {
        ReadData read = new ReadData();
        obj = read.ReadFromDB(name);
        ObjectName.Text = obj.Name;
        InfoLabel.Text = obj.Info;
        NotesLabel.Text = obj.Notes;
        MapsIMG.ImageUrl = obj.MapsPhoto;
        SatelliteIMG.ImageUrl = obj.SatellitePhoto;
        TopoIMG.ImageUrl = obj.TopoPhoto;
        MapsURL.NavigateUrl = obj.MapsURL;
        if (obj.MapsURL == null || obj.MapsURL == "")
        { }
        else
            MapsURL.Text = "Location";
        idToEdit = obj.id;

        ContentBlock.Visible = true;
        EditCurrent.Visible = true;
    }

    protected void SearchTB_TextChanged(object sender, EventArgs e)
    {

    }



    [WebMethod]
    public static List<string> GetObjectName(string objectName)
    {

            List<string> objResult = new List<string>();
    using (SqlConnection con = new SqlConnection())
    {
    con.ConnectionString = ConfigurationManager.ConnectionStrings["UrbanDBConnectionString1"].ConnectionString;
    using (SqlCommand cmd = new SqlCommand())
        {
            cmd.CommandText = "select Name from Manor where Name like @SearchText + '%'";
            cmd.Parameters.AddWithValue("@SearchText", objectName);
            cmd.Connection = con;
            con.Open();

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                        objResult.Add(dr["Name"].ToString());
                }
            }
            con.Close();

        }
    }
        return objResult;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {


    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        List<string> objResult = new List<string>();
        using (SqlConnection con = new SqlConnection())
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["UrbanDBConnectionString1"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "select Name from Manor where Name like @SearchText + '%'";
                cmd.Parameters.AddWithValue("@SearchText", SearchTB.Text);
                cmd.Connection = con;
                con.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        objResult.Add(dr["Name"].ToString());
                    }
                }
                con.Close();

            }
        }

        var list = new List<ItemsInSearchList>();

        foreach(var objItem in objResult)
        {
            list.Add(new ItemsInSearchList(objItem));
        }
   
        
        SearchLV.Visible = true;
        SearchLV.DataSource = list;
        SearchLV.DataBind();
        ContentBlock.Visible = false;

    }

    protected void SearchLV_ItemCommand(object sender, ListViewCommandEventArgs e)
    {

        SearchLV.Visible = false;
        SearchTB.Text = e.CommandName;
        ShowOnPage(e.CommandName);
    }

    protected void EditCurrent_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddNewObject.aspx");
    }
}