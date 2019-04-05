using System.Collections.Generic;

namespace VanTaiDuongBo.Modules.VanTaiDuongBo.Models.ThongTinViPham
{
    public class ListPhuongTienPartialModel
    {
        public long? XeID { get; set; }
        public string BienSoXe { get; set; }
        public long? ViPhamID { get; set; }
        public string TenViPham { get; set; }
        public int? SoLanViPham { get; set; }
        public List<HanhViXuLyViPhamByXeModel> listHanhViXuLyByXeModels { get; set; }
        public List<VanBanXuLyViPhamByXeModel> listVanBanXuLyViPhamModels { get; set; }
    }
}