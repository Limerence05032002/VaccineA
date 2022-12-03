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
    class VaccineBLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        private string fileName = "../../tb_Vaccine.xml";

        public VaccineBLL()
        {
            doc.Load(fileName);
            root = doc.DocumentElement;
        }



        XMLFile XmlFile = new XMLFile();
        public XmlNodeList getListName()
        {

            XmlDocument XDoc = XmlFile.getXmlDocument("../../tb_Vaccine.xml");

            return XDoc.SelectNodes("/Vaccines/vaccine");
        }

        public void setSoluong(int soLuongTraoDoi, XmlNode node)
        {
            if (node != null)
                node.ChildNodes[5].InnerText = (int.Parse(node.ChildNodes[5].InnerText) + soLuongTraoDoi).ToString();
        }



        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 7;

            XmlNodeList ds = root.SelectNodes("vaccine");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("TenDM").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("MaVC").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("TenVC").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("NgaySX").InnerText;
                dgv.Rows[sd].Cells[4].Value = item.SelectSingleNode("NgayHetHan").InnerText;
                dgv.Rows[sd].Cells[5].Value = item.SelectSingleNode("SoLuong").InnerText;
                dgv.Rows[sd].Cells[6].Value = item.SelectSingleNode("GiaTien").InnerText;
                
                sd++;
            }
        }



        public void Them(VaccineDTO vaccine)
        {
            //tạo nút vaccine
            XmlNode vc = doc.CreateElement("vaccine");

            //tạo nút con của khách hàng là maVaccine
            XmlElement TenDM = doc.CreateElement("TenDM");
            TenDM.InnerText = vaccine.TenDM1.ToString();
            vc.AppendChild(TenDM);

            XmlElement maVaccine = doc.CreateElement("MaVC");
            maVaccine.InnerText = vaccine.MaVaccine;//gán giá trị cho maVaccine
            vc.AppendChild(maVaccine);//thêm maVaccine vào trong vaccine

            XmlElement tenVC = doc.CreateElement("TenVC");
            tenVC.InnerText = vaccine.TenVaccine;
            vc.AppendChild(tenVC);   

            XmlElement ngaySX = doc.CreateElement("NgaySX");
            ngaySX.InnerText = vaccine.NgaySX.ToString();
            vc.AppendChild(ngaySX);

            XmlElement NgayHetHan = doc.CreateElement("NgayHetHan");
            NgayHetHan.InnerText = vaccine.NgayHetHan;
            vc.AppendChild(NgayHetHan);

            XmlElement SoLuong = doc.CreateElement("SoLuong");
            SoLuong.InnerText = vaccine.SoLuong;
            vc.AppendChild(SoLuong);

            XmlElement GiaTien = doc.CreateElement("GiaTien");
            GiaTien.InnerText = vaccine.GiaTien;
            vc.AppendChild(GiaTien);

            
          
            //thêm vaccine vào gốc root
            root.AppendChild(vc);
            doc.Save(fileName);//lưu dữ liệu
        }


        public void Sua(VaccineDTO vaccine)
        {
            //lấy vị trí cần sửa theo mã kh cũ đưa vào
            XmlNode vaccineCu = root.SelectSingleNode("vaccine[MaVC='" + vaccine.MaVaccine + "']");
            if (vaccineCu != null)
            {
                XmlNode vc = doc.CreateElement("vaccine");

                XmlElement TenDM = doc.CreateElement("TenDM");
                TenDM.InnerText = vaccine.TenDM1.ToString();
                vc.AppendChild(TenDM);

                XmlElement maVaccine = doc.CreateElement("MaVC");
                maVaccine.InnerText = vaccine.MaVaccine;//gán giá trị cho maVaccine
                vc.AppendChild(maVaccine);//thêm maVaccine vào trong vaccine

                XmlElement tenVC = doc.CreateElement("TenVC");
                tenVC.InnerText = vaccine.TenVaccine;
                vc.AppendChild(tenVC);

                XmlElement ngaySX = doc.CreateElement("NgaySX");
                ngaySX.InnerText = vaccine.NgaySX.ToString();
                vc.AppendChild(ngaySX);

                XmlElement NgayHetHan = doc.CreateElement("NgayHetHan");
                NgayHetHan.InnerText = vaccine.NgayHetHan;
                vc.AppendChild(NgayHetHan);

                XmlElement soLuong = doc.CreateElement("SoLuong");
                soLuong.InnerText = vaccine.SoLuong.ToString();
                vc.AppendChild(soLuong);

                XmlElement giaTien = doc.CreateElement("GiaTien");
                giaTien.InnerText = vaccine.GiaTien.ToString();
                vc.AppendChild(giaTien);


                

                //thay thế sách cũ bằng sách mới(sửa )
                root.ReplaceChild(vc, vaccineCu);
                doc.Save(fileName);//lưu lại
            }
        }

        public void Xoa(string MaVaccine)
        {
            XmlNode vaccineXoa = root.SelectSingleNode("vaccine[MaVC ='" + MaVaccine + "']");
            if (vaccineXoa != null)
            {
                root.RemoveChild(vaccineXoa);

                doc.Save(fileName);
            }
        }

        public void TimKiem(VaccineDTO vaccine, DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode vaccineTim = root.SelectSingleNode("vaccine[MaVC ='" + vaccine.MaVaccine + "']");
            
            if (vaccineTim != null)
            {
                MessageBox.Show("vao day roi nha");
                dgv.ColumnCount = 7;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = vaccineTim.SelectSingleNode("TenDM").InnerText;
                dgv.Rows[0].Cells[1].Value = vaccineTim.SelectSingleNode("MaVC").InnerText;
                dgv.Rows[0].Cells[2].Value = vaccineTim.SelectSingleNode("TenVC").InnerText;
                dgv.Rows[0].Cells[3].Value = vaccineTim.SelectSingleNode("NgaySX").InnerText;
                dgv.Rows[0].Cells[4].Value = vaccineTim.SelectSingleNode("NgayHetHan").InnerText;
                dgv.Rows[0].Cells[5].Value = vaccineTim.SelectSingleNode("SoLuong").InnerText;
                dgv.Rows[0].Cells[6].Value = vaccineTim.SelectSingleNode("GiaTien").InnerText;
                
               
            }
            
        }

        public VaccineDTO TimKiem2(VaccineDTO vaccine, DataGridView dgv)
        {

            VaccineDTO ketQua = null;
            dgv.Rows.Clear();
            XmlNode vaccinTim = root.SelectSingleNode("vaccine[MaVC='" + vaccine.MaVaccine + "']");

            if (vaccinTim != null)
            {

                dgv.ColumnCount = 7;//khai báo số cột
                dgv.Rows.Add();//thêm một dòng mới

                //đưa dữ liệu vào dòng vừa tạo
                dgv.Rows[0].Cells[0].Value = vaccinTim.SelectSingleNode("TenDM").InnerText;
                dgv.Rows[0].Cells[1].Value = vaccinTim.SelectSingleNode("MaVC").InnerText;
                dgv.Rows[0].Cells[2].Value = vaccinTim.SelectSingleNode("TenVC").InnerText;
                dgv.Rows[0].Cells[3].Value = vaccinTim.SelectSingleNode("NgaySX").InnerText;
                dgv.Rows[0].Cells[4].Value = vaccinTim.SelectSingleNode("NgayHetHan").InnerText;
                dgv.Rows[0].Cells[5].Value = vaccinTim.SelectSingleNode("SoLuong").InnerText;
                dgv.Rows[0].Cells[6].Value = vaccinTim.SelectSingleNode("GiaTien").InnerText;
                
            

                ketQua = new VaccineDTO();

                ketQua.TenDM1 = vaccinTim.SelectSingleNode("TenDM").InnerText;
                ketQua.MaVaccine = vaccinTim.SelectSingleNode("MaVC").InnerText;
                ketQua.TenVaccine = vaccinTim.SelectSingleNode("TenVC").InnerText;
                ketQua.NgaySX = vaccinTim.SelectSingleNode("NgaySX").InnerText;
                ketQua.NgayHetHan = vaccinTim.SelectSingleNode("NgayHetHan").InnerText;
                ketQua.SoLuong = vaccinTim.SelectSingleNode("SoLuong").InnerText;
                ketQua.GiaTien = vaccinTim.SelectSingleNode("GiaTien").InnerText;
                

            }
            return ketQua;

        }



    }
}
