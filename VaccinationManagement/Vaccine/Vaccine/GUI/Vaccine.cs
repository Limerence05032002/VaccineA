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
    public partial class Vaccine : Form
    {

        XMLFile XmlFile = new XMLFile();
        XmlNodeList nodeListDM;
        XmlNodeList nodeListCTNS;
        int stt = 0;

        private VaccineBLL vaccineBLL = new VaccineBLL();
        private VaccineDTO vaccineDTO = new VaccineDTO();

        public Vaccine()
        {
            InitializeComponent();
            vaccineBLL.HienThi(grvVaccine);
        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            stt = 0;
            HoaDon hd = new HoaDon();

            hd.ThemHoaDon(grvVaccine, "N");

            if (txtMaVaccine.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                vaccineDTO.TenDM1 = comboBox1.Text;
                vaccineDTO.MaVaccine = txtMaVaccine.Text;
                vaccineDTO.TenVaccine = txtTenVaccine.Text;
                vaccineDTO.NgaySX = dateTimePicker1.Text;
                vaccineDTO.NgayHetHan = dateTimePicker2.Text;
                vaccineDTO.SoLuong = txtSoLuong.Text;
                vaccineDTO.GiaTien = txtGiaTien.Text;
                
           
                //gọi BLL thực hiện
                vaccineBLL.Them(vaccineDTO);
                //hiện lên dgv
                vaccineBLL.HienThi(grvVaccine);
            }
            MessageBox.Show("Thêm Sản Phẩm Thành Công", "Thông Báo");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaVaccine.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                vaccineDTO.TenDM1 = comboBox1.Text;
                vaccineDTO.MaVaccine = txtMaVaccine.Text;
                vaccineDTO.TenVaccine = txtTenVaccine.Text;
                vaccineDTO.NgaySX = dateTimePicker1.Text;
                vaccineDTO.NgayHetHan = dateTimePicker2.Text;
                vaccineDTO.SoLuong = txtSoLuong.Text;
                vaccineDTO.GiaTien = txtGiaTien.Text;

                //gọi BLL thực hiện
                vaccineBLL.Sua(vaccineDTO);
                //hiện lên dgv
                vaccineBLL.HienThi(grvVaccine);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaVaccine.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                string MaVaccine = txtMaVaccine.Text;

                //gọi BLL thực hiện
                vaccineBLL.Xoa(MaVaccine);
                //hiện lên dgv
                vaccineBLL.HienThi(grvVaccine);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
           
            if (txtMaVaccine.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                vaccineDTO.MaVaccine = txtMaVaccine.Text;
                //gọi BLL thực hiện
                var vaccineTim = vaccineBLL.TimKiem2(vaccineDTO, grvVaccine);
                //khác null là tìm thấy, thực hiện bind lên ui
                if (vaccineTim != null)
                {
                    comboBox1.Text = vaccineTim.TenDM1;
                    txtMaVaccine.Text = vaccineTim.MaVaccine;
                    txtTenVaccine.Text = vaccineTim.TenVaccine;
                    dateTimePicker1.Text = vaccineTim.NgaySX;
                    dateTimePicker2.Text = vaccineTim.NgayHetHan;
                    vaccineDTO.SoLuong = txtSoLuong.Text;
                    vaccineDTO.GiaTien = txtGiaTien.Text;
                    
                }
                else
                {
                    //không thấy thì xóa trăng
                    MessageBox.Show("Không tìm thấy vaccine");
                    vaccineBLL.HienThi(grvVaccine);
                }
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Vaccine_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DanhMuc DMSP = new DanhMuc();
            nodeListDM = DMSP.getListName();
            comboBox1.Items.Clear();
            foreach (XmlNode x in nodeListDM)
            {
                
                comboBox1.Items.Add(x.ChildNodes[1].InnerText);
                
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtGiaTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void grvVaccine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grvVaccine.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                grvVaccine.CurrentRow.Selected = true;
                comboBox1.Text = grvVaccine.Rows[e.RowIndex].Cells["Column1"].FormattedValue.ToString();
                txtMaVaccine.Text = grvVaccine.Rows[e.RowIndex].Cells["Column2"].FormattedValue.ToString();
                txtTenVaccine.Text = grvVaccine.Rows[e.RowIndex].Cells["Column3"].FormattedValue.ToString();
                //dateTimePicker1.Text = grvVaccine.Rows[e.RowIndex].Cells["Column4"].FormattedValue.ToString();
                //dateTimePicker2.Text = grvVaccine.Rows[e.RowIndex].Cells["Column5"].FormattedValue.ToString();
                txtSoLuong.Text = grvVaccine.Rows[e.RowIndex].Cells["Column6"].FormattedValue.ToString();
                txtGiaTien.Text = grvVaccine.Rows[e.RowIndex].Cells["Column7"].FormattedValue.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDanhMuc formDanhMuc = new FormDanhMuc();
            formDanhMuc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            stt = 0;
            HoaDon hd = new HoaDon();


            MessageBox.Show("Thêm Sản Phẩm Thành Công", "Thông Báo");
            grvVaccine.Rows.Clear();
        }
        //Char.IsDigit(e.KeyChar) –> kiểm tra xem phím vừa nhập vào textbox có phải là ký tự số hay không, hàm này trả về kiểu bool
        //Char.IsContro(e.KeyChar) –> kiểm tra xem phím vừa nhập vào textbox có phải là các ký tự điều khiển (các phím mũi tên,Delete,Insert,backspace,space bar) hay không, 
        //mục đích dùng hàm này là để cho phép người dùng xóa số trong trường hợp nhập sai.
    }
}
