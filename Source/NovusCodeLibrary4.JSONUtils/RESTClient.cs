using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;


namespace NovusCodeLibrary.WebUtils
{
    public class RESTClient
    {

        public dynamic RequestRESTCall(string uri, string method, dynamic parms)
        {
            dynamic result;

            var req = HttpWebRequest.Create(uri);
            req.Method = method;
            req.ContentType = "application/json";
            byte[] bytes = UTF8Encoding.UTF8.GetBytes(parms.ToString());
            req.ContentLength = bytes.Length;

            using (var stream = req.GetRequestStream())
            {
                stream.Write(bytes, 0, bytes.Length);
            }


            using (var resp = req.GetResponse())
            {
                var results = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                result = JObject.Parse(results);
            }

            return result;
        }




    }
}
