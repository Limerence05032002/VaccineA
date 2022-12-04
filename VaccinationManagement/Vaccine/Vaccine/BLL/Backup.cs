using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Vaccine.BLL
{
    class Backup
    {
        SqlConnection conn = new SqlConnection("Data Source=TRUNGANH\\SQLEXPRESS;Initial Catalog=VaccinationManager_p5;Persist Security Info=True;User ID=sa;Password=123456");
        // Cái này là overload                             
        public void BackUpData()
        {
            //BackUpData("DanhMucSanPham");
            //BackUpData("KhachHang");
            //BackUpData("ChiTietSanPham");
            //BackUpData("ChiTietHoaDon");
            //BackUpData("HoaDonNhapXuat");
            BackUpData(@"C:\Users\Trung\Desktop\BaiTap\VaccinationManagement\Vaccine\Vaccine\NhanVien");
        }
        String toString(XElement elm)
        {
            String result = "";
            foreach (XElement x in elm.Elements())
            {
                if (x == elm.LastNode)
                    result += "N'" + x.Value + "'";
                else
                {
                    result += "N'" + x.Value + "',";
                }
            }
            return "(" + result + "),\n";
        }

        // Cái này là overload    
        private void BackUpData(String XMLFileName)
        {
            XDocument XDoc = XDocument.Load(XMLFileName + ".xml");
            conn.Open();
            SqlCommand command;
            // Tạo chuỗi câu lệnh
            String query = "DELETE FROM " + XMLFileName + " \n insert into " + XMLFileName + " values\n";
            try
            {
                foreach (XElement x in XDoc.Descendants(XMLFileName))
                {
                    toString(x);
                    query += toString(x);
                }

                // Tạo xong là chạy như bình thường như chạy 1 câu trong ssms
                command = new SqlCommand(query.Substring(0, query.Length - 2), conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                // try catch để biết lỗi
                Console.WriteLine(e.Message);
                conn.Close();
            }
            //Console.Read();
        }
    }
}
