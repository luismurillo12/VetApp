function ValidateUserMailExist() {

    let userMail = $("#userMail").val()
    let userMailMessage = $("#userMailMessage");

    const button = document.getElementById("btnSendRequest");

    // Disable the button
    button.disabled = true;
  /*  ('#btnSendRequest').attr('disabled', true);*/

    userMailMessage.text("");

    $.ajax({
        type: "GET",
        url: "../Administration/ValidateUserMailExist?userMail=" + userMail,
        dataType: "json",
        success: function (res) {

            if (res.userMail === "") {
                userMailMessage.text("El correo ingresado no existe en el sistema.");
                button.disabled = true;

            } else {
                button.disabled = false;
            }
            
        }
    });
}

function RequestNewPasswordEmailSend() {

    let userMail = $("#userMail").val();
    let userMailMessage = $("#userMailMessage");

    if (userMail.trim().length === 0) {
        userMailMessage.text("Correo no puede ir vac\u00EDo.");
        return;
    }

    userMailMessage.text("Enviando correo...");

    $.ajax({
        type: "POST",
        url: "../Home/RequestNewPasswordEmailSend",
        dataType: "json",
        data: {
            "userMail": userMail,
        },
        success: function (res) {

            if (res !== "") {

                userMailMessage.text("");

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: res,
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

