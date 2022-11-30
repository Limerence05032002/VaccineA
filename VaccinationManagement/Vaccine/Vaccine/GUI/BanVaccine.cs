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
    public partial class BanVaccine : Form
    {
        XMLFile XmlFile = new XMLFile();
        XmlDocument XDoc;
        XmlDocument XDocVaccine;
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
                        
                        dgvVaccineBan.CurrentRow.Cells[5].FormattedValue.ToString(),
                        (soLuongBan * int.Parse(dgvVaccineBan.CurrentRow.Cells[5].FormattedValue.ToString()))

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
            XDoc = XmlFile.getXmlDocument("../../tb_Vaccine.xml");
            XmlNodeList nodeList = XDoc.SelectNodes("/Vaccines/vaccine");
            foreach (XmlNode x in nodeList)
            {
                dgvVaccineBan.Rows.Add(x.ChildNodes[0].InnerText, x.ChildNodes[1].InnerText, x.ChildNodes[2].InnerText, x.ChildNodes[3].InnerText, x.ChildNodes[4].InnerText, x.ChildNodes[5].InnerText, x.ChildNodes[6].InnerText);
            }
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
            //List<XmlNode> nodeList = new List<XmlNode>();
            //XmlDocument XDoc = XmlFile.getXmlDocument("../../ChiTietHoaDons.xml");
            //for (int i = 0; i < dgvGioHang.Rows.Count - 1; i++)
            //{

            //    XmlElement node = XDoc.CreateElement("ChiTietHoaDon");

            //    XmlElement maVaccine = XDoc.CreateElement("MaVaccine");
            //    Console.WriteLine(i);


            //    maVaccine.InnerText = dgvGioHang.Rows[i].Cells[1].Value.ToString();


            //    XmlElement soLuong = XDoc.CreateElement("SoLuong");

            //    soLuong.InnerText = dgvGioHang.Rows[i].Cells[3].Value.ToString();
            //    XmlElement donGia = XDoc.CreateElement("DonGia");
            //    donGia.InnerText = dgvGioHang.Rows[i].Cells[4].Value.ToString(); ;

            //    node.AppendChild(maVaccine);
            //    node.AppendChild(soLuong);
            //    node.AppendChild(donGia);
            //    nodeList.Add(node);
            //}


            //HoaDon hoaDon = new HoaDon();


            ////String maKH = textBoxMaKhachHang.Text;
            ////Console.WriteLine(maKH + "123");
            ////if (maKH.Equals(""))
            ////    maKH = "KH00000";

            //XmlNodeList n = XDocVaccine.SelectNodes("/KhachHangs/KhachHang[maKH = '" + maKH + "']");
            //n[0].ChildNodes[2].InnerText = (int.Parse(n[0].ChildNodes[2].InnerText) + int.Parse(labelTongTien.Text)).ToString();
            //XDocVaccine.Save("KhachHangs.xml");



            //hoaDon.add(XDoc, nodeList, maKH, "X");



            //loadTable();
            //MessageBox.Show("Đã Thanh Toán Thành Công");
        }

        private void dgvVaccineBan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
