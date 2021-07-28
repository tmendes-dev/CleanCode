using System;
using System.Data;
using System.IO;

namespace CleanCode.LongMethods
{
    public class DataTableToCsv
    {
        public System.IO.MemoryStream Map(DataTable dataTable)
        {
            MemoryStream ReturnStream = new MemoryStream();
            StreamWriter sw = new StreamWriter(ReturnStream);
            WriteColumnsNames(dataTable, sw, dataTable.Columns.Count);
            WriteRows(dataTable, sw);
            sw.Flush();
            sw.Close();

            return ReturnStream;
        }

        private static void WriteRows(DataTable dt, StreamWriter sw)
        {
            foreach (DataRow dr in dt.Rows)
            {
                WriteRow(dt, dr, sw);
                sw.WriteLine();
            }
        }

        private static void WriteRow(DataTable dt, DataRow dr, StreamWriter sw)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                WriteCell(dr, i, sw);
                WriteSeparatorIfRequired(dt, i, sw);
            }
        }

        private static void WriteSeparatorIfRequired(DataTable dt, int i, StreamWriter sw)
        {
            if (i < dt.Columns.Count - 1)
            {
                sw.Write(",");
            }
        }

        private static void WriteCell(DataRow dr, int i, StreamWriter sw)
        {
            if (!Convert.IsDBNull(dr[i]))
            {
                string str = String.Format("\"{0:c}\"", dr[i].ToString()).Replace("\r\n", " ");
                sw.Write(str);
            }
            else
            {
                sw.Write("");
            }
        }

        private static void WriteColumnsNames(DataTable dt, StreamWriter sw, int iColCount)
        {
            for (int i = 0; i < iColCount; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < iColCount - 1)
                {
                    sw.Write(",");
                }
            }
            sw.WriteLine();
        }
    }
}