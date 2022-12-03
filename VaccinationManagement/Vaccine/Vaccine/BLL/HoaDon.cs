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

        public Boolean add(XmlDocument XDocCTHD, List<XmlNode> nodeList)
        {
            try
            {
                XmlDocument XDocChiTietVaccine = XmlFile.getXmlDocument(@"../../tb_Vaccine.xml");
                XmlDocument XDoc = XmlFile.getXmlDocument(@"../../HoaDonNhapXuats.xml");
                String maHD_new = taoMaHoaDon(XDoc);

                XmlFile.themHoaDon(XDoc, maHD_new);
                
                XDocCTHD.Save("ChiTietHoaDons.xml"); //ChiTietHoaDon.xml == LichSuBan.xml
                XDocChiTietVaccine.Save("tb_Vaccine.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public void ThemHoaDon(DataGridView dgvVaccineBan, String maKHachDD )
        {
            List<XmlNode> nodeList = new List<XmlNode>();
            XmlDocument XDoc = XmlFile.getXmlDocument(@"../../ChiTietHoaDons.xml");
            for (int i = 0; i < dgvVaccineBan.Rows.Count - 1; i++)
            {

                XmlElement node = XDoc.CreateElement("ChiTietHoaDon");

                XmlElement maSP = XDoc.CreateElement("MaVC");

                Console.WriteLine(dgvVaccineBan.Rows[i].Cells[6].Value.ToString() + "MaVC");

                maSP.InnerText = dgvVaccineBan.Rows[i].Cells[6].Value.ToString();

                XmlElement soLuong = XDoc.CreateElement("soLuong");

                soLuong.InnerText = dgvVaccineBan.Rows[i].Cells[3].Value.ToString();
                XmlElement donGia = XDoc.CreateElement("DonGia");
                donGia.InnerText = dgvVaccineBan.Rows[i].Cells[4].Value.ToString(); ;

                node.AppendChild(maSP);
                node.AppendChild(soLuong);
                node.AppendChild(donGia);
                nodeList.Add(node);
            }
            HoaDon hoaDon = new HoaDon();
            hoaDon.add(XDoc, nodeList);
        }
    }
}
