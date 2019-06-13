using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;
using System.Net;
using TweetSharp;
public partial class Default2 : System.Web.UI.Page
{
    public static string _consumerKey = "590AfxEghbSMYQUBxoP8TYHUV"; // Your key
    public static string _consumerSecret = "3KkTj2Sx8PrfU21JF4OojPwsj5UVtlWQyTte6q9RBKySHANpyA"; // Your key  
    public static string _accessToken = "1020658962801324032-VcgkSBbtIkeEostz7k2jYAyY2Eq9XK"; // Your key  
    public static string _accessTokenSecret = "zaRpMKOLZZ31hJL7onOIgdR88dnDPaNqs2dyK9yrVeHNP"; // Your key  
    protected void Page_Load(object sender, EventArgs e)
    {
        TwitterService twitterService = new TwitterService(_consumerKey, _consumerSecret);
        twitterService.AuthenticateWith(_accessToken, _accessTokenSecret);

        int tweetcount = 1;
        var tweets_search = twitterService.Search(new SearchOptions { Q = "#eGovForum", Resulttype = TwitterSearchResultType.Popular });
        //Resulttype can be TwitterSearchResultType.Popular or TwitterSearchResultType.Mixed or TwitterSearchResultType.Recent  
        List<TwitterStatus> resultList = new List<TwitterStatus>(tweets_search.Statuses);
       // dlLatest1.DataSource = resultList;
       // dlLatest1.DataBind();
        foreach (var tweet in tweets_search.Statuses)
        {
            try
            {
                //tweet.User.ScreenName;  
                //tweet.User.Name;   
                //tweet.Text; // Tweet text  
                //tweet.RetweetCount; //No of retweet on twitter  
                //tweet.User.FavouritesCount; //No of Fav mark on twitter  
                //tweet.User.ProfileImageUrl; //Profile Image of Tweet  
                //tweet.CreatedDate; //For Tweet posted time  
                //"https://twitter.com/intent/retweet?tweet_id=" + tweet.Id;  //For Retweet  
                //"https://twitter.com/intent/tweet?in_reply_to=" + tweet.Id; //For Reply  
                //"https://twitter.com/intent/favorite?tweet_id=" + tweet.Id; //For Favorite  

                //Above are the things we can also get using TweetSharp.  
                //Console.WriteLine("Sr.No: " + tweetcount + "\n" + tweet.User.Name + "\n" + tweet.User.ScreenName + "\n" + "https://twitter.com/intent/retweet?tweet_id=" + tweet.Id);
               tweetcount++;
                Label1.Text = tweet.Text;
                
            }
            catch { }
        }
       
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string email = "abc@abc.com";

        string aa = File.ReadAllText(Server.MapPath("aconf/email1.html")).ToString().Trim();

        ClientScript.RegisterStartupScript(this.GetType(), "mailto", "parent.location='mailto:" + email + "?subject=dsfd&body=<b>sdsd</b>'", true);

    }
}