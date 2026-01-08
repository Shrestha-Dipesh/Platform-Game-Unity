//Display items from local storage
function displayCart(){
    let cartItems = JSON.parse(localStorage.getItem('gamesInCart'));
    let totalcost = parseFloat(localStorage.getItem('totalcost'));
    let cart = document.querySelector('.cart');
    let pads = document.querySelector('.pads');
    if (cartItems){
        cart.style.background = 'none';
        pads.style.display = 'none';
        cart.innerHTML = `<div class="heading">
        <div class="name">Games</div>
        <div class="price">Price</div>
        <div class = "action"></div>
        </div>`;
        cartItems.forEach(cartItem =>  {
            cart.innerHTML += `<div class="gamecart">
            <div class="game"><img src="media/images/${cartItem[0]}" alt=""><span>${cartItem[1]}</span></div>
            <div class="game-price">$${cartItem[2].toFixed(2)}</div>
            <div class="remove-div"><button class = "remove"><i class = "fas fa-trash"></i> Remove</button></div>
            </div>`
        });
        cart.innerHTML += `<div class="total">
        <div class="total-div"><h1>Total:</h1></div>
        <div class="total-price">$${totalcost.toFixed(2)}</div>
        <div class="purchase-div"><button><i class = "fab fa-shopify"></i> Purchase</button></div>
    </div>`
    }
}
//Remove items from local storage
function removeCart(){
    const btns = document.querySelectorAll('.remove');
    let cartItems = JSON.parse(localStorage.getItem('gamesInCart'));
    let productNumbers = parseInt(localStorage.getItem('cartNumbers'));
    let cartCost = localStorage.getItem('totalcost');
    const total = document.querySelector('.total-price');
    let cartTotal = document.querySelector('.cart-number');
    btns.forEach(btn => {
        btn.addEventListener('click', () => {
            btn.parentElement.parentElement.remove();
            cartItems.forEach(cartItem => {
                if (btn.parentElement.parentElement.children[0].children[1].textContent === cartItem[1]){
                    cartItems.splice(cartItems.indexOf(cartItem),1);
                    localStorage.setItem('gamesInCart', JSON.stringify(cartItems));
                    productNumbers -= 1;
                   localStorage.setItem('cartNumbers', productNumbers);
                   cartTotal.textContent = productNumbers;
                   cartCost -= cartItem[2];
                   localStorage.setItem('totalcost', cartCost);
                   total.textContent = `$${cartCost.toFixed(2)}`;
                   emptyCart();
                }
            });
        });
    });
}

//Display content when page is empty
function emptyCart(){
    let cartTotal = document.querySelector('.cart-number');
    const totalDiv = document.querySelector('.total');
    const headingDiv = document.querySelector('.heading');
    const cart = document.querySelector('.cart');
    const pads = document.querySelector('.pads');
    if (cartTotal.textContent == 0){
        localStorage.removeItem('gamesInCart');
        localStorage.removeItem('cartNumbers');
        localStorage.removeItem('totalcost');
        headingDiv.style.display = 'none';
        totalDiv.style.display = 'none';
        cart.style.background = "url('media/images/lonely.svg')"
        cart.style.backgroundSize = "contain";
        cart.style.backgroundRepeat = "no-repeat";
        cart.style.backgroundPosition = "center";
        pads.style.display = "flex";
    }
}

//Confirm Purchase
function confirmPurchase(){
    const confirmBtn = document.querySelector('#confirm-btn');
    const cartModal = document.querySelector('#cart-modal');
    const modal = document.querySelector('.modal-bg');
    const cartError = document.querySelector('.cart-error');
    const number = document.querySelector('#number');
    const finame = document.querySelector('#finame');
    const laname = document.querySelector('#laname');
    const edate = document.querySelector('#edate');
    const cvc = document.querySelector('#cvc');
    let cartTotal = document.querySelector('.cart-number');
    const totalDiv = document.querySelector('.total');
    const headingDiv = document.querySelector('.heading');
    const cart = document.querySelector('.cart');
    const pads = document.querySelector('.pads');
    confirmBtn.addEventListener('click', () => {
        if (number.value === ''){
            cartError.textContent = "Credit Card Number Required";
        }
        else if (finame.value == ''){
            cartError.textContent = "First Name Required";
        }
        else if (laname.value == ''){
            cartError.textContent = "Last Name Required";
        }
        else if (edate.value == ''){
            cartError.textContent = "Expiry Date Required";
        }
        else if (cvc.value == ''){
            cartError.textContent = "CVC Required";
        }
        else{
            cartModal.innerHTML = '<img src = "media/images/purchase.svg" alt = "success" class = "success">'
            cartModal.style.width = '100%'
            cartModal.style.height = '100vh';
            setTimeout(() => modal.style.display = "none", 3000);
            localStorage.removeItem('gamesInCart');
            localStorage.removeItem('cartNumbers');
            localStorage.removeItem('totalcost');
            headingDiv.style.display = 'none';
            totalDiv.style.display = 'none';
            cart.style.background = "url('media/images/lonely.svg')"
            cart.style.backgroundSize = "contain";
            cart.style.backgroundRepeat = "no-repeat";
            cart.style.backgroundPosition = "center";
            pads.style.display = "flex";
            cartTotal.textContent = 0;
            cart.innerHTML = '';
        }
        setTimeout(() => cartError.textContent = '', 2000);
    })
}

displayCart();
removeCart();
confirmPurchase();