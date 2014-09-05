using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;

namespace NovusCodeLibrary.WebUtils
{
    public class WebUtils
    {

        public static string FullHost(Uri aURI)
        {
            string lsFullhost = "";

            try
            {
                lsFullhost = aURI.Scheme + Uri.SchemeDelimiter + aURI.Host + ":" + aURI.Port;
            }
            catch
            {
            }

            return lsFullhost;
        }



        public static bool RemoteFileExists(string aURL)
        {
            try
            {

                HttpWebRequest request = WebRequest.Create(aURL) as HttpWebRequest;

                request.Method = "HEAD";
                
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
              
                return false;
            }
        }
        


    }
}
