using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Linq;

namespace Vaccine
{
    class DanhMuc
    {
        XMLFile XmlFile = new XMLFile();
        public XmlNodeList getListName()
        {

            XmlDocument XDoc = XmlFile.getXmlDocument("../../DanhMucVaccine.xml");

            return XDoc.SelectNodes("/DanhMucSanPhams/DanhMucSanPham");
        }
    }
}
