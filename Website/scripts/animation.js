//Text Animation
window.addEventListener('load', () => {
    const text = document.querySelector('.fancy');
    const strText = text.textContent;
    const splitText = strText.split('');
    text.textContent = '';

    for (let i = 0; i < splitText.length; i++){
        text.innerHTML += `<h3>${splitText[i]}</h3>`
    }
    let char = 0;
    let timer = setInterval(onTick, 50);

    function onTick(){
        text.style.opacity = '1';
        const span = text.querySelectorAll('h3')[char];
        span.classList.add('fade');
        char++;
        if (char === splitText.length){
            complete();
            return;
        }
}

function complete(){
    clearInterval(timer);
    timer = null;
}
})

//Shop redirection
const buttons = document.querySelectorAll('button');
buttons.forEach(button => {
    button.onclick = () => {
        document.location = 'shop.html';
    }
});

//Dot Navigation Menu
const dots = document.querySelectorAll('.dot');
function scroll(e){
        for (let i = 0; i < dots.length; i++){
            dots[i].classList.remove('enable');
            }
        this.classList.add('enable');
}
dots.forEach(dot => {
    dot.addEventListener('click', scroll);
});
const containers = document.querySelectorAll('.nav-container');
const options = {
    threshold: 0.7
};
let observer = new IntersectionObserver(navCheck, options);
function navCheck(entries){
    entries.forEach(entry => {
        const id = entry.target.id;
        if (entry.isIntersecting){
            dots.forEach(dot => {
                    dot.classList.remove('enable');
            })
            if (id == 'video-container'){
                dots[0].classList.add('enable');
            }
            else if (id == 'trail-div'){
                dots[1].classList.add('enable');
            }
            else if (id == 'game-div'){ 
                dots[2].classList.add('enable');
            }
            else if (id == 'last-container'){
                dots[3].classList.add('enable');
            }
        }
    });
};
containers.forEach(container => {
    observer.observe(container);
});

//Mouse Hover Animation
const cursor = document.querySelector('.cursor');
const slideContainer = document.querySelector('.slide-container');
const h1 = document.querySelector('#discover');
const icons = document.querySelectorAll('.icon');
slideContainer.addEventListener('mousemove', function(e){
    cursor.style.opacity = 1;
    cursor.style.top = e.pageY+ 'px';
    cursor.style.left = e.pageX+ 'px';
})
h1.addEventListener('mouseover', ()=>{
    cursor.classList.add('show');
})
h1.addEventListener('mouseleave', ()=>{
    cursor.classList.remove('show');
})
icons.forEach(icon => {
    icon.addEventListener('mouseover', ()=>{
        cursor.classList.add('show');
    })
    icon.addEventListener('mouseleave', ()=>{
        cursor.classList.remove('show');
    });
});
slideContainer.addEventListener('mouseleave', function(e){
    cursor.style.opacity = 0;
})

//Image SlideShow
var i = 0;
var images = ['slide1.jpg', 'slide2.jpg', 'slide3.png', 'slide4.jpg', 'slide5.jpg', 'slide6.png'];
var media = window.matchMedia('(max-width: 800px)');
function slideShow() {
    slideContainer.style.backgroundImage = `url('media/images/${images[i]}')`;
    if (i < images.length -1){
        i++;
    }
    else{
        i = 0;
    }
}
setInterval(slideShow, 4000);
window.onload = slideShow;

//Trailer Video Change
const video = document.querySelector('iframe');
const img1 = document.querySelector('#img1');
const img2 = document.querySelector('#img2');
const img3 = document.querySelector('#img3');
const img4 = document.querySelector('#img4');
const img5 = document.querySelector('#img5');
const img6 = document.querySelector('#img6');
const img7 = document.querySelector('#img7');
img1.onclick = () => {
    video.setAttribute('src', 'https://www.youtube.com/embed/SeBnDAD7mHE?rel=0');
}
img2.onclick = () => {
    video.setAttribute('src', 'https://www.youtube.com/embed/UjxS9ciNlII?rel=0');
}
img3.onclick = () => {
    video.setAttribute('src', 'https://www.youtube.com/embed/QkkoHAzjnUs?rel=0');
}
img4.onclick = () => {
    video.setAttribute('src', 'https://www.youtube.com/embed/dZl1yGUetjI?rel=0');
}
img5.onclick = () => {
    video.setAttribute('src', 'https://www.youtube.com/embed/T2WbkJqqXbc?rel=0');
}
img6.onclick = () => {
    video.setAttribute('src', 'https://www.youtube.com/embed/2gUtfBmw86Y?rel=0');
}
img7.onclick = () => {
    video.setAttribute('src', 'https://www.youtube.com/embed/ot63S91Ihwk?rel=0');
}
