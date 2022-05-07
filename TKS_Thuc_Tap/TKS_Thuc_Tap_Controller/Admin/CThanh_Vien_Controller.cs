using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TKS_Thuc_Tap_DataLayer;
using TKS_Thuc_Tap_Utility;
using TKS_Thuc_Tap_Entity.Admin;
using System.Data;

namespace TKS_Thuc_Tap_Controller.Admin
{
    public class CThanh_Vien_Controller
    {
        private void MapThanh_Vien(DataRow p_row, CThanh_Vien p_objDes)
        {
            DataTable p_dt = p_row.Table;

            if (p_dt.Columns.Contains("Auto_ID"))
                p_objDes.Auto_ID = CUtility.Convert_To_Int32(p_row["Auto_ID"]);

            if (p_dt.Columns.Contains("Ma_Dang_Nhap"))
                p_objDes.Ma_Dang_Nhap = CUtility.Convert_To_String(p_row["Ma_Dang_Nhap"]);

            if (p_dt.Columns.Contains("Ten"))
                p_objDes.Ten = CUtility.Convert_To_String(p_row["Ten"]);

            if (p_dt.Columns.Contains("Ho_Lot"))
                p_objDes.Ho_Lot = CUtility.Convert_To_String(p_row["Ho_Lot"]);

            if (p_dt.Columns.Contains("Dien_Thoai"))
                p_objDes.Dien_Thoai = CUtility.Convert_To_String(p_row["Dien_Thoai"]);

            if (p_dt.Columns.Contains("Email"))
                p_objDes.Email = CUtility.Convert_To_String(p_row["Email"]);

            if (p_dt.Columns.Contains("Icon_Index"))
                p_objDes.Icon_Index = CUtility.Convert_To_Int32(p_row["Icon_Index"]);

            if (p_dt.Columns.Contains("Is_Updated_Password"))
                p_objDes.Is_Updated_Password = CUtility.Convert_To_Int32(p_row["Is_Updated_Password"]);

            if (p_dt.Columns.Contains("Created"))
                p_objDes.Created = CUtility.Convert_To_DateTime(p_row["Created"]);

            if (p_dt.Columns.Contains("Created_By"))
                p_objDes.Created_By = CUtility.Convert_To_String(p_row["Created_By"]);

            if (p_dt.Columns.Contains("Password"))
                p_objDes.Password = CUtility.Convert_To_String(p_row["Password"]);

            if (p_dt.Columns.Contains("Password_Giai_Tru"))
                p_objDes.Password_Giai_Tru = CUtility.Convert_To_String(p_row["Password_Giai_Tru"]);

            if (p_dt.Columns.Contains("Deleted"))
                p_objDes.Deleted = CUtility.Convert_To_Int32(p_row["Deleted"]);

            if (p_dt.Columns.Contains("Last_Updated"))
                p_objDes.Last_Updated = CUtility.Convert_To_DateTime(p_row["Last_Updated"]);

            if (p_dt.Columns.Contains("Last_Updated_By"))
                p_objDes.Last_Updated_By = CUtility.Convert_To_String(p_row["Last_Updated_By"]);

            if (p_dt.Columns.Contains("Default_URL"))
                p_objDes.Default_URL = CUtility.Convert_To_String(p_row["Default_URL"]);

        }

        private void MapQuan_Ly_Thanh_Vien(DataRow p_row, CQuan_Ly_Thanh_Vien p_objDes)
        {
            DataTable p_dt = p_row.Table;

            if (p_dt.Columns.Contains("Auto_ID"))
                p_objDes.Auto_ID = CUtility.Convert_To_Int32(p_row["Auto_ID"]);

            if (p_dt.Columns.Contains("Ma_Nhom_Quyen"))
                p_objDes.Ma_Nhom_Quyen = CUtility.Convert_To_Int32(p_row["Ma_Nhom_Quyen"]);

            if (p_dt.Columns.Contains("Ma_Thanh_Vien"))
                p_objDes.Ma_Thanh_Vien = CUtility.Convert_To_Int32(p_row["Ma_Thanh_Vien"]);

            if (p_dt.Columns.Contains("Role_Level"))
                p_objDes.Role_Level = CUtility.Convert_To_Int32(p_row["Role_Level"]);

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

            if (p_dt.Columns.Contains("Ho_Lot"))
                p_objDes.Ho_Lot = CUtility.Convert_To_String(p_row["Ho_Lot"]);

            if (p_dt.Columns.Contains("Ten"))
                p_objDes.Ten = CUtility.Convert_To_String(p_row["Ten"]);

            if (p_dt.Columns.Contains("Ma_Dang_Nhap"))
                p_objDes.Ma_Dang_Nhap = CUtility.Convert_To_String(p_row["Ma_Dang_Nhap"]);

        }
        public IList<CQuan_Ly_Thanh_Vien> List_Quan_Ly_Thanh_Vien()
        {
            IList<CQuan_Ly_Thanh_Vien> v_arrQuan_Ly_Thanh_Vien = new List<CQuan_Ly_Thanh_Vien>();
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_List_Quan_Ly_Thanh_Vien");

                foreach (DataRow v_row in v_dt.Rows)
                {
                    CQuan_Ly_Thanh_Vien v_objQuan_Ly_Thanh_Vien = new CQuan_Ly_Thanh_Vien();
                    MapQuan_Ly_Thanh_Vien(v_row, v_objQuan_Ly_Thanh_Vien);
                    v_arrQuan_Ly_Thanh_Vien.Add(v_objQuan_Ly_Thanh_Vien);
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

            return v_arrQuan_Ly_Thanh_Vien;
        }

        public IList<CQuan_Ly_Thanh_Vien> List_Quan_Ly_Thanh_Vien_By_Nhom_Quyen_ID(int p_iNhom_Quyen_ID)
        {
            IList<CQuan_Ly_Thanh_Vien> v_arrQuan_Ly_Thanh_Vien = new List<CQuan_Ly_Thanh_Vien>();
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt,
                    "sp_sel_List_Quan_Ly_Thanh_Vien_By_Ma_Nhom_Quyen_DelManager", p_iNhom_Quyen_ID);

                foreach (DataRow v_row in v_dt.Rows)
                {
                    CQuan_Ly_Thanh_Vien v_objQuan_Ly_Thanh_Vien = new CQuan_Ly_Thanh_Vien();
                    MapQuan_Ly_Thanh_Vien(v_row, v_objQuan_Ly_Thanh_Vien);
                    v_arrQuan_Ly_Thanh_Vien.Add(v_objQuan_Ly_Thanh_Vien);
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

            return v_arrQuan_Ly_Thanh_Vien;
        }

        public CQuan_Ly_Thanh_Vien Get_Quan_Ly_Thanh_Vien_By_ID(int p_iID)
        {
            CQuan_Ly_Thanh_Vien v_objQuan_Ly_Thanh_Vien = null;
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_Get_Quan_Ly_Thanh_Vien_By_ID", p_iID);

                if (v_dt.Rows.Count > 0)
                {
                    v_objQuan_Ly_Thanh_Vien = new CQuan_Ly_Thanh_Vien();
                    MapQuan_Ly_Thanh_Vien(v_dt.Rows[0], v_objQuan_Ly_Thanh_Vien);
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

            return v_objQuan_Ly_Thanh_Vien;
        }

        public int Insert_Quan_Ly_Thanh_Vien(CQuan_Ly_Thanh_Vien p_objData)
        {
            int v_iRes = CConst.INT_VALUE_NULL;

            try
            {
                v_iRes = Convert.ToInt32(CSqlHelper.ExecuteScalar(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_ins_Quan_Ly_Thanh_Vien",
                            p_objData.Ma_Nhom_Quyen, p_objData.Ma_Thanh_Vien, p_objData.Role_Level, p_objData.Last_Updated_By).ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return v_iRes;
        }

        public void Update_Quan_Ly_Thanh_Vien(CQuan_Ly_Thanh_Vien p_objData)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_upd_Quan_Ly_Thanh_Vien",
                            p_objData.Auto_ID, p_objData.Ma_Nhom_Quyen, p_objData.Ma_Thanh_Vien, p_objData.Role_Level, p_objData.Last_Updated_By);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_Quan_Ly_Thanh_Vien(int p_iID, string p_strLast_Updated_User)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_del_Quan_Ly_Thanh_Vien", p_iID, p_strLast_Updated_User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lấy danh sách những group mà user thuộc
        /// </summary>
        /// <param name="p_iUserID"></param>
        /// <returns></returns>
        public IList<CQuan_Ly_Thanh_Vien> F1002_List_Quan_Ly_Thanh_Vien_By_Ma_Thanh_Vien(int p_iMaThanhVien)
        {
            IList<CQuan_Ly_Thanh_Vien> v_arrRes = new List<CQuan_Ly_Thanh_Vien>();
            DataTable v_dt = new DataTable();

            try
            {
                // Bind dữ liệu
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "F1002_sp_sel_List_Quan_Ly_Thanh_Vien_By_Ma_Thanh_Vien", p_iMaThanhVien);

                foreach (DataRow v_row in v_dt.Rows)
                {
                    CQuan_Ly_Thanh_Vien v_objUR = new CQuan_Ly_Thanh_Vien();
                    MapQuan_Ly_Thanh_Vien(v_row, v_objUR);
                    v_arrRes.Add(v_objUR);
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

        public IList<CThanh_Vien> List_Thanh_Vien()
        {
            IList<CThanh_Vien> v_arrThanh_Vien = new List<CThanh_Vien>();
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_List_Thanh_Vien");

                foreach (DataRow v_row in v_dt.Rows)
                {
                    CThanh_Vien v_objThanh_Vien = new CThanh_Vien();
                    MapThanh_Vien(v_row, v_objThanh_Vien);
                    v_arrThanh_Vien.Add(v_objThanh_Vien);
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

            return v_arrThanh_Vien;
        }

        public CThanh_Vien Get_Thanh_Vien_By_ID(int p_iID)
        {
            CThanh_Vien v_objThanh_Vien = null;
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_Get_Thanh_Vien_By_ID", p_iID);

                if (v_dt.Rows.Count > 0)
                {
                    v_objThanh_Vien = new CThanh_Vien();
                    MapThanh_Vien(v_dt.Rows[0], v_objThanh_Vien);
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

            return v_objThanh_Vien;
        }

        public int Insert_Thanh_Vien(CThanh_Vien p_objData)
        {
            int v_iRes = CConst.INT_VALUE_NULL;

            try
            {
                v_iRes = Convert.ToInt32(CSqlHelper.ExecuteScalar(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_ins_Thanh_Vien",
                            p_objData.Ma_Dang_Nhap, p_objData.Ten, p_objData.Ho_Lot, p_objData.Dien_Thoai, p_objData.Email, p_objData.Icon_Index,
                            p_objData.Is_Updated_Password, p_objData.Password, p_objData.Default_URL, p_objData.Last_Updated_By).ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return v_iRes;
        }

        public void Update_Thanh_Vien(CThanh_Vien p_objData)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_upd_Thanh_Vien",
                            p_objData.Auto_ID, p_objData.Ma_Dang_Nhap, p_objData.Ten, p_objData.Ho_Lot, p_objData.Dien_Thoai, p_objData.Email,
                            p_objData.Icon_Index, p_objData.Is_Updated_Password, p_objData.Password, p_objData.Default_URL, p_objData.Last_Updated_By);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_Thanh_Vien(int p_iID, string p_strLast_Updated_User)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "sp_del_Thanh_Vien", p_iID, p_strLast_Updated_User);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Users
        /// </summary>
        /// <param name="p_objData"></param>
        public void F1002_Update_Thanh_Vien(CThanh_Vien p_objData)
        {
            try
            {
                // Update dữ liệu vào database
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, "F1002_sp_upd_Thanh_Vien",
                     p_objData.Auto_ID,
                     p_objData.Ma_Dang_Nhap,
                     p_objData.Ten,
                     p_objData.Ho_Lot,
                     p_objData.Dien_Thoai,
                     p_objData.Email,
                     p_objData.Icon_Index,
                     p_objData.Is_Updated_Password,
                     p_objData.Password,
                     p_objData.Default_URL,
                     p_objData.Last_Updated_By);

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Lấy User theo User_Name
        /// </summary>
        /// <param name="p_strUser_Name"></param>
        /// <returns></returns>
        public CThanh_Vien Get_Thanh_Vien_By_Ma_Dang_Nhap(string p_strMa_Dang_Nhap)
        {
            CThanh_Vien v_objRes = null;
            DataTable v_dt = new DataTable();

            try
            {
                // Fill dữ liệu vào datatable
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Admin_Conn_String, v_dt, "sp_sel_Get_Thanh_Vien_By_Ma_Dang_Nhap",
                    p_strMa_Dang_Nhap);

                //Kiểm tra dữ liệu 
                if (v_dt.Rows.Count > 0)
                {
                    v_objRes = new CThanh_Vien();
                    MapThanh_Vien(v_dt.Rows[0], v_objRes);
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
