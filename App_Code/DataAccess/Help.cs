using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Help
/// </summary>
public static class Help
{
    public static string GetRandomString()
    {
        string path = Path.GetRandomFileName();
        path = path.Replace(".", ""); // Remove period.
        return path;
    }
    public static byte[] encryptData(string data)
    {
        System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashedBytes;
        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
        hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
        return hashedBytes;
    }
    public static string md5(string data)
    {
        return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
    }




}