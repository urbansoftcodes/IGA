<%@ Page Title="" Language="C#" MasterPageFile="~/amain.master" AutoEventWireup="true" CodeFile="AEnquiry.aspx.cs" Inherits="AEnquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lblcid" runat="server" Text="" Visible="false"></asp:Label>
    <div class="page-header">
							<h1>Enquiries</h1>
						</div><!-- /.page-header -->
						<!----Body content---->
<div class="row">
									<div class="col-xs-12">
                                       
										<div class="clearfix">
											<div class="pull-right tableTools-container"></div>
										</div>
										<div class="table-header">
											List of Enquiries
										</div>

										<!-- div.table-responsive -->

										<!-- div.dataTables_borderWrap -->
										<div>


                                            <asp:Repeater ID="dlEnq" runat="server">
                                                <ItemTemplate>
                                                    <table style="width:740px;">
<tr>
	<td>Title</td>
	<td style="width:30%;"><%# Eval("NTitle") %></td>
</tr>
<tr>
	<td>First Name</td>
	<td style="width:30%;"><%# Eval("FName") %></td>
</tr>
<tr>
	<td>Middle Name</td>
	<td style="width:30%;"><%# Eval("MName") %></td>
</tr>
<tr>
	<td>Family Name</td>
	<td style="width:30%;"><%# Eval("FaName") %></td>
</tr>
<tr>
	<td>Position</td>
	<td style="width:30%;"><%# Eval("RPosition") %></td>
</tr>
<tr>
	<td>Organization</td>
	<td style="width:30%;"><%# Eval("Orgn") %></td>
</tr>
<tr>
	<td>Department</td>
	<td style="width:30%;"><%# Eval("Country") %></td>
</tr>
<tr>
	<td>Address</td>
	<td style="width:30%;"><%# Eval("Address") %></td>
</tr>
<tr>
	<td>Country</td>
	<td style="width:30%;"><%# Eval("Dept") %></td>
</tr>
<tr>
	<td>State</td>
	<td style="width:30%;"><%# Eval("State") %></td>
</tr>
<tr>
	<td>City</td>
	<td style="width:30%;"><%# Eval("City") %></td>
</tr>
<tr>
	<td>P.O. Box No</td>
	<td style="width:30%;"><%# Eval("POBox") %></td>
</tr>
<tr>
	<td>Mobile</td>
	<td style="width:30%;"><%# Eval("MCountry") %>  <%# Eval("MCode") %>  <%# Eval("MNo") %></td>
</tr>
<tr>
	<td>Office Telephone</td>
	<td style="width:30%;"><%# Eval("OCountry") %>  <%# Eval("OCode") %>  <%# Eval("ONo") %> </td>
</tr>
<tr>
	<td>Fax</td>
	<td style="width:30%;"><%# Eval("FCountry") %>  <%# Eval("FCode") %>  <%# Eval("FNo") %></td>
</tr>
<tr>
	<td>Email</td>
	<td style="width:30%;"><%# Eval("EMailId") %></td>
</tr>
<tr>
	<td>Forum Delegate Registration Fees </td>
    <td style="width:30%;"><%# Eval("RFees") %></td>
</tr>
<tr>
	<td>Payment Methods</td>
	<td><%# Eval("RPay") %></td>
</tr>

</table>
                                                </ItemTemplate>
                                            </asp:Repeater>




                                          
										
										</div>
									</div>
								</div>




</asp:Content>

