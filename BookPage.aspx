
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookPage.aspx.cs" Inherits="BookPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" Runat="Server">
    <p>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; The shell with books</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Label ID="Label13" runat="server" Text="Label" Visible="False"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
   
    <p>
        &nbsp;<asp:Button ID="Button10" runat="server" Text="Advanced search" OnClick="Button10_Click" />
&nbsp;<asp:TextBox ID="textBoxSearch" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:CheckBox ID="CheckBoxThriller" runat="server" ForeColor="Red" Text="Thriller"  />
        <asp:CheckBox ID="CheckBoxScience" runat="server" ForeColor="Red" Text="Science" />
        <asp:CheckBox ID="CheckBoxRomance" runat="server" ForeColor="Red" Text="Romance" />
        <asp:CheckBox ID="CheckBoxChildren" runat="server" ForeColor="Red" Text="Children" />
&nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="gvBooks" runat="server" OnSelectedIndexChanged="gvBooks_SelectedIndexChanged1">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </p>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
</asp:Content>

