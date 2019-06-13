<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="PreviusSpeakers.aspx.cs" Inherits="PreviusSpeakers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- content goes here -->
				<div class="banner-wrap" style="background-image:url('assets/images/Speakers-Banner.jpg');">
					<div class="container"><h2 class="banner-title"><asp:Label ID="lblPSpeakers" runat="server" Text="Previous Speakers"></asp:Label></h2></div>
				</div>
				<div class="breadcrum-wrap">
					<div class="container">
						<div class="breadcrum-inner">
							<ul>
								<li><a href="Default.aspx"><i class="fa fa-home"></i></a><i class="fa fa-angle-right"></i></li>
								<li><a href="#">
                                    <asp:Label ID="lblSpeakers" runat="server" Text="Speakers"></asp:Label>
                                    </a><i class="fa fa-angle-right"></i></li>
								<li><a href="#">
                                    <asp:Label ID="lblPSpeakers1" runat="server" Text="Previous Speakers"></asp:Label>
                                    </a></li>
							</ul>
						</div>
					</div>
				</div>
				<div class="content-inner-wrap">
					<div class="container">
						<div class="section-title">
							<h2><asp:Label ID="lblPSpeakers2" runat="server" Text="Previous Speakers"></asp:Label></h2>
						</div>
						<div class="section-content">
                              <div class="speakers-list">
                              <asp:Repeater ID="dlCont" runat="server" OnItemDataBound="dlCont_ItemDataBound" OnItemCommand="dlCont_ItemCommand">
                                         <HeaderTemplate>
                                             <ul>
                                         </HeaderTemplate>
   
<ItemTemplate>

    <li>
										<div class="peakersimg">
                                            <asp:ImageButton ID="imgDet" runat="server" ImageUrl='<%# Eval("DImage") %>' CssClass="example-image" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"ContentId") %>' CommandName="view" />
                                             <%--<a href='SpeakerDetail.aspx?c=<%# Eval("ContentId") %>'>
											<img class="example-image" src='<%# Eval("DImage") %>' alt=""/>
                                                 </a>--%>
										</div>
										<div class="speakerstext">
											<h1>
                                                <asp:Label ID="lblCategoryId" runat="server" Text='<%# Eval("ContentId") %>' Visible="false"></asp:Label>
                                               <asp:Label ID="lblCTitle" runat="server" Text='<%# Eval("ContentTitle") %>'></asp:Label>
                                                    <asp:Label ID="lblCTitle1" runat="server" Text='<%# Eval("ContentTitle1") %>'></asp:Label>
                                                
                                               </h1>
                                            <p>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                                                   
                                                </p>
											<p>
                                                <asp:Label ID="lblShort" runat="server" Text='<%# Eval("ShortContent") %>'></asp:Label>
                                                    <asp:Label ID="lblShort1" runat="server" Text='<%# Eval("ShortContent1") %>'></asp:Label>
                                            
                                                
                                                </p>
											<p>
                                                <asp:Label ID="lblDet" runat="server" Text='<%# Eval("ADetail") %>'></asp:Label>
                                                    <asp:Label ID="lblDet1" runat="server" Text='<%# Eval("ADetail1") %>'></asp:Label>
                                            
                                                
											</p>
										</div>
									</li>






  




   
    



    
</ItemTemplate>
                                         <FooterTemplate>
                                             </ul>
                                         </FooterTemplate>

</asp:Repeater>

                                  </div>

                           <%--  <asp:Repeater ID="dlCont" runat="server" OnItemDataBound="dlCont_ItemDataBound">
                                         <HeaderTemplate>
                                             
                                         </HeaderTemplate>
   
<ItemTemplate>
    <div class="col-md-4 speakers-category">
								<div class="speakers-cat-inner">
									<div class="speak-cat-title">
										<i class="fa fa-calendar"></i><h3>
                                            <asp:Label ID="lblCategoryId" runat="server" Text='<%# Eval("CategoryId") %>' Visible="false"></asp:Label>
        
             <asp:Label ID="lblCTitle" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                                                    <asp:Label ID="lblCTitle1" runat="server" Text='<%# Eval("CategoryName1") %>'></asp:Label>
                                            
                                            </h3>
									</div>
									<div class="speak-cat-desc">
										<p>
                                            <asp:Label ID="lblShort" runat="server" Text='<%# Eval("CategoryName") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblShort1" runat="server" Text='<%# Eval("CategoryName1") %>' Visible="false"></asp:Label>
                                            
                                            </p>
										
                                        <a class="btn-common" href='Speakers.aspx?c=<%# Eval("CategoryId") %>&t=<%# Eval("CategoryName") %>'>
                                            <asp:Label ID="lblVSpeakers" runat="server" Text="View Speakers"></asp:Label>
                                        </a>
									</div>
								</div>
							</div>




    



    
</ItemTemplate>
                                         <FooterTemplate>
                                             
                                         </FooterTemplate>

</asp:Repeater>--%>





							
						</div>
					</div>
				</div>






  
					


</asp:Content>

