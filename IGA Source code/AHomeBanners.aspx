<%@ Page Title="" Language="C#" MasterPageFile="~/amain.master" AutoEventWireup="true" CodeFile="AHomeBanners.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="clearfix">
        <div class="pull-right tableTools-container"></div>
    </div>
    <div class="table-header">
        List of Home Banners For Mobile APP
    </div>
    <div class="form-group col-lg-3">
        <label class="control-label col-xs-12 no-padding-right" for="Comapany Name"></label>

        <div class="col-xs-12 col-sm-10">
            <div class="clearfix">
                <asp:LinkButton ID="lbtnAddNew" runat="server" CssClass="btn btn-info" OnClick="lbtnAddNew_Click"><i class="ace-icon fa fa-plus bigger-110"></i> Add New</asp:LinkButton>
            </div>
        </div>
    </div>

    <!-- div.table-responsive -->

    <!-- div.dataTables_borderWrap -->
    <div>
        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" AllowSorting="true" OnSorting="gv_Sorting" OnPageIndexChanging="gv_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText="S.No">
                    <ItemTemplate>
                        <asp:Label ID="lblvsno" runat="server" Text=" <%# Container.DataItemIndex + 1 %>"></asp:Label>
                        <asp:Label ID="lblveid" runat="server" Text='<%# Eval("HomeBannerID") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Title_English" HeaderText="English Title" ReadOnly="True" SortExpression="ContentId" />

                <asp:BoundField DataField="Title_Arabic" HeaderText="Arabic Title" ReadOnly="True" SortExpression="ContentTitle" />

                <asp:BoundField DataField="BannerOrder" HeaderText="Banner Order" ReadOnly="True" SortExpression="ContentTitle1" />
                <asp:BoundField DataField="CreatedDate" HeaderText="Date" ReadOnly="True" SortExpression="CreatedDate" />


                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnEdit" runat="server" ToolTip="Edit" CssClass="green" OnClick="lbtnEdit_Click"><i class="ace-icon fa fa-pencil bigger-130"></i></asp:LinkButton>
                        <asp:LinkButton ID="lbtnDelete" runat="server" ToolTip="Delete" CssClass="red" OnClick="lbtnDelete_Click"><i class="ace-icon fa fa-trash bigger-130"></i></asp:LinkButton>
                        <%-- <asp:LinkButton ID="lbtnDelete" runat="server" ToolTip="Delete" CssClass="red"><i class="ace-icon fa fa-trash-o bigger-130"></i></asp:LinkButton>--%>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

    </div>
</asp:Content>

