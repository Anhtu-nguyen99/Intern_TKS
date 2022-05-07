using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TKS_Thuc_Tap_Utility;

namespace TKS_Thuc_Tap_Entity.Admin
{
    public class CPhan_Quyen_Chuc_Nang
    {
        private int m_intAuto_ID;  // 
        private int m_intMa_Thanh_Vien;  // 
        private int m_intMa_Chuc_Nang;  // 
        private int m_intMa_Nhom_Quyen;  // 
        private string m_strPermission_String;  // 
        private DateTime m_dtmCreated;  // 
        private string m_strCreated_By;  // 
        private DateTime m_dtmLast_Updated;  // 
        private string m_strLast_Updated_By;  // 


        private string m_strTen_Nhom;  // 
        private string m_strFunc_Code;  // 
        private int m_intSort_Priority;  // 
        private int m_intParent_Func_ID;  // 
        private int m_intFunc_Group_ID;  // 
        private bool m_blnIs_View;  //

        private string m_strFunc_URL;  //
        private string m_strTen_Chuc_Nang;  //

        private bool m_blnIs_New;  //
        private bool m_blnIs_Edit;  //
        private bool m_blnIs_Delete;  //        

        /// <summary>
        /// Reset Data to default value
        /// </summary>
        public void ResetData()
        {
            m_intAuto_ID = CConst.INT_VALUE_NULL;
            m_intMa_Thanh_Vien = CConst.INT_VALUE_NULL;
            m_intMa_Chuc_Nang = CConst.INT_VALUE_NULL;
            m_intMa_Nhom_Quyen = CConst.INT_VALUE_NULL;
            m_strPermission_String = CConst.STR_VALUE_NULL;
            m_dtmCreated = DateTime.Now;
            m_strCreated_By = CConst.STR_VALUE_NULL;
            m_dtmLast_Updated = DateTime.Now;
            m_strLast_Updated_By = CConst.STR_VALUE_NULL;

            m_strTen_Nhom = CConst.STR_VALUE_NULL;
            m_strFunc_Code = CConst.STR_VALUE_NULL;
            m_intSort_Priority = CConst.INT_VALUE_NULL;
            m_intParent_Func_ID = CConst.INT_VALUE_NULL;
            m_intFunc_Group_ID = CConst.INT_VALUE_NULL;


            m_strFunc_URL = CConst.STR_VALUE_NULL;
            m_strTen_Chuc_Nang = CConst.STR_VALUE_NULL;

            m_blnIs_View = CConst.BL_VALUE_NULL;
            m_blnIs_New = CConst.BL_VALUE_NULL;
            m_blnIs_Edit = CConst.BL_VALUE_NULL;
            m_blnIs_Delete = CConst.BL_VALUE_NULL;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Auto_ID
        {
            get { return m_intAuto_ID; }
            set
            {
                m_intAuto_ID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Ma_Thanh_Vien
        {
            get { return m_intMa_Thanh_Vien; }
            set
            {
                m_intMa_Thanh_Vien = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Ma_Chuc_Nang
        {
            get { return m_intMa_Chuc_Nang; }
            set
            {
                m_intMa_Chuc_Nang = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Ma_Nhom_Quyen
        {
            get { return m_intMa_Nhom_Quyen; }
            set
            {
                m_intMa_Nhom_Quyen = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Permission_String
        {
            get { return m_strPermission_String; }
            set
            {
                m_strPermission_String = value.Trim();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Created
        {
            get { return m_dtmCreated; }
            set
            {
                m_dtmCreated = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Created_By
        {
            get { return m_strCreated_By; }
            set
            {
                m_strCreated_By = value.Trim();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Last_Updated
        {
            get { return m_dtmLast_Updated; }
            set
            {
                m_dtmLast_Updated = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Last_Updated_By
        {
            get { return m_strLast_Updated_By; }
            set
            {
                m_strLast_Updated_By = value.Trim();
            }
        }

        public string Ten_Nhom
        {
            get { return m_strTen_Nhom; }
            set
            {
                m_strTen_Nhom = value.Trim();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Func_Code
        {
            get { return m_strFunc_Code; }
            set
            {
                m_strFunc_Code = value.Trim();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Sort_Priority
        {
            get { return m_intSort_Priority; }
            set
            {
                m_intSort_Priority = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Parent_Func_ID
        {
            get { return m_intParent_Func_ID; }
            set
            {
                m_intParent_Func_ID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Func_Group_ID
        {
            get { return m_intFunc_Group_ID; }
            set
            {
                m_intFunc_Group_ID = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Is_View
        {
            get { return m_blnIs_View; }
            set
            {
                m_blnIs_View = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Ten_Chuc_Nang
        {
            get { return m_strTen_Chuc_Nang; }
            set
            {
                m_strTen_Chuc_Nang = value.Trim();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Func_URL
        {
            get { return m_strFunc_URL; }
            set
            {
                m_strFunc_URL = value.Trim();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Is_New
        {
            get { return m_blnIs_New; }
            set
            {
                m_blnIs_New = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Is_Edit
        {
            get { return m_blnIs_Edit; }
            set
            {
                m_blnIs_Edit = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Is_Delete
        {
            get { return m_blnIs_Delete; }
            set
            {
                m_blnIs_Delete = value;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public CPhan_Quyen_Chuc_Nang()
        {
            ResetData();
        }
    }
}
