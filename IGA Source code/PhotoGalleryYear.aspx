<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="PhotoGalleryYear.aspx.cs" Inherits="PhotoGalleryYear" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="assets/css/flexslider.css" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblpid" runat="server" Text="" Visible="false"></asp:Label>
    <!-- content goes here -->
				<div class="banner-wrap" style="background-image:url('assets/images/PhotoGallery-banner-1.jpg');">
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
						<div class="section-content">
							<div class="col-md-12 home-photo-gallery">
                              <asp:Repeater ID="dlProducts" runat="server" OnItemDataBound="dlProducts_ItemDataBound"  OnItemCommand="dlProducts_ItemCommand">
   <HeaderTemplate>
      

   
   </HeaderTemplate>
<ItemTemplate>
    
    
     <div class="col-md-3">						
										<div class="inner-wrap">	
                                             
											<div class="photo-gallery-img">
                                               <asp:ImageButton ID="imgc" runat="server" CssClass="size-" CommandName="view" />
                                               <%-- <asp:Image ID="imgc" runat="server" CssClass="size-" />--%>
                                                    
												
											</div>
                                               
											
											<div class="gellery-info">																		        	
												
												<div class="gellery-date">
													<h3>
                                                       <%-- <a href='PhotoGallery.aspx?c=<%# Eval("CategoryId") %>'>--%>
                                                        <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("CategoryId") %>' Visible="false"></asp:Label>

                                                             <asp:LinkButton ID="lblTitle" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CategoryId") %>' CommandName="view" Text='<%# Eval("CategoryName") %>' ></asp:LinkButton>
                <asp:LinkButton ID="lblTitle1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CategoryId") %>' CommandName="view" Text='<%# Eval("CategoryName1") %>'></asp:LinkButton>
                

                                                       
													  <%--</a>--%>
                                                            </h3> 
													<!-- <p>May 28, 2018</p> -->
												</div>											
											</div>											
										</div>										
									</div>

   
  
</ItemTemplate>
<FooterTemplate>
    
</FooterTemplate>
</asp:Repeater>

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
	</script>					
    


</asp:Content>

