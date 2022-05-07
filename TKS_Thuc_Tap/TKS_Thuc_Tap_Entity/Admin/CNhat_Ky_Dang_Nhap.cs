using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TKS_Thuc_Tap_Utility;

namespace TKS_Thuc_Tap_Entity.Admin
{
    public class CNhat_Ky_Dang_Nhap
    {
        private int m_intAuto_ID;
        private string m_strMa_Dang_Nhap;
        private DateTime m_dtmThoi_Diem_Dang_Nhap;
        private string m_strUserHostAddress;
        private string m_strUserHostName;
        private string m_strUserAgent;
        private int m_intDeleted;
        private DateTime m_dtmCreated;
        private string m_strCreated_By;
        private DateTime m_dtmLast_Updated;
        private string m_strLast_Updated_By;
        public CNhat_Ky_Dang_Nhap()
        {
            ResetData();
        }

        public void ResetData()
        {
            m_intAuto_ID = CConst.INT_VALUE_NULL;
            m_strMa_Dang_Nhap = CConst.STR_VALUE_NULL;
            m_dtmThoi_Diem_Dang_Nhap = CConst.DTM_VALUE_NULL;
            m_strUserHostAddress = CConst.STR_VALUE_NULL;
            m_strUserHostName = CConst.STR_VALUE_NULL;
            m_strUserAgent = CConst.STR_VALUE_NULL;
            m_intDeleted = CConst.INT_VALUE_NULL;
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


        public string Ma_Dang_Nhap
        {
            get
            {
                return m_strMa_Dang_Nhap;
            }
            set
            {
                m_strMa_Dang_Nhap = value.Trim();
            }
        }


        public DateTime Thoi_Diem_Dang_Nhap
        {
            get
            {
                return m_dtmThoi_Diem_Dang_Nhap;
            }
            set
            {
                m_dtmThoi_Diem_Dang_Nhap = value;
            }
        }


        public string UserHostAddress
        {
            get
            {
                return m_strUserHostAddress;
            }
            set
            {
                m_strUserHostAddress = value.Trim();
            }
        }


        public string UserHostName
        {
            get
            {
                return m_strUserHostName;
            }
            set
            {
                m_strUserHostName = value.Trim();
            }
        }


        public string UserAgent
        {
            get
            {
                return m_strUserAgent;
            }
            set
            {
                m_strUserAgent = value.Trim();
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
