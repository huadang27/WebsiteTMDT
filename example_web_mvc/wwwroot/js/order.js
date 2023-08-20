$(document).ready(function () {
    var url = window.location.search;
    //check dữ liệu 
    if ($.fn.DataTable.isDataTable('#tblData')) {
        $('#tblData').DataTable().destroy();
    }

    if (url.includes("inventory")) {
        loadInventoryDataTable();
    }
    else if (url.includes("inprocess")) {
        loadDataTable("inprocess");
    }
    else if (url.includes("completed")) {
        loadDataTable("completed");
    }
    else if (url.includes("pending")) {
        loadDataTable("pending");
    }
    else if (url.includes("approved")) {
        loadDataTable("approved");
    }
    else {
        loadDataTable("all");
    }
});

function loadInventoryDataTable() {
    if ($.fn.DataTable.isDataTable('#tblData')) {
        $('#tblData').DataTable().destroy();
    }
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": '/admin/product/GetProductsBySeller'
        },
        "columns": [
            { data: 'id', "width": "25%" },
            { data: 'title', "width": "15%" },
            { data: 'quantity', "width": "10%" },
            { data: 'listPrice', "width": "10%" },
            { data: 'author', "width": "15%" },
            {
                data: 'quantity',
                "width": "15%",
                "render": function (data) {
                    return data < 20 ? '<span style="color:red;">Sắp hết</span>' : 'Đủ hàng';
                }
            },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href ="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Edit </a>
                    </div>`
                }, "width": "25%"
            }
        ]
    });
}

function loadDataTable(status) {
    if ($.fn.DataTable.isDataTable('#tblData')) {
        $('#tblData').DataTable().destroy();
    }
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": '/admin/order/getall?status=' + status
        },
        "columns": [
            { data: 'id', "width": "5%" },
            { data: 'name', "width": "25%" },
            { data: 'phoneNumber', "width": "20%" },
            { data: 'email', "width": "20%" },
            { data: 'orderStatus', "width": "10%" },
            { data: 'orderTotal', "width": "10%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    
                    </div>`
                }, "width": "25%"
            }
        ]
    });
}

            //<a href ="/admin/order/details?orderId=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i>  </a>