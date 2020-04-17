
function updateCartProducts() {
    var cartProducts;
    var existingCookieData = $.cookie('CartProducts');

    if (existingCookieData != undefined && existingCookieData != "" && existingCookieData != null) {
        cartProducts = existingCookieData.split('-');
    }
    else {
        cartProducts = [];
    }

    document.getElementById('cartProductsCount').innerHTML = "<a href='/Home/ShoppingCart'>購物車(" + cartProducts.length + ")</a>";
};

updateCartProducts();