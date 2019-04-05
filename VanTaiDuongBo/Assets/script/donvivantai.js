
$(function () {
    $('#toggle-two').bootstrapToggle({
        on: 'Hoạt động',
        off: 'Thu hồi'
    });

    $('#toggle-giayphep').bootstrapToggle({
        on: 'Hoạt động',
        off: 'Khóa'
    });
})


$(document).ready(function () {
    $("#tableTraCuu").hide();
    $("#dnn_ctr1287_dnnTITLE_titleLabel").hide();
    LoadListData();

    //Load các combobox phần form tra cứu
    GETSelectLoaiHinhKD();
    GETSelectDoanhNghiepVanTai();
    GETSelectLoaiHinhDoanhNghiep();
    GETSelectQuanHuyen();

    ShowTimKiemNangCao();
});

//Phần sự kiện click Datatable

async function LoadListData() {
    var ajaxCall = await $.ajax({
        type: 'GET',
        url: $("#UrlGetData").val(),
        contentType: "application/json;charset=utf-8",
        dataType: "text",
        headers: {
            "ModuleId": @Dnn.ModuleContext.ModuleId,
    "TabId": @Dnn.ModuleContext.TabId,
},
    //data: thongtin,
});
try {
    var dnnViewResp = ajaxCall;
    dnnViewResp = dnnViewResp.substring(0, dnnViewResp.indexOf("<!DOCTYPE html>"));
    var data = JSON.parse(dnnViewResp);
    debugger
    console.log(data);
    BinThongTin(data);
}
catch (e) {
    console.log(e);
}
    }
async function BinThongTin(data) {
    var _grid = $("#gridContainer").dxDataGrid({
        dataSource: data,
        paging: {
            pageSize: 10
        },
        pager: {
            showPageSizeSelector: true,
            allowedPageSizes: [5, 10, 20, 50, 100],
            showInfo: true
        },

        columns: [
            {
                caption: "STT",
                cellTemplate: function (container, options) {
                    container.text(_grid.pageIndex() * _grid.pageSize() + options.rowIndex + 1);
                },
                alignment: 'center',
                width: "6%"
            },
            {
                dataField: "TenDonVi",
                caption: "Doanh nghiệp",
                alignment: 'center',
                width: "30%"
                //visible: false,
            },
            {
                dataField: "SoGiayPhep",
                caption: "Số giấy phép",
                alignment: 'center',
                width: "12%"
                //visible: false,
            },
            {
                dataField: "CapLan",
                caption: "Lần cấp",
                alignment: 'center',
                width: "12%"
                //visible: false,
            },

            {
                dataField: "NgayCap",
                caption: "Ngày cấp",
                alignment: 'center',
                dataType: 'date',
                format: 'dd/MM/yyyy',
                width: "14%"
                //visible: false,
            },

            {
                dataField: "NgayHetHan",
                caption: "Thời hạn",
                alignment: 'center',
                dataType: 'date',
                format: 'dd/MM/yyyy',
                width: "14%"
                //visible: false,
            },

            {
                caption: ".::.",
                width: '12%',
                alignment: 'center',
                cellTemplate: function (cellElement, cellInfo) {
                    $('<i />').addClass('fa fa-search')
                        //.text("Sửa")
                        .on('dxclick', function (args) {
                            //ShowModalEdit(cellInfo.data.tinhthanhid);
                            ShowChiTietVanTai();
                        })
                        .appendTo(cellElement);
                },
                alignment: 'center'
            },
        ],
        showBorders: true,

    }).dxDataGrid("instance");
}

//Script show chi tiết của 1 đơn vị vận tải
async function ShowChiTietVanTai() {
    $.ajax({
        type: 'GET',
        url: $("#UrlChiTietVanTai").val(),
        contentType: "application/json;charset=utf-8",
        success: function () {
            window.location.href = '@Html.Raw(Url.Action("ChiTietVanTai", "QuanLyVanTai"))'
        }
    });
    debugger
}

//Script load Combobox Loại hình kinh doanh
async function GETSelectLoaiHinhKD() {
    var ListLoaiHinhKD = await $.ajax({
        type: 'GET',
        url: $("#UrlLoaiHinhKinhDoanh").val(),
        contentType: "application/x-www-form-urlencoded",
        dataType: "text"
    });
    try {
        var dnnViewResp = ListLoaiHinhKD;
        dnnViewResp = dnnViewResp.substring(0, dnnViewResp.indexOf("<!DOCTYPE html>"));
        var data = JSON.parse(dnnViewResp);

        $('#loaihinhKD').dxSelectBox({
            dataSource: data,
            placeholder: '--- Chọn loại hình kinh doanh ---',
            valueExpr: 'LoaiHinhKinhDoanhID',
            displayExpr: 'TenLoaiHinhKinhDoanh',
            onValueChanged: function (e) {
                //pTestBienLai_Loaiphi(e.value);
            }
        }).dxSelectBox('instance');
    }
    catch (e) {
        console.log(e);
    }
}

async function GETSelectDoanhNghiepVanTai() {
    var ListDNVanTai = await $.ajax({
        type: 'GET',
        url: $("#UrlDoanhNghiepVanTai").val(),
        contentType: "application/x-www-form-urlencoded",
        dataType: "text"
    });
    try {
        var dnnViewDN = ListDNVanTai;
        debugger
        dnnViewDN = dnnViewDN.substring(0, dnnViewDN.indexOf("<!DOCTYPE html>"));
        var dataDN = JSON.parse(dnnViewDN);

        $('#doanhnghiepVanTai').dxSelectBox({
            dataSource: dataDN,
            placeholder: '--- Chọn Doanh nghiệp vận tải ---',
            valueExpr: 'DoanhNghiepID',
            displayExpr: 'TenDoanhNghiep',
            onValueChanged: function (e) {
                //pTestBienLai_Loaiphi(e.value);
            }
        }).dxSelectBox('instance');
    }
    catch (e) {
        console.log(e);
    }
}

async function GETSelectLoaiHinhDoanhNghiep() {
    var ListLoaiHinhDN = await $.ajax({
        type: 'GET',
        url: $("#UrlLoaiHinhDoanhNghiep").val(),
        contentType: "application/x-www-form-urlencoded",
        dataType: "text"
    });
    try {
        var dnnViewLoaiDN = ListLoaiHinhDN;
        dnnViewLoaiDN = dnnViewLoaiDN.substring(0, dnnViewLoaiDN.indexOf("<!DOCTYPE html>"));
        var dataLoaiDN = JSON.parse(dnnViewLoaiDN);

        $('#loaihinhDoanhNghiep').dxSelectBox({
            dataSource: dataLoaiDN,
            placeholder: '--- Chọn loại hình Doanh nghiệp ---',
            valueExpr: 'LoaiDoanhNghiepID',
            displayExpr: 'TenLoaiDoanhNghiep',
            onValueChanged: function (e) {
                //pTestBienLai_Loaiphi(e.value);
            }
        }).dxSelectBox('instance');
    }
    catch (e) {
        console.log(e);
    }
}

async function GETSelectQuanHuyen() {
    var ListQuanHuyen = await $.ajax({
        type: 'GET',
        url: $("#UrlQuanHuyen").val(),
        contentType: "application/x-www-form-urlencoded",
        dataType: "text"
    });
    try {
        var dnnViewQuanHuyen = ListQuanHuyen;
        dnnViewQuanHuyen = dnnViewQuanHuyen.substring(0, dnnViewQuanHuyen.indexOf("<!DOCTYPE html>"));
        var dataQuanHuyen = JSON.parse(dnnViewQuanHuyen);

        $('#quanhuyen').dxSelectBox({
            dataSource: dataQuanHuyen,
            placeholder: '--- Chọn Quận huyện ---',
            valueExpr: 'QuanHuyenID',
            displayExpr: 'TenQuanHuyen',
            onValueChanged: function (e) {
                //pTestBienLai_Loaiphi(e.value);
            }
        }).dxSelectBox('instance');
    }
    catch (e) {
        console.log(e);
    }
}

//Phần script kiểm tra click tìm kiếm nâng cao
async function ShowTimKiemNangCao() {
    var flag = $("#checkShow").val();
    if (flag == 0) {
        $("#tableTraCuu").show();
        $("#checkShow").val(1);
    }
    else if (flag == 1) {
        $("#tableTraCuu").hide();
        $("#checkShow").val(0);
    }
}

//==============Script load Datepicker============
var tungay = new Date();
var txtNgayCapTu = $("#ngaycaptu").dxDateBox({
    width: "65%",
    type: "date",
    pickerType: "calendar",
    displayFormat: 'dd/MM/yyyy',
    value: tungay

}).dxDateBox("instance");

var denngay = new Date();
var txtNgayCapDenNgay = $("#ngaycapdenngay").dxDateBox({
    width: "65%",
    type: "date",
    pickerType: "calendar",
    displayFormat: 'dd/MM/yyyy',
    value: denngay

}).dxDateBox("instance");

var thoihantu = new Date();
var txtThoiHanTu = $("#thoihantu").dxDateBox({
    width: "65%",
    type: "date",
    pickerType: "calendar",
    displayFormat: 'dd/MM/yyyy',
    value: thoihantu

}).dxDateBox("instance");

var handenngay = new Date();
var txtHanDenNgay = $("#handenngay").dxDateBox({
    width: "65%",
    type: "date",
    pickerType: "calendar",
    displayFormat: 'dd/MM/yyyy',
    value: handenngay

}).dxDateBox("instance");

var ngaysinh = new Date();
var txtNgaySinh = $("#ngaysinh").dxDateBox({
    width: "65%",
    type: "date",
    pickerType: "calendar",
    displayFormat: 'dd/MM/yyyy',
    value: ngaysinh

}).dxDateBox("instance");

