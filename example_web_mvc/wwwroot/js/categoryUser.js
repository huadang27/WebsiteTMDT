let productCount = 0;

document.addEventListener('DOMContentLoaded', (event) => {
    loadProducts();
});

//function loadProducts() {
//    fetch(`https://localhost:7139/Customer/Category/GetCategoryProduct?startAt=${productCount}`)
//        .then(response => response.json())
//        .then(data => {
//            renderData(data);
//            console.log(data);
//            productCount += data.length;
//        })
//    // add error handling here if desired
//}

// tìm kiếm theo Categoryname
let selectedCategories = [];
let isRefreshing = false;
$('input[type=checkbox]').on('change', function () {
    let categoryName = $(this).val();
    if ($(this).is(':checked')) {
        selectedCategories.push(categoryName);
    } else {
        let index = selectedCategories.indexOf(categoryName);
        if (index !== -1) selectedCategories.splice(index, 1);
    }
    productCount = 0;  // Reset productCount
    isRefreshing = true;
    console.log("CategoryName: " + selectedCategories)
    loadProducts();
});

// tìm kiếm theo Tác giả
let selectedAuthors = [];

// tìm kiếm theo Tác giả
$('.author-checkbox').on('change', function () {
    let author = $(this).val();
    if ($(this).is(':checked')) {
        selectedAuthors.push(author);
    } else {
        let index = selectedAuthors.indexOf(author);
        if (index !== -1) selectedAuthors.splice(index, 1);
    }
    productCount = 0;  // Reset productCount
    isRefreshing = true;
    console.log("Authors: " + selectedAuthors);
    loadProducts();
});

let orderBy = "";

$('#product_short_list').on('change', function () {
    orderBy = $(this).val();
    productCount = 0;  // Reset productCount
    isRefreshing = true;
    console.log(orderBy);
    loadProducts();
});


function loadProducts() {
    fetch(`https://localhost:7139/Customer/Category/GetCategoryProduct?startAt=${productCount}&categoryNames=${selectedCategories.join(',')}&authors=${selectedAuthors.join(',')}&orderBy=${orderBy}`)
        .then(response => response.json())
        .then(data => {
            renderData(data);
            console.log(data);
            productCount += data.length;
        })
    // add error handling here if desired
}

document.querySelector('.more-btn2').addEventListener('click', function (event) {
    event.preventDefault();
    loadProducts();
});


function renderData(data) {
    let htmlContent = '';

    data.forEach(function (product) {
        let productImageUrl = product.imageUrls && product.imageUrls.length > 0 ? product.imageUrls[0] : "/images/default-product-image.png";
        let productHtml = `
            <div class="col-xxl-3 col-xl-4 col-lg-4 col-md-12 col-sm-6">
                <div class="properties pb-30">
                    <div class="properties-card">
                        <div class="properties-img">
                            <a href="/Customer/Home/Details/?productId=${product.id}">
                                <img src="${productImageUrl}" alt="${product.title}" />
                            </a>
                        </div>
                        <div class="properties-caption properties-caption2">
                            <h3 style="min-height: 135px;overflow: hidden;">
                                <a href="/Customer/Home/Details/?productId=${product.id}">${product.title}</a>
                            </h3>
                            <p>${product.author}</p>
                            <div class="properties-footer d-flex justify-content-between align-items-center">
                                <div class="review">
                                    <div class="rating">
                                        <i class="fas fa-star"></i>
                                        <i class="fas fa-star"></i>
                                        <i class="fas fa-star"></i>
                                        <i class="fas fa-star"></i>
                                        <i class="fas fa-star-half-alt"></i>
                                    </div>
                                    <p>(<span>120</span> Review)</p>
                                </div>
                                <div class="price">
                                    <span>${product.price100}</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        `;
        htmlContent += productHtml;
    });

    if (isRefreshing) {
        $('#productContainer').html(htmlContent);  // Thay thế toàn bộ nội dung hiện tại bằng htmlContent mới
        isRefreshing = false;  // Reset isRefreshing
    } else {
        $('#productContainer').append(htmlContent);  // Thêm nội dung mới vào cuối #productContainer
    }
}
    




function searchProduct() {
    // Lấy dữ liệu từ thẻ input
    var searchValue = document.getElementById("searchInput").value;

    console.log(searchValue);
    // Hiển thị kết quả tìm kiếm trong phần tử div có id "result"
   
}


function searchProduct() {
    // Lấy dữ liệu từ thuộc tính data-id của thẻ input
    var searchValue = document.querySelector('[data-id="productInput"]').value;

    // Hiển thị kết quả tìm kiếm trong phần tử div có id "result"
    document.getElementById("result").innerText = "Bạn đã nhập: " + searchValue;



}



function searchProduct(searchTerm) {
    // Tạo đối tượng XMLHttpRequest
    var searchValue = document.querySelector('[data-id="productInput"]').value;
    var xhr = new XMLHttpRequest();

    // Thiết lập callback để xử lý khi nhận được dữ liệu từ server
    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE) {
            if (xhr.status === 200) {
                var productList = JSON.parse(xhr.responseText);
                isRefreshing = true;
                renderData(productList);
            } else {
                console.log("Có lỗi xảy ra trong quá trình tải dữ liệu.");
            }
        }
    };

    // Tạo request và gửi lên server
    xhr.open("GET", "/Customer/Category/SearchProduct?searchTerm=" + searchValue, true);
    xhr.send();
}
