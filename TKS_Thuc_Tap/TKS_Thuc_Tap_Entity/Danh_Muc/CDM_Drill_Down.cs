using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKS_Thuc_Tap_Utility;

namespace TKS_Thuc_Tap_Entity.Danh_Muc
{
    public class CDM_Drill_Down
    {
        private int m_intAuto_ID;
        private string m_strField_Name;
        private string m_strLink_URL;
        private string m_strParameter_Field;
        private string m_strFunc_ID;
        private int m_intdeleted;
        private DateTime m_dtmCreated;
        private string m_strCreated_By;
        private DateTime m_dtmLast_Updated;
        private string m_strLast_Updated_By;

        public CDM_Drill_Down()
        {
            ResetData();
        }

        public void ResetData()
        {
            m_intAuto_ID = CConst.INT_VALUE_NULL;
            m_strField_Name = CConst.STR_VALUE_NULL;
            m_strLink_URL = CConst.STR_VALUE_NULL;
            m_strParameter_Field = CConst.STR_VALUE_NULL;
            m_strFunc_ID = CConst.STR_VALUE_NULL;
            m_intdeleted = CConst.INT_VALUE_NULL;
            m_dtmCreated = CConst.DTM_VALUE_NULL;
            m_strCreated_By = CConst.STR_VALUE_NULL;
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

        public string Field_Name
        {
            get
            {
                return m_strField_Name;
            }
            set
            {
                m_strField_Name = value.Trim();
            }
        }

        public string Link_URL
        {
            get
            {
                return m_strLink_URL;
            }
            set
            {
                m_strLink_URL = value.Trim();
            }
        }

        public string Parameter_Field
        {
            get
            {
                return m_strParameter_Field;
            }
            set
            {
                m_strParameter_Field = value.Trim();
            }
        }

        public string Func_ID
        {
            get
            {
                return m_strFunc_ID;
            }
            set
            {
                m_strFunc_ID = value.Trim();
            }
        }

        public int deleted
        {
            get
            {
                return m_intdeleted;
            }
            set
            {
                m_intdeleted = value;
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
