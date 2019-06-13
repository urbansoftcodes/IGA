<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="VideoGallery.aspx.cs" Inherits="VideoGallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="assets/css/flexslider.css" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblpid" runat="server" Text="" Visible="false"></asp:Label>
    <!-- content goes here -->
				<div class="banner-wrap" style="background-image:url('assets/images/Photo-Vidoe-Banner.jpg');">
					<div class="container"><h2 class="banner-title"><asp:Label ID="lblProducts" runat="server" Text="photo gallery"></asp:Label></h2></div>
				</div>
				<div class="breadcrum-wrap">
					<div class="container">
						<div class="breadcrum-inner">
							<ul>
								<li><a href="Default.aspx"><i class="fa fa-home"></i></a><i class="fa fa-angle-right"></i></li>
								<li><a href="#">
                                    <asp:Label ID="lblProducts1" runat="server" Text="photo gallery"></asp:Label>
								    </a></li>
							</ul>
						</div>
					</div>
				</div>
				<div class="content-inner-wrap">
					<div class="container">
						<div class="section-title">
							<h2>
                                <asp:Label ID="lblProducts2" runat="server" Text="photo gallery"></asp:Label>
                                </h2>
						</div>
						<div class="col-md-12 pad-0 videogalery-col12">
							
						<div id="main" role="main">
						  <section class="slider">


                              <div id="videoslider" class="flexslider">
                              <asp:Repeater ID="dlProducts" runat="server" OnItemDataBound="dlProducts_ItemDataBound">
   <HeaderTemplate>
      <ul class="slides">
   </HeaderTemplate>
<ItemTemplate>
    <li>
									<div class="videodetailcover">
											<div class="videotitlewithdate">
										<%--<span>29 june 2018 |</span>--%>
                                        <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("ContentId") %>' Visible="false"></asp:Label>
                                         <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("ContentTitle") %>'></asp:Label>
                                            <asp:Label ID="lblTitle1" runat="server" Text='<%# Eval("ContentTitle1") %>'></asp:Label>

									</div>
									<div class="videogallerycover">
                                        <asp:Label ID="lblvurl" runat="server" Text='<%# Eval("ADetail") %>' Visible="false"></asp:Label>
										<iframe src='<%# Eval("ADetail") %>' width="100%" height="450" runat="server" id="vidframe"></iframe>
                                        <video controls height="450" width="100%" runat="server" id="vidvid"><source src='<%# Eval("ADetail") %>'></video>
									</div>
                                        </div>
								</li>
    
    
   
  
</ItemTemplate>
<FooterTemplate>
    </ul>
</FooterTemplate>
</asp:Repeater>

</div>

                           <div id="videocarousel" class="flexslider">

                                   <asp:Repeater ID="dlProducts1" runat="server" OnItemDataBound="dlProducts1_ItemDataBound">
   <HeaderTemplate>
        <ul class="slides">	
   </HeaderTemplate>
<ItemTemplate>
    <li>
									<div class="videocover">
												<div class="videothumnails">
											<asp:Label ID="lblvurl" runat="server" Text='<%# Eval("ADetail") %>' Visible="false"></asp:Label>
										<iframe src='<%# Eval("ADetail") %>'  height="100" runat="server" id="vidframe"></iframe>
                                        <video controls height="100"  runat="server" id="vidvid"><source src='<%# Eval("ADetail") %>'></video>
										</div>
										<div class="photo-caption">
											<%--<p class="photodate">29 june 2018</p>--%>
											<div class="videotitle">
                                                 <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("ContentId") %>' Visible="false"></asp:Label>
                                         <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("ContentTitle") %>'></asp:Label>
                                            <asp:Label ID="lblTitle1" runat="server" Text='<%# Eval("ContentTitle1") %>'></asp:Label>
                                              </p>
										</div>
									</div>
								</li>



   
  
</ItemTemplate>
<FooterTemplate>
    </ul>
</FooterTemplate>
</asp:Repeater>



                                  </div>




                              </section>
						</div>

						</div>
					</div>
				</div>









   


  
			
                                      <%--<asp:Repeater ID="dlCategory" runat="server" OnItemDataBound="dlCategory_ItemDataBound" OnItemCommand="dlCategory_ItemCommand">
   
<ItemTemplate>
    <div>
										<span>
                                            <asp:Label ID="lblCategoryId" runat="server" Text='<%# Eval("CategoryId") %>' Visible="false"></asp:Label>
                
                <asp:LinkButton ID="lbtnCategoryName" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CategoryId") %>' CommandName="view" Text='<%# Eval("CategoryName") %>' ></asp:LinkButton>
                <asp:LinkButton ID="lbtnCategoryName1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CategoryId") %>' CommandName="view" Text='<%# Eval("CategoryName1") %>'></asp:LinkButton>
                
                                            
                                            
                                      </span>
										
									</div>

    
    
   
  
</ItemTemplate>

</asp:Repeater>--%>


									
								
			<script defer src="assets/js/jquery.flexslider.js"></script>
	<script>
        $(document).ready(function () {
            $(window).load(function () {
                $('#videocarousel').flexslider({
                    animation: "slide",
                    controlNav: false,
                    animationLoop: false,
                    slideshow: false,
                    itemWidth: 210,
                    itemMargin: 10,
                    asNavFor: '#videoslider'
                });

                $('#videoslider').flexslider({
                    animation: "slide",
                    controlNav: false,
                    animationLoop: false,
                    slideshow: false,
                    sync: "#videocarousel",
                    start: function (slider) {
                        $('body').removeClass('loading');
                    }
                });
            });
        });
	</script>		
    


</asp:Content>

