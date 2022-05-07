using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TKS_Thuc_Tap_Utility;

namespace TKS_Thuc_Tap_Entity.Admin
{
    public class CChuc_Nang
    {
        private int m_intAuto_ID;
        private string m_strFunc_Code;
        private int m_intSort_Priority;
        private int m_intParent_Func_ID;
        private int m_intFunc_Group_ID;
        private bool m_blnIs_View;
        private bool m_blnIs_New;
        private bool m_blnIs_Edit;
        private bool m_blnIs_Delete;
        //private DateTime m_dtmCreated;
        //private string m_strCreated_By;
        //private int m_intDeleted;
        private DateTime m_dtmLast_Updated;
        private string m_strLast_Updated_By;


        private string m_strLang_ID;  // 
        private string m_strTen_Chuc_Nang;  // 
        private string m_strImage_URL;  // 
        private string m_strFunc_URL;  // 
        private string m_strMo_Ta_Chuc_Nang;  // 
        public CChuc_Nang()
        {
            ResetData();
        }

        public void ResetData()
        {
            m_intAuto_ID = CConst.INT_VALUE_NULL;
            m_strFunc_Code = CConst.STR_VALUE_NULL;
            m_intSort_Priority = CConst.INT_VALUE_NULL;
            m_intParent_Func_ID = CConst.INT_VALUE_NULL;
            m_intFunc_Group_ID = CConst.INT_VALUE_NULL;
            m_blnIs_View = CConst.BL_VALUE_NULL;
            m_blnIs_New = CConst.BL_VALUE_NULL;
            m_blnIs_Edit = CConst.BL_VALUE_NULL;
            m_blnIs_Delete = CConst.BL_VALUE_NULL;
            //m_dtmCreated = CConst.DTM_VALUE_NULL;
            //m_strCreated_By = CConst.STR_VALUE_NULL;
            //m_intDeleted = CConst.INT_VALUE_NULL;
            m_dtmLast_Updated = CConst.DTM_VALUE_NULL;
            m_strLast_Updated_By = CConst.STR_VALUE_NULL;


            m_strLang_ID = CConst.STR_VALUE_NULL;
            m_strTen_Chuc_Nang = CConst.STR_VALUE_NULL;
            m_strImage_URL = CConst.STR_VALUE_NULL;
            m_strFunc_URL = CConst.STR_VALUE_NULL;
            m_strMo_Ta_Chuc_Nang = CConst.STR_VALUE_NULL;
        }


        public int Auto_ID
        {
            get
            {
                return m_intAuto_ID;
            }
            set
            {
                m_intAuto_ID = value;
            }
        }


        public string Func_Code
        {
            get
            {
                return m_strFunc_Code;
            }
            set
            {
                m_strFunc_Code = value.Trim();
            }
        }


        public int Sort_Priority
        {
            get
            {
                return m_intSort_Priority;
            }
            set
            {
                m_intSort_Priority = value;
            }
        }


        public int Parent_Func_ID
        {
            get
            {
                return m_intParent_Func_ID;
            }
            set
            {
                m_intParent_Func_ID = value;
            }
        }


        public int Func_Group_ID
        {
            get
            {
                return m_intFunc_Group_ID;
            }
            set
            {
                m_intFunc_Group_ID = value;
            }
        }


        public bool Is_View
        {
            get
            {
                return m_blnIs_View;
            }
            set
            {
                m_blnIs_View = value;
            }
        }


        public bool Is_New
        {
            get
            {
                return m_blnIs_New;
            }
            set
            {
                m_blnIs_New = value;
            }
        }


        public bool Is_Edit
        {
            get
            {
                return m_blnIs_Edit;
            }
            set
            {
                m_blnIs_Edit = value;
            }
        }


        public bool Is_Delete
        {
            get
            {
                return m_blnIs_Delete;
            }
            set
            {
                m_blnIs_Delete = value;
            }
        }


        //public DateTime Created
        //{
        //    get
        //    {
        //        return m_dtmCreated;
        //    }
        //    set
        //    {
        //        m_dtmCreated = value;
        //    }
        //}


        //public string Created_By
        //{
        //    get
        //    {
        //        return m_strCreated_By;
        //    }
        //    set
        //    {
        //        m_strCreated_By = value.Trim();
        //    }
        //}


        //public int Deleted
        //{
        //    get
        //    {
        //        return m_intDeleted;
        //    }
        //    set
        //    {
        //        m_intDeleted = value;
        //    }
        //}


        public DateTime Last_Updated
        {
            get
            {
                return m_dtmLast_Updated;
            }
            set
            {
                m_dtmLast_Updated = value;
            }
        }


        public string Last_Updated_By
        {
            get
            {
                return m_strLast_Updated_By;
            }
            set
            {
                m_strLast_Updated_By = value.Trim();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Lang_ID
        {
            get { return m_strLang_ID; }
            set
            {
                m_strLang_ID = value.Trim();
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
        public string Image_URL
        {
            get { return m_strImage_URL; }
            set
            {
                m_strImage_URL = value.Trim();
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
        public string Mo_Ta_Chuc_Nang
        {
            get { return m_strMo_Ta_Chuc_Nang; }
            set
            {
                m_strMo_Ta_Chuc_Nang = value.Trim();
            }
        }
    }
}
