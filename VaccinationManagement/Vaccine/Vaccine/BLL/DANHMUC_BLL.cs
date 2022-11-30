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
    class DANHMUC_BLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        private string fileName = @"../../DanhMucVaccine.xml";

        public DANHMUC_BLL()
        {
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public void ThemDM(DanhMucDTO themDM)
        {
            XmlNode DanhMuc = doc.CreateElement("DanhMucSanPham");

            //tạo nút con của sách là masach
            XmlElement MaDM = doc.CreateElement("maDM");
            MaDM.InnerText = themDM.MaDM1; //gán giá trị cho mã sách
            DanhMuc.AppendChild(MaDM);//thêm masach vào trong sách(sach nhận masach là con)

            XmlElement TenDM = doc.CreateElement("tenDM");
            TenDM.InnerText = themDM.TenDM1;
            DanhMuc.AppendChild(TenDM);

            //sau khi tạo xong sách, thì thêm sách vào gốc root
            root.AppendChild(DanhMuc);
            doc.Save(fileName);//lưu dữ liệu
        }
        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 2;

            XmlNodeList ds = root.SelectNodes("DanhMucSanPham");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("maDM").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("tenDM").InnerText;
            
                sd++;
            }
        }
        public void Xoa(DanhMucDTO xoaDanhMuc)
        {
            XmlNode DanhMucCanXoa = root.SelectSingleNode("DanhMucSanPham[maDM ='" + xoaDanhMuc.MaDM1 + "']");
            if (DanhMucCanXoa != null)
            {
                root.RemoveChild(DanhMucCanXoa);

                doc.Save(fileName);
            }
        }
        public void Sua(DanhMucDTO suaDanhMuc)
        {
            //láy vị trí cần sửa theo mã sách cũ đưa vào
            XmlNode DMCu = root.SelectSingleNode("DanhMucSanPham[maDM ='" + suaDanhMuc.MaDM1 + "']");
            if (DMCu != null)
            {
                XmlNode NhanVienSuaMoi = doc.CreateElement("DanhMucSanPham");

                //tạo nút con của sách là masach
                XmlElement MaDanhMuc = doc.CreateElement("maDM");
                MaDanhMuc.InnerText = suaDanhMuc.MaDM1;//gán giá trị cho mã sách
                NhanVienSuaMoi.AppendChild(MaDanhMuc);//thêm masach vào trong sách(sach nhận masach là con)

                XmlElement TenDanhMuc = doc.CreateElement("tenDM");
                TenDanhMuc.InnerText = suaDanhMuc.TenDM1;
                NhanVienSuaMoi.AppendChild(TenDanhMuc);

                //thay thế sách cũ bằng sách mới(sửa )
                root.ReplaceChild(NhanVienSuaMoi, DMCu);
                doc.Save(fileName);//lưu lại

                MessageBox.Show("Cập nhật thành công");
            }
        }
    }

    
}
