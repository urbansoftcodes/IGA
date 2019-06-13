using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using ADAL;
using ABLL;
/// <summary>
/// Summary description for Class1
/// </summary>
public class RDAL
{
    ADAL.ASQL obj = new ADAL.ASQL();
    public RDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public void ProcPdate(string a,string b)
    {
        SqlParameter[] paras = new SqlParameter[]
        {
                new SqlParameter("@ContentId",a),
                new SqlParameter("@pdate",b),
               


        };
        obj.ProcessRequest("sp_contentspub", paras);
    }

    public DataTable GetPub4(string a)
    {
        SqlParameter[] paras = new SqlParameter[]
        {
              new SqlParameter("@TypesId",a),
                
        };
        DataTable dt = obj.GetDataTable("sp_getcontentspub4", paras);
        return dt;

    }
    public DataSet GetPub(string a)
    {
        SqlParameter[] paras = new SqlParameter[]
        {
              new SqlParameter("@TypesId",a),
               

        };
        DataSet dt = obj.GetDataset("sp_getcontentspub", paras);
        return dt;

    }

    #region Contents

    public void ProcRegsc(Regsc pobj)
    {
        SqlParameter[] paras = new SqlParameter[]
        {
                new SqlParameter("@CType",pobj.CType),
                new SqlParameter("@RegId",pobj.RegId),
                new SqlParameter("@NTitle",pobj.NTitle),
                new SqlParameter("@FName",pobj.FName),
                 new SqlParameter("@MName",pobj.MName),
                new SqlParameter("@FaName",pobj.FaName),
                 new SqlParameter("@RPosition",pobj.RPosition),
                  new SqlParameter("@Orgn",pobj.Orgn),
                  new SqlParameter("@Country",pobj.Country),
                new SqlParameter("@Address",pobj.Address),
                new SqlParameter("@Dept",pobj.Dept),
                new SqlParameter("@State",pobj.State),
                 new SqlParameter("@City",pobj.City),
               new SqlParameter("@POBox",pobj.POBox),
                  new SqlParameter("@MCountry",pobj.MCountry),
                  new SqlParameter("@MCode",pobj.MCode),
                new SqlParameter("@MNo",pobj.MNo),
                new SqlParameter("@OCountry",pobj.OCountry),
                 new SqlParameter("@OCode",pobj.OCode),
                new SqlParameter("@ONo",pobj.ONo),
                 new SqlParameter("@FCountry",pobj.FCountry),
                  new SqlParameter("@FCode",pobj.FCode),
                  new SqlParameter("@FNo",pobj.FNo),
                new SqlParameter("@EMailId",pobj.EMailId),
                new SqlParameter("@RFees",pobj.RFees),
                 new SqlParameter("@RPay",pobj.RPay),
                 

        };
        obj.ProcessRequest("sp_regs", paras);
    }

    public DataTable GetRegsc(Regsc pobj)
    {
        SqlParameter[] paras = new SqlParameter[]
        {
              new SqlParameter("@CType",pobj.CType),
                new SqlParameter("@RegId",pobj.RegId),
                new SqlParameter("@NTitle",pobj.NTitle),
                new SqlParameter("@FName",pobj.FName),
                 new SqlParameter("@MName",pobj.MName),
                new SqlParameter("@FaName",pobj.FaName),
                 new SqlParameter("@RPosition",pobj.RPosition),
                  new SqlParameter("@Orgn",pobj.Orgn),
                  new SqlParameter("@Country",pobj.Country),
                new SqlParameter("@Address",pobj.Address),
                new SqlParameter("@Dept",pobj.Dept),
                new SqlParameter("@State",pobj.State),
                 new SqlParameter("@City",pobj.City),
               new SqlParameter("@POBox",pobj.POBox),
                  new SqlParameter("@MCountry",pobj.MCountry),
                  new SqlParameter("@MCode",pobj.MCode),
                new SqlParameter("@MNo",pobj.MNo),
                new SqlParameter("@OCountry",pobj.OCountry),
                 new SqlParameter("@OCode",pobj.OCode),
                new SqlParameter("@ONo",pobj.ONo),
                 new SqlParameter("@FCountry",pobj.FCountry),
                  new SqlParameter("@FCode",pobj.FCode),
                  new SqlParameter("@FNo",pobj.FNo),
                new SqlParameter("@EMailId",pobj.EMailId),
                new SqlParameter("@RFees",pobj.RFees),
                 new SqlParameter("@RPay",pobj.RPay),
        };
        DataTable dt = obj.GetDataTable("sp_regs", paras);
        return dt;

    }


    public DataSet GetRegscDS(Regsc pobj)
    {
        SqlParameter[] paras = new SqlParameter[]
        {
              new SqlParameter("@CType",pobj.CType),
                new SqlParameter("@RegId",pobj.RegId),
                new SqlParameter("@NTitle",pobj.NTitle),
                new SqlParameter("@FName",pobj.FName),
                 new SqlParameter("@MName",pobj.MName),
                new SqlParameter("@FaName",pobj.FaName),
                 new SqlParameter("@RPosition",pobj.RPosition),
                  new SqlParameter("@Orgn",pobj.Orgn),
                  new SqlParameter("@Country",pobj.Country),
                new SqlParameter("@Address",pobj.Address),
                new SqlParameter("@Dept",pobj.Dept),
                new SqlParameter("@State",pobj.State),
                 new SqlParameter("@City",pobj.City),
               new SqlParameter("@POBox",pobj.POBox),
                  new SqlParameter("@MCountry",pobj.MCountry),
                  new SqlParameter("@MCode",pobj.MCode),
                new SqlParameter("@MNo",pobj.MNo),
                new SqlParameter("@OCountry",pobj.OCountry),
                 new SqlParameter("@OCode",pobj.OCode),
                new SqlParameter("@ONo",pobj.ONo),
                 new SqlParameter("@FCountry",pobj.FCountry),
                  new SqlParameter("@FCode",pobj.FCode),
                  new SqlParameter("@FNo",pobj.FNo),
                new SqlParameter("@EMailId",pobj.EMailId),
                new SqlParameter("@RFees",pobj.RFees),
                 new SqlParameter("@RPay",pobj.RPay),

        };
        DataSet dt = obj.GetDataset("sp_regs", paras);
        return dt;

    }

    #endregion Contents

    public DataTable FetchHomeBanners()
    {
        try
        {
            
            return obj.WGetDataTable("sp_FetchHomeBanners_Mob");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public DataTable FetchHomeBannerByID(int bannerID)
    {
        try
        {
            SqlParameter[] paras = new SqlParameter[]
            {
               new SqlParameter("@HomebannerID",bannerID)
            };
            return obj.GetDataTable("sp_FetchHomeBanneryByID", paras);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void PostHomeBanners(HomeBanners_Mob banner)
    {
        SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter("@HomebannerID",banner.HomeBannerID),
                new SqlParameter("@Title_English",string.IsNullOrEmpty(banner.Title_English)?"":banner.Title_English),
                new SqlParameter("@Title_Arabic",string.IsNullOrEmpty(banner.Title_Arabic)?"":banner.Title_Arabic),
                new SqlParameter("@Shortdesc_English",string.IsNullOrEmpty(banner.ShortDesc_English)?"":banner.ShortDesc_English),
                new SqlParameter("@Shortdesc_Arabic",string.IsNullOrEmpty(banner.ShortDesc_Arabic)?"":banner.ShortDesc_Arabic),
                new SqlParameter("@ContentDetail_English",string.IsNullOrEmpty(banner.ContentDetail_English)?"":banner.ContentDetail_English),
                new SqlParameter("@ContentDetail_Arabic",string.IsNullOrEmpty(banner.ContentDetail_Arabic)?"":banner.ContentDetail_Arabic),
                new SqlParameter("@ImageURL_English",string.IsNullOrEmpty(banner.ImageUrl_English)?"":banner.ImageUrl_English),
                new SqlParameter("@ImageURL_Arabic",string.IsNullOrEmpty(banner.ImageUrl_Arabic)?"":banner.ImageUrl_Arabic),
                new SqlParameter("@BannerOrder",banner.BannerOrder),
                new SqlParameter("@Type",banner.Type)

                 
            };
        obj.ProcessRequest("sp_PostHomeBanner", paras);
    }
        




}
public class HomeBanners_Mob
{
    public int HomeBannerID { get; set; }

    public string Title_English { get; set; }
    public string Title_Arabic { get; set; }

    public string ShortDesc_English { get; set; }
    public string ShortDesc_Arabic { get; set; }

    public string ContentDetail_English { get; set; }

    public string ContentDetail_Arabic { get; set; }

    public string ImageUrl_English { get; set; }

    public string ImageUrl_Arabic { get; set; }

    public string CreatedDate { get; set; }
    public string Type { get; set; }

    public int BannerOrder { get; set; }

}
public class Regsc
{

    public string CType { get; set; }
    public string RegId { get; set; }
    public string NTitle { get; set; }
    public string FName { get; set; }
    public string MName { get; set; }

    public string FaName { get; set; }


    public string RPosition { get; set; }
    public string Orgn { get; set; }
    public string Country { get; set; }
    public string Address { get; set; }
    public string Dept { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string POBox { get; set; }
    public string MCountry { get; set; }
    public string MCode { get; set; }
    public string MNo { get; set; }
    public string OCountry { get; set; }
    public string OCode { get; set; }

    public string ONo { get; set; }
    public string FCountry { get; set; }

    public string FCode { get; set; }
    public string FNo { get; set; }
    public string EMailId { get; set; }
    public string RFees { get; set; }
    public string RPay { get; set; }

   

    public Regsc()
    {

        CType = "";
        RegId = "";
        NTitle = "";
        FName = "";
        MName = "";
        FaName = "";
        RPosition = "";
        Orgn = "";
        Country = "";
        Address = "";
        Dept = "";
        State = "";
        City = "";
        POBox = "";
        MCountry = "";
        MCode = "";
        MNo = "";
        OCountry = "";
        OCode = "";
        ONo = "";
        FCountry = "";
        FCode = "";
        FNo = "";
        EMailId = "";
        RFees = "";
        RPay = "";
       
    }

}