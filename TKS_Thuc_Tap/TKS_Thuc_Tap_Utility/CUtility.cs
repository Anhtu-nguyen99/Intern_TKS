using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Net.Mail;

namespace TKS_Thuc_Tap_Utility
{
    public class CUtility
    {
        public static DateTime ConvertFromStringToDateTime(string p_strDateTime)
        {
            IFormatProvider culture = new CultureInfo("fr-FR", true);
            return DateTime.Parse(p_strDateTime, culture);
        }

        public static DateTime GetDefaultDate()
        {
            return ConvertFromStringToDateTime("01/01/1900 00:00:00");
        }

        /// <summary>
        /// Cons
        /// </summary>
        public static int Convert_To_Int32(object p_objData)
        {
            if ((p_objData != System.DBNull.Value) && (CUtility.Convert_To_String(p_objData) != ""))
                return Convert.ToInt32(p_objData);
            else
                return CConst.INT_VALUE_NULL;
        }

        /// <summary>
        /// Cons
        /// </summary>
        public static double Convert_To_Double(object p_objData)
        {
            if ((p_objData != System.DBNull.Value) && (CUtility.Convert_To_String(p_objData) != ""))
                return Convert.ToDouble(p_objData);
            else
                return CConst.FLT_VALUE_NULL;
        }

        
        /// <summary>
        /// Cons
        /// </summary>
        public static bool Convert_To_Bool(object p_objData)
        {
            if (p_objData != System.DBNull.Value)
                return Convert.ToBoolean(p_objData);
            else
                return CConst.BL_VALUE_NULL;
        }

        /// <summary>
        /// Cons
        /// </summary>
        public static DateTime Convert_To_DateTime(object p_objData)
        {
            if (p_objData != System.DBNull.Value && p_objData != null)
                return Convert.ToDateTime(p_objData);
            else
                return CConst.DTM_VALUE_NULL;
        }

        /// <summary>
        /// Cons
        /// </summary>
        public static string Convert_To_String(object p_objData)
        {
            return Convert.ToString(p_objData);
        }

        /// <summary>
        /// Mã hoá chuỗi (MD5)
        /// </summary>
        /// <param name="p_strSource">DataSource</param>
        /// /// <param name="p_strIT">Mã số nhận dạng</param>
        /// <returns>string</returns>
        public static string MD5_Encrypt(string p_strSource)
        {
            System.Text.UTF8Encoding utf8encoding = new System.Text.UTF8Encoding();
            byte[] Data = utf8encoding.GetBytes(p_strSource);

            System.Security.Cryptography.MD5CryptoServiceProvider md5Encrypt = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashData = md5Encrypt.ComputeHash(Data);

            string result = "";

            for (int i = 0; i < hashData.Length; i++)
                result += Convert.ToString(hashData[i], 16).PadLeft(2, 'j');

            return result.PadLeft(32, 'n');
        }

        public static DateTime Add_Day_Include_Saturday(DateTime p_dtmNow, int p_iDay)
        {
            int v_iCount = 0;
            int v_iSub = 1;
            if (p_iDay < 0)
                v_iSub = -1;
            DateTime v_dtRes = p_dtmNow;

            while (v_iCount < Math.Abs(p_iDay))
            {
                v_iCount++;
                v_dtRes = v_dtRes.AddDays(v_iSub);

                while (v_dtRes.DayOfWeek == DayOfWeek.Sunday)
                    v_dtRes = v_dtRes.AddDays(v_iSub);
            }

            return v_dtRes;
        }

        public static DateTime Convert_To_Dau_Ngay(DateTime p_dtmDate)
        {
            DateTime v_dtmRes = p_dtmDate;

            v_dtmRes = CUtility.ConvertFromStringToDateTime(p_dtmDate.ToString("dd/MM/yyyy") + " 00:00:00");

            return v_dtmRes;
        }

        public static DateTime Convert_To_Cuoi_Ngay(DateTime p_dtmDate)
        {
            DateTime v_dtmRes = p_dtmDate;

            v_dtmRes = CUtility.ConvertFromStringToDateTime(p_dtmDate.ToString("dd/MM/yyyy") + " 23:59:59");

            return v_dtmRes;
        }


        /// <summary>
        /// Lấy ngày đầu tuần
        /// </summary>
        /// <param name="p_dtmData"></param>
        /// <returns></returns>
        public static DateTime Lay_Ngay_Dau_Tuan(DateTime p_dtmData)
        {
            DateTime v_dtmRes = p_dtmData;

            while (v_dtmRes.DayOfWeek != DayOfWeek.Monday)
                v_dtmRes = v_dtmRes.AddDays(-1);

            return v_dtmRes;
        }

        /// <summary>
        /// Lấy ngày đầu tháng
        /// </summary>
        /// <param name="p_dtmData"></param>
        /// <returns></returns>
        public static DateTime Lay_Ngay_Dau_Thang(DateTime p_dtmData)
        {
            DateTime v_dtmRes = p_dtmData;

            while (v_dtmRes.Day != 1)
                v_dtmRes = v_dtmRes.AddDays(-1);

            return v_dtmRes;
        }

        /// <summary>
        /// Lấy ngày đầu nam
        /// </summary>
        /// <param name="p_dtmData"></param>
        /// <returns></returns>
        public static DateTime Lay_Ngay_Dau_Nam(DateTime p_dtmData)
        {
            DateTime v_dtmRes = p_dtmData;

            while (v_dtmRes.DayOfYear != 1)
                v_dtmRes = v_dtmRes.AddDays(-1);

            return v_dtmRes;
        }

        public static double Min(double p_dbl1, double p_dbl2)
        {
            double v_dblRes = p_dbl1;
            if (v_dblRes > p_dbl2)
                v_dblRes = p_dbl2;
            return v_dblRes;
        }

        public static string Is_Valid_Password_Format(string p_strPass)
        {
            StringBuilder v_sb = new StringBuilder();

            if (p_strPass.Length < 8)
                v_sb.Append("Mật khẩu phải dài ít nhất 8 ký tự.<br/>");

            if (!Is_Contain_Character_Char(p_strPass))
                v_sb.Append("Mật khẩu phải có ít nhất một ký tự chữ.<br/>");

            if (!Is_Contain_Number_Char(p_strPass))
                v_sb.Append("Mật khẩu phải có ít nhất một ký tự số.<br/>");

            if (!Is_Contain_Special_Char(p_strPass))
                v_sb.Append("Mật khẩu phải có ít nhất một ký tự đặc biệt. Ký tự đặt biệt là các ký tự: +-(){}[]!?@#$%^&* <>:;.,=_~`.<br/>");

            return v_sb.ToString();
        }

        public static bool Is_Valid_Phone(string p_strPhone)
        {
            bool v_bRes = true;
            string v_strValid = @"0123456789 .-(){}[]+";
            //Kiểm tra tính hợp lệ,nếu không Contains(chứa) một trong các điều kiện trên là sai
            foreach (char v_c in p_strPhone)
            {
                if (!v_strValid.Contains(v_c.ToString()))
                {
                    v_bRes = false;
                    break;
                }
            }

            return v_bRes;
        }

        public static bool Is_Valid_Dang_Nhap(string p_strDang_Nhap)
        {
            bool v_bRes = true;
            string v_strValid = @"+(){}[]?/\!@#$%^&* <>:;,=~`";
            //Kiểm tra tính hợp lệ,nếu không Contains(chứa) một trong các điều kiện trên là sai
            foreach (char v_c in p_strDang_Nhap)
            {
                if (v_strValid.Contains(v_c.ToString()))
                {
                    v_bRes = false;
                    break;
                }
            }

            return v_bRes;
        }

        /// <summary>
        /// Gởi e-mail
        /// </summary>
        /// <param name="p_strSource">DataSource</param>
        /// <returns>string</returns>
        public static bool SendMailUseSMTP(string p_strFrom, string p_strTo, string p_strSubject,
                                            string p_strMessage, string p_strHost, bool p_bUseDefaultCredentials, int p_iPort,
                                            string p_strUser, string p_strPass, bool p_bEnableSsl)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

            bool result = regex.IsMatch(p_strFrom);
            if (result == false)
            {
                throw new Exception("Email không hợp lệ!!!");
            }
            else
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                SmtpClient smtp = new SmtpClient(p_strHost);

                mail.From = new MailAddress(p_strFrom);
                mail.To.Add(p_strTo);
                mail.Subject = p_strSubject;
                mail.Body = p_strMessage;
                mail.IsBodyHtml = true;

                smtp.UseDefaultCredentials = p_bUseDefaultCredentials;
                smtp.Port = p_iPort;
                smtp.Credentials = new System.Net.NetworkCredential(p_strUser, p_strPass);
                smtp.EnableSsl = p_bEnableSsl;
                smtp.Send(mail);
                return true;
            }
        }

        private static bool Is_Contain_Character_Char(string p_strData)
        {
            bool v_bRes = false;

            //Kiểm tra tính hợp lệ,nếu không Contains(chứa) một trong các điều kiện trên là sai
            foreach (char v_c in p_strData)
            {
                if ((v_c >= 'A' && v_c <= 'Z') || (v_c >= 'a' && v_c <= 'z'))
                {
                    v_bRes = true;
                    break;
                }
            }

            return v_bRes;
        }

        private static bool Is_Contain_Special_Char(string p_strData)
        {
            bool v_bRes = false;
            string v_strValid = @"+-(){}[]?/\!@#$%^&* <>:;.,=_~`";

            //Kiểm tra tính hợp lệ,nếu không Contains(chứa) một trong các điều kiện trên là sai
            foreach (char v_c in p_strData)
            {
                if (v_strValid.Contains(v_c.ToString()))
                {
                    v_bRes = true;
                    break;
                }
            }

            return v_bRes;
        }

        private static bool Is_Contain_Number_Char(string p_strData)
        {
            bool v_bRes = false;

            //Kiểm tra tính hợp lệ,nếu không Contains(chứa) một trong các điều kiện trên là sai
            foreach (char v_c in p_strData)
            {
                if (v_c >= 48 && v_c <= 57)
                {
                    v_bRes = true;
                    break;
                }
            }

            return v_bRes;
        }
    }
}
