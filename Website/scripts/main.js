//Login Animations
const inputs = document.querySelectorAll('.input');

function focusFunc(){
    let parent = this.parentNode.parentNode;
    parent.classList.add('focus');
};

function blurFunc(){
    let parent = this.parentNode.parentNode;
    if (this.value === ''){
        parent.classList.remove('focus');
    }
};

inputs.forEach(inputs => {
    inputs.addEventListener('focus', focusFunc);
    inputs.addEventListener('blur', blurFunc);
});

//Validate Login
const username = document.querySelector('#username');
const password = document.querySelector('#password');
const accessname = ['admin'];
const accesspassword = ['admin'];
const login = document.querySelector('#login');
const errormsg = document.querySelector('#errormsg')
login.onclick = (e) => {
    e.preventDefault();
    for (let i = 0; i < accessname.length; i++){
        if (accessname[i] === username.value && accesspassword[i] === password.value){
            errormsg.textContent = "Access Granted";
            errormsg.style.color = '#00b894'
            document.location = 'home.html';
            break;
        }
        else{
            if (username.value == '' || password.value == ''){
                errormsg.textContent = 'Empty Fields';
            }
            else{
                errormsg.textContent = 'Invalid Credentials'
            }
            errormsg.style.color = '#e74c3c'
        }
    }
    setTimeout(() => errormsg.textContent = '', 3000);
};

//Register user
const regname = document.querySelector('#regname');
const regpassword = document.querySelector('#regpassword');
const register = document.querySelector('#register');
const regerrormsg = document.querySelector('#regerrormsg');
const regcontainer = document.querySelector('#reg-container');
const logcontainer = document.querySelector('#log-container');
const back = document.querySelector('#back');
access.onclick = () =>{
    username.value = '';
    password.value = '';
    logcontainer.style.display = 'none';
    regcontainer.style.display = 'block';
    username.parentNode.parentNode.classList.remove('focus');
    password.parentNode.parentNode.classList.remove('focus');
}
back.onclick = () =>{
    regname.value = '';
    regpassword.value = '';
    logcontainer.style.display = 'block';
    regcontainer.style.display = 'none';
    regname.parentNode.parentNode.classList.remove('focus');
    regpassword.parentNode.parentNode.classList.remove('focus');
}
register.onclick = (e) =>{
    e.preventDefault();
    if(regname.value == '' || regpassword.value == ''){
        regerrormsg.textContent = 'Empty Fields';
        regerrormsg.style.color = '#e74c3c';
    }
    else{
        accessname.push(regname.value);
        accesspassword.push(regpassword.value);
        errormsg.textContent = 'Registered Successfully';
        errormsg.style.color = '#00b894';
        regcontainer.style.display = "none";
        logcontainer.style.display = "block"
        regname.parentNode.parentNode.classList.remove('focus');
        regpassword.parentNode.parentNode.classList.remove('focus');
    }
    setTimeout(() => regerrormsg.textContent = '', 3000);
    setTimeout(() => errormsg.textContent = '', 3000);
    regname.value = null;
    regpassword.value = null;
}