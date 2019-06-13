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
public partial class PhotoGalleryYear : System.Web.UI.Page
{
    HttpCookie cultureCookie;
    public static DataTable ds;
    public static DataTable dtCategory;
    ADAL.ADAL cobj = new ADAL.ADAL();
    static string tid = System.Configuration.ConfigurationSettings.AppSettings["photo"].ToString().Trim();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Request.QueryString["c"]!=null)
            {
                lblpid.Text = Request.QueryString["c"].ToString().Trim();
            }
            LoadCategory();
            LoadLang();
            LoadProducts();
        }
       
    }

    public void LoadProducts()
    {
        string a = lblpid.Text.Trim();
        //Contents aobj = new Contents();
        //aobj.TypesId = tid;
        //if(a=="")
        //{
        //    aobj.CType = "sbytypea";
        //}
        //else
        //{
        //    aobj.CType = "sbycata";
        //    aobj.CategoryId = a;
        //}

        Category aobj = new Category();
        aobj.TypesId = tid;
        aobj.CType = "sbytype";
        
        ds = cobj.GetCategory(aobj);
        dlProducts.DataSource = ds;
        dlProducts.DataBind();
        
    }


    public void LoadLang()
    {
        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;
        string a = lblpid.Text.Trim();
        Category caobj = new Category();
        caobj.CType = "sone";
        caobj.CategoryId = a;
        DataTable dtca = cobj.GetCategory(caobj);

        Types caobj1 = new Types();
        caobj1.CType = "sone";
        caobj1.TypesId = tid;
        DataTable dtca1 = cobj.GetTypes(caobj1);


        switch (cultureCode)
        {
            case "L2":
                if (dtca1.Rows.Count > 0)
                {
                    lblProducts1.Text = dtca1.Rows[0]["TypesName1"].ToString().Trim();
                }
                // lblCat.Text = HttpContext.GetGlobalResourceObject("Lang", "Categories").ToString();
                if (a=="")
                {
                    if (dtca1.Rows.Count > 0)
                    {
                        lblProducts.Text = dtca1.Rows[0]["TypesName1"].ToString().Trim();
                        lblProducts2.Text = dtca1.Rows[0]["TypesName1"].ToString().Trim();
                    }

                }
                else
                {
                    if(dtca.Rows.Count>0)
                    {
                        lblProducts.Text = dtca.Rows[0]["CategoryName1"].ToString().Trim();
                        lblProducts2.Text = dtca.Rows[0]["CategoryName1"].ToString().Trim();
                    }
                    
                }
                
                
                break;
            case "L1":
                if (dtca1.Rows.Count > 0)
                {
                    lblProducts1.Text = dtca1.Rows[0]["TypesName"].ToString().Trim();
                }
                //lblCat.Text = HttpContext.GetGlobalResourceObject("English", "Categories").ToString();
                if (a == "")
                {
                    if (dtca1.Rows.Count > 0)
                    {
                        lblProducts.Text = dtca1.Rows[0]["TypesName"].ToString().Trim();
                        lblProducts2.Text = dtca1.Rows[0]["TypesName"].ToString().Trim();
                    }
                }
                else
                {
                    if (dtca.Rows.Count > 0)
                    {
                        lblProducts.Text = dtca.Rows[0]["CategoryName"].ToString().Trim();
                        lblProducts2.Text = dtca.Rows[0]["CategoryName1"].ToString().Trim();
                    }

                }
               
               

                break;
            default:
                if (dtca1.Rows.Count > 0)
                {
                    lblProducts1.Text = dtca1.Rows[0]["TypesName"].ToString().Trim();
                }
                //lblCat.Text = HttpContext.GetGlobalResourceObject("English", "Categories").ToString();
                if (a == "")
                {
                    if (dtca1.Rows.Count > 0)
                    {
                        lblProducts.Text = dtca1.Rows[0]["TypesName"].ToString().Trim();
                        lblProducts2.Text = dtca1.Rows[0]["TypesName"].ToString().Trim();
                    }
                }
                else
                {
                    if (dtca.Rows.Count > 0)
                    {
                        lblProducts.Text = dtca.Rows[0]["CategoryName"].ToString().Trim();
                        lblProducts2.Text = dtca.Rows[0]["CategoryName1"].ToString().Trim();
                    }

                }
                break;
        }
    }

    protected void dlProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
           e.Item.ItemType == ListItemType.AlternatingItem)
        {


            LinkButton lbtit = (LinkButton)e.Item.FindControl("lblTitle");
            LinkButton lbtit1 = (LinkButton)e.Item.FindControl("lblTitle1");

            Label lbid = (Label)e.Item.FindControl("lblProductId");

            // ImageButton lbimg = (ImageButton)e.Item.FindControl("imgc");

            Image lbimg = (Image)e.Item.FindControl("imgc");

            Contents cobjc = new Contents();
            cobjc.CType = "sbycata";
            cobjc.TypesId = tid;
            cobjc.CategoryId = lbid.Text;

            DataTable dtc1 = cobj.GetContents(cobjc);

            if(dtc1.Rows.Count>0)
            {
                lbimg.ImageUrl = dtc1.Rows[0]["DImage"].ToString().Trim();
            }

            cultureCookie = Request.Cookies["Culture"];
            string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

            switch (cultureCode)
            {
                case "L2":
                    lbtit.Visible = false;
                    lbtit1.Visible = true;

                   
                    break;
                case "L1":
                    lbtit.Visible = true;
                    lbtit1.Visible = false;

                  

                    break;
                default:
                    lbtit.Visible = true;
                    lbtit1.Visible = false;

                   

                    break;
            }






        }
    }


    protected void dlProducts1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
           e.Item.ItemType == ListItemType.AlternatingItem)
        {


            Label lbtit = (Label)e.Item.FindControl("lblTitle");
            Label lbtit1 = (Label)e.Item.FindControl("lblTitle1");


            cultureCookie = Request.Cookies["Culture"];
            string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

            switch (cultureCode)
            {
                case "L2":
                    lbtit.Visible = false;
                    lbtit1.Visible = true;


                    break;
                case "L1":
                    lbtit.Visible = true;
                    lbtit1.Visible = false;



                    break;
                default:
                    lbtit.Visible = true;
                    lbtit1.Visible = false;



                    break;
            }






        }
    }



    protected void dlProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string a = ((Label)e.Item.FindControl("lblProductId")).Text.Trim();
        if (e.CommandName == "view")
        {
            Session["pgallery"] = a;
            Response.Redirect("PhotoGallery.aspx");

        }
    }




    #region Category


    public void LoadCategory()
    {
        Category mobj = new Category();
        mobj.CType = "sbytype";
        mobj.TypesId = tid;
        dtCategory = cobj.GetCategory(mobj);
        //dlCategory.DataSource = dtCategory;
        //dlCategory.DataBind();
    }

    //protected void dlHmenu_ItemDataBound(object sender, DataListItemEventArgs e)
    protected void dlCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lbt1 = (LinkButton)e.Item.FindControl("lbtnCategoryName");
            LinkButton lbt1a = (LinkButton)e.Item.FindControl("lbtnCategoryName1");
           

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
    //protected void dlHmenu_ItemCommand(object source, DataListCommandEventArgs e)
    protected void dlCategory_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        string a = ((Label)e.Item.FindControl("lblCategoryId")).Text.Trim();
        string c = ((LinkButton)e.Item.FindControl("lbtnCategoryName")).Text.Trim();
        string d = ((LinkButton)e.Item.FindControl("lbtnCategoryName1")).Text.Trim();
        string f = "";
        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

        switch (cultureCode)
        {
            case "L2":
                f = d;
                break;
            case "L1":
                f = c;
                break;
            default:
                f = c;
                break;
        }

        if (e.CommandName == "view")
        {
            Response.Redirect("PhotoGallery.aspx?c=" + a + "&n=" + f);

        }
    }


    #endregion Category



  


}