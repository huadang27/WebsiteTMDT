let productList = [];

// Fetch product data
fetch('/Customer/Home/GetProducts')
    .then(response => response.json())
    .then(data => {
        productList = data;
        console.log(data);
    })
    .catch(error => console.log(error));

// Handle input event
$('#searchInput').on('input', function () {
    const search = $(this).val().toLowerCase();
    const filteredProducts = productList.filter(p =>
        p.storeName.toLowerCase().includes(search) ||
        p.title.toLowerCase().includes(search)
        || p.author.toLowerCase().includes(search)
    );

    console.log(filteredProducts)

    // Build search results HTML
    let searchResultsHtml = '';
    for (let product of filteredProducts) {
        //searchResultsHtml += `<li><a class="dropdown-item" href="#">${product.title} by ${product.author}</a></li>`;
        searchResultsHtml += `<li><a class="dropdown-item" href="/Customer/Home/Details?productId=${product.id}">${product.title}</a></li>`;

    }

    // Insert search results into dropdown
    $('#searchResults').html(searchResultsHtml);

    // Show/hide the dropdown based on search results
    if (search && filteredProducts.length > 0) {
        $('#searchResults').addClass('show');
    } else {
        $('#searchResults').removeClass('show');
    }
});

// Handle click event on search results
//$(document).on('click', '.dropdown-item', function (e) {
//    e.preventDefault();
//    const selectedText = $(this).text();
//    $('#searchInput').val(selectedText);
//    $('#searchResults').removeClass('show');
//});
// Handle click event on search results
$(document).on('click', '.dropdown-item', function (e) {
    e.preventDefault();
    const selectedText = $(this).text();
    $('#searchInput').val(selectedText);
    $('#searchResults').removeClass('show');

    // Get the href attribute of the clicked item
    const href = $(this).attr('href');

    // Navigate to the product details page
    window.location.href = href;
});
