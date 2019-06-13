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
using System.Web.Mail;
using System.Text.RegularExpressions;
using System.Net;
//using System.Net.Mail;
using System.Web.UI.HtmlControls;
using System.Text;
using ADAL;
using ABLL;
using bh.bahrain.www;
using System.ServiceModel.Channels;

public partial class Contact : System.Web.UI.Page
{
    HttpCookie cultureCookie;
    public static DataSet ds;
    ADAL.ADAL cobj = new ADAL.ADAL();
    BLogic bobj = new BLogic();
    public static string ctmsg = "";
    public static DataTable dtContent;
    public static DataTable dtTypes;
    static string sname = System.Configuration.ConfigurationSettings.AppSettings["sid"].ToString().Trim();
    static string eser = System.Configuration.ConfigurationSettings.AppSettings["eser"].ToString().Trim();
    static string eeid = System.Configuration.ConfigurationSettings.AppSettings["eid"].ToString().Trim();
    static string epwd = System.Configuration.ConfigurationSettings.AppSettings["epwd"].ToString().Trim();
    static string eport = System.Configuration.ConfigurationSettings.AppSettings["eport"].ToString().Trim();
    static string efmail = System.Configuration.ConfigurationSettings.AppSettings["email"].ToString().Trim();
    static string tabout = System.Configuration.ConfigurationSettings.AppSettings["contact"].ToString().Trim();


    static string s1 = System.Configuration.ConfigurationSettings.AppSettings["siteurl"].ToString().Trim();
    static string s2 = System.Configuration.ConfigurationSettings.AppSettings["uname"].ToString().Trim();
    static string s3 = System.Configuration.ConfigurationSettings.AppSettings["upwd"].ToString().Trim();
    static string s4 = System.Configuration.ConfigurationSettings.AppSettings["scode"].ToString().Trim();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadLang();
            LoadLang1();
            
           HtmlGenericControl lbls = (HtmlGenericControl)Page.Master.FindControl("mcontact");
            
          lbls.InnerHtml = "<script src='https://maps.googleapis.com/maps/api/js?key=AIzaSyCPr_PaTg0NC1soJdiWfC74nnurdHRSydE'></script><script src='assets/js/custom.js'></script>";
        }
    }
    public void LoadLang1()
    {
        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

        Types tobj1 = new Types();
        tobj1.CType = "sall";
        dtTypes = cobj.GetTypes(tobj1);

        DataRow[] rabout = dtTypes.Select("TypesId='" + tabout + "'");

        Contents tobj = new Contents();
        tobj.CType = "sbytypea";
        tobj.TypesId = tabout;
        dtContent = cobj.GetContents(tobj);
        if (dtContent.Rows.Count > 0)
        {
            switch (cultureCode)
            {
                case "L2":
                    lbtnSubmit.Text = HttpContext.GetGlobalResourceObject("Lang", "Submit").ToString();
                    ctmsg = HttpContext.GetGlobalResourceObject("Lang", "CtMessage").ToString();
                   
                    haus.InnerHtml = dtContent.Rows[0]["ContentDetail1"].ToString().Trim();
                    lblProducts.Text= rabout[0]["TypesName1"].ToString().Trim();
                    lblProducts1.Text = rabout[0]["TypesName1"].ToString().Trim();
                    lblProducts2.Text = rabout[0]["TypesName1"].ToString().Trim();


                    lblfvenu.Text = "موقع المنتدى";

                    break;
                case "L1":
                    lbtnSubmit.Text = HttpContext.GetGlobalResourceObject("English", "Submit").ToString();
                    ctmsg = HttpContext.GetGlobalResourceObject("English", "CtMessage").ToString();
                    haus.InnerHtml = dtContent.Rows[0]["ContentDetail"].ToString().Trim();
                    lblProducts.Text = rabout[0]["TypesName"].ToString().Trim();
                    lblProducts1.Text = rabout[0]["TypesName"].ToString().Trim();
                    lblProducts2.Text = rabout[0]["TypesName"].ToString().Trim();
                    lblfvenu.Text = "Forum Venue";
                    break;
                default:
                    lbtnSubmit.Text = HttpContext.GetGlobalResourceObject("English", "Submit").ToString();
                    ctmsg = HttpContext.GetGlobalResourceObject("English", "CtMessage").ToString();
                    haus.InnerHtml = dtContent.Rows[0]["ContentDetail"].ToString().Trim();
                    lblProducts.Text = rabout[0]["TypesName"].ToString().Trim();
                    lblProducts1.Text = rabout[0]["TypesName"].ToString().Trim();
                    lblProducts2.Text = rabout[0]["TypesName"].ToString().Trim();
                    lblfvenu.Text = "Forum Venue";
                    break;
            }
        }
    }
    protected void lbtnSubmit_Click(object sender, EventArgs e)
    {
        string name = txtName.Text.Trim();
        string email = txtEmail.Text.Trim();
        string mno = txtMno.Text.Trim();
        string sub = txtSub.Text.Trim();
        string msg = txtMsg.Text.Trim();
        if (name == "" || email == "" || sub == "" || msg == "" || bobj.IsEMailValid(email) == false)
        {
            lbler.ForeColor = System.Drawing.Color.Maroon;
            lbler.Text = "Enter All Fields/Valid E-Mail ID";
        }
        else
        {
            string conid = cobj.GetIDA("Enquiry");
            
            lbler.ForeColor = System.Drawing.Color.Green;
            lbler.Text = ctmsg;

            if (efmail != "")
            {
                if (eeid != "")
                {

                    //  string sb = "Name:" + name + "<br>Mobile No.:" + mno + "<br>Email:" + email + "<br>Message:" + msg;
                    string sb = "Name:" + name + "<br>Email:" + email + "<br>Message:" + msg;
                    MailMessage meMail = new MailMessage();
                    meMail.BodyFormat = MailFormat.Html;
                    meMail.Subject = sub;
                    meMail.Body = sb;
                    meMail.From = email;
                    meMail.Fields["http://schemas.microsoft.com/cdo/configuration/smtsperver"] = eser;
                    meMail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserverport"] = Convert.ToInt32(eport);
                    meMail.Fields["http://schemas.microsoft.com/cdo/configuration/sendusing"] = 2;
                    // if (SMTPUser != null && SMTPPassword != null)
                    // {
                    meMail.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 1;
                    meMail.Fields["http://schemas.microsoft.com/cdo/configuration/sendusername"] = eeid;
                    meMail.Fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"] = epwd;
                    //  }
                    meMail.To = efmail;
                    SmtpMail.SmtpServer = eser;

                    SmtpMail.Send(meMail);





                    //string[] Tomailaddress = new string[1];

                    //Tomailaddress[0] = efmail;

                    //MailHeader mailHeader = new MailHeader();

                    //mailHeader.toMailIdArr = Tomailaddress;

                    //mailHeader.senderPassword = s3;

                    //mailHeader.senderUser = s2;



                    //Tomailaddress[0] = efmail;

                    ////files.fileContent=new byte[]

                    //// var client = new MailWSImplClient();
                    //// MailWSImplClient client = new MailWSImplClient();

                    //MailWSImplService client = new MailWSImplService();




                    //// CustomBinding binding = new CustomBinding(new CustomTextMessageBindingElement("iso-8859-1", "text/xml", MessageVersion.Soap11), new HttpTransportBindingElement());

                    ////  client.Endpoint.Binding = binding;
                    //client.sendHTMLMail(s4, mailHeader, sb.ToString());
                    ////  client.sendMail(s4, mailHeader, "test");
                    ////  var aa= client.sendMail(s4, mailHeader, "test");





                }



            }


        }
    }




    public void LoadLang()
    {
        cultureCookie = Request.Cookies["Culture"];
        string cultureCode = (cultureCookie != null) ? cultureCookie.Value : null;

      
        
            switch (cultureCode)
            {
                case "L2":
                lblName.Text = "الأسم";
                lblEmail.Text = "البريد الالكتروني";
                lblMessage.Text = "الرسالة";

                    break;
                case "L1":
                lblName.Text = "Name";
                lblEmail.Text = "Email ";
                lblMessage.Text = "Message";
                break;
                default:
                lblName.Text = "Name";
                lblEmail.Text = "Email ";
                lblMessage.Text = "Message";
                break;
            }
        
    }


}