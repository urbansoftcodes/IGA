<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="Committee.aspx.cs" Inherits="Committee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="assets/css/flexslider.css" type="text/css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <!-- content goes here -->
			<div class="banner-wrap" style="background-image:url('assets/images/About-Banner-1.jpg');">
				<div class="container"><h2 class="banner-title"><asp:Label ID="lblAgenda" runat="server" Text="Agenda"></asp:Label></h2></div>
			</div>
			<div class="breadcrum-wrap">
				<div class="container">
					<div class="breadcrum-inner">
						<ul>
							<li><a href="Default.aspx"><i class="fa fa-home"></i></a><i class="fa fa-angle-right"></i></li>
							<li><a href="#">
                                <asp:Label ID="lblpid" runat="server" Text="" Visible="false"></asp:Label>
                                <asp:Label ID="lblAgenda1" runat="server" Text="Agenda"></asp:Label></a></li>
						</ul>
					</div>
				</div>
			</div>
			






     <asp:Repeater ID="dlLatest" runat="server" OnItemDataBound="dlLatest_ItemDataBound">
  
<ItemTemplate>



    <!-- excutive Commitee Start  -->
				<div class="content-inner-wrap excutive_commitee">
					<div class="container">
						<div class="section-title">
							<h2>  <span>
                                <asp:Label ID="lblCategoryId" runat="server" Text='<%# Eval("CategoryId") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
                                <asp:Label ID="lblTitle1" runat="server" Text='<%# Eval("CategoryName1") %>'></asp:Label>
                            </span></h2>
						</div>
						<div class="section-content">
                            <div class="speakers-list">
                                <asp:Repeater ID="dlLatest1" runat="server" OnItemDataBound="dlLatest1_ItemDataBound">
  
                                    <HeaderTemplate>
                                        <ul>
                                    </HeaderTemplate>
<ItemTemplate>

    <li>
		    						<div class="peakersimg">
                                        <img src='<%# Eval("DImage") %>' class="img-responsive">
		                            	     
		                        	</div>
									<div class="speakerstext">
										<h1><span><asp:Label ID="lblTitle" runat="server" Text='<%# Eval("ContentTitle") %>'></asp:Label>
                                <asp:Label ID="lblTitle1" runat="server" Text='<%# Eval("ContentTitle1") %>'></asp:Label></span></h1>
									<p>
	                                	<span>
                                            <asp:Label ID="lblShort" runat="server" Text='<%# Eval("ShortContent") %>'></asp:Label>
                                <asp:Label ID="lblShort1" runat="server" Text='<%# Eval("ShortContent1") %>'></asp:Label>
	                                	</span>
	                                </p>
									<p>
										<span id="#"></span>
									</p>
									</div>
								</li>




    
  


    
   
		                     
</ItemTemplate>
<FooterTemplate>
    </ul>
</FooterTemplate>
</asp:Repeater>




                          
						</div>							
					</div>
				</div>
			</div>
			<!-- excutive Commitee end  -->












   



									
									
									

								
					


      


    
   
		                     
</ItemTemplate>

</asp:Repeater>




   

</asp:Content>

