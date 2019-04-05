using DotNetNuke.Web.Mvc.Framework.Controllers;
using System.Web.Mvc;
using VanTaiDuongBo.Modules.VanTaiDuongBo.CallAPIProvider;
using VanTaiDuongBo.Modules.VanTaiDuongBo.Models;
using VanTaiDuongBo.Modules.VanTaiDuongBo.FunctionsAPI;
using API_Call.Components;
using API_Call.UrlApi.DanhMuc;
using Newtonsoft.Json.Linq;

namespace VanTaiDuongBo.Modules.VanTaiDuongBo.Controllers
{
    public class QuanLyVanTaiController : DnnController
    {
        GetResponseFromAPI callAPI = new GetResponseFromAPI();
        ThongTinGiayPhep thongTinGiayPhep = new ThongTinGiayPhep();
        SoLieuXe soLieuXe = new SoLieuXe();
        ThongTinTuyenBenXe thongTinTuyenBenXe = new ThongTinTuyenBenXe();
        ThongTinViPham thongTinViPham = new ThongTinViPham();
        APIUrl apiUrl = new APIUrl();

        CommonAPI commonAPI;
        UrlAPIDanhMuc urlAPIDanhMuc;
        BaseController baseController = new BaseController();

        public QuanLyVanTaiController()
        {
            commonAPI = new CommonAPI();
            urlAPIDanhMuc = new UrlAPIDanhMuc();
        }

        #region Phần Danh sách Đơn vị vận tải
        // ==============Phần Danh sách các đơn vị vận tải======================
        public ActionResult DonViVanTai()
        {
            return View();
        }
        public ActionResult GetDataVanTai(PagingModel paging)
        {
            //if (paging.Index == null)
            //    paging.Index = 1;
            //var url1 = baseController.urlAPI + urlAPIDanhMuc.urlGetDataVanTai + "?Index=" + paging.Index + "&pageSize=" + paging.pageSize;
            //var url = "http://localhost:7777/api/DoanhNghiepVanTai/Get_DonViVanTai?Index=1&pageSize=10";

            //var result = commonAPI.CallAPIVanTai(url);
            if (paging.Index == null)
                paging.Index = 1;
            var url = apiUrl.urlAPI + "DoanhNghiepVanTai/Get_DonViVanTai?Index=" + paging.Index + "&pageSize=" + paging.pageSize;
            var result = callAPI.CallAPIVanTai(url);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //===============Hết phần danh sách các đơn vị vận tải========================
        #endregion

        #region Phần trang chi tiết 1 đơn vị vận tải 
        //===============Phần hiển thị trang chi tiết==================================
        [HttpGet]
        public ActionResult ChiTietVanTai(long DonViVanTaiID)
        {
            ViewBag.DonViVanTaiID = DonViVanTaiID;

            //Gọi hàm lấy thông tin cơ bản Partial Loại hình kinh doanh
            ViewBag.ThongTinCoBan = thongTinGiayPhep.ThongTinCoBan(DonViVanTaiID);

            //Gọi hàm lấy thông tin Số liệu xe
            ViewBag.ThongTinSoLieuXe = soLieuXe.ThongTinSoLieuXe(DonViVanTaiID);

            //Gọi hàm lấy thông tin Bến xe và Tuyến theo Bến xe
            ViewBag.ThongTinTuyen = thongTinTuyenBenXe.ThongTinChiTietTuyen(DonViVanTaiID);

            //Gọi hàm lấy thông tin vi phạm Chung theo đơn vị vận tảu
            ViewBag.ThongTinViPhamChung = thongTinViPham.GetByDonViVanTai(DonViVanTaiID);

            //Gọi hàm lấy thông tin vi phạm chi tiết theo Loại hình - Phương tiện
            ViewBag.ThongTinViPhamChiTiet = thongTinViPham.GetThongTinViPhamChiTiet(DonViVanTaiID);

            return View();
        }
        //================Hết phần hiển thị trang chi tiết=============================
        #endregion

        #region Phần các Combobox
        //===============Phần load các Combobox form tìm kiếm ======================
        public ActionResult GetDataLoaiHinhKinhDoanh()
        {

            var url = apiUrl.urlAPI + "DanhMucDungChung/Get_LoaiHinhKinhDoanh";
            var result = callAPI.CallAPILoaiHinhKinhDoanh(url);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataDoanhNghiepVanTai()
        {
            var url = apiUrl.urlAPI + "DanhMucDungChung/Get_DoanhNghiepVanTai";
            var resultDN = callAPI.CallAPIDoanhNghiepVanTai(url);

            return Json(resultDN, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataLoaiHinhDoanhNghiep()
        {
            var url = apiUrl.urlAPI + "DanhMucDungChung/Get_LoaiHinhDoanhNghiep";
            var resultloaiDN = callAPI.CallAPILoaiHinhDoanhNghiep(url);

            return Json(resultloaiDN, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataQuanHuyen()
        {
            var url = apiUrl.urlAPI + "DanhMucDungChung/Get_QuanHuyen";
            var resultQuanHuyen = callAPI.CallAPIQuanHuyen(url);

            return Json(resultQuanHuyen, JsonRequestBehavior.AllowGet);
        }
        //============Hết phần Load các Combobox form tìm kiếm=====================
        #endregion
    }
}