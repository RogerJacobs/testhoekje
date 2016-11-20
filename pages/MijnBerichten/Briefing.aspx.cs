using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Xml;
using System.Web.UI.WebControls;
using Testhoekje.App_Code.FTP;
using System.Text.RegularExpressions;
using Testhoekje.App_Code.Briefing;
using System.Web.ModelBinding;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InlezenBreefing.Attributes.Add("onClientClick", " this.disabled = true; " + ClientScript.GetPostBackEventReference(InlezenBreefing, null) + ";");

    }



    protected void InlezenBreefing_Click(object sender, EventArgs e)
    {
           
        InlezenBreefing.Enabled = false;
       

        
        var ftp = new FTP();
        var BriefingProperties = new Briefing();
        bool hasError = true;
        Dictionary<string, string> Properties = new Dictionary<string, string>();
        string[] FileSplit = null;
        //disable button om te voorkomen dat er 2x wordt gedrukt



        //bepaal omgeving
        string folderDes = "";
        switch (Omgeving.SelectedValue)
        {
            case "StubFTP-O":
                ftp.ConnectionSetup("ftp://srv-tomcat.cloudapp.net//", "SpoorPlazaUser", "4aeHWbjECxgzRZcuV8sk");
                folderDes = "Briefing//Ontwikkel//";
                break;
            case "StubFTP-T":
                ftp.ConnectionSetup("ftp://srv-tomcat.cloudapp.net//", "SpoorPlazaUser", "4aeHWbjECxgzRZcuV8sk");
                folderDes = "Briefing//Test//";
                break;
            case "StubFTP-A":
                ftp.ConnectionSetup("ftp://srv-tomcat.cloudapp.net//", "SpoorPlazaUser", "4aeHWbjECxgzRZcuV8sk");
                folderDes = "Briefing//Acceptatie//";
                break;
            case "StubFTP-A1":
                ftp.ConnectionSetup("ftp://srv-tomcat.cloudapp.net//", "SpoorPlazaUser", "4aeHWbjECxgzRZcuV8sk");
                folderDes = "Briefing//Acceptatie1//";
                break;
            case "StubFTP-A2":
                ftp.ConnectionSetup("ftp://srv-tomcat.cloudapp.net//", "SpoorPlazaUser", "4aeHWbjECxgzRZcuV8sk");
                folderDes = "Briefing//Acceptatie2//";
                break;
            case "StubFTP-Demo":
                ftp.ConnectionSetup("ftp://srv-tomcat.cloudapp.net//", "SpoorPlazaUser", "4aeHWbjECxgzRZcuV8sk");
                folderDes = "Briefing//Demo//";
                break;
            case "NS-FTP-Acceptatie":
                ftp.ConnectionSetup("ftp://ftp-pso.ns.nl//", "ftp-pso-orp-a", "okvMbdofO9N9hCeJbkW9T3E0");
                folderDes = "Briefing//Demo//";
                break;
            case "NS-FTP-Productie":
                ftp.ConnectionSetup("ftp://ftp-pso.ns.nl//", "ftp-pso-orp-p", "okvMbdofO9N9hCeJbkW9T3E0");
                folderDes = "";
                break;
        }

        
        //maak een datasource XML bestand aan
        string PathProject = Server.MapPath("~");
        using(XmlWriter writer = XmlWriter.Create(PathProject + "\\datasource\\Berichten.xml"))
        { 
            try
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("berichten");

                //wandel door de drie folders van briefing
                string[] Folders = { "handboekupdates", "infobulletin", "managementberichten" };
                foreach (string FolderNaam in Folders)
                {
                    //get alle bestands namen in de folder
                    var FileList = ftp.GetFolderList(folderDes + FolderNaam, out hasError); 
                    if (hasError)
                    {
                   
                        writer.WriteStartElement("bericht");
                          writer.WriteStartElement("titel");
                           writer.WriteString("Error bij ophalen lijst: " + FileList[0]);
                          writer.WriteEndElement();
                        writer.WriteEndElement();
                        //afronden elementen en sluiten bestand
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();

                        //update Gridview
                        XmlDataSource1.EnableCaching = false;
                        XmlDataSource1.DataBind();
                        GridView1.DataBind();
                        //GridView1.CollapseAll();

                        InlezenBreefing.Enabled = true;

                    }
                    else
                    {
                        //wandel door de ijst met bestandsnamen
                        string FileContent = "";
                        foreach (string File in FileList)
                        {

                            if (File.ToLower().Contains(".htm") || File.ToLower().Contains(".html"))
                            {
                                FileContent = ftp.Download_file(folderDes + File, out hasError);
                            

                                if (hasError)
                                {
                                    writer.WriteStartElement("bericht");
                                      writer.WriteStartElement("titel");
                                       writer.WriteString("Error bij ophalen file [" + File + "]" + FileContent);
                                      writer.WriteEndElement();
                                    writer.WriteEndElement();

                                    //afronden elementen en sluiten bestand
                                    writer.WriteEndElement();
                                    writer.WriteEndDocument();
                                    writer.Close();

                                    //update Gridview
                                    XmlDataSource1.EnableCaching = false;
                                    XmlDataSource1.DataBind();
                                    GridView1.DataBind();
                                    //GridView1.CollapseAll();

                                    InlezenBreefing.Enabled = true;
                                }
                                else
                                {
                                    //properties in lezen
                                    Properties = BriefingProperties.GetBerichtProperties(FileContent);
                                    FileSplit = Regex.Split(File, "/");
                                }
           

                                writer.WriteStartElement("bericht");
                                writer.WriteStartElement("id");
                                writer.WriteString(Properties["id"]);
                                writer.WriteEndElement();

                                writer.WriteStartElement("categorie");
                                writer.WriteString(FileSplit[0]);
                                writer.WriteEndElement();

                                writer.WriteStartElement("titel");
                                writer.WriteString(Properties["titel"]);
                                writer.WriteEndElement();

                                writer.WriteStartElement("rollen");
                                writer.WriteString(Properties["rollen"]);
                                writer.WriteEndElement();

                                writer.WriteStartElement("Machinist-NSR");
                                writer.WriteString(Properties["Machinist-NSR"]);
                                writer.WriteEndElement();

                                writer.WriteStartElement("Hoofdconducteur-NSR");
                                writer.WriteString(Properties["Hoofdconducteur-NSR"]);
                                writer.WriteEndElement();

                                writer.WriteStartElement("Servicemedewerker");
                                writer.WriteString(Properties["Servicemedewerker"]);
                                writer.WriteEndElement();

                                writer.WriteStartElement("Procesleider-Perron");
                                writer.WriteString(Properties["Procesleider-Perron"]);
                                writer.WriteEndElement();

                                writer.WriteStartElement("Veiligheid-en-service");
                                writer.WriteString(Properties["Veiligheid-en-service"]);
                                writer.WriteEndElement();

                                writer.WriteStartElement("Trainmanager-ICBrussel");
                                writer.WriteString(Properties["Trainmanager-ICBrussel"]);
                                writer.WriteEndElement();

                                writer.WriteStartElement("Trainmanager-ICE");
                                writer.WriteString(Properties["Trainmanager-ICE"]);
                                writer.WriteEndElement();

                                writer.WriteStartElement("Trainmanager-Thalys");
                                writer.WriteString(Properties["Trainmanager-Thalys"]);
                                writer.WriteEndElement();

                                writer.WriteStartElement("Machinist-ICE");
                                writer.WriteString(Properties["Machinist-ICE"]);
                                writer.WriteEndElement();

                                writer.WriteStartElement("Machinist-ICBrussel");
                                writer.WriteString(Properties["Machinist-ICBrussel"]);
                                writer.WriteEndElement();

                                writer.WriteStartElement("Machinist-Thalys");
                                writer.WriteString(Properties["Machinist-Thalys"]);
                                writer.WriteEndElement();


                                writer.WriteStartElement("geldigheidVan");
                                writer.WriteString(Properties["geldigheidVan"]);
                                writer.WriteEndElement();

                                writer.WriteStartElement("geldigheidTot");
                                writer.WriteString(Properties["geldigheidTot"]);
                                writer.WriteEndElement();
                                writer.WriteEndElement();
                            }
                        }
                    }
     
                }
                //afronden elementen en sluiten bestand
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        
            catch { }
            

            //update Gridview
            XmlDataSource1.EnableCaching = false;
            XmlDataSource1.DataBind();
            GridView1.DataBind();
            //GridView1.CollapseAll();

            InlezenBreefing.Enabled = true;
        }
    }



    protected void Refresh_Click(object sender, EventArgs e)
    {
        //XmlDataSource1.XPath = "//*[rollen='Hc,def']";

        string q = "";
        int i = 0;

        String strItem;
        int[] Items = ListBox1.GetSelectedIndices();
        foreach (int item in Items)
        {
            // strItem = selecteditem as String;
            i = i + 1;
            if (i != 1)
            {
                q = q + " | ";
            }

            switch (item)
            {
                case 0:
                    q = q + "//*[Machinist-NSR='true']";
                    break;
                case 1:
                    q = q + "//*[Hoofdconducteur-NSR='true']";
                    break;
                case 2:
                    q = q + "//*[Servicemedewerker='true']";
                    break;
                case 3:
                    q = q + "//*[Procesleider-Perron='true']";
                    break;
                case 4:
                    q = q + "//*[Veiligheid-en-service='true']";
                    break;
                case 5:
                    q = q + "//*[Trainmanager-ICBrussel='true']";
                    break;
                case 6:
                    q = q + "//*[Trainmanager-ICE='true']";
                    break;
                case 7:
                    q = q + "//*[Trainmanager-Thalys='true']";
                    break;
                case 8:
                    q = q + "//*[Machinist-ICE='true']";
                    break;
                case 9:
                    q = q + "//*[Machinist-ICBrussel='true']";
                    break;
                case 10:
                    q = q + "//*[Machinist-Thalys='true']";
                    break;
            }

        }


        //selectie aanpassen
        XmlDataSource1.XPath = q;



        //update grid view
        XmlDataSource1.EnableCaching = false;
        XmlDataSource1.DataBind();
        GridView1.DataBind();
    }
}