using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Vaccine.GUI
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        public string FromXML_user = "";
        public string FromXML_pass = "";
        public string FromXML_name = "";

        private void button2_Click(object sender, EventArgs e)
        {
            String user = username.Text;
            String pass = password.Text;
             
            XDocument doc = XDocument.Load(@"../../NhanVien.xml");
            var selected_user = from x in doc.Descendants("NhanVien").Where
                                (x => (string)x.Element("TenDangNhap") == username.Text)
                                select new
                                {
                                    XMLuser = x.Element("TenDangNhap").Value,
                                    XMLpass = x.Element("MatKhau").Value,
                                    XMLname = x.Element("TenNhanVien").Value
                                };
            foreach (var x in selected_user)
            {
                FromXML_user = x.XMLuser;
                FromXML_pass = x.XMLpass;
                FromXML_name = x.XMLname;
            }

            if (user == FromXML_user){
                if (pass == FromXML_pass)
                {
                        MessageBox.Show("Đăng nhập thành công !");
                        ClearBox();
                        this.Hide();
                        FormNhanVien FormNhanVien = new FormNhanVien();
                        FormNhanVien.Show();
                    }else
                    {
                        MessageBox.Show("Sai mật khẩu");
                        ClearBox();  
                    }
            }else{
                    MessageBox.Show("Sai tên đăng nhập !");
                    ClearBox();
                }
        }
            private void ClearBox(){
                username.Clear();
                password.Clear();
            }

            private void DangNhap_Load(object sender, EventArgs e)
            {

            }
        }
    }
