using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaccine.DTO
{
    class VaccineDTO
    {
        private string maVaccine;

        public string MaVaccine
        {
            get { return maVaccine; }
            set { maVaccine = value; }
        }
        private string tenVaccine;

        public string TenVaccine
        {
            get { return tenVaccine; }
            set { tenVaccine = value; }
        }
        private string ngaySX;

        public string NgaySX
        {
            get { return ngaySX; }
            set { ngaySX = value; }
        }
        private string ngayHetHan;

        public string NgayHetHan
        {
            get { return ngayHetHan; }
            set { ngayHetHan = value; }
        }
        private string soLuong;

        public string SoLuong
        {
            get { return soLuong; }
            set { soLuong = value; }
        }
        private string giaTien;

        public string GiaTien
        {
            get { return giaTien; }
            set { giaTien = value; }
        }
        private string TenDM;

        public string TenDM1
        {
            get { return TenDM; }
            set { TenDM = value; }
        }


        public VaccineDTO()
        {

        }

        public VaccineDTO(string maVaccine, string tenVaccine, string ngaySX, string ngayHetHan, string soLuong, string giaTien, string TenDM)
        {
            this.maVaccine = maVaccine;
            this.tenVaccine = tenVaccine;
            this.ngaySX = ngaySX;
            this.ngayHetHan = ngayHetHan;
            this.soLuong = soLuong;
            this.giaTien = giaTien;
            this.TenDM = TenDM;
        }
    }
}
