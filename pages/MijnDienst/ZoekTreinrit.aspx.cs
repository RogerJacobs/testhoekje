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
using System.IO;




public partial class pages_MijnDienst_ZoekTreinrit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void Zoeken_Click(object sender, EventArgs e)
    {
        string PathProject = Server.MapPath("~");
        List<string> ARNUlijst = new List<string>();
        
        XmlDocument doc = new XmlDocument();
        XmlElement treinritten = doc.CreateElement("treinritten");
        API arnu = new API();

        //lijt maken
        //List<string> lijst = new List<string>();
        //lijst = GetTreinreeksen();
        
        string url = @"http://10.145.0.65/nsperssi2";
        //string url = @"http://nsorp-stubs.orp-o.p.azurewebsites.net/extensiblestub";

        string treinritNr = "";
        int treinrittenVan = 0;
        int treinrittenTot = 0;
        if (TextBox1.Text == "")
        {
            var Selectie = DropDownList1.Text.Split('-');
            treinrittenVan = Int32.Parse(Selectie[0]);
            treinrittenTot = Int32.Parse(Selectie[1]);
        }
        else
        {
            var Selectie = Int32.Parse(TextBox1.Text);
            treinrittenVan = Selectie;
            treinrittenTot = Selectie;
        }

        //ga naar ANU en vrtaag alle trein ritten in reeks op
        for (int k = treinrittenVan; k <= treinrittenTot; k++)
        {
            treinritNr = k.ToString();

            var result = arnu.GetARNU(url, treinritNr);

            if (result.Contains("GetServiceInfoOut"))
            {

                try
                {
                    string path = PathProject + "\\logging\\ARNU";
                    string fileName = path + "\\" + treinritNr + "_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".txt";
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        sw.WriteLine(result);
                        sw.Close();
                    }
                }
                catch { }
                
                //vertalen ADK response naar lijst
                ARNUlijst = GetARNUlist(result);
                foreach (string item in ARNUlijst)
                {
                    XmlElement treinritinhoud = doc.CreateElement("treinritInhoud");
                    treinritinhoud.InnerXml += item;
                    treinritten.AppendChild(treinritinhoud);
                }

            }

            // xml samenvoegen
            doc.AppendChild(treinritten);
            doc.Save(PathProject + "\\datasource\\Treinritten.xml");
        }

        //verversen van 
        XmlDataSource1.EnableCaching = false;
        XmlDataSource1.DataBind();
        GridView1.DataBind();
    }


    public List<string> GetARNUlist(string result)
    {

        List<string> ARNUlijst = new List<string>();
        string treinritInhoudLijst = "";
        string s = "";
        string stoptype = "";

        if (result.Contains("GetServiceInfoOut"))
        {
            XmlDocument respons = new XmlDocument();
            XmlDocument stop = new XmlDocument();

            respons.LoadXml(result);
            XmlNodeList treinnummer = respons.SelectNodes("//*[local-name()='ServiceCode']");
            XmlNodeList stops = respons.SelectNodes("//*[local-name()='Stop']");

            //vul de elementen in de lijst
            treinritInhoudLijst = "<treinnummer>" + treinnummer[0].InnerText + "</treinnummer>" + "\n";

            //wandel door alle stops heen
            for (int j = 0; j < stops.Count; j++)
            {
                string xml = stops[j].InnerXml;
                stoptype = "";
                try { stoptype = stops[j].Attributes["StopType"].Value; }
                catch { }

                switch (stoptype)
                {
                    case "Cancelled-Stop":
                        stoptype = "C";
                        break;
                    case "Split-Stop":
                        stoptype = "S";
                        break;
                    case "Diverted-Stop":
                        stoptype = "D";
                        break;
                    case "":
                        stoptype = "0";
                        break;
                }

                stop.LoadXml("<Stop>" + xml + @"</Stop>");
                XmlNodeList stopcode = null;

                //probeer treincode binnen de stop te achterhalen
                try
                {
                    stopcode = stop.SelectNodes("//*[local-name()='StopCode']");
                    if (s == "")
                    {
                        s = stopcode[0].InnerText + "-" + stoptype;
                    }
                    else
                    {
                        s = s + " ," + stopcode[0].InnerText + "-" + stoptype;
                    }
                }
                catch { };

            }
            treinritInhoudLijst = treinritInhoudLijst + "<stops>" + s + "</stops>" + "\n";
            ARNUlijst.Add(treinritInhoudLijst);
            treinritInhoudLijst = "";
            
        }
        return ARNUlijst;
      }

    public List<string> GetTreinreeksen()
    {

        List<string> treinreeksen = new List<string>();
        XmlDocument lijst = new XmlDocument();
        string PathProject = Server.MapPath("~");
        string filename = PathProject + "\\App_Data\\arnu\\treinreeksen.xml";
        string Klatblok = "";
        lijst.Load(filename);
        XmlNodeList VanTreinNummer = lijst.SelectNodes("//*[local-name()='VanTreinNummer']");
        XmlNodeList TotEnMetTreinNummer = lijst.SelectNodes("//*[local-name()='TotEnMetTreinNummer']");
        int totaal = 0;
        int v = 0;
        int v_old = Int32.Parse(VanTreinNummer[0].InnerText);
        int t = 0;
        int t_old = Int32.Parse(TotEnMetTreinNummer[0].InnerText);
        for (int j = 1; j < VanTreinNummer.Count; j++)
        {
            v = Int32.Parse(VanTreinNummer[j].InnerText);
            t = Int32.Parse(TotEnMetTreinNummer[j].InnerText);
            if(v == t_old + 1 )
            {
                t_old = t;
            }
            else
            {
               totaal = t_old - v_old + 1;
               treinreeksen.Add(v_old.ToString() + "-" + t_old.ToString());
               Klatblok = Klatblok + @"<asp:ListItem Value=""" +  v_old.ToString() + "-"+ t_old.ToString() + @""">Treinreeks: " + v_old.ToString() + " (" + totaal.ToString() + @")</asp:ListItem>" + "\n";
               v_old = v;
               t_old = t;
            }
        }
        return treinreeksen;
    }
 }



