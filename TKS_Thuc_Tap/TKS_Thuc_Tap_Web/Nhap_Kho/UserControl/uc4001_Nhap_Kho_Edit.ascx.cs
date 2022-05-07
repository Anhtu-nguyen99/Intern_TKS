using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using TKS_Thuc_Tap_Utility;
using TKS_Thuc_Tap_Controller.Danh_Muc;
using TKS_Thuc_Tap_Entity.Danh_Muc;
using TKS_Thuc_Tap_DataLayer;
using System.Text;
using System.Data;


namespace TKS_Thuc_Tap_Web.Nhap_Kho.UserControl
{
	public partial class uc4001_Nhap_Kho_Edit : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				grdData.SettingsSearchPanel.Visible = false;
				Load_Combo_NCC();
				Load_Combo_Kho();
				Init_Data();
				lblSession_Key.Text = CCommonFunction.Create_Random_Session_ID();
				lblSession_Key.Visible = false;
				if (Request.QueryString["Nhap_Kho_ID"] != null)
				{
					Load_Data();
				}
				
			}
		}

		private string Check_Data()
		{
			StringBuilder v_sb = new StringBuilder();

			if (txtNgay_Nhap_Kho.Value == null)
				v_sb.AppendLine("Vui lòng nhập ngày nhập kho. <br/>");

			if (cboNha_Cung_Cap.SelectedIndex < 0)
				v_sb.AppendLine("Vui lòng nhập nhà cung cấp. <br/>");

			if (cboKho.SelectedIndex < 0)
				v_sb.AppendLine("Vui lòng nhập kho. <br/>");

			if (txtSo_Phieu_Nhap.Text.Trim() == "")
				v_sb.AppendLine("Vui lòng nhập số phiếu nhập. <br/>");

			return v_sb.ToString();
		}

		private void Load_Combo_NCC()
		{
			CDM_Nha_Cung_Cap_Controller v_objCtrNCC = new CDM_Nha_Cung_Cap_Controller();
			IList<CDM_Nha_Cung_Cap> v_arrNCC = v_objCtrNCC.List_Nha_Cung_Cap();

			cboNha_Cung_Cap.TextField = "Ten_Nha_Cung_Cap";
			cboNha_Cung_Cap.ValueField = "Auto_ID";
			cboNha_Cung_Cap.DataSource = v_arrNCC;
			cboNha_Cung_Cap.DataBind();
		}

		private void Load_Combo_Kho()
		{
			CDM_Kho_Controller v_objCtrKho = new CDM_Kho_Controller();
			IList<CDM_Kho> v_arrNCC = v_objCtrKho.List_DM_Kho();

			cboKho.TextField = "Ten_Kho";
			cboKho.ValueField = "Auto_ID";
			cboKho.DataSource = v_arrNCC;
			cboKho.DataBind();
		}

		private void Init_Data()
		{
			txtNgay_Nhap_Kho.Date = DateTime.Now;
		}

		private void Assign_Data(CNK_Nhap_Kho p_objNhap_Kho, IList<CNK_Nhap_Kho_Chi_Tiet> p_arrChi_Tiet)
		{
			p_objNhap_Kho.Ngay_Nhap_Kho = txtNgay_Nhap_Kho.Date;
			p_objNhap_Kho.So_Phieu_Nhap = txtSo_Phieu_Nhap.Text;
			p_objNhap_Kho.Kho_ID = CUtility.Convert_To_Int32(cboKho.Value);
			p_objNhap_Kho.Nha_Cung_Cap_ID = CUtility.Convert_To_Int32(cboNha_Cung_Cap.Value);
			p_objNhap_Kho.Ghi_Chu = txtGhi_Chu.Text;

			float v_dblTong_SL = 0;
			float v_dblTong_Tri_Gia = 0;

			foreach (CNK_Nhap_Kho_Chi_Tiet v_objChi_Tiet in p_arrChi_Tiet)
			{
				v_dblTong_SL += v_objChi_Tiet.So_Luong;
				v_dblTong_Tri_Gia += v_objChi_Tiet.So_Luong * v_objChi_Tiet.Don_Gia;
			}

			p_objNhap_Kho.Tong_So_Luong_Nhap = v_dblTong_SL;
			p_objNhap_Kho.Tong_Gia_Tri_Nhap = v_dblTong_Tri_Gia;
			p_objNhap_Kho.Last_Updated_By = CSession.Active_User_Name;
		}

		private void Import_Excel()
		{
			CExcel_Controller v_objCtrExcel = new CExcel_Controller();
			CNK_Nhap_Kho_Chi_Tiet_Controller v_objCtrNKCT = new CNK_Nhap_Kho_Chi_Tiet_Controller();
			CDM_San_Pham_Controller v_objCtrSan_Pham = new CDM_San_Pham_Controller();

			litError.Text = "";
			litError_2.Text = "";

			try
			{
				v_objCtrExcel.Open_File(txtImport_Excel.UploadedFiles[0], CCommonData.g_strPathImportExcel);
				DataTable v_dt = v_objCtrExcel.List_Range_Value_To_End("A2", "F");

				// Loại mấy dòng trống
				for (int v_i = v_dt.Rows.Count - 1; v_i >= 0; v_i--)
					if (v_dt.Rows[v_i][0].ToString().Trim() == "")
						v_dt.Rows.RemoveAt(v_i);

				IList<CDM_San_Pham> v_arrSan_Pham = v_objCtrSan_Pham.List_DM_San_Pham();
				IDictionary<string, CDM_San_Pham> v_dicSan_Pham = new Dictionary<string, CDM_San_Pham>();

				foreach (CDM_San_Pham v_objSan_Pham in v_arrSan_Pham)
				{
					v_dicSan_Pham.Add(v_objSan_Pham.Ma_San_Pham.ToUpper(), v_objSan_Pham);
				}
					

				// Kiểm tra độ hợp lệ của sản phẩm
				StringBuilder v_sb = new StringBuilder();
				int v_iCount = 1;
				foreach (DataRow v_row in v_dt.Rows)
				{
					v_iCount++;

					string v_strMa_San_Pham = v_row[0].ToString().ToUpper();
					if (!v_dicSan_Pham.ContainsKey(v_strMa_San_Pham))
						v_sb.AppendLine("Dòng " + v_iCount + " bị error. Mã sản phẩm " + v_strMa_San_Pham + " không tồn tại trong danh mục.<br/>");
				}

				if (v_sb.ToString() != "")
					throw new Exception(v_sb.ToString());


				foreach (DataRow v_row in v_dt.Rows)
				{

					CNK_Nhap_Kho_Chi_Tiet v_objNKCT = new CNK_Nhap_Kho_Chi_Tiet();
					v_objNKCT.San_Pham_ID = v_dicSan_Pham[v_row[0].ToString().ToUpper()].Auto_ID;
					v_objNKCT.Ma_San_Pham = v_row[0].ToString();
					v_objNKCT.So_Luong = CUtility.Convert_To_Int32(v_row[2]);
					v_objNKCT.Ghi_Chu = v_row[3].ToString();
					v_objNKCT.Don_Gia = CUtility.Convert_To_Int32(v_row[4]);
					v_objNKCT.Session_ID = lblSession_Key.Text;
					
					
					v_objCtrNKCT.Insert_CNK_Nhap_Kho_Chi_Tiet_Temp(v_objNKCT);
				}

				grdData.DataBind();
			}

			catch (Exception ex)
			{
				litError.Text = CCommonFunction.Set_Error_MessageBox(ex.Message);
				litError_2.Text = CCommonFunction.Set_Error_MessageBox(ex.Message);
			}

			finally
			{
				v_objCtrExcel.Close();
			}
		}

		private void Save()
		{
			CNK_Nhap_Kho_Controller v_objCtrNhap_Kho = new CNK_Nhap_Kho_Controller();
			CNK_Nhap_Kho_Chi_Tiet_Controller v_objCtrNKCT = new CNK_Nhap_Kho_Chi_Tiet_Controller();
			litError.Text = "";
			litError_2.Text = "";

			SqlConnection v_conn = null;
			SqlTransaction v_trans = null;
			try
			{
				v_conn = CSqlHelper.CreateConnection(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String);
				v_conn.Open();
				v_trans = v_conn.BeginTransaction();

				string v_strError = Check_Data();
				if (v_strError != "")
					throw new Exception(v_strError);

				int p_intNhap_Kho_ID = CUtility.Convert_To_Int32(Request.QueryString["Nhap_Kho_ID"]);
				IList<CNK_Nhap_Kho_Chi_Tiet> v_arrChi_Tiet = v_objCtrNKCT.List_CNK_Nhap_Kho_Chi_Tiet_Temp_By_Session_ID(lblSession_Key.Text);
				CNK_Nhap_Kho v_objNK = new CNK_Nhap_Kho();

				if (Request.QueryString["Nhap_Kho_ID"] != null)
				{
					v_objNK = v_objCtrNhap_Kho.Get_NK_Thong_Tin_Phieu_Nhap(p_intNhap_Kho_ID);
					Assign_Data(v_objNK, v_arrChi_Tiet);
					v_objCtrNhap_Kho.Update_NK_Nhap_Kho(v_objNK);

					v_objCtrNKCT.Delete_CNK_Nhap_Kho_Chi_Tiet(p_intNhap_Kho_ID);
					foreach (CNK_Nhap_Kho_Chi_Tiet v_objChi_Tiet in v_arrChi_Tiet)
					{
						v_objChi_Tiet.Nhap_Kho_ID = v_objNK.Auto_ID;
						v_objChi_Tiet.Last_Updated_By = CSession.Active_User_Name;
						v_objCtrNKCT.Insert_NK_Nhap_Kho_Chi_Tiet(v_objChi_Tiet);
					}

					v_trans.Commit();
					MessageBox.ShowAndClose_And_Reload_Parent("Lưu phiếu nhập kho thành công.");
					//MessageBox.Show("Lưu phiếu nhập kho thành công.", "/Nhap_Kho/Nhap_Kho_Management.aspx?f=4002");
				}
				else
				{
					Assign_Data(v_objNK, v_arrChi_Tiet);
					v_objNK.Auto_ID = v_objCtrNhap_Kho.Insert_NK_Nhap_Kho(v_objNK);

					// Đưa chi tiết xuống database
					foreach (CNK_Nhap_Kho_Chi_Tiet v_objChi_Tiet in v_arrChi_Tiet)
					{
						v_objChi_Tiet.Nhap_Kho_ID = v_objNK.Auto_ID;
						v_objChi_Tiet.Last_Updated_By = CSession.Active_User_Name;
						v_objCtrNKCT.Insert_NK_Nhap_Kho_Chi_Tiet(v_objChi_Tiet);
					}

					v_trans.Commit();
					MessageBox.ShowAndClose_And_Reload_Parent("Tạo phiếu nhập kho thành công.");
					//MessageBox.Show("Tạo phiếu nhập kho thành công.", "/Nhap_Kho/Nhap_Kho_Management.aspx?f=4002");
				}
			}

			catch (Exception ex)
			{
				if (v_trans != null)
					v_trans.Rollback();

				litError.Text = CCommonFunction.Set_Error_MessageBox(ex.Message);
				litError_2.Text = CCommonFunction.Set_Error_MessageBox(ex.Message);
			}

			finally
			{
				v_trans.Dispose();
				if (v_conn != null)
					v_conn.Close();
			}
		}

		protected void btnImport_Excel_Click(object sender, EventArgs e)
		{
			Import_Excel();
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void Load_Data()
		{
			CNK_Nhap_Kho_Controller v_objCtrNhap_Kho = new CNK_Nhap_Kho_Controller();
			CNK_Nhap_Kho_Chi_Tiet_Controller v_objCtrNKCT = new CNK_Nhap_Kho_Chi_Tiet_Controller();
			CNK_Nhap_Kho v_objNK = new CNK_Nhap_Kho();

			int p_intNhap_Kho_ID = CUtility.Convert_To_Int32(Request.QueryString["Nhap_Kho_ID"]);
			v_objNK = v_objCtrNhap_Kho.Get_NK_Thong_Tin_Phieu_Nhap(p_intNhap_Kho_ID);

			if (v_objNK != null)
			{
				txtSo_Phieu_Nhap.Text = v_objNK.So_Phieu_Nhap;
				txtNgay_Nhap_Kho.Date = v_objNK.Ngay_Nhap_Kho;
				cboNha_Cung_Cap.Value = v_objNK.Nha_Cung_Cap_ID;
				cboKho.Value = v_objNK.Kho_ID;
				txtGhi_Chu.Text = v_objNK.Ghi_Chu;

				IList<CNK_Nhap_Kho_Chi_Tiet> v_arrChi_Tiet = v_objCtrNKCT.List_CNK_Nhap_Kho_Chi_Tiet_By_ID(p_intNhap_Kho_ID);
				foreach (CNK_Nhap_Kho_Chi_Tiet v_objChi_Tiet in v_arrChi_Tiet)
				{
					v_objChi_Tiet.Session_ID = lblSession_Key.Text;
					v_objCtrNKCT.Insert_CNK_Nhap_Kho_Chi_Tiet_Temp(v_objChi_Tiet);
				}
				grdData.DataBind();
			}
		}
	}
}