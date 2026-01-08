//Cart number local storage
const cartBtns = document.querySelectorAll('.btn1');
let cartTotal = document.querySelector('.cart-number')
const buyDiv = document.querySelector('.buy');
const alreadyDiv = document.querySelector('.already');
let games = [
    ['image1.png', "NSUNS 4", 29.99, false],
    ['image2.png', "Overwatch", 19.99, false],
    ['image3.jpg', "GTA V", 0.00, false],
    ['image4.png', "Fortnite", 0.00, false],
    ['image5.jpg', "Assassins Creed", 56.69, false],
    ['image6.jpg', "Prince of Persia", 9.45, false],
    ['image7.jpg', "Dota 2", 0.00, false],
    ['image8.png', "Cyberpunk 2077", 29.99, false],
    ['image9.jpg', "Mortal Kombat", 49.99, false],
    ['image10.jpg', "Witcher 3", 39.99, false],
    ['image11.png', "Asphalt 9", 0.00, false],
    ['image12.jpg', "PUBG", 14.99, false],
    ['image13.png', "God of War", 14.99, false],
    ['image14.jpg', "Fifa 16", 14.99, false],
    ['image15.jpg', "Devil May Cry", 24.99, false],
    ['image16.jpg', "Dark Souls", 59.99, false]
]
cartBtns.forEach((cartBtn, index) => {
    cartBtn.addEventListener('click', () => {
        let found = false;
        let items = JSON.parse(localStorage.getItem('gamesInCart'));
        if (items){
            items.forEach(item => {
                if (item[0] == games[index][0]){
                    found = true;
                    alreadyDiv.style.opacity = 1;
                    setTimeout(() => alreadyDiv.style.opacity = 0, 1000);
                }
            })
            if (found==false){
                addToCart(games[index]);
                totalCost(games[index]);
            }
        }
        else{
            addToCart(games[index]);
            totalCost(games[index]);
        }
    })
})
//Add items numbers to local storage
function addToCart(game){
    buyDiv.style.opacity = 1;
    setTimeout(() => buyDiv.style.opacity = 0, 1000);
    let productNumbers = parseInt(localStorage.getItem('cartNumbers'));
    if (productNumbers)
    {
        localStorage.setItem('cartNumbers', productNumbers+1);
        cartTotal.textContent = productNumbers+1;
    }
    else{
        localStorage.setItem('cartNumbers', 1);
        cartTotal.textContent = 1;
    }
    setItems(game);
}

//Add items to local storage
function setItems(game){
    let cartItems = JSON.parse(localStorage.getItem('gamesInCart'));
    let found = false;
    if (cartItems != null){
        cartItems.forEach(cartItem => {
            if (cartItem[1] === game[1]){
                found = true;
            }
        })
        if (found == false){
            cartItems.push(game);
        }
        game[3] = true;
    }
    else{
        cartItems = [game];
        game[3] = true;
    }
    localStorage.setItem('gamesInCart', JSON.stringify(cartItems));
}
//Add total cost to local storage
function totalCost(game){
    let cartCost = localStorage.getItem('totalcost');
    if (cartCost != null){
        cartCost = parseFloat(cartCost);
        localStorage.setItem('totalcost', (cartCost + game[2]).toFixed(2));
    }
    else{
        localStorage.setItem('totalcost',game[2]);
    }
}