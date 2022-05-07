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
    public class CChuc_Nang_Language_Controller
    {
        private void MapChuc_Nang_Language(DataRow p_row, CChuc_Nang_Language p_objDes)
        {
            DataTable p_dt = p_row.Table;

            if (p_dt.Columns.Contains("Auto_ID"))
                p_objDes.Auto_ID = CUtility.Convert_To_Int32(p_row["Auto_ID"]);

            if (p_dt.Columns.Contains("Ma_Chuc_Nang"))
                p_objDes.Ma_Chuc_Nang = CUtility.Convert_To_Int32(p_row["Ma_Chuc_Nang"]);

            if (p_dt.Columns.Contains("Lang_ID"))
                p_objDes.Lang_ID = CUtility.Convert_To_String(p_row["Lang_ID"]);

            if (p_dt.Columns.Contains("Ten_Chuc_Nang"))
                p_objDes.Ten_Chuc_Nang = CUtility.Convert_To_String(p_row["Ten_Chuc_Nang"]);

            if (p_dt.Columns.Contains("Image_URL"))
                p_objDes.Image_URL = CUtility.Convert_To_String(p_row["Image_URL"]);

            if (p_dt.Columns.Contains("Func_URL"))
                p_objDes.Func_URL = CUtility.Convert_To_String(p_row["Func_URL"]);

            if (p_dt.Columns.Contains("Mo_Ta_Chuc_Nang"))
                p_objDes.Mo_Ta_Chuc_Nang = CUtility.Convert_To_String(p_row["Mo_Ta_Chuc_Nang"]);

            if (p_dt.Columns.Contains("Created"))
                p_objDes.Created = CUtility.Convert_To_DateTime(p_row["Created"]);

            if (p_dt.Columns.Contains("Created_By"))
                p_objDes.Created_By = CUtility.Convert_To_String(p_row["Created_By"]);

            if (p_dt.Columns.Contains("Deleted"))
                p_objDes.Deleted = CUtility.Convert_To_Int32(p_row["Deleted"]);

            if (p_dt.Columns.Contains("Last_Updated"))
                p_objDes.Last_Updated = CUtility.Convert_To_DateTime(p_row["Last_Updated"]);

            if (p_dt.Columns.Contains("Last_Updated_By"))
                p_objDes.Last_Updated_By = CUtility.Convert_To_String(p_row["Last_Updated_By"]);

        }

        public IList<CChuc_Nang_Language> List_Chuc_Nang_Language()
        {
            IList<CChuc_Nang_Language> v_arrChuc_Nang_Language = new List<CChuc_Nang_Language>();
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_List_Chuc_Nang_Language");

                foreach (DataRow v_row in v_dt.Rows)
                {
                    CChuc_Nang_Language v_objChuc_Nang_Language = new CChuc_Nang_Language();
                    MapChuc_Nang_Language(v_row, v_objChuc_Nang_Language);
                    v_arrChuc_Nang_Language.Add(v_objChuc_Nang_Language);
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

            return v_arrChuc_Nang_Language;
        }

        public CChuc_Nang_Language Get_Chuc_Nang_Language_By_ID(int p_iID)
        {
            CChuc_Nang_Language v_objChuc_Nang_Language = null;
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_Get_Chuc_Nang_Language_By_ID", p_iID);

                if (v_dt.Rows.Count > 0)
                {
                    v_objChuc_Nang_Language = new CChuc_Nang_Language();
                    MapChuc_Nang_Language(v_dt.Rows[0], v_objChuc_Nang_Language);
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

            return v_objChuc_Nang_Language;
        }

        public int Insert_Chuc_Nang_Language(CChuc_Nang_Language p_objData)
        {
            int v_iRes = CConst.INT_VALUE_NULL;

            try
            {
                v_iRes = Convert.ToInt32(CSqlHelper.ExecuteScalar(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_ins_Chuc_Nang_Language",
                            p_objData.Ma_Chuc_Nang, p_objData.Lang_ID, p_objData.Ten_Chuc_Nang, p_objData.Image_URL, p_objData.Func_URL, p_objData.Mo_Ta_Chuc_Nang, p_objData.Last_Updated_By).ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return v_iRes;
        }

        public void Update_Chuc_Nang_Language(CChuc_Nang_Language p_objData)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_upd_Chuc_Nang_Language",
                            p_objData.Auto_ID, p_objData.Ma_Chuc_Nang, p_objData.Lang_ID, p_objData.Ten_Chuc_Nang, p_objData.Image_URL, p_objData.Func_URL, p_objData.Mo_Ta_Chuc_Nang, p_objData.Last_Updated_By);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_Chuc_Nang_Language(int p_iID, string p_strLast_Updated_User)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_del_Chuc_Nang_Language", p_iID, p_strLast_Updated_User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
