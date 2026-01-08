//Selectors
const switchBtn = document.querySelector('.l');
const body = document.querySelector('body');
const nav = document.querySelector('nav');
const navA = document.querySelectorAll('nav a');
const searctTxt = document.querySelector('.search-txt');
const hyperlinkA = document.querySelectorAll('.hyperlink-container a');
const formInputs = document.querySelectorAll('.form-input input');
const formArea = document.querySelector('.text-input textarea');
const modalDiv = document.querySelector('.modal');
const boxes = document.querySelectorAll('.box');
const backs = document.querySelectorAll('.back');
const sups = document.querySelectorAll('sup');
const lines = document.querySelectorAll('.line');
const navLinks = document.querySelector('.nav-links');
const buy = document.querySelector('.buy');
const already = document.querySelector('.already');
const mainH6 = document.querySelector('.main-container h6');
const content = document.querySelector('.content');
const imgBox = document.querySelector('.imgbox');
const trailerContainer = document.querySelector('.trailer-container');
const discover = document.querySelector('#discover');
const icon = document.querySelectorAll('.icon');
const sBox = document.querySelector('.search-box');
const sBtn = document.querySelector('.search-btn');
const inputDivs = document.querySelectorAll('.input');

//Event Listener
switchBtn.addEventListener('click', makeSwitch);

//Functions
function makeSwitch(){
    if (switchBtn.checked == true){
        localStorage.setItem('checked', JSON.stringify('true'));
    }
    else if (switchBtn.checked == false){
        localStorage.setItem('checked', JSON.stringify('false'));
    }
    checkSwitch();
}
function checkSwitch(){
    let checked = JSON.parse(localStorage.getItem('checked'));
    if (checked == 'true'){
        switchBtn.checked = true;
        body.classList.add('light');
        if (nav){
            nav.classList.add('light');
        }
        if (sBox){
            sBox.style.background = "#e2e2ec"
        }
        if (sBtn){
            sBtn.style.background = "#e2e2ec"
        }
        if (hyperlinkA){
            hyperlinkA.forEach(hyperlink => {
                hyperlink.style.background = "#e2e2ec";
            })
        }
        if (navA.length >0){
            for (let i = 0; i < 4; i++){
                navA[i].style.color = 'black';
                navA[i].addEventListener('mouseover', ()=> {
                    navA[i].style.color = "#0984e3"
                })
                navA[i].addEventListener('mouseleave', ()=> {
                    navA[i].style.color = "black"
                })
            }
        }
        if (searctTxt){
            searctTxt.style.color = 'black';
        }
        if (formInputs){
            formInputs.forEach(formInput => {
                formInput.style.color = 'black';
            })
        }
        if (formArea){
            formArea.style.color = 'black';
        }
        if (modalDiv){
            modalDiv.classList.add('light');
        }
        if (boxes){
            boxes.forEach(box => {
                box.classList.add('light');
            })
        }
        if (backs){
            backs.forEach(back => {
                back.classList.add('light');
            }) 
        }
        if (sups){
            sups.forEach(sup => {
                sup.style.color = "white";
            })
        }
        if (lines){
            lines.forEach(line => {
                line.style.background = 'black';
            })
        }
        if (navLinks){
            navLinks.style.background = 'white';    
        }
        if (buy){
            buy.classList.add('light');
        }
        if (already){
            already.classList.add('light');
        }
        if (mainH6){
            mainH6.style.color = 'white';
        }
        if (content){
            content.classList.add('light');
        }
        if (imgBox){
            imgBox.style.borderLeft = '250px solid white';
        }
        if (trailerContainer){
            trailerContainer.style.border = '1px solid white';
        }
        if (discover){
            discover.style.color = 'white';
        }
        if (icon){
            icon.forEach(i => {
                i.style.color = 'white';
            })
        }
        if (inputDivs){
            inputDivs.forEach(inputDiv => {
                inputDiv.style.color = 'black';
            })
        }
    }
    else if (checked == 'false'){
        switchBtn.checked = false;
        body.classList.remove('light');
        if (nav){
            nav.classList.remove('light');
        }
        if (sBox){
            sBox.style.background = "black"
        }
        if (sBtn){
            sBtn.style.background = "black"
        }
        if (hyperlinkA){
            hyperlinkA.forEach(hyperlink => {
                hyperlink.style.background = 'white';
            })
        }
        if (navA.length > 0){
            for (let i = 0; i < 4; i++){
                navA[i].style.color = 'white';
                navA[i].addEventListener('mouseover', ()=> {
                    navA[i].style.color = "#0984e3"
                })
                navA[i].addEventListener('mouseleave', ()=> {
                    navA[i].style.color = "white"
                })
            }
        }
        if (searctTxt){
            searctTxt.style.color = 'white';
        }
        if (formInputs){
            formInputs.forEach(formInput => {
                formInput.style.color = 'white';
            })
        }
        if (formArea){
            formArea.style.color = 'white';
        }
        if (modalDiv){
            modalDiv.classList.remove('light');
        }
        if (boxes){
            boxes.forEach(box => {
                box.classList.remove('light');
            })
        }
        if (backs){
            backs.forEach(back => {
                back.classList.remove('light');
            }) 
        }
        if (sups){
            sups.forEach(sup => {
                sup.style.color = "#111";
            })
        }
        if (lines){
            lines.forEach(line => {
                line.style.background = 'white';
            })
        }
        if (navLinks){
            navLinks.style.background = '#111';
        }
        if (buy){
            buy.classList.remove('light');
        }
        if (already){
            already.classList.remove('light');
        }
        if (mainH6){
            mainH6.style.color = 'white';
        }
        if (content){
            content.classList.remove('light');
        }
        if (imgBox){
            imgBox.style.borderLeft = '250px solid #111';
        }
        if (trailerContainer){
            trailerContainer.style.border = '1px solid #111';
        }
        if (discover){
            discover.style.color = '#111';
        }
        if (icon){
            icon.forEach(i => {
                i.style.color = '#111';
            })
        }
        if (inputDivs){
            inputDivs.forEach(inputDiv => {
                inputDiv.style.color = 'white';
            })
        }
    }
}
checkSwitch();