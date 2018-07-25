using System;
using System.Data;
using System.Data.OleDb;
namespace WebSiteCommon
{
    #region ExcelVersions
    public enum ExcelVersions
    {
        #region MyRegion
        /* Provider=Microsoft.ACE.OLEDB.12.0;Data Source=;Extended properties=Excel 12.0;Imex=1;HDR=Yes;
        Provider=Microsoft.ACE.OLEDB.12.0;Data Source=;Extended Properties=Excel 12.0 Xml;HDR=YES;IMEX=1;

        /// <summary>
        /// Excel3.0版文档格式
        /// </summary>
        Excel3 = "Excel3.0",
        /// <summary>
        /// Excel4.0版文档格式
        /// </summary>
        Excel4 = "Excel4.0",
        /// <summary>
        /// Excel5.0版文档格式，适用于 Microsoft Excel 5.0 和 7.0 (95) 工作簿
        /// </summary>
        Excel5 = "Excel5.0", */
        #endregion

        /// <summary>
        /// Excel8.0版文档格式，适用于Microsoft Excel 8.0 (98-2003) 工作簿
        /// </summary>
        Excel8 = 2003,
        /// <summary>
        /// Excel12.0版文档格式，适用于Microsoft Excel 12.0 (2007) 工作簿
        /// </summary>
        Excel12 = 2007
    }
    #endregion

    public class Common
    {
        #region 功能：读取excel文件获得DataTable=========================

        /// <summary>
        /// 读取excel文件获得DataTable
        /// </summary>
        /// <param name="strExcelFileName">目标Excel文件完全路径</param>
        /// <param name="strSheetName">工作表的名字</param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string strExcelFileName, string strSheetName, ExcelVersions exVersions)
        {
            string ConnectString = string.Empty;

            switch (exVersions)
            {
                case ExcelVersions.Excel8:
                    ConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + strExcelFileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;IMEX=1';";
                    break;
                case ExcelVersions.Excel12:
                    ConnectString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + strExcelFileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1';";
                    break;
                default:
                    break;
            }
            string strExcel = "select * from  [" + strSheetName + "$]";
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            using (OleDbConnection conn = new OleDbConnection(ConnectString))
            {
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, ConnectString);
                //adapter.Fill(ds, strSheetName);
                //return ds.Tables[strSheetName];
                adapter.Fill(dt);
                dt.TableName = strSheetName;
                return dt;
            }
            #region MyRegion

            //很简单的代码，但是问题就出在连接字符串上面，后面一定要加上Extended Properties='Excel 8.0;HDR=NO;IMEX=1'，HDR和IMEX也一定要配合使用，
            //哈哈,老实说,我也不知道为什么,这样配合的效果最好,这是我艰苦调试的结果.IMEX=1应该是将所有的列全部视为文本,我也有点忘记了.
            //至于HDR本来只是说是否要出现一行标题头而已,但是结果却会导致某些字段值丢失,所以其实我至今也搞不明白为什么,很可能是驱动的问题...
            //IMEX=1 解决数字与字符混合时,识别不正常的情况.

            #endregion
        }

        /// <summary>
        /// 读取excel文件获得DataReader
        /// </summary>
        /// <param name="strExcelFileName">Excel文件</param>
        /// <param name="strSheetName">工作薄的名字</param>
        /// <param name="exVersions">版本</param>
        /// <returns></returns>
        public static OleDbDataReader ExcelToDataReader(string strExcelFileName, string strSheetName, ExcelVersions exVersions)
        {
            string ConnectString = string.Empty;

            switch (exVersions)
            {
                case ExcelVersions.Excel8:
                    ConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + strExcelFileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;IMEX=1';";
                    break;
                case ExcelVersions.Excel12:
                    ConnectString = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + strExcelFileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1';";
                    break;
                default:
                    break;
            }
            string strExcel = "select * from  [" + strSheetName + "$]";

            OleDbConnection conn = new OleDbConnection(ConnectString);
            OleDbCommand cmd = new OleDbCommand(strExcel, conn);
            try
            {
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch (System.Data.OleDb.OleDbException e)
            {
                throw new Exception(e.Message);
            }
        }

        #region MyRegion
        ///// <summary>
        ///// 从DataTable中导出数据到Excel
        ///// </summary>
        ///// <param name="dt">一个DataTable</param>
        //public static bool Impordata(DataTable dt, ExcelVersions exVersions)
        //{
        //    bool bl = true;

        //    if (dt != null)
        //    {
        //        string excelPath = string.Empty;

        //        switch (exVersions)
        //        {
        //            case ExcelVersions.Excel8:
        //                excelPath = WinFormTools.GetFileSavePath("Excel2003文件(*.xls)|*.xls", new SaveFileDialog());

        //                if (!string.IsNullOrEmpty(excelPath))
        //                {
        //                    xiaoy.Excel.ExcelFile.SetData(dt, excelPath, xiaoy.Excel.ExcelVersion.Excel8, xiaoy.Excel.HDRType.Yes);
        //                    MessageBox.Show("导出成功!");
        //                    bl = true;
        //                }
        //                else
        //                {
        //                    MessageBox.Show("导出失败!");
        //                    bl = false;
        //                }

        //                break;
        //            case ExcelVersions.Excel12:
        //                excelPath = WinFormTools.GetFileSavePath("Excel2007文件(*.xlsx)|*.xlsx", new SaveFileDialog());
        //                if (!string.IsNullOrEmpty(excelPath))
        //                {
        //                    xiaoy.Excel.ExcelFile.SetData(dt, excelPath, xiaoy.Excel.ExcelVersion.Excel12, xiaoy.Excel.HDRType.Yes);
        //                    MessageBox.Show("导出成功!");
        //                    bl = true;
        //                }
        //                else
        //                {
        //                    MessageBox.Show("导出失败!");
        //                    bl = false;
        //                }
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    return bl;
        //} 
        #endregion

        #endregion
    }
}
