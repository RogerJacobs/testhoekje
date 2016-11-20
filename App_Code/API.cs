using System;
using System.IO;
using System.Net;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Specialized;
using Testhoekje.App_Code.API;
using System.Collections.Generic;

namespace Testhoekje.App_Code.API
{


    public class API
    {

        public string SendRestBasicAuth(string url, string userName, string passWord)
        {

            WebClient client = new WebClient();

            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(userName + ":" + passWord));
            client.Headers[HttpRequestHeader.Authorization] = "Basic " + credentials;
            var result = client.UploadString(url, "");
            return result.ToString();

        }

        public string SendREST(string url)
        {

            using( WebClient client = new WebClient())
            {
                try
                {
                    var result = client.DownloadString(url);
                    return result.ToString();
                }
                catch(Exception e)
                {
                    return e.Message;
                }
            }
        }



        public string GetIAM(string url)
        {

            using (WebClient client = new WebClient())
            {
                try
                {
                    var result = client.DownloadString(url);
                    return result.ToString();
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
        }


        public string GetADK(string url, string dienstNr, string uitvoering, string code, string functiecode)
        {
            using (WebClient client = new WebClient())
            {

                //client.Headers.Add("Accept-Encoding", "gzip,deflate");
                client.Headers.Add("Content-Type", "text/xml;charset=UTF-8");
                client.Headers.Add("SOAPAction", "");
                //client.Headers.Add("Content-Length", "591");
                //client.Headers.Add("Host", "nsorp-stubs.cloudapp.net:8081");
                //client.Headers.Add("Connection", "Keep-Alive");
                //client.Headers.Add("User-Agent", "Apache-HttpClient/4.3.1 (java 1.5");

                string payload = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:dien=""http://www.ns.nl/dienstkaart/ws/dienstkaart"" xmlns:dien1=""http://www.ns.nl/dienstkaart/model/dienst"" xmlns:stan=""http://www.ns.nl/dienstkaart/model/standplaats""> 
                        <soapenv:Header/>
                           <soapenv:Body>
                              <dien:lookupDienstkaartRequest>
                                 <dien1:nummer>" + dienstNr + @"</dien1:nummer>
                                 <dien1:uitvoering>" + uitvoering + @"</dien1:uitvoering>
                                 <stan:code>" + code + @"</stan:code>
                                 <dien1:functiecode>" + functiecode + @"</dien1:functiecode>
                              </dien:lookupDienstkaartRequest>
                           </soapenv:Body>
                        </soapenv:Envelope>";


                //    var payload = @"<?xml version=""1.0"" encoding=""utf-8""?><soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><soap:Body><HelloWorld xmlns=""http://tempuri.org/""><foo><Id>1</Id><Name>Bar</Name></foo></HelloWorld></soap:Body></soap:Envelope>";
                var data = Encoding.UTF8.GetBytes(payload);

                try
                {
                    var result = client.UploadData(url, data);
                    return Encoding.UTF8.GetString(result);
                }
                catch (Exception e)
                {
                    var d = e.Data;
                    return e.Message;
                }
            }
        }


        public string GetARNU(string url, string treinnummer)
        {

            using (WebClient client = new WebClient())
            {

                //client.Headers.Add("Accept-Encoding", "gzip,deflate");
                client.Headers.Add("Content-Type", "text/xml;charset=UTF-8");
                client.Headers.Add("SOAPAction", "");
                //client.Headers.Add("Content-Length", "591");
                //client.Headers.Add("Host", "nsorp-stubs.cloudapp.net:8081");
                //client.Headers.Add("Connection", "Keep-Alive");
                //client.Headers.Add("User-Agent", "Apache-HttpClient/4.3.1 (java 1.5");
                string vandaag = DateTime.Now.ToString("yyyy-MM-dd");


               string payload = @"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:SOAP-ENC=""http://schemas.xmlsoap.org/soap/encoding/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                  <SOAP-ENV:Body>
                   <m:GetSeviceInfoIn xmlns:m=""http://www.tt-solutions.nl/schemas/NS/RTI/1.1/"">
                    <ServiceInput SearchType=""REALTIME"" SearchOccurrenceType=""SINGLE"">
                      <CompanyCode>ns</CompanyCode>
                      <ServiceCode>" + treinnummer + @"</ServiceCode>
                      <DateTime MatchDate=""true"" SearchDateType=""CALENDAR"">" + vandaag + @"</DateTime>
                      <CallerId>NS_TOOLS</CallerId>
                     </ServiceInput>
                   </m:GetSeviceInfoIn>
                  </SOAP-ENV:Body>
                </SOAP-ENV:Envelope>";

                var data = Encoding.UTF8.GetBytes(payload);
                
                try
                {
                    var result = client.UploadData(url, data);
                    return Encoding.UTF8.GetString(result);
                }
                catch (Exception e)
                {
                    var d = e.Data;
                    return e.Message;
                }
            }
        }
    }
}
