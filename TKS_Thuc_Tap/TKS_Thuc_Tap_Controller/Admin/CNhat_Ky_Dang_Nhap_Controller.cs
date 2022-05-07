using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TKS_Thuc_Tap_DataLayer;
using TKS_Thuc_Tap_Entity.Admin;
using TKS_Thuc_Tap_Utility;
using System.Data;

namespace TKS_Thuc_Tap_Controller.Admin
{
    public class CNhat_Ky_Dang_Nhap_Controller
    {
        private void MapNhat_Ky_Dang_Nhap(DataRow p_row, CNhat_Ky_Dang_Nhap p_objDes)
        {
            DataTable p_dt = p_row.Table;

            if (p_dt.Columns.Contains("Auto_ID"))
                p_objDes.Auto_ID = CUtility.Convert_To_Int32(p_row["Auto_ID"]);

            if (p_dt.Columns.Contains("Ma_Dang_Nhap"))
                p_objDes.Ma_Dang_Nhap = CUtility.Convert_To_String(p_row["Ma_Dang_Nhap"]);

            if (p_dt.Columns.Contains("Thoi_Diem_Dang_Nhap"))
                p_objDes.Thoi_Diem_Dang_Nhap = CUtility.Convert_To_DateTime(p_row["Thoi_Diem_Dang_Nhap"]);

            if (p_dt.Columns.Contains("UserHostAddress"))
                p_objDes.UserHostAddress = CUtility.Convert_To_String(p_row["UserHostAddress"]);

            if (p_dt.Columns.Contains("UserHostName"))
                p_objDes.UserHostName = CUtility.Convert_To_String(p_row["UserHostName"]);

            if (p_dt.Columns.Contains("UserAgent"))
                p_objDes.UserAgent = CUtility.Convert_To_String(p_row["UserAgent"]);

            if (p_dt.Columns.Contains("Deleted"))
                p_objDes.Deleted = CUtility.Convert_To_Int32(p_row["Deleted"]);

            if (p_dt.Columns.Contains("Created"))
                p_objDes.Created = CUtility.Convert_To_DateTime(p_row["Created"]);

            if (p_dt.Columns.Contains("Created_By"))
                p_objDes.Created_By = CUtility.Convert_To_String(p_row["Created_By"]);

            if (p_dt.Columns.Contains("Last_Updated"))
                p_objDes.Last_Updated = CUtility.Convert_To_DateTime(p_row["Last_Updated"]);

            if (p_dt.Columns.Contains("Last_Updated_By"))
                p_objDes.Last_Updated_By = CUtility.Convert_To_String(p_row["Last_Updated_By"]);

        }

        public IList<CNhat_Ky_Dang_Nhap> List_Nhat_Ky_Dang_Nhap()
        {
            IList<CNhat_Ky_Dang_Nhap> v_arrNhat_Ky_Dang_Nhap = new List<CNhat_Ky_Dang_Nhap>();
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_List_Nhat_Ky_Dang_Nhap");

                foreach (DataRow v_row in v_dt.Rows)
                {
                    CNhat_Ky_Dang_Nhap v_objNhat_Ky_Dang_Nhap = new CNhat_Ky_Dang_Nhap();
                    MapNhat_Ky_Dang_Nhap(v_row, v_objNhat_Ky_Dang_Nhap);
                    v_arrNhat_Ky_Dang_Nhap.Add(v_objNhat_Ky_Dang_Nhap);
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

            return v_arrNhat_Ky_Dang_Nhap;
        }

        public CNhat_Ky_Dang_Nhap Get_Nhat_Ky_Dang_Nhap_By_ID(int p_iID)
        {
            CNhat_Ky_Dang_Nhap v_objNhat_Ky_Dang_Nhap = null;
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_Get_Nhat_Ky_Dang_Nhap_By_ID", p_iID);

                if (v_dt.Rows.Count > 0)
                {
                    v_objNhat_Ky_Dang_Nhap = new CNhat_Ky_Dang_Nhap();
                    MapNhat_Ky_Dang_Nhap(v_dt.Rows[0], v_objNhat_Ky_Dang_Nhap);
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

            return v_objNhat_Ky_Dang_Nhap;
        }

        public int Insert_Nhat_Ky_Dang_Nhap(CNhat_Ky_Dang_Nhap p_objData)
        {
            int v_iRes = CConst.INT_VALUE_NULL;

            try
            {
                v_iRes = Convert.ToInt32(CSqlHelper.ExecuteScalar(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_ins_Nhat_Ky_Dang_Nhap",
                            p_objData.Ma_Dang_Nhap, p_objData.Thoi_Diem_Dang_Nhap, p_objData.UserHostAddress, p_objData.UserHostName, p_objData.UserAgent, p_objData.Last_Updated_By).ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return v_iRes;
        }

        public void Update_Nhat_Ky_Dang_Nhap(CNhat_Ky_Dang_Nhap p_objData)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_upd_Nhat_Ky_Dang_Nhap",
                            p_objData.Auto_ID, p_objData.Ma_Dang_Nhap, p_objData.Thoi_Diem_Dang_Nhap, p_objData.UserHostAddress, p_objData.UserHostName, p_objData.UserAgent, p_objData.Last_Updated_By);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_Nhat_Ky_Dang_Nhap(int p_iID, string p_strLast_Updated_User)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_del_Nhat_Ky_Dang_Nhap", p_iID, p_strLast_Updated_User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    } 

}
