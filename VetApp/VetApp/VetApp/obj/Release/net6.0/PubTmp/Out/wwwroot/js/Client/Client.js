let clientNameMessage = $("#clientNameModalMessage");
let clientFirstLastNameMessage = $("#clientFirstLastNameModalMessage");
let clientSecondLastNameMessage = $("#clientSecondLastNameModalMessage");
let clientIdCardMessage = $("#clientIdCardModalMessage");
let clientphoneNumberMessage = $("#clientphoneNumberModalMessage");

$(document).on("click", "#btnAddClient", function () {

    $("#clientNameModal").prop("readonly", false);
    $("#clientFirstLastNameModal").prop("readonly", false);
    $("#clientSecondLastNameModal").prop("readonly", false);
    $("#clientphoneNumberModal").prop("readonly", false);
    $("#clientIdCardModal").prop("readonly", false);

    $("#idClientModal").val('');
    $("#clientNameModal").val('');
    $("#clientFirstLastNameModal").val('');
    $("#clientSecondLastNameModal").val('');
    $("#clientIdCardModal").val('');
    $("#clientphoneNumberModal").val('');

    clientNameMessage.text("");
    clientFirstLastNameMessage.text("");
    clientSecondLastNameMessage.text("");
    clientIdCardMessage.text("");
    clientphoneNumberMessage.text("");

    const button = document.getElementById("btnGuardarModal");

    // Disable the button
    button.disabled = false;


    $('#clientsModal').modal('show');

});

function SavaChangesClientModal() {

    let idClient = $("#idClientModal").val();

    let validateInput = validateInputs();
    let validateClientIdCardMessage = validateClientIdCard();


    if (validateInput && validateClientIdCardMessage) {

        if (idClient.trim().length === 0) {
            CreateClient();
        } else {
            UpdateClient();
        }

    }


}

function CreateClient() {
    let clientName = $("#clientNameModal").val();
    let clientFirstLastName = $("#clientFirstLastNameModal").val();
    let clientSecondLastName = $("#clientSecondLastNameModal").val();
    let clientIdCard = $("#clientIdCardModal").val();
    let clientphoneNumber = $("#clientphoneNumberModal").val();


    $.ajax({
        type: "POST",
        url: "../Client/CreateClient",
        dataType: "json",
        data: {
            "clientName": clientName,
            "clientFirstLastName": clientFirstLastName,
            "clientSecondLastName": clientSecondLastName,
            "clientIdCard": clientIdCard,
            "clientphoneNumber": clientphoneNumber,
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Cliente registrado correctamente.',
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

function OpenUpdateClientModal(idClient) {
    $.ajax({
        type: "GET",
        url: "../Client/GetClient?idClient=" + idClient,
        dataType: "json",
        success: function (res) {

            $("#clientNameModal").prop("readonly", false);
            $("#clientFirstLastNameModal").prop("readonly", false);
            $("#clientSecondLastNameModal").prop("readonly", false);
            $("#clientphoneNumberModal").prop("readonly", false);
            $("#clientIdCardModal").prop("readonly", false);


            $("#idClientModal").val(res.idClient);
            $("#clientNameModal").val(res.clientName);
            $("#clientFirstLastNameModal").val(res.clientFirstLastName);
            $("#clientSecondLastNameModal").val(res.clientSecondLastName);
            $("#clientIdCardModal").val(res.clientIdCard);
            $("#clientphoneNumberModal").val(res.clientphoneNumber);


            $('#clientsModal').modal('show');

        }
    });
}

function UpdateClient() {

    let idClient = $("#idClientModal").val();
    let clientName = $("#clientNameModal").val();
    let clientFirstLastName = $("#clientFirstLastNameModal").val();
    let clientSecondLastName = $("#clientSecondLastNameModal").val();
    let clientIdCard = $("#clientIdCardModal").val();
    let clientphoneNumber = $("#clientphoneNumberModal").val();


    $.ajax({
        type: "PUT",
        url: "../Client/UpdateClient",
        dataType: "json",
        data: {
            "idClient": idClient,
            "clientName": clientName,
            "clientFirstLastName": clientFirstLastName,
            "clientSecondLastName": clientSecondLastName,
            "clientIdCard": clientIdCard,
            "clientphoneNumber": clientphoneNumber
        },
        success: function (res) {

            if (res == 1) {

                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Cliente actualizado correctamente.',
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

let idtemp = 0;

function OpenDeleteConfirmClientModal(idClient) {
    idtemp = idClient;
    $('#deleteClientModal').modal('show');
}

function DeleteClient() {
    $.ajax({
        type: "DELETE",
        url: "../Client/DeleteClient?idClient=" + idtemp,
        dataType: "json",
        success: function (res) {

            if (res == 1) {
                Swal.fire({
                    title: '',
                    icon: 'success',
                    text: 'Cliente eliminado correctamente.',
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
                text: 'El cliente no puede ser eliminado, ya que esta siendo utilizado en otras funcionalidades del sistema.',
            });

        }
    });
}

function ValidateClientIdCardExist() {

    let idClient = $("#idClientModal").val();

    if (idClient.trim().length === 0) {

        let clientIdCard = $("#clientIdCardModal").val()

        const button = document.getElementById("btnGuardarModal");

        // Disable the button
      //  button.disabled = true;
        clientIdCardMessage.text("");

        $.ajax({
            type: "GET",
            url: "../Client/ValidateClientIdCardExist?clientIdCard=" + clientIdCard,
            dataType: "json",
            success: function (res) {

                if (res === null) {
                    button.disabled = false;

                } else {
                    clientIdCardMessage.text("La c\u00E9dula ingresada ya existe en el sistema.");
                    button.disabled = true;
                }

            }
        });
    }

}
function validateClientIdCard() {

    let clientIdCard = $("#clientIdCardModal").val();
    let selectClientIdCard = $("#selectClientIdCardModal").val();

    clientIdCardMessage.text("");


    if (selectClientIdCard === '1') {

        if (clientIdCard.trim().length < 9) {
            clientIdCardMessage.text("C\u00E9dula no puede ser menor a 9 d\u00EDgitos.");
            return false;
        }

        if (clientIdCard.trim().length > 9) {
            clientIdCardMessage.text("C\u00E9dula no puede ser mayor a 9 d\u00EDgitos.");
            return false;
        }

        return true;
    }

    if (selectClientIdCard === '2') {

        if (clientIdCard.trim().length < 10) {
            clientIdCardMessage.text("C\u00E9dula  no puede ser menor a 10 d\u00EDgitos.");
            return false;
        }

        if (clientIdCard.trim().length > 10) {
            clientIdCardMessage.text("C\u00E9dula  no puede ser mayor a 10 d\u00EDgitos.");
            return false;
        }

        return true;
    }

    if (selectClientIdCard === '3') {

        if (clientIdCard.trim().length < 12) {
            clientIdCardMessage.text("DIMEX no puede ser menor a 12 d\u00EDgitos.");
            return false;
        }

        if (clientIdCard.trim().length > 12) {
            clientIdCardMessage.text("DIMEX no puede ser mayor a 12 d\u00EDgitos.");
            return false;
        }

        return true;
    }

    return true;
}

$('#selectClientIdCardModal').on('change', function () {
    //alert(this.value);
    clientIdCardMessage.text("");
});
function validateInputs() {

    let clientName = $("#clientNameModal").val();
    let clientFirstLastName = $("#clientFirstLastNameModal").val();
    let clientSecondLastName = $("#clientSecondLastNameModal").val();
    let clientIdCard = $("#clientIdCardModal").val();
    let clientphoneNumber = $("#clientphoneNumberModal").val();

    let clientNameMessage = $("#clientNameModalMessage");
    let clientFirstLastNameMessage = $("#clientFirstLastNameModalMessage");
    let clientSecondLastNameMessage = $("#clientSecondLastNameModalMessage");
    let clientIdCardMessage = $("#clientIdCardModalMessage");
    let clientphoneNumberMessage = $("#clientphoneNumberModalMessage");


    clientNameMessage.text("");
    clientFirstLastNameMessage.text("");
    clientSecondLastNameMessage.text("");
    clientIdCardMessage.text("");
    clientphoneNumberMessage.text("");

    if (clientName.trim().length === 0) {
        clientNameMessage.text("Nombre no puede ir vac\u00EDo.");
        return false;
    }

    if (clientFirstLastName.trim().length === 0) {
        clientFirstLastNameMessage.text("Primer apellido no puede ir vac\u00EDo.");
        return false;
    }

    if (clientSecondLastName.trim().length === 0) {
        clientSecondLastNameMessage.text("Segundo apellido no puede ir vac\u00EDo.");
        return false;
    }

    if (clientIdCard.trim().length === 0) {
        clientIdCardMessage.text("C\u00E9dula no puede ir vac\u00EDo.");
        return false;
    }

    if (clientphoneNumber.trim().length === 0) {
        clientphoneNumberMessage.text("Tel\u00E9fono no puede ir vac\u00EDo.");
        return false;
    }
    if (clientphoneNumber.trim().length < 8) {
        clientphoneNumberMessage.text("Debe tener m\u00EDnimo 8 n\u00FAmeros.");
        return false;
    }

    return true;
}
