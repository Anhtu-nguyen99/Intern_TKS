using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TKS_Thuc_Tap_Utility;

namespace TKS_Thuc_Tap_Entity.Admin
{
    public class CNhom_Quyen
    {
        private int m_intAuto_ID;
        private string m_strTen_Nhom;
        private string m_strMo_Ta;
        private int m_intIcon_Index;
        private int m_intParent_Role_ID;
        private DateTime m_dtmCreated;
        private string m_strCreated_By;
        private int m_intSort_Priority;
        private int m_intDeleted;
        private DateTime m_dtmLast_Updated;
        private string m_strLast_Updated_By;
        public CNhom_Quyen()
        {
            ResetData();
        }

        public void ResetData()
        {
            m_intAuto_ID = CConst.INT_VALUE_NULL;
            m_strTen_Nhom = CConst.STR_VALUE_NULL;
            m_strMo_Ta = CConst.STR_VALUE_NULL;
            m_intIcon_Index = CConst.INT_VALUE_NULL;
            m_intParent_Role_ID = CConst.INT_VALUE_NULL;
            m_dtmCreated = CConst.DTM_VALUE_NULL;
            m_strCreated_By = CConst.STR_VALUE_NULL;
            m_intSort_Priority = CConst.INT_VALUE_NULL;
            m_intDeleted = CConst.INT_VALUE_NULL;
            m_dtmLast_Updated = CConst.DTM_VALUE_NULL;
            m_strLast_Updated_By = CConst.STR_VALUE_NULL;
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


        public string Ten_Nhom
        {
            get
            {
                return m_strTen_Nhom;
            }
            set
            {
                m_strTen_Nhom = value.Trim();
            }
        }


        public string Mo_Ta
        {
            get
            {
                return m_strMo_Ta;
            }
            set
            {
                m_strMo_Ta = value.Trim();
            }
        }


        public int Icon_Index
        {
            get
            {
                return m_intIcon_Index;
            }
            set
            {
                m_intIcon_Index = value;
            }
        }


        public int Parent_Role_ID
        {
            get
            {
                return m_intParent_Role_ID;
            }
            set
            {
                m_intParent_Role_ID = value;
            }
        }


        public DateTime Created
        {
            get
            {
                return m_dtmCreated;
            }
            set
            {
                m_dtmCreated = value;
            }
        }


        public string Created_By
        {
            get
            {
                return m_strCreated_By;
            }
            set
            {
                m_strCreated_By = value.Trim();
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


        public int Deleted
        {
            get
            {
                return m_intDeleted;
            }
            set
            {
                m_intDeleted = value;
            }
        }


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
    }
}
