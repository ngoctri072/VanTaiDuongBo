using System;

namespace VanTaiDuongBo.Modules.VanTaiDuongBo.Models
{
    public class ThongTinGiayPhepVanTaiModel
    {
        public string TenDonVi { get; set; }
        public string SoGiayPhep { get; set; }
        public string NgayCap { get; set; }
        public Nullable<int> CapLan { get; set; }
        public string NgayHetHan { get; set; }
        public string DiaChiKinhDoanh { get; set; }
        public Nullable<int> SoLuongXe { get; set; }
        public string NgayBaoCao { get; set; }
    }
}