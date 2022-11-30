using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vaccine.BLL
{
    class fileXML
    {
        string Conn = "Data Source = NDC\\SQLEXPRESS;Initial Catalog = ElectricityManagement; Integrated Security = True";

        public void TaoXML(string bang)
        {
            SqlConnection con = new SqlConnection(Conn);
            con.Open();
            string sql = "Select* from " + bang;
            SqlDataAdapter ad = new SqlDataAdapter(sql, con);
            DataTable dt = new DataTable("'" + bang + "'");
            ad.Fill(dt);
            dt.WriteXml("../../" + bang + ".xml", XmlWriteMode.WriteSchema);
        }
        public void InsertOrUpDateSQL(string sql)
        {
            SqlConnection con = new SqlConnection(Conn);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable Hienthi1(string file)
        {
            DataTable dt = new DataTable();
            string FilePath = file;
            if (File.Exists(FilePath))
            {
                FileStream fsReadXML = new FileStream(FilePath, FileMode.Open);
                dt.ReadXml(fsReadXML);
                fsReadXML.Close();
            }
            else
            {
                MessageBox.Show("File XML '" + file + "' không tồn tại");
            }

            return dt;
        }

        public DataTable HienThi(string file)
        {
            DataTable dt = new DataTable();
            string FilePath = "../../" + file;
            if (File.Exists(FilePath))
            {
                FileStream fsReadXML = new FileStream(FilePath, FileMode.Open);
                dt.ReadXml(fsReadXML);
                fsReadXML.Close();
            }
            else
            {
                MessageBox.Show("File XML '" + file + "' không tồn tại");
            }

            return dt;
        }
    }
}
