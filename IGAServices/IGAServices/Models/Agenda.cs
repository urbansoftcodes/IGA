using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IGAServices.Models
{
    public class Category
    {
        [JsonProperty(PropertyName = "categoryID")]
        public string CategoryID { get; set; }

        [JsonProperty(PropertyName = "typeID")]
        public string TypeID { get; set; }

        [JsonProperty(PropertyName = "englishCategoryName")]
        public string EnglishCategoryName { get; set; }

        [JsonProperty(PropertyName = "arabicCategoryName")]
        public string ArabicCategoryName { get; set; }

        [JsonProperty(PropertyName = "englishMenuType")]
        public string EnglishMenuType { get; set; }

        [JsonProperty(PropertyName = "arabicMenuType")]
        public string ArabicMenuType { get; set; }

        [JsonProperty(PropertyName = "createdDate")]
        public string CreatedDate { get; set; }
    }

    public class Contents
    {
        [JsonProperty(PropertyName = "contentID")]
        public string ContentID { get; set; }
        [JsonProperty(PropertyName = "categoryID")]
        public string CategoryID { get; set; }

        [JsonProperty(PropertyName = "englishTitle")]
        public string EnglishTitle { get; set; }

        [JsonProperty(PropertyName = "arabicTitle")]
        public string ArabicTitle { get; set; }

        [JsonProperty(PropertyName = "englishContent")]
        public string EnglishContent { get; set; }
        [JsonProperty(PropertyName = "arabicContent")]
        public string ArabicContent { get; set; }
        [JsonProperty(PropertyName = "englishContentDetail")]
        public string EnglishContentDetail { get; set; }
        [JsonProperty(PropertyName = "arabicContentDetail")]
        public string ArabicContentDetail { get; set; }
        [JsonProperty(PropertyName = "englishPeroid")]
        public string EnglishPeroid { get; set; }

        [JsonProperty(PropertyName = "arabicPeroid")]
        public string ArabicPeroid { get; set; }
        [JsonProperty(PropertyName = "englishImage")]
        public string EnglishImage { get; set; }
        [JsonProperty(PropertyName = "arabicImage")]
        public string ArabicImage { get; set; }
        [JsonProperty(PropertyName = "createdDate")]
        public string CreatedDate { get; set; }

    }
    public class Agenda : TransactionWrapper
    {
        [JsonProperty(PropertyName = "englishMenuName")]
        public string EnglishMenuName { get; set; }

        [JsonProperty(PropertyName = "arabicMenuName")]
        public string ArabicMenuName { get; set; }
        public List<Category> CategoryList { get; set; }
        public List<Contents> ContentList { get; set; }

        public Agenda()
        {
            CategoryList = new List<Category>();
            ContentList = new List<Contents>();
        }
    }


    public class HomeBanners
    {
        [JsonProperty(PropertyName = "homeBannerID")]
        public int HomeBannerID { get; set; }

        [JsonProperty(PropertyName = "title_English")]
        public string Title_English { get; set; }

        [JsonProperty(PropertyName = "title_Arabic")]
        public string Title_Arabic { get; set; }

        [JsonProperty(PropertyName = "shortDesc_English")]
        public string ShortDesc_English { get; set; }

        [JsonProperty(PropertyName = "shortDesc_Arabic")]
        public string ShortDesc_Arabic { get; set; }

        [JsonProperty(PropertyName = "contentDetail_English")]
        public string ContentDetail_English { get; set; }

        [JsonProperty(PropertyName = "contentDetail_Arabic")]
        public string ContentDetail_Arabic { get; set; }

        [JsonProperty(PropertyName = "imageURL_English")]
        public string ImageURL_English { get; set; }

        [JsonProperty(PropertyName = "imageURL_Arabic")]
        public string ImageURL_Arabic { get; set; }

        [JsonProperty(PropertyName = "createdDate")]
        public DateTime CreatedDate { get; set; }
    }


    public class HomeBannersResponse:TransactionWrapper
    {
        [JsonProperty(PropertyName = "homeBannersList")]
        public List<HomeBanners> HomeBannersList { get; set; }
        public HomeBannersResponse()
        {
            HomeBannersList = new List<HomeBanners>();
        }
    }

    public class SponsorType
    {
        public string Name_English { get; set; }

        public string Name_Arabic { get; set; }

        public string CategoryID { get; set; }
    }

    public class SponsorTypeResponse : TransactionWrapper
    {
        [JsonProperty(PropertyName = "sponsortypes")]
        public List<SponsorType> SponsorTypes { get; set; }
        public SponsorTypeResponse()
        {
            SponsorTypes = new List<SponsorType>();
        }
    }



    public class Sponsor
    {
        public string Image { get; set; }
        public string Detail { get; set; }       
    }

    public class SponsorResponse : TransactionWrapper
    {
        [JsonProperty(PropertyName = "sponsors")]
        public List<Sponsor> Sponsors { get; set; }
        public SponsorResponse()
        {
            Sponsors = new List<Sponsor>();
        }
    }
}