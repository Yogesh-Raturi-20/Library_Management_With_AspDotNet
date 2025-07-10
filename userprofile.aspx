<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="LibraryManagement.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid mt-2">
        <div class="row">
            <div class="col-md-5 ">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/admin-user.png" width="100px" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                   <h4>Your Profile</h4>
                                    <span>Account Status - </span>
                                    <asp:Label CssClass="badge badge-pill badge-info" ID="lb_AccountStatus" runat="server" Text="status"></asp:Label>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                               <hr />
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-6">
                                 <label>Full Name</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_MemberName" runat="server" placeholder=" Enter Name"></asp:TextBox>
                               </div>
                            </div>
                            <div class="col-md-6">
                                 <label>Date-Of-birth</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_DOB" runat="server" TextMode="Date"></asp:TextBox>
                               </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                 <label>Contact Number</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_Contact" runat="server" placeholder=" Enter Number" TextMode="Number"></asp:TextBox>
                               </div>
                            </div>
                            <div class="col-md-6">
                                 <label>Email-Id</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_Email" runat="server" TextMode="Email" placeholder="Enter Email" ></asp:TextBox>
                               </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                 <label>State</label>
                               <div class="form-group">
                                   <asp:DropDownList CssClass="form-control" ID="ddl_State" runat="server">
                                       <asp:ListItem Text="Select" Value="Select"/>
                                       <asp:ListItem Text="Assam" Value="Assam"/>
                                       <asp:ListItem Text="Haryana" Value="Haryana"/>
                                       <asp:ListItem Text="Uttarakhand" Value="Uttarakhand"/>
                                       <asp:ListItem Text="Uttarpradesh" Value="Uttarpradesh"/>
                                   </asp:DropDownList>
                               </div>
                            </div>
                            <div class="col-md-4">
                                 <label>City</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_City" runat="server" placeholder="City"></asp:TextBox>
                               </div>
                            </div>
                             <div class="col-md-4">
                                 <label>Pin-Code</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_Pincode" runat="server" TextMode="Number" placeholder="Pin-Code"></asp:TextBox>
                               </div>
                            </div>
                        </div>
                          <div class="row">
                             <div class="col-md-12">
                                 <label>Full Address</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_Address" runat="server" TextMode="MultiLine" Rows="2" placeholder="Enter-Your-Address.........."></asp:TextBox>
                               </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                               <center>
                                   <h4 class="badge badge-pill badge-primary">Login Credentials</h4>
                               </center>
                            </div>
                        </div>
                        <div class="row">
                              <div class="col-md-4">
                                 <label>Member ID</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_MemberId" runat="server" placeholder="ID" ReadOnly="true" ></asp:TextBox>
                               </div>
                            </div>
                            <div class="col-md-4">
                                 <label>Old Password</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_OldPassword" runat="server" placeholder="Password " ReadOnly="true"></asp:TextBox>
                               </div>
                            </div>
                            <div class="col-md-4">
                                 <label>New Password</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_NewPassword" runat="server" TextMode="Password" placeholder="Password "></asp:TextBox>
                               </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                               <hr />
                            </div>
                        </div>
                         <div class="row">
                             <div class="col-8 mx-auto">
                                <center>
                                  <div class="form-group">
                                      <asp:Button CssClass="btn btn-block btn-lg btn-primary" ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" />
                                  </div>  
                                </center>
                             </div>
                         </div>  
                    </div>
                </div>
            <center>
              <a href="homepage.aspx"><<<< Back to Home </a> <br /> <br />
           </center
            </div>
        </div>      
          <div class="col-md-7 ">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/Books2.png" width="100px" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                   <h4>Your Issued Books</h4>
                                    <asp:Label CssClass="badge badge-pill badge-info" ID="Label2" runat="server" Text="Your Books Info"></asp:Label>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                               <hr />
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound" ></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
   </div>
</asp:Content>
