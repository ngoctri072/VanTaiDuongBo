using System.Collections.Generic;

namespace VanTaiDuongBo.Modules.VanTaiDuongBo.Models.SoLieuXe
{
    public class SoLieuXePartialModel
    {
        public long LoaiHinhXeID { get; set; }
        public int TongSoXe { get; set; }
        public int SoXe { get; set; }
        public string LoaiHinhXe { get; set; }
        public List<ListXe_LoaiHinhXeModel> ListXe { get; set; }
    }
}