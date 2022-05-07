using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TKS_Thuc_Tap_Utility
{
    public class CConfig
    {
        /// <summary>
        /// Câu kết nối vào database
        /// </summary>
        public static string g_strTKS_Thuc_Tap_Data_Conn_String = "";
        public static string g_strTKS_Thuc_Tap_Admin_Conn_String = "";

        // Thông tin header báo cáo
        public static string g_strCompany_Name = "";
        public static string g_strCompany_Address = "";
        public static string g_strCompany_Tel = "";
        public static string g_strCompany_Fax = "";
        public static string g_strLogo_Url = "";
        public static int g_intReport_Line_Space = 20;
      
    }
}
