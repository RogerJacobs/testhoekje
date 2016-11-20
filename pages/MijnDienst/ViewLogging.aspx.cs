using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class pages_MijnDienst_ViewLogging : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string PathProject = Server.MapPath("~") + "logging\\ADK";

        System.Data.DataTable dt = new System.Data.DataTable();
        dt.Columns.Add("name");
  
        string[] files = Directory.GetFiles(PathProject, "*.txt");
        for (int i = 0; i < files.Length; i++) 
        {
            files[i] = Path.GetFileName(files[i]);
            dt.Rows.Add(Path.GetFileName(files[i])); 
        }

        GridView1.DataSource = dt;
        GridView1.DataBind();

        foreach (GridViewRow gvr in GridView1.Rows)
        {
            ((HyperLink)gvr.Cells[0].Controls[0]).NavigateUrl = PathProject
                                                  + dt.Rows[gvr.RowIndex]["name"];
        }
    }

  
    protected void DeleteAll_Click(object sender, EventArgs e)
    {
        string PathProject = Server.MapPath("~") + "logging\\ADK";

//        System.Data.DataTable dt = new System.Data.DataTable();
//        dt.Columns.Add("name");

        string[] files = Directory.GetFiles(PathProject, "*.txt");
        for (int i = 0; i < files.Length; i++)
        {
            System.IO.File.Delete(files[i]);
        }

     //   GridView1.DataSource = dt;
       GridView1.DataBind();

  
    }
}