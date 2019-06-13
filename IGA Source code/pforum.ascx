<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pforum.ascx.cs" Inherits="pforum" %>
<div class="fixed-side-bar english">
<div class="fixed-text">
    <h3>
        <asp:Label ID="lblPForum" runat="server" Text="Previous Forums"></asp:Label>
        </h3>
</div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

       
<div class="fixed-inside-content">
    <p><asp:Label ID="lblYear" runat="server" Text="Year"></asp:Label>
        </p>
    <!--<a href="#" id="" class="main-click tab-forums">Previous Forums</a>-->

    <asp:Repeater ID="dlSpeak" runat="server" OnItemDataBound="dlSpeak_ItemDataBound"  OnItemCommand="dlSpeak_ItemCommand">
                                         <HeaderTemplate>
                                           <ul class="tab-forums-cnt">
                                         </HeaderTemplate>
   
<ItemTemplate>
    
    <li><asp:Label ID="lblCategoryId" runat="server" Text='<%# Eval("CategoryId") %>' Visible="false"></asp:Label>
        <%--<a href='Forums.aspx'>--%>
        
             <asp:LinkButton ID="lblCTitle" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CategoryId") %>' CommandName="view" Text='<%# Eval("CategoryName") %>' ></asp:LinkButton>
                <asp:LinkButton ID="lblCTitle1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CategoryId") %>' CommandName="view" Text='<%# Eval("CategoryName1") %>'></asp:LinkButton>
                


            <%-- <asp:Label ID="lblCTitle" runat="server" Text='<%# Eval("CategoryName") %>'></asp:Label>
    <asp:Label ID="lblCTitle1" runat="server" Text='<%# Eval("CategoryName1") %>'></asp:Label>--%>
        <%--</a>--%></li>
    



    
</ItemTemplate>
                                         <FooterTemplate>
                                             </ul>
                                         </FooterTemplate>

</asp:Repeater>

    
        
		
    <!--<a href="#" class="main-click">Previous Speakers</a>-->
</div>

             </ContentTemplate>
    </asp:UpdatePanel>
</div>