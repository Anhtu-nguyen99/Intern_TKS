using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.Web.UI.HtmlControls;
using TKS_Thuc_Tap_Utility;

namespace TKS_Thuc_Tap_Web.Nhap_Kho.UserControl
{
	public partial class uc1718_Nhap_Kho_Management : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				//((GridViewDataColumn)grdData.Columns[1]).DataItemTemplate = new MyHyperlinkTemplate();
				this.dtmNgay_Bat_Dau.Date = DateTime.Now.AddMonths(-1);
				this.dtmNgay_Ket_Thuc.Date = DateTime.Now.AddDays(+1);

				Session["S3003_Ngay_Bat_Dau"] = CUtility.Convert_To_Dau_Ngay(this.dtmNgay_Bat_Dau.Date);
				Session["S3003_Ngay_Ket_Thuc"] = CUtility.Convert_To_Cuoi_Ngay(this.dtmNgay_Ket_Thuc.Date);
			}
		}

		protected void NhapKhoEdit()
		{
			Response.Redirect("Nhap_Kho_Edit.aspx");
		}

		protected void btnView_Click(object sender, EventArgs e)
		{
			Session["S3003_Ngay_Bat_Dau"] = CUtility.Convert_To_Dau_Ngay(this.dtmNgay_Bat_Dau.Date);
			Session["S3003_Ngay_Ket_Thuc"] = CUtility.Convert_To_Cuoi_Ngay(this.dtmNgay_Ket_Thuc.Date);
		}
	}
}