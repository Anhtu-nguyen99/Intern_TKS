using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TKS_Thuc_Tap_Controller.Danh_Muc;
using TKS_Thuc_Tap_Entity.Danh_Muc;
using TKS_Thuc_Tap_Utility;

namespace TKS_Thuc_Tap_Web.Danh_Muc.UserControl
{
	public partial class uc3006_Phan_Quyen_Kho_User : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Session["Kho_ID_2"] = null;
				LoadRoleComboBox();

				grdData.SettingsSearchPanel.Visible = false;
				grdData.SettingsPager.Mode = DevExpress.Web.GridViewPagerMode.ShowAllRecords;
			}
		}



		private void LoadRoleComboBox()
		{
			CDM_Kho_Controller v_objCtrKho = new CDM_Kho_Controller();

			try
			{
				// Lấy danh sách những nhóm quyền do user này làm quản lý
				IList<CDM_Kho> v_arrKho = v_objCtrKho.List_DM_Kho();

				cboKho.DataSource = v_arrKho;
				cboKho.TextField = "Ten_Kho";
				cboKho.ValueField = "Auto_ID";
				cboKho.DataBind();
			}

			catch (Exception ex)
			{
				CCommonFunction.ShowWarning(ex.Message);
			}
		}

		protected void cboKho_SelectedIndexChanged(object sender, EventArgs e)
		{
			Session["Kho_ID_2"] = int.Parse(cboKho.Value.ToString());
		}
	}
}