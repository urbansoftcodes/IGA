<%@ Control Language="C#" AutoEventWireup="true" CodeFile="twitter.ascx.cs" Inherits="twitter" %>


<div class="home-title no-transform">
    <asp:Label ID="lblTitle" runat="server" Text="#eGovForum Feed"></asp:Label>
    </div>

	<div class="twitter_feed_wrap">									
		<div class="insta twit">
			<div class="instagram-head">
				<a href="https://twitter.com/intent/tweet?button_hashtag=eGovForum&ref_src=twsrc%5Etfw" class="twitter-hashtag-button" data-show-count="false">Tweet #eGovForum</a><script async src="https://platform.twitter.com/widgets.js" charset="utf-8"></script>
			</div>
			<div>
                <asp:Repeater ID="dlLatestTwit" runat="server">
  
<ItemTemplate>
    <div class="item-twitter">
					<div class="item-content">
						<h4><asp:Label ID="Label2" runat="server" Text='<%# Eval("User.Name") %>'></asp:Label><span>   @<asp:Label ID="Label3" runat="server" Text='<%# Eval("User.ScreenName") %>'></asp:Label>  <asp:Label ID="Label4" runat="server" Text='<%# Eval("CreatedDate") %>'></asp:Label></span></h4>
						<p><asp:Label ID="Label1" runat="server" Text='<%# Eval("Text") %>'></asp:Label></p>
					</div>
				</div>
   

        

	
    
   
		                     
</ItemTemplate>

</asp:Repeater>

				

												
			</div>
		</div>
	</div>									
	
 
