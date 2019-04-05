using System.Collections.Generic;

namespace VanTaiDuongBo.Modules.VanTaiDuongBo.Models.Tuyen_BenXe
{
    public class TuyenBenXePartialModel
    {
        public long BenXeID { get; set; }
        public string TenBenXe { get; set; }
        public int SoXeBenXe { get; set; }
        public List<ListTuyen_ByBenXeModel> ListTuyen_ByBenXe { get; set; }
    }
}