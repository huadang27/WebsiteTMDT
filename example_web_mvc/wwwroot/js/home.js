document.addEventListener('DOMContentLoaded', (event) => {
    fetch('https://localhost:7139/Customer/Home/GetProductInCategory?CategoryName=All')
        .then(response => {
            if (!response.ok) {
                throw new Error("HTTP error " + response.status);
            }
            return response.json();
        })
        .then(data => {
            renderData(data);
            console.log(data);
        })
        .catch(function (error) {
            console.log(error);
        });
});

window.addEventListener('load', function () {
    const links = document.querySelectorAll('.nav-link');

    links.forEach(function (link) {
        link.addEventListener('click', function (event) {
            var categoryName = event.target.getAttribute('data-category');
            // Các bạn có thể sử dụng categoryName tại đây.
            console.log(categoryName);
            let requestUrl;
            if (categoryName == null) {
                requestUrl = 'https://localhost:7139/Customer/Home/GetProductInCategory?CategoryName=All'

            }
            else {
                requestUrl = 'https://localhost:7139/Customer/Home/GetProductInCategory?CategoryName=' + categoryName;
            }
            


            fetch(requestUrl)
                .then(function (response) {
                    console.log('Response status:', response.status); // Kiểm tra trạng thái phản hồi
                    console.log('Response:', response); // Kiểm tra phản hồi thô
                    if (!response.ok) {
                        throw new Error('HTTP error ' + response.status);
                    }
                    return response.json();
                })
                .then(function (data) {
                    console.log('Data:', data);
                    renderData(data);
                })
                .catch(function (error) {
                    console.log(error);
                });
        });
    });
});

// Hàm kiểm tra và xử lý tên sản phẩm
function formatProductName(name) {
    const maxLength = 30;
    if (name.length > maxLength) {
        return name.substring(0, maxLength) + '...';
    }
    return name;
}
function renderData(data)  {
   
    // Biến dùng để lưu HTML
    let htmlContent = '';

    data.forEach(function (product) {
        let productName = formatProductName(product.title);
        let productHtml = `
               <div class="col-xl-2 col-lg-3 col-md-4 col-sm-6 ">
                <div class="properties pb-30">
                    <div class="properties-card">
                        <div class="properties-img">
                            <a href="https://localhost:7139/Customer/Home/Details/?productId=${product.id}">
                               <img src="${product.productImages && product.productImages.length > 0 ? product.productImages[0].imageUrl : 'default_image.jpg'}" alt="" style="width: 198px;height: 295px;object-fit: cover;" />
                            </a>
                        </div>
                        <div class="properties-caption properties-caption2">
                            <h3 style="    min-height: 135px;
    overflow: hidden;"><a href="https://localhost:7139/Customer/Home/Details/?productId=${product.id}" style="a:hover{coler:#ff1616}">${productName}</a></h3>
                            <p>${product.author}</p>
                            <div class="properties-footer d-flex justify-content-between align-items-center">
                               <i class="far fa-cart-plus"></i>
                                <div class="price">
                                    <span>${product.price100}</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
         </div>
        `;
        // Thêm vào htmlContent
        htmlContent += productHtml;
    });

    // Thêm htmlContent vào div mong muốn
    $('#productContainer').html(htmlContent);
    // Gọi hàm này sau khi các phần tử đã được thêm vào trang
 
}



//document.addEventListener('DOMContentLoaded', (event) => {
//    fetch('/Customer/Home/GetProductInCategory')
//        .then(response => {
//            if (!response.ok) {
//                throw new Error("HTTP error " + response.status);
//            }
//            return response.json();
//        })
//        .then(data => {
//            renderData(data);
//            console.log(data);
//        })
//        .catch(function (error) {
//            console.log(error);
//        });
//});

//function renderData(data) {
//    // Biến dùng để lưu HTML
//    let htmlContent = '';
//    data.forEach(function (product) {
//        let productHtml = `
        
//               <div class="col-xl-2 col-lg-3 col-md-4 col-sm-6">
//                <div class="properties pb-30">
//                    <div class="properties-card">
//                        <div class="properties-img">
//                            <a href="book-details.html">
//                               <img src="${product.productImages && product.productImages.length > 0 ? product.productImages[0].imageUrl : 'default_image.jpg'}" alt="" style="width: 198px;height: 295px;object-fit: cover;" />
//                            </a>
//                        </div>
//                        <div class="properties-caption properties-caption2">
//                            <h3><a href="book-details.html">${product.title}</a></h3>
//                            <p>${product.author}</p>
//                            <div class="properties-footer d-flex justify-content-between align-items-center">
//                                <div class="review">
//                                    <div class="rating">
//                                        <i class="fas fa-star"></i>
//                                        <i class="fas fa-star"></i>
//                                        <i class="fas fa-star"></i>
//                                        <i class="fas fa-star"></i>
//                                        <i class="fas fa-star-half-alt"></i>
//                                    </div>
//                                    <p>(<span>120</span> Review)</p>
//                                </div>
//                                <div class="price">
//                                    <span>${product.price100}</span>
//                                </div>
//                            </div>
//                        </div>
//                    </div>
//                </div>
//         </div>
//        `;
//        // Thêm vào htmlContent
//        htmlContent += productHtml;
//        document.getElementById("productContainer").innerHTML = htmlContent;
//    });


//    // Thêm htmlContent vào div mong muốn
//    $('#productContainer').html(htmlContent);
//}


//function renderData(data) {
//    var html = "";
//    for (var i = 0; i < data.length; i++) {
//        var product = data[i];

//        html += `<div class="col-xl-2 col-lg-3 col-md-4 col-sm-6">
//            <div class="properties pb-30">
//                <div class="properties-card">
//                    <div class="properties-img">
//                        <a href="book-details.html">
//                           <img src="` + (product.productImages && product.productImages.length > 0 ? product.productImages[0].imageUrl : 'default_image.jpg') + `" alt="" style="width: 198px;
//    height: 295px;
//    object-fit: cover;" />
//                        </a>
//                    </div>
//                    <div class="properties-caption properties-caption2">
//                        <h3><a href="book-details.html">` + product.title + `</a></h3>
//                        <p>` + product.author + `</p>
//                        <div class="properties-footer d-flex justify-content-between align-items-center">
//                            <div class="review">
//                                <div class="rating">
//                                    <i class="fas fa-star"></i>
//                                    <i class="fas fa-star"></i>
//                                    <i class="fas fa-star"></i>
//                                    <i class="fas fa-star"></i>
//                                    <i class="fas fa-star-half-alt"></i>
//                                </div>
//                                <p>(<span>120</span> Review)</p>
//                            </div>
//                            <div class="price">
//                                <span>` + product.price100 + `</span>
//                            </div>
//                        </div>
//                    </div>
//                </div>
//            </div>
//        </div>`;
//    }
//    document.getElementById("productContainer").innerHTML = html;
//}





//$(document).ready(function () {
//    var page = 2;

//    $('#loadMore').click(function () {
//        $.ajax({
//            url: '/Customer/Home/Index',
//            data: { page: page },
//            type: 'GET',
//            headers: { "X-Requested-With": "XMLHttpRequest" },
//            success: function (data) {
//                $('#additionalProducts').append(data);
//                page++;
//                if (page > '@Model.PageCount') {
//                    $('#loadMore').hide();
//                }
              
//            }
//        });
//    });
//});
