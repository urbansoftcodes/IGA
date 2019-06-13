using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Reflection;
using System.Resources;
using System.Globalization;
using System.Security.Principal;
using System.Web.Services;
using System.IO;
using ADAL;
using ABLL;
using System.Web.UI.HtmlControls;
public partial class Agenda : System.Web.UI.Page
{
    HttpCookie cultureCookie;
    ADAL.ADAL cobj = new ADAL.ADAL();
    public static DataTable dtContent;
    public static DataTable dtTypes;
    static string tabout = System.Configuration.ConfigurationSettings.AppSettings["agenda"].ToString().Trim();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadLang1();
            LoadLatest();

        }
    }
    public void LoadLang1()
    {
        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

        Types tobj = new Types();
        tobj.CType = "sone";
        tobj.TypesId = tabout;
        dtTypes = cobj.GetTypes(tobj);
        if (dtTypes.Rows.Count>0)
        {
      
        switch (cultureCode)
        {
            case "L2":

                   lblAgenda.Text= dtTypes.Rows[0]["TypesName1"].ToString().Trim();
                    lblAgenda1.Text = dtTypes.Rows[0]["TypesName1"].ToString().Trim();
                    lblAgenda2.Text = dtTypes.Rows[0]["TypesName1"].ToString().Trim();
                    break;
            case "L1":
                    lblAgenda.Text = dtTypes.Rows[0]["TypesName"].ToString().Trim();
                    lblAgenda1.Text = dtTypes.Rows[0]["TypesName"].ToString().Trim();
                    lblAgenda2.Text = dtTypes.Rows[0]["TypesName"].ToString().Trim();
                    break;
            default:
                    lblAgenda.Text = dtTypes.Rows[0]["TypesName"].ToString().Trim();
                    lblAgenda1.Text = dtTypes.Rows[0]["TypesName"].ToString().Trim();
                    lblAgenda2.Text = dtTypes.Rows[0]["TypesName"].ToString().Trim();
                    break;
        }
        }


    }


    public void LoadLatest()
    {

        Category aobj2 = new Category();
        aobj2.TypesId = tabout;
        aobj2.CType = "sbytype";

        dtTypes = cobj.GetCategory(aobj2);

        // dtLatest1 = dtLatest1.Rows.Cast<System.Data.DataRow>().Take(4).CopyToDataTable();

        if (dtTypes.Rows.Count > 0)
        {
            if(lblpid.Text.Trim()=="")
            {
                lblpid.Text = dtTypes.Rows[0]["CategoryId"].ToString().Trim();
            }
           
        }

        dlLatest1.DataSource = dtTypes;
        dlLatest1.DataBind();

        


    }
    protected void dlLatest1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
           e.Item.ItemType == ListItemType.AlternatingItem)
        {


            LinkButton lbtit = (LinkButton)e.Item.FindControl("lblTitle");
            LinkButton lbtit1 = (LinkButton)e.Item.FindControl("lblTitle1");

            LinkButton lbday = (LinkButton)e.Item.FindControl("lbtnDay");

            Label lbid = (Label)e.Item.FindControl("lblProductId");

            Label lbid1 = (Label)e.Item.FindControl("lblCategoryId");

            cultureCookie = Request.Cookies["Culture"];
            string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

            switch (cultureCode)
            {
                case "L2":
                    lbtit.Visible = false;
                    lbtit1.Visible = true;
                    if(lbid1.Text.Trim()=="1")
                    {
                        lbday.Text = "07 أكتوبر 2018";
                    }
                    else
                    {
                        lbday.Text = "08 أكتوبر 2018";
                    }


                    break;
                case "L1":
                    lbtit.Visible = true;
                    lbtit1.Visible = false;
                    if (lbid1.Text.Trim() == "1")
                    {
                        lbday.Text = "07 October 2018";
                    }
                    else
                    {
                        lbday.Text = "08 October 2018";
                    }


                    break;
                default:
                    lbtit.Visible = true;
                    lbtit1.Visible = false;
                    if (lbid1.Text.Trim() == "1")
                    {
                        lbday.Text = "07 October 2018";
                    }
                    else
                    {
                        lbday.Text = "08 October 2018";
                    }


                    break;
            }



            HtmlControl hc = (HtmlControl)e.Item.FindControl("yforum");
            if (lblpid.Text.Trim() == lbid.Text.Trim())
            {
                hc.Attributes["class"] = "active";
                Contents cobjc = new Contents();
                cobjc.CType = "sbycataa";
                cobjc.TypesId = tabout;
                cobjc.CategoryId = lbid.Text;

                DataTable dtc1 = cobj.GetContents(cobjc);
                dlCont.DataSource = dtc1;
                dlCont.DataBind();


            }
            else
            {
                hc.Attributes["class"] = "";
                //fcont.InnerHtml = "";
            }





        }
    }

    protected void dlLatest1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string a = ((Label)e.Item.FindControl("lblProductId")).Text.Trim();
        if (e.CommandName == "view")
        {
            lblpid.Text = a;
            LoadLatest();

        }
    }



  

    protected void dlCont_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label lbt1 = (Label)e.Item.FindControl("lblCTitle");
            Label lbt1a = (Label)e.Item.FindControl("lblCTitle1");
            Label lbts1 = (Label)e.Item.FindControl("lblShort");
            Label lbts1a = (Label)e.Item.FindControl("lblShort1");
            Label lbtm1 = (Label)e.Item.FindControl("lblTime");
            Label lbtm1a = (Label)e.Item.FindControl("lblTime1");
          Label lblp = (Label)e.Item.FindControl("lblpresent");
            Label lbld = (Label)e.Item.FindControl("lbldimg");
            HtmlControl hc = (HtmlControl)e.Item.FindControl("dimg");
            if (lbld.Text.Trim()=="")
            {
                hc.Visible = false;
                lblp.Visible = false;
            }
            else
            {
                hc.Visible = true;
                lblp.Visible = true;
                if(File.Exists(Server.MapPath(lbld.Text.Trim()))==true)
                {
                    FileInfo finf = new FileInfo(Server.MapPath(lbld.Text.Trim()));

                    long b = finf.Length;
                    decimal kb = b / 1024;
                    decimal mb = kb / 1024;
                    decimal gb = mb / 1024;

                    lblp.Text = mb.ToString("#.000") + " MB";
                }
                
            }

            cultureCookie = Request.Cookies["Culture"];
            string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

            switch (cultureCode)
            {
                case "L2":
                    lbt1.Visible = false;
                    lbt1a.Visible = true;
                    lbts1.Visible = false;
                    lbts1a.Visible = true;
                    lbtm1.Visible = false;
                    lbtm1a.Visible = true;
                   // lblp.Text = "عرض";
                    break;
                case "L1":
                    lbt1.Visible = true;
                    lbt1a.Visible = false;
                    lbts1.Visible = true;
                    lbts1a.Visible = false;
                    lbtm1.Visible = true;
                    lbtm1a.Visible = false;
                    //lblp.Text = "Presentation";
                    break;
                default:
                    lbt1.Visible = true;
                    lbt1a.Visible = false;
                    lbts1.Visible = true;
                    lbts1a.Visible = false;
                    lbtm1.Visible = true;
                    lbtm1a.Visible = false;
                   // lblp.Text = "Presentation";
                    break;
            }



        }
    }




}