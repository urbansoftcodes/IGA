using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using ABLL;
using ADAL;
public partial class AEnquiry : System.Web.UI.Page
{
    ADAL.ADAL cobj = new ADAL.ADAL();
    RDAL obj1 = new RDAL();
    HttpCookie cultureCookie;
    public static DataTable dtEnquiries;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Request.QueryString["c"] != null)
            {
                lblcid.Text = cobj.Decrypt(Request.QueryString["c"].ToString().Trim());
               
            }
            LoadEnquiries();
        }
    }

  
    public void LoadEnquiries()
    {
        Regsc pobj = new Regsc();
        pobj.CType = "sone";
        pobj.RegId = lblcid.Text.Trim();
        dtEnquiries = obj1.GetRegsc(pobj);
        dlEnq.DataSource = dtEnquiries;
        dlEnq.DataBind();
    }

   
   

}