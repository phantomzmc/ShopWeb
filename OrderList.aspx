﻿<%@ Page Title="Orderlist" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="ShopCafeWebForm.OrderList" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="column" style="padding : 20px; font-family :'Kanit-Black';">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="table" BorderWidth="0" GridLines="None">
                    <Columns>
                        <asp:BoundField DataField="ProductID" HeaderText="ProductID"/>
                        <asp:BoundField DataField="ProductName" HeaderText="ProductName"/>
                        <asp:BoundField DataField="ProductPrice" HeaderText="ProductPrice"/>
                    </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>