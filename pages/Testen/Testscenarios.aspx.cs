using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml;
using Gherkin;
using System.Collections;
using Testhoekje.App_Code.TestScenarios;


public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Int(object sender, EventArgs e)
    {
        TreeView1.CollapseAll();
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {
        TreeView1.CollapseAll();


        string PathProject = Server.MapPath("~");
   

        XmlDocument doc = new XmlDocument();
        doc.Load(PathProject + "\\datasource\\testscenarios.xml");
        var app = doc.SelectSingleNode("//*[local-name()='Mijn_Meldingen']").InnerXml;
        doc.LoadXml("<root>" + app + "</root>" );
        var tags = doc.SelectNodes("//*[local-name()='tags']");
        int aantal_autoamtische = 0;
        int aantal_geparkeerd = 0;
        string tag = "";
        for (int i=0; i < tags.Count ; i++)
        {
            tag = tags.Item(i).InnerText;
            if ( tag.Contains("@automatic") == true && tag.Contains("@wip") == false && tag.Contains("@turnedOff") == false) 
            {
                aantal_autoamtische = aantal_autoamtische + 1; 
            }
            if ( tag.Contains("@turnedOff") == true)
            {
                aantal_geparkeerd = aantal_geparkeerd + 1;
            }
        }
        Label1.Text = "Aantal scenario's: " + doc.SelectNodes("//*[local-name()='tags']").Count.ToString();
        Label2.Text = "Aantal Automatische: " + aantal_autoamtische.ToString();
        Label3.Text = "Aantal Automatische en uitgescahkeld: " + aantal_geparkeerd.ToString();
     
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string PathProject = Server.MapPath("~");
        XmlWriter writer = XmlWriter.Create(PathProject + "\\datasource\\testscenarios.xml");
        TestScenarios.ImportFeatures(writer);

        //ververs TreeView
        XmlDataSource1.EnableCaching = false;
        XmlDataSource1.DataBind();
        TreeView1.DataBind();
        TreeView1.CollapseAll();
    }

    protected void SluitAll_Click(object sender, EventArgs e)
    {
        TreeView1.CollapseAll();
    }

    protected void OpenAll_Click(object sender, EventArgs e)
    {
        TreeView1.ExpandAll();
    }
}