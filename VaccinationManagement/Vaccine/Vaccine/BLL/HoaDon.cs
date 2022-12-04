using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Vaccine.GUI;

namespace Vaccine.BLL
{
    class HoaDon
    {
        XMLFile XmlFile = new XMLFile();
        VaccineBLL cTNS = new VaccineBLL();
        String taoMaHoaDon(XmlDocument XDoc)
        {

            XmlNodeList temp = XDoc.SelectNodes("/HoaDonNhapXuats/HoaDonNhapXuat[last()]");

            String maHD = temp[0].ChildNodes[0].InnerText;
            maHD = ("000000" + (int.Parse(maHD.Substring(2)) + 1).ToString());
            maHD = "HD" + maHD.Substring(maHD.Length - 5);
            return maHD;
        }

        public Boolean add(XmlDocument XDocCTHD, List<XmlNode> nodeList, String l)
        {
            try
            {
                XmlDocument XDocChiTietVaccine = XmlFile.getXmlDocument(@"C:\Users\Trung\Desktop\BaiTap\VaccinationManagement\Vaccine\Vaccine\tb_Vaccine.xml");
                XmlDocument XDoc = XmlFile.getXmlDocument(@"C:\Users\Trung\Desktop\BaiTap\VaccinationManagement\Vaccine\Vaccine\HoaDonNhapXuats.xml");
                String maHD_new = taoMaHoaDon(XDoc);
                String loai = l;
                int CongTru = 1;
                if (l.Equals("N"))
                {
                    CongTru = 1;
                }
                else
                {
                    CongTru = -1;
                }

                XmlFile.themHoaDon(XDoc, maHD_new, loai);
                foreach (XmlNode x in nodeList)
                {
                    XmlNodeList temp = XDocChiTietVaccine.SelectNodes("/Vaccines/vaccine[MaVC = '" + x.ChildNodes[0].InnerText + "']");
                    cTNS.setSoluong(int.Parse(x.ChildNodes[1].InnerText) * CongTru, temp[0]);

                    XmlNode maHoaDon = XDocCTHD.CreateElement("maHD");
                    maHoaDon.InnerText = maHD_new;
                    x.InsertBefore(maHoaDon, x.FirstChild);
                    XDocCTHD.DocumentElement.AppendChild(x);
                }
                
                XDocCTHD.Save(@"C:\Users\Trung\Desktop\BaiTap\VaccinationManagement\Vaccine\Vaccine\ChiTietHoaDons.xml"); //ChiTietHoaDon.xml == LichSuBan.xml
                MessageBox.Show("Đã lưu");
                XDocChiTietVaccine.Save(@"C:\Users\Trung\Desktop\BaiTap\VaccinationManagement\Vaccine\Vaccine\tb_Vaccine.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public void ThemHoaDon(DataGridView dgvVaccineBan, String loai)
        {
            List<XmlNode> nodeList = new List<XmlNode>();
            XmlDocument XDoc = XmlFile.getXmlDocument(@"C:\Users\Trung\Desktop\BaiTap\VaccinationManagement\Vaccine\Vaccine\ChiTietHoaDons.xml");
            for (int i = 0; i < dgvVaccineBan.Rows.Count - 1; i++)
            {

                XmlElement node = XDoc.CreateElement("ChiTietHoaDon");

                XmlElement maSP = XDoc.CreateElement("MaVC");
                Console.WriteLine(maSP.InnerText);
                Console.WriteLine(dgvVaccineBan.Rows[i].Cells[1].Value.ToString() + " MaVC");
                maSP.InnerText = dgvVaccineBan.Rows[i].Cells[1].Value.ToString();

                XmlElement soLuong = XDoc.CreateElement("soLuong");
                soLuong.InnerText = dgvVaccineBan.Rows[i].Cells[5].Value.ToString();
                Console.WriteLine(dgvVaccineBan.Rows[i].Cells[5].Value.ToString() + " SoLuong");

                XmlElement donGia = XDoc.CreateElement("DonGia");
                donGia.InnerText = dgvVaccineBan.Rows[i].Cells[6].Value.ToString();
                Console.WriteLine(dgvVaccineBan.Rows[i].Cells[6].Value.ToString() + " SoLuong");

                node.AppendChild(maSP);
                node.AppendChild(soLuong);
                node.AppendChild(donGia);
                nodeList.Add(node);
            }
            HoaDon hoaDon = new HoaDon();
            hoaDon.add(XDoc, nodeList, loai);
        }
    }
}
