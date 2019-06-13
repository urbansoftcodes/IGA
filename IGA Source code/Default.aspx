<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>


<%@ Register Src="~/pforum.ascx" TagPrefix="uc1" TagName="pforum" %>
<%@ Register Src="~/sponsor.ascx" TagPrefix="uc1" TagName="sponsor" %>
<%@ Register Src="~/twitter.ascx" TagPrefix="uc1" TagName="twitter" %>
<%@ Register Src="~/hvideo.ascx" TagPrefix="uc1" TagName="hvideo" %>






<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

   <script type="text/javascript">

       function calm() {

           $.get('aconf/email2.html', function (data) {
               window.location = "mailto:registration@iga.gov.bh?subject= Egov forum 2018 Registration&body=" + encodeURIComponent(data);
           }, 'html');


       }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <!-- Content-->
				<div class="home-page-container">
					<div class="section_1 background-wrap-fullwidth" runat="server" id="haus">
						
					</div>
					<div class="clearfix"></div>
					<div class="section_2 mainmarque-rw">
						<!--marque text -->
                          <div class="container">
							<div class="row main-marque">
								<div class="col-md-2">
									<p>
                                        <asp:Label ID="lblLnews" runat="server" Text="Latest News"></asp:Label>
                                        </p>
								</div>
								<div class="col-md-10">
									<marquee behavior="scroll" direction="left" onmouseover="this.stop();" onmouseout="this.start();"  scrollamount="3" id="mdisp" runat="server">
                                         <asp:Repeater ID="dlLatest2" runat="server" OnItemDataBound="dlLatest2_ItemDataBound">
  
<ItemTemplate>

    <a href='NewsDetail.aspx?c=<%# Eval("ContentId") %>&t=<%# Eval("ContentTitle") %>'> 
         <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("ContentId") %>' Visible="false"></asp:Label>
                                         <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("ContentTitle") %>'></asp:Label>
                                            <asp:Label ID="lblTitle1" runat="server" Text='<%# Eval("ContentTitle1") %>'></asp:Label>
        
       </a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


   



    
   
		                     
</ItemTemplate>

</asp:Repeater></marquee>
								</div>
							</div>
						  </div>
                        <!--marque text end-->
					</div>
					<!-- section 3 -->
					
					<!-- #section 3 -->
					<!-- section 4 -->
					<div class="section_4 padding-50" runat="server" id="haus1">
                        
					</div>
					<!-- #section 4 -->


                    <!-- section 5 -->
			<div class="section_5 padding-50 home-speaker-section home-parallax">
				<div class="speaker-overlay-bg">
					<div class="container">
						<div class="row ">
							<div class="home-title"><asp:Label ID="lblESpeaker" runat="server" Text="Event Speakers"></asp:Label></div>
							<div class="col-md-12">
								<div class="carousel carousel-showmanymoveone slide" id="home-speakers-carousel">
									<div class="carousel-inner">

                                        <asp:Repeater ID="dlSlide" runat="server" OnItemDataBound="dlSlide_ItemDataBound" OnItemCommand="dlSlide_ItemCommand">
   
<ItemTemplate>

    <div class="item active" runat="server" id="slcsse">
											<div class="col-xs-12 col-sm-6 col-md-3">
												<div class="h-speakers-img">
													 <asp:ImageButton ID="imgc" runat="server" ImageUrl='<%# Eval("DImage") %>'  CssClass="img-with-animation  animated-in" CommandName="view" />
												</div>
												<div class="h-speakers-info">
													<h3>
                                                        <asp:Label ID="lblCategoryId" runat="server" Text='<%# Container.ItemIndex + 1 %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblprodid" runat="server" Text='<%# Eval("ContentId") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblCTitle" runat="server" Text='<%# Eval("ContentTitle") %>'></asp:Label>
                                                    <asp:Label ID="lblCTitle1" runat="server" Text='<%# Eval("ContentTitle1") %>'></asp:Label></h3>
												<p>
                                                    <asp:Label ID="lblShort" runat="server" Text='<%# Eval("ShortContent") %>'></asp:Label>
                                                    <asp:Label ID="lblShort1" runat="server" Text='<%# Eval("ShortContent1") %>'></asp:Label>
                                                    <br />
                                                    <asp:Label ID="lblDet" runat="server" Text='<%# Eval("ADetail") %>'></asp:Label>
                                                    <asp:Label ID="lblDet1" runat="server" Text='<%# Eval("ADetail1") %>'></asp:Label>
												</p>
												</div>
											</div>
										</div>

   





    
</ItemTemplate>

</asp:Repeater>



										
									</div>
									<div class="speaker-controls">
										<a class="left carousel-control" href="#home-speakers-carousel" data-slide="prev">
											<img src="assets/images/left-arrow.png" alt="left arrow">
										</a>
										<a class="right carousel-control" href="#home-speakers-carousel" data-slide="next">
											<img src="assets/images/right-arrow.png" alt="left arrow">
										</a>
									</div>
								</div>
							</div>
							<div class="view-more-btn col-md-12">
								<a class="iga-btn" href="Speakers.aspx">
									<asp:Label ID="lblASpeakers" runat="server" Text="View All Speakers"></asp:Label>
									<img class="size-" src="assets/images/right-arrow-circular.svg" alt="">
								</a>
							</div>
							
						</div>
					</div>
				</div>
			</div>
			<!-- #section 5 -->








				

					<!-- section 6 -->
					<div class="section_5 padding-50 section-bg-color">
						<div class="container">
							<div class="row ">
								<div class="home-title">
                                    <asp:Label ID="lblPGallery" runat="server" Text="Photo Gallery"></asp:Label>
                                    </div>
								<div class="col-md-12 home-photo-gallery">
                                     <asp:Repeater ID="dlLatest1" runat="server" OnItemDataBound="dlLatest1_ItemDataBound"   OnItemCommand="dlLatest1_ItemCommand">
  
<ItemTemplate>
 <div class="col-md-3">						
										<div class="inner-wrap">	
                                             
											<div class="photo-gallery-img">
                                               <asp:ImageButton ID="imgc" runat="server" CssClass="size-" CommandName="view" />
                                                <%--<asp:Image ID="imgc" runat="server" CssClass="size-" />--%>
                                                    
												
											</div>
                                               
											<%--<div class="overlay-bg"></div>--%>
											<div class="gellery-info">																		        	
												
												<div class="gellery-date">
													<h3>


                                                        <%--<a href='PhotoGallery.aspx?c=<%# Eval("CategoryId") %>'>
                                                        <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("CategoryId") %>' Visible="false"></asp:Label>
                                                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                                            <asp:Label ID="lblTitle1" runat="server" Text='<%# Eval("CategoryName1") %>'></asp:Label>
													  </a>--%>

                                                        <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("CategoryId") %>' Visible="false"></asp:Label>

                                                             <asp:LinkButton ID="lblTitle" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CategoryId") %>' CommandName="view" Text='<%# Eval("CategoryName") %>' ></asp:LinkButton>
                <asp:LinkButton ID="lblTitle1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CategoryId") %>' CommandName="view" Text='<%# Eval("CategoryName1") %>'></asp:LinkButton>
                


                                                            </h3> 
													<!-- <p>May 28, 2018</p> -->
												</div>											
											</div>											
										</div>										
									</div>

   


    
   
		                     
</ItemTemplate>

</asp:Repeater>




									
									
									<div class="view-more-btn">
										<a class="iga-btn" href="PhotoGalleryYear.aspx">
                                            <asp:Label ID="lblVGallery" runat="server" Text="View Full Gallery"></asp:Label>
                                             <img class="size-" src="assets/images/right-arrow-circular.svg" alt=""></a>
									</div>
								</div>
							</div>
						</div>
					</div>
					<!-- #section 6 -->

                  <!-- include sponsor -->
					<uc1:sponsor runat="server" ID="sponsor" />
					<!-- End include sponsor -->

					<!-- section 7 -->
					<div class="section_6 padding-50">
						<div class="container">
							<div class="row ">
								<div class="col-md-6 padding-left-0"  runat="server" id="haus2">
                                    <uc1:hvideo runat="server" ID="hvideo" />
                                    <uc1:twitter runat="server" ID="twitter" />
								</div>
								<div class="col-md-6 padding-right-0 latestns-rw">
									<div class="home-title no-transform">
                                        <asp:Label ID="lblHNews" runat="server" Text="News"></asp:Label>
                                        </div>									
									<!-- news carousel -->
								    <div class='col-md-12 home-news-carousel'>
										<div class="carousel slide" data-ride="carousel" id="news-carousel">
											<!-- Bottom Carousel Indicators -->
											<ol class="carousel-indicators">
											  <li data-target="#news-carousel" data-slide-to="0" class="active"></li>
											  <li data-target="#news-carousel" data-slide-to="1"></li>
											  <li data-target="#news-carousel" data-slide-to="2"></li>
                                                <li data-target="#news-carousel" data-slide-to="3"></li>
											</ol>        
											<!-- Carousel Slides / Quotes -->
											<div class="carousel-inner">  
                                                <asp:Repeater ID="dlLatest" runat="server" OnItemDataBound="dlLatest_ItemDataBound"  OnItemCommand="dlLatest_ItemCommand">
  
<ItemTemplate>

    <!-- news item 1 -->
												<div class="item active" runat="server" id="slcss">
													<div class="col-sm-12 h-news-ims-sec">
                                                        <asp:Label ID="lblCategoryId" runat="server" Text='<%# Container.ItemIndex + 1 %>' Visible="false"></asp:Label>
														<img src='<%# Eval("DImage") %>' alt="news image">
														<div class="h-news-date">
															<span class="n-date"><asp:Label ID="lblDate" runat="server" Text='<%# Eval("PublishDate", "{0:dd}")%>'></asp:Label></span>
															<span class="n-month"><asp:Label ID="lblMonth" runat="server" Text='<%# Eval("PublishDate", "{0:MMMM}")%>'></asp:Label></span>
														</div>														
													</div>
													<div class="col-sm-12">
														<div class="news-sub-title" >
															<h3>
                                                                <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("ContentId") %>' Visible="false"></asp:Label>
                                         <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("ContentTitle") %>'></asp:Label>
                                            <asp:Label ID="lblTitle1" runat="server" Text='<%# Eval("ContentTitle1") %>'></asp:Label>
															</h3>
														</div>
														<div class="desc">
															<p >
                                                                 <asp:Label ID="lblShort" runat="server" Text='<%# Eval("ShortContent") %>'></asp:Label>
                                            <asp:Label ID="lblShort1" runat="server" Text='<%# Eval("ShortContent1") %>'></asp:Label>
															</p>
															
                                                            <asp:LinkButton ID="lblView" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CategoryId") %>' CommandName="view" Text='read more' CssClass="read-more" ></asp:LinkButton>
                                                            <%--<a href='NewsDetail.aspx?c=<%# Eval("ContentId") %>&t=<%# Eval("ContentTitle") %>' class="read-more"> <asp:Label ID="lblView" runat="server" Text="read more"></asp:Label></a>--%>
                                                           
														</div>														
													</div>
												</div>




    
   
		                     
</ItemTemplate>

</asp:Repeater>


					
												
												
											</div>        
											<!-- Carousel Buttons Next/Prev -->
											<div class="news-controls">
												<!-- <a data-slide="prev" href="#news-carousel" class="left carousel-control"><i class="fa fa-chevron-left"></i></a> -->
												<!-- <a data-slide="next" href="#news-carousel" class="right carousel-control"><i class="fa fa-chevron-right"></i></a> -->
												<a data-slide="prev" href="#news-carousel" class="left carousel-control">
													<img src="assets/images/left-arrow.png" alt="left arrow">
												</a>
												<a data-slide="next" href="#news-carousel" class="right carousel-control">
													<img src="assets/images/right-arrow.png" alt="left arrow">
												</a>
											</div>
										</div>                          
									</div>
								</div>
							</div>
						</div>
					</div>
					<!-- #section 7 -->
					<!-- section 8 -->
					<div class="section_6 padding-50 home-need-section home-parallax">
						<div class="container">
							<div class="row home-need-help" runat="server" id="haus3">
                                
							</div>
						</div>						
					</div>
					<!-- # section 8 -->		
                    
                   



				</div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:LinkButton ID="lbtnSm1" runat="server" OnClick="lbtnSm1_Click"></asp:LinkButton>

    <asp:LinkButton ID="lbtnSm2" runat="server" OnClick="lbtnSm2_Click"></asp:LinkButton>
    <asp:LinkButton ID="lbtnSm3" runat="server" OnClick="lbtnSm3_Click"></asp:LinkButton>
    <asp:LinkButton ID="lbtnSm4" runat="server" OnClick="lbtnSm4_Click"></asp:LinkButton>
    <asp:LinkButton ID="lbtnSm5" runat="server" OnClick="lbtnSm5_Click"></asp:LinkButton>

        </ContentTemplate>   

    </asp:UpdatePanel>


    












    <!--Registration Form-->
	<div class="modal fade" id="registerNow" tabindex="-1" role="dialog" aria-labelledby="registerNow" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
         
        </div>
    </div>
</div>
<!-- End-->


    <uc1:pforum runat="server" ID="pforum" />
    

</asp:Content>

