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
                WriteRow(dt, sw, dr);
                sw.WriteLine();
            }
        }

        private static void WriteRow(DataTable dt, StreamWriter sw, DataRow dr)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                WriteCell(sw, dr, i);
                WriteSeparatorIfRequired(dt, sw, i);
            }
        }

        private static void WriteSeparatorIfRequired(DataTable dt, StreamWriter sw, int i)
        {
            if (i < dt.Columns.Count - 1)
            {
                sw.Write(",");
            }
        }

        private static void WriteCell(StreamWriter sw, DataRow dr, int i)
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