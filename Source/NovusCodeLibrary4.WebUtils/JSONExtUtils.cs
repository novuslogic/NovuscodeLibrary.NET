using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script;
using System.Web.Mvc;

namespace NovusCodeLibrary.WebUtils
{
    public class JSONExtUtils
    {

        public static string FormCollectionToJSON(FormCollection collection)
        {
            var list = new Dictionary<string, string>();
            foreach (string key in collection.Keys)
            {
                list.Add(key, collection[key]);
            }
            return new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(list);
        }
        
    }
}
