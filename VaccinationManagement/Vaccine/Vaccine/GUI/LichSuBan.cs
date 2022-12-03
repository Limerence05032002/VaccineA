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
            XDoc = XmlFile.getXmlDocument(@"C:\Users\Trung\Desktop\BaiTap\VaccinationManagement\Vaccine\Vaccine\HoaDonNhapXuats.xml");
            XmlNodeList nodeListDH = XDoc.SelectNodes("/HoaDonNhapXuats/HoaDonNhapXuat");
            XDoc = XmlFile.getXmlDocument(@"C:\Users\Trung\Desktop\BaiTap\VaccinationManagement\Vaccine\Vaccine\NhanVien.xml");
            XmlNodeList nodeListNV = XDoc.SelectNodes("/ds/NhanVien");
            XDoc = XmlFile.getXmlDocument(@"C:\Users\Trung\Desktop\BaiTap\VaccinationManagement\Vaccine\Vaccine\ChiTietHoaDons.xml");
            XmlNodeList nodeListCTHD = XDoc.SelectNodes("/ChiTietHoaDons/ChiTietHoaDon");
            foreach (XmlNode x in nodeListDH)
            {
                MessageBox.Show("Zo roi");
                
                    tongtien = 0;
                    soluong = 0;
                    foreach (XmlNode c in nodeListCTHD)
                    {
                        if ((c.ChildNodes[0].InnerText).Equals(x.ChildNodes[0].InnerText))
                        {
                            tongtien += int.Parse(c.ChildNodes[3].InnerText);
                            soluong += int.Parse(c.ChildNodes[2].InnerText);
                        }
                    }
                    Console.WriteLine(x.ChildNodes[0].InnerText);

                    dgvLichSu.Rows.Add(x.ChildNodes[0].InnerText, soluong, tongtien);
                
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
