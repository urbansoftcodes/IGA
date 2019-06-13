using IGA.Web.API.BL;
using IGA.WebAPI.OAuth;
using IGAServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IGAServices.Controllers
{
    public class IGAForumController : ApiController
    {
        [HttpGet]
        [Route("api/igaforum/fetchagenda")]
        public Agenda FetchAgenda()
        {
            DataLayer layer = new DataLayer();
            return layer.FetchAgendaDetails();


        }
        [HttpGet]
        [Route("api/igaforum/fetchhomebanner")]
        public HomeBannersResponse FetchHomeBanner()
        {
            DataLayer layer = new DataLayer();
            return layer.FetchHomeBanner();


        }

        [HttpGet]
        [Route("api/igaforum/fetchsponsortypes")]
        public SponsorTypeResponse FetchSponsorTypes()
        {
            string tid = System.Configuration.ConfigurationSettings.AppSettings["sponsors"].ToString().Trim();
            DataLayer layer = new DataLayer();
            return layer.GetSponsorTypes(tid);


        }


        [HttpGet]
        [Route("api/igaforum/fetchsponsors")]
        public SponsorResponse FetchSponsor(string categoryID)
        {
            string tid = System.Configuration.ConfigurationSettings.AppSettings["sponsors"].ToString().Trim();
            DataLayer layer = new DataLayer();
            return layer.GetSponsor(tid, categoryID);


        }

    }
}