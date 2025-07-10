<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="admin-member-managememt.aspx.cs" Inherits="LibraryManagement.admin_member_managememt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class=" container-fluid mt-2">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                         <div class="row">
                            <div class="col">
                                <center>
                                   <h3>Member Details</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/admin-user.png" width="50px" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                               <hr />
                            </div>
                        </div>
                         <div class="row">
                               <div class="col-md-3">
                                 <label>Member ID</label>
                               <div class="form-group">
                                   <div class="input-group">     
                                   <asp:TextBox CssClass="form-control " ID="txt_MemberId" runat="server" placeholder="ID" ></asp:TextBox>
                                       <asp:LinkButton CssClass="btn btn-primary btn-sm ml-1 mr-1" ID="btn_Go" runat="server" OnClick="btn_Go_Click1"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                   </div>
                               </div>
                            </div>
                             <div class="col-md-4">
                                <label>Full Name</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control " ID="txt_MemberName" runat="server" placeholder="Member Name" ReadOnly="true"></asp:TextBox>
                               </div>
                            </div>
                              <div class="col-md-5">
                                <label>Account Status</label>               <%--TextBox7--%>
                               <div class="form-group">
                                   <div class="input-group">
                                   <asp:TextBox CssClass="form-control " ID="txt_AccountStatus" runat="server" placeholder="Status" ReadOnly="true"></asp:TextBox>
                                   <asp:LinkButton CssClass="btn btn-success  btn-sm ml-1 mr-1" ID="btn_Active" runat="server" OnClick="btn_Active_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                   <asp:LinkButton CssClass="btn btn-warning btn-sm mr-1" ID="btn_Pending" runat="server" OnClick="btn_Pending_Click"><i class="fas fa-pause-circle"></i></asp:LinkButton>
                                   <asp:LinkButton CssClass="btn btn-danger btn-sm mr-1" ID="btn_Deactive" runat="server" OnClick="btn_Deactive_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                   </div>
                               </div>
                            </div>
                        </div>
                          <div class="row">
                             <div class="col-md-4">
                                <label>DOB</label>          <%--TextBox3--%>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control " ID="txt_DOB" runat="server" TextMode="Date" ReadOnly="true"></asp:TextBox>
                               </div>
                            </div>
                              <div class="col-md-4">
                                 <label>Contact No.</label>         <%--TextBox4--%>
                               <div class="form-group">
                                   <div class="input-group">     
                                   <asp:TextBox CssClass="form-control" ID="txt_Contact" runat="server" placeholder="Contact No." ReadOnly="true"></asp:TextBox>
                                   </div>
                               </div>
                            </div>
                                <div class="col-md-4">
                                 <label>Email-Id</label>            <%--TextBox8--%>
                               <div class="form-group">
                                   <div class="input-group">     
                                   <asp:TextBox CssClass="form-control" ID="txt_Email" runat="server" placeholder="Email-Id" ReadOnly="true"></asp:TextBox>
                                   </div>
                               </div>
                            </div>
                        </div>
                          <div class="row">
                             <div class="col-md-4">
                                <label>State</label>            <%--TextBox5--%>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control " ID="txt_State" runat="server" placeholder="State" ReadOnly="true" ></asp:TextBox>
                               </div>
                            </div>
                              <div class="col-md-4">
                                 <label>City</label>            <%--TextBox6--%>
                               <div class="form-group">
                                   <div class="input-group">     
                                   <asp:TextBox CssClass="form-control " ID="txt_City" runat="server" placeholder="City" ReadOnly="true"></asp:TextBox>
                                   </div>
                               </div>
                            </div>
                               <div class="col-md-4">
                                 <label>Pin-Code</label>            <%--TextBox9--%>
                               <div class="form-group">
                                   <div class="input-group">     
                                   <asp:TextBox CssClass="form-control " ID="txt_Pincode" runat="server" placeholder="Pin-Code" ReadOnly="true"></asp:TextBox>
                                   </div>
                               </div>
                            </div>
                        </div>
                          <div class="row">
                             <div class="col-md-12">
                                <label>Full Postal Address </label>             <%--TextBox10--%>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control " ID="txt_Address" runat="server" Rows="2" TextMode="MultiLine" placeholder="Address....." ReadOnly="true" ></asp:TextBox>
                               </div>
                            </div>
                        </div>
                         <div class="row">
                             <div class="col-12">
                                  <div class="form-group">
                                      <asp:Button CssClass="btn btn-block btn-lg btn-danger" ID="btn_Delete" runat="server" Text="Delete User Permanently" OnClick="btn_Delete_Click" />
                                  </div>  
                             </div>
                         </div>
                    </div>
                </div>
            <center>
              <a href="homepage.aspx"><<<< Back to Home </a> <br /> <br />
           </center
            </div>          
       </div>
          <div class=" col-md-7 ">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class=" col ">
                                <center>
                                   <h4>Member List</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                               <hr />
                            </div>
                        </div>
                         <div class="row">
                             <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>--%>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="ID" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact No." SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
  </div>
</asp:Content>
