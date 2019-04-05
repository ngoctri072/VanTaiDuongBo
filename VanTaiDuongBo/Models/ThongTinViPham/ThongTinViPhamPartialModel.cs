using System.Collections.Generic;

namespace VanTaiDuongBo.Modules.VanTaiDuongBo.Models.ThongTinViPham
{
    public class ThongTinViPhamPartialModel
    {
        public long? ViPhamID { get; set; }
        public string TenViPham { get; set; }
        public int? SoLanViPham { get; set; }
        public int? TongLanViPham { get; set; }
        public List<HanhViXuLyViPhamModel> HanhViXuLyViPham { get; set; }
    }
}