
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

var sessionValue = $("#hdnSession").data('value'); // _Layout

if (sessionValue.length == 0) { // Admin login check
    updateCartProducts();
}