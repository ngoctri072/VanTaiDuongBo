namespace VanTaiDuongBo.Modules.VanTaiDuongBo.Models.ThongTinViPham
{
    public class ViPhamByLoaiHinhModel
    {
        public long? LoaiHinhXeID { get; set; }
        public string TenLoaiHinhXe { get; set; }
        public long? ViPhamID { get; set; }
        public string TenViPham { get; set; }
        public int? SoLanViPham { get; set; }
        public int? TongLanViPham { get; set; }
    }
}