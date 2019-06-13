<%@ Page Title="" Language="C#" MasterPageFile="~/amain.master" AutoEventWireup="true" CodeFile="AContents.aspx.cs" Inherits="AContents" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="page-header">
        <h1>Contents</h1>
    </div>
    <!-- /.page-header -->
    <!----Body content---->
    <div class="row">
        <div class="col-xs-12">
            <div class="row">
                <div class="form-group col-lg-4">
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
                            <asp:DropDownList ID="ddlCategory" runat="server" CssClass="input-medium1 form-control chzn-select" AppendDataBoundItems="true" data-placeholder="Choose a Category..." OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:Label ID="lblCategory" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="form-group col-lg-2" style="display: none;">
                    <label class="control-label col-xs-12 no-padding-right" for="Comapany Name"></label>

                    <div class="col-xs-12 col-sm-10">
                        <div class="clearfix">
                            <asp:DropDownList ID="ddlSubCategory" runat="server" CssClass="input-medium1 form-control chzn-select" AppendDataBoundItems="true" data-placeholder="Choose a Sub Category..." OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:Label ID="lblSubCategory" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="form-group col-lg-2" style="display: none;">
                    <label class="control-label col-xs-12 no-padding-right" for="Comapany Name"></label>

                    <div class="col-xs-12 col-sm-10">
                        <div class="clearfix">
                            <asp:DropDownList ID="ddlSCategorySub" runat="server" CssClass="input-medium1 form-control chzn-select" AppendDataBoundItems="true" data-placeholder="Choose a Sub Category Sub..." OnSelectedIndexChanged="ddlSCategorySub_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            <asp:Label ID="lblSCategorySub" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="form-group col-lg-3">
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
                List of Contents
            </div>

            <!-- div.table-responsive -->

            <!-- div.dataTables_borderWrap -->
            <div>
                <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" AllowSorting="true" OnSorting="gv_Sorting" OnPageIndexChanging="gv_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="S.No">
                            <ItemTemplate>
                                <asp:Label ID="lblvsno" runat="server" Text=" <%# Container.DataItemIndex + 1 %>"></asp:Label>
                                <asp:Label ID="lblveid" runat="server" Text='<%# Eval("ContentId") %>' Visible="False"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ContentId" HeaderText="Id" ReadOnly="True" SortExpression="ContentId" />

                        <asp:BoundField DataField="ContentTitle" HeaderText="Title" ReadOnly="True" SortExpression="ContentTitle" />

                        <asp:BoundField DataField="ContentTitle1" HeaderText="Title Language" ReadOnly="True" SortExpression="ContentTitle1" />
                        <asp:BoundField DataField="CreatedDate" HeaderText="Date" ReadOnly="True" SortExpression="CreatedDate" />


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

