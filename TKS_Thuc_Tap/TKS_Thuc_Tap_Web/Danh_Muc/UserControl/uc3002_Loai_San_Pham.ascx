﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc3002_Loai_San_Pham.ascx.cs" Inherits="TKS_Thuc_Tap_Web.Danh_Muc.UserControl.uc3002_Loai_San_Pham" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<div class="row">
	<div class="col-md-12">
        <span style="font-size:11px; font-family: Tahoma">
        - Khai báo loại sản phẩm.
        </span>
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

				<dx:GridViewDataTextColumn Caption="MSHT" FieldName="Auto_ID" VisibleIndex="1" Width="60px">
					<EditFormSettings Visible="False" />
				</dx:GridViewDataTextColumn>
        
				<dx:GridViewDataTextColumn Caption="Tên loại sản phẩm" FieldName="Ten_Loai_San_Pham" VisibleIndex="2" Width="200px" >
					<CellStyle HorizontalAlign="Left">
					</CellStyle>
				</dx:GridViewDataTextColumn>

				<dx:GridViewCommandColumn VisibleIndex="6" Width="50px" ShowNewButton="True">
				</dx:GridViewCommandColumn>
        
				<dx:GridViewCommandColumn VisibleIndex="7" Width="40px" ShowEditButton="True">
				</dx:GridViewCommandColumn>
        
				<dx:GridViewCommandColumn VisibleIndex="8" Width="40px" ShowDeleteButton="True">
				</dx:GridViewCommandColumn>

			</Columns>
		</dx:ASPxGridView>

		<table cellpadding="0" cellspacing="0" width="100%" style="margin-top:15px">
			<tr>
				<td align="left">
					<dx:ASPxButton ID="btnXoa_Select" runat="server" Text="Xóa Chọn" 
						onclick="btnXoa_Select_Click" Theme="Office2010Blue">
					</dx:ASPxButton>
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
			DeleteCommand="sp_del_DM_Loai_San_Pham" DeleteCommandType="StoredProcedure" 
			InsertCommand="F3002_sp_ins_Loai_San_Pham" InsertCommandType="StoredProcedure" 
			SelectCommand="sp_sel_List_DM_Loai_San_Pham" SelectCommandType="StoredProcedure" 
			UpdateCommand="F3002_sp_upd_Loai_San_Pham" UpdateCommandType="StoredProcedure">

			<DeleteParameters>
                <asp:Parameter Name="Auto_ID" />
                <asp:SessionParameter Name="Last_Updated_By" SessionField="Active_User_Name" />
            </DeleteParameters>

			<UpdateParameters>
                <asp:Parameter Name="Auto_ID" Type="Int32" />
                <asp:Parameter Name="Ten_Loai_San_Pham" Type="String" />
                <asp:SessionParameter Name="Last_Updated_By" SessionField="Active_User_Name" Type="String" />
            </UpdateParameters>

			<InsertParameters>
                <asp:Parameter Name="Ten_Loai_San_Pham" Type="String" />
                <asp:SessionParameter Name="Last_Updated_By" SessionField="Active_User_Name" Type="String" />
            </InsertParameters>
		</asp:SqlDataSource>
	</div>
</div>