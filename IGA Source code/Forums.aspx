<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="Forums.aspx.cs" Inherits="Forums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- content goes here -->
				<div class="banner-wrap" style="background-image:url('assets/images/About-BAnner.jpg');">
					<div class="container"><h2 class="banner-title"><asp:Label ID="lblPForum" runat="server" Text=""></asp:Label></h2></div>
				</div>
				<div class="breadcrum-wrap">
					<div class="container">
						<div class="breadcrum-inner">
							<ul>
								<li><a href="#"><i class="fa fa-home"></i></a><i class="fa fa-angle-right"></i></li>
								<li><a href="#">
                                    <asp:Label ID="lblPForum1" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="lblpid" runat="server" Text="" Visible="false"></asp:Label>
                                    </a></li>
							</ul>
						</div>
					</div>
				</div>
				<div class="content-inner-wrap previous-forums-page">				
					<div class="container">
						<div class="section-title">
							<h2><asp:Label ID="lblPForum2" runat="server" Text=""></asp:Label></h2>
						</div>
						<div class="col-md-12">
							<!-- Nav tabs -->
							<div class="card  previous-forums-tab">

                                <asp:Repeater ID="dlLatest1" runat="server" OnItemDataBound="dlLatest1_ItemDataBound"   OnItemCommand="dlLatest1_ItemCommand">
  
<HeaderTemplate>
    <ul class="nav nav-tabs" role="tablist">
</HeaderTemplate>
<ItemTemplate>
    <li role="presentation" class="" runat="server" id="yforum">
        <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("CategoryId") %>' Visible="false"></asp:Label>

                                                             <asp:LinkButton ID="lblTitle" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CategoryId") %>' CommandName="view" Text='<%# Eval("CategoryName") %>'></asp:LinkButton>
                <asp:LinkButton ID="lblTitle1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CategoryId") %>' CommandName="view" Text='<%# Eval("CategoryName1") %>'></asp:LinkButton>
                

										
									</li>

 
    
   
		                     
</ItemTemplate>
<FooterTemplate>
    </ul>
</FooterTemplate>
</asp:Repeater>

						
								<!-- Tab panes -->
								<div class="tab-content">
									<div role="tabpanel" class="tab-pane active" id="home">
										<!-- previous forum topic  -->
										<div class="col-md-12agendabox-col4 previous-forums-container" runat="server" id="fcont">
											
										</div>
										<!-- previous forum speaker  -->
										<div class="col-md-12 agendabox-col4 previous-speaker-table">
                                            <!-- include new title -->
	<div class="previous-forums-Speakers-title">
		<h3> <asp:LinkButton ID="lbtnpyear" runat="server" OnClick="lbtnpyear_Click"></asp:LinkButton> <asp:LinkButton ID="lbtnpyear1" runat="server" OnClick="lbtnpyear1_Click">Photo Gallery</asp:LinkButton> </h3>
	</div>
	<!-- End include new title -->

											<div class="previous-forums-title">
												<h3>
                                                    <asp:Label ID="lblSpeakers" runat="server" Text="Speakers"></asp:Label>
                                                    </h3>
											</div>
											<div class="col-md-12">
												<div class="carousel carousel-showmanymoveone slide" id="carouselABC">
													<div class="carousel-inner">

                                                         <asp:Repeater ID="dlCont" runat="server" OnItemDataBound="dlCont_ItemDataBound">
                                        
   
<ItemTemplate>


    <div class="" runat="server" id="cssspeak">
															<div class="col-xs-12 col-sm-6 col-md-3">
																
                                                                    <asp:ImageButton ID="imgDet" runat="server" ImageUrl='<%# Eval("DImage") %>' CssClass="example-image" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ContentId") %>' CommandName="view" />
																	
																
																<div class="speakers-info">
																	<h1 data-toggle="modal" data-target="#mybio">
                                                                         <asp:Label ID="lblCategoryId1" runat="server" Text='<%# Container.ItemIndex + 1 %>' Visible="false"></asp:Label>
																		 <asp:Label ID="lblCategoryId" runat="server" Text='<%# Eval("ContentId") %>' Visible="false"></asp:Label>
                                               <asp:Label ID="lblCTitle" runat="server" Text='<%# Eval("ContentTitle") %>'></asp:Label>
                                                    <asp:Label ID="lblCTitle1" runat="server" Text='<%# Eval("ContentTitle1") %>'></asp:Label>
                                                				
																	</h1>
																</div>
															</div>
														</div>







  




   
    



    
</ItemTemplate>
                                        

</asp:Repeater>





														
																											 
													</div>
													<div class="speaker-controls">
														<a class="left carousel-control" href="#carouselABC" data-slide="prev">
															<img src="assets/images/left-arrow.png" alt="left arrow">
														</a>
														<a class="right carousel-control" href="#carouselABC" data-slide="next">
															<img src="assets/images/right-arrow.png" alt="left arrow">
														</a>
													</div>														
												</div>
											</div>																						
										</div>									
									</div>
									
										<div role="tabpanel" class="tab-pane" id="profile">
										
										</div>
										
										<div role="tabpanel" class="tab-pane" id="messages">
										
										</div>
										
										<div role="tabpanel" class="tab-pane" id="settings">
										
										</div>
									</div>
							</div>
						</div>	
					</div>
				</div>



	<!-- <script src="//static.codepen.io/assets/common/stopExecutionOnTimeout-b2a7b3fe212eaa732349046d8416e00a9dec26eb7fd347590fbced3ab38af52e.js"></script>
	<script src='//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
	<script src='//maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js'></script> -->

	<!-- carousel -->
    <!-- <script>
		
		(function(){
			
			$('#carousel123').carousel({ interval: 2000 });
			$('#carouselABC').carousel({ interval: 3600 });
		}());

		(function(){
			alert (" test ");
		  $('.carousel-showmanymoveone .item').each(function(){
			var itemToClone = $(this);

			for (var i=1;i<4;i++) {if (window.CP.shouldStopExecution(1)){break;}
			  itemToClone = itemToClone.next();

			  // wrap around if at end of item collection
			  if (!itemToClone.length) {
				itemToClone = $(this).siblings(':first');
			  }

			  // grab item, clone, add marker class, add to collection
			  itemToClone.children(':first-child').clone()
				.addClass("cloneditem-"+(i))
				.appendTo($(this));
			}
		window.CP.exitedLoop(1);

		  });
		}());
      //# sourceURL=pen.js
    </script>-->

</asp:Content>

