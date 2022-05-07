using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myExcel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Reflection;
using System.Web;
using System.IO;
using DevExpress.Web;

namespace TKS_Thuc_Tap_Utility
{
    public class CExcel_Controller
    {
        private myExcel.Application m_objApp = null;
        private myExcel.Workbook m_objWorkbook = null;
        private string m_strFile_Name = "";

        /// <summary>
        /// Khởi tạo với file trống
        /// </summary>
        public CExcel_Controller()
        {
        }

        /// <summary>
        /// Check excel file
        /// </summary>
        /// <param name="p_strFileName">Đuôi file</param>
        /// <returns></returns>
        private bool Check_Excel_File_Type(string p_strFileName)
        {
            if (p_strFileName != ".xls" && p_strFileName != ".xlsx")
                return false;
            return true;
        }

        public string File_Name
        {
            get
            {
                return m_strFile_Name;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_strFile_Name"></param>
        public void Open_File(string p_strFile_Name)
        {
            m_objApp = new Microsoft.Office.Interop.Excel.Application();

            m_objApp.AlertBeforeOverwriting = false;
            m_objApp.DisplayAlerts = false;

            m_objWorkbook = m_objApp.Workbooks.Open(p_strFile_Name, 0, true, 5, "", "", true, myExcel.XlPlatform.xlWindows,
                                                                            "\t", false, false, 0, true, 1, 0);
        }

        /// <summary>
        /// Đọc dữ liệu từ 1 file upload up lên
        /// </summary>
        /// <param name="p_strFile_Name"></param>
        public void Open_File(UploadedFile p_objPost_File, string p_strFolder)
        {
            try
            {
                string v_dtmNgay = DateTime.Now.ToString("ddMMyyyyhhmmss");

                // Lấy đuôi file
                string v_strTextExl = Path.GetExtension(p_objPost_File.FileName).ToLower();
                string v_strName = Path.GetFileName(p_objPost_File.FileName);

                /*Cắt duôi file */
                v_strName = v_strName.Substring(0, v_strName.Length - v_strTextExl.Length);

                FileInfo fileInfo = new FileInfo(p_objPost_File.FileName);

                if (!Check_Excel_File_Type(v_strTextExl))
                    throw new Exception("Không phải định dạng excel nên không đọc được.");

                // Tạo tên file có gắn thêm ngày tháng phía sau
                String v_strFile_Path = HttpContext.Current.Server.MapPath(p_strFolder + v_strName + "_" + v_dtmNgay + v_strTextExl);
                p_objPost_File.SaveAs(v_strFile_Path);

                m_objApp = new Microsoft.Office.Interop.Excel.Application();

                m_objApp.AlertBeforeOverwriting = false;
                m_objApp.DisplayAlerts = false;

                m_objWorkbook = m_objApp.Workbooks.Open(v_strFile_Path, 0, true, 5, "", "", true, myExcel.XlPlatform.xlWindows,
                                                                                "\t", false, false, 0, true, 1, 0);

                m_strFile_Name = v_strName + "_" + v_dtmNgay + v_strTextExl;
            }

            catch (Exception ex)
            {
                Close();
                throw ex;
            }
        }

        /// <summary>
        /// Đóng và giải phóng vùng nhớ file excel. (Luôn phải sử dụng hàm này)
        /// </summary>
        public void Close()
        {
            if (m_objWorkbook != null)
            {
                m_objWorkbook.Close(false, Type.Missing, Type.Missing);
                NAR(m_objWorkbook);
            }

            if (m_objApp != null)
            {
                m_objApp.Quit();
                NAR(m_objApp);
            }

            //GC.Collect();
        }

        public void SaveFile(string p_strFile_Name)
        {
            //save lại file
            m_objWorkbook.SaveAs(p_strFile_Name, Missing.Value, Missing.Value,
                Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

        }

        /// <summary>
        /// Lấy dòng sau cùng của sheet
        /// </summary>
        /// <param name="p_objSheet"></param>
        /// <returns></returns>
        private int Get_Dong_End(myExcel.Worksheet p_objSheet)
        {
            int v_iRes = 1;
            v_iRes = p_objSheet.Cells.SpecialCells(myExcel.XlCellType.xlCellTypeLastCell, Type.Missing).Row;
            return v_iRes;
        }

        /// <summary>
        /// Lấy danh sách sheet name
        /// </summary>
        /// <param name="p_strFile_Name"></param>
        /// <returns></returns>
        public IList<string> List_Sheet_Name()
        {
            IList<string> v_arrRes = new List<string>();

            try
            {
                for (int v_i = 1; v_i <= m_objWorkbook.Sheets.Count; v_i++)
                {
                    myExcel.Worksheet v_objSheet = (myExcel.Worksheet) m_objWorkbook.Sheets[v_i];
                    v_arrRes.Add(v_objSheet.Name);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return v_arrRes;
        }

        /// <summary>
        /// Lấy danh sách dữ liệu từ ô nào đến ô nào trong sheet đầu tiên
        /// Cell_From: Chỉnh chính xác tên ô. VD: B2
        /// Cell_To: Chỉ cần chỉ tên cột. VD: AH còn dòng cuối cùng hệ thống sẽ tự xác định
        /// </summary>
        /// <param name="p_strFile_Name"></param>
        /// <param name="p_strCell_From"></param>
        /// <param name="p_strCell_End"></param>
        /// <returns></returns>
        public DataTable List_Range_Value_To_End(string p_strCell_From, string p_strCell_End)
        {
            return List_Range_Value_To_End(1, p_strCell_From, p_strCell_End);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu từ ô nào đến ô nào trong của 1 sheet chỉ định
        /// Cell_From: Chỉnh chính xác tên ô. VD: B2
        /// Cell_To: Chỉ cần chỉ tên cột. VD: AH còn dòng cuối cùng hệ thống sẽ tự xác định
        /// </summary>
        /// <param name="p_strFile_Name"></param>
        /// <param name="p_strCell_From"></param>
        /// <param name="p_strCell_End"></param>
        /// <returns></returns>
        public DataTable List_Range_Value_To_End(int p_iSheet_Index, string p_strCell_From, string p_strCell_End)
        {
            // Xác định lại cell_end
            myExcel.Worksheet v_objSheet = (myExcel.Worksheet)m_objWorkbook.Sheets[p_iSheet_Index];

            p_strCell_End = p_strCell_End + Get_Dong_End(v_objSheet).ToString();
            return List_Range_Value(p_iSheet_Index, p_strCell_From, p_strCell_End);
        }

        /// <summary>
        /// Lấy danh sách dữ liệu trong vùng cell_from đến cell_end. VD A2 đến D8.
        /// </summary>
        /// <param name="p_iSheet_Index"></param>
        /// <param name="p_strCell_From"></param>
        /// <param name="p_strCell_End"></param>
        /// <returns></returns>
        public DataTable List_Range_Value(int p_iSheet_Index, string p_strCell_From, string p_strCell_End)
        {
            DataTable v_dtRes = new DataTable();

            try
            {
                myExcel.Worksheet v_objSheet = (myExcel.Worksheet)m_objWorkbook.Sheets[p_iSheet_Index];
                if (v_objSheet.AutoFilter != null)
                {
                    v_objSheet.AutoFilterMode = false;
                }

                myExcel.Range range = v_objSheet.get_Range(p_strCell_From, p_strCell_End);

                object[,] values = (object[,])range.Value2;

                DataRow v_row;

                for (int j = 1; j <= values.GetLength(1); j++)
                    v_dtRes.Columns.Add();

                for (int i = 1; i <= values.GetLength(0); i++)
                {
                    v_row = v_dtRes.NewRow();

                    for (int j = 1; j <= values.GetLength(1); j++)
                    {
                        v_row[j - 1] = values[i, j];
                        v_row[j - 1] = v_row[j - 1].ToString().Trim();
                    }

                    v_dtRes.Rows.Add(v_row);
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return v_dtRes;
        }

        private void NAR(object p_obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(p_obj);
            }

            catch { }
            finally
            {
                p_obj = null;
            }
        }

        /// <summary>
        /// Đưa dữ liệu vào 1 cell nào đó của 1 sheet đầu tiên
        /// </summary>
        /// <param name="p_iSheet_Index"></param>
        /// <param name="p_strCell"></param>
        /// <param name="p_objValue"></param>
        public void Set_Value_To_Cell(string p_strCell, object p_objValue)
        {
            Set_Value_To_Cell(1, p_strCell, p_objValue);
        }

        /// <summary>
        /// Đưa dữ liệu vào 1 cell nào đó của 1 sheet nào đó
        /// </summary>
        /// <param name="p_iSheet_Index"></param>
        /// <param name="p_strCell"></param>
        /// <param name="p_objValue"></param>
        public void Set_Value_To_Cell(int p_iSheet_Index, string p_strCell, object p_objValue)
        {
            myExcel.Worksheet v_objSheet = (myExcel.Worksheet) m_objWorkbook.Sheets[p_iSheet_Index];
            myExcel.Range v_Current_Range = v_objSheet.get_Range(p_strCell, p_strCell);
            v_Current_Range.set_Value(Missing.Value, p_objValue);
        }

        /// <summary>
        /// đưa mảng vào row excell
        /// </summary>
        /// <param name="p_intColStart"></param>
        /// <param name="p_intColEnd"></param>
        /// <param name="p_strRow"></param>
        /// <param name="p_objValue"></param>
        public void Set_Value_List_To_Cell(int p_intColStart, int p_intColEnd, string p_strRow, object p_objValue)
        {
            Set_Value_List_To_Cell(1, p_intColStart, p_intColEnd, p_strRow, p_objValue);
        }

        /// <summary>
        /// đưa mảng vào row excell cùa 1 sheet
        /// </summary>
        /// <param name="p_iSheet_Index"></param>
        /// <param name="p_intColStart"></param>
        /// <param name="p_intColEnd"></param>
        /// <param name="p_strRow"></param>
        /// <param name="p_objValue"></param>
        public void Set_Value_List_To_Cell(int p_iSheet_Index,int p_intColStart,int p_intColEnd, string p_strRowIndex, object p_objValue)
        {          
            myExcel.Worksheet v_objSheet = (myExcel.Worksheet)m_objWorkbook.Sheets[p_iSheet_Index];
            myExcel.Range v_Current_Range = v_objSheet.get_Range(Get_Excel_Column(p_intColStart) + p_strRowIndex, Get_Excel_Column(p_intColEnd) + p_strRowIndex);
            v_Current_Range.set_Value(Missing.Value, p_objValue);
        }


        private string Get_Excel_Column(int p_colIndex)
        {
            int dividend = p_colIndex;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        /// <summary>
        /// Đưa dữ liệu vào 1 cell nào đó của 1 sheet đầu tiên
        /// </summary>
        /// <param name="p_iSheet_Index"></param>
        /// <param name="p_strCell"></param>
        /// <param name="p_objValue"></param>
        public object Get_Cell_Value(string p_strCell)
        {
            return Get_Cell_Value(1, p_strCell);
        }

        /// <summary>
        /// Đưa dữ liệu vào 1 cell nào đó của 1 sheet nào đó
        /// </summary>
        /// <param name="p_iSheet_Index"></param>
        /// <param name="p_strCell"></param>
        /// <param name="p_objValue"></param>
        public object Get_Cell_Value(int p_iSheet_Index, string p_strCell)
        {
            myExcel.Worksheet v_objSheet = (myExcel.Worksheet)m_objWorkbook.Sheets[p_iSheet_Index];
            myExcel.Range v_Current_Range = v_objSheet.get_Range(p_strCell, p_strCell);

            return v_Current_Range.Value2;
        }


        public void Delete_Row_Du_Thua(int p_iStart, int p_iEnd, string p_strTen_Col)
        {
            Delete_Row_Du_Thua(1, p_iStart, p_iEnd, p_strTen_Col);
        }


        /// <summary>
        /// delete cac dong trong cua 1 sheet
        /// </summary>
        /// <param name="p_iSheet_Index"></param>
        /// <param name="p_iStart"></param>
        /// <param name="p_iEnd"></param>
        public void Delete_Row_Du_Thua(int p_iSheet_Index, int p_iStart, int p_iEnd, string p_strTen_Col)
        {
            // Xóa các dòng trống
            myExcel.Worksheet v_objSheet = (myExcel.Worksheet)m_objWorkbook.Sheets[p_iSheet_Index];
            Microsoft.Office.Interop.Excel.Range v_objRange = v_objSheet.get_Range(p_strTen_Col + p_iStart.ToString(), p_strTen_Col + p_iEnd.ToString());

            object[,] values = (object[,])v_objRange.Value2;
            int v_iDelete_Position = 0;

            for (int i = 1; i <= values.GetLength(0); i++)
            {
                if (CUtility.Convert_To_String(values[i, 1]).Trim() == "")
                {
                    v_iDelete_Position = i;
                    break;
                }
            }

            if (v_iDelete_Position != 0)
            {
                string v_strCell = p_strTen_Col + (v_iDelete_Position + p_iStart - 1).ToString();
                Microsoft.Office.Interop.Excel.Range rng = v_objSheet.get_Range(v_strCell, p_strTen_Col + p_iEnd.ToString());

                rng.EntireRow.Delete(Microsoft.Office.Interop.Excel.XlDirection.xlUp);
            }
        }


    }
}
