function UpdateUserPassword() {

    let validatePasswordMessage = validatePassword();

    if (validatePasswordMessage) {

        let userMail = $("#userMail").val();
        let userPassword = $("#userPassword").val();

        $.ajax({
            type: "PUT",
            url: "../Administration/UpdateUserPassword",
            dataType: "json",
            data: {
                "userMail": userMail,
                "userPassword": userPassword,
            },
            success: function (res) {

                if (res == 1) {

                    Swal.fire({
                        title: '',
                        icon: 'success',
                        text: 'Contrase\u00F1a actualizada correctamente.',
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
    

}

function validatePassword() {

    let userPassword = $("#userPassword").val()
    let userPasswordModalMessage = $("#userPasswordMessage");
    let userPassworConfirm = $("#confirmPassword").val()
    let userPassworConfirmModalMessage = $("#confirmPasswordMessage");

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