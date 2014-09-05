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
                
        public TemplateTag(string aTagName, string aTagValue)
        {
            TagName = aTagName;
            TagValue = aTagValue;
        }
    
    }
       
    
    public class SimpleTemplateParser
    {

        public Hashtable TemplateTags;
        private string matchpattern = @"(\<%\w+%\>)";

        public string Inputbuffer {get;set;}
        public string Outputbuffer {get;set;}

        public SimpleTemplateParser()
        {
            TemplateTags = new Hashtable();
            Inputbuffer = "";
            Outputbuffer = "";
        }
              
        
        public void AddTag(string aTagName)
        {
            TemplateTags.Add(aTagName, new TemplateTag(aTagName, string.Empty)); 
        }
        
        
        private string LoadFilenameInternal(string aFilename)
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
        
        public void LoadFilename(string aFilename)
        {
            Inputbuffer = LoadFilenameInternal(aFilename);
        }

        public void ParseInputbuffer()
        {
            MatchCollection tagnames = Regex.Matches(Inputbuffer, matchpattern);
            foreach (Match tagname in tagnames) AddTag(tagname.ToString());
        }


        private string replacetaghandler(Match token)
        {
            if (TemplateTags.Contains(token.Value))
                return ((TemplateTag)TemplateTags[token.Value]).TagValue;
            else
                return string.Empty;
        }

        
        public void ParseOutputbuffer()
        {
            MatchEvaluator replacecallback = new MatchEvaluator(replacetaghandler);
            Outputbuffer = Regex.Replace(Inputbuffer, matchpattern, replacecallback);
       
        }
                   

    }
}
