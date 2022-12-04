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
using Vaccine.BLL;
using Vaccine.DTO;

namespace Vaccine.GUI
{
    public partial class BanVaccine : Form
    {
        private HoaDonBLL hoaDonBLL = new HoaDonBLL();
        private HoaDonDTO hoaDonDTO = new HoaDonDTO();

        private XmlDocument doc = new XmlDocument();

        XMLFile XmlFile = new XMLFile();
        XmlDocument XDoc;
        XmlDocument XDocVaccine;
        private XmlElement root;
        int stt = 0;
        public BanVaccine()
        {
            InitializeComponent();
        }

        private void BanVaccine_Load(object sender, EventArgs e)
        {
            loadTable();
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            try
            {
                int soLuongBan = int.Parse(txtSoLuongBan.Text);
                if (soLuongBan > 0 && int.Parse(txtSoLuongBan.Text) <= int.Parse(dgvVaccineBan.CurrentRow.Cells[5].FormattedValue.ToString()))
                {
                    dgvGioHang.Rows.Add(
                        ++stt,
                        dgvVaccineBan.CurrentRow.Cells[0].FormattedValue.ToString(),
                        dgvVaccineBan.CurrentRow.Cells[1].FormattedValue.ToString(),
                        dgvVaccineBan.CurrentRow.Cells[2].FormattedValue.ToString(),
                        dgvVaccineBan.CurrentRow.Cells[3].FormattedValue.ToString(),
                        dgvVaccineBan.CurrentRow.Cells[4].FormattedValue.ToString(),
                        soLuongBan,
                        dgvVaccineBan.CurrentRow.Cells[6].FormattedValue.ToString(),
                        (soLuongBan * int.Parse(dgvVaccineBan.CurrentRow.Cells[6].FormattedValue.ToString()))

                        );
                }
                else
                    MessageBox.Show("Số lượng hàng không đủ mong bạn thông cảm!!", "Thông Báo");
                txtSoLuongBan.Text = "";
            }
            catch { }
            capNhatTongTien();
        }

        void loadTable()
        {
            dgvVaccineBan.Rows.Clear();
            XDoc = XmlFile.getXmlDocument(@"C:\Users\Trung\Desktop\BaiTap\VaccinationManagement\Vaccine\Vaccine\tb_Vaccine.xml");
            XmlNodeList nodeList = XDoc.SelectNodes("/Vaccines/vaccine");
            foreach (XmlNode x in nodeList)
            {
                dgvVaccineBan.Rows.Add(x.ChildNodes[0].InnerText, x.ChildNodes[1].InnerText, x.ChildNodes[2].InnerText, x.ChildNodes[3].InnerText, x.ChildNodes[4].InnerText, x.ChildNodes[5].InnerText, x.ChildNodes[6].InnerText);
            }
        }

        void capNhatSoLuong()
        {
            
            int SoluongCon = 0;
            int SoluongMua = 0;
            for (int i = 0; i < dgvVaccineBan.Rows.Count - 1; i++ )
            {
                SoluongCon += int.Parse(dgvVaccineBan.Rows[i].Cells[5].Value.ToString());
            }
            for (int i = 0; i < dgvGioHang.Rows.Count - 1; i++)
            {
                SoluongMua += int.Parse(dgvVaccineBan.Rows[i].Cells[5].Value.ToString());
            }

            SoluongCon = SoluongCon - SoluongMua;
            ////////////////
            dgvVaccineBan.Rows.Clear();
            dgvVaccineBan.ColumnCount = 7;

            XmlDocument XDoc = XmlFile.getXmlDocument("../../tb_Vaccine.xml");
            XmlNodeList ds = root.SelectNodes("/Vaccines/vaccine");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgvVaccineBan.Rows.Add();
                dgvVaccineBan.Rows[sd].Cells[0].Value = item.SelectSingleNode("TenDM").InnerText;
                dgvVaccineBan.Rows[sd].Cells[1].Value = item.SelectSingleNode("MaVC").InnerText;
                dgvVaccineBan.Rows[sd].Cells[2].Value = item.SelectSingleNode("TenVC").InnerText;
                dgvVaccineBan.Rows[sd].Cells[3].Value = item.SelectSingleNode("NgaySX").InnerText;
                dgvVaccineBan.Rows[sd].Cells[4].Value = item.SelectSingleNode("NgayHetHan").InnerText;
                dgvVaccineBan.Rows[sd].Cells[5].Value = SoluongCon.ToString();
                dgvVaccineBan.Rows[sd].Cells[6].Value = item.SelectSingleNode("GiaTien").InnerText;
                
                sd++;
            }
            ////// //////
            
            
        }

        void capNhatTongTien()
        {
            int tongTien = 0;
            for (int i = 0; i < dgvGioHang.Rows.Count - 1; i++)
            {
                tongTien += int.Parse(dgvGioHang.Rows[i].Cells[8].Value.ToString());
            }
            txtTongTien.Text = tongTien.ToString();
        }

        private void dgvGioHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

            List<XmlNode> nodeList = new List<XmlNode>();
            XmlDocument XDoc = XmlFile.getXmlDocument(@"C:\Users\Trung\Desktop\BaiTap\VaccinationManagement\Vaccine\Vaccine\ChiTietHoaDons.xml");
            for (int i = 0; i < dgvGioHang.Rows.Count - 1; i++)
            {

                XmlElement node = XDoc.CreateElement("ChiTietHoaDon");

                XmlElement maSP = XDoc.CreateElement("maSP");
                Console.WriteLine(i);


                maSP.InnerText = dgvGioHang.Rows[i].Cells[1].Value.ToString();
                Console.WriteLine(maSP.InnerText);

                XmlElement soLuong = XDoc.CreateElement("soLuong");
                soLuong.InnerText = dgvGioHang.Rows[i].Cells[6].Value.ToString();
                Console.WriteLine(soLuong.InnerText);

                XmlElement donGia = XDoc.CreateElement("DonGia");
                donGia.InnerText = dgvGioHang.Rows[i].Cells[8].Value.ToString(); ;
                Console.WriteLine(donGia.InnerText);

                node.AppendChild(maSP);
                node.AppendChild(soLuong);
                node.AppendChild(donGia);
                nodeList.Add(node);
            }
            Console.WriteLine(nodeList);

            HoaDon hoaDon = new HoaDon();
            hoaDon.add(XDoc, nodeList,"X");

           
            MessageBox.Show("Đã Thanh Toán Thành Công");
            loadTable();
            }
        

        private void dgvVaccineBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
