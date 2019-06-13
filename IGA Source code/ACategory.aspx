<%@ Page Title="" Language="C#" MasterPageFile="~/amain.master" AutoEventWireup="true" CodeFile="ACategory.aspx.cs" Inherits="ACategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     
    <div class="page-header">
							<h1>Category</h1>
						</div><!-- /.page-header -->
						<!----Body content---->
<div class="row">
									<div class="col-xs-12">
                                        <div class="row">       
                                                        <div class="form-group col-lg-6">
																<label class="control-label col-xs-12 no-padding-right" for="Comapany Name"></label>

																<div class="col-xs-12 col-sm-10">
																	<div class="clearfix">
                                                                        <asp:DropDownList ID="ddlTypes" runat="server" CssClass="input-medium1 form-control chzn-select" AppendDataBoundItems="true" data-placeholder="Choose a Types..." OnSelectedIndexChanged="ddlTypes_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                                        <asp:Label ID="lblTypes" runat="server" Text="" ForeColor="Maroon"></asp:Label>
																	</div>
																</div>
															</div>                                                   
                                                        <div class="form-group col-lg-4">
																<label class="control-label col-xs-12 no-padding-right" for="Comapany Name"></label>

																<div class="col-xs-12 col-sm-10">
																	<div class="clearfix">
                                                                         <asp:LinkButton ID="lbtnAddNew" runat="server" CssClass="btn btn-info" OnClick="lbtnAddNew_Click"><i class="ace-icon fa fa-plus bigger-110"></i> Add New</asp:LinkButton>

																	</div>
																</div>
															</div>   
                                                            
                                                           
                                                            
                                                                                                               
                                                        </div>


                                       
										<div class="clearfix">
											<div class="pull-right tableTools-container"></div>
										</div>
										<div class="table-header">
											List of Category
										</div>

										<!-- div.table-responsive -->

										<!-- div.dataTables_borderWrap -->
										<div>
                                            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" AllowSorting="true" OnSorting="gv_Sorting" OnPageIndexChanging="gv_PageIndexChanging" PageSize="10">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                    <ItemTemplate>
                        <asp:Label ID="lblvsno" runat="server" Text=" <%# Container.DataItemIndex + 1 %>"></asp:Label>
                        <asp:Label ID="lblveid" runat="server" Text='<%# Eval("CategoryId") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                                    <asp:BoundField DataField="CategoryId" HeaderText="Id" ReadOnly="True" SortExpression="CategoryId"/> 
                                                    <asp:BoundField DataField="TypesName" HeaderText="Type" ReadOnly="True" SortExpression="TypesName"/> 
                                                     <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="True" SortExpression="CategoryName"/> 
                                                     <asp:BoundField DataField="CategoryName1" HeaderText="Category Language" ReadOnly="True" SortExpression="CategoryName1"/> 

                                               
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

