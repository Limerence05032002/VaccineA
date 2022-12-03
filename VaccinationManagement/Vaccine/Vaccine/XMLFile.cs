using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Vaccine
{
    class XMLFile
    {
        public XmlDocument getXmlDocument(String fileName)
        {
            XmlDocument Xd = new XmlDocument();
            Xd.Load(fileName);
            return Xd;
        }

        public Boolean themHoaDon(XmlDocument XDoc, String maHD,String loai)
        {
            try
            {
                XmlElement el = XDoc.CreateElement("HoaDonNhapXuat");
                XmlElement mHD = XDoc.CreateElement("maHD");

                mHD.InnerText = maHD;
                XmlElement mNV = XDoc.CreateElement("maNV");

                XmlElement l = XDoc.CreateElement("LoaiHD");
                l.InnerText = loai;
                Console.WriteLine(l.InnerText);

                el.AppendChild(mHD);
                el.AppendChild(l);
                XDoc.DocumentElement.AppendChild(el);
                XDoc.Save(@"C:\Users\Trung\Desktop\BaiTap\VaccinationManagement\Vaccine\Vaccine\HoaDonNhapXuats.xml");
                MessageBox.Show("Đã lưu");
            }
            catch { return false; }
            
            return true;
        }
    }
}
