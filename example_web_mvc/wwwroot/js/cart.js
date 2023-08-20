//document.addEventListener('DOMContentLoaded', (event) => {
//    fetchDataAndRender();

//    document.addEventListener('click', function (event) {
//        if (event.target.closest('.input-number-increment')) {
//            event.preventDefault();
//            const id = event.target.closest('.input-number-increment').getAttribute('data-id');
//            updateCount(id, 'Plus');
//        }
//        if (event.target.closest('.input-number-decrement')) {
//            event.preventDefault();
//            const id = event.target.closest('.input-number-decrement').getAttribute('data-id');
//            updateCount(id, 'Minus');
//        }

//        if (event.target.closest('.remove-item')) {
//            event.preventDefault();
//            const id = event.target.closest('.remove-item').getAttribute('data-id');
//            removeItem(id);
//        }



//    });

//    function fetchDataAndRender() {
//        fetch('https://localhost:7139/Customer/Cart/GetCartUser')
//            .then(response => {
//                if (!response.ok) {
//                    throw new Error("HTTP error " + response.status);
//                }
//                return response.json();
//            })
//            .then(data => {
//                renderData(data);
//            })
//            .catch(function (error) {
//                console.log(error);
//            });
//    }

//    function renderData(data) {
//        var tbody = document.querySelector('tbody');
//        tbody.innerHTML = '';

//        data.shoppingCart.forEach(item => {
//            var tr = document.createElement('tr');
//            tr.id = `row-${item.id}`; // Add this line
//            var productImage = item.productImages && item.productImages.length > 0
//                ? item.productImages[0].imageUrl
//                : 'https://placehold.co/500x600/png';

//            var money = item.price * item.count;

//            tr.innerHTML = `
//                <td>
//                    <div class="media">
//                        <div class="d-flex">
//                            <img src="${productImage}" class="card-img-top rounded w-100" alt="${item.productTitle}" />
//                        </div>
//                        <div class="media-body">
//                            <p>${item.productTitle}</p>
//                        </div>
//                    </div>
//                </td>
//                <td>
//                    <h5 id="price-${item.id}">${item.price}</h5>
//                </td>
//                <td>
//                    <div class="product_count">
//                        <a href="#" data-id="${item.id}" class="input-number-decrement" style="color :black ">
//                            <i class="far fa-minus"></i>
//                        </a>
//                        <input class="" id="count-${item.id}"
//                            type="text"
//                            value="${item.count}"
//                            min="0"
//                            max="10" />
//                        <a href="#" data-id="${item.id}" class="input-number-increment" style="color :black ">
//                            <i class="far fa-plus"></i>
//                        </a>
//                    </div>
//                    <a href="#" data-id="${item.id}" class="remove-item" style="color :black ">
//                            <i class="far fa-plus"></i>
//                </td>
//                <td>
//                    <h5 id="money-${item.id}">${money}</h5>
//                </td>
//            `;

//            tbody.appendChild(tr);
//        });

//        var trTotal = document.createElement('tr');
//        trTotal.innerHTML = `
//            <td></td>
//            <td></td>
//            <td>
//                <h5>Tổng tiền</h5>
//            </td>
//            <td>
//                <h5 id="totalPrice">${data.orderHeader.orderTotal}</h5>
//            </td>
//        `;
//        tbody.appendChild(trTotal);
//    }

//    function updateCount(id, action) {
//        fetch(`/Customer/Cart/${action}?cartId=${id}`, {
//            method: 'POST',
//            headers: {
//                'Accept': 'application/json',
//                'Content-Type': 'application/json'
//            },
//        })
//            .then(response => response.json())
//            .then(data => {
//                if (data.success) {
//                    document.querySelector(`#count-${id}`).value = data.itemCount;

//                    // Calculate new cost for this item
//                    var priceElement = document.querySelector(`#price-${id}`);
//                    var moneyElement = document.querySelector(`#money-${id}`);
//                    var totalPriceElement = document.querySelector('#totalPrice');
//                    var oldMoney = parseFloat(moneyElement.textContent);
//                    var oldTotalPrice = parseFloat(totalPriceElement.textContent);
//                    var newMoney = data.itemCount * parseFloat(priceElement.textContent);

//                    moneyElement.textContent = newMoney.toFixed(2);
//                    totalPriceElement.textContent = (oldTotalPrice - oldMoney + newMoney).toFixed(2);

//                    if (action === 'Minus' && data.itemCount === 0) {
//                        document.querySelector(`#row-${id}`).remove();
//                    }
//                }
//            });
//    }
//});
//function removeItem(id) {
//    fetch(`/Customer/Cart/Remove?cartId=${id}`, {
//        method: 'POST',
//        headers: {
//            'Accept': 'application/json',
//            'Content-Type': 'application/json'
//        },
//    })
//        .then(response => response.json())
//        .then(data => {
//            if (data.success) {
//                document.querySelector(`#row-${id}`).remove();

//                // Update total price
//                var totalPriceElement = document.querySelector('#totalPrice');
//                var oldTotalPrice = parseFloat(totalPriceElement.textContent);
//                var priceElement = document.querySelector(`#price-${id}`);
//                var countElement = document.querySelector(`#count-${id}`);
//                var removedMoney = parseFloat(priceElement.textContent) * parseFloat(countElement.value);

//                totalPriceElement.textContent = (oldTotalPrice - removedMoney).toFixed(2);
//            }
//        });
//}



document.addEventListener('DOMContentLoaded', (event) => {
    fetchDataAndRender();

    document.addEventListener('click', function (event) {
        if (event.target.closest('.input-number-increment')) {
            event.preventDefault();
            const id = event.target.closest('.input-number-increment').getAttribute('data-id');
            updateCount(id, 'Plus');
        }
        if (event.target.closest('.input-number-decrement')) {
            event.preventDefault();
            const id = event.target.closest('.input-number-decrement').getAttribute('data-id');
            updateCount(id, 'Minus');
        }

        if (event.target.closest('.remove-item')) {
            event.preventDefault();
            const id = event.target.closest('.remove-item').getAttribute('data-id');
            removeItem(id);
        }
    });

    function fetchDataAndRender() {
        fetch('https://localhost:7139/Customer/Cart/GetCartUser')
            .then(response => {
                if (!response.ok) {
                    throw new Error("HTTP error " + response.status);
                }
                return response.json();
            })
            .then(data => {
                renderData(data);
            })
            .catch(function (error) {
                console.log(error);
            });
    }

    function renderData(data) {
        var tbody = document.querySelector('tbody');
        tbody.innerHTML = '';

        data.shoppingCart.forEach(item => {
            var tr = document.createElement('tr');
            tr.id = `row-${item.id}`; // Add this line
            var productImage = item.productImages && item.productImages.length > 0
                ? item.productImages[0].imageUrl
                : 'https://placehold.co/500x600/png';

            var money = item.price * item.count;

            tr.innerHTML = `
                <td>
                    <div class="media">
                        <div class="d-flex">
                            <img src="${productImage}" class="card-img-top rounded w-100" alt="${item.productTitle}" />
                        </div>
                        <div class="media-body">
                            <p>${item.productTitle}</p>
                        </div>
                    </div>
                </td>
                <td>
                    <h5 id="price-${item.id}">${item.price}</h5>
                </td>
                <td>
                    <div class="product_count">
                        <a href="#" data-id="${item.id}" class="input-number-decrement" style="color :black ">
                            <i class="far fa-minus"></i>
                        </a>
                        <input class="" id="count-${item.id}"
                            type="text"
                            value="${item.count}"
                            min="0"
                            max="10" />
                        <a href="#" data-id="${item.id}" class="input-number-increment" style="color :black ">
                            <i class="far fa-plus"></i>
                        </a>
                         <input href="#"id="quantity-${item.id}" value="${item.quantityProduct}" class="input-number-increment" style="color :black " hidden>
                           
                        </input>
                    </div>
                   
                </td>
                <td>
                    <h5 id="money-${item.id}">${money}</h5>
                </td>
                <td>
                 <a href="#" data-id="${item.id}" class="remove-item" style="color :black  ">
                            <i class="far fa-trash"></i>
                        </a>
                </td>
            `;

            tbody.appendChild(tr);
        });

        var trTotal = document.createElement('tr');
        trTotal.innerHTML = `
            <td></td>
            <td></td>
            <td>
                <h5>Tổng tiền</h5>
            </td>
            <td>
                <h5 id="totalPrice">${data.orderHeader.orderTotal}</h5>
            </td>
        `;
        tbody.appendChild(trTotal);
    }

    function updateCount(id, action) {
        fetch(`/Customer/Cart/${action}?cartId=${id}`, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    document.querySelector(`#count-${id}`).value = data.itemCount;

                    var currentCount = document.querySelector(`#count-${id}`).value;
                    var quantityProduct = document.querySelector(`#quantity-${id}`).value; // assuming you have the quantity in a hidden field

                    // Check if trying to increment and it's not exceeding the stock
                    if (action === 'Plus' && parseInt(currentCount) + 1 > parseInt(quantityProduct)) {
                        alert('Hàng hết');
                        return;
                    }

                    document.querySelector(`#count-${id}`).value = data.itemCount;


                    // Calculate new cost for this item
                    var priceElement = document.querySelector(`#price-${id}`);
                    var moneyElement = document.querySelector(`#money-${id}`);
                    var totalPriceElement = document.querySelector('#totalPrice');
                    var oldMoney = parseFloat(moneyElement.textContent);
                    var oldTotalPrice = parseFloat(totalPriceElement.textContent);
                    var newMoney = data.itemCount * parseFloat(priceElement.textContent);

                    moneyElement.textContent = newMoney.toFixed(2);
                    totalPriceElement.textContent = (oldTotalPrice - oldMoney + newMoney).toFixed(2);

                    if (action === 'Minus' && data.itemCount === 0) {
                        document.querySelector(`#row-${id}`).remove();
                    }

                }
            });
    }

    function removeItem(id) {
        fetch(`/Customer/Cart/Remove?cartId=${id}`, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    // Update total price
                    var priceElement = document.querySelector(`#price-${id}`);
                    var countElement = document.querySelector(`#count-${id}`);
                    var removedMoney = parseFloat(priceElement.textContent) * parseFloat(countElement.value);

                    document.querySelector(`#row-${id}`).remove();

                    var totalPriceElement = document.querySelector('#totalPrice');
                    var oldTotalPrice = parseFloat(totalPriceElement.textContent);
                    totalPriceElement.textContent = (oldTotalPrice - removedMoney).toFixed(2);
                }
            });
    }
});
