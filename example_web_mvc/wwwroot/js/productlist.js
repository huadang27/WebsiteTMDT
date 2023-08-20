var products = [];
var currentPage = 0;
var itemsPerPage = 8;
function showPage(pageNumber) {
    var start = pageNumber * itemsPerPage;
    var end = start + itemsPerPage;
    var pageProducts = products.slice(start, end);

    var productsElement = $('#products');
    productsElement.empty();

    var rowElement = $('<div class="row pb-3">');
    productsElement.append(rowElement);

    for (var i = 0; i < pageProducts.length; i++) {
        var product = pageProducts[i];
        var imageUrl = product.imageUrls && product.imageUrls.length > 0 ? product.imageUrls[0].replace(/\\/g, '/') : "https://placehold.co/200x300/png";

        var productElement = `
            <div class="col-lg-3 col-sm-6">
                <div class="p-2">
                    <div class="card border-0 p-3 shadow border-top border-5 rounded">
                        <img src="${imageUrl}" alt="${product.title}" class="card-img-top rounded" width="300" height="200" />
                        <div class="card-body pb-0">
                            <p class="card-title h5 text-dark opacity-75 text-uppercase text-center product-title">${product.title}</p>
                            <p class="card-title text-warning text-center">by ${product.author}</p>
                        </div>
                        <div class="pl-1">
                            <p class="text-dark text-opacity-75 text-center mb-0">
                                List Price:
                                <span class="text-decoration-line-through">${product.listPrice}  <i class="far fa-usd-circle"></i></span>
                            </p>
                        </div>
                        <div class="pl-1">
                            <p class="text-dark text-opacity-75 text-center">
                                 As low as
                                <span class="">${product.price100} <i class="far fa-usd-circle"></i></span>
                            </p>
                        </div>
                        <div>
                            <a href="/Customer/Home/Details?productId=1" asp-action="Details" asp-route-productId="${product.id}" class="btn btn-primary bg-gradient border-0 form-control">
                                Detail
                            </a>
                        </div>
                    </div>
                </div>
            </div>`;
        rowElement.append(productElement);

        // After adding 4 products, create a new row
        if ((i + 1) % 4 === 0) {
            rowElement = $('<div class="row pb-3">');
            productsElement.append(rowElement);
        }
    }

    $('#prev-page').toggleClass('disabled', pageNumber === 0);
    var lastPage = Math.ceil(products.length / itemsPerPage) - 1;
    $('#next-page').toggleClass('disabled', pageNumber === lastPage);
}

$(document).ready(function () {
    $.get('/Customer/Home/GetProducts', function (data) {
        products = data;
        console.log(data);
        showPage(0);
    });

    $('#prev-page').click(function () {
        if (currentPage > 0) {
            currentPage--;
            showPage(currentPage);
        }
    });

    $('#next-page').click(function () {
        var lastPage = Math.ceil(products.length / itemsPerPage) - 1;
        if (currentPage < lastPage) {
            currentPage++;
            showPage(currentPage);
        }
    });
});
