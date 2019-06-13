﻿using System;
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
public partial class Agenda1 : System.Web.UI.Page
{
    HttpCookie cultureCookie;
    ADAL.ADAL cobj = new ADAL.ADAL();
    public static DataTable dtContent;
    static string tabout = System.Configuration.ConfigurationSettings.AppSettings["agenda"].ToString().Trim();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadLang1();

        }
    }
    public void LoadLang1()
    {
        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

        Contents tobj = new Contents();
        tobj.CType = "sbytypea";
        tobj.TypesId = tabout;
        dtContent = cobj.GetContents(tobj);
        if(dtContent.Rows.Count>0)
        {
      
        switch (cultureCode)
        {
            case "L2":

                    aaus.InnerHtml = dtContent.Rows[0]["ContentDetail1"].ToString().Trim();
                break;
            case "L1":

                    aaus.InnerHtml = dtContent.Rows[0]["ContentDetail"].ToString().Trim();
                    break;
            default:

                    aaus.InnerHtml = dtContent.Rows[0]["ContentDetail"].ToString().Trim();
                    break;
        }
        }


    }
}