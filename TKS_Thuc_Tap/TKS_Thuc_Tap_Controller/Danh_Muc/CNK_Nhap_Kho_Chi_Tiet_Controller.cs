using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TKS_Thuc_Tap_Utility;
using TKS_Thuc_Tap_DataLayer;
using TKS_Thuc_Tap_Entity.Danh_Muc;

namespace TKS_Thuc_Tap_Controller.Danh_Muc
{
	public class CNK_Nhap_Kho_Chi_Tiet_Controller
	{
		private void MapCNK_Nhap_Kho_Chi_Tiet(DataRow p_row, CNK_Nhap_Kho_Chi_Tiet p_objDes)
		{
			DataTable p_dt = p_row.Table;

			if (p_dt.Columns.Contains("Auto_ID"))
				p_objDes.Auto_ID = CUtility.Convert_To_Int32(p_row["Auto_ID"]);

			if (p_dt.Columns.Contains("Session_ID"))
				p_objDes.Session_ID = CUtility.Convert_To_String(p_row["Session_ID"]);

			if (p_dt.Columns.Contains("Nhap_Kho_ID"))
				p_objDes.Nhap_Kho_ID = CUtility.Convert_To_Int32(p_row["Nhap_Kho_ID"]);

			if (p_dt.Columns.Contains("San_Pham_ID"))
				p_objDes.San_Pham_ID = CUtility.Convert_To_Int32(p_row["San_Pham_ID"]);

			if (p_dt.Columns.Contains("Ma_San_Pham"))
				p_objDes.Ma_San_Pham = CUtility.Convert_To_String(p_row["Ma_San_Pham"]);

			if (p_dt.Columns.Contains("Ghi_Chu"))
				p_objDes.Ghi_Chu = CUtility.Convert_To_String(p_row["Ghi_Chu"]);

			if (p_dt.Columns.Contains("So_Luong"))
				p_objDes.So_Luong = CUtility.Convert_To_Int32(p_row["So_Luong"]);

			if (p_dt.Columns.Contains("Don_Gia"))
				p_objDes.Don_Gia = CUtility.Convert_To_Int32(p_row["Don_Gia"]);

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

		public IList<CNK_Nhap_Kho_Chi_Tiet> List_CNK_Nhap_Kho_Chi_Tiet_By_ID(int p_intNhap_Kho_ID)
		{
			IList<CNK_Nhap_Kho_Chi_Tiet> v_arrres = new List<CNK_Nhap_Kho_Chi_Tiet>();
			DataTable v_dt = new DataTable();

			try
			{
				CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, v_dt, "sp_sel_List_XNK_Nhap_Kho_Chi_Tiet_By_ID", p_intNhap_Kho_ID);

				foreach (DataRow v_row in v_dt.Rows)
				{
					CNK_Nhap_Kho_Chi_Tiet v_objres = new CNK_Nhap_Kho_Chi_Tiet();
					MapCNK_Nhap_Kho_Chi_Tiet(v_row, v_objres);
					v_arrres.Add(v_objres);
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

			return v_arrres;
		}

		public int Insert_NK_Nhap_Kho_Chi_Tiet(CNK_Nhap_Kho_Chi_Tiet p_objdata)
		{
			int v_ires = CConst.INT_VALUE_NULL;

			try
			{
				v_ires = Convert.ToInt32(CSqlHelper.ExecuteScalar(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, "F4001_sp_ins_Nhap_Kho_Chi_Tiet",
					p_objdata.Nhap_Kho_ID, p_objdata.San_Pham_ID, p_objdata.Don_Gia, p_objdata.So_Luong, p_objdata.Last_Updated_By));
			}

			catch (Exception ex)
			{
				throw ex;
			}

			return v_ires;
		}

		public int Insert_CNK_Nhap_Kho_Chi_Tiet_Temp(CNK_Nhap_Kho_Chi_Tiet p_objdata)
		{
			int v_ires = CConst.INT_VALUE_NULL;

			try
			{
				v_ires = Convert.ToInt32(CSqlHelper.ExecuteScalar(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, "F4001_sp_ins_Nhap_Kho_Chi_Tiet_Temp",
					p_objdata.Session_ID, p_objdata.San_Pham_ID, p_objdata.Ma_San_Pham, p_objdata.Ghi_Chu,
					p_objdata.So_Luong, p_objdata.Don_Gia, p_objdata.Last_Updated_By));
			}

			catch (Exception ex)
			{
				throw ex;
			}

			return v_ires;
		}

		public void Delete_CNK_Nhap_Kho_Chi_Tiet(int p_intNhap_Kho_ID)
		{
			try
			{
				CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, "sp_del_NK_Nhap_Kho_Chi_Tiet", p_intNhap_Kho_ID);
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Delete_CNK_Nhap_Kho_Chi_Tiet_Temp(string Session_ID)
		{
			try
			{
				CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, "sp_del_NK_Nhap_Kho_Chi_Tiet_Temp", Session_ID);
			}

			catch (Exception ex)
			{
				throw ex;
			}
		}

		public IList<CNK_Nhap_Kho_Chi_Tiet> List_CNK_Nhap_Kho_Chi_Tiet_Temp_By_Session_ID(string Session_ID)
		{
			IList<CNK_Nhap_Kho_Chi_Tiet> v_arrres = new List<CNK_Nhap_Kho_Chi_Tiet>();
			DataTable v_dt = new DataTable();

			try
			{
				CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, v_dt, "sp_sel_List_NK_Nhap_Kho_Chi_Tiet_Temp_By_Session_ID", Session_ID);

				foreach (DataRow v_row in v_dt.Rows)
				{
					CNK_Nhap_Kho_Chi_Tiet v_objres = new CNK_Nhap_Kho_Chi_Tiet();
					MapCNK_Nhap_Kho_Chi_Tiet(v_row, v_objres);
					v_arrres.Add(v_objres);
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

			return v_arrres;
		}

		public IList<CNK_Nhap_Kho_Chi_Tiet> List_CNK_Nhap_Kho_Chi_Tiet_Temp()
		{
			IList<CNK_Nhap_Kho_Chi_Tiet> v_arrres = new List<CNK_Nhap_Kho_Chi_Tiet>();
			DataTable v_dt = new DataTable();

			try
			{
				CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, v_dt, "F4001_sp_sel_List_Nhap_Kho_Chi_Tiet_Temp");

				foreach (DataRow v_row in v_dt.Rows)
				{
					CNK_Nhap_Kho_Chi_Tiet v_objres = new CNK_Nhap_Kho_Chi_Tiet();
					MapCNK_Nhap_Kho_Chi_Tiet(v_row, v_objres);
					v_arrres.Add(v_objres);
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

			return v_arrres;
		}
	}
}
