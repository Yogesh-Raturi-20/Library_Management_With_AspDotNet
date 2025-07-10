<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="LibraryManagement.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container mt-2">
        <div class="row">
            <div class="col-md-10 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/admin-user.png" width="100" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                   <h4>Member Sign-Up</h4>
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
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_Contact" runat="server" placeholder=" Enter Number" TextMode="Phone"></asp:TextBox>
                               </div>
                            </div>
                            <div class="col-md-6">
                                 <label>Email-Id</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_Email" runat="server" TextMode="Email" placeholder="Enter Email"></asp:TextBox>
                               </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                 <label>State</label>
                               <div class="form-group">
                                   <asp:DropDownList CssClass="form-control form-control-lg" ID="ddl_State" runat="server">
                                         <asp:ListItem>Select</asp:ListItem>
                                         <asp:ListItem>Andaman and Nicobar Islands</asp:ListItem>
                                         <asp:ListItem>Andhra Pradesh</asp:ListItem>
                                         <asp:ListItem>Arunachal Pradesh</asp:ListItem>
                                         <asp:ListItem>Assam</asp:ListItem>
                                         <asp:ListItem>Bihar</asp:ListItem>
                                         <asp:ListItem>Chandigarh</asp:ListItem>
                                         <asp:ListItem>Chattisgarh</asp:ListItem>
                                         <asp:ListItem>Dadra and Nagar Haveli</asp:ListItem>
                                         <asp:ListItem>Daman and Diu</asp:ListItem>
                                         <asp:ListItem>Delhi</asp:ListItem>
                                         <asp:ListItem>Goa</asp:ListItem>
                                         <asp:ListItem>Gujarat</asp:ListItem>
                                         <asp:ListItem>Haryana</asp:ListItem>
                                         <asp:ListItem>Himachal Pradesh</asp:ListItem>
                                         <asp:ListItem>Jammu and Kashmir</asp:ListItem>
                                         <asp:ListItem>Jharkhand</asp:ListItem>
                                         <asp:ListItem>Karnataka</asp:ListItem>
                                         <asp:ListItem>Kerala</asp:ListItem>
                                         <asp:ListItem>Lakshadweep</asp:ListItem>
                                         <asp:ListItem>Madhya Pradesh</asp:ListItem>
                                         <asp:ListItem>Maharashtra</asp:ListItem>
                                         <asp:ListItem>Manipur</asp:ListItem>
                                         <asp:ListItem>Meghalaya</asp:ListItem>
                                         <asp:ListItem>Mizoram</asp:ListItem>
                                         <asp:ListItem>Nagaland</asp:ListItem>
                                         <asp:ListItem>Orissa</asp:ListItem>
                                         <asp:ListItem>Pondicherry</asp:ListItem>
                                         <asp:ListItem>Punjab</asp:ListItem>
                                         <asp:ListItem>Rajasthan</asp:ListItem>
                                         <asp:ListItem>Sikkim</asp:ListItem>
                                         <asp:ListItem>Tamil Nadu</asp:ListItem>
                                         <asp:ListItem>Tripura</asp:ListItem>
                                         <asp:ListItem>Uttarakhand</asp:ListItem>
                                         <asp:ListItem>Uttaranchal</asp:ListItem>
                                         <asp:ListItem>Uttar Pradesh</asp:ListItem>
                                         <asp:ListItem>West Bengal</asp:ListItem>
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
                                 <label>Full-Postal-Address</label>
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
                              <div class="col-md-6">
                                 <label>Create ID</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_CreateId" runat="server" placeholder="ID" ></asp:TextBox>
                               </div>
                            </div>
                            <div class="col-md-6">
                                 <label>Create Password</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_CreatePassword" runat="server" TextMode="Password" placeholder="Password "></asp:TextBox>
                               </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                               <hr />
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Button CssClass="btn btn-block btn-lg btn-success" ID="btn_Signup" runat="server" Text="Sign-up" OnClick="btn_Signup_Click" />
                         </div>
                    </div>
                </div>
            <center>
              <a href="homepage.aspx"><<<< Back to Home </a> <br /> <br />
           </center
            </div>
        </div>
    </div>
</asp:Content>