using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Testhoekje.App_Code.API;
using Testhoekje.App_Code.JSON;
using System.Xml;
using System.Xml.Linq;

public partial class Default2 : System.Web.UI.Page
{

    public string hasErrorHTML = "";

    public class Versie
    {
        public string _Major { get; set; }
        public string _Minor { get; set; }
        public string _Build { get; set; }
        public string _Revision { get; set; }
       
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        Response.Write(hasErrorHTML);
    }


    protected void GetVersion_Click(object sender, EventArgs e)
    {
        UpdateDataSource("Versie.xml");
        XmlDataSource1.EnableCaching = false;
        XmlDataSource1.DataBind();
        GridView1.DataBind();
    }
    protected void Clean_Click(object sender, EventArgs e)
    {
        CleanDataSource("Versie.xml");
        XmlDataSource1.EnableCaching = false;
        XmlDataSource1.DataBind();
        GridView1.DataBind();
    }

    public string GetVersie(string url)
    {

        var api = new API();
        var versie = api.SendREST(url);
        try
        {
            var p = JsonHelper.JsonDeserialize<Versie>(versie);
            versie = p._Major + "." + p._Minor + "." + p._Build + "." + p._Revision;
        }
        catch { }
        return versie;
    }


    public string CleanDataSource(string xmlFileName)
    {
        string PathProject = Server.MapPath("~");
        string hasError = "";
   
        using (XmlWriter writer = XmlWriter.Create(PathProject + "\\datasource\\" + xmlFileName))
        {
            try
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("versies");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
            catch (Exception e)
            {
                hasError = e.Message;
            }
        }
        return hasError;
    }


    public string UpdateDataSource(string xmlFileName)
    {
        string PathProject = Server.MapPath("~");
        string hasError = "";

        string appapiURL = "";
        string configuratieURL = "";
        string internalURL = "";
        string loggingsportaalURL = "";
        string berichtenbackendURL = "";
        string dienstbackendURL = "";
        string versionRouterURL = "";
        string treinritbackendURL = "";
       // string url = TextBox1.Text;

        string omgeving = "";
        string release = Release.Text;


        switch (Omgeving.Text)
        {

            case "O":
                appapiURL = @"https://nsorp-o.orp-o.p.azurewebsites.net/" + release + @"/api/version";
                versionRouterURL = @"https://nsorp-o.orp-o.p.azurewebsites.net/api/version";
                configuratieURL = @"https://nsorp-config-o.orp-o.p.azurewebsites.net/api/version";
                internalURL = @"http://nsorp-internal-o.cloud.ns.nl/api/version";
                loggingsportaalURL = @"https://orp-ops-o.mobile-apps.ns.nl/api/version";
                berichtenbackendURL = @"https://nsorp-berichten-o.orp-o.p.azurewebsites.net/api/version";
                dienstbackendURL = @"https://nsorp-dienst-o.orp-o.p.azurewebsites.net/api/version";
                treinritbackendURL = @"https://nsorp-treinrit-o.orp-o.p.azurewebsites.net/api/version";
                omgeving = "Ontwikkel";
            break;

            case "T":
                 appapiURL = @"https://nsorp-t.orp-o.p.azurewebsites.net/" + release + @"/api/version";
                 versionRouterURL = @"https://nsorp-t.orp-o.p.azurewebsites.net/api/version";
                 configuratieURL = @"https://nsorp-config-o.orp-o.p.azurewebsites.net/api/version";
                 internalURL = @"http://10.40.18.20/api/version";
                 loggingsportaalURL = @"https://orp-ops-t.mobile-apps.ns.nl/api/version";
                 berichtenbackendURL = @"https://nsorp-berichten-t.orp-o.p.azurewebsites.net/api/version";
                 dienstbackendURL = @"https://nsorp-dienst-t.orp-o.p.azurewebsites.net/api/version";
                 treinritbackendURL = @"https://nsorp-treinrit-t.orp-o.p.azurewebsites.net/api/version";
                 omgeving = "Test";
            break;

            case "A":
            appapiURL = @"https://orp-acceptatie.mobile-apps.ns.nl/" + release + @"/api/version";
                 versionRouterURL = @"https://orp-acceptatie.mobile-apps.ns.nl/api/version";
                 configuratieURL = @"https://orp-config-a.mobile-apps.ns.nl/api/version";
                 internalURL = @"http://nsorp-internal-a.cloud.ns.nl/api/version";
                 loggingsportaalURL = @"https://orp-ops-a.mobile-apps.ns.nl/api/version";
                 berichtenbackendURL = @"https://nsorp-berichten-a.orp-p.p.azurewebsites.net/api/version";
                 dienstbackendURL = @"https://nsorp-dienst-a.orp-p.p.azurewebsites.net/api/version";
                 treinritbackendURL = @"https://nsorp-treinrit-a.orp-p.p.azurewebsites.net/api/version";
                 omgeving = "Acceptatie";
            break;

            case "P":
            appapiURL = @"https://orp-productie.mobile-apps.ns.nl/" + release + @"/api/version";
            versionRouterURL = @"https://orp-productie.mobile-apps.ns.nl/api/version";
            configuratieURL = @"https://orp-config-p.mobile-apps.ns.nl/api/version";
            internalURL = @"http://nsorp-internal-p.cloud.ns.nl/api/version";
            loggingsportaalURL = @"https://orp-ops-p.mobile-apps.ns.nl/api/version";
            berichtenbackendURL = @"https://nsorp-berichten-p.orp-p.p.azurewebsites.net/api/version";
            dienstbackendURL = @"https://nsorp-dienst-p.orp-p.p.azurewebsites.net/api/version";
            treinritbackendURL = @"https://nsorp-treinrit-p.orp-p.p.azurewebsites.net/api/version";
            omgeving = "Productie";
            break;

            //case "A1":
            //     appapiURL = @"https://nsorp-a1.orp-o.p.azurewebsites.net/" + release + @"/api/version";
            //     versionRouterURL = @"https://nsorp-a1.orp-o.p.azurewebsites.net/api/version";
            //     configuratieURL = @"https://nsorp-config-a1.orp-o.p.azurewebsites.net/api/version";
            //     internalURL = @"https://nsorp-internal-a.cloud.ns.nl/api/version";
            //     loggingsportaalURL = @"https://orp-ops-a.mobile-apps.ns.nl/api/version";
            //     berichtenbackendURL = @"https://nsorp-berichten-a.orp-o.p.azurewebsites.net/api/version";
            //     omgeving = "Acceptatie_1";
            //break;

            //case "A2":
            //    appapiURL = @"https://orp-acceptatie2.mobile-apps.ns.nl/api/version";
            //    versionRouterURL = @"https://nsorp-t.orp-o.p.azurewebsites.net/api/version";
            //    configuratieURL = @"https://orp-config-a.mobile-apps.ns.nl/api/version";
            //    internalURL = @"https://nsorp-internal-a.cloud.ns.nl/api/versio";
            //    loggingsportaalURL = @"https://orp-ops-a.mobile-apps.ns.nl/api/version";
            //    berichtenbackendURL = @"https://nsorp-berichten-a.orp-o.p.azurewebsites.net/api/version";
            //break;

            //case "P1":
            //appapiURL = @"https://orp-productie1.mobile-apps.ns.nl/api/version";
            //versionRouterURL = @"https://nsorp-t.orp-o.p.azurewebsites.net/api/version";
            //configuratieURL = @"https://orp-config-p.mobile-apps.ns.nl/api/version";
            //internalURL = @"https://nsorp-internal-a.cloud.ns.nl/api/version";
            //loggingsportaalURL = @"https://orp-ops-a.mobile-apps.ns.nl/api/version";
            //berichtenbackendURL = @"https://nsorp-berichten-a.orp-o.p.azurewebsites.net/api/version";
            //break;

            //case "P2":
            //appapiURL = @"https://orp-productie2.mobile-apps.ns.nl/api/version";
            //versionRouterURL = @"https://nsorp-t.orp-o.p.azurewebsites.net/api/version";
            //configuratieURL = @"https://orp-config-p.mobile-apps.ns.nl/api/version";
            //internalURL = @"https://nsorp-internal-a.cloud.ns.nl/api/versio";
            //loggingsportaalURL = @"https://orp-ops-a.mobile-apps.ns.nl/api/version";
            //berichtenbackendURL = @"https://nsorp-berichten-a.orp-o.p.azurewebsites.net/api/version";
            //break;
        }

        try
        {
            XDocument doc = XDocument.Load(PathProject + "\\datasource\\" + xmlFileName);
            XElement versies = doc.Element("versies");
            versies.AddFirst(new XElement("versie",
                new XElement("omgeving", omgeving),
                new XElement("release", release),
                new XElement("versieRouter", GetVersie(versionRouterURL)),
                new XElement("appapi", GetVersie(appapiURL)),
                new XElement("configuratie", GetVersie(configuratieURL)),
                new XElement("internal", GetVersie(internalURL)),
                new XElement("loggingsportaal", GetVersie(loggingsportaalURL)),
                new XElement("berichtenbackend", GetVersie(berichtenbackendURL)),
                new XElement("dienstbackend", GetVersie(dienstbackendURL)),
                new XElement("treinritbackend", GetVersie(treinritbackendURL)),
                new XElement("laatsteupdate", DateTime.Now.AddHours(2).ToString("yyyy-MM-dd  HH:mm:ss"))));
            doc.Save(PathProject + "\\datasource\\" + xmlFileName);
        }
            catch (Exception e) 
        {
            hasError = e.Message;
        }

        return hasError;
    }

 
}