var dataTable;
$(document).ready(function () {
  loadDataTable();
});

//function loadDataTable() {
//  dataTable = $("#tblData").DataTable({
//    ajax: {
//      url: "/admin/user/getall",
//    },
//    columns: [
//      { data: "name", width: "15%" },
//      { data: "email", width: "15%" },
//      { data: "phoneNumber", width: "15%" },
//      { data: "company.name", width: "15%" },
//      { data: "role", width: "15%" },
//      {
//        data: { id: "id", lockoutEnd: "lockoutEnd" },
//        render: function (data) {
//          var today = new Date().getTime();
//          var lockout = new Date(data.lockoutEnd).getTime();
//          if (lockout > today) {
//            return `
//                  <div class="text-center">
//                    <a  onclick="LockUnLock('${data.id}')" class="btn btn-success text-white" style="cursor:pointer;width:120px;">

//                          <i class="fad fa-user-lock"></i> Lock
//                        </a>
//                        <a class="btn btn-danger text-white" style="cursor:pointer;width:140px;">
//                            <i class="bi bi-pencil-square"> </i>Permission
//                        </a>
//                  </div>
//                  `;
//          } else {
//            return `
//                  <div class="text-center">
//                    <a onclick="LockUnLock('${data.id}')"
//                    class="btn btn-success text-white" style="cursor:pointer;width:120px;">

//                         <i class="far fa-user-unlock"></i> Unlock

//                        </a>
//                        <a class="btn btn-danger text-white" style="cursor:pointer;width:140px;">
//                            <i class="bi bi-pencil-square"> </i>Permission
//                        </a>
//                  </div>
//                  `;
//          }
//        },
//        width: "25%",
//      },
//    ],
//  });
//}

function loadDataTable() {
    dataTable = $("#tblData").DataTable({
        ajax: {
            url: "/admin/user/getall",
        },
        columns: [
            { data: "name", width: "15%" },
            { data: "email", width: "15%" },
            { data: "phoneNumber", width: "15%" },
            { data: "company.name", width: "15%" },
            { data: "role", width: "15%" },
            {
                data: { id: "id", lockoutEnd: "lockoutEnd" },
                render: function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();
                    var lockText, lockClass;
                    if (lockout > today) {
                        lockText = "Lock";
                        lockClass = "fad fa-user-lock";
                    } else {
                        lockText = "Unlock";
                        lockClass = "far fa-user-unlock";
                    }
                    return `
            <div class="text-center">
              <a onclick="LockUnLock('${data.id}')"
                class="btn btn-success text-white" style="cursor:pointer;width:120px;">
                <i class="${lockClass}"></i> ${lockText}
              </a>
              <a href="/admin/user/RoleManagment?userId=${data.id}" class="btn btn-danger text-white" style="cursor:pointer;width:140px;">
                <i class="bi bi-pencil-square"></i> Permission
              </a>
            </div>
          `;
                },
                width: "25%",
            },
        ],
    });
}

//function LockUnLock(id) {
//  $.ajax({
//    type: "POST",
//    url: "/Admin/User/LockUnLock",
//    data: JSON.stringify(id),
//    contentType: "application/json",
//      success: function (data) {
//          if (data.success) {
//              dataTable.ajax.reload();
//              toastr.success(data.message)
//          }
          
//      }
//});
//}
function LockUnLock(id) {
    $.ajax({
        type: "POST",
        url: "/Admin/User/LockUnLock",
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                dataTable.ajax.reload();
                var lockText, lockClass;
                if (data.message === "Unlock successful") {
                    lockText = "Lock";
                    lockClass = "fad fa-user-lock";
                    toastr.success("Unlock account user successfully");
                } else {
                    lockText = "Unlock";
                    lockClass = "far fa-user-unlock";
                    toastr.success("Lock account user successfully");
                }
                // Update the lockoutEnd, lockText, and lockClass in the DataTable
                var row = dataTable.row($("#tblData").find("[data-id='" + id + "']").closest("tr"));
                row.data().lockoutEnd = new Date().toISOString();
                row.invalidate();
                row.draw();
            } else {
                toastr.error(data.message);
            }
        },
    });
}

