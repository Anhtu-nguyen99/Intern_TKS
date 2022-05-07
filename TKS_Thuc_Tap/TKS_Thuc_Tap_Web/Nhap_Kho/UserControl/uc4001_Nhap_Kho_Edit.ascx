<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc4001_Nhap_Kho_Edit.ascx.cs" Inherits="TKS_Thuc_Tap_Web.Nhap_Kho.UserControl.uc4001_Nhap_Kho_Edit" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<div class="row">
	<div class="col-md-12">
            <span style="font-size:11px; font-family: Tahoma">
            - Tạo phiếu nhập kho.<br />
            - Lưu ý: <br />
                <span style="color:Red">&nbsp;&nbsp;&nbsp;+ Bắt buộc phải nhập nhà cung cấp và kho.</span> <br />
                <span style="color:Red">&nbsp;&nbsp;&nbsp;+ Số phiếu nhập là duy nhất .</span> <br />
            </span>
    </div>
</div>
<div class="row-spacer_20"></div>
<dx:ASPxLabel ID="lblSession_Key" runat="server" Visible="false">
</dx:ASPxLabel>

<div class="TKS_Editor_Form">
    <div class="row">
		<div class="col-md-8">
            <h6><strong><i class='fa fa-circle'></i>&nbsp;&nbsp;Thông Tin Phiếu</strong></h6>
            <asp:Literal ID="litError" runat="server"></asp:Literal>
			<div class="row border-top background">
            	<div class="col-md-2 part-01">
                	<h5>Số Phiếu Nhập:</h5>
                </div>
                <div class="col-md-10 part-02">
                    <dx:ASPxTextBox ID="txtSo_Phieu_Nhap" runat="server" Theme="Office2010Blue">
                    </dx:ASPxTextBox>
                </div>
            </div>

            <div class="row border-top background">
            	<div class="col-md-2 part-01">
                	<h5>Ngày nhập kho:</h5>
                </div>
                <div class="col-md-4 part-02">
                    <dx:ASPxDateEdit ID="txtNgay_Nhap_Kho" runat="server" Theme="Office2010Blue" >
                    </dx:ASPxDateEdit>
                </div>
            </div>

            <div class="row border-top background">
            	<div class="col-md-2 part-01">
                	<h5>Kho:</h5>
                </div>
                <div class="col-md-4 part-02">
                    <dx:ASPxComboBox ID="cboKho" runat="server" Theme="Office2010Blue" ValueType="System.Int32">
                    </dx:ASPxComboBox>
                </div>
            </div>

            <div class="row border-top background">
            	<div class="col-md-2 part-01">
                	<h5>Nhà Cung Cấp:</h5>
                </div>
                <div class="col-md-4 part-02">
                    <dx:ASPxComboBox ID="cboNha_Cung_Cap" runat="server" Theme="Office2010Blue" ValueType="System.Int32">
                    </dx:ASPxComboBox>
                </div>
            </div>

            <div class="row border-top background">
            	<div class="col-md-2 part-01">
                	<h5>Ghi Chú:</h5>
                </div>
                <div class="col-md-10 part-02">
                    <dx:ASPxMemo ID="txtGhi_Chu" runat="server" Height="71px" Theme="Office2010Blue" >
                    </dx:ASPxMemo>
                </div>
            </div>
        </div>
    </div>
</div>

<div class="row-spacer_20"></div>

<div class="row">
	<div class="col-md-12">
        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowHeader="False" Width="100%" Theme="Office2010Blue">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <asp:Literal ID="litError_2" runat="server"></asp:Literal>
                    <div class="row">
		                <div class="col-md-6">
                            <dx:ASPxUploadControl ID="txtImport_Excel" runat="server" UploadMode="Standard" Theme="Office2010Blue" Width="100%" >
                            </dx:ASPxUploadControl>
                        </div>
                        <div class="col-md-2">
                            <dx:ASPxButton ID="btnImport_Excel" runat="server" Text="Import Excel" Theme="Office2010Blue" OnClick="btnImport_Excel_Click">
                            </dx:ASPxButton>
                        </div>
                        <div class="col-md-2" style="padding-top: 5px;">
                            <a href="/FileManagement/Template/Nhap_Kho_Template.xlsx">Download Template</a>
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
            Width="100%" 
            KeyFieldName="Auto_ID" 
            Theme="Office2010Blue" ClientInstanceName="grdData" 
            AutoGenerateColumns="False" EnableTheming="True" DataSourceID="sqlData" >    
    
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

				<dx:GridViewDataTextColumn Caption="Mã sản phẩm" FieldName="Ma_San_Pham" VisibleIndex="1" Width="60px">
					<EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>

				<dx:GridViewDataSpinEditColumn Caption="Số Lượng" FieldName="So_Luong" VisibleIndex="5" Width="80px">
                    <PropertiesSpinEdit DisplayFormatString="g">
                    </PropertiesSpinEdit>
                </dx:GridViewDataSpinEditColumn>

                <dx:GridViewDataComboBoxColumn Caption="Tên sản phẩm" FieldName="San_Pham_ID" VisibleIndex="3" Width="80">
					<PropertiesComboBox DataSourceID="sql1" ValueField="Auto_ID" TextField="Ten_San_Pham">
					</PropertiesComboBox>
					<CellStyle HorizontalAlign="Left"></CellStyle>
                </dx:GridViewDataComboBoxColumn>

				<dx:GridViewDataTextColumn Caption="Ghi chú" FieldName="Ghi_Chu" VisibleIndex="6" Width="60px">
					<EditFormSettings Visible="False" />
                </dx:GridViewDataTextColumn>

                <dx:GridViewDataSpinEditColumn Caption="Đơn Giá" FieldName="Don_Gia" VisibleIndex="7" Width="80px">
                    <PropertiesSpinEdit DisplayFormatString="g">
                    </PropertiesSpinEdit>
                </dx:GridViewDataSpinEditColumn>

				<dx:GridViewCommandColumn VisibleIndex="9" Width="40px" ShowNewButton="True">
                </dx:GridViewCommandColumn>
				<dx:GridViewCommandColumn VisibleIndex="10" Width="40px" ShowEditButton="True">
                </dx:GridViewCommandColumn>
				<dx:GridViewCommandColumn VisibleIndex="11" Width="40px" ShowDeleteButton="True">
                </dx:GridViewCommandColumn>
            </Columns>
        </dx:ASPxGridView>

        <asp:SqlDataSource ID="sqlData" runat="server" 
            ConnectionString="<%$ appSettings:TKS_Thuc_Tap_Data_Conn_String %>"
			DeleteCommand="F4001_sp_del_Nhap_Kho_Chi_Tiet_Temp" DeleteCommandType="StoredProcedure"
			SelectCommand="F4001_sp_sel_List_Nhap_Kho_Chi_Tiet_Temp" SelectCommandType="StoredProcedure" 
            UpdateCommand="F4001_sp_upd_Nhap_Kho_Chi_Tiet_Temp" UpdateCommandType="StoredProcedure"
			InsertCommand="F4001_sp_ins_Nhap_Kho_Chi_Tiet_Temp" InsertCommandType="StoredProcedure">

            <DeleteParameters>
				<asp:Parameter Name="Auto_ID" />
            </DeleteParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="lblSession_Key" Name="Session_ID" PropertyName="Text" />
            </SelectParameters>
            <UpdateParameters>
                <asp:ControlParameter ControlID="lblSession_Key" Name="Session_ID" PropertyName="Text" />
                <asp:Parameter Name="San_Pham_ID" />
                <asp:Parameter Name="So_Luong" />
				<asp:Parameter Name="Don_Gia" />
                <asp:SessionParameter Name="Last_Updated_By" SessionField="Active_User_Name" Type="String" />
            </UpdateParameters>
            <InsertParameters>
                <asp:ControlParameter ControlID="lblSession_Key" Name="Session_ID" PropertyName="Text" />
				<asp:Parameter Name="Ma_San_Pham" />
				<asp:Parameter Name="Ghi_Chu" />
				<asp:Parameter Name="San_Pham_ID" />
				<asp:Parameter Name="Don_Gia" />
				<asp:Parameter Name="So_Luong" />
                <asp:SessionParameter Name="Last_Updated_By" SessionField="Active_User_Name" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
		<asp:SqlDataSource ID="sql1" runat="server" 
			ConnectionString="<%$ appSettings:TKS_Thuc_Tap_Data_Conn_String %>"
			SelectCommand="sp_sel_List_DM_San_Pham" SelectCommandType="StoredProcedure">
		</asp:SqlDataSource>
    </div>
</div>

<div class="row-spacer_20"></div>

<div class="row">
    <div class="col-md-12" >
        <div align="right">
            <dx:ASPxButton ID="btnSave" runat="server" Text="Lưu" height="35px"
                Theme="Office2010Blue" OnClick="btnSave_Click">
            </dx:ASPxButton>
        </div>
    </div>
</div>
