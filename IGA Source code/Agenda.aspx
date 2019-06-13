<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="Agenda.aspx.cs" Inherits="Agenda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="assets/css/flexslider.css" type="text/css" media="screen" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- content goes here -->
    <div class="banner-wrap inner-res-banner-2" style="background-image: url('assets/images/About-BAnner.jpg');">
        <div class="container">
            <h2 class="banner-title">
                <asp:Label ID="lblAgenda" runat="server" Text="Agenda"></asp:Label></h2>
        </div>
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
    <div class="content-inner-wrap">
        <div class="container">
            <div class="section-title">
                <h2>
                    <asp:Label ID="lblAgenda2" runat="server" Text="Agenda"></asp:Label></h2>
            </div>
            <!------ agenda tab ---------->
            <div class="agenda-container">
                <div class="agenda-row">
                    <div class="col-md-12 agenda-tab-menu">
                        <!-- Nav tabs -->
                        <div class="card">
                            <div class="agenda-tab-bg">

                                <asp:Repeater ID="dlLatest1" runat="server" OnItemDataBound="dlLatest1_ItemDataBound" OnItemCommand="dlLatest1_ItemCommand">

                                    <HeaderTemplate>
                                        <ul class="nav nav-tabs" role="tablist">
                                    </HeaderTemplate>
                                    <ItemTemplate>

                                        <li role="presentation" class="" runat="server" id="yforum">
                                            <%--<a href="#day1" aria-controls="day1" role="tab" data-toggle="tab">--%>
                                            <div class="agenda-day-nav">
                                                <p class="day-count">
                                                    <asp:Label ID="lblCategoryId" runat="server" Text='<%# Container.ItemIndex + 1 %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblProductId" runat="server" Text='<%# Eval("CategoryId") %>' Visible="false"></asp:Label>

                                                    <asp:LinkButton ID="lblTitle" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CategoryId") %>' CommandName="view" Text='<%# Eval("CategoryName") %>'></asp:LinkButton>
                                                    <asp:LinkButton ID="lblTitle1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CategoryId") %>' CommandName="view" Text='<%# Eval("CategoryName1") %>'></asp:LinkButton>

                                                </p>
                                                <p class="agenda-date">
                                                    <asp:LinkButton ID="lbtnDay" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CategoryId") %>' CommandName="view" Text=''></asp:LinkButton>

                                                </p>
                                            </div>
                                            <%--</a>--%>
                                        </li>





                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </ul>
                                    </FooterTemplate>
                                </asp:Repeater>



                            </div>
                            <!-- Tab panes -->
                            <div class="tab-content">
                                <div role="tabpanel" class="tab-pane active" id="day1">

                                    <asp:Repeater ID="dlCont" runat="server" OnItemDataBound="dlCont_ItemDataBound">


                                        <ItemTemplate>

                                            <div class="agenda-content">
                                                <div class="agenda-date-left">
                                                    <%--<img src='<%# Eval("DImage") %>' alt="">--%>
                                                    <p class="time">
                                                        <asp:Label ID="lblTime" runat="server" Text='<%# Eval("ADetail") %>'></asp:Label>
                                                        <asp:Label ID="lblTime1" runat="server" Text='<%# Eval("ADetail1") %>'></asp:Label>
                                                    </p>
                                                </div>
                                                <div class="agenda-desc">

                                                    <div class="agenda-desc-left">
                                                        <h2>
                                                            <asp:Label ID="lblCategoryId" runat="server" Text='<%# Eval("ContentId") %>' Visible="false"></asp:Label>
                                                            <asp:Label ID="lblCTitle" runat="server" Text='<%# Eval("ContentTitle") %>'></asp:Label>
                                                            <asp:Label ID="lblCTitle1" runat="server" Text='<%# Eval("ContentTitle1") %>'></asp:Label></h2>
                                                        <p>

                                                            <asp:Label ID="lblShort" runat="server" Text='<%# Eval("ContentDetail") %>'></asp:Label>
                                                            <asp:Label ID="lblShort1" runat="server" Text='<%# Eval("ContentDetail1") %>'></asp:Label>
                                                        </p>

                                                    </div>
                                                    <div class="agenda-desc-icon ">
                                                        <asp:Label ID="lbldimg" runat="server" Text='<%# Eval("DImage") %>' Visible="false"></asp:Label>
                                                        <a href='<%# Eval("DImage") %>' runat="server" id="dimg">
                                                            <img src="assets/images/download.png" alt=""></a>
                                                        <p>
                                                            <asp:Label ID="lblpresent" runat="server" Text="Presentation"></asp:Label>
                                                        </p>
                                                    </div>







                                                </div>
                                            </div>





                                        </ItemTemplate>


                                    </asp:Repeater>






                                </div>



                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>

