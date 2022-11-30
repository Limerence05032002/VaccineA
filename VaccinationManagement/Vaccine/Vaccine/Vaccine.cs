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
using Vaccine.GUI;

namespace Vaccine
{
    public partial class Vaccine : Form
    {
        XMLFile XmlFile = new XMLFile();
        XmlNodeList nodeListDM;
        XmlNodeList nodeListCTNS;
        
        public Vaccine()
        {
            InitializeComponent();
            DanhMuc DMSP = new DanhMuc();
            nodeListDM = DMSP.getListName();
            String maNS = "";
            foreach (XmlNode x in nodeListDM)
            {
                comboBox1.Items.Add(x.ChildNodes[1].InnerText);

            }
        }

        
        private VaccineDTO vaccineDTO = new VaccineDTO();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FormDanhMuc formDanhMuc = new FormDanhMuc();
            formDanhMuc.Show();
        }

        private void Vaccine_Load(object sender, EventArgs e)
        {

        }
    }
}
