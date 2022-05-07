<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc4002_Nhap_Kho_Management.ascx.cs" Inherits="TKS_Thuc_Tap_Web.Nhap_Kho.UserControl.uc1718_Nhap_Kho_Management" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<div class="row">
	<a href="javascript:openWin('/Nhap_Kho/Nhap_Kho_Edit.aspx?f=4001',1000,600)">Tạo phiếu nhập</a>
</div>

<div class="row">
	<div class="col-md-12">
            <span style="font-size:11px; font-family: Tahoma">
                - Quản lý, hiệu chỉnh, in phiếu nhập kho.<br />
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
                        <div class="col-md-1" style="text-align: left; padding-top: 4px; width: 140px;">Ngày nhập kho: </div>
                        <div class="col-md-2">
                            <dx:ASPxDateEdit ID="dtmNgay_Bat_Dau" runat="server" Theme="Office2010Blue" Width="100%">
                            </dx:ASPxDateEdit>
                        </div>
                        <div class="col-md-1" style="text-align: center; width: 50px; padding-top: 5px;">--></div>
                        <div class="col-md-2">
                            <dx:ASPxDateEdit ID="dtmNgay_Ket_Thuc" runat="server" Theme="Office2010Blue" Width="100%">
                            </dx:ASPxDateEdit>
                        </div>
                        <div class="col-md-2">
                            <dx:ASPxButton ID="btnView" runat="server" Text="Tìm Kiếm" Theme="Office2010Blue" OnClick="btnView_Click">
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
            <dx:ASPxGridView ID="grdData" runat="server" 
                DataSourceID="sqlData"
                Width="100%" 
                KeyFieldName="Auto_ID" 
                Theme="Office2010Blue" ClientInstanceName="grdData" 
                AutoGenerateColumns="False" EnableTheming="True" >    
    
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0" Width="40px">
                        <HeaderTemplate>
                            <input type="checkbox" onclick="grdData.SelectAllRowsOnPage(this.checked);" style="vertical-align: middle;"
                                title="Select/Unselect all rows on the page"></input>
                        </HeaderTemplate>
                    </dx:GridViewCommandColumn>

                    <dx:GridViewDataTextColumn Caption="#" VisibleIndex="1" Width="120px">
                        <DataItemTemplate>
                            <table>
                                <tr>
                                    <td style="text-align:center; border-bottom-style : dotted; border-width: 1px; border-color: #C0C0C0; width: 100%; height: 22px;">
                                        <a href="javascript:openWin('Nhap_Kho_Edit.aspx?Nhap_Kho_ID=<%#Eval("Auto_ID") %>&f=4001',1000,600)">
                                            Hiệu Chỉnh Thông Tin
                                        </a>
                                    </td>
                                </tr>
                            </table>
                        </DataItemTemplate>
                    </dx:GridViewDataTextColumn>

                    <dx:GridViewDataTextColumn Caption="MSHT" FieldName="Auto_ID" VisibleIndex="3" Width="60px">
                        <EditFormSettings Visible="False" />
                    </dx:GridViewDataTextColumn>
        
                    <dx:GridViewDataTextColumn Caption="Số Phiếu" FieldName="So_Phieu_Nhap" VisibleIndex="4" Width="80px" >
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataDateColumn Caption="Ngày Nhập" FieldName="Ngay_Nhap_Kho" VisibleIndex="5" Width="80px">
                    </dx:GridViewDataDateColumn>

					<dx:GridViewDataComboBoxColumn Caption="NCC" FieldName="Nha_Cung_Cap_ID" VisibleIndex="11" Width="100px">
						<PropertiesComboBox DataSourceID="sql1" ValueField="Auto_ID" TextField="Ten_Nha_Cung_Cap">
						</PropertiesComboBox>
						<CellStyle HorizontalAlign="Left"></CellStyle>
					</dx:GridViewDataComboBoxColumn>

					<dx:GridViewDataComboBoxColumn Caption="Kho" FieldName="Kho_ID" VisibleIndex="11" Width="100px">
						<PropertiesComboBox DataSourceID="sql2" ValueField="Auto_ID" TextField="Ten_Kho">
						</PropertiesComboBox>
						<CellStyle HorizontalAlign="Left"></CellStyle>
					</dx:GridViewDataComboBoxColumn>

                    <dx:GridViewDataSpinEditColumn Caption="Số Lượng" FieldName="Tong_So_Luong_Nhap" VisibleIndex="6" Width="70px">
						<PropertiesSpinEdit DisplayFormatString="g"></PropertiesSpinEdit>
                    </dx:GridViewDataSpinEditColumn>
                    <dx:GridViewDataSpinEditColumn Caption="Trị Giá" FieldName="Tong_Gia_Tri_Nhap" VisibleIndex="7" Width="100px">
						<PropertiesSpinEdit DisplayFormatString="g"></PropertiesSpinEdit>
                    </dx:GridViewDataSpinEditColumn>
                    <dx:GridViewDataTextColumn Caption="Ghi Chú" FieldName="Ghi_Chu" VisibleIndex="12">
                    </dx:GridViewDataTextColumn>
                        
                    <dx:GridViewCommandColumn ShowDeleteButton="True" VisibleIndex="2" Width="40px">
                    </dx:GridViewCommandColumn>              
                </Columns>
            </dx:ASPxGridView>
                
            <table cellpadding="0" cellspacing="0" width="100%" style="margin-top:15px">
                <tr>
                    <td align="left">
                        &nbsp;
                    </td>
                
                    <td width="130px" align="right">
                        <dx:ASPxButton ID="btnExport_PDF" runat="server" Text="Kết Xuất PDF" Theme="Office2010Blue">
                        </dx:ASPxButton>
                    </td>
                    <td width="130px" align="right">
                        <dx:ASPxButton ID="btnExport_CSV" runat="server" Text="Kết Xuất CSV" Theme="Office2010Blue">
                        </dx:ASPxButton>
                    </td>
                    <td width="130px" align="right">
                        <dx:ASPxButton ID="btnExport_XLS" runat="server" Text="Kết Xuất XLS" Theme="Office2010Blue">
                        </dx:ASPxButton>
                    </td>
                    <td width="150px" align="right">
                        <dx:ASPxButton ID="btnExport_XLSX" runat="server" Text="Kết Xuất XLSX" Theme="Office2010Blue" Width="120px">
                        </dx:ASPxButton>
                    </td>
                </tr>
            </table>
            <dx:ASPxGridViewExporter ID="gridExport" runat="server" GridViewID="grdData"></dx:ASPxGridViewExporter>

            <asp:SqlDataSource ID="sqlData" runat="server" 
                ConnectionString="<%$ appSettings:TKS_Thuc_Tap_Data_Conn_String %>" 
                SelectCommand="F4002_sp_sel_List_Nhap_Kho" SelectCommandType="StoredProcedure" 
				DeleteCommand="F4002_sp_del_Nhap_Kho" DeleteCommandType="StoredProcedure" >
                <DeleteParameters>
                    <asp:Parameter Name="Auto_ID" />
                    <asp:SessionParameter Name="Last_Updated_By" SessionField="Active_User_Name" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:SessionParameter Name="Ngay_Bat_Dau" SessionField="S3003_Ngay_Bat_Dau" />
                    <asp:SessionParameter Name="Ngay_Ket_Thuc" SessionField="S3003_Ngay_Ket_Thuc" />
                </SelectParameters>
            </asp:SqlDataSource>
			
			<asp:SqlDataSource ID="sql1" runat="server" 
			ConnectionString="<%$ appSettings:TKS_Thuc_Tap_Data_Conn_String %>"
			SelectCommand="sp_sel_List_DM_Nha_Cung_Cap" SelectCommandType="StoredProcedure">
			</asp:SqlDataSource>

			<asp:SqlDataSource ID="sql2" runat="server" 
			ConnectionString="<%$ appSettings:TKS_Thuc_Tap_Data_Conn_String %>"
			SelectCommand="sp_sel_List_DM_Kho" SelectCommandType="StoredProcedure">
			</asp:SqlDataSource>
    </div>
</div>
