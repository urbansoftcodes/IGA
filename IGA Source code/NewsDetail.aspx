<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="NewsDetail.aspx.cs" Inherits="NewsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblpid" runat="server" Text="" Visible="false"></asp:Label>
    <!-- content goes here -->
				<div class="banner-wrap" style="background-image:url('assets/images/About-BAnner.jpg');">
					<div class="container"><h2 class="banner-title"><asp:Label ID="lblType" runat="server" Text=""></asp:Label></h2></div>
				</div>
				<div class="breadcrum-wrap">
					<div class="container">
						<div class="breadcrum-inner">
							<ul>
								<li><a href="Default.aspx"><i class="fa fa-home"></i></a><i class="fa fa-angle-right"></i></li>
								<li><a href="#"><asp:Label ID="lblType1" runat="server" Text=""></asp:Label></a><i class="fa fa-angle-right"></i></li>
								<%--<li><a href="#">News Detail</a></li>--%>
							</ul>
						</div>
					</div>
				</div>

    <div class="content-inner-wrap">
					<div class="container">
						<div class="section-title">
							<h2><asp:Label ID="lblType2" runat="server" Text=""></asp:Label></h2>
						</div>
						<div class="col-md-12 pad-0 newsdetail-col12">
							<div class="col-md-6 newsdetail-col6">
								<div class="newsdetailimg">
                                    <asp:Image ID="imgd" runat="server" CssClass="newsdetailimg" />
									
								</div>
							</div>
							<div class="col-md-6 newsdetail-col6">
								<div class="newsdetail-descriptions">
									<h1><asp:Label ID="lblTitle" runat="server" Text=""></asp:Label></h1>
									<div class="news-post-meta">
										<ul class="newspost-infolist">
											<li><i class="fa fa-eye"></i> <asp:Label ID="lblViews" runat="server" Text=""> </asp:Label></li>
											<li><i class="fa fa-calendar"></i> <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></li>										
										</ul>
									</div>
									<p class="newsdetail-desc">
                                        <asp:Label ID="lblDes1" runat="server" Text=""></asp:Label>
                                    </p>
								</div>
							</div>
						</div>
					</div>
				</div>




    

   


   




   
</asp:Content>

