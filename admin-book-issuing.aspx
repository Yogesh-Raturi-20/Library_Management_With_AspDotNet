<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="admin-book-issuing.aspx.cs" Inherits="LibraryManagement.admin_book_issuing" %>
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
                                   <h3>Book Issuing</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="Images/books2.png" width="100px" />
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
                                <label>Member ID</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_MemberId" runat="server" placeholder="Member ID"></asp:TextBox>
                               </div>
                            </div>
                              <div class="col-md-6">
                                 <label>Book ID</label>
                               <div class="form-group">
                                   <div class="input-group">     
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_BookId" runat="server" placeholder="ID"></asp:TextBox>
                                       <asp:Button CssClass="btn btn-sm btn-secondary" ID="btn_Go" runat="server" Text="GO" OnClick="btn_Go_Click" />
                                   </div>
                               </div>
                            </div>
                        </div>
                          <div class="row">
                             <div class="col-md-6">
                                <label>Member Name</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_MembrName" runat="server" placeholder="Member Name" ReadOnly="true"></asp:TextBox>
                               </div>
                            </div>
                              <div class="col-md-6">
                                 <label>Book Name</label>
                               <div class="form-group">
                                   <div class="input-group">     
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_BookName" runat="server" placeholder="Book Name" ReadOnly="true"></asp:TextBox>
                                   </div>
                               </div>
                            </div>
                        </div>
                          <div class="row">
                             <div class="col-md-6">
                                <label>Start Date</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_StartDate" runat="server" TextMode="Date"></asp:TextBox>
                               </div>
                            </div>
                              <div class="col-md-6">
                                 <label>End Date</label>
                               <div class="form-group">
                                   <div class="input-group">     
                                   <asp:TextBox CssClass="form-control form-control-lg" ID="txt_EndDate" runat="server" TextMode="Date"></asp:TextBox>
                                   </div>
                               </div>
                            </div>
                        </div>
                         <div class="row">
                             <div class="col-6">
                                  <div class="form-group">
                                      <asp:Button CssClass="btn btn-block btn-lg btn-primary" ID="btn_Issue" runat="server" Text="Issue" OnClick="btn_Issue_Click" />
                                  </div>  
                             </div>
                              <div class="col-6">
                                  <div class="form-group">
                                      <asp:Button CssClass="btn btn-block btn-lg btn-success" ID="btn_Return" runat="server" Text="Return" OnClick="btn_Return_Click" />
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
          <div class=" container-fluid col-md-7 ">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                   <h4>Issued Book List</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                               <hr />
                            </div>
                        </div>
                         <div class="row">
                             <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [book_issue_tbl]"></asp:SqlDataSource>--%>
                            <div class="col">
                                <asp:GridView CssClass="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Member ID" SortExpression="member_id" />
                                        <asp:BoundField DataField="member_name" HeaderText="Member Name" SortExpression="member_name" />
                                        <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name" />
                                        <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date" />
                                        <asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="due_date" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
   </div>
</asp:Content>