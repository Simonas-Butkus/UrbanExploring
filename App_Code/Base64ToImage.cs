using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Base64ToImage
/// </summary>
public class Base64ToImage
{
    public Base64ToImage()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Image Base64ToImageConvert(string base64String)
    {
        // Convert base 64 string to byte[]
        byte[] imageBytes = Convert.FromBase64String(base64String);
        // Convert byte[] to Image
        using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
        {
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}