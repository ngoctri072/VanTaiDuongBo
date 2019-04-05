using System.Collections.Generic;

namespace VanTaiDuongBo.Modules.VanTaiDuongBo.Models.ThongTinViPham
{
    public class ChiTietViPhamPartialModel
    {
        public long? LoaiHinhXeID { get; set; }
        public string TenLoaiHinhXe { get; set; }
        public long? ViPhamID { get; set; }
        public string TenViPham { get; set; }
        public int? SoLanViPham { get; set; }
        public int? TongLanViPham { get; set; }
        public List<HanhViXuLyViPhamDetailModel> hanhViXuLyViPhamModels { get; set; }
        public List<ListPhuongTienPartialModel> listPhuongTienModels { get; set; }
    }
}