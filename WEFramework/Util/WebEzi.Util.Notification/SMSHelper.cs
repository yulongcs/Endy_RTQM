using System;
using System.Net;
using System.Text;
using System.Xml;

namespace WebEzi.Util.Notification
{
    public class SMSHelper
    {
        private static SMSHelper _smsHelper;

        public string AccountName { get; set; }
        public string Password { get; set; }
        public string API_ID { get; set; }
        public string Concat { get; set; }
        public string ServiceAddress { get; set; }

        public static SMSHelper GetInstance(string accountName, string password, string api_id, string concat, string serviceAddress)
        {
            if (_smsHelper == null)
            {
                _smsHelper = new SMSHelper();
                _smsHelper.AccountName = accountName;
                _smsHelper.Password = password;
                _smsHelper.API_ID = api_id;
                _smsHelper.Concat = concat;
                _smsHelper.ServiceAddress = serviceAddress;
            }

            return _smsHelper;
        }

        public string SendSMS(string to, string content)
        {
            var smResult = string.Empty;
            try
            {
                // Post data
                var httpclient = new WebClient();
                httpclient.Credentials = CredentialCache.DefaultCredentials;

                httpclient.Headers.Add("Content-Type", "text/xml");

                string postString = @"<?xml version=""1.0"" encoding=""ISO-8859-1""?>
<SOAP-ENV:Envelope SOAP-ENV:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:SOAP-ENC=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:tns=""soap.clickatell.com""> <SOAP-ENV:Body>
<tns:sendmsg xmlns:tns=""soap.clickatell.com"">
<api_id xsi:type=""xsd:int"">{0}</api_id>
<user xsi:type=""xsd:string"">{1}</user>
<password xsi:type=""xsd:string"">{2}</password>
<to xsi:type=""SOAP-ENC:Array"" SOAP-ENC:arrayType=""xsd:string[{3}]"">
{4}
</to>
<text xsi:type=""xsd:string"">{5}</text>
<concat xsi:type=""xsd:int"">{6}</concat>
</tns:sendmsg>

</SOAP-ENV:Body>
</SOAP-ENV:Envelope>
";
                string toTemplate = @"<item xsi:type=""xsd:string"">{0}</item>";

                // Split the SMS_To
                var toList = to.Split(',');
                string toString = string.Empty;
                foreach (var t in toList)
                {
                    toString += string.Format(toTemplate, t);
                }

                byte[] postData = Encoding.UTF8.GetBytes(string.Format(postString, new string[]
                                                                                       {
                                                                                           this.API_ID,
                                                                                           this.AccountName,
                                                                                           this.Password,
                                                                                           toList.Length.ToString(),
                                                                                           toString,
                                                                                           content,
                                                                                           this.Concat
            }));

                byte[] responseData = httpclient.UploadData(this.ServiceAddress, "POST", postData);

                // Parser return xml
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(Encoding.Default.GetString(responseData));

                var node = xmlDocument.SelectSingleNode("/");
                if (node.InnerText.Contains("ID: "))
                {
                    smResult = string.Empty;
                }
                else
                {
                    smResult = node.InnerText;
                }
            }
            catch (Exception ex)
            {
                smResult = ex.Message;
            }

            return smResult;
        }
    }
}
