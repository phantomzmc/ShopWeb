<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditCoffee.aspx.cs" Inherits="ShopCafeWebForm.EditCoffee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container">
    <div class="row">
      <div class="col-sm-12 col-md-12 col-xs-12" style="padding : 20px;">
        <div class="panel panel-primary">
          <div class="panel-heading">Add Product</div>
          <div class="panel-body">
            <div class="form-group" style="padding : 20px;">
              <asp:Label runat="server" Text="Product Name" CssClass="control-label col-sm-2"></asp:Label>
              <div class="col-sm-10">
                <asp:TextBox ID="productName" runat="server" CssClass="form-control" placeholder="Name"></asp:TextBox>
              </div>
            </div>
            <div class="form-group" style="padding : 20px;">
              <asp:Label runat="server" Text="Product Price" CssClass="control-label col-sm-2"></asp:Label>
              <div class="col-sm-10">
                <asp:TextBox ID="productPrice" runat="server" CssClass="form-control " placeholder="Price">
                </asp:TextBox>
              </div>
            </div>
            <div class="form-group" style="padding : 20px;">
              <asp:Label runat="server" Text="Product Detail" CssClass="control-label col-sm-2"></asp:Label>
              <div class="col-sm-10">
                <asp:TextBox ID="productDetail" runat="server" CssClass="form-control" placeholder="Detail">
                </asp:TextBox>
              </div>
            </div>
            <div class="form-group" style="padding : 20px;">
              <asp:Label runat="server" Text="Product Type" CssClass="control-label col-sm-2"></asp:Label>
              <div class="col-sm-10">
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
                    onClick="submit_Click" OnClientClick="return submitClick();" />
                </div>
                <div class="col-sm-6">
                  <asp:Button ID="cancel" runat="server" CssClass="btn btn-danger btn-block" Text="Cancel"
                    OnClick="cancel_Click" />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <script type="text/javascript">
    function submitClick() {
      if (!$('#MainContent_productName').val()) {
        showAlertError('กรุณากรอกข้อมูลชื่อภาพยนต์');
        return false;
      }
      if (!$('#MainContent_productPrice').val()) {
        showAlertError('กรุณากรอกข้อมูลความยาวของภาพยนต์(นาที)');
        return false;
      }
      if (isNaN($('#MainContent_productDetail').val())) {
        showAlertError('กรุณากรอกข้อมูลความยาวของภาพยนต์(นาที) เป็นตัวเลขเท่านั้น');
        return false;
      }
      if (!$('#MainContent_typeProduct').val()) {
        showAlertError('กรุณาเลือกรูปภาพ');
        return false;
      }
  </script>
</asp:Content> 
