using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Vaccine.DTO;

namespace Vaccine.BLL
{
    class HoaDonBLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        private string fileName = @"../../HoaDon.xml";

        public HoaDonBLL()
        {
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public void ThemNV(HoaDonDTO themHD)
        {
            XmlNode HoaDon = doc.CreateElement("HoaDon");

            //tạo nút con của sách là masach
            XmlElement TenDM = doc.CreateElement("TenDanhMuc");
            TenDM.InnerText = themHD.TenDM1; //gán giá trị cho mã sách
            HoaDon.AppendChild(TenDM);//thêm masach vào trong sách(sach nhận masach là con)

            XmlElement MaVC = doc.CreateElement("MaVC");
            MaVC.InnerText = themHD.MaVC1;
            HoaDon.AppendChild(MaVC);

            XmlElement TenVC = doc.CreateElement("TenVC");
            TenVC.InnerText = themHD.TenVC1;
            HoaDon.AppendChild(TenVC);

            XmlElement NgaySX = doc.CreateElement("NgaySX");
            NgaySX.InnerText = themHD.NSX1;
            HoaDon.AppendChild(NgaySX);

            XmlElement NgayHH = doc.CreateElement("NgayHH");
            NgayHH.InnerText = themHD.NHH1;
            HoaDon.AppendChild(NgayHH);

            XmlElement SoLuong = doc.CreateElement("SoLuong");
            SoLuong.InnerText = themHD.SoLuong1;
            HoaDon.AppendChild(SoLuong);

            XmlElement Gia = doc.CreateElement("Gia");
            Gia.InnerText = themHD.Gia1;
            HoaDon.AppendChild(Gia);

            XmlElement ThanhTien = doc.CreateElement("ThanhTien");
            ThanhTien.InnerText = themHD.ThanhTien1;
            HoaDon.AppendChild(ThanhTien);
            
            //sau khi tạo xong sách, thì thêm sách vào gốc root
            root.AppendChild(HoaDon);
            doc.Save(fileName);//lưu dữ liệu
        }
        public void HienThi(DataGridView dgvLichSu)
        {
            dgvLichSu.Rows.Clear();
            dgvLichSu.ColumnCount = 8;

            XmlNodeList ds = root.SelectNodes("HoaDon");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgvLichSu.Rows.Add();
                dgvLichSu.Rows[sd].Cells[0].Value = item.SelectSingleNode("TenDanhMuc").InnerText;
                dgvLichSu.Rows[sd].Cells[1].Value = item.SelectSingleNode("MaVC").InnerText;
                dgvLichSu.Rows[sd].Cells[2].Value = item.SelectSingleNode("TenVC").InnerText;
                dgvLichSu.Rows[sd].Cells[3].Value = item.SelectSingleNode("NgaySX").InnerText;
                dgvLichSu.Rows[sd].Cells[4].Value = item.SelectSingleNode("NgayHH").InnerText;
                dgvLichSu.Rows[sd].Cells[5].Value = item.SelectSingleNode("SoLuong").InnerText;
                dgvLichSu.Rows[sd].Cells[6].Value = item.SelectSingleNode("Gia").InnerText;
                dgvLichSu.Rows[sd].Cells[7].Value = item.SelectSingleNode("ThanhTien").InnerText;
                sd++;
            }
        }

    }
}
