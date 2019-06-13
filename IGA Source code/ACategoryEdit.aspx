<%@ Page Title="" Language="C#" MasterPageFile="~/amain.master" AutoEventWireup="true" CodeFile="ACategoryEdit.aspx.cs" Inherits="ACategoryEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    

  

    <asp:Label ID="lblcid" runat="server" Text="" Visible="false"></asp:Label>	

<div class="page-header">
							<h1>Category</h1>
						</div><!-- /.page-header -->

<div class="row">
    <div class="col-lg-12">
        <section class="panel">
           
            <div class="panel-body">
							
							
											
               
                    <%-- tab 1--%>
									
												
													<div class="form-horizontal hide1" runat="server" id="vcont"> 
                                                        <div class="row"> 
                                                            <div class="form-group col-lg-4">
                                                        <label class="control-label col-xs-12 no-padding-right required" for="email">Types Name:</label>
                                                        <div class="col-xs-12 col-sm-10">
                                                            <div class="clearfix">
                                                               <asp:DropDownList ID="ddlTypes" runat="server" CssClass="input-medium1 form-control chzn-select" AppendDataBoundItems="true" data-placeholder="Choose a Types..."  AutoPostBack="true"></asp:DropDownList>
                                                                        <asp:Label ID="lblTypes" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                        <div class="form-group col-lg-4">
                                                        <label class="control-label col-xs-12 no-padding-right required" for="email">Category Name:</label>
                                                        <div class="col-xs-12 col-sm-10">
                                                            <div class="clearfix">
                                                               <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <asp:Label ID="lblCategoryName" runat="server" Text="" ForeColor="Maroon"></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                        <div class="form-group col-lg-4">
																<label class="control-label col-xs-12 no-padding-right" for="Comapany Name">Category Name Language:</label>

											     		<div class="col-xs-12 col-sm-10">
																	<div class="clearfix">
																		<asp:TextBox ID="txtCategoryName1" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <asp:Label ID="lblCategoryName1" runat="server" Text="" ForeColor="Maroon"></asp:Label>
																	</div>
																</div>
															</div>                                               
														    
													 </div>
                                                      
                                                      
                                               
                                                                                                           
                                                            </div>  
                                                          
                                                      <div class="form-horizontal hide1"> 
                                                           <div class="row">                                                          
                                                        
                                                        <div class="col-xs-12 col-sm-12">

                                        <asp:LinkButton ID="lbtnUpdate" runat="server" CssClass="btn btn-info" OnClick="lbtnUpdate_Click"><i class="ace-icon fa fa-plus bigger-110"></i> Update</asp:LinkButton>
                                       <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="btn btn-info" OnClick="lbtnDelete_Click"><i class="ace-icon fa fa-trash-o bigger-130"></i> Delete</asp:LinkButton>
                                                            <br /><asp:Label ID="lbler" runat="server" Text="" ForeColor="Maroon"></asp:Label>

                                                            	
		   			 </div>  
                                                            </div> 
										             
                                                          
                                                          </div>  
                
                
                							
													</div>
													
                                                        
           
             
         </section>
    </div>	

</div>
			
</asp:Content>

