const loader = document.querySelector('.loader');
let checked = JSON.parse(localStorage.getItem('checked'));
if (checked == 'true'){
    loader.style.background = 'white';
}
else{
    loader.style.background = '#111';
}

//Display Loader
window.addEventListener('load', () => {
    loader.style.opacity = 0;
    loader.style.pointerEvents = 'none';
})