using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using TKS_Thuc_Tap_Entity.Danh_Muc;
using TKS_Thuc_Tap_Controller.Danh_Muc;
using TKS_Thuc_Tap_Utility;

namespace TKS_Thuc_Tap_Report.Nhap
{
	public partial class F4005_Phieu_Nhap : DevExpress.XtraReports.UI.XtraReport
	{
		public F4005_Phieu_Nhap(int p_intAuto_ID_Nhap_Kho)
		{
			InitializeComponent();
			lblDayNow.Text= DateTime.Today.ToString();
			IList<CNK_Nhap_Kho_Chi_Tiet> v_arrNhap_Kho_Chi_Tiet = new List<CNK_Nhap_Kho_Chi_Tiet>();
			CNK_Nhap_Kho_Chi_Tiet_Controller v_ctrNKCT = new CNK_Nhap_Kho_Chi_Tiet_Controller();
			v_arrNhap_Kho_Chi_Tiet = v_ctrNKCT.List_CNK_Nhap_Kho_Chi_Tiet_By_ID(p_intAuto_ID_Nhap_Kho);
			p_datasource.DataSource = v_arrNhap_Kho_Chi_Tiet;
		}

	}
}
