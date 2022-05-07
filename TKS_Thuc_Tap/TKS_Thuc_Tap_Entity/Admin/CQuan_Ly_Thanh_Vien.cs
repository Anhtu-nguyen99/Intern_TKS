using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TKS_Thuc_Tap_Utility;

namespace TKS_Thuc_Tap_Entity.Admin
{
    public class CQuan_Ly_Thanh_Vien
    {
        private int m_intAuto_ID;
        private int m_intMa_Nhom_Quyen;
        private int m_intMa_Thanh_Vien;
        private int m_intRole_Level;
        private DateTime m_dtmCreated;
        private string m_strCreated_By;
        private int m_intDeleted;
        private DateTime m_dtmLast_Updated;
        private string m_strLast_Updated_By;
        private string m_strHo_Lot;  // 
        private string m_strTen;  // 
        private string m_strMa_Dang_Nhap;  // 

        public CQuan_Ly_Thanh_Vien()
        {
            ResetData();
        }

        public void ResetData()
        {
            m_intAuto_ID = CConst.INT_VALUE_NULL;
            m_intMa_Nhom_Quyen = CConst.INT_VALUE_NULL;
            m_intMa_Thanh_Vien = CConst.INT_VALUE_NULL;
            m_intRole_Level = CConst.INT_VALUE_NULL;
            m_dtmCreated = CConst.DTM_VALUE_NULL;
            m_strCreated_By = CConst.STR_VALUE_NULL;
            m_intDeleted = CConst.INT_VALUE_NULL;
            m_dtmLast_Updated = CConst.DTM_VALUE_NULL;
            m_strLast_Updated_By = CConst.STR_VALUE_NULL;
            m_strHo_Lot = CConst.STR_VALUE_NULL;
            m_strTen = CConst.STR_VALUE_NULL;
            m_strMa_Dang_Nhap = CConst.STR_VALUE_NULL;
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


        public int Ma_Nhom_Quyen
        {
            get
            {
                return m_intMa_Nhom_Quyen;
            }
            set
            {
                m_intMa_Nhom_Quyen = value;
            }
        }


        public int Ma_Thanh_Vien
        {
            get
            {
                return m_intMa_Thanh_Vien;
            }
            set
            {
                m_intMa_Thanh_Vien = value;
            }
        }


        public int Role_Level
        {
            get
            {
                return m_intRole_Level;
            }
            set
            {
                m_intRole_Level = value;
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

        /// <summary>
        /// 
        /// </summary>
        public string Ho_Lot
        {
            get { return m_strHo_Lot; }
            set
            {
                m_strHo_Lot = value.Trim();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Ten
        {
            get { return m_strTen; }
            set
            {
                m_strTen = value.Trim();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Ma_Dang_Nhap
        {
            get { return m_strMa_Dang_Nhap; }
            set
            {
                m_strMa_Dang_Nhap = value.Trim();
            }
        }
    }
}
