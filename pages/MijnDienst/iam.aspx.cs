using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Testhoekje.App_Code.API;
using Testhoekje.App_Code.IAMsupport;
using System.IO;
using System.Xml;

public partial class IAM : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

        string PathProject = Server.MapPath("~"); 
        // Stop Caching in IE
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);

        // Stop Caching in Firefox
        Response.Cache.SetNoStore();
        
        XmlDocument doc = new XmlDocument();
        doc.Load(PathProject + "\\datasource\\IAM.xml");
        Label1.Text = "Aantal getelde TSB berichten: " + doc.SelectNodes("//*[local-name()='TijdelijkeSnelheidsBeperking']").Count.ToString();
        Label3.Text = "Aantal getelde Wegwijzer berichten: " + doc.SelectNodes("//*[local-name()='WegwijzerBericht']").Count.ToString();
        Label2.Text = "Aantal getelde RayonInfo berichten: " + doc.SelectNodes("//*[local-name()='RayonInfo']").Count.ToString();
     
       
    }


    protected void SluitAll_Click(object sender, EventArgs e)
    {
        TreeView1.CollapseAll();
    }

    protected void OpenAll_Click(object sender, EventArgs e)
    {
        TreeView1.ExpandAll();
    }


    protected void GetIAM_Click(object sender, EventArgs e)
    {
        string PathProject = Server.MapPath("~"); 
        API iam = new API();
        XmlDocument doc = new XmlDocument();
        IAMsupport imaScreen = new IAMsupport();
        string url = "";
        switch (Omgeving.Text)
        {
            case "Stub_O":
                url = @"http://nsorp-stubs.orp-o.p.azurewebsites.net/file/iam/iam_Ontwikkel.xml";
                break;
            case "Stub_T":
                url = @"http://nsorp-stubs.orp-o.p.azurewebsites.net/file/iam/iam_Test.xml";
                break;
            case "A":
                url = @"http://10.149.0.9/RpController/getIAM.rps";
                break;
            case "P":
                url = @"http://10.145.0.65/RpController/getIAM.rps";
                break;
        }

        var result = iam.GetIAM(url);

        if (result.Contains("ControleGetallen"))
        {
            doc.LoadXml(result);



            try
            {
                string path = PathProject + "\\logging\\IAM";
                string fileName = path + "\\IAM_" + Omgeving.Text + "_" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".txt";

                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine(result);
                    sw.Close();
                }
            }
            catch { }
        }
        else
        {
            doc.LoadXml("<error>"+ result  + "</error>");
        }
        doc.Save(PathProject + "\\datasource\\IAM.xml");
        XmlText.Text = Server.HtmlEncode(result);


        //IAM scherm bij werken
        imaScreen.Store_IAM(result);
        Response.Redirect(Request.RawUrl);

        //verversen van 
        XmlDataSource1.EnableCaching = false;
        XmlDataSource1.DataBind();
        TreeView1.DataBind();



    }
}