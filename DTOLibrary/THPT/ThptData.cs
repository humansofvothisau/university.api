using System.Collections.Generic;

namespace DTOLibrary.THPT
{
    public class ThptData
    {
        public double? Toan { get; set; }
        public double? NguVan { get; set; }
        public double? NgoaiNgu { get; set; }
        public double? VatLi { get; set; }
        public double? HoaHoc { get; set; }
        public double? SinhHoc { get; set; }
        public double? KHTN { get; set; }
        public double? DiaLi { get; set; }
        public double? LichSu { get; set; }
        public double? GDCD { get; set; }
        public double? KHXH { get; set; }
        public string ResultGroup { get; set; }
        public List<KeyValuePair<string, double>> ResultGroupConvert { get; set; }
        public string Result { get; set; }
    }
}
