using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using TKS_Thuc_Tap_Utility;
using TKS_Thuc_Tap_DataLayer;
using TKS_Thuc_Tap_Entity.Danh_Muc;

namespace TKS_Thuc_Tap_Controller.Danh_Muc
{
	public class CNK_Nhap_Kho_Controller
	{
		private void MapCNK_Nhap_Kho(DataRow p_row, CNK_Nhap_Kho p_objDes)
		{
			DataTable p_dt = p_row.Table;

			if (p_dt.Columns.Contains("Auto_ID"))
				p_objDes.Auto_ID = CUtility.Convert_To_Int32(p_row["Auto_ID"]);

			if (p_dt.Columns.Contains("So_Phieu_Nhap"))
				p_objDes.So_Phieu_Nhap = CUtility.Convert_To_String(p_row["So_Phieu_Nhap"]);

			if (p_dt.Columns.Contains("Ngay_Nhap_Kho"))
				p_objDes.Ngay_Nhap_Kho = CUtility.Convert_To_DateTime(p_row["Ngay_Nhap_Kho"]);

			if (p_dt.Columns.Contains("Nha_Cung_Cap_ID"))
				p_objDes.Nha_Cung_Cap_ID = CUtility.Convert_To_Int32(p_row["Nha_Cung_Cap_ID"]);

			if (p_dt.Columns.Contains("Kho_ID"))
				p_objDes.Kho_ID = CUtility.Convert_To_Int32(p_row["Kho_ID"]);

			if (p_dt.Columns.Contains("Ghi_Chu"))
				p_objDes.Ghi_Chu = CUtility.Convert_To_String(p_row["Ghi_Chu"]);

			if (p_dt.Columns.Contains("Tong_Gia_Tri_Nhap"))
				p_objDes.Tong_Gia_Tri_Nhap = CUtility.Convert_To_Int32(p_row["Tong_Gia_Tri_Nhap"]);

			if (p_dt.Columns.Contains("Tong_So_Luong_Nhap"))
				p_objDes.Tong_So_Luong_Nhap = CUtility.Convert_To_Int32(p_row["Tong_So_Luong_Nhap"]);

			if (p_dt.Columns.Contains("deleted"))
				p_objDes.deleted = CUtility.Convert_To_Int32(p_row["deleted"]);

			if (p_dt.Columns.Contains("Created"))
				p_objDes.Created = CUtility.Convert_To_DateTime(p_row["Created"]);

			if (p_dt.Columns.Contains("Created_By"))
				p_objDes.Created_By = CUtility.Convert_To_String(p_row["Created_By"]);

			if (p_dt.Columns.Contains("Last_Updated"))
				p_objDes.Last_Updated = CUtility.Convert_To_DateTime(p_row["Last_Updated"]);

			if (p_dt.Columns.Contains("Last_Updated_By"))
				p_objDes.Last_Updated_By = CUtility.Convert_To_String(p_row["Last_Updated_By"]);
		}

		public int Insert_NK_Nhap_Kho(CNK_Nhap_Kho p_objData)
		{
			int v_iRes = CConst.INT_VALUE_NULL;

			try
			{
				v_iRes = Convert.ToInt32(CSqlHelper.ExecuteScalar(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, "F4002_sp_ins_Nhap_Kho",
					p_objData.So_Phieu_Nhap, p_objData.Ngay_Nhap_Kho, p_objData.Nha_Cung_Cap_ID, p_objData.Kho_ID, p_objData.Ghi_Chu,
					p_objData.Tong_So_Luong_Nhap, p_objData.Tong_Gia_Tri_Nhap,
					p_objData.Last_Updated_By));
			}

			catch (Exception ex)
			{
				throw ex;
			}

			return v_iRes;
		}

		public void Update_NK_Nhap_Kho(CNK_Nhap_Kho p_objData)
		{
			try
			{
				CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, "F4002_sp_upd_Nhap_Kho", p_objData.Auto_ID,
					p_objData.So_Phieu_Nhap, p_objData.Ngay_Nhap_Kho, p_objData.Nha_Cung_Cap_ID, p_objData.Kho_ID, p_objData.Ghi_Chu,
					p_objData.Tong_So_Luong_Nhap, p_objData.Tong_Gia_Tri_Nhap, p_objData.Last_Updated_By);
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		public CNK_Nhap_Kho Get_NK_Thong_Tin_Phieu_Nhap(int p_intAuto_ID)
		{
			CNK_Nhap_Kho v_objRes = null;
			DataTable v_dt = new DataTable();

			try
			{
				CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, v_dt, "F4003_sp_sel_Get_NK_Thong_Tin_Phieu_Nhap_By_ID", p_intAuto_ID);

				if (v_dt.Rows.Count > 0)
				{
					v_objRes = new CNK_Nhap_Kho();
					MapCNK_Nhap_Kho(v_dt.Rows[0], v_objRes);
				}
			}

			catch (Exception ex)
			{
				throw ex;
			}

			finally
			{
				v_dt.Dispose();
			}

			return v_objRes;
		}
	}
}
