const nickNameInput = document.getElementById('nickName');
const passwordInput = document.getElementById('password');
const loginButton = document.getElementById('login-button');

function validarCampos() {
    const nickName = nickNameInput.value.trim();
    const password = passwordInput.value.trim();


    if (nickName !== '' && password !== '') {
        loginButton.disabled = false;
    } else {
        loginButton.disabled = true;
    }
}


nickNameInput.addEventListener('input', validarCampos);
passwordInput.addEventListener('input', validarCampos);


validarCampos();