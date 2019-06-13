<%@ Page Title="" Language="C#" MasterPageFile="~/amain.master" AutoEventWireup="true" CodeFile="AEnquiries.aspx.cs" Inherits="AEnquiries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
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
                                            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" AllowSorting="true" OnSorting="gv_Sorting" OnPageIndexChanging="gv_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                    <ItemTemplate>
                        <asp:Label ID="lblvsno" runat="server" Text=" <%# Container.DataItemIndex + 1 %>"></asp:Label>
                        <asp:Label ID="lblveid" runat="server" Text='<%# Eval("RegId") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                                    <asp:BoundField DataField="FName" HeaderText="First Name" ReadOnly="True" SortExpression="FName"/> 
                                                     <asp:BoundField DataField="FaName" HeaderText="Family Name" ReadOnly="True" SortExpression="FaName"/> 
                                                     <asp:BoundField DataField="EMailId" HeaderText="EMail Id" ReadOnly="True" SortExpression="EMailId"/> 
                                                    <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" ReadOnly="True" SortExpression="CreatedDate"/> 
                                                    
                                                     <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnEdit" runat="server" ToolTip="Edit" CssClass="green" OnClick="lbtnEdit_Click"><i class="ace-icon fa fa-eye bigger-130"></i></asp:LinkButton>
                     
                    </ItemTemplate>

</asp:TemplateField>
                                                     </Columns>
                                            </asp:GridView>
										
										</div>
									</div>
								</div>




</asp:Content>

