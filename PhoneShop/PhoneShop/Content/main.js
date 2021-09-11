
function updateCartProducts() {
    var cartProducts;
    var existingCookieData = $.cookie('CartProducts');

    if (existingCookieData != undefined && existingCookieData != "" && existingCookieData != null) {
        //若cookie存有CartProducts，用'-'做分割後將element回傳給products
        //e.g. 21-19-30 => [21,19,30]，數字為產品ID
        cartProducts = existingCookieData.split('-');
    }
    else {
        cartProducts = []; // cookie 沒有 CartProducts，products設為空陣列
    }

    // find html id elemnt 'cartProductsCount'，更改innerHTML文字，主要為每次產品加入購物車時，刷新購物車顯示數量
    document.getElementById('cartProductsCount').innerHTML = "<a href='/Home/ShoppingCart'>購物車(" + cartProducts.length + ")</a>";
};

var sessionValue = $("#hdnSession").data('value'); // _Layout

if (sessionValue.length == 0) { // Admin login check
    updateCartProducts();
}