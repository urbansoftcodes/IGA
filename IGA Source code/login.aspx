<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
		<meta charset="utf-8" />
		<title>Urbansoft - CMS</title>

		<meta name="description" content="User login page" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />

		<!-- bootstrap & fontawesome -->
		<link rel="stylesheet" href="assets1/css/bootstrap.min.css" />
		<link rel="stylesheet" href="assets1/font-awesome/4.5.0/css/font-awesome.min.css" />

		<!-- text fonts -->
		<link rel="stylesheet" href="assets1/css/fonts.googleapis.com.css" />

		<!-- ace styles -->
		<link rel="stylesheet" href="assets1/css/ace.min.css" />

		<!--[if lte IE 9]>
			<link rel="stylesheet" href="assets1/css/ace-part2.min.css" />
		<![endif]-->
		<link rel="stylesheet" href="assets1/css/ace-rtl.min.css" />

		<!--[if lte IE 9]>
		  <link rel="stylesheet" href="assets1/css/ace-ie.min.css" />
		<![endif]-->

		<!-- HTML5shiv and Respond.js for IE8 to support HTML5 elements and media queries -->

		<!--[if lte IE 8]>
		<script src="assets1/js/html5shiv.min.js"></script>
		<script src="assets1/js/respond.min.js"></script>
		<![endif]-->

     <script type="text/javascript">

         function SubmitsEncry() {
             var txtUserName = document.getElementById("<%=txtuid.ClientID %>").value.trim();
            var txtpassword = document.getElementById("<%=txtpwd.ClientID %>").value.trim();
            var a = SHA256(txtpassword)
            var b = document.getElementById("<%=HDsalt.ClientID %>").value.trim();
            var c = a + b;
            var d = SHA256(c);
            document.getElementById("<%=HDPassword.ClientID %>").value = d;
            document.getElementById("<%=HDusername.ClientID %>").value = txtUserName;
            document.getElementById("<%=txtuid.ClientID %>").value = "";
            document.getElementById("<%=txtpwd.ClientID %>").value = "";

         }







         function SHA256(s) {


             var chrsz = 8;

             var hexcase = 0;


             function safe_add(x, y) {

                 var lsw = (x & 0xFFFF) + (y & 0xFFFF);

                 var msw = (x >> 16) + (y >> 16) + (lsw >> 16);

                 return (msw << 16) | (lsw & 0xFFFF);

             }


             function S(X, n) { return (X >>> n) | (X << (32 - n)); }

             function R(X, n) { return (X >>> n); }

             function Ch(x, y, z) { return ((x & y) ^ ((~x) & z)); }

             function Maj(x, y, z) { return ((x & y) ^ (x & z) ^ (y & z)); }

             function Sigma0256(x) { return (S(x, 2) ^ S(x, 13) ^ S(x, 22)); }

             function Sigma1256(x) { return (S(x, 6) ^ S(x, 11) ^ S(x, 25)); }

             function Gamma0256(x) { return (S(x, 7) ^ S(x, 18) ^ R(x, 3)); }

             function Gamma1256(x) { return (S(x, 17) ^ S(x, 19) ^ R(x, 10)); }


             function core_sha256(m, l) {

                 var K = new Array(0x428A2F98, 0x71374491, 0xB5C0FBCF, 0xE9B5DBA5, 0x3956C25B, 0x59F111F1, 0x923F82A4, 0xAB1C5ED5, 0xD807AA98, 0x12835B01, 0x243185BE, 0x550C7DC3, 0x72BE5D74, 0x80DEB1FE, 0x9BDC06A7, 0xC19BF174, 0xE49B69C1, 0xEFBE4786, 0xFC19DC6, 0x240CA1CC, 0x2DE92C6F, 0x4A7484AA, 0x5CB0A9DC, 0x76F988DA, 0x983E5152, 0xA831C66D, 0xB00327C8, 0xBF597FC7, 0xC6E00BF3, 0xD5A79147, 0x6CA6351, 0x14292967, 0x27B70A85, 0x2E1B2138, 0x4D2C6DFC, 0x53380D13, 0x650A7354, 0x766A0ABB, 0x81C2C92E, 0x92722C85, 0xA2BFE8A1, 0xA81A664B, 0xC24B8B70, 0xC76C51A3, 0xD192E819, 0xD6990624, 0xF40E3585, 0x106AA070, 0x19A4C116, 0x1E376C08, 0x2748774C, 0x34B0BCB5, 0x391C0CB3, 0x4ED8AA4A, 0x5B9CCA4F, 0x682E6FF3, 0x748F82EE, 0x78A5636F, 0x84C87814, 0x8CC70208, 0x90BEFFFA, 0xA4506CEB, 0xBEF9A3F7, 0xC67178F2);

                 var HASH = new Array(0x6A09E667, 0xBB67AE85, 0x3C6EF372, 0xA54FF53A, 0x510E527F, 0x9B05688C, 0x1F83D9AB, 0x5BE0CD19);

                 var W = new Array(64);

                 var a, b, c, d, e, f, g, h, i, j;

                 var T1, T2;


                 m[l >> 5] |= 0x80 << (24 - l % 32);

                 m[((l + 64 >> 9) << 4) + 15] = l;


                 for (var i = 0; i < m.length; i += 16) {

                     a = HASH[0];

                     b = HASH[1];

                     c = HASH[2];

                     d = HASH[3];

                     e = HASH[4];

                     f = HASH[5];

                     g = HASH[6];

                     h = HASH[7];


                     for (var j = 0; j < 64; j++) {

                         if (j < 16) W[j] = m[j + i];

                         else W[j] = safe_add(safe_add(safe_add(Gamma1256(W[j - 2]), W[j - 7]), Gamma0256(W[j - 15])), W[j - 16]);


                         T1 = safe_add(safe_add(safe_add(safe_add(h, Sigma1256(e)), Ch(e, f, g)), K[j]), W[j]);

                         T2 = safe_add(Sigma0256(a), Maj(a, b, c));


                         h = g;

                         g = f;

                         f = e;

                         e = safe_add(d, T1);

                         d = c;

                         c = b;

                         b = a;

                         a = safe_add(T1, T2);

                     }


                     HASH[0] = safe_add(a, HASH[0]);

                     HASH[1] = safe_add(b, HASH[1]);

                     HASH[2] = safe_add(c, HASH[2]);

                     HASH[3] = safe_add(d, HASH[3]);

                     HASH[4] = safe_add(e, HASH[4]);

                     HASH[5] = safe_add(f, HASH[5]);

                     HASH[6] = safe_add(g, HASH[6]);

                     HASH[7] = safe_add(h, HASH[7]);

                 }

                 return HASH;

             }


             function str2binb(str) {

                 var bin = Array();

                 var mask = (1 << chrsz) - 1;

                 for (var i = 0; i < str.length * chrsz; i += chrsz) {

                     bin[i >> 5] |= (str.charCodeAt(i / chrsz) & mask) << (24 - i % 32);

                 }

                 return bin;

             }


             function Utf8Encode(string) {

                 string = string.replace(/\r\n/g, "\n");

                 var utftext = "";


                 for (var n = 0; n < string.length; n++) {


                     var c = string.charCodeAt(n);


                     if (c < 128) {

                         utftext += String.fromCharCode(c);

                     }

                     else if ((c > 127) && (c < 2048)) {

                         utftext += String.fromCharCode((c >> 6) | 192);

                         utftext += String.fromCharCode((c & 63) | 128);

                     }

                     else {

                         utftext += String.fromCharCode((c >> 12) | 224);

                         utftext += String.fromCharCode(((c >> 6) & 63) | 128);

                         utftext += String.fromCharCode((c & 63) | 128);

                     }


                 }


                 return utftext;

             }


             function binb2hex(binarray) {

                 var hex_tab = hexcase ? "0123456789ABCDEF" : "0123456789abcdef";

                 var str = "";

                 for (var i = 0; i < binarray.length * 4; i++) {

                     str += hex_tab.charAt((binarray[i >> 2] >> ((3 - i % 4) * 8 + 4)) & 0xF) +

                         hex_tab.charAt((binarray[i >> 2] >> ((3 - i % 4) * 8)) & 0xF);

                 }

                 return str;

             }


             s = Utf8Encode(s);

             return binb2hex(core_sha256(str2binb(s), s.length * chrsz));

         }

    </script>



</head>
<body class="login-layout">
    <form id="form1" runat="server">
    <div class="main-container">
			<div class="main-content">
				<div class="row">
					<div class="col-sm-10 col-sm-offset-1">
						<div class="login-container">
							<div class="center">
								<h1>
									<%--<img src="assets1/images/softmaxsolutions-logo.png" alt="soft max solutions" height="40" />--%>
                                   
									<span class="red"></span>
									<span class="white" id="id-text2">Urbansoft</span>
								</h1>
								<h4 class="blue" id="id-company-text">&copy; iGA</h4>
							</div>

							<div class="space-6"></div>

							<div class="position-relative">
								<div id="login-box" class="login-box visible widget-box no-border">
									<div class="widget-body">
										<div class="widget-main">
											<h4 class="header blue lighter bigger">
												<i class="ace-icon fa fa-coffee green"></i>
												Please Enter Your Information
											</h4>

											<div class="space-6"></div>

											<div>
												<fieldset>
													<label class="block clearfix">
														<span class="block input-icon input-icon-right">
                                                            <asp:TextBox ID="txtuid" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
															
															<i class="ace-icon fa fa-user"></i>
                                                            <asp:HiddenField ID="HDusername" runat="server" />
                                                            <asp:HiddenField ID="HDsalt" runat="server" />
														</span>
													</label>

													<label class="block clearfix">
														<span class="block input-icon input-icon-right">
                                                            <asp:TextBox ID="txtpwd" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
															
															<i class="ace-icon fa fa-lock"></i>
                                                            <asp:HiddenField ID="HDPassword" runat="server" />
														</span>
													</label>

													<div class="space"></div>

													<div class="clearfix">
														<label class="inline">
															<span class="lbl"> <asp:Label ID="lbler" runat="server" Text="" ForeColor="Maroon"></asp:Label></span>
														</label>
                                                        <asp:LinkButton ID="lbtnlogin" runat="server" CssClass="width-35 pull-right btn btn-sm btn-primary" OnClick="lbtnlogin_Click"  OnClientClick="return SubmitsEncry();"><i class="ace-icon fa fa-key"></i>
															<span class="bigger-110">Login</span></asp:LinkButton>
														
													</div>

													<div class="space-4"></div>
												</fieldset>
											</div>

											

											<div class="space-6"></div>

											
										</div><!-- /.widget-main -->

										<div class="toolbar clearfix">
											<div>
												<a href="#" class="forgot-password-link">
													<i class="ace-icon fa fa-arrow-left"></i>
													Developed By
												</a>
											</div>

											<div>
												<a href="#" class="user-signup-link">
													Urbansoft
													<i class="ace-icon fa fa-arrow-right"></i>
												</a>
											</div>
										</div>
									</div><!-- /.widget-body -->
								</div><!-- /.login-box -->

								
							</div><!-- /.position-relative -->

							<div class="navbar-fixed-top align-right">
								<br />
								&nbsp;
								<a id="btn-login-dark" href="#">Dark</a>
								&nbsp;
								<span class="blue">/</span>
								&nbsp;
								<a id="btn-login-blur" href="#">Blur</a>
								&nbsp;
								<span class="blue">/</span>
								&nbsp;
								<a id="btn-login-light" href="#">Light</a>
								&nbsp; &nbsp; &nbsp;
							</div>
						</div>
					</div><!-- /.col -->
				</div><!-- /.row -->
			</div><!-- /.main-content -->
		</div><!-- /.main-container -->

		<!-- basic scripts -->

		<!--[if !IE]> -->
		<script src="assets1/js/jquery-2.1.4.min.js"></script>

		<!-- <![endif]-->

		<!--[if IE]>
<script src="assets1/js/jquery-1.11.3.min.js"></script>
<![endif]-->
		<script type="text/javascript">
			if('ontouchstart' in document.documentElement) document.write("<script src='assets1/js/jquery.mobile.custom.min.js'>"+"<"+"/script>");
		</script>

		<!-- inline scripts related to this page -->
		<script type="text/javascript">
			jQuery(function($) {
			 $(document).on('click', '.toolbar a[data-target]', function(e) {
				e.preventDefault();
				var target = $(this).data('target');
				$('.widget-box.visible').removeClass('visible');//hide others
				$(target).addClass('visible');//show target
			 });
			});
			
			
			
			//you don't need this, just used for changing background
			jQuery(function($) {
			 $('#btn-login-dark').on('click', function(e) {
				$('body').attr('class', 'login-layout');
				$('#id-text2').attr('class', 'white');
				$('#id-company-text').attr('class', 'blue');
				
				e.preventDefault();
			 });
			 $('#btn-login-light').on('click', function(e) {
				$('body').attr('class', 'login-layout light-login');
				$('#id-text2').attr('class', 'grey');
				$('#id-company-text').attr('class', 'blue');
				
				e.preventDefault();
			 });
			 $('#btn-login-blur').on('click', function(e) {
				$('body').attr('class', 'login-layout blur-login');
				$('#id-text2').attr('class', 'white');
				$('#id-company-text').attr('class', 'light-blue');
				
				e.preventDefault();
			 });
			 
			});
		</script>













    </form>
</body>
</html>
