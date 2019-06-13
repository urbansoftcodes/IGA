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
public partial class _login : System.Web.UI.Page
{
    BLogic lobj = new BLogic();
    ADAL.ADAL obj = new ADAL.ADAL();
    public static DataTable dtAdmin;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtpwd.Attributes.Add("autocomplete", "off");
            txtuid.Attributes.Add("autocomplete", "off");
            string asalt = obj.RNGCharacterMask();
            HDsalt.Value = asalt;

        }
    }

    protected void lbtnlogin_Click(object sender, EventArgs e)
    {
        string UserId = HDusername.Value.ToString();
        string Pwd = HDPassword.Value.ToString();
        string Saltval = HDsalt.Value.ToString();
       
        if(UserId=="" || Pwd=="")
        {
            lbler.Text = "Enter All Fields";
        }
        else
        {
            AdminDet aobj = new AdminDet();
            aobj.CType = "selectonebyname";
            aobj.AdminName = UserId;
            dtAdmin = obj.GetAdminDet(aobj);
            if(dtAdmin.Rows.Count>0)
            {
                string pw1 = dtAdmin.Rows[0]["AdminPwd"].ToString().Trim();
                string pw = pw1 + Saltval;
                string pwd1 = obj.EncodePassword(pw);
                if (Pwd == pwd1)
                {
                    string astat = dtAdmin.Rows[0]["AdminStatus"].ToString().Trim();
                    if(astat=="1")
                    {
                        Session["aid"] = dtAdmin;
                        Response.Cookies.Add(new HttpCookie("aid", UserId));
                        Response.Redirect("ACategory.aspx");
                    }
                    else
                    {
                        lbler.Text = "Your account has been deactivated";
                    }
                }
                else
                {
                    lbler.Text = "Invalid Password";
                }


             }
            else
            {
                lbler.Text = "Invalid User Id";
            }

        }
    }
}