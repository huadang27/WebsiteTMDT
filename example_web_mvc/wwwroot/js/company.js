function showModal() {
    $('#myModal').modal('show');
}

var updateId = null;

function showModal(isUpdate, id) {
    updateId = isUpdate ? id : null;
    var title = isUpdate ? 'Cập nhật công ty' : 'Thêm mới một công ty';
    var save = isUpdate ? 'Cập nhật' : 'Thêm mới';
    document.getElementById('myModalLabel').innerHTML = title;
    document.getElementById('save').innerHTML = save;
    $('#myModal').modal('show');
}

function saveCompany() {
    if (updateId) {
        updateCompany(updateId);
    } else {
        createCompany();
    }
}

function updateCompany(id) {
    var CompanyName = document.getElementById("CompanyName");
    var StreetAddress = document.getElementById("StreetAddress");
    var City = document.getElementById("City");
    var State = document.getElementById("State");
    var PostalCode = document.getElementById("PostalCode");
    var PhoneNumber = document.getElementById("PhoneNumber");

    var companyData = {
        Id: id,
        Name: CompanyName.value,
        StreetAddress: StreetAddress.value,
        City: City.value,
        State: State.value,
        PostalCode: PostalCode.value,
        PhoneNumber: PhoneNumber.value
    };

    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            toastr.success("Cập nhật thành công")
            document.getElementById('company-name-' + id).innerHTML = companyData.Name;
            document.getElementById('street-address-' + id).innerHTML = companyData.StreetAddress;
            document.getElementById('city-' + id).innerHTML = companyData.City;
            document.getElementById('state-' + id).innerHTML = companyData.State;
            document.getElementById('postal-code-' + id).innerHTML = companyData.PostalCode;
            document.getElementById('phone-number-' + id).innerHTML = companyData.PhoneNumber;
            document.getElementById("btn-close").click();
        }
    };
    request.open("POST", "/Admin/Company/Upsert", true);
    request.setRequestHeader("Content-type", "application/json");
    request.send(JSON.stringify(companyData));
}

function fetchCompanyData(id, callback) {
    var request = new XMLHttpRequest();
    request.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            try {
                var companyData = JSON.parse(this.responseText);
                callback(null, companyData);
            } catch (err) {
                callback(err);
            }
        }
    };
    request.open("GET", "/Admin/Company/Upsert/" + id, true);
    request.send();
}

function populateModalWithCompanyDetails(id) {
    fetchCompanyData(id, function (err, companyData) {
        if (err) {
            console.log("Cannot fetch company data, opening modal for creating a new company.");
            document.getElementById("CompanyName").value = "";
            document.getElementById("StreetAddress").value = "";
            document.getElementById("City").value = "";
            document.getElementById("State").value = "";
            document.getElementById("PostalCode").value = "";
            document.getElementById("PhoneNumber").value = "";
            showModal(false);
        } else {
            document.getElementById("CompanyName").value = companyData.name;
            document.getElementById("StreetAddress").value = companyData.streetAddress;
            document.getElementById("City").value = companyData.city;
            document.getElementById("State").value = companyData.state;
            document.getElementById("PostalCode").value = companyData.postalCode;
            document.getElementById("PhoneNumber").value = companyData.phoneNumber;
            showModal(true, id);
        }
    });
}

function createCompany() {
    var CompanyName = document.getElementById("CompanyName");
    var StreetAddress = document.getElementById("StreetAddress");
    var City = document.getElementById("City");
    var State = document.getElementById("State");
    var PostalCode = document.getElementById("PostalCode");
    var PhoneNumber = document.getElementById("PhoneNumber");

    var checkName = document.getElementById("checkName");
    var checkAddress = document.getElementById("checkAddress");
    // ... Add other check elements for validation

    if (CompanyName.value == "") {
        checkName.innerHTML = "Vui lòng nhập tên công ty!";
        CompanyName.focus();
        return;
    } else {
        checkName.innerHTML = "";
    }

    if (StreetAddress.value == "") {
        checkAddress.innerHTML = "Vui lòng nhập địa chỉ công ty!";
        StreetAddress.focus();
        return;
    } else {
        checkAddress.innerHTML = "";
    }

    // ... Add other validation checks

    var companyData = {
        Name: CompanyName.value,
        StreetAddress: StreetAddress.value,
        City: City.value,
        State: State.value,
        PostalCode: PostalCode.value,
        PhoneNumber: PhoneNumber.value
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
            document.getElementById("btn-close").click();

            addRowToTable(res.id, res.name, res.streetAddress, res.city, res.state, res.postalCode, res.phoneNumber);
        }
    };
    request.open("POST", "/Admin/Company/Upsert", true);
    request.setRequestHeader("Content-type", "application/json");
    request.send(JSON.stringify(companyData));
}

function deleteCompany(id) {
    Swal.fire({
        title: 'Bạn có chắc không?',
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
            xhr.open("DELETE", `/Admin/Company/Delete/${id}`);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.onload = function () {
                if (this.readyState == 4 && this.status == 200) {
                    toastr.success("Xoá công ty thành công")
                    document.getElementById('tblCompant').deleteRow(document.getElementById('hihi-'+id).rowIndex);
                } else {
                    toastr.error("Có lỗi khi xóa. Mã lỗi: " + xhr.status);
                }
            }
            xhr.send();
        }
    });
}
function addRowToTable(id, name, streetAddress, city, state, postalCode, phoneNumber) {
    var table = document.getElementById("tblCompant");
    var row = table.insertRow();
    row.id = 'hihi-' + id;

    var cell1 = row.insertCell(0);
    cell1.innerHTML = table.rows.length - 1;

    var cell2 = row.insertCell(1);
    cell2.innerHTML = name;
    cell2.id = 'company-name-' + id;

    var cell3 = row.insertCell(2);
    cell3.innerHTML = streetAddress;
    cell3.id = 'street-address-' + id;

    var cell4 = row.insertCell(3);
    cell4.innerHTML = city;
    cell4.id = 'city-' + id;

    var cell5 = row.insertCell(4);
    cell5.innerHTML = state;
    cell5.id = 'state-' + id;

    var cell6 = row.insertCell(5);
    cell6.innerHTML = postalCode;
    cell6.id = 'postal-code-' + id;

    var cell7 = row.insertCell(6);
    cell7.innerHTML = phoneNumber;
    cell7.id = 'phone-number-' + id;

    var cell8 = row.insertCell(7);
    cell8.className = 'table-action';
    cell8.innerHTML = '<a href="#" onclick="populateModalWithCompanyDetails(' + id + ')"><i class="fal fa-pen" style="color: #000000; margin-right: 25px;"></i></a><a onclick="deleteCompany(' + id + ')"><i class="fal fa-trash" style="color: #000000;"></i></a>';
}

function resetText() {
    document.getElementById("CompanyName").value = "";
    document.getElementById("StreetAddress").value = "";
    document.getElementById("City").value = "";
    document.getElementById("State").value = "";
    document.getElementById("PostalCode").value = "";
    document.getElementById("PhoneNumber").value = "";
    // ... Reset other input fields and validation messages
}
