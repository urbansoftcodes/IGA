using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using ADAL;
using ABLL;
public partial class pforum : System.Web.UI.UserControl
{
    HttpCookie cultureCookie;
    public string lang;
    ADAL.ADAL cobj = new ADAL.ADAL();
    public static DataTable dtTypes;
    public static DataTable dtSMenu1;
    public static DataTable dtSpeak;
    static string tspeakers = System.Configuration.ConfigurationSettings.AppSettings["forums"].ToString().Trim();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadLang();
            loadsmenu();

        }
    }
    public void LoadLang()
    {
        

        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

        switch (cultureCode)
        {
            case "L2":
                
                lblPForum.Text = HttpContext.GetGlobalResourceObject("Lang", "PForum").ToString();
                lblYear.Text = HttpContext.GetGlobalResourceObject("Lang", "Year").ToString();
                
                break;
            case "L1":
               
                lblPForum.Text = HttpContext.GetGlobalResourceObject("English", "PForum").ToString();
                lblYear.Text = HttpContext.GetGlobalResourceObject("English", "Year").ToString();
                


                break;
            default:
                
                lblPForum.Text = HttpContext.GetGlobalResourceObject("English", "PForum").ToString();
                lblYear.Text = HttpContext.GetGlobalResourceObject("English", "Year").ToString();
               
                break;
        }
    }
    public void loadsmenu()
    {
        Category tobj1 = new Category();
        tobj1.CType = "sbytype";
        tobj1.TypesId = tspeakers;
        dtSpeak = cobj.GetCategory(tobj1);
        dlSpeak.DataSource = dtSpeak;
        dlSpeak.DataBind();
    }

    protected void dlSpeak_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            //Label lbt1 = (Label)e.Item.FindControl("lblCTitle");
            //Label lbt1a = (Label)e.Item.FindControl("lblCTitle1");
            LinkButton lbt1 = (LinkButton)e.Item.FindControl("lblCTitle");
            LinkButton lbt1a = (LinkButton)e.Item.FindControl("lblCTitle1");

            cultureCookie = Request.Cookies["Culture"];
            string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

            switch (cultureCode)
            {
                case "L2":
                    lbt1.Visible = false;
                    lbt1a.Visible = true;
                    break;
                case "L1":
                    lbt1.Visible = true;
                    lbt1a.Visible = false;
                    break;
                default:
                    lbt1.Visible = true;
                    lbt1a.Visible = false;
                    break;
            }








        }
    }


    protected void dlSpeak_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string a = ((Label)e.Item.FindControl("lblCategoryId")).Text.Trim();
        if (e.CommandName == "view")
        {
            Session["pforum"] = a;
         Response.Redirect("Forums.aspx");
           // ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "script", "window.open ('Forums.aspx','_blank');", true);

        }
    }


}