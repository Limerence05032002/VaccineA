using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vaccine.BLL;
using Vaccine.DTO;

namespace Vaccine.GUI
{
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private NHANVIEN_BLL nhanVienBLL = new NHANVIEN_BLL();
        private NhanVienDTO nhanVienDTO = new NhanVienDTO();

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            nhanVienBLL.HienThi(dgv);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMNV.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                nhanVienDTO.MaNV1 = txtMNV.Text.ToLower();
                nhanVienDTO.TenNV1 = txtTNV.Text;
                nhanVienDTO.TenDN1 = txtTDN.Text;
                nhanVienDTO.MK1 = txtMK.Text;
                nhanVienDTO.DiaChi1 = txtDC.Text;
                nhanVienDTO.SDT1 = txtSDT.Text;
                //gọi BLL thực hiện
                nhanVienBLL.ThemNV(nhanVienDTO);
                //hiện lên dgv
                nhanVienBLL.HienThi(dgv);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMNV.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                nhanVienDTO.MaNV1 = txtMNV.Text.ToLower(); ;

                //gọi BLL thực hiện
                nhanVienBLL.Xoa(nhanVienDTO);
                //hiện lên dgv
                nhanVienBLL.HienThi(dgv);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgv.CurrentRow.Selected = true;
                txtMNV.Text = dgv.Rows[e.RowIndex].Cells["MaNV"].FormattedValue.ToString();
                txtTNV.Text = dgv.Rows[e.RowIndex].Cells["Column1"].FormattedValue.ToString();
                txtTDN.Text = dgv.Rows[e.RowIndex].Cells["Column2"].FormattedValue.ToString();
                txtMK.Text = dgv.Rows[e.RowIndex].Cells["Column3"].FormattedValue.ToString();
                txtDC.Text = dgv.Rows[e.RowIndex].Cells["Column4"].FormattedValue.ToString();
                txtSDT.Text = dgv.Rows[e.RowIndex].Cells["Column5"].FormattedValue.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMNV.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                nhanVienDTO.MaNV1 = txtMNV.Text.ToLower();
                nhanVienDTO.TenNV1 = txtTNV.Text;
                nhanVienDTO.TenDN1 = txtTDN.Text;
                nhanVienDTO.MK1 = txtMK.Text;
                nhanVienDTO.DiaChi1 = txtDC.Text;
                nhanVienDTO.SDT1 = txtSDT.Text;
                //gọi BLL thực hiện
                nhanVienBLL.Sua(nhanVienDTO);
                //hiện lên dgv
                nhanVienBLL.HienThi(dgv);
            }
        }
        

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (txtFind.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                nhanVienDTO.MaNV1 = txtFind.Text;
                //gọi BLL thực hiện
                var nhanVienTim = nhanVienBLL.TimKiem2(nhanVienDTO, dgv);
                //khác null là tìm thấy, thực hiện bind lên ui
                if (nhanVienTim != null)
                {
                    txtMNV.Text = nhanVienTim.MaNV1;
                    txtTNV.Text = nhanVienTim.TenNV1;
                    txtTDN.Text = nhanVienTim.TenDN1;
                    txtMK.Text = nhanVienTim.MK1;
                    txtDC.Text = nhanVienTim.DiaChi1;
                    txtSDT.Text = nhanVienTim.SDT1;
                }
                else
                {
                    //không thấy thì xóa trăng
                    txtFind.Text = txtMNV.Text = txtTNV.Text = txtTDN.Text = txtMK.Text = txtDC.Text = txtSDT.Text = string.Empty;
                }
            }
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {

        }


    }
}
