<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="News.aspx.cs" Inherits="News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="banner-wrap" style="background-image:url('assets/images/About-BAnner.jpg');">
					<div class="container"><h2 class="banner-title">
                        <asp:Label ID="lblProducts" runat="server" Text="News"></asp:Label>
                        
                        </h2></div>
				</div>

    <div class="breadcrum-wrap">
					<div class="container">
						<div class="breadcrum-inner">
							<ul>
								<li><a href="Default.aspx"><i class="fa fa-home"></i></a><i class="fa fa-angle-right"></i></li>
								<li><a href="#"><asp:Label ID="lblProducts1" runat="server" Text="News"></asp:Label></a></li>
							</ul>
						</div>
					</div>
				</div>

    <!-- <div class="row news-row"> -->
							<div class="container news-cover ">

                                <asp:DataList ID="dlProducts" runat="server" OnItemDataBound="dlProducts_ItemDataBound" RepeatLayout="Flow" RepeatDirection="Vertical"  OnItemCommand="dlProducts_ItemCommand">
                      <ItemTemplate>

                          <div class="col-md-12 news-col12 pad-0">
									<div class="col-md-4 newscol-6">
										<div class="newsimg-cover">
											<img src='<%# Eval("DImage") %>' alt="NEWS IMAGE" class="newsimg">
										</div>
										<div class="news-date">
											<h1>
                                                <asp:Label ID="lblDate" runat="server" Text='<%# Eval("PublishDate", "{0:dd}")%>'></asp:Label>
                                                <br/> <asp:Label ID="lblMonth" runat="server" Text='<%# Eval("PublishDate", "{0:MMMM}")%>'></asp:Label></h1>
										</div>
										
									</div>
									<div class="col-md-8 newscol-6">
										<div class="news-description">
											<h1><%--<a href='NewsDetail.aspx?c=<%# Eval("ContentId") %>&t=<%# Eval("ContentTitle") %>'>--%>
                                                 <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("ContentId") %>' Visible="false"></asp:Label>
                                                <asp:Label ID="lblCDate" runat="server" Text='<%# Eval("CreatedDate") %>' Visible="false"></asp:Label>
                                         
                                                 <asp:LinkButton ID="lblTitle" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ContentId") %>' CommandName="view" Text='<%# Eval("ContentTitle") %>'></asp:LinkButton>
                                                <asp:LinkButton ID="lblTitle1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ContentId") %>' CommandName="view" Text='<%# Eval("ContentTitle1") %>'></asp:LinkButton>
                                                
                                                
                                               <%-- <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("ContentTitle") %>'></asp:Label>
                                            <asp:Label ID="lblTitle1" runat="server" Text='<%# Eval("ContentTitle1") %>'></asp:Label>--%>
                                                

											    <%--</a>--%></h1>
											<p>
                                               <asp:Label ID="lblShort" runat="server" Text='<%# Eval("ShortContent") %>'></asp:Label>
                                            <asp:Label ID="lblShort1" runat="server" Text='<%# Eval("ShortContent1") %>'></asp:Label>
											</p>
											<div class="iga-btndiv">
                                                 <asp:LinkButton ID="lblView" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CategoryId") %>' CommandName="view" Text='read more' CssClass="read-more" ></asp:LinkButton>
                                                            
                                                <%-- <a href='NewsDetail.aspx?c=<%# Eval("ContentId") %>&t=<%# Eval("ContentTitle") %>' class="iga-btn"> <asp:Label ID="lblView" runat="server" Text="read more"></asp:Label></a>--%>
                                               </div>
											
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

