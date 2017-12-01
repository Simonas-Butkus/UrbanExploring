using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using System.Diagnostics;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Data;

public partial class AddNewObject : Page
{
    string connectionString;
    string path;
    protected void Page_Load(object sender, EventArgs e)
    {
        path = "~/Upload/" + NormalizeString(ManorName.Text) + "/";


        ObjectInfo.Init();
        if(ObjectToEditInfo.id != 0 && !IsPostBack)
            EditObject();

    }

    protected void SubmitData(object sender, EventArgs e)
    {
        if (ObjectToEditInfo.id == 0)
            WriteToDB();
        else
            UpdateDB();

        Response.Redirect("Default.aspx");
    }

    protected string SavePhoto(FileUpload Photo)
    {
        if (!Photo.HasFile)
            return "NULL";
        else
        {
            string name = Photo.FileName;
            Photo.PostedFile.SaveAs(Server.MapPath(path + name));

            return path + name.ToString();
        }
    }

    protected string[] SavePhotos()
    {
        int i = 0;
        string[] PhotosNames = new string[20];
        foreach (var photo in ManorPhotos.PostedFiles)
        {
            if (ManorPhotos.PostedFiles.ElementAt(i).ContentLength > 0)
            {
                string name = ManorPhotos.PostedFiles.ElementAt(i).FileName;
                ManorPhotos.PostedFiles.ElementAt(i).SaveAs(Server.MapPath(path + name));
                PhotosNames[i] = path + name.ToString();
            }
            else
            {
                PhotosNames[i] = "NULL";
            }
            i++;
        }

        return PhotosNames;
    }

    protected string[] SaveStreet()
    {
        int i = 0;
        string[] PhotosNames = new string[20];
        foreach (var photo in StreetPhotos.PostedFiles)
        {
            if (StreetPhotos.PostedFiles.ElementAt(i).ContentLength > 0)
            {
                string name = StreetPhotos.PostedFiles.ElementAt(i).FileName;
                StreetPhotos.PostedFiles.ElementAt(i).SaveAs(Server.MapPath(path + name));
                PhotosNames[i] = path + name.ToString();
            }
            else
            {
                PhotosNames[i] = "NULL";
            }
            i++;
        }

        return PhotosNames;
    }

    private string NormalizeString(string text)
    {
        text = Regex.Replace(text, @"\s+", "");
        var normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }
        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);

    }


    public void EditObject()
    {
        ReadData read = new ReadData();
        read.ReadFromDBInt(ObjectToEditInfo.id);
        ShowOnPage();
    }

    protected void ShowOnPage()
    {
        ManorName.Text = ObjectInfo.Name;
        MapsURL.Text = ObjectInfo.MapsURL;
        Information.Text = ObjectInfo.Info;
        Notes.Text = ObjectInfo.Notes;

    }


    public void WriteToDB()
    {

        System.IO.Directory.CreateDirectory(Server.MapPath(path));

        using (SqlConnection con = new SqlConnection())
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["UrbanDBConnectionString1"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "insert into Manor (Name, MapsURL, Info, Notes, MapsPhoto, TopoPhoto, SatellitePhoto) " +
                        "values(@Name, @MapsURL, @Info, @Notes, @MapsPhoto, @TopoPhoto, @SatellitePhoto)";
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@Name", ManorName.Text);
                cmd.Parameters.AddWithValue("@MapsURL", MapsURL.Text);
                cmd.Parameters.AddWithValue("@Info", Information.Text);
                cmd.Parameters.AddWithValue("@Notes", Notes.Text);
                cmd.Parameters.AddWithValue("@MapsPhoto", SavePhoto(MapsPhotoUp));
                cmd.Parameters.AddWithValue("@TopoPhoto", SavePhoto(TopoPhoto));
                cmd.Parameters.AddWithValue("@SatellitePhoto", SavePhoto(SatellitePhoto));

                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT TOP 1 * FROM Manor ORDER BY Manor_Id DESC";
                var Id = cmd.ExecuteScalar();

                cmd.CommandText = "Insert Into Photos (Photo, Manor_Id) Values (@Photo, @Manor_Id)";
                string[] Photos = SavePhotos();
                cmd.Parameters.Add("@Photo", SqlDbType.VarChar);
                cmd.Parameters.Add("@Manor_Id", SqlDbType.Int);

                foreach (var photo in Photos)
                {
                    if (photo != "" && photo != null)
                    {

                        cmd.Parameters["@Photo"].Value = photo;
                        cmd.Parameters["@Manor_Id"].Value = Id;

                        cmd.ExecuteNonQuery();
                    }
                }

                Photos = SaveStreet();
                cmd.CommandText = "Insert Into Streetview (Streetview, Manor_Id) Values (@Streetview, @Manor_Id)";
                cmd.Parameters.Add("@Streetview", SqlDbType.VarChar);

                foreach (var photo in Photos)
                {
                    if (photo != "" && photo != null)
                    {

                        cmd.Parameters["@Streetview"].Value = photo;
                        cmd.Parameters["@Manor_Id"].Value = Id;

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            con.Close();
        }
    }


    public void UpdateDB()
    {
        using (SqlConnection con = new SqlConnection())
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["UrbanDBConnectionString1"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Update Manor " +
                                  "SET Name = @Name, MapsURL = @MapsURL, Info = @Info, Notes = @Notes " +
                                  "Where Id = @Id";
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@Name", ManorName.Text);
                cmd.Parameters.AddWithValue("@MapsURL", MapsURL.Text);
                cmd.Parameters.AddWithValue("@Info", Information.Text);
                cmd.Parameters.AddWithValue("@Notes", Notes.Text);
                cmd.Parameters.AddWithValue("@Id", ObjectToEditInfo.id);

                cmd.ExecuteNonQuery();

                con.Close();
            }
        }
    }

}