//Smooth Scroll Page
const topbtn = document.querySelector("#topBtn");

window.addEventListener("scroll", scrollFunction);

function scrollFunction(){
    if (window.pageYOffset > 200){
        topbtn.style.display = "block";
    }
    else{
        topbtn.style.display = "none";
    }
}

topbtn.addEventListener("click", backToTop);

function backToTop(){
    window.scrollTo(0,0);
}