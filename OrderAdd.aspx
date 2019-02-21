<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderAdd.aspx.cs" Inherits="ShopCafeWebForm.OrderAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container">
    <div class="row">
      <div class="col-sm-12 col-md-12 col-xs-12" style="padding : 20px;">
        <div class="panel panel-primary">
          <div class="panel-heading">Add Product</div>
          <div class="panel-body">
            <div class="form-group" style="padding : 20px;">
              <asp:Label runat="server" Text="Product Name" CssClass="control-label col-sm-3"></asp:Label>
              <div class="col-sm-7">
                <asp:TextBox ID="productName" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
              </div>
            </div>
            <div class="form-group" style="padding : 20px;">
              <asp:Label runat="server" Text="Product Price" CssClass="control-label col-sm-3"></asp:Label>
              <div class="col-sm-7">
                <asp:TextBox ID="productPrice" runat="server" CssClass="form-control" placeholder="Price"></asp:TextBox>
              </div>
            </div>
            <div class="form-group" style="padding : 20px;">
              <asp:Label runat="server" Text="Product Detail" CssClass="control-label col-sm-3"></asp:Label>
              <div class="col-sm-7">
                <asp:TextBox ID="productDetail" runat="server" CssClass="form-control" placeholder="Detail">
                </asp:TextBox>
              </div>
            </div>
            <div class="form-group" style="padding : 20px;">
              <asp:Label runat="server" Text="Product Type" CssClass="control-label col-sm-3"></asp:Label>
              <div class="col-sm-7">
                <asp:DropDownList ID="typeProduct" runat="server" CssClass="form-control">
                  <asp:ListItem Enabled="true" Text="Select Type" Value="0">
                  </asp:ListItem>
                  <asp:ListItem Text="Coffee" Value="1"></asp:ListItem>
                  <asp:ListItem Text="Sweets" Value="2"></asp:ListItem>
                  <asp:ListItem Text="Drinking" Value="3"></asp:ListItem>
                  <asp:ListItem Text="Tea" Value="4"></asp:ListItem>
                </asp:DropDownList>
              </div>
            </div>
            <div style="padding : 20px;">
              <div class="row">
                <div class="col-sm-6">
                  <asp:Button ID="submit" runat="server" CssClass="btn btn-success btn-block" Text="Submit"
                    onClick="submit_Click" />
                </div>
                <div class="col-sm-6">
                  <asp:Button ID="cancal" runat="server" CssClass="btn btn-danger btn-block" Text="Cancel"
                    onClick="cancal_Click" />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</asp:Content>