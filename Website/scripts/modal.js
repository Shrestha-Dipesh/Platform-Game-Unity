//Modal Toggle
const show = document.querySelector('#send');
const modal = document.querySelector('.modal-bg');
const firstName = document.querySelector('#fname');
const lastName = document.querySelector('#lname');
const email = document.querySelector('#email');
const message = document.querySelector('#msg');
const errorMessage = document.querySelector('#formerror');
if (show){
    show.addEventListener('click', function(e){
        e.preventDefault();
        if (firstName.value === ''){
            errorMessage.textContent = "First Name required";
        }
        else if (lastName.value == ''){
            errorMessage.textContent = "Last Name required";
        }
        else if (email.value == ''){
            errorMessage.textContent = "Email required"
        }
        else if (!email.value.includes('@')){
            errorMessage.textContent = "Invalid Email"
        }
        else if (message.value == ''){
            errorMessage.textContent = "Message required"
        }
        else{
            firstName.value = '';
            lastName.value = '';
            email.value = '';
            message.value = '';
            modal.classList.add('modal-active');
        }
        setTimeout(() => errorMessage.textContent = '', 3000);
    });
}
const purchaseBtn = document.querySelector('.purchase-div button');
if (purchaseBtn){
    purchaseBtn.addEventListener('click', () => {
        modal.classList.add('modal-active');
    })
}
const close = document.querySelector('.modal-close');
close.addEventListener('click', function(){
    modal.classList.remove('modal-active');
});