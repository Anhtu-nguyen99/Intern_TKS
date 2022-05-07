using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using TKS_Thuc_Tap_DataLayer;
using TKS_Thuc_Tap_Utility;
using TKS_Thuc_Tap_Entity.Admin;
using System.Data;

namespace TKS_Thuc_Tap_Controller.Admin
{
    public class CNhom_Quyen_Controller
    {
        private void MapNhom_Quyen(DataRow p_row, CNhom_Quyen p_objDes)
        {
            DataTable p_dt = p_row.Table;

            if (p_dt.Columns.Contains("Auto_ID"))
                p_objDes.Auto_ID = CUtility.Convert_To_Int32(p_row["Auto_ID"]);

            if (p_dt.Columns.Contains("Ten_Nhom"))
                p_objDes.Ten_Nhom = CUtility.Convert_To_String(p_row["Ten_Nhom"]);

            if (p_dt.Columns.Contains("Mo_Ta"))
                p_objDes.Mo_Ta = CUtility.Convert_To_String(p_row["Mo_Ta"]);

            if (p_dt.Columns.Contains("Icon_Index"))
                p_objDes.Icon_Index = CUtility.Convert_To_Int32(p_row["Icon_Index"]);

            if (p_dt.Columns.Contains("Parent_Role_ID"))
                p_objDes.Parent_Role_ID = CUtility.Convert_To_Int32(p_row["Parent_Role_ID"]);

            if (p_dt.Columns.Contains("Created"))
                p_objDes.Created = CUtility.Convert_To_DateTime(p_row["Created"]);

            if (p_dt.Columns.Contains("Created_By"))
                p_objDes.Created_By = CUtility.Convert_To_String(p_row["Created_By"]);

            if (p_dt.Columns.Contains("Sort_Priority"))
                p_objDes.Sort_Priority = CUtility.Convert_To_Int32(p_row["Sort_Priority"]);

            if (p_dt.Columns.Contains("Deleted"))
                p_objDes.Deleted = CUtility.Convert_To_Int32(p_row["Deleted"]);

            if (p_dt.Columns.Contains("Last_Updated"))
                p_objDes.Last_Updated = CUtility.Convert_To_DateTime(p_row["Last_Updated"]);

            if (p_dt.Columns.Contains("Last_Updated_By"))
                p_objDes.Last_Updated_By = CUtility.Convert_To_String(p_row["Last_Updated_By"]);

        }
        /// <summary>
        ///lấy giá trị lớn nhất của AuTo_ID
        /// </summary>
        /// <param name="p_objData"></param>
        /// <returns></returns>
        public int Get_Max_AutoID_Nhom_Quyen()
        {
            int v_iRes = CConst.INT_VALUE_NULL;

            try
            {
                // Thêm vào database
                v_iRes = CUtility.Convert_To_Int32(CSqlHelper.ExecuteScalar(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, 
                    "20013_sp_sel_Get_Max_AutoID_Nhom_Quyen", null).ToString());
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return v_iRes;
        }
        private void MapPhan_Quyen_Chuc_Nang(DataRow p_row, CPhan_Quyen_Chuc_Nang p_objDes)
        {
            DataTable p_dt = p_row.Table;

            if (p_dt.Columns.Contains("Auto_ID"))
                p_objDes.Auto_ID = CUtility.Convert_To_Int32(p_row["Auto_ID"]);

            if (p_dt.Columns.Contains("Ma_Thanh_Vien"))
                p_objDes.Ma_Thanh_Vien = CUtility.Convert_To_Int32(p_row["Ma_Thanh_Vien"]);

            if (p_dt.Columns.Contains("Ma_Chuc_Nang"))
                p_objDes.Ma_Chuc_Nang = CUtility.Convert_To_Int32(p_row["Ma_Chuc_Nang"]);

            if (p_dt.Columns.Contains("Ma_Nhom_Quyen"))
                p_objDes.Ma_Nhom_Quyen = CUtility.Convert_To_Int32(p_row["Ma_Nhom_Quyen"]);

            if (p_dt.Columns.Contains("Permission_String"))
                p_objDes.Permission_String = CUtility.Convert_To_String(p_row["Permission_String"]);

            if (p_dt.Columns.Contains("Func_URL"))
                p_objDes.Func_URL = CUtility.Convert_To_String(p_row["Func_URL"]);

            if (p_dt.Columns.Contains("Created"))
                p_objDes.Created = CUtility.Convert_To_DateTime(p_row["Created"]);

            if (p_dt.Columns.Contains("Created_By"))
                p_objDes.Created_By = CUtility.Convert_To_String(p_row["Created_By"]);

            if (p_dt.Columns.Contains("Last_Updated"))
                p_objDes.Last_Updated = CUtility.Convert_To_DateTime(p_row["Last_Updated"]);

            if (p_dt.Columns.Contains("Last_Updated_By"))
                p_objDes.Last_Updated_By = CUtility.Convert_To_String(p_row["Last_Updated_By"]);

            if (p_dt.Columns.Contains("Is_View"))
                p_objDes.Is_View = CUtility.Convert_To_Bool(p_row["Is_View"]);

            if (p_dt.Columns.Contains("Is_New"))
                p_objDes.Is_New = CUtility.Convert_To_Bool(p_row["Is_New"]);

            if (p_dt.Columns.Contains("Is_Edit"))
                p_objDes.Is_Edit = CUtility.Convert_To_Bool(p_row["Is_Edit"]);

            if (p_dt.Columns.Contains("Is_Delete"))
                p_objDes.Is_Delete = CUtility.Convert_To_Bool(p_row["Is_Delete"]);

        }

        public IList<CPhan_Quyen_Chuc_Nang> List_Phan_Quyen_Chuc_Nang()
        {
            IList<CPhan_Quyen_Chuc_Nang> v_arrPhan_Quyen_Chuc_Nang = new List<CPhan_Quyen_Chuc_Nang>();
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_List_Phan_Quyen_Chuc_Nang");

                foreach (DataRow v_row in v_dt.Rows)
                {
                    CPhan_Quyen_Chuc_Nang v_objPhan_Quyen_Chuc_Nang = new CPhan_Quyen_Chuc_Nang();
                    MapPhan_Quyen_Chuc_Nang(v_row, v_objPhan_Quyen_Chuc_Nang);
                    v_arrPhan_Quyen_Chuc_Nang.Add(v_objPhan_Quyen_Chuc_Nang);
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

            return v_arrPhan_Quyen_Chuc_Nang;
        }

        public IList<CPhan_Quyen_Chuc_Nang> List_Phan_Quyen_Chuc_Nang_By_AutoID(int p_iAutoID)
        {
            IList<CPhan_Quyen_Chuc_Nang> v_arrPhan_Quyen_Chuc_Nang = new List<CPhan_Quyen_Chuc_Nang>();
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_List_Phan_Quyen_Chuc_Nang_By_AutoID", p_iAutoID);

                foreach (DataRow v_row in v_dt.Rows)
                {
                    CPhan_Quyen_Chuc_Nang v_objPhan_Quyen_Chuc_Nang = new CPhan_Quyen_Chuc_Nang();
                    MapPhan_Quyen_Chuc_Nang(v_row, v_objPhan_Quyen_Chuc_Nang);
                    v_arrPhan_Quyen_Chuc_Nang.Add(v_objPhan_Quyen_Chuc_Nang);
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

            return v_arrPhan_Quyen_Chuc_Nang;
        }

        public CPhan_Quyen_Chuc_Nang Get_Phan_Quyen_Chuc_Nang_By_ID(int p_iID)
        {
            CPhan_Quyen_Chuc_Nang v_objPhan_Quyen_Chuc_Nang = null;
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_Get_Phan_Quyen_Chuc_Nang_By_ID", p_iID);

                if (v_dt.Rows.Count > 0)
                {
                    v_objPhan_Quyen_Chuc_Nang = new CPhan_Quyen_Chuc_Nang();
                    MapPhan_Quyen_Chuc_Nang(v_dt.Rows[0], v_objPhan_Quyen_Chuc_Nang);
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

            return v_objPhan_Quyen_Chuc_Nang;
        }

        public int Insert_Phan_Quyen_Chuc_Nang(CPhan_Quyen_Chuc_Nang p_objData)
        {
            int v_iRes = CConst.INT_VALUE_NULL;

            try
            {
                v_iRes = Convert.ToInt32(CSqlHelper.ExecuteScalar(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_ins_Phan_Quyen_Chuc_Nang",
                            p_objData.Ma_Thanh_Vien, p_objData.Ma_Chuc_Nang, p_objData.Ma_Nhom_Quyen,
                            p_objData.Permission_String, p_objData.Created, p_objData.Created_By,
                            p_objData.Last_Updated_By).ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return v_iRes;
        }

        public void Update_Phan_Quyen_Chuc_Nang(CPhan_Quyen_Chuc_Nang p_objData)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_upd_Phan_Quyen_Chuc_Nang",
                            p_objData.Auto_ID, p_objData.Ma_Thanh_Vien, p_objData.Ma_Chuc_Nang, p_objData.Ma_Nhom_Quyen,
                            p_objData.Permission_String, p_objData.Last_Updated_By);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_Phan_Quyen_Chuc_Nang(int p_iID, string p_strLast_Updated_User)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_del_Phan_Quyen_Chuc_Nang", p_iID, p_strLast_Updated_User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy danh sách các quyền của một nhóm quyền
        /// </summary>
        /// <param name="p_iRoleID"></param>
        /// <returns></returns>
        public IList<CPhan_Quyen_Chuc_Nang> F1004_List_Phan_Quyen_Chuc_Nang_By_Ma_Nhom_Quyen(int p_iMaNhomQuyen)
        {
            DataTable v_dt = new DataTable();
            IList<CPhan_Quyen_Chuc_Nang> v_arrRes = new List<CPhan_Quyen_Chuc_Nang>();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "F1004_sp_sel_List_Phan_Quyen_Chuc_Nang_By_Ma_Nhom_Quyen", p_iMaNhomQuyen);

                foreach (DataRow v_row in v_dt.Rows)
                {
                    CPhan_Quyen_Chuc_Nang v_objFP = new CPhan_Quyen_Chuc_Nang();
                    MapPhan_Quyen_Chuc_Nang(v_row, v_objFP);
                    v_arrRes.Add(v_objFP);
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

            return v_arrRes;
        }

        /// <summary>
        /// Lấy danh sách role
        /// </summary>
        /// <returns></returns>
        public IList<CNhom_Quyen> List_Nhom_Quyen()
        {
            DataTable v_dt = new DataTable();
            IList<CNhom_Quyen> v_arrRes = new List<CNhom_Quyen>();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_List_Nhom_Quyen", null);

                foreach (DataRow v_row in v_dt.Rows)
                {
                    CNhom_Quyen v_objNhom_Quyen = new CNhom_Quyen();
                    MapNhom_Quyen(v_row, v_objNhom_Quyen);
                    v_arrRes.Add(v_objNhom_Quyen);
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

            return v_arrRes;
        }

        public CNhom_Quyen Get_Nhom_Quyen_By_ID(int p_iID)
        {
            CNhom_Quyen v_objNhom_Quyen = null;
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_Get_Nhom_Quyen_By_ID", p_iID);

                if (v_dt.Rows.Count > 0)
                {
                    v_objNhom_Quyen = new CNhom_Quyen();
                    MapNhom_Quyen(v_dt.Rows[0], v_objNhom_Quyen);
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

            return v_objNhom_Quyen;
        }

        public int Insert_Nhom_Quyen(CNhom_Quyen p_objData)
        {
            int v_iRes = CConst.INT_VALUE_NULL;

            try
            {
                v_iRes = Convert.ToInt32(CSqlHelper.ExecuteScalar(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_ins_Nhom_Quyen",
                            p_objData.Ten_Nhom, p_objData.Mo_Ta, p_objData.Icon_Index, p_objData.Parent_Role_ID, p_objData.Sort_Priority, p_objData.Last_Updated_By).ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return v_iRes;
        }

        public void Update_Nhom_Quyen(CNhom_Quyen p_objData)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_upd_Nhom_Quyen",
                            p_objData.Auto_ID, p_objData.Ten_Nhom, p_objData.Mo_Ta, p_objData.Icon_Index, p_objData.Parent_Role_ID, p_objData.Sort_Priority, p_objData.Last_Updated_By);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_Nhom_Quyen(int p_iID, string p_strLast_Updated_User)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_del_Nhom_Quyen", p_iID, p_strLast_Updated_User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Phân quyền chức năng
        /// </summary>
        /// <param name="p_arrFP"></param>
        public void Phan_Quyen_Chuc_Nang(IList<CPhan_Quyen_Chuc_Nang> p_arrFP, int p_iFunc_Group, int p_iMa_Nhom_Quyen)
        {
            SqlConnection v_conn = null;
            SqlTransaction v_trans = null;
            try
            {
                // Tạo connection
                v_conn = CSqlHelper.CreateConnection(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String);
                v_conn.Open();
                v_trans = v_conn.BeginTransaction();

                // Xoá tất cả các quyền hiện có của nhóm quyền
                Del_Phan_Quyen_Chuc_Nang_By_RoleID_By_Func_Group_ID(v_conn, v_trans, p_iMa_Nhom_Quyen, p_iFunc_Group);

                // Add các quyền lại vào database
                foreach (CPhan_Quyen_Chuc_Nang v_objFP in p_arrFP)
                    Add_Phan_Quyen_Chuc_Nang(v_conn, v_trans, v_objFP);

                v_trans.Commit();
            }

            catch (Exception ex)
            {
                if (v_trans != null)
                    v_trans.Rollback();
                throw ex;
            }

            finally
            {
                if (v_conn != null)
                    v_conn.Close();
            }
        }
        /// <summary>
        /// Xoá quyền của một nhóm quyền
        /// </summary>
        /// <param name="p_intRoleID"></param>
        public void Del_Phan_Quyen_Chuc_Nang_By_RoleID_By_Func_Group_ID(SqlConnection p_conn, SqlTransaction p_tran, int p_intMa_NHom_Quyen, int p_iFunc_Group_ID)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(p_conn, p_tran, CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_del_Phan_Quyen_Chuc_Nang_By_RoleID_By_Func_Group_ID", p_intMa_NHom_Quyen,
                    p_iFunc_Group_ID);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Add một quyền vào database
        /// </summary>
        /// <param name="p_conn"></param>
        /// <param name="p_tran"></param>
        /// <param name="p_objFuncPermission"></param>
        public void Add_Phan_Quyen_Chuc_Nang(SqlConnection p_conn, SqlTransaction p_tran, CPhan_Quyen_Chuc_Nang p_objPhan_Quyen_Chuc_Nang)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(p_conn, p_tran, CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_ins_Phan_Quyen_Chuc_Nang",
                    p_objPhan_Quyen_Chuc_Nang.Ma_Thanh_Vien,
                    p_objPhan_Quyen_Chuc_Nang.Ma_Chuc_Nang,
                    p_objPhan_Quyen_Chuc_Nang.Ma_Nhom_Quyen,
                    p_objPhan_Quyen_Chuc_Nang.Permission_String,
                    p_objPhan_Quyen_Chuc_Nang.Last_Updated_By);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
