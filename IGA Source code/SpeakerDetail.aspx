<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="SpeakerDetail.aspx.cs" Inherits="SpeakerDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Content-->
				<div class="container bio-page-container">
    <!-- breadcrum wrap-->
					<div class="breadcrum-wrap">
						<div class="container">
							<div class="breadcrum-inner">
								<ul>
									<li><a href="Default.aspx"><i class="fa fa-home"></i></a><i class="fa fa-angle-right"></i></li>
									<li>
                                        <asp:LinkButton ID="lblType" runat="server" OnClick="lblType_Click"></asp:LinkButton>
                                        <i class="fa fa-angle-right"></i></li>
									<li><a href="#"><asp:Label ID="lblCat" runat="server" Text=""></asp:Label> <asp:Label ID="lblType1" runat="server" Text=""></asp:Label></a></li>
								</ul>
							</div>
						</div>
					</div>
					<!-- End breadcrum wrap-->
					<div class="col-md-12">
						<div class="bio-header">
							<div class="image-block">
								<asp:Image ID="imgd" runat="server" CssClass="img-fluid" />					
							</div>
						</div>
						<div class="bio-info">
							<div class="bio-title">
								<h3>
									<asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
									</h3>
								<p class="bio-position"><asp:Label ID="lblShort" runat="server" Text=""></asp:Label></p>
								<p class="bio-position-sub"><asp:Label ID="lblMore" runat="server" Text=""></asp:Label></p>
								
							</div>							
							<div class="bio-content" runat="server" id="cdet">
								
							</div>
						</div>
					</div>
				</div>

</div>

</asp:Content>

