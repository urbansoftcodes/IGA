<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sponsor1.ascx.cs" Inherits="sponsor1" %>
   
<!-- section 9 -->	
					<div class="section_6 padding-50 home-sponsors">
						<div class="container">
							<div class="row home-need-help">
								<div class="home-title no-transform">
                                    <asp:Label ID="lblSponsor" runat="server" Text="Sponsors"></asp:Label>
                                    </div>
							    <div class="col-md-12">
									 <div class="carousel carousel-showmanymoveone slide" id="carouselABC">
										<div class="carousel-inner">

                                            <asp:Repeater ID="dlLatest" runat="server" OnItemDataBound="dlLatest_ItemDataBound">
  
<ItemTemplate>

    <div class="item active" runat="server" id="slcss">
											<div class="col-xs-12 col-sm-6 col-md-3">
                                                <asp:Label ID="lblCategoryId" runat="server" Text='<%# Container.ItemIndex + 1 %>' Visible="false"></asp:Label>
												<a href='<%# Eval("ADetail") %>'>
													<img src='<%# Eval("DImage") %>' class="img-responsive">
												</a>
											</div>
										</div>


  


    
   
		                     
</ItemTemplate>

</asp:Repeater>


										 
										</div>
										<a class="left carousel-control" href="#carouselABC" data-slide="prev"><i class="glyphicon glyphicon-chevron-left"></i></a>
										<a class="right carousel-control" href="#carouselABC" data-slide="next"><i class="glyphicon glyphicon-chevron-right"></i></a>
									  </div>
									</div>
							</div>
						</div>						
					</div>
					<!-- # section 9 -->	

	<!-- <script src="//static.codepen.io/assets/common/stopExecutionOnTimeout-b2a7b3fe212eaa732349046d8416e00a9dec26eb7fd347590fbced3ab38af52e.js"></script>

	<script src='//cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
	<script src='//maxcdn.bootstrapcdn.com/bootstrap/3.3.4/js/bootstrap.min.js'></script>-->

  

    <!-- <script >
		(function(){
		  $('#carousel123').carousel({ interval: 2000 });
				$('#carouselABC').carousel({ interval: 3600 });
			}());

			(function(){
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