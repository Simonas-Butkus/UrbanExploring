using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ObjectToEditInfo
/// </summary>
public static class ObjectToEditInfo
{
    public static int id { get; set; }
    public static string Name { get; set; }
    public static string MapsURL { get; set; }
    public static string Info { get; set; }
    public static string Notes { get; set; }
    public static string MapsPhoto { get; set; }
    public static string TopoPhoto { get; set; }
    public static string SatellitePhoto { get; set; }
    public static string Photo1 { get; set; }
    public static string Photo2 { get; set; }
    public static string Photo3 { get; set; }
    public static string Photo4 { get; set; }
    public static string Photo5 { get; set; }

    public static void Init()
    {
        id = ObjectInfo.id;
        Name = ObjectInfo.Name;
        MapsURL = ObjectInfo.MapsURL;
        Info = ObjectInfo.Info;
        Notes = ObjectInfo.Notes;

    }
}