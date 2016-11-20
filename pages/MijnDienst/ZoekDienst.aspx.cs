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
using System.IO;




public partial class pages_MijnDienst_ZoekDienst : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Zoeken_Click(object sender, EventArgs e)
    {
        string PathProject = Server.MapPath("~");
        List<string> ADKlijst = new List<string>();
        XmlDocument doc = new XmlDocument();
        XmlElement diensten = doc.CreateElement("diensten");
        API adk = new API();


        string url = @"http://10.145.0.65/dkprod/dkws";
        //string url = @"http://nsorp-stubs.cloudapp.net:8081/ExtensibleStub.svc";

        //string uitvoering = "2016-03-04";
        string dienstNr = "";
        string uitvoering = DateTime.Now.ToString("yyyy-MM-dd");

        string code = StandPlaats.Text;
        string functiecode = FunctieCode.Text;
        int dienstNrVan = Int32.Parse(TextBoxVan.Text);
        int dienstNrTot = Int32.Parse(TextBoxTot.Text);

        //ga naar ADK en vraag dienst op
        for (int k = dienstNrVan; k <= dienstNrTot; k++)
        {
            dienstNr = k.ToString();        

            var result = adk.GetADK(url, dienstNr, uitvoering, code, functiecode);

            if (result.Contains("lookupDienstkaartResponse"))
            {

                try
                {
                    string path = PathProject + "\\logging\\ADK";

                    // als folder neit bestaan maken we hem aan
                 //   bool exists = System.IO.Directory.Exists(path);
                 //   if (!exists)
                 //       System.IO.Directory.CreateDirectory(path);
                    string fileName = path + "\\" + dienstNr + "_" + code + "_" + functiecode + "_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".txt";

                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        sw.WriteLine(result);
                        sw.Close();
                    }
                }
                catch { }
                
                //vertalen ADK response naar lijst
                ADKlijst = GetADKlist(result);
                foreach (string item in ADKlijst)
                {
                    XmlElement dienstinhoud = doc.CreateElement("dienstInhoud");
                    dienstinhoud.InnerXml += item;
                    diensten.AppendChild(dienstinhoud);
                }

            }

            // xml samenvoegen
            doc.AppendChild(diensten);
            doc.Save(PathProject + "\\datasource\\Diensten.xml");
        }

        //verversen van 
        XmlDataSource1.EnableCaching = false;
        XmlDataSource1.DataBind();
        GridView1.DataBind();
    }


    public List<string> GetADKlist(string result)
    {

        List<string> ADKlijst = new List<string>();
        string dienstInhoudLijst = "";



        if (result.Contains("lookupDienstkaartResponse"))
        {
            //XmlElement diensten = doc.CreateElement("diensten");
            //XmlElement dienstinhoud = doc.CreateElement("dienstInhoud");
            //XmlElement dienstnummerOutput = doc.CreateElement("dienstnummer");
            //XmlElement soortOutput = doc.CreateElement("soort");
            //XmlElement stopsOutput = doc.CreateElement("stops");

            XmlDocument respons = new XmlDocument();
            XmlDocument activiteit = new XmlDocument();

            respons.LoadXml(result);
            XmlNodeList nummer = respons.SelectNodes("//*[local-name()='nummer']");
            XmlNodeList planfase = respons.SelectNodes("//*[local-name()='planfase']");
            XmlNodeList rol = respons.SelectNodes("//*[local-name()='functiecode']");
            XmlNodeList start = respons.SelectNodes("//*[local-name()='begin']");
            XmlNodeList stop = respons.SelectNodes("//*[local-name()='eind']");
            XmlNodeList activiteiten = respons.SelectNodes("//*[local-name()='activiteit']");

            //wandel door alle activitetien heen
            for (int j = 0; j < activiteiten.Count; j++)
            {
                string xml = activiteiten[j].InnerXml;
                activiteit.LoadXml("<activiteit>" + xml + @"</activiteit>");
                XmlNodeList treinnummer = null;
                XmlNodeList soort = null;
                XmlNodeList materieelcode = null;
                XmlNodeList stops = null;


                //vul de elementen in de lijst
                dienstInhoudLijst = "<dienstnummer>" + nummer[0].InnerText + "</dienstnummer>" + "\n";
                dienstInhoudLijst = dienstInhoudLijst + "<planfase>" + planfase[0].InnerText + "</planfase>" + "\n";
                dienstInhoudLijst = dienstInhoudLijst + "<rol>" + rol[0].InnerText + "</rol>" + "\n";
                dienstInhoudLijst = dienstInhoudLijst + "<start>" + start[0].InnerText.Substring(11, 5) + "</start>" + "\n";
                dienstInhoudLijst = dienstInhoudLijst + "<stop>" + stop[0].InnerText.Substring(11, 5) + "</stop>" + "\n";

                //probeer treinnummer binnen de activiteit te achterhalen
                try
                {
                    treinnummer = activiteit.SelectNodes("//*[local-name()='nummer']");
                    dienstInhoudLijst = dienstInhoudLijst + "<treinnummer>" + treinnummer[0].InnerText + "</treinnummer>" + "\n";
                }
                catch { };

                //probeer soort binnen de activiteit te achterhalen
                try 
                { 
                    soort = activiteit.SelectNodes("//*[local-name()='soort']");
                    dienstInhoudLijst = dienstInhoudLijst + "<soort>" + soort[0].InnerText + "</soort>" + "\n";
                }
                catch { };

                //probeer materieelnummer binnen de activiteit te achterhalen
                try 
                { 
                    materieelcode = activiteit.SelectNodes("//*[local-name()='materieelcode']");
                    dienstInhoudLijst = dienstInhoudLijst + "<materieelnummers>" + materieelcode[0].InnerText + "</materieelnummers>" + "\n";
                }
                catch { };

                //probeer regelpunten binnen de activiteit te achterhalen
                try 
                { 
                    stops = activiteit.SelectNodes("//*[local-name()='regelpuntcode']");
                    string t = "";
                    for (int i = 0; i < stops.Count; i++)
                    {
                        if (t == "")
                        {
                            t = stops[i].InnerText;
                        }
                        else
                        {
                            if (i % 8 == 0) 
                            {
                                t = t + ", " + stops[i].InnerText;
                            }
                            else
                            {
                                t = t + "," + stops[i].InnerText;
                            }
                        }
                    }
                    dienstInhoudLijst = dienstInhoudLijst + "<stops>" + t + "</stops>" + "\n";
                }
                catch { };

                //schrijf weg in de lijst          
                ADKlijst.Add(dienstInhoudLijst);
                dienstInhoudLijst = "";

                //soortOutput.InnerXml = soort[0].InnerText == null ? soort[0].InnerText : "-";
                //dienstS.soort = dienstS.soort == null ? soort[0].InnerText : "-";
                //dienstS.materieelnummers = dienstS.materieelnummers  == null ? materieelcode[0].InnerText : "-";
 
                //stopsOutput.InnerXml = t;    

                ////dienstS.stops = t;
                ////dienstL.Add(dienstS);
                //dienstinhoud.AppendChild(dienstnummerOutput);
                //dienstinhoud.AppendChild(stopsOutput);


                //diensten.AppendChild(dienstinhoud);

            }

            
        }
        return ADKlijst;
      }


}



