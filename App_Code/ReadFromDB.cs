using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ReadFromDB
/// </summary>
public class ReadData
{
    ObjectInfo obj = new ObjectInfo();
    public ReadData()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public ObjectInfo ReadFromDB(string InsertedName)
    {


        using (SqlConnection con = new SqlConnection())
        {
            List<string> photos = new List<string>();
            List<string> streetview = new List<string>();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["UrbanDBConnectionString1"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Select * from Manor where Name=@name";
                cmd.Parameters.AddWithValue("@name", InsertedName);
                cmd.Connection = con;
                con.Open();

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        obj.id = Int32.Parse(oReader["Manor_Id"].ToString());
                        obj.Name = oReader["Name"].ToString();
                        obj.MapsURL = oReader["MapsURL"].ToString();
                        obj.Info = oReader["Info"].ToString();
                        obj.Notes = oReader["Notes"].ToString();
                        obj.MapsPhoto = oReader["MapsPhoto"].ToString();
                        obj.TopoPhoto = oReader["TopoPhoto"].ToString();
                        obj.SatellitePhoto = oReader["SatellitePhoto"].ToString();
                    }

                }

                cmd.CommandText = "Select * from Photos where Manor_Id = @ManorId";
                cmd.Parameters.AddWithValue("@ManorId", obj.id);

                using(SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        photos.Add(oReader["Photo"].ToString());
                    }
                }

                cmd.CommandText = "Select * from Streetview where Manor_Id = @ManorId";

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        streetview.Add(oReader["Streetview"].ToString());
                    }
                }
            }

            con.Close();
        }
        return obj;
    }

    public ObjectInfo ReadFromDBInt(int id)
    {
        List<string> photos = new List<string>();
        List<string> streetview = new List<string>();
        using (SqlConnection con = new SqlConnection())
        {
            con.ConnectionString = ConfigurationManager.ConnectionStrings["UrbanDBConnectionString1"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "Select * from Manor where Id=@id";
                cmd.Parameters.AddWithValue("@Manor_Id", id);
                cmd.Connection = con;
                con.Open();

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        obj.id = Int32.Parse(oReader["Manor_Id"].ToString());
                        obj.Name = oReader["Name"].ToString();
                        obj.MapsURL = oReader["MapsURL"].ToString();
                        obj.Info = oReader["Info"].ToString();
                        obj.Notes = oReader["Notes"].ToString();
                        obj.MapsPhoto = oReader["MapsPhoto"].ToString();
                        obj.TopoPhoto = oReader["TopoPhoto"].ToString();
                        obj.SatellitePhoto = oReader["SatellitePhoto"].ToString();
                    }


                }

                cmd.CommandText = "Select * from Photos where Manor_Id = @ManorId";
                cmd.Parameters.AddWithValue("@ManorId", obj.id);

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        photos.Add(oReader["Photo"].ToString());
                    }
                }

                cmd.CommandText = "Select * from Streetview where Manor_Id = @ManorId";

                using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        streetview.Add(oReader["Streetview"].ToString());
                    }
                }
            }
            con.Close();
        }
        return obj;
    }
}