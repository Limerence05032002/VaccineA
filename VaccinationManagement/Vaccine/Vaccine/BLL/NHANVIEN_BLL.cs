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
    class NHANVIEN_BLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        private string fileName = @"../../NhanVien.xml";

        public NHANVIEN_BLL()
        {
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public void ThemNV(NhanVienDTO themNV)
        {
            XmlNode NhanVien = doc.CreateElement("NhanVien");

            //tạo nút con của sách là masach
            XmlElement MaNV = doc.CreateElement("MaNhanVien");
            MaNV.InnerText = themNV.MaNV1; //gán giá trị cho mã sách
            NhanVien.AppendChild(MaNV);//thêm masach vào trong sách(sach nhận masach là con)

            XmlElement TenNV = doc.CreateElement("TenNhanVien");
            TenNV.InnerText = themNV.TenNV1;
            NhanVien.AppendChild(TenNV);

            XmlElement TenDN = doc.CreateElement("TenDangNhap");
            TenDN.InnerText = themNV.TenDN1;
            NhanVien.AppendChild(TenDN);

            XmlElement MK = doc.CreateElement("MatKhau");
            MK.InnerText = themNV.MK1;
            NhanVien.AppendChild(MK);

            XmlElement DiaChi = doc.CreateElement("DiaChi");
            DiaChi.InnerText = themNV.DiaChi1;
            NhanVien.AppendChild(DiaChi);

            XmlElement SDT = doc.CreateElement("SDT");
            SDT.InnerText = themNV.SDT1;
            NhanVien.AppendChild(SDT);
            //sau khi tạo xong sách, thì thêm sách vào gốc root
            root.AppendChild(NhanVien);
            doc.Save(fileName);//lưu dữ liệu
        }
        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 6;

            XmlNodeList ds = root.SelectNodes("NhanVien");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("MaNhanVien").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("TenNhanVien").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("TenDangNhap").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("MatKhau").InnerText;
                dgv.Rows[sd].Cells[4].Value = item.SelectSingleNode("DiaChi").InnerText;
                dgv.Rows[sd].Cells[5].Value = item.SelectSingleNode("SDT").InnerText;
                sd++;
            }
        }
        public void Xoa(NhanVienDTO XoaNhanVien)
        {
            XmlNode NhanVienCanXoa = root.SelectSingleNode("NhanVien[MaNhanVien ='" + XoaNhanVien.MaNV1 + "']");
            if (NhanVienCanXoa != null)
            {
                root.RemoveChild(NhanVienCanXoa);

                doc.Save(fileName);
            }
        }

        public void Sua(NhanVienDTO SuaNhanVien)
        {
            //láy vị trí cần sửa theo mã sách cũ đưa vào
            XmlNode NVCu = root.SelectSingleNode("NhanVien[MaNhanVien ='" + SuaNhanVien.MaNV1 + "']");
            if (NVCu != null)
            {
                XmlNode NhanVienSuaMoi = doc.CreateElement("NhanVien");

                //tạo nút con của sách là masach
                XmlElement MaNhanVien = doc.CreateElement("MaNhanVien");
                MaNhanVien.InnerText = SuaNhanVien.MaNV1;//gán giá trị cho mã sách
                NhanVienSuaMoi.AppendChild(MaNhanVien);//thêm masach vào trong sách(sach nhận masach là con)

                XmlElement TenNhanVien = doc.CreateElement("TenNhanVien");
                TenNhanVien.InnerText = SuaNhanVien.TenNV1;
                NhanVienSuaMoi.AppendChild(TenNhanVien);

                XmlElement TenDangNhap = doc.CreateElement("TenDangNhap");
                TenDangNhap.InnerText = SuaNhanVien.TenDN1;
                NhanVienSuaMoi.AppendChild(TenDangNhap);

                XmlElement MatKhau = doc.CreateElement("MatKhau");
                MatKhau.InnerText = SuaNhanVien.MK1;
                NhanVienSuaMoi.AppendChild(MatKhau);

                XmlElement DiaChi = doc.CreateElement("DiaChi");
                DiaChi.InnerText = SuaNhanVien.DiaChi1;
                NhanVienSuaMoi.AppendChild(DiaChi);

                XmlElement SDT = doc.CreateElement("SDT");
                SDT.InnerText = SuaNhanVien.SDT1;
                NhanVienSuaMoi.AppendChild(SDT);

                //thay thế sách cũ bằng sách mới(sửa )
                root.ReplaceChild(NhanVienSuaMoi, NVCu);
                doc.Save(fileName);//lưu lại

            }
        }

        private void TimKiem(NhanVienDTO nhanVienTim, DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode nhanVienCanTim = root.SelectSingleNode("NhanVien[MaNhanVien ='" + nhanVienTim.MaNV1 + "']");

            if (nhanVienCanTim != null)
            {
                dgv.ColumnCount = 6;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = nhanVienCanTim.SelectSingleNode("MaNhanVien").InnerText;
                dgv.Rows[0].Cells[1].Value = nhanVienCanTim.SelectSingleNode("TenNhanVien").InnerText;
                dgv.Rows[0].Cells[2].Value = nhanVienCanTim.SelectSingleNode("TenDangNhap").InnerText;
                dgv.Rows[0].Cells[3].Value = nhanVienCanTim.SelectSingleNode("MatKhau").InnerText;
                dgv.Rows[0].Cells[4].Value = nhanVienCanTim.SelectSingleNode("DiaChi").InnerText;
                dgv.Rows[0].Cells[5].Value = nhanVienCanTim.SelectSingleNode("SDT").InnerText;
            }
        }
        public NhanVienDTO TimKiem2(NhanVienDTO TimNhanVien, DataGridView dgv)
        {
            NhanVienDTO ketQua = null;
            dgv.Rows.Clear();
            XmlNode nhanVienCanTim = root.SelectSingleNode("NhanVien[MaNhanVien ='" + TimNhanVien.MaNV1 + "']");
            if (nhanVienCanTim != null)
            {
                MessageBox.Show("Zo rooif");
                dgv.ColumnCount = 6;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = nhanVienCanTim.SelectSingleNode("MaNhanVien").InnerText;
                dgv.Rows[0].Cells[1].Value = nhanVienCanTim.SelectSingleNode("TenNhanVien").InnerText;
                dgv.Rows[0].Cells[2].Value = nhanVienCanTim.SelectSingleNode("TenDangNhap").InnerText;
                dgv.Rows[0].Cells[3].Value = nhanVienCanTim.SelectSingleNode("MatKhau").InnerText;
                dgv.Rows[0].Cells[4].Value = nhanVienCanTim.SelectSingleNode("DiaChi").InnerText;
                dgv.Rows[0].Cells[5].Value = nhanVienCanTim.SelectSingleNode("SDT").InnerText;
                

                ketQua = new NhanVienDTO();

                ketQua.MaNV1 = nhanVienCanTim.SelectSingleNode("MaNhanVien").InnerText;
                ketQua.TenNV1 = nhanVienCanTim.SelectSingleNode("TenNhanVien").InnerText;
                ketQua.TenDN1 = nhanVienCanTim.SelectSingleNode("TenDangNhap").InnerText;
                ketQua.MK1 = nhanVienCanTim.SelectSingleNode("MatKhau").InnerText;
                ketQua.DiaChi1 = nhanVienCanTim.SelectSingleNode("DiaChi").InnerText;
                ketQua.SDT1 = nhanVienCanTim.SelectSingleNode("SDT").InnerText;
            }

            return ketQua;
            }
        }
}
