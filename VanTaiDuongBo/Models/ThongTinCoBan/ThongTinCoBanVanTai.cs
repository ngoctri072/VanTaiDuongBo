using System.Collections.Generic;

namespace VanTaiDuongBo.Modules.VanTaiDuongBo.Models.ThongTinCoBan
{
    public class ThongTinCoBanVanTai
    {
        public List<ThongTinGiayPhepVanTaiModel> ThongTinGiayPhep { get; set; }
        public List<LoaiHinhKinhDoanhVanTaiPartialModel> LoaiHinhVanTai { get; set; }
    }
}