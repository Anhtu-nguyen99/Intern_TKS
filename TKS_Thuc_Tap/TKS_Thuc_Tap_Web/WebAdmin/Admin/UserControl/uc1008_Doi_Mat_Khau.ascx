﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc1008_Doi_Mat_Khau.ascx.cs" Inherits="TKS_Thuc_Tap_Web.WebAdmin.Admin.UserControl.uc1008_Doi_Mat_Khau" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<div class="row">
	<div class="col-md-12">
        <span style="font-size:11px; font-family: Tahoma">
        - Đổi mật khẩu sử dụng.<br />
        - Lưu ý: <br />
            <span style="color:Red">&nbsp;&nbsp;&nbsp;+ Vui lòng nhập mật khẩu đúng định dạng: Dài ít nhất 8 ký tự, có ít nhất 1 ký tự chữ, 1 ký tự số, 1 ký tự đặt biệt..</span> <br />
        </span>
    </div>
</div>

<div class="row-spacer_20"></div>

<div class="TKS_Editor_Form">
    <div class="row">
	    <div class="col-md-5">
            <asp:Literal ID="litError" runat="server"></asp:Literal>
        
            <div class="row border-top background">
                <div class="col-md-4 part-01">
                    <h5>Mật khẩu cũ:</h5>
                </div>

                <div class="col-md-8 part-02">
                    <dx:ASPxTextBox ID="txtMat_Khau_Cu" runat="server" Theme="Office2010Blue" 
                        Password="True" >
                    </dx:ASPxTextBox>
                </div>
            </div>

            <div class="row border-top background">
                <div class="col-md-4 part-01">
                    <h5>Mật khẩu mới:</h5>
                </div>
                <div class="col-md-8 part-02">
                    <dx:ASPxTextBox ID="txtMat_Khau_Moi" runat="server" Theme="Office2010Blue" 
                        Password="True" >
                    </dx:ASPxTextBox>
                </div>
            </div>

            <div class="row border-top background">
                <div class="col-md-4 part-01">
                    <h5>Nhập lại Mật khẩu mới:</h5>
                </div>
                <div class="col-md-8 part-02">
                    <dx:ASPxTextBox ID="txtConfirm_Mat_Khau_Moi" runat="server" 
                        Theme="Office2010Blue" Password="True" >
                    </dx:ASPxTextBox>
                </div>
            </div>
        </div>
    </div>
</div>

<div class="row">
    <div class="col-md-5" >
        <div style="padding-top: 10px;" align="right">
            <dx:ASPxButton ID="btnDoi_Mat_Khai" runat="server" Text="Đổi Mật Khẩu" 
                Theme="Office2010Blue" onclick="btnDoi_Mat_Khau_Click" Height="35px">
            </dx:ASPxButton>
        </div>
    </div>
</div>

