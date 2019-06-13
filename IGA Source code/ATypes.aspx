<%@ Page Title="" Language="C#" MasterPageFile="~/amain.master" AutoEventWireup="true" CodeFile="ATypes.aspx.cs" Inherits="ATypes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
    <div class="page-header">
							<h1>Types</h1>
						</div><!-- /.page-header -->
						<!----Body content---->
<div class="row">
									<div class="col-xs-12">
                                        <asp:LinkButton ID="lbtnAddNew" runat="server" CssClass="btn btn-info" OnClick="lbtnAddNew_Click"><i class="ace-icon fa fa-plus bigger-110"></i> Add New</asp:LinkButton>

										<div class="clearfix">
											<div class="pull-right tableTools-container"></div>
										</div>
										<div class="table-header">
											List of Types
										</div>

										<!-- div.table-responsive -->

										<!-- div.dataTables_borderWrap -->
										<div>
                                            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" AllowSorting="true" OnSorting="gv_Sorting" OnPageIndexChanging="gv_PageIndexChanging" >
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                    <ItemTemplate>
                        <asp:Label ID="lblvsno" runat="server" Text=" <%# Container.DataItemIndex + 1 %>"></asp:Label>
                        <asp:Label ID="lblveid" runat="server" Text='<%# Eval("TypesId") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                                    <asp:BoundField DataField="TypesId" HeaderText="Id" ReadOnly="True" SortExpression="TypesId"/> 
                                                     <asp:BoundField DataField="TypesName" HeaderText="Type" ReadOnly="True" SortExpression="TypesName"/> 
                                                     <asp:BoundField DataField="TypesName1" HeaderText="Type Language" ReadOnly="True" SortExpression="TypesName1"/> 

                                               
                                                    <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnEdit" runat="server" ToolTip="Edit" CssClass="green" OnClick="lbtnEdit_Click"><i class="ace-icon fa fa-pencil bigger-130"></i></asp:LinkButton>
                       <%-- <asp:LinkButton ID="lbtnDelete" runat="server" ToolTip="Delete" CssClass="red"><i class="ace-icon fa fa-trash-o bigger-130"></i></asp:LinkButton>--%>
                    </ItemTemplate>
                </asp:TemplateField>
                                                    
                                                     </Columns>
                                            </asp:GridView>
										
										</div>
									</div>
								</div>




</asp:Content>

