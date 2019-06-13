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
public partial class Search : System.Web.UI.Page
{
    HttpCookie cultureCookie;
    public static DataSet ds;
    public static DataTable dtTypes;
    public static DataTable dtCategory;
    ADAL.ADAL cobj = new ADAL.ADAL();
    
    static string tabout = System.Configuration.ConfigurationSettings.AppSettings["about"].ToString().Trim();
    static string ttopic = System.Configuration.ConfigurationSettings.AppSettings["topics"].ToString().Trim();
    static string tagenda = System.Configuration.ConfigurationSettings.AppSettings["agenda"].ToString().Trim();
    static string tspeakers = System.Configuration.ConfigurationSettings.AppSettings["speakers"].ToString().Trim();
    static string tspeakers2018 = System.Configuration.ConfigurationSettings.AppSettings["speakers2018"].ToString().Trim();
    static string tnews = System.Configuration.ConfigurationSettings.AppSettings["news"].ToString().Trim();
    static string tphoto = System.Configuration.ConfigurationSettings.AppSettings["photo"].ToString().Trim();
    static string tvideo = System.Configuration.ConfigurationSettings.AppSettings["video"].ToString().Trim();
    static string tcontact = System.Configuration.ConfigurationSettings.AppSettings["contact"].ToString().Trim();

    static string thome = System.Configuration.ConfigurationSettings.AppSettings["home"].ToString().Trim();
    static string thome1 = System.Configuration.ConfigurationSettings.AppSettings["homeforum"].ToString().Trim();
    static string thome2 = System.Configuration.ConfigurationSettings.AppSettings["homefeed"].ToString().Trim();
    static string thome3 = System.Configuration.ConfigurationSettings.AppSettings["homehelp"].ToString().Trim();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
           // LoadCategory();
            LoadLang();
            LoadProducts();
        }
        else
        {
            //since the pagination controls are dynamically creating its shld be re created in each page load
            BuildPagination();
        }
    }

    public void LoadProducts()
    {
        if(Session["search"]!=null)
        {
            Contents aobj = new Contents();
            // aobj.TypesId = tid;

            aobj.CType = "search";
            aobj.PageTitle = Session["search"].ToString().Trim();

            ds = cobj.GetContentsDS(aobj);
            bindDataWithPaging(dlProducts, ds);
        }
        
    }


    public void LoadLang()
    {
        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;
        Types tobj = new Types();
        tobj.CType = "sall";
        dtTypes = cobj.GetTypes(tobj);

      //  DataRow[] rabout = dtTypes.Select("TypesId='" + tid + "'");

       
        switch (cultureCode)
        {
            case "L2":
               

                break;
            case "L1":
               
                break;
            default:
               
                break;
        }
    }

    protected void dlProducts_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
           e.Item.ItemType == ListItemType.AlternatingItem)
        {


            //Label lbtit = (Label)e.Item.FindControl("lblTitle");
            //Label lbtit1 = (Label)e.Item.FindControl("lblTitle1");

            LinkButton lbtit = (LinkButton)e.Item.FindControl("lblTitle");
            LinkButton lbtit1 = (LinkButton)e.Item.FindControl("lblTitle1");
            Label lbsho = (Label)e.Item.FindControl("lblShort");
            Label lbsho1 = (Label)e.Item.FindControl("lblShort1");
          

           // Label lbadr = (Label)e.Item.FindControl("lblView");

            //LinkButton lbadr = (LinkButton)e.Item.FindControl("lblView");

            cultureCookie = Request.Cookies["Culture"];
            string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

            switch (cultureCode)
            {
                case "L2":
                    lbtit.Visible = false;
                    lbtit1.Visible = true;

                    lbsho.Visible = false;
                    lbsho1.Visible = true;

                   

                   // lbadr.Text = HttpContext.GetGlobalResourceObject("Lang", "ReadMore").ToString();
                    break;
                case "L1":
                    lbtit.Visible = true;
                    lbtit1.Visible = false;

                    lbsho.Visible = true;
                    lbsho1.Visible = false;

                    
                   // lbadr.Text = HttpContext.GetGlobalResourceObject("English", "ReadMore").ToString();

                    break;
                default:
                    lbtit.Visible = true;
                    lbtit1.Visible = false;

                    lbsho.Visible = true;
                    lbsho1.Visible = false;

                    

                   // lbadr.Text = HttpContext.GetGlobalResourceObject("English", "ReadMore").ToString();

                    break;
            }






        }
    }



    protected void dlProducts_ItemCommand(object source,DataListCommandEventArgs e)
    {
        string a = ((Label)e.Item.FindControl("lblProductId")).Text.Trim();
        string b= ((Label)e.Item.FindControl("lblTypeId")).Text.Trim();
        string c = ((Label)e.Item.FindControl("lblCatId")).Text.Trim();
        if (e.CommandName == "view")
        {


            if (b == tabout)
            {
                Response.Redirect("About.aspx");
            }
            else if(b==tagenda)
            {
                Response.Redirect("Agenda.aspx");
            }
            else if (b == tcontact)
            {
                Response.Redirect("Contact.aspx");
            }
            else if (b == tspeakers)
            {
                Session["speakerdetail"] = a;
                Response.Redirect("SpeakerDetail.aspx");

            }
            else if (b == tnews)
            {
                Session["news"] = a;
                Response.Redirect("NewsDetail.aspx");
            }
            else if (b == tphoto)
            {
                Session["pgallery"] = a;
                Response.Redirect("PhotoGallery.aspx");
            }
            else if (b == tvideo)
            {
                Response.Redirect("VideoGallery.aspx");
            }
            else if (b == ttopic)
            {
                Session["topics"] = c;
                Response.Redirect("Topics.aspx");
            }
            else if (b == thome || b==thome1 || b == thome2 || b == thome3)
            {
                Response.Redirect("Default.aspx");
            }



            //Session["news"] = a;
            //Response.Redirect("NewsDetail.aspx");

        }
    }


    #region Pager Creation
    protected void lnkPager_Click(object sender, EventArgs e) //Page index changed function
    {
        LinkButton lnk = (LinkButton)sender;
        CurrentPageIndex = int.Parse(lnk.CommandArgument);

        LoadProducts();
    }

    private int PageSize //total rows per page
    {

        get
        {

            // string a = ddlpage.SelectedValue.ToString().Trim();
            string a = "10";
            int b = 12;
            if (a != "")
            {
                b = Convert.ToInt32(a);
            }

            return b;
        }
    }

    private int ButtonsCount //how many total linkbuttons shld be shown
    {
        get { return 10; }
    }

    private string FirstPageText
    {
        get { return "&lt;&lt;"; }
    }
    private string LastPageText
    {
        get { return "&gt;&gt;"; }
    }


    private void bindDataWithPaging(Control bindControl, DataSet data) //you can pass either DatList or Repeater to this function
    {
        if (data.Tables.Count > 0) // if the datset contains data
        {
            DataView dv = data.Tables[0].DefaultView;

            PagedDataSource dsP = new PagedDataSource();
            dsP.AllowPaging = true;
            dsP.DataSource = dv;
            dsP.CurrentPageIndex = CurrentPageIndex;
            dsP.PageSize = PageSize;

            //Binding data to the controls
            if (bindControl is DataList)
            {
                ((DataList)bindControl).DataSource = dsP;
                ((DataList)bindControl).DataBind();
            }
            else if (bindControl is Repeater)
            {
                ((Repeater)bindControl).DataSource = dsP;
                ((Repeater)bindControl).DataBind();
            }

            //saving the total page count in Viewstate for later use
            PageCount = dsP.PageCount;

            //create the linkbuttons for pagination
            BuildPagination();
        }
    }

    private int CurrentPageIndex //to store the current page index
    {
        get { return ViewState["CurrentPageIndex"] == null ? 0 : int.Parse(ViewState["CurrentPageIndex"].ToString()); }
        set { ViewState["CurrentPageIndex"] = value; }
    }
    private int PageCount  //total number of pages needed to display the data
    {
        get { return ViewState["PageCount"] == null ? 0 : int.Parse(ViewState["PageCount"].ToString()); }
        set { ViewState["PageCount"] = value; }
    }

    private LinkButton createButton(string title, int index)
    {
        LinkButton lnk = new LinkButton();
        lnk.ID = index.ToString();
        lnk.Text = title;
        lnk.CommandArgument = index.ToString();
        lnk.Click += new EventHandler(lnkPager_Click);
        return lnk;
    }

    //create the linkbuttons for pagination
    protected void BuildPagination()
    {
        pnlPager.Controls.Clear(); //

        if (PageCount <= 1) return; // at least two pages should be there to show the pagination

        //finding the first linkbutton to be shown in the current display
        int start = CurrentPageIndex - (CurrentPageIndex % ButtonsCount);

        //finding the last linkbutton to be shown in the current display
        int end = CurrentPageIndex + (ButtonsCount - (CurrentPageIndex % ButtonsCount));

        //if the start button is more than the number of buttons. If the start button is 11 we have to show the <<First link
        if (start > ButtonsCount - 1)
        {
            pnlPager.Controls.Add(createButton(FirstPageText, 0));
            pnlPager.Controls.Add(createButton("..", start - 1));
        }

        int i = 0, j = 0;

        for (i = start; i < end; i++)
        {
            LinkButton lnk;
            if (i < PageCount)
            {
                if (i == CurrentPageIndex) //if its the current page
                {
                    Label lbl = new Label();
                    lbl.Text = (i + 1).ToString();
                    pnlPager.Controls.Add(lbl);
                }
                else
                {
                    pnlPager.Controls.Add(createButton((i + 1).ToString(), i));
                }
            }
            j++;
        }

        //If the total number of pages are greaer than the end page we have to show Last>> link
        if (PageCount > end)
        {
            pnlPager.Controls.Add(createButton("..", i));
            pnlPager.Controls.Add(createButton("&gt;&gt;", PageCount - 1));
        }


    }
    #endregion





}