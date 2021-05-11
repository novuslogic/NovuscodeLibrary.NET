11/05/2021

* Added public static Boolean IsAlphaNumeric(string aString)

30/04/2021

* Fixed Nughet package for NovusCodeLibrary.Elmah


17/07/2020

* Fix reference issue with NovusCodeLibrary4.WebUtils with MVC4


22/08/2019

* public static Boolean IsNumeric(string aString) now using Regex.IsMatch fixes Int32 size issue
* public static bool UrlsMatch(string aURI1, string aURI2, bool aJustPath = false) new option for JustPath in URL


30/04/2019

NovusCodeLibrary.WebUtils

* New method  public static string GetFullDomain(HttpRequest aRequest)

12/12/2018

NovusCodeLibrary4.Elmah

* Fixed namespace from NovusCodeLibrary4.Elmah to NovusCodeLibrary.Elmah


NovusCodeLibrary4.SimpleTemplate

* Rename property IgnoreBlankTags to IgnoreBlankValue
* public void ParseInputbuffer() clears TemplateTags when called
* Check key exists public void AddTag(string aTagName, string aRawTagEx)

05/10/2018

NovusCodeLibrary4.Utils

new method string BytesToString(byte[] bytes) in class StringUtils

06/08/2018

NovusCodeLibrary4.Utils

* New method  byte[] GetBinaryFilename(string aFilename) in class SystemUtils

02/08/2018

NovusCodeLibrary4.Utils

* New method CleanString(string aString) in class StringUtils


19/06/2018

NovusCodeLibrary4.Utils

* New method bool IsDateEmpty(DateTime aDate) in class DateTimeUtils 


14/11/2017

* Start of the Changelog

NovusCodeLibrary4.SimpleTemplate

* Updated TagName without <%xxx%> save in HashTable for key
* New method public string CleanTagName(string aRawTagEx)
* New method public void UpdateTagValue(string aTagName, string aTagValue )
* New property IgnoreBlankTags - If TagValue is blank re-insert <%TagName%>


                                                                                                                                                                                                                                                           