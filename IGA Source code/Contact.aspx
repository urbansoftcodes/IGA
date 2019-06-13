<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <%--  <script type="text/javascript">
        $("#mcontact").ready(function () {
        var aa = document.getElementById("mcontact");
        var s = document.createElement('script');
        s.setAttribute('src', "assets/js/custom.js");
       // document.body.appendChild(s);
        aa.appendChild(s);
        });
    </script>--%>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- content goes here -->
				<div class="banner-wrap" style="background-image:url('assets/images/Contact-Banner.jpg');">
					<div class="container"><h2 class="banner-title">
                        <asp:Label ID="lblProducts" runat="server" Text="contact us"></asp:Label>
                  <asp:Label ID="lblpid" runat="server" Text="" Visible="false"></asp:Label>
					                       </h2></div>
				</div>
				<div class="breadcrum-wrap">
					<div class="container">
						<div class="breadcrum-inner">
							<ul>
								<li><a href="Default.aspx"><i class="fa fa-home"></i></a><i class="fa fa-angle-right"></i></li>
								<li><a href="#">
                                    <asp:Label ID="lblProducts1" runat="server" Text="contact us"></asp:Label>
								    </a></li>
							</ul>
						</div>
					</div>
				</div>
				<div class="content-inner-wrap">
					<div class="container">
						<div class="section-title">
							<h2><asp:Label ID="lblProducts2" runat="server" Text="contact us"></asp:Label></h2>
						</div>
						<div class="col-md-12 contact-col12">
                            <div runat="server" id="haus">
							

                                </div>



							
							<div class="row contact-innerrow">
								<div class="contact-fom">
									<div>
										<div class="col-md-12 pad-0">
											<div class="col-md-6">
												<div class="form-group">
                                                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
												</div>
											</div>
											<div class="col-md-6">
												<div class="form-group">
													<asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:TextBox ID="txtMno" runat="server"  CssClass="form-control" Visible="false"></asp:TextBox>
                                                    <asp:TextBox ID="txtSub" runat="server"  CssClass="form-control" Visible="false" Text="Enquiry"></asp:TextBox>
												</div>
											</div>
										</div>
										<div class="col-md-12">
											<div class="form-group">
												<asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                                <asp:TextBox ID="txtMsg" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
											</div>
										</div>
										<div class="col-md-12 contact-btncol12">
											<asp:LinkButton ID="lbtnSubmit" runat="server" OnClick="lbtnSubmit_Click" CssClass="iga-btn" >Submit</asp:LinkButton>	
                                          
                                            
                                <asp:Label ID="lbler" runat="server" Text="" ForeColor="Maroon"></asp:Label>
										
										</div>
									</div>
								</div>
							</div>
                            <div class="row contactmap-row contact-map-container">
                                <div class="section-title contact-map-title">
									<h2><span>
                                        <asp:Label ID="lblfvenu" runat="server" Text="Forum Venue"></asp:Label>
                                        </span></h2>
								</div>
								<div id="map"></div>
						
							</div>

						</div>
					</div>
					
				</div>


   <%-- <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
	<!-- Latest compiled JavaScript -->
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCPr_PaTg0NC1soJdiWfC74nnurdHRSydE"></script>
	<script src="assets/js/custom.js"></script>--%>
	<%--<script type='text/javascript' src='assets/js/jquery_menu.js'></script>--%>
    	



</asp:Content>

