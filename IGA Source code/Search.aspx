<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   

    <!-- <div class="row news-row"> -->
							<div class="container news-cover" style="padding-top:130px;">

                                <asp:DataList ID="dlProducts" runat="server" OnItemDataBound="dlProducts_ItemDataBound" RepeatLayout="Flow" RepeatDirection="Vertical"  OnItemCommand="dlProducts_ItemCommand">
                      <ItemTemplate>

                          <div class="col-md-12 news-col12 pad-0">
									
									<div class="col-md-12 newscol-6">
										<div class="news-description">
											<h1>
                                                <asp:Label ID="lblTypeId" runat="server" Text='<%# Eval("TypesId") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblCatId" runat="server" Text='<%# Eval("CategoryId") %>' Visible="false"></asp:Label>
                                                 <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("ContentId") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblCDate" runat="server" Text='<%# Eval("CreatedDate") %>' Visible="false"></asp:Label>
                                         
                                                 <asp:LinkButton ID="lblTitle" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ContentId") %>' CommandName="view" Text='<%# Eval("ContentTitle") %>'></asp:LinkButton>
                                                <asp:LinkButton ID="lblTitle1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ContentId") %>' CommandName="view" Text='<%# Eval("ContentTitle1") %>'></asp:LinkButton>
                                                
                                                
                                              </h1>
											<p>
                                               <asp:Label ID="lblShort" runat="server" Text='<%# Eval("ShortContent") %>'></asp:Label>
                                            <asp:Label ID="lblShort1" runat="server" Text='<%# Eval("ShortContent1") %>'></asp:Label>
											</p>
											<%--<div class="iga-btndiv">
                                                 <asp:LinkButton ID="lblView" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CategoryId") %>' CommandName="view" Text='read more' CssClass="read-more" ></asp:LinkButton>
                                                            
                                               
                                               </div>--%>
											
										</div>
									</div>
								</div>




                       

                         

                          </ItemTemplate>
                                </asp:DataList>







                                </div>
    <div class="container pagination-cover">
        <asp:Panel runat="server" id="pnlPager" CssClass="pagination1 post-pagination text-center">
            
                                </asp:Panel>
								
							</div>







   

    <div class="container main-content-wrapper sidebar-right">

			<div class="main-content">

				<div class="row">
					<div class="col-md-12 col-xs-12">
						<div class="post-block post-image-300">
                            


							
							
							
						</div>
					</div>
				</div>

				<div class="row">
					<div class="col-md-12 col-xs-12">
                         <div class="pagination-wrapper">
                         
                      </div>

						
					</div>
				</div>

			</div>

			
		</div>


    


</asp:Content>

