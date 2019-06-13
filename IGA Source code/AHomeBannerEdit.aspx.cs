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

public partial class Default3 : System.Web.UI.Page
{
    ADAL.ADAL cobj = new ADAL.ADAL();
    RDAL robj = new RDAL();
    HttpCookie cultureCookie;
    public static DataTable dtTypes;
    public static DataTable dtCategory;
    public static DataTable dtSubCategory;
    public static DataTable dtSCategorySub;
    public static DataTable dtContents;
    public static DataTable dtImages;
    static string furl = System.Configuration.ConfigurationSettings.AppSettings["furl"].ToString().Trim();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["c"] != null)
            {
                lblcid.Text = cobj.Decrypt(Request.QueryString["c"].ToString().Trim());
                if (!string.IsNullOrEmpty(lblcid.Text))
                {
                    int bannerorder = Convert.ToInt32(cobj.Decrypt(Request.QueryString["c"].ToString().Trim()));
                    LoadBannerDetails(bannerorder);
                    lbtnUpdate.Text = "Update";
                  
                }
            }
            else
            {
                lbtnUpdate.Text = "Add";
              
            }


        }
    }


    public void LoadBannerDetails(int ID)
    {
        DataTable dt = robj.FetchHomeBannerByID(ID);
        foreach (DataRow dr in dt.Rows)
        {
            txtTitle.Text = Convert.ToString(dr["Title_English"]);
            txtTitle1.Text = Convert.ToString(dr["Title_Arabic"]);
            txtShort.Text = Convert.ToString(dr["ShortDesc_English"]);
            txtShort1.Text = Convert.ToString(dr["ShortDesc_Arabic"]);
            txtCDet.Text = Convert.ToString(dr["ContentDetail_English"]);
            txtCDet1.Text = Convert.ToString(dr["ContentDetail_Arabic"]);
            txtBanners.Text = Convert.ToString(dr["BannerOrder"]);
            hdnfileupload_arabic.Value = Convert.ToString(dr["ImageUrl_Arabic"]);
            hdnfileupload_english.Value = Convert.ToString(dr["ImageUrl_English"]);


        }
    }

    protected void lbtnUpdate_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["csrf"] == null || Request.Cookies["csrf"].ToString().Trim() == "")
        {
            Response.Redirect("Default.aspx");
        }
        else
        {

            cultureCookie = Request.Cookies["csrf"];
            string csrt = cultureCookie.Value;
            int bannerid = string.IsNullOrEmpty(lblcid.Text) ? 0 : Convert.ToInt32(lblcid.Text);
            HomeBanners_Mob banner = new HomeBanners_Mob();
            banner.HomeBannerID = bannerid;
            banner.Title_Arabic = txtTitle1.Text.Trim();
            banner.Title_English = txtTitle.Text.Trim();
            banner.ShortDesc_English = txtShort.Text.Trim();
            banner.ShortDesc_Arabic = txtShort1.Text.Trim();
            banner.ContentDetail_English = txtCDet.Text.Trim();
            banner.ContentDetail_Arabic = txtCDet1.Text.Trim();
            banner.BannerOrder = string.IsNullOrEmpty(txtBanners.Text) ? 0 : Convert.ToInt32(txtBanners.Text);
            string arabicurl = lbtnUpload_Image_Arabic();
            string englishurl = lbtnUpload_Image_English();
            banner.ImageUrl_Arabic = string.IsNullOrEmpty(arabicurl) ? hdnfileupload_arabic.Value : arabicurl;
            banner.ImageUrl_English = string.IsNullOrEmpty(englishurl) ? hdnfileupload_english.Value : englishurl;
            banner.Type = string.IsNullOrEmpty(lblcid.Text) ? "Insert" : "Update";
            robj.PostHomeBanners(banner);
            if (string.IsNullOrEmpty(lblcid.Text))
            {
                lbler.Text = "Added Successfully";
                ClearFields();
            }
            else
            {
                lbler.Text = "Updated Successfully";
               // Response.Redirect("AHomeBanner.aspx");
            }

        }
    }

    public void ClearFields()
    {
        txtTitle.Text = "";
        txtTitle1.Text = "";
        txtShort.Text = "";
        txtShort1.Text = "";
        txtCDet.Text = "";
        txtCDet1.Text = "";
        txtBanners.Text = "";
        hdnfileupload_arabic.Value = "";
        hdnfileupload_english.Value = "";
    }
    //protected void lbtnDelete_Click(object sender, EventArgs e)
    //{
    //    if (Request.Cookies["csrf"] == null || Request.Cookies["csrf"].ToString().Trim() == "")
    //    {
    //        Response.Redirect("Default.aspx");
    //    }
    //    else
    //    {

    //        cultureCookie = Request.Cookies["csrf"];
    //        string csrt = cultureCookie.Value;
    //        amain master = (amain)this.Master;
    //        Label lcsrt = (Label)master.FindControl("lblhcsrf");
    //        string hcsrt = lcsrt.Text.Trim();
    //        if (csrt == hcsrt)
    //        {
    //            HomeBanners_Mob banner = new HomeBanners_Mob();
    //            int bannerid = string.IsNullOrEmpty(lblcid.Text) ? 0 : Convert.ToInt32(lblcid.Text);
    //            banner.Type = "Delete";
    //            robj.PostHomeBanners(banner);
    //            lbler.Text = "Contents has been deleted";
    //        }
    //        else
    //        {
    //            Response.Redirect("Default.aspx");
    //        }
    //    }
    //}

    private void GenerateThumbnails(Stream sourcePath, string targetPath)
    {
        using (var image = System.Drawing.Image.FromStream(sourcePath))
        {
            //var newWidth = (int)(image.Width * scaleFactor);
            //var newHeight = (int)(image.Height * scaleFactor);
            var newWidth = (int)(image.Width);
            var newHeight = (int)(image.Height);
            if (newWidth > 2000)
            {
                newWidth = (newWidth * 50) / 100;
                newHeight = (newHeight * 50) / 100;
            }
            if (newHeight > 2000)
            {
                newWidth = (newWidth * 50) / 100;
                newHeight = (newHeight * 50) / 100;
            }
            if (newWidth > 1500)
            {
                newWidth = (newWidth * 50) / 100;
                newHeight = (newHeight * 50) / 100;
            }
            if (newHeight > 1500)
            {
                newWidth = (newWidth * 50) / 100;
                newHeight = (newHeight * 50) / 100;
            }



            var thumbnailImg = new Bitmap(newWidth, newHeight);
            var thumbGraph = Graphics.FromImage(thumbnailImg);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);
            thumbnailImg.Save(targetPath, image.RawFormat);
        }
    }


    public string lbtnUpload_Image_English()
    {
        string ContentId = lblcid.Text.Trim();
        string Dimage = rbtnDImage.SelectedValue.ToString().Trim();
        string furl1 = "";
        if (fufd.HasFile == true)
        {
            string a = cobj.GetID("Files");
            string filename = Path.GetFileName(fufd.PostedFile.FileName);
            furl1 = furl + ContentId + "-" + a + "-" + filename;
            string ext = Path.GetExtension(fufd.PostedFile.FileName);
            if (ext.ToLower() == ".jpg" || ext.ToLower() == ".png" || ext.ToLower() == ".gif" || ext.ToLower() == ".jpeg")
            {

                string targetPath = Server.MapPath(furl1);
                Stream strm = fufd.PostedFile.InputStream;
                var targetFile = targetPath;
                GenerateThumbnails(strm, targetFile);
                //CIMages pobj = new CIMages();
                //pobj.CType = "insert";
                //pobj.ContentId = ContentId;
                //pobj.FileId = a;
                //pobj.ImageUrl = furl1;
                //pobj.DefaultImage = Dimage;

                return furl1;

            }
            else if (ext.ToLower() == ".pdf" || ext.ToLower() == ".ppt" || ext.ToLower() == ".pptx" || ext.ToLower() == ".doc" || ext.ToLower() == ".docx" || ext.ToLower() == ".xls" || ext.ToLower() == ".xlsx")
            {
                fufd.SaveAs(Server.MapPath(furl1));
                return furl1;
            }

        }
        else
        {
            lblImage.Text = "Invalid Format";

        }

        return furl1;
    }

    public string lbtnUpload_Image_Arabic()
    {
        string ContentId = lblcid.Text.Trim();
        string Dimage = rbtnDImage.SelectedValue.ToString().Trim();
        string furl1 = "";
        if (FileUpload1.HasFile == true)
        {
            string a = cobj.GetID("Files");
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            furl1 = furl + ContentId + "-" + a + "-" + filename;
            string ext = Path.GetExtension(FileUpload1.PostedFile.FileName);
            if (ext.ToLower() == ".jpg" || ext.ToLower() == ".png" || ext.ToLower() == ".gif" || ext.ToLower() == ".jpeg")
            {

                string targetPath = Server.MapPath(furl1);
                Stream strm = FileUpload1.PostedFile.InputStream;
                var targetFile = targetPath;
                GenerateThumbnails(strm, targetFile);
                //CIMages pobj = new CIMages();
                //pobj.CType = "insert";
                //pobj.ContentId = ContentId;
                //pobj.FileId = a;
                //pobj.ImageUrl = furl1;
                //pobj.DefaultImage = Dimage;

                return furl1;

            }
            else if (ext.ToLower() == ".pdf" || ext.ToLower() == ".ppt" || ext.ToLower() == ".pptx" || ext.ToLower() == ".doc" || ext.ToLower() == ".docx" || ext.ToLower() == ".xls" || ext.ToLower() == ".xlsx")
            {
                fufd.SaveAs(Server.MapPath(furl1));
                return furl1;
            }

        }
        else
        {
            lblImage.Text = "Invalid Format";

        }

        return furl1;
    }

    protected void lbtnDeleteImage_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            string sid = (row.FindControl("lblveid") as Label).Text.Trim();
            CIMages pobj = new CIMages();
            pobj.CType = "delete";
            pobj.FileId = sid;
            cobj.ProcCImages(pobj);

        }
    }






    #region grid view
    //grid view
    public override void VerifyRenderingInServerForm(Control control)
    {

    }
    protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv.PageIndex = e.NewPageIndex;

    }


    protected void gv_Sorting(object sender, GridViewSortEventArgs e)
    {
        dtImages.DefaultView.Sort = e.SortExpression + " " + SortDir(e.SortExpression);
        gv.DataSource = dtImages;
        gv.DataBind();
    }

    private string SortDir(string sField)
    {
        string sDir = "asc";
        string sPrevField = (ViewState["SortField"] != null ? ViewState["SortField"].ToString() : "");
        if (sPrevField == sField)
            sDir = (ViewState["SortDir"].ToString() == "asc" ? "desc" : "asc");
        else
            ViewState["SortField"] = sField;

        ViewState["SortDir"] = sDir;
        return sDir;
    }
    #endregion grid view


    protected void lbtnUpdateDefault_Click(object sender, EventArgs e)
    {
        using (GridViewRow row = (GridViewRow)((LinkButton)sender).Parent.Parent)
        {
            string sid = (row.FindControl("lblveid") as Label).Text.Trim();
            string furl1 = (row.FindControl("lblIURL") as Label).Text.Trim();
            string d = (row.FindControl("rbtnDImage") as RadioButtonList).SelectedValue.ToString().Trim();
            if (d == "Yes")
            {
                Contents pobj1 = new Contents();
                pobj1.CType = "updatedefaultimage";
                pobj1.ContentId = lblcid.Text.Trim();
                pobj1.DImage = furl1;
                cobj.ProcContents(pobj1);

            }
            CIMages pobj = new CIMages();
            pobj.CType = "updatedefault";
            pobj.FileId = sid;
            pobj.DefaultImage = d;
            cobj.ProcCImages(pobj);

        }
    }

    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            RadioButtonList ddlST = (RadioButtonList)e.Row.FindControl("rbtnDImage");
            Label lbld = (Label)e.Row.FindControl("lblDefault");
            if (lbld.Text.Trim() != "")
            {
                ddlST.Text = lbld.Text.Trim();
            }

        }
    }


}