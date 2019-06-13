<%@ Page Title="" Language="C#" MasterPageFile="~/amain.master" AutoEventWireup="true" CodeFile="AHomeBannerEdit.aspx.cs" Inherits="Default3" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<%@ Register Assembly="DatePickerControl" Namespace="DatePickerControl" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Label ID="lblcid" runat="server" Text="" Visible="false"></asp:Label>	

<div class="page-header">
							<h1>Home Banner</h1>
						</div><!-- /.page-header -->

<div class="row">
    <div class="col-lg-12">
        <section class="panel">
           
            <div class="panel-body">
               
                    <%-- tab 1--%>
									
												
													<div class="form-horizontal hide1" runat="server" id="vcont"> 
                                                        <%--<div class="row">       
                                                            
                                             <div class="form-group col-lg-3" style="display:none;">
																<label class="control-label col-xs-12 no-padding-right" for="Comapany Name"></label>

																<div class="col-xs-12 col-sm-10">
																	<div class="clearfix">
                                                                        <asp:DropDownList ID="ddlSubCategory" runat="server" CssClass="input-medium1 form-control chzn-select" AppendDataBoundItems="true" data-placeholder="Choose a Sub Category..." OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                                        <asp:Label ID="lblSubCategory" runat="server" Text="" ForeColor="Maroon"></asp:Label>
																	</div>
																</div>
															</div>   
                                             <div class="form-group col-lg-3" style="display:none;">
																<label class="control-label col-xs-12 no-padding-right" for="Comapany Name"></label>

																<div class="col-xs-12 col-sm-10">
																	<div class="clearfix">
                                                                        <asp:DropDownList ID="ddlSCategorySub" runat="server" CssClass="input-medium1 form-control chzn-select" AppendDataBoundItems="true" data-placeholder="Choose a Sub Category Sub..." OnSelectedIndexChanged="ddlSCategorySub_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                                        <asp:Label ID="lblSCategorySub" runat="server" Text="" ForeColor="Maroon"></asp:Label>
																	</div>
																</div>
															</div>
                                                       
                                                            
                                                           
                                                            
                                                                                                               
                                                        </div>--%>

                                                        <div class="row"> 
                                                            

                                                        <div class="form-group col-lg-6">
                                                        <label class="control-label col-xs-12 no-padding-right required" for="email">Title:</label>
                                                        <div class="col-xs-12 col-sm-10">
                                                            <div class="clearfix">
                                                               <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                <asp:Label ID="lblTitle" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                        <div class="form-group col-lg-6">
																<label class="control-label col-xs-12 no-padding-right" for="Comapany Name">Title Language:</label>

											     		<div class="col-xs-12 col-sm-10">
																	<div class="clearfix">
																		<asp:TextBox ID="txtTitle1" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                        <asp:Label ID="lblTitle1" runat="server" Text="" ForeColor="Maroon"></asp:Label>
																	</div>
																</div>
															</div>   
                                                            

                                                           
													 </div>

                                                        <div class="row"> 

                                                              <div class="form-group col-lg-6">
                                                        <label class="control-label col-xs-12 no-padding-right required" for="email">Short Content:</label>
                                                        <div class="col-xs-12 col-sm-10">
                                                            <div class="clearfix">
                                                               <asp:TextBox ID="txtShort" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                <asp:Label ID="lblShort" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                        <div class="form-group col-lg-6">
																<label class="control-label col-xs-12 no-padding-right" for="Comapany Name">Short Content Language:</label>

											     		<div class="col-xs-12 col-sm-10">
																	<div class="clearfix">
																		<asp:TextBox ID="txtShort1" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                        <asp:Label ID="lblShort1" runat="server" Text="" ForeColor="Maroon"></asp:Label>
																	</div>
																</div>
															</div> 
														    

                                                            </div>


                                                      
                                                       <div class="row"> 
                                                            

                                                        <%--<div class="form-group col-lg-6">
                                                        <label class="control-label col-xs-12 no-padding-right required" for="email">More Detail:</label>
                                                        <div class="col-xs-12 col-sm-10">
                                                            <div class="clearfix">
                                                               <asp:TextBox ID="txtMDetail" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                <asp:Label ID="lblMDetail" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                        <div class="form-group col-lg-6">
																<label class="control-label col-xs-12 no-padding-right" for="Comapany Name">More Detail Language:</label>

											     		<div class="col-xs-12 col-sm-10">
																	<div class="clearfix">
																		<asp:TextBox ID="txtMDetail1" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                        <asp:Label ID="lblMDetail1" runat="server" Text="" ForeColor="Maroon"></asp:Label>
																	</div>
																</div>
															</div>   --%>
                                                            

                                                             <div class="form-group col-lg-3" style="display:none;">
                                                        <label class="control-label col-xs-12 no-padding-right required" for="email">More Detail 1:</label>
                                                        <div class="col-xs-12 col-sm-10">
                                                            <div class="clearfix">
                                                               <asp:TextBox ID="txtMDetail2" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                <asp:Label ID="lblMDetail2" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                        <div class="form-group col-lg-3" style="display:none;">
																<label class="control-label col-xs-12 no-padding-right" for="Comapany Name">More Detail 1 Language:</label>

											     		<div class="col-xs-12 col-sm-10">
																	<div class="clearfix">
																		<asp:TextBox ID="txtMDetail21" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                        <asp:Label ID="lblMDetail21" runat="server" Text="" ForeColor="Maroon"></asp:Label>
																	</div>
																</div>
															</div> 
														    
													 </div>
                                                         <div class="row" style="display:none;"> 
                                                            

                                                        <div class="form-group col-lg-3"">
                                                        <label class="control-label col-xs-12 no-padding-right required" for="email">Page Title:</label>
                                                        <div class="col-xs-12 col-sm-10">
                                                            <div class="clearfix">
                                                               <asp:TextBox ID="txtPTitle" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                <asp:Label ID="lblPTitle" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                        <div class="form-group col-lg-3">
																<label class="control-label col-xs-12 no-padding-right" for="Comapany Name">Page Title Language:</label>

											     		<div class="col-xs-12 col-sm-10">
																	<div class="clearfix">
																		<asp:TextBox ID="txtPTitle1" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                        <asp:Label ID="lblPTitle1" runat="server" Text="" ForeColor="Maroon"></asp:Label>
																	</div>
																</div>
															</div>   
                                                            

                                                             <div class="form-group col-lg-3">
                                                        <label class="control-label col-xs-12 no-padding-right required" for="email">Page Keyword:</label>
                                                        <div class="col-xs-12 col-sm-10">
                                                            <div class="clearfix">
                                                               <asp:TextBox ID="txtPKey" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                <asp:Label ID="lblPKey" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                        <div class="form-group col-lg-3">
																<label class="control-label col-xs-12 no-padding-right" for="Comapany Name">Page Keyword Language:</label>

											     		<div class="col-xs-12 col-sm-10">
																	<div class="clearfix">
																		<asp:TextBox ID="txtPKey1" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                        <asp:Label ID="lblPKey1" runat="server" Text="" ForeColor="Maroon"></asp:Label>
																	</div>
																</div>
															</div> 
														    
													 </div>

                                                         <div class="row" style="display:none;"> 
                                                            

                                                        <div class="form-group col-lg-3">
                                                        <label class="control-label col-xs-12 no-padding-right required" for="email">Page Description:</label>
                                                        <div class="col-xs-12 col-sm-10">
                                                            <div class="clearfix">
                                                               <asp:TextBox ID="txtPDes" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                <asp:Label ID="lblPDes" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                        <div class="form-group col-lg-3">
																<label class="control-label col-xs-12 no-padding-right" for="Comapany Name">Page Description Language:</label>

											     		<div class="col-xs-12 col-sm-10">
																	<div class="clearfix">
																		<asp:TextBox ID="txtPDes1" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                        <asp:Label ID="lblPDes1" runat="server" Text="" ForeColor="Maroon"></asp:Label>
																	</div>
																</div>
															</div>   
                                                            

                                                             <div class="form-group col-lg-3">
                                                        <label class="control-label col-xs-12 no-padding-right required" for="email">Common Detail(50 Character):</label>
                                                        <div class="col-xs-12 col-sm-10">
                                                            <div class="clearfix">
                                                               <asp:TextBox ID="txtCDet" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                <asp:Label ID="lblCDet" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                        <div class="form-group col-lg-3">
																<label class="control-label col-xs-12 no-padding-right" for="Comapany Name">Common Detail(200 Character):</label>

											     		<div class="col-xs-12 col-sm-10">
																	<div class="clearfix">
																		<asp:TextBox ID="txtCDet1" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                                                        <asp:Label ID="lblCDet1" runat="server" Text="" ForeColor="Maroon"></asp:Label>
																	</div>
																</div>
															</div> 
														    
													 </div>

                                                        <div class="row"> 
                                                            

                                                        <div class="form-group col-lg-6">
                                                        <label class="control-label col-xs-12 no-padding-right required" for="email">Order for Banners:</label>
                                                        <div class="col-xs-12 col-sm-10">
                                                            <div class="clearfix">
                                                               <asp:TextBox ID="txtBanners" runat="server" CssClass="form-control" ></asp:TextBox>                                         
                                                            </div>
                                                        </div>
                                                    </div>
                                                        <div class="form-group col-lg-6">
																<label class="control-label col-xs-12 no-padding-right" for="Comapany Name">Status:</label>

											     		<div class="col-xs-12 col-sm-10">
																	<div class="clearfix">
																		<asp:RadioButtonList ID="rbtnStatus" CssClass="radio1" Width="100%" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True">Active</asp:ListItem>
                                                <asp:ListItem>Closed</asp:ListItem>
                                            </asp:RadioButtonList>
                                                                        <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Maroon"></asp:Label>
																	</div>
																</div>
															</div>   
                                                            
                                                            <%--<div class="form-group col-lg-4">
																<label class="control-label col-xs-12 no-padding-right" for="Comapany Name">Published Date for News:</label>

											     		<div class="col-xs-12 col-sm-10">
																	<div class="clearfix">
																		 <cc1:DatePicker ID="dpstart" runat="server" Width="100%" />
                                                                        <asp:Label ID="Label7" runat="server" Text="" ForeColor="Maroon"></asp:Label>
																	</div>
																</div>
															</div>   --%>
                                                             



                                                             
                                                       
													 </div>
                                                        


                                                        <div class="row"> 
                                                            

                                                        <div class="form-group col-lg-6">
                                                        <label class="control-label col-xs-12 no-padding-right required" for="email">Detail English:</label>
                                                        <div class="col-xs-12 col-sm-10">
                                                            <div class="clearfix">
                                                               <FTB:FreeTextBox ID="ftDet" runat="server"  Width="100%"></FTB:FreeTextBox>
                                                                    <asp:Label ID="lblDet" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                        <div class="form-group col-lg-6">
																<label class="control-label col-xs-12 no-padding-right" for="Comapany Name">Document Language:</label>

											     		<div class="col-xs-12 col-sm-10">
																	<div class="clearfix">
																		<FTB:FreeTextBox ID="ftDet1" runat="server"  Width="100%"></FTB:FreeTextBox>
                                                                    <asp:Label ID="lblDet1" runat="server" Text="" ForeColor="Maroon"></asp:Label>
																	</div>
																</div>
															</div>   
                                                            

                                                           
                                                       
													 </div>


                                                        <div class="row" style="display:none;"> 
                                                            

                                                        <div class="form-group col-lg-3">
                                                        
                                                        <div class="col-xs-12 col-sm-10">
                                                            <div class="clearfix">
                                                              
                                                                <asp:Label ID="Label1" runat="server" Text="Image" ForeColor="Maroon"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                        <div class="form-group col-lg-3">
															
											     		<div class="col-xs-12 col-sm-10">
																	<div class="clearfix">
																		 <asp:FileUpload ID="fuf" runat="server" />
                                                                        <asp:Label ID="lblImage" runat="server" Text="" ForeColor="Maroon"></asp:Label>
																	</div>
																</div>
															</div>   
                                                            

                                                             <div class="form-group col-lg-3">
                                                       <div class="col-xs-12 col-sm-10">
                                                            <div class="clearfix">
                                                                <asp:Image ID="imgd" runat="server" Width="100px" />
                                                                 <asp:Label ID="lbld" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                       
													 </div>


                                               
                                                                                                           
                                                            </div>  
                                                          
                                                      <div class="form-horizontal hide1"> 
                                                          
                                                          <div class="col-xs-12 col-sm-10">
                                                               <div class="clearfix">
                                                              
                                                                <asp:Label ID="Label4" runat="server" Text="Image / File English" ForeColor="Maroon"></asp:Label>
                                                            </div>
																	<div class="clearfix">
																		 <asp:FileUpload ID="fufd" runat="server" />
                                                                        <asp:Label ID="lblfufd" runat="server" Text="" ForeColor="Maroon" ></asp:Label>
                                                                        <asp:HiddenField runat="server" ID="hdnfileupload_english" />
																	</div>
																</div>
                                                          <div class="col-xs-12 col-sm-10">
                                                               <div class="clearfix">
                                                              
                                                                <asp:Label ID="Label2" runat="server" Text="Image / File Arabic" ForeColor="Maroon"></asp:Label>
                                                            </div>
																	<div class="clearfix">
																		 <asp:FileUpload ID="FileUpload1" runat="server" />
                                                                        <asp:Label ID="lblfileupload" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                                         <asp:HiddenField runat="server" ID="hdnfileupload_arabic" />
																	</div>
																</div>
                                                           <div class="row">                                                          
                                                        
                                                        <div class="col-xs-12 col-sm-12">

                                        <asp:LinkButton ID="lbtnUpdate" runat="server" CssClass="btn btn-info" OnClick="lbtnUpdate_Click"><i class="ace-icon fa fa-plus bigger-110"></i> Update</asp:LinkButton>
                                       <%--<asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn btn-info" OnClick="lbtnDelete_Click"><i class="ace-icon fa fa-trash-o bigger-130"></i> Delete</asp:LinkButton>--%>
                                                            <br /><asp:Label ID="lbler" runat="server" Text="" ForeColor="Maroon"></asp:Label>

                                                            	
		   			 </div>  
                                                            </div> 
										             
                                                          
                                                          </div>  
                
                <br /><br />
                <div class="form-horizontal hide1"> 

                        <div class="row"> 
                                                            

                                                        
                                                        <div class="form-group col-lg-3">
															
											     		
															</div>   
                                                            
                             <div class="form-group col-lg-3" style="display:none;">
                                                        <label class="control-label col-xs-12 no-padding-right required" for="email">Default Image</label>
                                                        <div class="col-xs-12 col-sm-10">
                                                            <div class="clearfix">
                                                               <asp:RadioButtonList ID="rbtnDImage" CssClass="radio1" Width="100%"  runat="server" RepeatDirection="Horizontal" Visible="false">
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                                                                <asp:Label ID="Label5" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                             <div class="form-group col-lg-3">
                                                       <%--<div class="col-xs-12 col-sm-10">
                                                            <div class="clearfix">
                                                                <asp:LinkButton ID="lbtnUpload" runat="server" CssClass="btn btn-info" OnClick="lbtnUpload_Click"><i class="ace-icon fa fa-plus bigger-110"></i> Upload</asp:LinkButton>
                                                                 <asp:Label ID="lblcier" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                            </div>
                                                        </div>--%>
                                                    </div>
                                                       
													 </div>



                    </div>



                <!-- div.dataTables_borderWrap -->
										<div>
                                            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" AllowPaging="true" AllowSorting="true" OnRowDataBound="gv_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No">
                    <ItemTemplate>
                        <asp:Label ID="lblvsno" runat="server" Text=" <%# Container.DataItemIndex + 1 %>"></asp:Label>
                        <asp:Label ID="lblveid" runat="server" Text='<%# Eval("FileId") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                                                    <asp:BoundField DataField="FileId" HeaderText="Id" ReadOnly="True" SortExpression="FileId"/> 
                                                    
                                                    <asp:BoundField DataField="ImageUrl" HeaderText="Image /File Url" ReadOnly="True" SortExpression="ImageUrl"/> 
                                                     
                                                     <asp:BoundField DataField="DefaultImage" HeaderText="Default Image" ReadOnly="True" SortExpression="DefaultImage"/> 
                                                    <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        
                        <asp:Image ID="Image1" runat="server" Width="100px" ImageUrl='<%# Eval("ImageUrl") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
   <asp:TemplateField HeaderText="Default">
                    <ItemTemplate>
                       
                        <asp:Label ID="lblDefault" runat="server" Text='<%# Eval("DefaultImage") %>' Visible="false"></asp:Label>
                         <asp:Label ID="lblIURL" runat="server" Text='<%# Eval("ImageUrl") %>' Visible="false"></asp:Label>
                         <asp:RadioButtonList ID="rbtnDImage" CssClass="radio1" Width="100%"  runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem>Yes</asp:ListItem>
                                                <asp:ListItem Selected="True">No</asp:ListItem>
                                            </asp:RadioButtonList>
                        
                    </ItemTemplate>
                </asp:TemplateField>



                                                    <asp:TemplateField HeaderText="Update">
                    <ItemTemplate>
                        
                        <asp:LinkButton ID="lbtnUpdateDefault" runat="server" ToolTip="Delete" CssClass="red" OnClick="lbtnUpdateDefault_Click">Update</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                                                
                                                    <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        
                        <asp:LinkButton ID="lbtnDeleteImage" runat="server" ToolTip="Delete" CssClass="red" OnClick="lbtnDeleteImage_Click"><i class="ace-icon fa fa-trash-o bigger-130"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                                                    
                                                     </Columns>
                                            </asp:GridView>
										
										</div>



                
                							
													</div>
													
                                                        
           
             
         </section>
    </div>	

</div>
	
</asp:Content>

