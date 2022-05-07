<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/MPAdmin.Master" AutoEventWireup="true" CodeBehind="San_Pham.aspx.cs" Inherits="TKS_Thuc_Tap_Web.Danh_Muc.San_Pham" %>
<%@ Register Src="~/Danh_Muc/UserControl/uc3003_San_Pham.ascx" TagPrefix="uc1" TagName="uc3003_San_Pham" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<uc1:uc3003_San_Pham runat="server" id="uc3003_San_Pham" />
</asp:Content>
