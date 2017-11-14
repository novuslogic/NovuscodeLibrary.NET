using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace NovusCodeLibrary.SimpleTemplate
{
    
    public class TemplateTag
    {

        public string TagName { get; set; }
        public string TagValue { get; set; }
        public string RawTagEx { get; set; }
        
        public TemplateTag(string aTagName, string aTagValue, string aRawTagEx)
        {
            TagName = aTagName;
            TagValue = aTagValue;
            RawTagEx = aRawTagEx;
        }
    
    }
       
    
    public class SimpleTemplateParser
    {
        public bool IgnoreBlankTags { get; set; } 
        
        public Hashtable TemplateTags;
        private string matchpattern = @"(\<%\w+%\>)";

        public string Inputbuffer {get;set;}
        public string Outputbuffer {get;set;}

        public SimpleTemplateParser()
        {
            TemplateTags = new Hashtable();
            Inputbuffer = "";
            Outputbuffer = "";
            IgnoreBlankTags = false;
        }
             
        
        
        public void AddTag(string aTagName, string aRawTagEx)
        {
            TemplateTags.Add(aTagName, new TemplateTag(aTagName, "", aRawTagEx)); 
        }
        
        
        private string LoadFromFileInternal(string aFilename)
        {
         if (!File.Exists(aFilename)) 
                { 
                throw new ArgumentNullException(aFilename, "Filename does not exist");
            }

            StreamReader reader = new StreamReader(aFilename);
            string lsstringbuffer = reader.ReadToEnd();
            reader.Close();

            return lsstringbuffer;
        }
        
        public void LoadFromFile(string aFilename)
        {
            Inputbuffer = LoadFromFileInternal(aFilename);
        }

        public string CleanTagName(string aRawTagEx)
        {
            string fsTagname = aRawTagEx;
            fsTagname = fsTagname.Replace("<%", "");
            fsTagname = fsTagname.Replace("%>", "");
            
            return fsTagname;
        }

        public void UpdateTagValue(string aTagName, string aTagValue )
        {
            if (TemplateTags.Contains(aTagName))
            {

                TemplateTag FTag = (TemplateTag)TemplateTags[aTagName];

                FTag.TagValue = aTagValue;

                ((TemplateTag)TemplateTags[aTagName]).TagValue = aTagValue;
            }
        }
        
        public void ParseInputbuffer()
        {
            MatchCollection tagnames = Regex.Matches(Inputbuffer, matchpattern);
            foreach (Match tagname in tagnames)
            {
                AddTag(CleanTagName(tagname.ToString()), tagname.ToString());
            }
        }


        private string replacetaghandler(Match token)
        {
            string fsTagName = CleanTagName(token.Value);

            if (TemplateTags.Contains(fsTagName))
            {

                if (IgnoreBlankTags == false)
                { return ((TemplateTag)TemplateTags[fsTagName]).TagValue; }
                else
                {

                    if (!string.IsNullOrEmpty(((TemplateTag)TemplateTags[fsTagName]).TagValue))
                    { return ((TemplateTag)TemplateTags[fsTagName]).TagValue; }
                    else { return ((TemplateTag)TemplateTags[fsTagName]).RawTagEx; }
                }
                
            }
            else
            {
                return "";
            }
        }

        
        public void ParseOutputbuffer()
        {
            MatchEvaluator replacecallback = new MatchEvaluator(replacetaghandler);
            Outputbuffer = Regex.Replace(Inputbuffer, matchpattern, replacecallback);
       
        }
                   

    }
}
