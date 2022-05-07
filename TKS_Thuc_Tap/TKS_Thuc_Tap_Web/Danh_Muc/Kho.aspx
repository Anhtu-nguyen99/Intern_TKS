<%@ Page Title="" Language="C#" MasterPageFile="~/WebAdmin/MPAdmin.Master" AutoEventWireup="true" CodeBehind="Kho.aspx.cs" Inherits="TKS_Thuc_Tap_Web.Danh_Muc.Kho" %>
<%@ Register Src="~/Danh_Muc/UserControl/uc3005_Kho.ascx" TagPrefix="uc1" TagName="uc3005_Kho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<uc1:uc3005_Kho runat="server" id="uc3005_Kho" />
</asp:Content>
