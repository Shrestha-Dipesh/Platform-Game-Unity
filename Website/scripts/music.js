//Sound Player
const sounds = document.querySelectorAll('.sound');
const pads = document.querySelectorAll('.pads div');
const cart = document.querySelector('.cart');
const colors = [
    '#0984e3',
    '#d63031',
    '#27ae60',
    '#fdcb6e',
    '#6c5ce7',
    '#fd79a8'
]
//Play sounds
pads.forEach((pad, index) => {
    pad.addEventListener('click', function(){
        sounds[index].currentTime = 0;
        sounds[index].play();
        createBubbles(index);
    });
});
//Create bubbles
const createBubbles = (index) => {
    const bubble = document.createElement('section');
    cart.appendChild(bubble);
    bubble.style.backgroundColor = colors[index];
    bubble.style.animation = 'jump 1s ease';
    bubble.addEventListener('animationend', function(){
        cart.removeChild(this);
    })
}