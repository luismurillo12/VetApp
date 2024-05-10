    let userNameMessage = $("#userNameModalMessage");
let userFirstLastNameMessage = $("#userFirstLastNameModalMessage");
let userSecondLastNameMessage = $("#userSecondLastNameModalMessage");
let userIdCardMessage = $("#userIdCardModalMessage");
let userPhoneNumberMessage = $("#userPhoneNumberModalMessage");
let userMailMessage = $("#userMailModalMessage");
let userNickNameMessage = $("#userNickNameModalMessage");
let idRolMessage = $("#idRolModalMessage");
let userPasswordModalMessage = $("#userPasswordModalMessage");
let userPassworConfirmModalMessage = $("#userPassworConfirmModalMessage");



$(document).on("click", "#btnAddEmployee", function () {

    $("#userNameModal").prop("readonly", false);
    $("#userFirstLastNameModal").prop("readonly", false);
    $("#userSecondLastNameModal").prop("readonly", false);
    $("#userIdCardModal").prop("readonly", false);
    $("#userNickNameModal").prop("readonly", false);

    $("#idUserModal").val('');
    $("#userNameModal").val('');
    $("#userFirstLastNameModal").val('');
    $("#userSecondLastNameModal").val('');
    $("#userMailModal").val('');
    $("#userNickNameModal").val('');
    $("#userPhoneNumberModal").val('');
    $("#userIdCardModal").val('');

    userNameMessage.text("");
    userFirstLastNameMessage.text("");
    userSecondLastNameMessage.text("");
    userIdCardMessage.text("");
    userPhoneNumberMessage.text("");
    userMailMessage.text("");
    userNickNameMessage.text("");
    idRolMessage.text("");
    userPasswordModalMessage.text("");
    userPassworConfirmModalMessage.text("");

    const button = document.getElementById("btnGuardarModal");

    // Disable the button
    button.disabled = false;

    $('#usersModal').modal('show');

});

let userPicture = $("#userPictureModal").val();

function SavaChangesUserModal() {

    let idUser = $("#idUserModal").val();

    let validateInput = validateInputs();
    let validateEmailMessage = validateEmail();
    let validatePasswordMessage = validatePassword();
    let validatePhoneNumberMessage = validatePhoneNumber();
    let validateUserIdCardMessage = validateUserIdCard();

    if (validateInput && validateEmailMessage && validatePhoneNumberMessage && validateUserIdCardMessage) {

        if (idUser.trim().length === 0) {
            if (validatePasswordMessage) {
                CreateUser();
            }
        } else {
            UpdateUser();
        }

    }
    

}

function CreateUser() {
    let userName = $("#userNameModal").val();
    let userFirstLastName = $("#userFirstLastNameModal").val();
    let userSecondLastName = $("#userSecondLastNameModal").val();
    let userMail = $("#userMailModal").val();
    let userNickName = $("#userNickNameModal").val();
    let userPassword = $("#userPasswordModal").val();
    let userPhoneNumber = $("#userPhoneNumberModal").val();
    let idRol = $("#idRolModal").val();
    let userIdCard = $("#userIdCardModal").val();

    $.ajax({
        type: "POST",
        url: "../Administration/CreateUser",
        dataType: "json",
        data: {
            "userName": userName,
            "userFirstLastName": userFirstLastName,
            "userSecondLastName": userSecondLastName,
            "userMail": userMail,
            "userNickName": userNickName,
            "userPassword": userPassword,
            "userPicture": userPicture,
            "userPhoneNumber": userPhoneNumber,
            "idRol": idRol,
            "userIdCard": userIdCard
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Usuario registrado correctamente.',
                    confirmButtonText: 'Ok'
                }).then((result) => {
                    if (result['isConfirmed']) {
                        location.reload();
                    }
                })

                return;
            }
            Swal.fire({
                icon: 'error',
                title: 'Erorr',
                text: 'Lo sentimos ha ocurrido un error.',
            });

        }
    });

}

function OpenUpdateUserModal(idUser){
    $.ajax({
        type: "GET",
        url: "../Administration/GetUser?idUser=" + idUser,
        dataType: "json",
        success: function (res) {

            $("#userNameModal").prop("readonly", true);
            $("#userFirstLastNameModal").prop("readonly", true);
            $("#userSecondLastNameModal").prop("readonly", true);
            $("#userIdCardModal").prop("readonly", true);
            $("#userNickNameModal").prop("readonly", true);
            $("#userPasswordModal").val('');
            $("#userPassworConfirmModal").val('');

            $("#idUserModal").val(res.idUser);
            $("#userNameModal").val(res.userName);
            $("#userFirstLastNameModal").val(res.userFirstLastName);
            $("#userSecondLastNameModal").val(res.userSecondLastName);
            $("#userMailModal").val(res.userMail);
            $("#userNickNameModal").val(res.userNickName);
            $("#userPhoneNumberModal").val(res.userPhoneNumber);
            $("#idRolModal").val(res.idRol);
            $("#userIdCardModal").val(res.userIdCard);

            if (res.userIdCard.length === 9) {
                $("#selectUserIdCardModal").val('1');
            } else {
                $("#selectUserIdCardModal").val('2');
            }


            $('#usersModal').modal('show');

        }
    });
}

function UpdateUser() {

    let idUser = $("#idUserModal").val();
    let userMail = $("#userMailModal").val();
    let userNickName = $("#userNickNameModal").val();
    let userPassword = $("#userPasswordModal").val();
    let userPhoneNumber = $("#userPhoneNumberModal").val();
    let idRol = $("#idRolModal").val();
    let userIdCard = $("#userIdCardModal").val();

    $.ajax({
        type: "PUT",
        url: "../Administration/UpdateUser",
        dataType: "json",
        data: {
            "idUser": idUser,
            "idRol": idRol,
            "userMail": userMail,
            "userNickName": userNickName,
            "userPassword": userPassword,
            "userPicture": userPicture,
            "userPhoneNumber": userPhoneNumber,
            "userIdCard": userIdCard
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Usuario actualizado correctamente.',
                    confirmButtonText: 'Ok'
                }).then((result) => {
                    if (result['isConfirmed']) {
                        location.reload();
                    }
                })

                return;
            }

            Swal.fire({
                icon: 'error',
                title: 'Erorr',
                text: 'Lo sentimos ha ocurrido un error.',
            });

        }
    });

}

let id = 0;

function OpenDeleteConfirmUserModal(idUser) {
    id = idUser;
    $('#deleteUserModal').modal('show');   
}

function DeleteUser() {
    $.ajax({
        type: "DELETE",
        url: "../Administration/DeleteUser?idUser=" + id,
        dataType: "json",
        success: function (res) {

            if (res == 1) {
                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Usuario eliminado correctamente.',
                    confirmButtonText: 'Ok'
                }).then((result) => {
                    if (result['isConfirmed']) {
                        location.reload();
                    }
                })
                return;
            }

            Swal.fire({
                icon: 'error',
                title: 'Erorr',
                text: 'El empleado no puede ser eliminado, ya que esta siendo utilizada en otras funcionalidades del sistema.',
            });

        }
    });
}

//$(document).ready(function () {
//    $("#myInput").on("keyup", function () {

//    });
//});

//$('#search').keyup(function () {
//    $('.col-xl-4').removeClass('d-none');
//    var filter = $(this).val(); // get the value of the input, which we filter on
//    $('.col-xl-4').find('.card .card-body .text-start h4:not(:contains("' + filter + '"))').parent().parent().addClass('d-none');
//})

function ValidateAliasExist() {

    let userNickName = $("#userNickNameModal").val()

    const button = document.getElementById("btnGuardarModal");

    // Disable the button
    button.disabled = true;
    userNickNameMessage.text("");

    $.ajax({
        type: "GET",
        url: "../Administration/ValidateAliasExist?userNickName=" + userNickName,
        dataType: "json",
        success: function (res) {

            if (res === null) {
                button.disabled = false;

            } else {
                userNickNameMessage.text("El alias ingresado ya existe en el sistema.");
                button.disabled = true;
            }

        }
    });
}

function ValidateUserIdCardExist() {

    let idUser = $("#idUserModal").val();

    if (idUser.trim().length === 0) {

        let userIdCard = $("#userIdCardModal").val()

        const button = document.getElementById("btnGuardarModal");

        // Disable the button
        button.disabled = true;
        userIdCardMessage.text("");

        $.ajax({
            type: "GET",
            url: "../Administration/ValidateUserIdCardExist?userIdCard=" + userIdCard,
            dataType: "json",
            success: function (res) {

                if (res === null) {
                    button.disabled = false;

                } else {
                    userIdCardMessage.text("La c\u00E9dula ingresada ya existe en el sistema.");
                    button.disabled = true;
                }

            }
        });
    }
    
}

// Selecciona el elemento de entrada de archivo (input type="file") en tu HTML
const input = document.getElementById('userPictureModal');

// Agrega un evento para escuchar cuando se selecciona un archivo
input.addEventListener('change', function () {
    const file = input.files[0];

    // Crea un objeto FileReader
    const reader = new FileReader();

    // Define la función de devolución de llamada que se ejecutará cuando se cargue el archivo
    reader.onload = function () {
        // El contenido de la imagen en Base64 estará en reader.result
        const base64Image = reader.result;
        userPicture = base64Image;
    };

    // Lee el archivo como una URL de datos (Base64)
    reader.readAsDataURL(file);
});

function validateEmail() {

    let userMail = $("#userMailModal").val();

    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

    if (userMail.match(mailformat)) {
        userMailMessage.text("");
        return true;
    }
    else {
        userMailMessage.text("Formato de correo incorrecto.");
        return false;
    }
}

function validatePassword() {

    let userPassword = $("#userPasswordModal").val()
    let userPassworConfirm = $("#userPassworConfirmModal").val()

    userPasswordModalMessage.text("");
    userPassworConfirmModalMessage.text("");

    // Verificar longitud mínima
    if (userPassword.length < 8) {
        userPasswordModalMessage.text("Debe ser mayor o igual a 8 caracteres.");
        return false;
    }

    // Verificar si contiene al menos una letra mayúscula
    if (!/[A-Z]/.test(userPassword)) {
        userPasswordModalMessage.text("Debe contener al menos una letra may\u00FAscula.");
        return false;
    }

    // Verificar si contiene al menos una letra minúscula
    if (!/[a-z]/.test(userPassword)) {
        userPasswordModalMessage.text("Debe contener al menos una letra min\u00FAscula.");
        return false;
    }

    // Verificar si contiene al menos un número
    if (!/[0-9]/.test(userPassword)) {
        userPasswordModalMessage.text("Debe contener al menos un n\u00FAmero.");
        return false;
    }

    // Verificar si contiene al menos un caracter especial (por ejemplo, !@#$%^&*)
    if (!/[!@#$%^&*]/.test(userPassword)) {
        userPasswordModalMessage.text("Debe contener al menos un caracter especial.");
        return false;
    }

    if (userPassword !== userPassworConfirm) {
        userPassworConfirmModalMessage.text("Las contrase\u00F1as no coinciden.");
        return false;
    }
    // La contrasena cumple con todos los criterios
    return true;
}

function validatePhoneNumber() {

    let userPhoneNumber = $("#userPhoneNumberModal").val();
    userPhoneNumberMessage.text("");

    if (userPhoneNumber.trim().length < 8) {
        userPhoneNumberMessage.text("Tel\u00E9fono tiene que ser de ocho d\u00EDgitos.");
        return false;
    }

    if (userPhoneNumber.trim().length > 8) {
        userPhoneNumberMessage.text("Tel\u00E9fono no puede tener m\u00E1s de ocho d\u00EDgitos.");
        return false;
    }

    return true;
}

function validateUserIdCard() {

    let idUser = $("#idUserModal").val();

    if (idUser.trim().length === 0) {

        let userIdCard = $("#userIdCardModal").val();
        let selectUserIdCard = $("#selectUserIdCardModal").val();

        userIdCardMessage.text("");


        if (selectUserIdCard === '1') {

            if (userIdCard.trim().length < 9) {
                userIdCardMessage.text("C\u00E9dula no puede ser menor a 9 d\u00EDgitos.");
                return false;
            }

            if (userIdCard.trim().length > 9) {
                userIdCardMessage.text("C\u00E9dula no puede ser mayor a 9 d\u00EDgitos.");
                return false;
            }

            return true;
        }

        if (selectUserIdCard === '2') {

            if (userIdCard.trim().length < 10) {
                userIdCardMessage.text("C\u00E9dula no puede ser menor a 10 d\u00EDgitos.");
                return false;
            }

            if (userIdCard.trim().length > 10) {
                userIdCardMessage.text("C\u00E9dula no puede ser mayor a 10 d\u00EDgitos.");
                return false;
            }

            return true;
        }

        if (selectUserIdCard === '3') {

            if (userIdCard.trim().length < 12) {
                userIdCardMessage.text("DIMEX no puede ser menor a 12 d\u00EDgitos.");
                return false;
            }

            if (userIdCard.trim().length > 12) {
                userIdCardMessage.text("DIMEX no puede ser mayor a 12 d\u00EDgitos.");
                return false;
            }

            return true;
        }

        return true;

    }
    return true;
}

$('#selectUserIdCardModal').on('change', function () {
    //alert(this.value);
    userIdCardMessage.text("");
});

function validateInputs() {

    let userName = $("#userNameModal").val();
    let userFirstLastName = $("#userFirstLastNameModal").val();
    let userSecondLastName = $("#userSecondLastNameModal").val();
    let userIdCard = $("#userIdCardModal").val();
    let userPhoneNumber = $("#userPhoneNumberModal").val();
    let userMail = $("#userMailModal").val();
    let userNickName = $("#userNickNameModal").val();
    let idRol = $("#idRolModal").val();

    userNameMessage.text("");
    userFirstLastNameMessage.text("");
    userSecondLastNameMessage.text("");
    userIdCardMessage.text("");
    userPhoneNumberMessage.text("");
    userMailMessage.text("");
    userNickNameMessage.text("");
    idRolMessage.text("");

    if (userName.trim().length === 0) {
        userNameMessage.text("Nombre no puede ir vac\u00EDo.");
        return false;
    }

    if (userFirstLastName.trim().length === 0) {
        userFirstLastNameMessage.text("Primer apellido no puede ir vac\u00EDo.");
        return false;
    }

    if (userSecondLastName.trim().length === 0) {
        userSecondLastNameMessage.text("Segundo apellido no puede ir vac\u00EDo.");
        return false;
    }

    if (userIdCard.trim().length === 0) {
        userIdCardMessage.text("C\u00E9dula no puede ir vac\u00EDo.");
        return false;
    }

    if (userPhoneNumber.trim().length === 0) {
        userPhoneNumberMessage.text("Tel\u00E9fono no puede ir vac\u00EDo.");
        return false;
    }

    if (userMail.trim().length === 0) {
        userMailMessage.text("Correo no puede ir vac\u00EDo.");
        return false;
    }

    if (userNickName.trim().length === 0) {
        userNickNameMessage.text("Alias no puede ir vac\u00EDo.");
        return false;
    }

    if (idRol.trim().length === 0) {
        idRolMessage.text("Debe seleccionar un rol.");
        return false;
    }

    return true;
}