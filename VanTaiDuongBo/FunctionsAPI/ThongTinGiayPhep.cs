using System.Collections.Generic;
using VanTaiDuongBo.Modules.VanTaiDuongBo.CallAPIProvider;
using VanTaiDuongBo.Modules.VanTaiDuongBo.Models;
using VanTaiDuongBo.Modules.VanTaiDuongBo.Models.ThongTinCoBan;

namespace VanTaiDuongBo.Modules.VanTaiDuongBo.FunctionsAPI
{
    public class ThongTinGiayPhep
    {
        GetResponseFromAPI callAPI = new GetResponseFromAPI();
        APIUrl apiUrl = new APIUrl();
        public ThongTinCoBanVanTai ThongTinCoBan(long DonViVanTaiID)
        {
            ThongTinCoBanVanTai loaihinhVanTai = new ThongTinCoBanVanTai();
            var urlCallThongTinGiayPhep = apiUrl.urlAPI + "ThongTinGiayPhep/Get_ByDonViVanTaiID?donvivantaiID=" + DonViVanTaiID;
            List<ThongTinGiayPhepVanTaiModel> resultThongTinGiayPhep = callAPI.CallAPIThongTinGiayPhep(urlCallThongTinGiayPhep);

            var urlCallLoaiHinhKinhDoanh = apiUrl.urlAPI + "LoaiHinhVanTai/Get_ByDonViVanTaiID?donvivantaiID=" + DonViVanTaiID;
            List<LoaiHinhKinhDoanhVanTaiPartialModel> resultLoaiHinhKDVanTai = callAPI.CallAPILoaiHinhVanTai(urlCallLoaiHinhKinhDoanh);

            loaihinhVanTai.ThongTinGiayPhep = resultThongTinGiayPhep;
            loaihinhVanTai.LoaiHinhVanTai = resultLoaiHinhKDVanTai;

            return loaihinhVanTai;
        }
    }
}