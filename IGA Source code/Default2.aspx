<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
$(document).ready(function () {  
    var hashtag = 'kali'  
        var accessToken = '8307517323.3879a9e.8a3efe998c2341cbb0862eb117e8325a' //Write your access token  
    $.ajax({  
        url: 'https://api.instagram.com/v1/tags/' + hashtag + '/media/recent?count=33&access_token='+ accessToken +'',  
        dataType: 'jsonp',  
        type: 'GET',  
        success: function (data) {  
            console.log(data);  
            for (x in data.data) {  
                if (data.data[x].type == 'video') {  
                    //console.log("Video" + data.data[x].videos.standard_resolution.url);  
                    //See the browser console and add data as per requirements  
                    $('.instagram').append('<div style="border:1px solid orange"><video controls><source src="' + data.data[x].videos.standard_resolution.url + '" type="video/mp4"></video><span style="border:1px solid orange; dislay:block">Test1</span></div>');  
                } else if (data.data[x].type == 'image') {  
                    $('.instagram').append('<div style="border:1px solid orange"><img src="' + data.data[x].images.standard_resolution.url + '" ><span style="border:1px solid orange; display:block">"' + data.data[x].caption.text + '"</span><span style="border:1px solid orange; dislay:block">Test1</span></div>');  
                    //console.log("Image");  
                    //See the browser console and add data as per requirements  
                }  
            }  
        },  
        error: function (data) {  
            console.log(data);  
        }  
    })  
});  

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

            <%--<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>--%>
             <br /><br />

         <%--   <asp:Repeater ID="dlLatest1" runat="server">
  
<ItemTemplate>

   

        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Text") %>'></asp:Label>

										


    <br /><br />
   
  


    
   
		                     
</ItemTemplate>

</asp:Repeater>--%>
        </div>



       <%-- <asp:HyperLink runat="server" id="hl_email" Target="mailto:manish@simplygraphix.com?subject=Feedback for webdevelopersnotes.com&body=The Tips and Tricks section is great" Text="Send me an email" />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>--%>
    </div>


        <div class="instagram"></div>



    </form>
</body>
</html>
