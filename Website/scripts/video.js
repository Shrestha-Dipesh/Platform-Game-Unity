//Video Player
const btn = document.querySelectorAll('.btn2');
const video = document.querySelectorAll('.video');
const actualVideo = document.querySelectorAll('iframe');
const overlay = document.querySelector('#video-overlay');

for (let i = 0; i < btn.length; i++){
    btn[i].onclick = () => {
    video[i].classList.add('display');
    overlay.classList.add('display');
    }
}
overlay.onclick = () => {;
    overlay.classList.remove('display');
    video.forEach((vid) => {
        vid.classList.remove('display');
    });
    actualVideo.forEach((vii) =>{
        vii.src = vii.src;
    });
}