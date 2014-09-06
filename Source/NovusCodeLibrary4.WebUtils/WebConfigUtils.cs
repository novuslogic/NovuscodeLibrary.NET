using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;

namespace NovusCodeLibrary.WebUtils
{
    public class WebConfigUtils
    {
        
        public static string GetAppSettingskey(string akey)
        {
            string lskey = "";
            
            try
            {
                lskey = GetAppSettings().Settings[akey].Value;
            }
            catch
            {
            } 

            return lskey;
       
        }
        
        
        //public static 
        public static AppSettingsSection GetAppSettings()
        {
            Configuration objConfig =
              WebConfigurationManager.OpenWebConfiguration(System.Web.HttpContext.Current.Request.ApplicationPath);
            AppSettingsSection objAppsettings =
              (AppSettingsSection)objConfig.GetSection("appSettings");
            /*
             if (!objAppsettings.SectionInformation.IsProtected)
             {
                 objAppsettings.SectionInformation.ProtectSection(
                                "RsaProtectedConfigurationProvider");
                 objAppsettings.SectionInformation.ForceSave = true;
                 objConfig.Save(ConfigurationSaveMode.Modified);
             }
             */


            return objAppsettings;
        }



    }
}
