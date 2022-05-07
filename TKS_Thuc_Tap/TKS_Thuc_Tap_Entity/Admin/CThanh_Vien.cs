using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TKS_Thuc_Tap_Utility;

namespace TKS_Thuc_Tap_Entity.Admin
{
    public class CThanh_Vien
    {
        private int m_intAuto_ID;
        private string m_strMa_Dang_Nhap;
        private string m_strTen;
        private string m_strHo_Lot;
        private string m_strDien_Thoai;
        private string m_strEmail;
        private int m_intIcon_Index;
        private int m_intIs_Updated_Password;
        private DateTime m_dtmCreated;
        private string m_strCreated_By;
        private string m_strPassword;
        private string m_strPassword_Giai_Tru;
        private int m_intDeleted;
        private DateTime m_dtmLast_Updated;
        private string m_strLast_Updated_By;
        private string m_strDefault_URL;  // 

        public CThanh_Vien()
        {
            ResetData();
        }

        public void ResetData()
        {
            m_intAuto_ID = CConst.INT_VALUE_NULL;
            m_strMa_Dang_Nhap = CConst.STR_VALUE_NULL;
            m_strTen = CConst.STR_VALUE_NULL;
            m_strHo_Lot = CConst.STR_VALUE_NULL;
            m_strDien_Thoai = CConst.STR_VALUE_NULL;
            m_strEmail = CConst.STR_VALUE_NULL;
            m_intIcon_Index = CConst.INT_VALUE_NULL;
            m_intIs_Updated_Password = CConst.INT_VALUE_NULL;
            m_dtmCreated = CConst.DTM_VALUE_NULL;
            m_strCreated_By = CConst.STR_VALUE_NULL;
            m_strPassword = CConst.STR_VALUE_NULL;
            m_strPassword_Giai_Tru = CConst.STR_VALUE_NULL;
            m_intDeleted = CConst.INT_VALUE_NULL;
            m_dtmLast_Updated = CConst.DTM_VALUE_NULL;
            m_strLast_Updated_By = CConst.STR_VALUE_NULL;
            m_strDefault_URL = CConst.STR_VALUE_NULL;
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


        public string Ten
        {
            get
            {
                return m_strTen;
            }
            set
            {
                m_strTen = value.Trim();
            }
        }


        public string Ho_Lot
        {
            get
            {
                return m_strHo_Lot;
            }
            set
            {
                m_strHo_Lot = value.Trim();
            }
        }


        public string Dien_Thoai
        {
            get
            {
                return m_strDien_Thoai;
            }
            set
            {
                m_strDien_Thoai = value.Trim();
            }
        }


        public string Email
        {
            get
            {
                return m_strEmail;
            }
            set
            {
                m_strEmail = value.Trim();
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


        public int Is_Updated_Password
        {
            get
            {
                return m_intIs_Updated_Password;
            }
            set
            {
                m_intIs_Updated_Password = value;
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


        public string Password
        {
            get
            {
                return m_strPassword;
            }
            set
            {
                m_strPassword = value.Trim();
            }
        }

        public string Password_Giai_Tru
        {
            get
            {
                return m_strPassword_Giai_Tru;
            }
            set
            {
                m_strPassword_Giai_Tru = value.Trim();
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

        /// <summary>
        /// 
        /// </summary>
        public string Default_URL
        {
            get { return m_strDefault_URL; }
            set
            {
                m_strDefault_URL = value.Trim();
            }
        }

    }
}
