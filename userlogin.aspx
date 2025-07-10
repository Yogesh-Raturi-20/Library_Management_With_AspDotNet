<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="LibraryManagement.userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-2" >
        <div class="row">
            <div class="col-md-10 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/admin-user.png" width="150px" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                   <h3>Member Login</h3>
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
                                <label>Member ID</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_MemberId" runat="server" placeholder=" Enter ID"></asp:TextBox>
                                   <center>
                                     <asp:Label ID="lb_ErrorID" runat="server" Text=""></asp:Label>
                                   </center>
                               </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <label>Password</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_Password" runat="server" placeholder="Password" ErrorMessage="please enter password" TextMode="Password"></asp:TextBox>
                                   <center>
                                     <asp:Label ID="lb_ErrorPassword" runat="server" Text=""></asp:Label>
                                   </center>
                               </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Captcha</label>
                                <div class="form-group">
                                      <asp:TextBox CssClass="form-control form-control-lg" ID="txt_Captcha" runat="server" placeholder="Enter Captcha"></asp:TextBox>
                                    <center>
                                     <asp:Label ID="lb_ErrorMsg" runat="server" Text=""></asp:Label>
                                    </center>
                                    <br />
                                    <center>
                                        <asp:Image ID="captchaImage" runat="server" Height="80px" Width="250px" ImageUrl="~/MyCaptcha.aspx"/>
                                    </center>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Button CssClass="btn btn-block btn-lg btn-success" ID="btn_Login" runat="server" Text="Login" OnClick="btn_Login_Click" />
                         </div>
                        <div class="form-group">
                            <a href="usersignup.aspx">
                            <input class="btn btn-block btn-lg btn-primary" type="button" id="btn_Signup" value="Sign Up"/>
                            </a>
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
