<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sponsor.ascx.cs" Inherits="sponsor" %>
   

	<!-- section 9 -->
			<div class="section_6 padding-0 home-sponsors">
               
				<div class="container">
                     <div class="row home-sponsors-row">
						<div class="home-title no-transform"><asp:Label ID="lblSponsor" runat="server" Text="Sponsors"></asp:Label></div>
                </div>
					<div class="row home-sponsors-row">
						

                         <asp:Repeater ID="dlLatest" runat="server" OnItemDataBound="dlLatest_ItemDataBound">
  
<ItemTemplate>
    <!-- sponsor 1 -->
						<div class="col-md-4">
							<div class="sponsors-title "><asp:Label ID="lblCategoryId" runat="server" Text='<%# Eval("CategoryId") %>' Visible="false"></asp:Label>
        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                                <asp:Label ID="lblTitle1" runat="server" Text='<%# Eval("CategoryName1") %>'></asp:Label>
							</div>
							<div class="carousel carousel-showmanymoveone slide" id='carousel_sponsor_<%# Container.ItemIndex + 1 %>'>
								<div class="carousel-inner">
                                    <asp:Repeater ID="dlLatest1" runat="server" OnItemDataBound="dlLatest1_ItemDataBound">
  
<ItemTemplate>

    <div class="item active" runat="server" id="slcss">
										<div class="col-xs-12 col-sm-12 col-md-12">
											<asp:Label ID="lblCategoryId" runat="server" Text='<%# Container.ItemIndex + 1 %>' Visible="false"></asp:Label>
												<a href='<%# Eval("ADetail") %>'>
													<img src='<%# Eval("DImage") %>' class="img-responsive">
												</a>
										</div>
									</div>




   
  


    
   
		                     
</ItemTemplate>

</asp:Repeater>





									
									
									

								</div>
                                <div class="home-sponsor-ctrl">
									<a class="left carousel-control left-ctrl" href="#carousel_sponsor_<%# Container.ItemIndex + 1 %>" data-slide="prev">
										<img src="assets/images/grey-left-arrow.png">
										<!--<i class="glyphicon glyphicon-chevron-left"></i>-->
									</a>
									<a class="right carousel-control right-ctrl" href="#carousel_sponsor_<%# Container.ItemIndex + 1 %>" data-slide="next">
										<img src="assets/images/grey-right-arrow.png">
									</a>
								</div>


								
							</div>
						</div>
						<!-- End sponsor 1 -->



      


    
   
		                     
</ItemTemplate>

</asp:Repeater>


						

					</div>
					
				</div>
			</div>
			<!-- # section 9 -->







	