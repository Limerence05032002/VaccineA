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

namespace Vaccine.GUI
{
    public partial class TrangQuanTri : Form
    {
        static public Vaccine form3;
        static public BanVaccine form4;
        public static String nameEmployee;
        public String maNV = "";

        private Form currentFormChild;

        private void OpenChildForm(Form ChildForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            panel_body.Controls.Add(ChildForm);
            panel_body.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        public TrangQuanTri()
        {
            InitializeComponent();
        }

        private void TrangQuanTri_Load(object sender, EventArgs e)
        {
            OpenChildForm(new FormNhanVien());
            label1.Text = button1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNhanVien());
            label1.Text = button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new BanVaccine());
            label1.Text = button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Vaccine());
            label1.Text = button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new LichSuBan());
            label1.Text = button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void panel_body_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Backup bk = new Backup();
            bk.BackUpData();
            MessageBox.Show("Đã sao lưu lên máy chủ", "Thành công!");
        }
    }
}
