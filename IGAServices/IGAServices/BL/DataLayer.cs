
using IGA.Common;
using IGAServices.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGA.Web.API.BL
{
    public class DataLayer
    {


        public Agenda FetchAgendaDetails()
        {
            try
            {
                SqlParameter[] para = new SqlParameter[] {
                };

                DataSet catds = IGASQL.eds("sp_Mobile_FetchAgenda", para);
                DataTable typedt = catds.Tables[0];
                DataTable catdt = catds.Tables[1];
                DataTable contentsdt = catds.Tables[2];
                string EnglishMenu = string.Empty;
                string ArabicMenu = string.Empty;
                foreach (DataRow dr in typedt.Rows)
                {

                    EnglishMenu = Convert.ToString(dr["TypesName"]);
                    ArabicMenu = Convert.ToString(dr["TypesName1"]);
                   
                }
                List<Category> catlist = new List<Category>();
                foreach (DataRow dr in catdt.Rows)
                {
                    Category cat = new Category();
                    cat.CategoryID = Convert.ToString(dr["CategoryId"]);
                    cat.TypeID = Convert.ToString(dr["TypesId"]);
                    cat.EnglishCategoryName = Convert.ToString(dr["CategoryName"]);
                    cat.ArabicCategoryName = Convert.ToString(dr["CategoryName1"]);
                    cat.EnglishMenuType = Convert.ToString(dr["TypesName"]);
                    cat.ArabicMenuType = Convert.ToString(dr["TypesName1"]);
                    cat.ArabicMenuType = Convert.ToString(dr["TypesName1"]);
                    cat.CreatedDate = dr.IsNull("CreatedDate") ? "" : CovertToLocalFormat(Convert.ToDateTime(dr["CreatedDate"]));

                    catlist.Add(cat);
                }

                List<Contents> contentlist = new List<Contents>();
                foreach (DataRow dr in contentsdt.Rows)
                {
                    Contents content = new Contents();
                    content.ContentID = Convert.ToString(dr["ContentId"]);
                    content.CategoryID = Convert.ToString(dr["CategoryId"]);
                    content.EnglishTitle = Convert.ToString(dr["ContentTitle"]);
                    content.ArabicTitle = Convert.ToString(dr["ContentTitle1"]);
                    content.EnglishContent = Convert.ToString(dr["ShortContent"]);
                    content.ArabicContent = Convert.ToString(dr["ShortContent1"]);
                    content.EnglishContentDetail = Convert.ToString(dr["ContentDetail"]);
                    content.ArabicContentDetail = Convert.ToString(dr["ContentDetail1"]);
                    content.EnglishPeroid = Convert.ToString(dr["ADetail"]);
                    content.ArabicPeroid = Convert.ToString(dr["ADetail1"]);
                    content.EnglishImage = string.IsNullOrEmpty(Convert.ToString(dr["DImage"])) ? "" : CommonUtility.EGovUrl + Convert.ToString(dr["DImage"]);
                    content.ArabicImage = string.IsNullOrEmpty(Convert.ToString(dr["DImage1"])) ? "" : CommonUtility.EGovUrl + Convert.ToString(dr["DImage1"]);
                    content.CreatedDate = dr.IsNull("CreatedDate") ? "" : CovertToLocalFormat(Convert.ToDateTime(dr["CreatedDate"]));
                
                    contentlist.Add(content);
                }
                return new Agenda {EnglishMenuName=EnglishMenu,ArabicMenuName=ArabicMenu, CategoryList = catlist,ContentList=contentlist, IsTransactionDone = true };

            }
            catch (Exception ex)
            {
                return new Agenda { TransactionErrorMessage = ex.Message, IsTransactionDone = false };
            }
        }   


        public HomeBannersResponse FetchHomeBanner()
        {
            try
            {
                SqlParameter[] para = new SqlParameter[] {
                };

                DataTable bannerdt = IGASQL.edt("sp_FetchHomeBanners_Mob", para);
                List<HomeBanners> bannerlist = new List<HomeBanners>();
                foreach(DataRow dr in bannerdt.Rows)
                {
                    HomeBanners banner = new HomeBanners();
                    banner.HomeBannerID = Convert.ToInt32(dr["HomeBannerID"]);
                    banner.Title_Arabic = Convert.ToString(dr["Title_English"]);
                    banner.Title_English = Convert.ToString(dr["Title_Arabic"]);
                    banner.ShortDesc_Arabic = Convert.ToString(dr["ShortDesc_English"]);
                    banner.ShortDesc_English = Convert.ToString(dr["ShortDesc_Arabic"]);
                    banner.ContentDetail_Arabic = Convert.ToString(dr["ContentDetail_English"]);
                    banner.ContentDetail_English = Convert.ToString(dr["ContentDetail_Arabic"]);
                    banner.ImageURL_Arabic = !string.IsNullOrEmpty(Convert.ToString(dr["ImageUrl_Arabic"])) ? CommonUtility.EGovUrl + Convert.ToString(dr["ImageUrl_Arabic"]) : "";
                    banner.ImageURL_English = !string.IsNullOrEmpty(Convert.ToString(dr["ImageUrl_English"])) ? CommonUtility.EGovUrl + Convert.ToString(dr["ImageUrl_English"]) : ""; 
                    banner.CreatedDate = Convert.ToDateTime(dr["CreatedDate"]);


                    bannerlist.Add(banner);
                }

                return new HomeBannersResponse { HomeBannersList = bannerlist, IsTransactionDone = true };
            }
            catch(Exception ex)
            {
                return new HomeBannersResponse { IsTransactionDone = false, TransactionErrorMessage = ex.Message };
            }
        }


        public SponsorTypeResponse GetSponsorTypes(string typeID)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[] {
                  new SqlParameter("@TypeId", typeID),
            };
                DataTable sponsordt = IGASQL.edt("SP_GetTypeByTypeID_Mob", para);
                List<SponsorType> sponsorlist = new List<SponsorType>();
                foreach (DataRow dr in sponsordt.Rows)
                {
                    SponsorType sponsorType = new SponsorType();
                    sponsorType.Name_Arabic = Convert.ToString(dr["CategoryName1"]);
                    sponsorType.Name_English = Convert.ToString(dr["CategoryName"]);
                    sponsorType.CategoryID = Convert.ToString(dr["CategoryID"]);

                    sponsorlist.Add(sponsorType);
                }
                return new SponsorTypeResponse
                {
                    SponsorTypes = sponsorlist,
                    IsTransactionDone = true
                };
            }
            catch(Exception ex)
            {
                return new SponsorTypeResponse
                {                    
                    IsTransactionDone = false,
                    TransactionErrorMessage = ex.Message
                };
            }
           
        }


        public SponsorResponse GetSponsor(string typeID, string CategoryID)
        {
            try
            {
                SqlParameter[] para = new SqlParameter[] {
                  new SqlParameter("@TypeId", typeID),
                  new SqlParameter("@CategoryID", CategoryID),
            };
                DataTable sponsordt = IGASQL.edt("SP_GetTypeByTypeIDByCategoryID_Mob", para);
                List<Sponsor> sponsors = new List<Sponsor>();
                foreach (DataRow dr in sponsordt.Rows)
                {
                    Sponsor sponsor = new Sponsor();
                    sponsor.Image = Convert.ToString(dr["DImage"]);
                    sponsor.Detail = Convert.ToString(dr["ADetail"]);                

                    sponsors.Add(sponsor);
                }
                return new SponsorResponse
                {
                    Sponsors = sponsors,
                    IsTransactionDone = true
                };
            }
            catch (Exception ex)
            {
                return new SponsorResponse
                {
                    IsTransactionDone = false,
                    TransactionErrorMessage = ex.Message
                };
            }

        }


        public  string CovertToLocalFormat(DateTime value)
        {
            return value.ToString("dd/MM/yyyy hh:mm:ss");
           
        }
    }
}

