//Navigation Animation
const hamburger = document.querySelector('.hamburger');
const navlinks = document.querySelector('.nav-links');
const links = document.querySelectorAll('.nav-links li');

hamburger.onclick =() =>{
    navlinks.classList.toggle('open');
}

//Search Section
const search = document.querySelector('.search-txt');
const searchBtn = document.querySelector('.search-btn');
const searchBox = document.querySelector('.search-box');
searchBox.addEventListener('mouseover', () => {
    search.style.width = '200px';
    search.style.padding = '0 6px';
})
searchBox.addEventListener('mouseleave', () => {
    if (search.value === ''){
        search.style.width = '0px';
        search.style.padding = '0px';
    } 
})
searchBtn.onclick = () => {
    if (search.value.toLowerCase() === 'trailer'){
        searchBtn.href = "#trail-div";
    }
    else if (search.value.toLowerCase() === 'games'){
        searchBtn.href = "#game-div";
    }
    else if (search.value.toLowerCase() === 'slide'){
        searchBtn.href = "#last-container";
    }
    else if (search.value.toLowerCase() === 'video'){
        searchBtn.href = "#video-container";
    }
    search.value = '';
}

//Cart Number Update
function onLoadCartNumber(){
    let cartTotal = document.querySelector('.cart-number')
    let productNumbers = parseInt(localStorage.getItem('cartNumbers'));
    if (productNumbers){
        cartTotal.textContent = productNumbers;
    }
}
onLoadCartNumber();