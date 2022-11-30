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
    public partial class FormDanhMuc : Form
    {
        public FormDanhMuc()
        {
            InitializeComponent();
        }

        private DANHMUC_BLL danhMucBLL = new DANHMUC_BLL();
        private DanhMucDTO DanhMucDTO = new DanhMucDTO();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtDM.Text.Trim() != "")
            {
                DanhMucDTO.MaDM1 = txtDM.Text.ToLower();
                DanhMucDTO.TenDM1 = txtTDM.Text;

                danhMucBLL.ThemDM(DanhMucDTO);
                danhMucBLL.HienThi(dgv);
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            danhMucBLL.HienThi(dgv);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtDM.Text.Trim() != "")
            {
                //gán dữ liệu vào DTO
                DanhMucDTO.MaDM1 = txtDM.Text.ToLower(); ;

                //gọi BLL thực hiện
                danhMucBLL.Xoa(DanhMucDTO);
                //hiện lên dgv
                danhMucBLL.HienThi(dgv);
            }
            
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dgv.CurrentRow.Selected = true;
                txtDM.Text = dgv.Rows[e.RowIndex].Cells["Column1"].FormattedValue.ToString();
                txtTDM.Text = dgv.Rows[e.RowIndex].Cells["Column2"].FormattedValue.ToString();
                
            }
        }
    }
}
