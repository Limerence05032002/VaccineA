using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Vaccine.GUI
{
    public partial class LichSuBan : Form
    {
        XMLFile XmlFile = new XMLFile();
        XmlDocument XDoc;
        string tenKhach = "", tenNV = "";
        int tongtien = 0, soluong = 0;

        public LichSuBan()
        {
            InitializeComponent();
        }

        void loadTable()
        {
            dgvLichSu.Rows.Clear();
            MessageBox.Show("1");
            XDoc = XmlFile.getXmlDocument("../../HoaDonNhapXuats.xml");
            XmlNodeList nodeListDH = XDoc.SelectNodes("/HoaDonNhapXuats/HoaDonNhapXuat");
            XDoc = XmlFile.getXmlDocument("../../NhanVien.xml");
            XmlNodeList nodeListNV = XDoc.SelectNodes("/ds/NhanVien");
            XDoc = XmlFile.getXmlDocument("../../ChiTietHoaDons.xml");
            XmlNodeList nodeListCTHD = XDoc.SelectNodes("/ChiTietHoaDons/ChiTietHoaDon");
            foreach (XmlNode x in nodeListDH)
            {
                MessageBox.Show("Zo roi");
                
                    tongtien = 0;
                    soluong = 0;
                    Console.WriteLine(x.ChildNodes[0].InnerText);

                    dgvLichSu.Rows.Add(x.ChildNodes[0].InnerText,tongtien,soluong);
                
            }
        }

        private void dgvLichSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LichSuBan_Load(object sender, EventArgs e)
        {
            MessageBox.Show("alo");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadTable();
        }
    }
}
