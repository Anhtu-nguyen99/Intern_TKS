<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc3006_Phan_Quyen_Kho_User.ascx.cs" Inherits="TKS_Thuc_Tap_Web.Danh_Muc.UserControl.uc3006_Phan_Quyen_Kho_User" %>
<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<div class="row">
	<div class="col-md-12">
        <span style="font-size:11px; font-family: Tahoma">
        - Cho biết user thuộc phân quyền nào.<br />
        - Lưu ý: <br />
        <span style="color:Red">&nbsp;&nbsp;&nbsp;+ Một user có thể có nhiều quyền khác nhau.</span> <br />
        </span>
    </div>
</div>

<div class="row-spacer_20"></div>

<div class="row">
	<div class="col-md-7">
        <h6><strong><i class='fa fa-circle'></i>&nbsp;&nbsp;Phân quyền</strong></h6>
        <div class="TKS_Editor_Form">
            <div class="row border-top background">
                <div class="col-md-2 part-01"><h5>Nhóm User:</h5></div>
                <div class="col-md-6 part-01" style="padding-top:2px;">
                    <dx:ASPxComboBox ID="cboKho" runat="server"
                        AutoPostBack="True" TextField="Ten_Kho" ValueField="Auto_ID" 
                        onselectedindexchanged="cboKho_SelectedIndexChanged" 
                        Theme="Office2010Blue">
                    </dx:ASPxComboBox>  
                </div>
            </div>
        </div>

        <div class="row-spacer_10"></div>

        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-10" style="padding-left: 0px; padding-right: 0px;">
                <dx:ASPxGridView ID="grdData" runat="server" 
                    DataSourceID="SqlDataSource1" 
                    KeyFieldName="Auto_ID" Width="100%" AutoGenerateColumns="False" 
                    Theme="Office2010Blue">
                    <Columns>
						<dx:gridviewdatacomboboxcolumn caption="user" fieldname="Ma_Dang_Nhap" 
                             visibleindex="3" width="100px" visible="false">
                            <PropertiesComboBox DataSourceID="sqldatasource2" TextField="Ma_Dang_Nhap" 
                                ValueField="Ma_Dang_Nhap" ValueType="System.String">
                            </PropertiesComboBox>
                            <editformsettings columnspan="2" visible="true" />
                            <editformcaptionstyle wrap="false">
                            </editformcaptionstyle>
                            <headerstyle font-bold="true" horizontalalign="center" />
                        </dx:gridviewdatacomboboxcolumn>
               
                        <dx:GridViewDataTextColumn Caption="User" FieldName="Ma_Dang_Nhap" 
                            VisibleIndex="1">
                            <EditFormSettings Visible="False" />
                        </dx:GridViewDataTextColumn>
                
                        <dx:GridViewCommandColumn VisibleIndex="4" Width="40px" ShowNewButton="True">
                        </dx:GridViewCommandColumn>
                
                        <dx:GridViewCommandColumn VisibleIndex="5" Width="40px" ShowDeleteButton="True">
                        </dx:GridViewCommandColumn>
                    </Columns>
                </dx:ASPxGridView>
            </div>
        </div> 
    </div>
</div>

<asp:SqlDataSource ID="SqlDataSource1" runat="server"
    ConnectionString="<%$ appSettings:TKS_Thuc_Tap_Data_Conn_String %>" 
    DeleteCommand="F3006_sp_del_Phan_Quyen_Kho_User" DeleteCommandType="StoredProcedure" 
    InsertCommand="F3006_sp_ins_Phan_Quyen_Kho_User" InsertCommandType="StoredProcedure" 
	SelectCommand="F3006_sp_sel_list_Phan_Quyen_Kho_User" SelectCommandType="StoredProcedure">

    <DeleteParameters>
        <asp:Parameter Name="Auto_ID" Type="Int32" />
		<asp:SessionParameter Name="Last_Updated_By" SessionField="Active_User_Name" Type="String" />
    </DeleteParameters>

    <InsertParameters>
		<asp:SessionParameter Name="kho_ID" SessionField="Kho_ID_2" Type="Int32" />
        <asp:Parameter Name="Ma_Dang_Nhap" Type="String" />
        <asp:SessionParameter Name="Last_Updated_By" SessionField="Active_User_Name" Type="String" />
    </InsertParameters>

	<SelectParameters>
		<asp:SessionParameter Name="kho_ID" SessionField="Kho_ID_2" Type="Int32" />
	</SelectParameters>
</asp:SqlDataSource>

<asp:sqldatasource ID="sqldatasource2" runat="server"
    connectionstring="<%$ appSettings:TKS_Thuc_Tap_Admin_Conn_String %>" 
	SelectCommand="F1002_sp_sel_List_Thanh_Vien_NotExist_By_Kho_ID" SelectCommandType="StoredProcedure">

	<SelectParameters>
		<asp:SessionParameter Name="kho_ID" SessionField="Kho_ID_2" Type="Int32" />
	</SelectParameters>
</asp:sqldatasource>

