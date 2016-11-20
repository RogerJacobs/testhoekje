using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ns.Stub.Orchestrator.Services;

public partial class pages_MijnBerichten_Stub : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void StartStub_Click(object sender, EventArgs e)
    {
        String status = "Succes";
        try
        {
//           BerichtenService.Instance.SetSmall();
        }
        catch (Exception erorr)
        {
            status = erorr.Message;
        }
        Status.Text = status;
    }
}