using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;


namespace NovusCodeLibrary.JSONUtils
{
    public class RESTClientUtils
    {

    public string RequestRESTCall(string uri, string method, string jsonParams)
    {
        string result;

        var req = (HttpWebRequest)WebRequest.Create(uri);
        req.Method = method;
        req.ContentType = "application/json";

        byte[] bytes = Encoding.UTF8.GetBytes(jsonParams);
        req.ContentLength = bytes.Length;

        using (var stream = req.GetRequestStream())
        {
            stream.Write(bytes, 0, bytes.Length);
        }

        using (var resp = (HttpWebResponse)req.GetResponse())
        {
            using (var reader = new StreamReader(resp.GetResponseStream()))
            {
                result = reader.ReadToEnd();
            }
        }

        return result;
    }
    }
}
