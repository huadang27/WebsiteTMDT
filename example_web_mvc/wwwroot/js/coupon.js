function showModal() {
    $('#myModal').modal('show');
}


var updateId = null;

function showModal(isUpdate, id) {
    updateId = isUpdate ? id : null;
    var title = isUpdate ? 'Cập nhật mã giảm giá' : 'Thêm mới một mã giảm giá';
    var save = isUpdate ? 'Cập nhật' : 'Thêm mới';
    document.getElementById('myModalLabel').innerHTML = title;
    document.getElementById('save').innerHTML = save;
    $('#myModal').modal('show');
}

function saveIndustry() {
    if (updateId) {
        updateIndustry(updateId);
    } else {
        createIndustry();
    }
}

function updateIndustry(id) {
    console.log("hihi1");
    var Code = document.getElementById("code-" + id).value;
    var Description = document.getElementById("description-" + id).value;
    var DiscountAmount = parseFloat(document.getElementById("discount-amount-" + id).value);
    var MinimumSpend = parseFloat(document.getElementById("minimum-spend-" + id).value);
    var StartDate = document.getElementById("start-date-" + id).value;
    var EndDate = document.getElementById("end-date-" + id).value;
    var MaxUseTimes = parseInt(document.getElementById("max-use-times-" + id).value);
    var UsedTimes = parseInt(document.getElementById("used-times-" + id).value);
    var ApplyForAllProducts = document.getElementById("apply-for-all-products-" + id).checked;
    var IsActive = document.getElementById("is-active-" + id).checked;

    console.log(StartDate + ", " + EndDate);
    var isoStartDate = convertToIsoDate(StartDate);
    var isoEndDate = convertToIsoDate(EndDate);

    var industryData = {
        Id: id,
        Code: Code,
        Description: Description,
        DiscountAmount: DiscountAmount,
        MinimumSpend: MinimumSpend,
        StartDate: isoStartDate,
        EndDate: isoEndDate,
        MaxUseTimes: MaxUseTimes,
        UsedTimes: UsedTimes,
        ApplyForAllProducts: ApplyForAllProducts,
        IsActive: IsActive
    };
    console.log("Lấy dữ liệu gửi lên server",industryData);

    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            console.log("hihi: " + JSON.stringify(industryData));
            toastr.success("Cập nhật thành công");
            document.getElementById('code-' + id).value = industryData.Code;
            document.getElementById('description-' + id).value = industryData.Description;
            document.getElementById('discount-amount-' + id).value = industryData.DiscountAmount;
            document.getElementById('minimum-spend-' + id).value = industryData.MinimumSpend;
            document.getElementById('start-date-' + id).value = StartDate; // assign the old formatted date string
            document.getElementById('end-date-' + id).value = EndDate; // assign the old formatted date string
            document.getElementById('max-use-times-' + id).value = industryData.MaxUseTimes;
            document.getElementById('used-times-' + id).value = industryData.UsedTimes;
            document.getElementById('apply-for-all-products-' + id).checked = industryData.ApplyForAllProducts;
            document.getElementById('is-active-' + id).checked = industryData.IsActive;
            document.getElementById("btn-close").click();
        }
        else {
            console.log(this.status)
        }
    };

    request.open("POST", "/Admin/Coupon/Upsert", true);
    request.setRequestHeader("Content-type", "application/json");
    request.send(JSON.stringify(industryData));
}


function updateIndustry(id) {
    console.log("hihi1");
    var Code = document.getElementById("code-" + id);
    var Description = document.getElementById("description-" + id);
    var DiscountAmount = document.getElementById("discount-amount-" + id);
    var MinimumSpend = document.getElementById("minimum-spend-" + id);
    var StartDate = document.getElementById("start-date-" + id);
    var EndDate = document.getElementById("end-date-" + id);
    var MaxUseTimes = document.getElementById("max-use-times-" + id);
    var UsedTimes = document.getElementById("used-times-" + id);
    var ApplyForAllProducts = document.getElementById("apply-for-all-products-" + id);
    var IsActive = document.getElementById("is-active-" + id);
    var isoStartDate = convertToIsoDate(StartDate.innerHTML);
    var isoEndDate = convertToIsoDate(EndDate.innerHTML);

    var industryData = {
        Id: id,
        Code: Code.innerHTML,
        Description: Description.innerHTML,
        DiscountAmount: parseFloat(DiscountAmount.innerHTML),
        MinimumSpend: parseFloat(MinimumSpend.innerHTML),
        StartDate: isoStartDate,
        EndDate: isoEndDate,
        MaxUseTimes: parseInt(MaxUseTimes.innerHTML),
        UsedTimes: parseInt(UsedTimes.innerHTML),
        ApplyForAllProducts: ApplyForAllProducts.innerHTML === "true",
        IsActive: IsActive.innerHTML === "true"
    };
    console.log("Lấy dữ liệu gửi lên server",industryData.Code);

    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            console.log("hihi: " + JSON.stringify(industryData));
            toastr.success("Cập nhật thành công");
            Code.innerHTML = industryData.Code;
            Description.innerHTML = industryData.Description;
            DiscountAmount.innerHTML = industryData.DiscountAmount;
            MinimumSpend.innerHTML = industryData.MinimumSpend;
            StartDate.innerHTML = StartDate.innerHTML; // assign the old formatted date string
            EndDate.innerHTML = EndDate.innerHTML; // assign the old formatted date string
            MaxUseTimes.innerHTML = industryData.MaxUseTimes;
            UsedTimes.innerHTML = industryData.UsedTimes;
            ApplyForAllProducts.innerHTML = industryData.ApplyForAllProducts;
            IsActive.innerHTML = industryData.IsActive;
            document.getElementById("btn-close").click();
        }
        else {
            console.log(this.status)
        }
    };

    request.open("POST", "/Admin/Coupon/Upsert", true);
    request.setRequestHeader("Content-type", "application/json");
    request.send(JSON.stringify(industryData));
}

function convertToIsoDate(dateStr) {
    var parts = dateStr.split(/[/ :]/);
    var dt = new Date(parts[2], parts[1] - 1, parts[0], parts[3], parts[4], parts[5]);
    return dt.toISOString();
}



// đổ dữ liệu lên modal khi ấn edit
// hàm lấy dữ liệu
function fetchIndustryData(id, callback) {
    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            try {
                var industryData = JSON.parse(this.responseText);
                console.log("Con ga",industryData);
                callback(null, industryData);
            } catch (err) {
                callback(err);
            }
        }
    };
    request.open("GET", "/Admin/Coupon/Upsert/" + id, true);
    request.send();
}


//hàm đổ dữ liệu
function populateModalWithIndustryDetails(id) {
    fetchIndustryData(id, function (err, industryData) {
        if (err) {
            console.log("Cannot fetch industry data, opening modal for creating a new category.");
            document.getElementById("Code").value = "";
            document.getElementById("Description").value = "";
            document.getElementById("DiscountAmount").value = "";
            document.getElementById("MinimumSpend").value = "";
            document.getElementById("StartDate").value = "";
            document.getElementById("EndDate").value = "";
            document.getElementById("MaxUseTimes").value = "";
            document.getElementById("UsedTimes").value = "";
            document.getElementById("ApplyForAllProducts").value = "";
            document.getElementById("IsActive").value = "";

            showModal(false);
        } else {
            console.log("chay vao day");
            document.getElementById("Code").value = industryData.code;
            document.getElementById("Description").value = industryData.description;
            document.getElementById("DiscountAmount").value = industryData.discountAmount;
            document.getElementById("MinimumSpend").value = industryData.minimumSpend;
            document.getElementById("StartDate").value = industryData.startDate;
            document.getElementById("EndDate").value = industryData.endDate;
            document.getElementById("MaxUseTimes").value = industryData.maxUseTimes;
            document.getElementById("UsedTimes").value = industryData.usedTimes;
            document.getElementById("ApplyForAllProducts").value = industryData.applyForAllProducts;
            document.getElementById("IsActive").value = industryData.isActive;
            showModal(true, id);
        }
    });
}

function createIndustry() {
    var Code = document.getElementById("Code");
    var Description = document.getElementById("Description");
    var DiscountAmount= document.getElementById("DiscountAmount");
    var MinimumSpend= document.getElementById("MinimumSpend");
    var StartDate = document.getElementById("StartDate");
    var EndDate =document.getElementById("EndDate");
    var MaxUseTimes  =document.getElementById("MaxUseTimes");
    var UsedTimes =document.getElementById("UsedTimes");
    var ApplyForAllProducts = document.getElementById("ApplyForAllProducts");
    var IsActive = document.getElementById("IsActive");

 

    var industryData = {
        Code: Code.value,
        Description: Description.value,
        DiscountAmount: parseFloat(DiscountAmount.value),
        MinimumSpend: parseFloat(MinimumSpend.value),
        StartDate: StartDate.value,
        EndDate: EndDate.value,
        MaxUseTimes: parseInt(MaxUseTimes.value),
        UsedTimes: parseInt(UsedTimes.value),
        ApplyForAllProducts: ApplyForAllProducts.value === "true",
        IsActive: IsActive.value=== "true"
    };

    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {

            toastr.success("Thêm thành công")
            var res = JSON.parse(this.responseText);
            if (res.checkName != null) {

                checkName.innerHTML = res.checkName;
                return;
            }

            resetText();
            addRowToTable(res.id, res.code, res.description, res.discountAmount, res.minimumSpend, res.startDate, res.endDate, res.maxUseTimes, res.usedTimes, res.applyForAllProducts, res.isActive);
            document.getElementById("btn-close").click();
        }
    };
    request.open("POST", "/Admin/Coupon/Upsert", true);
    request.setRequestHeader("Content-type", "application/json");
    request.send(JSON.stringify(industryData));
}


function deleteIndustry(id) {
    Swal.fire({
        title: 'Bạn có chắc không??',
        text: "Bạn sẽ không thể hoàn nguyên điều này!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Đồng ý xoá!',
        cancelButtonText: 'Không'
    }).then((result) => {
        if (result.isConfirmed) {
            var xhr = new XMLHttpRequest();
            xhr.open("DELETE", `/Admin/Coupon/Delete/${id}`);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.onload = function () {
                if (this.readyState == 4 && this.status == 200) {
                    toastr.success("Xoá danh mục thành công")
                    document.getElementById('tblCategory').deleteRow(document.getElementById('hihi-' + id).rowIndex);
                } else {
                    toastr.error("Có lỗi khi xóa. Mã lỗi: " + xhr.status);
                }
            };
            xhr.onerror = function () {
                toastr.error("Đã xảy ra lỗi khi xóa bản ghi.");
            };
            xhr.send();
        }
    })
}




function addRowToTable(id, code, description, discountAmount, minimumSpend, startDate, endDate, maxUseTimes, usedTimes, applyForAllProducts, isActive) {
    //console.log("id: ", id + " name: " + name + " display: " + displayorder)
    var table = document.getElementById("tblCategory");
    var row = table.insertRow();
    row.id = 'hihi-' + id;

    var cell1 = row.insertCell(0);
    cell1.innerHTML = table.rows.length - 1;

    var cell2 = row.insertCell(1);
    cell2.innerHTML = code;
    cell2.id = 'code-' + id;  // Thêm id cho cell

    var cell3 = row.insertCell(2);
    cell3.innerHTML = description;
    cell3.id = 'description-' + id; // Thêm id cho cell

    var cell4 = row.insertCell(3);
    cell4.innerHTML = discountAmount;
    cell4.id = 'discount-amount-' + id; // Thêm id cho cell

    var cell5 = row.insertCell(4);
    cell5.innerHTML = minimumSpend;
    cell5.id = 'minimum-spend-' + id; // Thêm id cho cell

    var cell6 = row.insertCell(5);
    cell6.innerHTML = startDate;
    cell6.id = 'start-date-' + id; // Thêm id cho cell

    var cell7 = row.insertCell(6);
    cell7.innerHTML = endDate;
    cell7.id = 'end-date-' + id; // Thêm id cho cell

    var cell8 = row.insertCell(7);
    cell8.innerHTML = maxUseTimes;
    cell8.id = 'max-use-times-' + id; // Thêm id cho cell

    var cell9 = row.insertCell(8);
    cell9.innerHTML = usedTimes;
    cell9.id = 'used-times-' + id; // Thêm id cho cell

    var cel10 = row.insertCell(9);
    cel10.innerHTML = applyForAllProducts;
    cel10.id = 'apply-for-all-products-' + id; //Thêm id cho cell

    var cell1 = row.insertCell(10);
    cell1.innerHTML = isActive;
    cell1.id = 'is-active-' + id; // Thêm id cho cell


    var cell12 = row.insertCell(11);
    cell12.className = "table-action";
    //cell4.innerHTML = `<a href="#"><i class="fal fa-pen" style="color: #000000; margin-right: 25px;"></i></a>
    //    <a onclick="deleteIndustry(` + id + `)"><i class="fal fa-trash" style="color: #000000;"></i></a>`;
    cell12.innerHTML = `<a href="#" onclick="populateModalWithIndustryDetails(` + id + `)"><i class="fal fa-pen" style="color: #000000; margin-right: 25px;"></i></a>
        <a onclick="deleteIndustry(` + id + `)"><i class="fal fa-trash" style="color: #000000;"></i></a>`;
}

function resetText() {
    document.getElementById("Code").value = "";
    document.getElementById("Description").value = "";
    document.getElementById("DiscountAmount").value = "";
    document.getElementById("MinimumSpend").value = "";
    document.getElementById("StartDate").value = "";
    document.getElementById("EndDate").value = "";
    document.getElementById("MaxUseTimes").value = "";
    document.getElementById("UsedTimes").value = "";
    document.getElementById("ApplyForAllProducts").value = "";
    document.getElementById("IsActive").value = "";


}
















//var dataTable;
//$(document).ready(function () {
//    loadDataTable();
//});

//function loadDataTable() {
//    dataTable = $('#tblData').DataTable({
//        "ajax": {
//            "url": '/admin/coupon/getall'
//        },
//        "columns": [
//            { data: 'code', "width": "10%" },
//            { data: 'description', "width": "20%" },
//            { data: 'discountAmount', "width": "10%" },
//            { data: 'minimumSpend', "width": "10%" },
//            { data: 'startDate', "width": "10%" },
//            { data: 'endDate', "width": "10%" },
//            { data: 'maxUseTimes', "width": "10%" },
//            { data: 'usedTimes', "width": "10%" },
//            { data: 'applyForAllProducts', "width": "10%" },
//            { data: 'isActive', "width": "10%" },
//            {
//                data: 'id',
//                "render": function (data) {
//                    return `<div class="w-75 btn-group" role="group">
//                        <a href="/admin/coupon/upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Edit </a>
//                        <a onClick="Delete('/admin/coupon/delete/${data}')" class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i> Delete </a>
//                    </div>`;
//                }, "width": "10%"
//            }
//        ]
//    });
//}

//function Delete(url) {
//    Swal.fire({
//        title: 'Are you sure?',
//        text: "You won't be able to revert this!",
//        icon: 'warning',
//        showCancelButton: true,
//        confirmButtonColor: '#3085d6',
//        cancelButtonColor: '#d33',
//        confirmButtonText: 'Yes, delete it!'
//    }).then((result) => {
//        if (result.isConfirmed) {
//            $.ajax({
//                url: url,
//                type: "DELETE",
//                success: function (data) {
//                    dataTable.ajax.reload();
//                    toastr.success(data.message);
//                }
//            });
//        }
//    });
//}
