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

public partial class AContentsEdit : System.Web.UI.Page
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
        if(!IsPostBack)
        {
            if(Request.QueryString["c"]!=null)
            {
                lblcid.Text =cobj.Decrypt(Request.QueryString["c"].ToString().Trim());
                LoadTypes();
                LoadTypes();
                LoadCategory();
                LoadSubCategory();
                LoadSCategorySub();
                LoadContents();
                LoadImages();
            }
           
        }
    }
    public void LoadTypes()
    {
        Types sobj = new Types();
        sobj.CType = "sall";
        dtTypes = cobj.GetTypes(sobj);
        ddlTypes.Items.Clear();
        ddlTypes.DataSource = dtTypes;
        ddlTypes.DataValueField = "TypesId";
        ddlTypes.DataTextField = "TypesName";
        ddlTypes.Items.Insert(0, new ListItem("", ""));
        ddlTypes.DataBind();
    }
    public void LoadCategory()
    {
        string a = ddlTypes.SelectedValue.ToString().Trim();
        Category sobj = new Category();
        sobj.CType = "sbytype";
        sobj.TypesId = a;
        dtCategory = cobj.GetCategory(sobj);
        ddlCategory.Items.Clear();
        ddlCategory.DataSource = dtCategory;
        ddlCategory.DataValueField = "CategoryId";
        ddlCategory.DataTextField = "CategoryName";
        ddlCategory.Items.Insert(0, new ListItem("", ""));
        ddlCategory.DataBind();
        //LoadSubCategory();
    }

    public void LoadSubCategory()
    {
        string a = ddlCategory.SelectedValue.ToString().Trim();
        SubCategory sobj = new SubCategory();
        sobj.CType = "sbycat";
        sobj.CategoryId = a;
        dtSubCategory = cobj.GetSubCategory(sobj);
        ddlSubCategory.Items.Clear();
        ddlSubCategory.DataSource = dtSubCategory;
        ddlSubCategory.DataValueField = "SubCategoryId";
        ddlSubCategory.DataTextField = "SubCategoryName";
        ddlSubCategory.Items.Insert(0, new ListItem("", ""));
        ddlSubCategory.DataBind();
      //  LoadSCategorySub();
    }
    public void LoadSCategorySub()
    {
        string a = ddlSubCategory.SelectedValue.ToString().Trim();
        SCategorySub sobj = new SCategorySub();
        sobj.CType = "sbysubcat";
        sobj.SubCategoryId = a;
        dtSCategorySub = cobj.GetSCategorySub(sobj);
        ddlSCategorySub.Items.Clear();
        ddlSCategorySub.DataSource = dtSCategorySub;
        ddlSCategorySub.DataValueField = "SubCategoryId";
        ddlSCategorySub.DataTextField = "SubCategoryName";
        ddlSCategorySub.Items.Insert(0, new ListItem("", ""));
        ddlSCategorySub.DataBind();
       // LoadContents();
    }
    protected void ddlTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadCategory();
        LoadSubCategory();
        LoadSCategorySub();
        //LoadContents();
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSubCategory();
        LoadSCategorySub();
        //LoadContents();
    }
    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadSCategorySub();
        LoadSCategorySub();
       // LoadContents();
    }
    protected void ddlSCategorySub_SelectedIndexChanged(object sender, EventArgs e)
    {
        //LoadContents();
    }

    public void LoadContents()
    {
        Contents pobj = new Contents();
        pobj.CType = "sone";
        pobj.ContentId = lblcid.Text.Trim();
        dtContents = cobj.GetContents(pobj);
        if(dtContents.Rows.Count>0)
        {
            txtTitle.Text = dtContents.Rows[0]["ContentTitle"].ToString().Trim();
            txtTitle1.Text = dtContents.Rows[0]["ContentTitle1"].ToString().Trim();
            txtShort.Text = dtContents.Rows[0]["ShortContent"].ToString().Trim();
            txtShort1.Text = dtContents.Rows[0]["ShortContent1"].ToString().Trim();
            txtMDetail.Text = dtContents.Rows[0]["ADetail"].ToString().Trim();
            txtMDetail1.Text = dtContents.Rows[0]["ADetail1"].ToString().Trim();
            txtMDetail2.Text = dtContents.Rows[0]["BDetail"].ToString().Trim();
            txtMDetail21.Text = dtContents.Rows[0]["BDetail1"].ToString().Trim();
            txtPTitle.Text = dtContents.Rows[0]["PageTitle"].ToString().Trim();
            txtPTitle1.Text = dtContents.Rows[0]["PageTitle1"].ToString().Trim();
            txtPKey.Text = dtContents.Rows[0]["PageKey"].ToString().Trim();
            txtPKey1.Text = dtContents.Rows[0]["PageKey1"].ToString().Trim();
            txtPDes.Text = dtContents.Rows[0]["PageDes"].ToString().Trim();
            txtPDes1.Text = dtContents.Rows[0]["PageDes1"].ToString().Trim();
            txtCDet.Text = dtContents.Rows[0]["CDetail"].ToString().Trim();
            txtCDet1.Text = dtContents.Rows[0]["CDetail1"].ToString().Trim();
            string tp = dtContents.Rows[0]["Price"].ToString().Trim();
            if(tp!="")
            {
                txtPrice.Text = tp;
            }
            else
            {
                txtPrice.Text = "0";
            }
            
            lbld.Text = dtContents.Rows[0]["DImage"].ToString().Trim();
            ftDet.Text = dtContents.Rows[0]["ContentDetail"].ToString().Trim();
            ftDet1.Text = dtContents.Rows[0]["ContentDetail1"].ToString().Trim();

            string TypesId= dtContents.Rows[0]["TypesId"].ToString().Trim();
            if(TypesId!="")
            {
                ddlTypes.Text = TypesId;
                LoadCategory();
                LoadSubCategory();
                LoadSCategorySub();

            }
            string CategoryId = dtContents.Rows[0]["CategoryId"].ToString().Trim();
            if (CategoryId != "")
            {
                ddlCategory.Text = CategoryId;
                LoadSubCategory();
                LoadSCategorySub();
            }
            string SubCategoryId = dtContents.Rows[0]["SubCategoryId"].ToString().Trim();
            if (SubCategoryId != "")
            {
                ddlSubCategory.Text = SubCategoryId;
                LoadSCategorySub();
            }
            string SCategorySubId = dtContents.Rows[0]["SCategorySubId"].ToString().Trim();
            if (SCategorySubId != "")
            {
                ddlSCategorySub.Text = SCategorySubId;
            }

            string ContentStatus = dtContents.Rows[0]["ContentStatus"].ToString().Trim();
            if (ContentStatus != "")
            {
                rbtnStatus.Text = ContentStatus;
            }
            string ContentType = dtContents.Rows[0]["ContentType"].ToString().Trim();
            if (ContentType != "")
            {
                rbtnCType.Text = ContentType;
            }
            string Hpage = dtContents.Rows[0]["HPage"].ToString().Trim();
            if (Hpage != "")
            {
                rbtnSetting.Text = Hpage;
            }
            string Hpage1 = dtContents.Rows[0]["HPage1"].ToString().Trim();
            if (Hpage1 != "")
            {
                rbtnSetting1.Text = Hpage1;
            }
            string h = dtContents.Rows[0]["PublishDate"].ToString().Trim();
            if (h != "")
            {
                dpstart.CalendarDate = Convert.ToDateTime(h);
            }
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
            amain master = (amain)this.Master;
            Label lcsrt = (Label)master.FindControl("lblhcsrf");
            string hcsrt = lcsrt.Text.Trim();
            if (csrt == hcsrt)
            {
                string ContentId = lblcid.Text.Trim();
                string CTitle = txtTitle.Text.Trim();
                string CTitle1 = txtTitle1.Text.Trim();
                string TypesId = ddlTypes.SelectedValue.ToString().Trim();
                string CatId = ddlCategory.SelectedValue.ToString().Trim();
                string SCatId = ddlSubCategory.SelectedValue.ToString().Trim();
                string SCatsId = ddlSCategorySub.SelectedValue.ToString().Trim();
                string SCont = txtShort.Text.Trim();
                string SCont1 = txtShort1.Text.Trim();
                string MDetail = txtMDetail.Text.Trim();
                string MDetail1 = txtMDetail1.Text.Trim();
                string MDetail2 = txtMDetail2.Text.Trim();
                string MDetail21 = txtMDetail21.Text.Trim();
                string CDetail = txtCDet.Text.Trim();
                string CDetail1 = txtCDet1.Text.Trim();
                string Price = txtPrice.Text.Trim();
                string CStat = rbtnStatus.SelectedValue.ToString().Trim();
                string CType = rbtnCType.SelectedValue.ToString().Trim();
                string Det = ftDet.Text.Trim();
                string Det1 = ftDet1.Text.Trim();
                string Ptitle = txtPTitle.Text.Trim();
                string Ptitle1 = txtPTitle1.Text.Trim();
                string Pkey = txtPKey.Text.Trim();
                string Pkey1 = txtPKey1.Text.Trim();
                string PDes = txtPDes.Text.Trim();
                string PDes1 = txtPDes1.Text.Trim();
                string HPage = rbtnSetting.SelectedValue.ToString().Trim();
                string HPage1 = rbtnSetting1.SelectedValue.ToString().Trim();
                string furl1 = "";
                if (fuf.HasFile == true)
                {
                    string a = cobj.GetID("Files");
                    string filename = Path.GetFileName(fuf.PostedFile.FileName);
                    furl1 = furl +ContentId+"-"+ a + "-" + filename;
                    string ext = Path.GetExtension(fuf.PostedFile.FileName);
                    if (ext.ToLower() == ".jpg" || ext.ToLower() == ".png" || ext.ToLower() == ".gif" || ext.ToLower() == ".jpeg")
                    {
                       
                            string targetPath = Server.MapPath(furl1);
                            Stream strm = fuf.PostedFile.InputStream;
                            var targetFile = targetPath;
                            GenerateThumbnails(strm, targetFile);
                        
                    }
                    else
                    {
                        lblImage.Text = "Invalid Format";
                    }


                }
                else
                {
                    furl1 = lbld.Text.Trim();
                }





                Contents pobj = new Contents();
                pobj.CType = "update";
                pobj.ContentId = ContentId;
                pobj.TypesId = TypesId;
                pobj.CategoryId = CatId;
                pobj.SubCategoryId = SCatId;
                pobj.SCategorySubId = SCatsId;
                pobj.ContentTitle = CTitle;
                pobj.ContentTitle1 = CTitle1;
                pobj.ShortContent = SCont;
                pobj.ShortContent1 = SCont1;
                pobj.ADetail = MDetail;
                pobj.ADetail1 = MDetail1;
                pobj.BDetail = MDetail2;
                pobj.BDetail1 = MDetail21;
                pobj.CDetail = CDetail;
                pobj.CDetail1 = CDetail1;
                pobj.ContentStatus = CStat;
                pobj.ContentType = CType;
                pobj.ContentDetail = Det;
                pobj.ContentDetail1 = Det1;
                pobj.DImage = furl1;
                pobj.Price = Price;
                pobj.PageTitle = Ptitle;
                pobj.PageTitle1 = Ptitle1;
                pobj.PageKey = Pkey;
                pobj.PageKey1 = Pkey1;
                pobj.PageDes = PDes;
                pobj.PageDes1 = PDes1;
                pobj.HPage = HPage;
                pobj.HPage1 = HPage1;
                cobj.ProcContents(pobj);



                string l = "";
                string l1 = dpstart.CalendarDateString.Trim();
                if (l1 != "")
                {
                    l = String.Format("{0:yyyy-MM-dd}", dpstart.CalendarDate);
                }

                robj.ProcPdate(ContentId, l);

                lbler.Text = "Contents has been updated";
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    protected void lbtnDelete_Click(object sender, EventArgs e)
    {
        if (Request.Cookies["csrf"] == null || Request.Cookies["csrf"].ToString().Trim() == "")
        {
            Response.Redirect("Default.aspx");
        }
        else
        {

            cultureCookie = Request.Cookies["csrf"];
            string csrt = cultureCookie.Value;
            amain master = (amain)this.Master;
            Label lcsrt = (Label)master.FindControl("lblhcsrf");
            string hcsrt = lcsrt.Text.Trim();
            if (csrt == hcsrt)
            {
                string ContentId = lblcid.Text.Trim();
                Contents pobj = new Contents();
                pobj.CType = "delete";
                pobj.ContentId = ContentId;
                cobj.ProcContents(pobj);
                lbler.Text = "Contents has been deleted";
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

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


    protected void lbtnUpload_Click(object sender, EventArgs e)
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
               CIMages pobj = new CIMages();
                pobj.CType = "insert";
                pobj.ContentId = ContentId;
                pobj.FileId = a;
                pobj.ImageUrl = furl1;
                pobj.DefaultImage = Dimage;
                cobj.ProcCImages(pobj);
                if (Dimage == "Yes")
                {
                    Contents pobj1 = new Contents();
                    pobj1.CType = "updatedefaultimage";
                    pobj1.ContentId = ContentId;
                    pobj1.DImage = furl1;
                    cobj.ProcContents(pobj1);
                }
                LoadImages();
                
            }
            else if(ext.ToLower() == ".pdf" || ext.ToLower() == ".ppt" || ext.ToLower() == ".pptx" || ext.ToLower() == ".doc" || ext.ToLower() == ".docx" || ext.ToLower() == ".xls" || ext.ToLower() == ".xlsx")
            {
                fufd.SaveAs(Server.MapPath(furl1));
                CIMages pobj = new CIMages();
                pobj.CType = "insert";
                pobj.ContentId = ContentId;
                pobj.FileId = a;
                pobj.ImageUrl = furl1;
                pobj.DefaultImage = Dimage;
                cobj.ProcCImages(pobj);
                if (Dimage == "Yes")
                {
                    Contents pobj1 = new Contents();
                    pobj1.CType = "updatedefaultimage";
                    pobj1.ContentId = ContentId;
                    pobj1.DImage = furl1;
                    cobj.ProcContents(pobj1);
                }
                LoadImages();
            }
            else
            {
                lblcier.Text = "Invalid Format";
            }


        }
        
    }

    public void LoadImages()
    {
        string ContentId = lblcid.Text.Trim();
        CIMages pobj = new CIMages();
        pobj.CType = "sbytype";
        pobj.ContentId = ContentId;
        dtImages = cobj.GetCImages(pobj);
        gv.DataSource = dtImages;
        gv.DataBind();
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
            LoadImages();
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
        LoadImages(); //bindgridview will get the data source and bind it again
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
            LoadImages();
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