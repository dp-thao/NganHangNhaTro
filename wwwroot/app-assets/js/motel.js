$(document).ready(function () {

})
// Biến
var btnEditSave = document.getElementById('btn-edit-save');

// Lớp Filter - đối tượng điều kiện lọc
class Filter {
    //constructor(filterType, value, fieldName) {
    //    this.FilterType = filterType;
    //    this.FilterValue = value;
    //    this.FieldName = fieldName;
    //}
}

// Lớp MotelJS
class MotelJS {
    constructor() {
        this.initEvents();
    }
    // Hàm xử lý sự kiện cho các nút
    initEvents() {
        // Sự kiện nhấn nút Sửa
        btnEditSave.onclick = function () {
            motelJS.RedirectToEditMotel();
        };
    }

    // Hàm thao tác với dữ liệu
    RedirectToEditMotel() {



        var xhttp = new XMLHttpRequest(); // Create an XMLHttpRequest object
        // Define a callback function
        xhttp.onload = function () {
            // Here you can use the Data
            // Xử lý dữ liệu nhận được (nếu cần)
            var newContent = xhttp.responseText; // Nội dung của view mới
        }
        // Send a request
        xhttp.open("GET", "Edit.cshtml");
        xhttp.send();
    }

}

var motelJS = new MotelJS();

// Các hàm bổ trợ