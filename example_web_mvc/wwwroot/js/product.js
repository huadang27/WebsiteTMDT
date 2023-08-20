var dataTable;
$(document).ready(function () {
    loadDataTable();
});

//function loadDataTable() {
//    dataTable = $('#tblData').DataTable({
//        "ajax": {
//            "url": '/admin/product/getall'
//        },
//        "columns": [
//            { data: 'title', "width": "25%" },
//            { data: 'isbn', "width": "15%" },
//            { data: 'listPrice', "width": "10%" },
//            { data: 'author', "width": "15%" },
//            { data: 'category.name', "width": "15%" },
//            {
//                data: 'id',
//                "render": function (data) {
//                    return `<div class="w-75 btn-group" role="group">
//                    <a href ="/admin/product/upsert?id=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Edit </a>
//                    <a onClick=Delete('/admin/product/delete/${data}') class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i> Delete </a>
//                    </div>`
//                }, "width": "25%"

//            }
//        ]
//    });
//}
function loadDataTable() {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', '/admin/product/getall', true);
    xhr.onload = function () {
        if (this.status == 200) {
            //var data = JSON.parse(this.responseText);
            var data = JSON.parse(this.responseText).data;

            var tableBody = document.getElementById('tblData').getElementsByTagName('tbody')[0];
            tableBody.innerHTML = ''; // Clear current table body

            // Insert new rows
            data.forEach(function (item) {
                var newRow = tableBody.insertRow();

                var cell = newRow.insertCell();
                cell.style.width = '15%';
                cell.textContent = item.title;

                cell = newRow.insertCell();
                cell.style.width = '15%';
                cell.textContent = item.isbn;

                cell = newRow.insertCell();
                cell.style.width = '10%';
                cell.textContent = item.listPrice;

                cell = newRow.insertCell();
                cell.style.width = '15%';
                cell.textContent = item.author;

                cell = newRow.insertCell();
                cell.style.width = '15%';
                cell.textContent = item.category.name;

                //số lượng 
                cell = newRow.insertCell();
                cell.style.width = '5%';
                cell.textContent = item.quantity;
                //đã bán 
                cell = newRow.insertCell();
                cell.style.width = '5%';
                cell.textContent = item.TotalCount;

                cell = newRow.insertCell();
                cell.style.width = '25%';
                cell.innerHTML = `<div class="w-75 btn-group" role="group">
                    <a href ="/admin/product/upsert?id=${item.id}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i> Edit </a>
                    <a onClick=Delete('/admin/product/delete/${item.id}') class="btn btn-danger mx-2"><i class="bi bi-trash-fill"></i> Delete </a>
                    </div>`;
            });
        }
    };
    xhr.send();
}


function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message)
                }
            })
        }
    })
}