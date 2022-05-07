﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc1316_Bao_Cao.ascx.cs" Inherits="TKS_Thuc_Tap_Web.Sample_Page.UserControl.uc1316_Bao_Cao" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>
<div class="row">
	<div class="col-md-12">
            <span style="font-size:11px; font-family: Tahoma">
                - Báo cáo xuất nhập tồn.<br />
            </span>
    </div>
</div>

<div class="row-spacer_20"></div>

<div class="row">
	<div class="col-md-12">
        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowHeader="False" Width="100%" Theme="Office2010Blue">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <div class="row">
                        <div class="col-md-1" style="text-align: right; padding-top: 6px;">Ngày tạo:</div>
                        <div class="col-md-2">
                            <dx:ASPxDateEdit ID="dtmNgay_Bat_Dau" runat="server" Theme="Office2010Blue" Width="100%">
                            </dx:ASPxDateEdit>
                        </div>
                        <div class="col-md-1" style="text-align: center; width: 50px; padding-top: 6px;">--></div>
                        <div class="col-md-2">
                            <dx:ASPxDateEdit ID="dtmNgay_Ket_Thuc" runat="server" Theme="Office2010Blue" Width="100%">
                            </dx:ASPxDateEdit>
                        </div>
                        <div class="col-md-2">
                            <dx:ASPxButton ID="btnView" runat="server" Text="Tìm Kiếm" Theme="Office2010Blue">
                            </dx:ASPxButton>
                        </div>
                    </div>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxRoundPanel>
    </div>
</div>

<div class="row-spacer_20"></div>

<div class="row">
	<div class="col-md-12">
        <dx:ASPxDocumentViewer ID="rptViewer" runat="server" Theme="Office2010Blue">
        </dx:ASPxDocumentViewer>
    </div>
</div>

