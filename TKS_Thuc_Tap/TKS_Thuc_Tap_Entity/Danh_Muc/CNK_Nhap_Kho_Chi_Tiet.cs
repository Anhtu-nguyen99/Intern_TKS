using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKS_Thuc_Tap_Utility;

namespace TKS_Thuc_Tap_Entity.Danh_Muc
{
	public	class CNK_Nhap_Kho_Chi_Tiet
	{
		private int m_intAuto_ID;
		private string m_strSession_ID;
		private int m_intNhap_Kho_ID;
		private int m_intSan_Pham_ID;
		private string m_strMa_San_Pham;
		private string m_strGhi_Chu;
		private float m_floatSo_Luong;
		private float m_floatDon_Gia;
		private int m_intdeleted;
		private DateTime m_dtmCreated;
		private string m_strCreated_By;
		private DateTime m_dtmLast_Updated;
		private string m_strLast_Updated_By;

		public CNK_Nhap_Kho_Chi_Tiet()
		{
			ResetData();
		}

		public void ResetData()
		{
			m_intAuto_ID = CConst.INT_VALUE_NULL;
			m_strSession_ID = CConst.STR_VALUE_NULL;
			m_intNhap_Kho_ID = CConst.INT_VALUE_NULL;
			m_intSan_Pham_ID = CConst.INT_VALUE_NULL;
			m_strMa_San_Pham = CConst.STR_VALUE_NULL;
			m_strGhi_Chu = CConst.STR_VALUE_NULL;
			m_floatSo_Luong = CConst.FLT_VALUE_NULL;
			m_floatDon_Gia = CConst.FLT_VALUE_NULL;
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

		public string Session_ID
		{
			get
			{
				return m_strSession_ID;
			}
			set
			{
				m_strSession_ID = value;
			}
		}

		public int Nhap_Kho_ID
		{
			get
			{
				return m_intNhap_Kho_ID;
			}
			set
			{
				m_intNhap_Kho_ID = value;
			}
		}

		public int San_Pham_ID
		{
			get
			{
				return m_intSan_Pham_ID;
			}
			set
			{
				m_intSan_Pham_ID = value;
			}
		}

		public string Ma_San_Pham
		{
			get
			{
				return m_strMa_San_Pham;
			}
			set
			{
				m_strMa_San_Pham = value;
			}
		}

		public string Ghi_Chu
		{
			get
			{
				return m_strGhi_Chu;
			}
			set
			{
				m_strGhi_Chu = value;
			}
		}

		public float So_Luong
		{
			get
			{
				return m_floatSo_Luong;
			}
			set
			{
				m_floatSo_Luong = value;
			}
		}

		public float Don_Gia
		{
			get
			{
				return m_floatDon_Gia;
			}
			set
			{
				m_floatDon_Gia = value;
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
