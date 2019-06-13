<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="PhotoGallery.aspx.cs" Inherits="PhotoGallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="assets/css/flexslider.css" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <asp:Label ID="lblpid" runat="server" Text="" Visible="false"></asp:Label>
    <!-- content goes here -->
				<div class="banner-wrap inner-res-banner-2"  style="background-image:url('assets/images/Photo-Vidoe-Banner.jpg');">
					<div class="container"><h2 class="banner-title"><asp:Label ID="lblProducts" runat="server" Text="photo gallery"></asp:Label></h2></div>
				</div>
				<div class="breadcrum-wrap">
					<div class="container">
						<div class="breadcrum-inner">
							<ul>
								<li><a href="Default.aspx"><i class="fa fa-home"></i></a><i class="fa fa-angle-right"></i></li>
								<li><a href="PhotoGalleryYear.aspx">
                                    <asp:Label ID="lblProducts1" runat="server" Text="photo gallery"></asp:Label>
								    </a><i class="fa fa-angle-right"></i></li>
                                <li><a href="#">
                                    <asp:Label ID="lblProducts3" runat="server" Text=""></asp:Label>
								    </a></li>
							</ul>
						</div>
					</div>
				</div>
				<div class="content-inner-wrap">
					<div class="container">
						<div class="section-title" style="display:none;">
							<h2>
                                <asp:Label ID="lblProducts2" runat="server" Text="photo gallery"></asp:Label>
                                </h2>
						</div>
						<div class="col-md-12 pad-0 photogallery-col12">
							
						<div id="main" role="main">
						  <section class="slider">


                              <div id="slider1" class="flexslider">
                              <asp:Repeater ID="dlProducts" runat="server" OnItemDataBound="dlProducts_ItemDataBound">
   <HeaderTemplate>
       <ul class="slides photogalleryslides" >	
   </HeaderTemplate>
<ItemTemplate>
    <li>
									<div class="photodetailtitle">
										<%--<span>29 june 2018 |</span>--%>
                                        <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("ContentId") %>' Visible="false"></asp:Label>
                                         <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("ContentTitle") %>'></asp:Label>
                                            <asp:Label ID="lblTitle1" runat="server" Text='<%# Eval("ContentTitle1") %>'></asp:Label>

									</div>
									<div class="photoimg">
										<img src='<%# Eval("DImage") %>' />
									</div>
								</li>
    
    
   
  
</ItemTemplate>
<FooterTemplate>
    </ul>
</FooterTemplate>
</asp:Repeater>

</div>

                              <div id="carousel1" class="flexslider">

                                   <asp:Repeater ID="dlProducts1" runat="server" OnItemDataBound="dlProducts1_ItemDataBound">
   <HeaderTemplate>
        <ul class="slides">	
   </HeaderTemplate>
<ItemTemplate>
    <li>
									<div class="photocover">
										<div class="photo-thumpnail">
											<img src='<%# Eval("DImage") %>' />
										</div>
										<div class="photo-caption">
											<%--<p class="photodate">29 june 2018</p>--%>
											<p class="phototitle">
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


									
								
	<!-- <script defer src="assets/js/jquery.flexslider.js"></script>
	<script>
		$(document).ready(function() {
		 
    $(window).load(function(){
      $('#carousel1').flexslider({
        animation: "slide",
        controlNav: false,
        animationLoop: false,
        slideshow: false,
        itemWidth: 210,
        itemMargin: 10,
        asNavFor: '#slider1'
      });

      $('#slider1').flexslider({
        animation: "slide",
        controlNav: false,
        animationLoop: false,
        slideshow: false,
        sync: "#carousel1",
        start: function(slider){
          $('body').removeClass('loading');
        }
      });
    });
		});
	</script>-->
    


</asp:Content>

