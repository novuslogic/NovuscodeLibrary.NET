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
        /*
        public static string GetUserAddress(HttpRequest request)
        {
            string result = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrWhiteSpace(result))
            {
                result = request.UserHostAddress;

            }
            return result;
        }
        */

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

        public static bool UrlsMatch(string aURI1, string aURI2, bool aJustPath = false)
        {
            if (aJustPath)
            {
                if (!aURI1.EndsWith("/"))
                {

                    aURI1 += "/";

                }
                if (!aURI2.EndsWith("/"))
                {

                    aURI2  += "/";

                }

            }


            Uri uri1 = new Uri(aURI1.ToLower());
            Uri uri2 = new Uri(aURI2.ToLower());

            
            return (uri1==uri2);
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
        
        /*
        public static string GetFullDomain(HttpRequest aRequest)
        {

            var httpRequestBase = new HttpRequestWrapper(aRequest);
        
            var uri = httpRequestBase?.UrlReferrer;
            if (uri == null)
                return string.Empty;
            return uri.Scheme + Uri.SchemeDelimiter + uri.Authority;
        
        }
        */


    }
}
