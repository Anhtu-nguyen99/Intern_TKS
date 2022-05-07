using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using TKS_Thuc_Tap_Utility;
using TKS_Thuc_Tap_DataLayer;
using TKS_Thuc_Tap_Entity.Danh_Muc;

namespace TKS_Thuc_Tap_Controller.Danh_Muc
{
    public class CDM_Drill_Down_Controller
    {
        private void MapDM_Drill_Down(DataRow p_row, CDM_Drill_Down p_objDes)
        {
            DataTable p_dt = p_row.Table;

            if (p_dt.Columns.Contains("Auto_ID"))
                p_objDes.Auto_ID = CUtility.Convert_To_Int32(p_row["Auto_ID"]);

            if (p_dt.Columns.Contains("Field_Name"))
                p_objDes.Field_Name = CUtility.Convert_To_String(p_row["Field_Name"]);

            if (p_dt.Columns.Contains("Link_URL"))
                p_objDes.Link_URL = CUtility.Convert_To_String(p_row["Link_URL"]);

            if (p_dt.Columns.Contains("Parameter_Field"))
                p_objDes.Parameter_Field = CUtility.Convert_To_String(p_row["Parameter_Field"]);

            if (p_dt.Columns.Contains("Func_ID"))
                p_objDes.Func_ID = CUtility.Convert_To_String(p_row["Func_ID"]);

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

        public IList<CDM_Drill_Down> List_DM_Drill_Down()
        {
            IList<CDM_Drill_Down> v_arrRes = new List<CDM_Drill_Down>();
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, v_dt, "sp_sel_List_DM_Drill_Down");

                foreach (DataRow v_row in v_dt.Rows)
                {
                    CDM_Drill_Down v_objRes = new CDM_Drill_Down();
                    MapDM_Drill_Down(v_row, v_objRes);
                    v_arrRes.Add(v_objRes);
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

        public CDM_Drill_Down Get_DM_Drill_Down_By_ID(int p_iID)
        {
            CDM_Drill_Down v_objRes = null;
            DataTable v_dt = new DataTable();

            try
            {
                CSqlHelper.FillDataTable(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, v_dt, "sp_sel_Get_DM_Drill_Down_By_ID", p_iID);

                if (v_dt.Rows.Count > 0)
                {
                    v_objRes = new CDM_Drill_Down();
                    MapDM_Drill_Down(v_dt.Rows[0], v_objRes);
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

        public int Insert_DM_Drill_Down(CDM_Drill_Down p_objData)
        {
            int v_iRes = CConst.INT_VALUE_NULL;

            try
            {
                v_iRes = Convert.ToInt32(CSqlHelper.ExecuteScalar(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, "sp_ins_DM_Drill_Down",
                    p_objData.Field_Name, p_objData.Link_URL, p_objData.Parameter_Field, p_objData.Func_ID, p_objData.Last_Updated_By));
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return v_iRes;
        }

        public void Update_DM_Drill_Down(CDM_Drill_Down p_objData)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, "sp_upd_DM_Drill_Down", p_objData.Auto_ID,
                    p_objData.Field_Name, p_objData.Link_URL, p_objData.Parameter_Field, p_objData.Func_ID, p_objData.Last_Updated_By);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_DM_Drill_Down(int p_iAuto_ID, string p_strLast_Updated_By)
        {
            try
            {
                CSqlHelper.ExecuteNonquery(CConfig.g_strTKS_Thuc_Tap_Data_Conn_String, "sp_del_DM_Drill_Down", p_iAuto_ID, p_strLast_Updated_By);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
