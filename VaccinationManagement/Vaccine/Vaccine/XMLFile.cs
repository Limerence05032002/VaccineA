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

        public Boolean themHoaDon(XmlDocument XDoc, String maHD)
        {
            try
            {
                XmlElement el = XDoc.CreateElement("HoaDonNhapXuat");
                XmlElement mHD = XDoc.CreateElement("maHD");
                mHD.InnerText = maHD;

                el.AppendChild(mHD);
                XDoc.DocumentElement.AppendChild(el);
                XDoc.Save("HoaDonNhapXuats.xml");
                MessageBox.Show("Đã lưu");
            }
            catch { return false; }
            
            return true;
        }
    }
}
