using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TKS_Thuc_Tap_Entity.Admin;
using TKS_Thuc_Tap_Utility;
using TKS_Thuc_Tap_DataLayer;

namespace TKS_Thuc_Tap_Controller.Admin
{
    public class CChuc_Nang_Controller
    {
        private void MapChuc_Nang(DataRow p_row, CChuc_Nang p_objDes)
        {
            DataTable p_dt = p_row.Table;

            if (p_dt.Columns.Contains("Auto_ID"))
                p_objDes.Auto_ID = CUtility.Convert_To_Int32(p_row["Auto_ID"]);

            if (p_dt.Columns.Contains("Func_Code"))
                p_objDes.Func_Code = CUtility.Convert_To_String(p_row["Func_Code"]);

            if (p_dt.Columns.Contains("Sort_Priority"))
                p_objDes.Sort_Priority = CUtility.Convert_To_Int32(p_row["Sort_Priority"]);

            if (p_dt.Columns.Contains("Parent_Func_ID"))
                p_objDes.Parent_Func_ID = CUtility.Convert_To_Int32(p_row["Parent_Func_ID"]);

            if (p_dt.Columns.Contains("Func_Group_ID"))
                p_objDes.Func_Group_ID = CUtility.Convert_To_Int32(p_row["Func_Group_ID"]);

            if (p_dt.Columns.Contains("Is_View"))
                p_objDes.Is_View = CUtility.Convert_To_Bool(p_row["Is_View"]);

            if (p_dt.Columns.Contains("Is_New"))
                p_objDes.Is_New = CUtility.Convert_To_Bool(p_row["Is_New"]);

            if (p_dt.Columns.Contains("Is_Edit"))
                p_objDes.Is_Edit = CUtility.Convert_To_Bool(p_row["Is_Edit"]);

            if (p_dt.Columns.Contains("Is_Delete"))
                p_objDes.Is_Delete = CUtility.Convert_To_Bool(p_row["Is_Delete"]);

            //if (p_dt.Columns.Contains("Created"))
            //    p_objDes.Created = CUtility.Convert_To_DateTime(p_row["Created"]);

            //if (p_dt.Columns.Contains("Created_By"))
            //    p_objDes.Created_By = CUtility.Convert_To_String(p_row["Created_By"]);

            //if (p_dt.Columns.Contains("Deleted"))
            //    p_objDes.Deleted = CUtility.Convert_To_Int32(p_row["Deleted"]);

            if (p_dt.Columns.Contains("Last_Updated"))
                p_objDes.Last_Updated = CUtility.Convert_To_DateTime(p_row["Last_Updated"]);

            if (p_dt.Columns.Contains("Last_Updated_By"))
                p_objDes.Last_Updated_By = CUtility.Convert_To_String(p_row["Last_Updated_By"]);

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

        }
        /// <summary>
        /// Lấy danh sách function theo group và lang_id
        /// </summary>
        /// <param name="p_iFuncGroupID"></param>
        /// <param name="p_strLangID"></param>
        /// <returns></returns>
        public IList<CChuc_Nang> F1001_List_Chuc_Nang(int p_iFuncGroupID, string p_strLangID)
        {
            IList<CChuc_Nang> v_arrChuc_Nang = new List<CChuc_Nang>();
            DataTable v_dt = new DataTable();

            try
            {
                // Fill dữ liệu vào datatable
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "F1001_sp_sel_List_Chuc_Nang_Func_Group_ID_Lang_ID",
                    p_iFuncGroupID, p_strLangID);

                // Map qua IList
                foreach (DataRow v_row in v_dt.Rows)
                {
                    CChuc_Nang v_objChuc_Nang = new CChuc_Nang();
                    MapChuc_Nang(v_row, v_objChuc_Nang);
                    v_arrChuc_Nang.Add(v_objChuc_Nang);
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

            return v_arrChuc_Nang;
        }
        
        /// <summary>
        /// Lấy danh sách function theo group và lang_id
        /// </summary>
        /// <param name="p_iFuncGroupID"></param>
        /// <param name="p_strLangID"></param>
        /// <returns></returns>
        public IList<CChuc_Nang> F1001_List_Chuc_Nang_Func_Group_ID(int p_iFuncGroupID, string p_strLangID)
        {
            IList<CChuc_Nang> v_arrChuc_Nang = new List<CChuc_Nang>();
            DataTable v_dt = new DataTable();

            try
            {
                // Fill dữ liệu vào datatable
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "F1001_sp_sel_List_Chuc_Nang_Func_Group_ID_Lang_ID",
                    p_iFuncGroupID, p_strLangID);

                // Map qua IList
                foreach (DataRow v_row in v_dt.Rows)
                {
                    CChuc_Nang v_objChuc_Nang = new CChuc_Nang();
                    MapChuc_Nang(v_row, v_objChuc_Nang);
                    v_arrChuc_Nang.Add(v_objChuc_Nang);
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

            return v_arrChuc_Nang;
        }

        /// <summary>
        /// Lấy danh sách function theo group và lang_id
        /// </summary>
        /// <param name="p_iFuncGroupID"></param>
        /// <param name="p_strLangID"></param>
        /// <returns></returns>
        public IList<CChuc_Nang> List_Chuc_Nang_Func_Group_ID_Lang_ID(int p_iFuncGroupID, string p_strLangID)
        {
            IList<CChuc_Nang> v_arrChuc_Nang = new List<CChuc_Nang>();
            DataTable v_dt = new DataTable();

            try
            {
                // Fill dữ liệu vào datatable
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_List_Chuc_Nang_Func_Group_ID_Lang_ID",
                    p_iFuncGroupID, p_strLangID);

                // Map qua IList
                foreach (DataRow v_row in v_dt.Rows)
                {
                    CChuc_Nang v_objChuc_Nang = new CChuc_Nang();
                    MapChuc_Nang(v_row, v_objChuc_Nang);
                    v_arrChuc_Nang.Add(v_objChuc_Nang);
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

            return v_arrChuc_Nang;
        }

        public CChuc_Nang Get_Chuc_Nang_By_Func_By_LangID(int p_iFuncGroupID, string p_strLangID)
        {
            CChuc_Nang v_objChuc_Nang = null;
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_Get_Chuc_Nang_By_Func_By_LangID", p_iFuncGroupID, p_strLangID);

                if (v_dt.Rows.Count > 0)
                {
                    v_objChuc_Nang = new CChuc_Nang();
                    MapChuc_Nang(v_dt.Rows[0], v_objChuc_Nang);
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

            return v_objChuc_Nang;
        }

        public CChuc_Nang Get_Chuc_Nang_By_ID(int p_iID)
        {
            CChuc_Nang v_objChuc_Nang = null;
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_Get_Chuc_Nang_By_ID", p_iID);

                if (v_dt.Rows.Count > 0)
                {
                    v_objChuc_Nang = new CChuc_Nang();
                    MapChuc_Nang(v_dt.Rows[0], v_objChuc_Nang);
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

            return v_objChuc_Nang;
        }

        public int Insert_Chuc_Nang(CChuc_Nang p_objData)
        {
            int v_iRes = CConst.INT_VALUE_NULL;

            try
            {
                v_iRes = Convert.ToInt32(CSqlHelper.ExecuteScalar(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_ins_Chuc_Nang",
                            p_objData.Func_Code, p_objData.Sort_Priority, p_objData.Parent_Func_ID, p_objData.Func_Group_ID, p_objData.Is_View, p_objData.Is_New, p_objData.Is_Edit, p_objData.Is_Delete, p_objData.Last_Updated_By).ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return v_iRes;
        }

        public void Update_Chuc_Nang(CChuc_Nang p_objData)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_upd_Chuc_Nang",
                            p_objData.Auto_ID, p_objData.Func_Code, p_objData.Sort_Priority, p_objData.Parent_Func_ID, p_objData.Func_Group_ID, p_objData.Is_View, p_objData.Is_New, p_objData.Is_Edit, p_objData.Is_Delete, p_objData.Last_Updated_By);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_Chuc_Nang(int p_iID, string p_strLast_Updated_User)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_del_Chuc_Nang", p_iID, p_strLast_Updated_User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy danh sách function theo group và lang_id
        /// </summary>
        /// <param name="p_iFuncGroupID"></param>
        /// <param name="p_strLangID"></param>
        /// <returns></returns>
        public CChuc_Nang F1001_Get_Chuc_Nang_By_AutoID(int p_intFuncID, string p_strLangID)
        {
            CChuc_Nang v_objRes = null;
            DataTable v_dt = new DataTable();

            try
            {
                // Fill dữ liệu vào datatable
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "F1001_sp_sel_Get_Chuc_Nang_By_AutoID",
                    p_intFuncID, p_strLangID);

                //Kiểm tra dữ liệu 
                if (v_dt.Rows.Count > 0)
                {
                    v_objRes = new CChuc_Nang();
                    MapChuc_Nang(v_dt.Rows[0], v_objRes);
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

        /// <summary>
        /// Lấy danh sách function theo group và lang_id
        /// </summary>
        /// <param name="p_iFuncGroupID"></param>
        /// <param name="p_strLangID"></param>
        /// <returns></returns>
        public IList<CChuc_Nang> sp_sel_List_Chuc_Nang(int p_iFuncGroupID, string p_strLangID)
        {
            IList<CChuc_Nang> v_arrChuc_Nang = new List<CChuc_Nang>();
            DataTable v_dt = new DataTable();

            try
            {
                // Fill dữ liệu vào datatable
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_List_Chuc_Nang",
                    p_iFuncGroupID, p_strLangID);

                // Map qua IList
                foreach (DataRow v_row in v_dt.Rows)
                {
                    CChuc_Nang v_objChuc_Nang = new CChuc_Nang();
                    MapChuc_Nang(v_row, v_objChuc_Nang);
                    v_arrChuc_Nang.Add(v_objChuc_Nang);
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

            return v_arrChuc_Nang;
        }

        /// <summary>
        /// Lấy danh sách chức năng
        /// /// </summary>
        /// <param name="p_iFuncGroupID"></param>
        /// <param name="p_strLangID"></param>
        /// <returns></returns>
        public IList<CChuc_Nang> List_All_Chuc_Nang()
        {
            IList<CChuc_Nang> v_arrChuc_Nang = new List<CChuc_Nang>();
            DataTable v_dt = new DataTable();

            try
            {
                // Fill dữ liệu vào datatable
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_List_All_Chuc_Nang");

                // Map qua IList
                foreach (DataRow v_row in v_dt.Rows)
                {
                    CChuc_Nang v_objChuc_Nang = new CChuc_Nang();
                    MapChuc_Nang(v_row, v_objChuc_Nang);
                    v_arrChuc_Nang.Add(v_objChuc_Nang);
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

            return v_arrChuc_Nang;
        }
    }
}
