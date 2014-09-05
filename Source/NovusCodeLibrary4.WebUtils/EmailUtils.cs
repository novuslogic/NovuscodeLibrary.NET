using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net.Mime;

namespace NovusCodeLibrary.WebUtils
{
    public class EmailUtils
    {
        
        public static bool SendSMTPEmail(string aSMTPHost, 
                                         int aSMTPPort,
                                         bool aEnableSSL, 
                                         int aTimeout,
                                         string aSMTPUsername,
                                         string aSMTPPassword,
                                         string aFromEmail,
                                         string aToEmails,
                                         string aEmailSubject,
                                         string aEmailBody)
        {
        SmtpClient client = new SmtpClient();
        client.Port = aSMTPPort;
        client.Host = aSMTPHost;
        client.EnableSsl = aEnableSSL;

        if (aTimeout == 0) { aTimeout = 10000; }

        client.Timeout = aTimeout;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential(aSMTPUsername, aSMTPPassword);

        MailMessage mm = new MailMessage(aFromEmail, aToEmails, aEmailSubject, aEmailBody);
        mm.BodyEncoding = UTF8Encoding.UTF8;
        mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

        client.Send(mm);

                    
        return false;
        }
               
        
        public static bool IsEmailformat(string aEmail)
        {
            if (aEmail == null || aEmail.Length == 0)
            {
                return false;
                
            }

            const string expression = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            Regex regex = new Regex(expression);
            return regex.IsMatch(aEmail);
        }


        public static bool ValidEmailDomain(string aEmail)
        {
            bool ReturnVal = false;
            string[] Host = aEmail.Split('@');
            string HostName = Host[1];

            try
            {
                IPHostEntry IPHost = Dns.GetHostEntry(HostName);
                IPEndPoint EndPoint = new IPEndPoint(IPHost.AddressList[0], 25);
                Socket s = new Socket(EndPoint.AddressFamily,
                            SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    s.Connect(EndPoint);
                    s.Disconnect(false);
                    ReturnVal = true;
                }
                catch (Exception)
                {
                    ReturnVal = false;
                }
                finally
                {
                    if (s.Connected)
                        s.Disconnect(false);
                }
            }
            catch (Exception)
            {
                ReturnVal = false;
            }

            return ReturnVal;
        }




    }
}
