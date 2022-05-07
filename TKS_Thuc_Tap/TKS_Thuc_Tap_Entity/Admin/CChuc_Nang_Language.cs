using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TKS_Thuc_Tap_Utility;

namespace TKS_Thuc_Tap_Entity.Admin
{
    public class CChuc_Nang_Language
    {
        private int m_intAuto_ID;
        private int m_intMa_Chuc_Nang;
        private string m_strLang_ID;
        private string m_strTen_Chuc_Nang;
        private string m_strImage_URL;
        private string m_strFunc_URL;
        private string m_strMo_Ta_Chuc_Nang;
        private DateTime m_dtmCreated;
        private string m_strCreated_By;
        private int m_intDeleted;
        private DateTime m_dtmLast_Updated;
        private string m_strLast_Updated_By;
        public CChuc_Nang_Language()
        {
            ResetData();
        }

        public void ResetData()
        {
            m_intAuto_ID = CConst.INT_VALUE_NULL;
            m_intMa_Chuc_Nang = CConst.INT_VALUE_NULL;
            m_strLang_ID = CConst.STR_VALUE_NULL;
            m_strTen_Chuc_Nang = CConst.STR_VALUE_NULL;
            m_strImage_URL = CConst.STR_VALUE_NULL;
            m_strFunc_URL = CConst.STR_VALUE_NULL;
            m_strMo_Ta_Chuc_Nang = CConst.STR_VALUE_NULL;
            m_dtmCreated = CConst.DTM_VALUE_NULL;
            m_strCreated_By = CConst.STR_VALUE_NULL;
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


        public int Ma_Chuc_Nang
        {
            get
            {
                return m_intMa_Chuc_Nang;
            }
            set
            {
                m_intMa_Chuc_Nang = value;
            }
        }


        public string Lang_ID
        {
            get
            {
                return m_strLang_ID;
            }
            set
            {
                m_strLang_ID = value.Trim();
            }
        }


        public string Ten_Chuc_Nang
        {
            get
            {
                return m_strTen_Chuc_Nang;
            }
            set
            {
                m_strTen_Chuc_Nang = value.Trim();
            }
        }


        public string Image_URL
        {
            get
            {
                return m_strImage_URL;
            }
            set
            {
                m_strImage_URL = value.Trim();
            }
        }


        public string Func_URL
        {
            get
            {
                return m_strFunc_URL;
            }
            set
            {
                m_strFunc_URL = value.Trim();
            }
        }


        public string Mo_Ta_Chuc_Nang
        {
            get
            {
                return m_strMo_Ta_Chuc_Nang;
            }
            set
            {
                m_strMo_Ta_Chuc_Nang = value.Trim();
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
